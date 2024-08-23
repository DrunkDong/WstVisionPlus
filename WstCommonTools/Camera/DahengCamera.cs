using GxIAPINET;
using HalconDotNet;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WstCommonTools
{
    [Serializable]
    public class DahengCamera : CameraBase
    {
        public DahengCamera()
        {
            mWidth = 0;
            mHeight = 0;
            mImageCount = 0;
            mSN = "";
            mPixelDeep = "Bpp10";
            mIsOpen = false;
            mMonoFlag = false;
            mImageBuff = new ConcurrentQueue<HObject>();
            mCameraManufacturer = CameraType.CameraType_Daheng;
            mCameraInterfaceType = "Gige";
        }


        private bool mIsOpen;
        private int mWidth;
        private int mHeight;
        private string mSN;
        private bool mMonoFlag;
        private string mPixelDeep;
        private int mImageCount;
        private string mCameraName;
        private CameraType mCameraManufacturer;
        private string mCameraInterfaceType;


        [NonSerialized]
        private ConcurrentQueue<HObject> mImageBuff;                                ///<图像队列>
        [NonSerialized]
        private static IGXFactory mobjIGXFactory = null;                            ///<Factory对像
        [NonSerialized]
        private IGXDevice mobjIGXDevice = null;                                     ///<设备对像
        [NonSerialized]
        private IGXStream mobjIGXStream = null;                                     ///<流对像
        [NonSerialized]
        private IGXFeatureControl mobjIGXFeatureControl = null;
        [NonSerialized]
        private GX_DEVICE_OFFLINE_CALLBACK_HANDLE mhCB = null;

        public delegate void CameraExceptiondelegate(string exceptionCode);
        public event CameraExceptiondelegate mCameraExceptiondelegateEvent;


        public override ConcurrentQueue<HObject> ImageBuff
        {
            get => mImageBuff;
            set => mImageBuff = value;
        }
        public override string SerialNum
        {
            get { return mSN; }
            set { mSN = value; }
        }

        public override bool MonoFlag
        {
            get => mMonoFlag;
        }

        public override int ImageWidth
        {
            get { return mWidth; }
        }

        public override int ImageHeight
        {
            get { return mHeight; }
        }

        public override int ImageCount
        {
            get => mImageCount;
            set => mImageCount = value;
        }

        public override string CameraName
        {
            get => mCameraName;
            set => mCameraName = value;
        }

        public override DelegateFrameReceived OnCameraFrameReceived
        {
            get;
            set;
        }
        public override CameraType CameraManufacturer
        {
            get => mCameraManufacturer;
            set => mCameraManufacturer = value;
        }
        public override string CameraInterfaceType
        {
            get => mCameraInterfaceType;
            set => mCameraInterfaceType = value;
        }

        public static bool QueryCamera(out List<CameraInfo> CameraInfolist)
        {
            CameraInfolist = new List<CameraInfo>();

            try
            {
                //枚举所有相机
                List<IGXDeviceInfo> listGXDeviceInfo = new List<IGXDeviceInfo>();
                mobjIGXFactory = IGXFactory.GetInstance();
                mobjIGXFactory.Init();

                mobjIGXFactory.UpdateDeviceList(500, listGXDeviceInfo);

                foreach (IGXDeviceInfo item in listGXDeviceInfo)
                {
                    CameraInfo info = new CameraInfo();
                    info.CamName = item.GetUserID();
                    if (item.GetDeviceClass() == GX_DEVICE_CLASS_LIST.GX_DEVICE_CLASS_U3V)
                        info.CamType = "USB3";
                    else if (item.GetDeviceClass() == GX_DEVICE_CLASS_LIST.GX_DEVICE_CLASS_GEV)
                        info.CamType = "Gige";
                    else
                        info.CamType = "";
                    info.CamSerialNumber = item.GetSN();
                    info.CamManufacturerType = GetCamManufacturerType(item.GetVendorName());
                    CameraInfolist.Add(info);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Query Cameras Errors", ex);
                return false;
            }
        }

        public static bool DeInitLib()
        {
            if (null != mobjIGXFactory)
            {
                mobjIGXFactory.Uninit();
            }
            return true;
        }

        public override bool OpenCamera(string SerialNumber)
        {
            if (null != mobjIGXStream)
            {
                mobjIGXStream.Close();
                mobjIGXStream = null;
            }

            if (null != mobjIGXDevice)
            {
                mobjIGXDevice.Close();
                mobjIGXDevice = null;
            }

            mSN = SerialNumber;
            try
            {
                mobjIGXDevice = mobjIGXFactory.OpenDeviceBySN(SerialNumber, GX_ACCESS_MODE.GX_ACCESS_EXCLUSIVE);
                mobjIGXFeatureControl = mobjIGXDevice.GetRemoteFeatureControl();

                //打开流
                if (null != mobjIGXDevice)
                {
                    mobjIGXStream = mobjIGXDevice.OpenStream(0);
                }

                //RegisterCaptureCallback第一个参数属于用户自定参数(类型必须为引用
                //类型)，若用户想用这个参数可以在委托函数中进行使用
                mobjIGXStream.RegisterCaptureCallback(this, OnDahengCameraFrameReceived);
                mhCB = mobjIGXDevice.RegisterDeviceOfflineCallback(null, OnDeviceOfflineCallbackFun);
                //确定图像格式
                if (mobjIGXFeatureControl.GetEnumFeature("PixelFormat").GetValue() == "Mono8")
                {
                    mMonoFlag = true;
                }
                else
                {
                    mMonoFlag = false;
                    mPixelDeep = mobjIGXFeatureControl.GetEnumFeature("PixelSize").GetValue();
                }
                //确定图像大小
                mWidth = (int)mobjIGXFeatureControl.GetIntFeature("Width").GetValue();
                mHeight = (int)mobjIGXFeatureControl.GetIntFeature("Height").GetValue();
                mIsOpen = true;
                return true;
            }
            catch (Exception ex)
            {
                mIsOpen = false;
                LogHelper.WriteExceptionLog(ex.Message);
                return false;
            }
        }

        public override bool CloseCamera()
        {
            if (!mIsOpen) return false;
            try
            {
                //关闭设备
                if (null != mobjIGXDevice)
                {
                    //注销采集回调函数
                    mobjIGXStream.UnregisterCaptureCallback();
                    //注销掉线回调函数
                    mobjIGXDevice.UnregisterDeviceOfflineCallback(mhCB);
                    mobjIGXDevice.Close();
                    mobjIGXDevice = null;
                    mobjIGXStream = null;
                    mobjIGXFeatureControl = null;
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Camera [" + mSN + "] Close Error\n" + ex.Message);
                MessageBox.Show("Camera [" + mSN + "] Close Error\n" + ex.Message);
                return false;
            }
        }

        public override bool StartGrab()
        {
            if (!mIsOpen) return false;
            try
            {
                if (null != mobjIGXStream)
                {
                    mImageBuff = new ConcurrentQueue<HObject>();
                    mobjIGXStream.StartGrab();
                }

                //发送开采命令
                if (null != mobjIGXFeatureControl)
                {
                    mobjIGXFeatureControl.GetCommandFeature("AcquisitionStart").Execute();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Camera [" + mSN + "] StartGrab Error\n" + ex.Message);
                MessageBox.Show("Camera [" + mSN + "] StartGrab Error\n" + ex.Message);
                return false;
            }

        }

        public override bool StopGrab()
        {
            if (!mIsOpen) return false;
            try
            {
                //发送停采命令
                if (null != mobjIGXFeatureControl)
                {
                    mobjIGXFeatureControl.GetCommandFeature("AcquisitionStop").Execute();
                }

                //关闭采集流通道
                if (null != mobjIGXStream)
                {
                    mobjIGXStream.StopGrab();
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Camera [" + mSN + "] StopGrab Error\n" + ex.Message);
                MessageBox.Show("Camera [" + mSN + "] StopGrab Error\n" + ex.Message);
                return false;
            }
        }

        public override bool SetCameraGain(float Gain)
        {
            if (!mIsOpen) return false;
            try
            {
                if (Gain > 0 && Gain < 1023)
                {
                    mobjIGXFeatureControl.GetFloatFeature("Gain").SetValue(Gain);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Camera [" + mSN + "] SetCameraGain Error\n" + ex.Message);
                MessageBox.Show("Camera [" + mSN + "] SetCameraGain Error\n" + ex.Message);
                return false;

            }
        }

        public override bool SetCameraExposure(float Exposure)
        {
            if (!mIsOpen) return false;
            try
            {
                if (Exposure > 1 && Exposure < 1000000)
                {
                    mobjIGXFeatureControl.GetFloatFeature("ExposureTime").SetValue(Exposure);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Camera [" + mSN + "] SetCameraExposure Error\n" + ex.Message);
                MessageBox.Show("Camera [" + mSN + "] SetCameraExposure Error\n" + ex.Message);
                return false;
            }
        }

        public override bool SetTriggerDelay(float delay)
        {
            if (!mIsOpen) return false;
            try
            {
                mobjIGXFeatureControl.GetFloatFeature("TriggerDelay").SetValue(delay);
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Camera [" + mSN + "] SetTriggerDelay Error\n" + ex.Message);
                MessageBox.Show("Camera [" + mSN + "] SetTriggerDelay Error\n" + ex.Message);
                return false;
            }
        }

        public override bool GetCameraExposure(out FloatValue mFloatValue)
        {
            mFloatValue = new FloatValue();
            if (!mIsOpen) return false;
            try
            {
                mFloatValue.FloatCurr = (float)mobjIGXFeatureControl.GetFloatFeature("ExposureTime").GetValue();
                mFloatValue.FloarMin = (float)mobjIGXFeatureControl.GetFloatFeature("ExposureTime").GetMin();
                mFloatValue.FloatMax = (float)mobjIGXFeatureControl.GetFloatFeature("ExposureTime").GetMax();
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex.Message);
                return false;
            }
        }

        public override bool GetCameraGain(out FloatValue mFloatValue)
        {
            mFloatValue = new FloatValue();
            if (!mIsOpen) return false;
            try
            {
                mFloatValue.FloatCurr = (float)mobjIGXFeatureControl.GetFloatFeature("Gain").GetValue();
                mFloatValue.FloarMin = (float)mobjIGXFeatureControl.GetFloatFeature("Gain").GetMin();
                mFloatValue.FloatMax = (float)mobjIGXFeatureControl.GetFloatFeature("Gain").GetMax();
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex.Message);
                return false;
            }
        }

        public override bool GetTriggerDelay(out FloatValue mFloatValue)
        {
            mFloatValue = new FloatValue();
            if (!mIsOpen) return false;
            try
            {
                mFloatValue.FloatCurr = (float)mobjIGXFeatureControl.GetFloatFeature("TriggerDelay").GetValue();
                mFloatValue.FloarMin = (float)mobjIGXFeatureControl.GetFloatFeature("TriggerDelay").GetMin();
                mFloatValue.FloatMax = (float)mobjIGXFeatureControl.GetFloatFeature("TriggerDelay").GetMax();
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex.Message);
                return false;
            }
        }

        public override bool SetCameraMode(TriggerMode Mode)
        {
            if (!mIsOpen) return false;
            try
            {
                if (Mode == TriggerMode.Mode_Continue)
                {
                    mobjIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("Off");
                }
                else
                {
                    mobjIGXFeatureControl.GetEnumFeature("TriggerMode").SetValue("On");
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex.Message);
                return false;
            }

        }

        public override bool SetTriggerSource(TriggerSource Source)
        {
            if (!mIsOpen) return false;
            try
            {
                if (Source == TriggerSource.Line1)
                {
                    mobjIGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Line0");
                }
                else if (Source == TriggerSource.Line2)
                {
                    mobjIGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Line2");
                }
                else
                {
                    mobjIGXFeatureControl.GetEnumFeature("TriggerSource").SetValue("Software");
                }
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex.Message);
                return false;
            }
        }

        public override bool SoftTrigger()
        {
            if (!mIsOpen) return false;
            try
            {
                mobjIGXFeatureControl.GetCommandFeature("TriggerSoftware").Execute();
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Camera [" + mSN + "] SoftTrigger Error\n" + ex.Message);
                MessageBox.Show("Camera [" + mSN + "] SoftTrigger Error\n" + ex.Message);
                return false;
            }
        }

        private void OnDahengCameraFrameReceived(object objUserParam, IFrameData objIFrameData)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                ulong Width = objIFrameData.GetWidth();
                ulong Height = objIFrameData.GetHeight();
                if (mMonoFlag)
                {
                    mImageCount++;
                    HOperatorSet.GenImage1(out HObject obj, "byte", mWidth, mHeight, (HTuple)objIFrameData.GetBuffer());
                    ImageBuff.Enqueue(obj);
                    OnCameraFrameReceived?.Invoke(obj);
                }
                else
                {
                    IntPtr BuffPtr;
                    if (mPixelDeep == "Bpp8")
                        BuffPtr = objIFrameData.ConvertToRGB24(GX_VALID_BIT_LIST.GX_BIT_0_7, GX_BAYER_CONVERT_TYPE_LIST.GX_RAW2RGB_NEIGHBOUR, false);
                    else if (mPixelDeep == "Bpp12")
                        BuffPtr = objIFrameData.ConvertToRGB24(GX_VALID_BIT_LIST.GX_BIT_4_11, GX_BAYER_CONVERT_TYPE_LIST.GX_RAW2RGB_NEIGHBOUR, false);
                    else
                        BuffPtr = objIFrameData.ConvertToRGB24(GX_VALID_BIT_LIST.GX_BIT_2_9, GX_BAYER_CONVERT_TYPE_LIST.GX_RAW2RGB_NEIGHBOUR, false);

                    HOperatorSet.GenImageInterleaved(out HObject obj, (HTuple)BuffPtr, "bgr", mWidth, mHeight, -1, "byte", mWidth, mHeight, 0, 0, -1, 0);
                    mImageCount++;
                    ImageBuff.Enqueue(obj);
                    OnCameraFrameReceived?.Invoke(obj);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog("相机 [" + this.SerialNum + "] " + ex);
            }
            sw.Stop();
            if (sw.ElapsedMilliseconds > 50)
                LogHelper.WriteErrorLog("相机 [" + this.SerialNum + "] 取流超时，" + sw.ElapsedMilliseconds.ToString() + "ms");
        }

        private void OnDeviceOfflineCallbackFun(object pUserParam)
        {
            try
            {
                //打开失败
                mIsOpen = false;
                if (mCameraExceptiondelegateEvent != null)
                    mCameraExceptiondelegateEvent("Daheng [" + this.SerialNum + "] Camera Offline");
            }
            catch (Exception)
            {

            }
        }

        private static CameraType GetCamManufacturerType(string str)
        {
            if (string.IsNullOrEmpty(str))
                return CameraType.CameraType_HiKang;
            if (str.Contains("Daheng"))
                return CameraType.CameraType_Daheng;
            else if (str.Contains("Hikrobot"))
                return CameraType.CameraType_HiKang;
            else
                return CameraType.CameraType_HiKang;
        }

    }
}
