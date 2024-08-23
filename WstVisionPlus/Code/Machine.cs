using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WstCommonTools;
using WstControls;
using HalconDotNet;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Windows.Forms;

namespace WstVisionPlus
{
    public delegate void SoceketReceiveDel(string mes);
    public class Machine : SingletonTemplate<Machine>
    {
        public readonly string SettingInfoSavePath = AppDomain.CurrentDomain.BaseDirectory + "\\AppConfig\\Setting.dat";

        int mOkNumber;
        int mNGNumber;
        int mAllNumber;


        List<HWindow> mHWindowList;
        List<HShowWindow> mHWindowControlList;
        List<CameraBase> mCamList;
        List<ProjectInfo> mProjectInfoList;
        List<DetectTaskBase> mTaskList;
        ProjectInfo mCurrProjectInfo;
        UserAccess mUserAccessOp;
        TCPClient mSocket_Client;
        ModbusTcp mModbus_Tcp;
        ZmotionOperation mZmotion;
        SettingInfo mSettingInfo;
        string mSavePath;
        SoceketReceiveDel mSoceketReceive;

        CamParam mCameraParam;
        bool mIsGrabDebug;

        FrmProjectSet mFrmProject;


        public List<HWindow> HWindowList
        {
            get => mHWindowList;
            set => mHWindowList = value;
        }
        public List<HShowWindow> HWindowControlList
        {
            get => mHWindowControlList;
            set => mHWindowControlList = value;
        }
        public List<CameraBase> CamList
        {
            get => mCamList;
            set => mCamList = value;
        }
        public ProjectInfo CurrProjectInfo
        {
            get => mCurrProjectInfo;
            set => mCurrProjectInfo = value;
        }
        public List<ProjectInfo> ProjectInfoList
        {
            get => mProjectInfoList;
            set => mProjectInfoList = value;
        }
        public UserAccess UserAccessOp
        {
            get => mUserAccessOp;
            set => mUserAccessOp = value;
        }
        public TCPClient Socket_Client
        {
            get => mSocket_Client;
            set => mSocket_Client = value;
        }
        public ModbusTcp Modbus_Tcp
        {
            get => mModbus_Tcp;
            set => mModbus_Tcp = value;
        }
        public ZmotionOperation Zmotion
        {
            get => mZmotion;
            set => mZmotion = value;
        }
        public SettingInfo SettingInfo
        {
            get => mSettingInfo;
            set => mSettingInfo = value;
        }
        public string SavePath
        {
            get => mSavePath;
            set => mSavePath = value;
        }
        public List<DetectTaskBase> TaskList
        {
            get => mTaskList;
            set => mTaskList = value;
        }
        public SoceketReceiveDel SoceketReceive
        {
            get => mSoceketReceive;
            set => mSoceketReceive = value;
        }
        public int OkNumber
        {
            get => mOkNumber;
            set => mOkNumber = value;
        }
        public int NGNumber
        {
            get => mNGNumber;
            set => mNGNumber = value;
        }
        public int AllNumber
        {
            get => mAllNumber;
            set => mAllNumber = value;
        }
        public CamParam CameraParam
        {
            get => mCameraParam;
            set => mCameraParam = value;
        }
        public bool IsGrabDebug
        {
            get => mIsGrabDebug;
            set => mIsGrabDebug = value;
        }
        public FrmProjectSet FrmProject
        {
            get => mFrmProject;
            set => mFrmProject = value;
        }

        public Machine()
        {
            mHWindowList = new List<HWindow>();
            mHWindowControlList = new List<HShowWindow>();
            mCamList = new List<CameraBase>();
            mCurrProjectInfo = new ProjectInfo();
            mProjectInfoList = new List<ProjectInfo>();
            mUserAccessOp = new UserAccess();
            Socket_Client = new TCPClient();
            mModbus_Tcp = new ModbusTcp();
            mZmotion = new ZmotionOperation();
            mSettingInfo = new SettingInfo();
            mSavePath = "E:\\Images\\";
            mSoceketReceive = null;
            mCameraParam = new CamParam();
            mIsGrabDebug = true;
        }

        public bool DeSerializeFuc<T>(string path, out T param) where T : class, new()
        {
            param = new T();
            if (!File.Exists(path))
                return false;

            FileStream fStream = new FileStream(path, FileMode.Open);
            try
            {
                BinaryFormatter soapFormat = new BinaryFormatter();
                param = (T)soapFormat.Deserialize(fStream);
                fStream.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                fStream.Close();
                return false;
            }
        }

        public bool SerializeFuc<T>(string path, T param)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\AppConfig"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\AppConfig").Create();
            FileStream fStream = new FileStream(path, FileMode.OpenOrCreate);
            try
            {
                BinaryFormatter Format = new BinaryFormatter();
                Format.Serialize(fStream, param);
                fStream.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                fStream.Close();
                return false;
            }
        }



        public bool DeSoapSerializeFuc<T>(string path, out T param) where T : class, new()
        {
            param = new T();
            if (!File.Exists(path))
                return false;
            FileStream fStream = new FileStream(path, FileMode.Open);
            try
            {
                SoapFormatter soapFormat = new SoapFormatter();
                param = (T)soapFormat.Deserialize(fStream);
                fStream.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                fStream.Close();
                return false;
            }
        }

        public bool SoapSerializeFuc<T>(string path, T param)
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\AppConfig"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\AppConfig").Create();
            FileStream fStream = new FileStream(path, FileMode.OpenOrCreate);
            try
            {
                SoapFormatter Format = new SoapFormatter();
                Format.Serialize(fStream, param);
                fStream.Close();
                return true;
            }
            catch (System.Exception ex)
            {
                fStream.Close();
                return false;
            }
        }


        public bool GetRemainMemeory(string str_HardDiskName) //磁盘号
        {
            try
            {
                long freeSpace = new long();
                str_HardDiskName = str_HardDiskName + ":\\";
                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    if (drive.Name == str_HardDiskName)
                    {
                        freeSpace = drive.TotalFreeSpace / (1024 * 1024 * 1024);//转GB
                    }
                }
                if (freeSpace < SettingInfo.LowDiskCapacity)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex.Message);
                return false;
            }
        }
    }
}
