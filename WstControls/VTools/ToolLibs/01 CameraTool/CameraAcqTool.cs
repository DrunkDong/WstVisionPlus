using WstCommonTools;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace WstControls
{
    [Serializable]
    public class CameraAcqTool : ToolBase
    {
        public CameraAcqTool()
        {
            Type = ToolType.Camera;
            ResultType = ToolResultType.Image;
            mReceiveEvent = new AutoResetEvent(false);
            mReceiveImage = false;

            mCamTriggerSource = TriggerSource.Software;
            mCameraTriggerMode = TriggerMode.Mode_Continue;

            mFolderImageQueue = new Queue<HObject>();
        }


        TriggerSource mCamTriggerSource;
        TriggerMode mCameraTriggerMode;
        CameraBase mCurrCamera;


        [NonSerialized]
        AutoResetEvent mReceiveEvent;
        [NonSerialized]
        HObject mCurrReceiveImage;
        [NonSerialized]
        bool mReceiveImage;
        [NonSerialized]
        Queue<HObject> mFolderImageQueue;
        

        public CameraBase CurrCamera
        {
            get => mCurrCamera;
            set => mCurrCamera = value;
        }
        public TriggerMode CameraTriggerMode
        {
            get => mCameraTriggerMode;
            set => mCameraTriggerMode = value;
        }
        public TriggerSource CamTriggerSource
        {
            get => mCamTriggerSource;
            set => mCamTriggerSource = value;
        }


        [ToolParamType(ParamType.image)]
        [ToolResult("ReceiveImage")]
        [Description("接收的图片")]
        public HObject CurrReceiveImage
        {
            get => mCurrReceiveImage;
            set => mCurrReceiveImage = value;
        }
        public Queue<HObject> FolderImageQueue
        {
            get => mFolderImageQueue;
            set => mFolderImageQueue = value;
        }

        public void CameraReceiveHandler(HObject obj)
        {
            if (mReceiveEvent != null)
                mReceiveEvent.Set();
        }
        public override void ReleaseReslut()
        {
            CurrReceiveImage?.Dispose();
        }

        public override OperateStatus ToolRun(List<ToolBase> toolList, bool mIsShowResult)
        {
            try
            {
                //相机文件夹里面有内容
                if (mFolderImageQueue.Count > 0)
                {
                    mCurrReceiveImage = new HObject();
                    HOperatorSet.GenEmptyObj(out mCurrReceiveImage);
                    mCurrReceiveImage = mFolderImageQueue.Dequeue();
                    mFolderImageQueue.Clear();
                    if (HObjectHelper.ObjectValided(mCurrReceiveImage))
                        return OperateStatus.OK;
                    return OperateStatus.Error;
                }

                //相机句柄为空
                if (mCurrCamera == null) 
                    return OperateStatus.Error;
                //进入采集流程
                mReceiveImage = true;
                while (mReceiveImage) 
                {                 
                    mReceiveEvent.WaitOne(500);
                    //工具强制停止
                    if (!mReceiveImage)
                        break;
                    //相机工具获取图片
                    if (!mCurrCamera.ImageBuff.IsEmpty)
                    {               
                        //清除上一次结果
                        mCurrReceiveImage?.Dispose();
                        mCurrCamera.ImageBuff.TryDequeue(out mCurrReceiveImage);
                        if (HObjectHelper.ObjectValided(mCurrReceiveImage))
                        {
                            if (mIsShowResult)
                            {
                                DebugWind.DispImage(mCurrReceiveImage);
                            }
                            return OperateStatus.OK;
                        }
                        else
                            return OperateStatus.Error;
                    }
                    else
                        Thread.Sleep(1);
                }
                return OperateStatus.Break;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("CameraAcqTool is Error\r" + ex.Message);
                return OperateStatus.Error;
            }
        }

        public override void RefreshToolSource(List<ToolBase> toolList)
        {
            int res = -1;
            //若输入源
            if (ImageSourceToolIDMark > 0)
            {
                foreach (var item in toolList)
                {
                    //扫描到自己就跳出
                    if (item.Equals(this))
                        break;
                    //扫到输入源就跳出
                    if (item.ToolID == ImageSourceToolIDMark)
                    {
                        res = 1;
                        break;
                    }
                }
                if (res < 1)
                {
                    ImageSourceToolIDMark = -1;
                    ImageSourceParam = "";
                }
            }
        }

        public override void ToolForceStop()
        {
            mReceiveImage = false;
        }
    }
}
