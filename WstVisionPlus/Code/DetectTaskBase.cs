using System;
using System.Collections.Concurrent;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WstCommonTools;
using HalconDotNet;
using WstControls;

namespace WstVisionPlus
{
    public abstract class DetectTaskBase
    {
        bool mIsStart;
        double mOkCount;
        double mNgCount;
        double mCount;
        double mCostTime;
        CameraBase mCamera;
        string mTaskNmae;
        string mSaveFolderName;
        bool mTaskThreadRunFlag;
        Thread mTaskRunThread;
        ConcurrentQueue<string> mTaskResultQueue;
        TaskSaveProcess mSaveProcess;

        public bool IsStart
        {
            get => mIsStart;
            set => mIsStart = value;
        }
        public double OkCount
        {
            get => mOkCount;
            set => mOkCount = value;
        }
        public double NgCount
        {
            get => mNgCount;
            set => mNgCount = value;
        }
        public double Count
        {
            get => mCount;
            set => mCount = value;
        }
        public double CostTime
        {
            get => mCostTime;
            set => mCostTime = value;
        }
        public ConcurrentQueue<string> TaskResultQueue
        {
            get => mTaskResultQueue;
            set => mTaskResultQueue = value;
        }
        public CameraBase Camera
        {
            get => mCamera;
            set => mCamera = value;
        }
        public string TaskNmae
        {
            get => mTaskNmae;
            set => mTaskNmae = value;
        }
        public string SaveFolderName
        {
            get => mSaveFolderName;
            set => mSaveFolderName = value;
        }
        public bool TaskThreadRunFlag
        {
            get => mTaskThreadRunFlag;
            set => mTaskThreadRunFlag = value;
        }
        public Thread TaskRunThread
        {
            get => mTaskRunThread;
            set => mTaskRunThread = value;
        }
        public TaskSaveProcess SaveProcess
        {
            get => mSaveProcess;
            set => mSaveProcess = value;
        }

        /// <summary>
        /// 检测启动
        /// </summary>
        public abstract void CheckStart();
        /// <summary>
        /// 检测暂停
        /// </summary>
        public abstract void CheckStop();

        /// <summary>
        /// 释放工具
        /// </summary>
        public abstract void ReleaseTool();

        /// <summary>
        /// 退出释放资源
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// 无参线程方法
        /// </summary>
        public abstract void ThreadRunTask();

        //存图方法
        public void SaveImageFuc(object save1)
        {
            SaveImageClass save = (SaveImageClass)save1;
            if (save == null) return;
            if (save.mSavePath == "") return;
            if (!HObjectHelper.ObjectValided(save.mImage)) return;

            if (!Directory.Exists(save.mSavePath))
                Directory.CreateDirectory(save.mSavePath);
            if (save.mSaveModel == 0)
            {
                SaveOKImage(save.mImage, save.mSavePath, save.mSaveName);
            }
            else
            {
                SaveNGImage(save.mImage, save.mSavePath, save.mSaveName);
            }
            save.mImage.Dispose();
        }

        //存OK图
        public void SaveOKImage(HObject obj, string path, string name)
        {
            try
            {
                string mFinalFath = path + "\\OK\\";
                if (!Directory.Exists(mFinalFath))
                    Directory.CreateDirectory(mFinalFath);
                if (!Directory.Exists(mFinalFath))
                    Directory.CreateDirectory(mFinalFath);
                if (Machine.GetInstance().SettingInfo.SaveOKMode == 0)
                    return;
                string fomat = "jpeg";
                if (Machine.GetInstance().SettingInfo.SaveOKMode == 1)
                    fomat = "jpeg";
                else if (Machine.GetInstance().SettingInfo.SaveOKMode == 2)
                    fomat = "png";
                else if (Machine.GetInstance().SettingInfo.SaveOKMode == 3)
                    fomat = "bmp";
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    HOperatorSet.WriteImage(obj, fomat, 0, mFinalFath + name);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Save OK Image Error:" + ex);
            }
        }

        //存NG图
        public void SaveNGImage(HObject obj, string path, string name)
        {
            try
            {
                string mFinalFath = path + "\\NG\\";
                if (!Directory.Exists(mFinalFath))
                    Directory.CreateDirectory(mFinalFath);
                if (Machine.GetInstance().SettingInfo.SaveNGMode == 0)
                    return;
                string fomat = "jpeg";
                if (Machine.GetInstance().SettingInfo.SaveNGMode == 1)
                    fomat = "jpeg";
                else if (Machine.GetInstance().SettingInfo.SaveNGMode == 2)
                    fomat = "png";
                else if (Machine.GetInstance().SettingInfo.SaveNGMode == 3)
                    fomat = "bmp";
                using (HDevDisposeHelper dh = new HDevDisposeHelper())
                {
                    HOperatorSet.WriteImage(obj, fomat, 0, mFinalFath + name);
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Save NG Image Error:" + ex);
            }
        }
    }

    public class SaveImageClass
    {
        public HObject mImage;
        public string mSavePath;
        public int mSaveModel;
        public string mSaveName;

        public SaveImageClass()
        {
            HOperatorSet.GenEmptyObj(out mImage);
        }
    }
}
