using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WstCommonTools;

namespace WstVisionPlus
{
    [Serializable]
    public class SettingInfo
    {
        public string ModbusIP;
        public int ModbusPort;
        public string RobotIP;
        public int RobotPort;
        public string PlateIP;
        public int PlatePort;
        public string MotionCardIP;
        public int SaveOKMode;
        public int SaveNGMode;
        public string SaveImagePath;
        public double LowYeild;
        public double LowDiskCapacity;
        public double AnomalyCount;

        public int FocusPosition;
        public int MoveSpeed;
        public int OffSetPosition;
        public int Frequency;
        public int Distance;
        public int CameraExposure1;
        public int CameraExposure2;

        public double TopLeftX;
        public double TopLeftY;
        public double LowerRightX;
        public double LowerRightY;

        public bool RoiFlag;

        public List<double> ROIRowList;
        public List<double> ROIColList;

        public bool IsSaveNgByClass;
        public List<ProjectInfo> ProjectInfoList;
        public List<CameraInfo> CameraInfoList;
        public int GlobalEnableCamNums;
        public ProjectInfo SelectProject;
        public SettingInfo()
        {
            GlobalEnableCamNums = 0;
            FocusPosition = 25704;
            MoveSpeed = 100000;
            OffSetPosition = 0;
            Frequency = 10;
            Distance = 110;
            CameraExposure1 = 200;
            CameraExposure2 = 2000;

            TopLeftX = 0;
            TopLeftY = 0;
            LowerRightX = 1;
            LowerRightY = 1;
            RoiFlag = false;
            ROIRowList = new List<double>();
            ROIColList = new List<double>();
            IsSaveNgByClass = false;
            ProjectInfoList = new List<ProjectInfo>();
            CameraInfoList = new List<CameraInfo>();
            SelectProject = new ProjectInfo();

            ModbusIP = "172.17.0.1";
            ModbusPort = 3000;
            RobotIP = "172.17.1.1";
            RobotPort = 4000;
            PlateIP = "172.17.2.1";
            PlatePort = 5000;
            MotionCardIP = "172.17.3.1";
            SaveOKMode = 0;
            SaveNGMode = 0;
            SaveImagePath = "E:\\Images\\";
            LowYeild = 50;
            LowDiskCapacity = 50;
            AnomalyCount = 100;
        }
    }


    [Serializable]
    public class ProjectInfo
    {
        public int mActiveCamNum;
        public string mProjectName;
        public string mProjectDescribe;
        public string mProjectCreateTime;

        public ProjectInfo()
        {
            mActiveCamNum = 6;
            mProjectName = "";
            mProjectDescribe = "";
            mProjectCreateTime = "";
        }
    }
}
