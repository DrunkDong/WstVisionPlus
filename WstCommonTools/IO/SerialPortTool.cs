using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstCommonTools
{
    public class SerialPortTool
    {
        SerialPort mTool;
        SerialPortInfo mSerialPortInfo;
        bool mIsOpen;

        public delegate void SerialPortReceiveCallback(string receiveData);
        public event SerialPortReceiveCallback SerialPortReceiveEvent;


        public SerialPort MTool
        {
            get => mTool;
            set => mTool = value;
        }
        public SerialPortInfo SerialPortInfo
        {
            get => mSerialPortInfo;
            set => mSerialPortInfo = value;
        }
        public bool IsOpen
        {
            get => mIsOpen;
            set => mIsOpen = value;
        }

        public SerialPortTool()
        {
            mTool = new SerialPort();
            mTool.DataReceived += Tool_DataReceived;

        }

        private void Tool_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            SerialPortReceiveEvent?.Invoke(indata);
        }

        public void SendData(string sendData)
        {
            if (mIsOpen)
            {
                if (sendData.Length > 0)
                {
                    mTool.Write(sendData);
                }
            }

        }

        public int OpenSerialPort()
        {
            mIsOpen = false;
            mTool.PortName = mSerialPortInfo.PortName;
            mTool.BaudRate = mSerialPortInfo.BaudRate;
            mTool.DataBits = mSerialPortInfo.DataBits;
            mTool.Parity = Parity.None;
            mTool.StopBits = StopBits.One;
            mTool.ReadTimeout = mSerialPortInfo.ReadTimeOut;
            mTool.WriteTimeout = mSerialPortInfo.WriteTimeOut;
            try
            {
                mTool.Open();
                IsOpen = true;
                return 0;
            }
            catch (Exception)
            {
                IsOpen = false;
                return 1;
            }
        }

        public void CloseSerialPort()
        {
            if (IsOpen)
                mTool.Close();
        }



    }
    [Serializable]
    public class SerialPortInfo
    {
        string portName;//串口号
        int baudRate;//波特率
        int dataBits;//数据位
        int readTimeOut;//读取超时
        int writeTimeOut;//发送超时

        [DisplayName("串口号")]
        public string PortName { get => portName; set => portName = value; }
        [DisplayName("波特率")]
        public int BaudRate { get => baudRate; set => baudRate = value; }
        [DisplayName("数据位")]
        public int DataBits { get => dataBits; set => dataBits = value; }
        [DisplayName("读取超时(ms)")]
        public int ReadTimeOut { get => readTimeOut; set => readTimeOut = value; }
        [DisplayName("发送超时(ms)")]
        public int WriteTimeOut { get => writeTimeOut; set => writeTimeOut = value; }

        public SerialPortInfo()
        {
            portName = "COM1";
            baudRate = 9600;
            dataBits = 8;
            readTimeOut = 500;
            writeTimeOut = 500;
        }
    }

}
