using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Modbus.Device;

namespace WstCommonTools
{
    public class ModbusTcp
    {
        string address;
        int port = 502;
        bool mIsConnected;
        ModbusIpMaster master;
        TcpClient client;

        public string Address
        {
            get => address;
            set => address = value;
        }
        public int Port
        {
            get => port;
            set => port = value;
        }

        //判断有无连接
        public bool IsModbusTcpOpen()
        {
            try
            {
                client = new TcpClient(Address, Port);
                client.SendTimeout = 1;
                master = ModbusIpMaster.CreateIp(client);
                mIsConnected = true;
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                mIsConnected = false;
                return false;
            }

        }

        //栈号  //地址
        /// <summary>
        /// 05 写入单个线圈
        /// </summary>d
        public void WriteSingleCoil(byte SlaveID, ushort StartAdr, bool result)
        {
            if (!mIsConnected)
                return;
            master.WriteSingleCoil(SlaveID, StartAdr, result);

        }

        /// <summary>
        /// 0F 批量写入线圈
        /// </summary>
        public void WriteArrayCoil(byte SlaveID, ushort StartAdr, bool[] result)
        {
            if (!mIsConnected)
                return;
            master.WriteMultipleCoils(SlaveID, StartAdr, result);
        }



        /// <summary>
        /// 06 写入单个寄存器
        /// </summary>
        public int WriteSingleRegister(byte SlaveID, ushort StartAdr, ushort result)
        {
            try
            {
                if (!mIsConnected)
                    return -1;
                master.WriteSingleRegister(SlaveID, StartAdr, result);
                return 0;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex);
                return -1;
            }

        }

        /// <summary>
        /// 10 批量写入寄存器
        /// </summary>
        /// 
        public void WriteArrayRegister(byte SlaveID, ushort StartAdr, ushort[] result)
        {
            if (!mIsConnected)
                return;
            master.WriteMultipleRegisters(SlaveID, StartAdr, result);
        }




        /// <summary>
        /// 01 读取输出线圈
        /// </summary>
        /// <returns></returns>
        public bool[] ReadCoils(byte SlaveID, ushort StartAdr, ushort length)
        {
            if (!mIsConnected)
                return new bool[] { };
            return master.ReadCoils(SlaveID, StartAdr, length);
        }

        /// <summary>
        /// 02 读取输入线圈
        /// </summary>
        /// <returns></returns>
        public bool[] ReadInputs(byte SlaveID, ushort StartAdr, ushort length)
        {
            if (!mIsConnected)
                return new bool[] { };
            return master.ReadInputs(SlaveID, StartAdr, length);
        }



        /// <summary>
        /// 03 读取保持型寄存器
        /// </summary>
        /// <returns></returns>
        public ushort[] ReadHoldingRegisters(byte SlaveID, ushort StartAdr, ushort length)
        {
            if (!mIsConnected)
                return new ushort[] { };
            try
            {
                return master.ReadHoldingRegisters(SlaveID, StartAdr, length);
            }
            catch (Exception ex)
            {
                ushort[] aa = { 9999 };
                return aa;

            }

        }
    }
}
