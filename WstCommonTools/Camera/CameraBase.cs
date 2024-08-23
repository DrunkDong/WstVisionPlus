using System;
using HalconDotNet;
using System.Collections.Concurrent;

namespace WstCommonTools
{
    [Serializable]
    //抽象类接口，作为相机SDK基类
    public abstract class CameraBase
    {
        #region Properties
        public virtual int ImageCount { get; set; }
        public virtual double ImageSize { get; set; }
        public abstract int ImageWidth { get; }
        public abstract int ImageHeight { get; }
        public abstract string SerialNum { get; set; }
        public abstract string CameraName { get; set; }
        public abstract bool MonoFlag { get; }
        public abstract CameraType CameraManufacturer { get; set; }
        public abstract ConcurrentQueue<HObject> ImageBuff { get; set; }
        public virtual DelegateFrameReceived OnCameraFrameReceived { get; set; }
        public abstract string CameraInterfaceType { get; set; }

        #endregion

        #region Delegate
        public delegate void DelegateFrameReceived(HObject Frame);
        #endregion

        #region Implements
        //Connect and allocate resource of camera by serial number
        public abstract bool OpenCamera(string SerialNumber);
        //Disconnect and release resource of camera
        public abstract bool CloseCamera();
        // Start to acquire frames
        public abstract bool StartGrab();
        // Stop to acquire frames
        public abstract bool StopGrab();
        //Get one frame
        public virtual OperateStatus GrabImage(out byte[] ImageBuff)
        {
            ImageBuff = null;
            return OperateStatus.Virtual;
        }
        public abstract bool SetCameraMode(TriggerMode Mode);
        public abstract bool SetTriggerSource(TriggerSource Source);

        public virtual bool GetCameraExposure(out FloatValue time)
        {
            time = new FloatValue();
            return true;
        }

        public virtual bool GetCameraGain(out FloatValue gain)
        {
            gain = new FloatValue();
            return true;
        }

        public virtual bool GetTriggerDelay(out FloatValue delay)
        {
            delay = new FloatValue();
            return true;
        }
        public virtual bool SetTriggerDelay(float delay)
        {
            return true;
        }
        
        //Set camera exposure time
        public abstract bool SetCameraExposure(float Exposure);
        //Set camera gain
        public abstract bool SetCameraGain(float Gain);
        // Send camera command
        public abstract bool SoftTrigger();
        #endregion
    }

    public enum TriggerMode
    {
        Mode_Continue,
        Mode_Trigger,
        Mode_SoftTrigger,
    }

    public enum TriggerSource
    {
        Line0,
        Line1,
        Line2,
        Line3,
        Encoder,
        Software
    }

    public struct FloatValue
    {
        public float FloatMax;
        public float FloarMin;
        public float FloatCurr;
    }

    [Serializable]
    public enum CameraType //枚举相机厂家类型
    {
        CameraType_UnKnown = -1,
        CameraType_HiKang = 0,
        CameraType_Daheng = 1
    }

    [Serializable]
    public class CameraInfo
    {
        public string CamType;
        public string CamName;
        public string CamSerialNumber;
        public CameraType CamManufacturerType;
    }
}
