using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HalconDotNet;
using WstControls;
using WstCommonTools;
using System.IO;

namespace WstVisionPlus
{
   public class TaskSaveProcess
    {
        Machine mMachine;
        ConcurrentQueue<ResultBuff> mResBuffQueue;
        ConcurrentQueue<SaveImageBuff> mSaveImageBuffQueue;

        HShowWindow mShowWind;
        Thread mSaveResultThread;
        Thread mSaveImageThread;

        bool mThreadRun;
        int FinalResult;
        int num;

        public TaskSaveProcess()
        {
            mMachine = Machine.GetInstance();
            mResBuffQueue = new ConcurrentQueue<ResultBuff>();
            mSaveImageBuffQueue = new ConcurrentQueue<SaveImageBuff>();
            mThreadRun = true;
            mSaveResultThread = new Thread(new ThreadStart(SaveResultProcess));
            mSaveResultThread.IsBackground = true;
            mSaveResultThread.Start();
            mSaveImageThread = new Thread(new ThreadStart(SaveImageProcess));
            mSaveResultThread.IsBackground = true;
            mSaveImageThread.Start();
        }

        public void Enqueue(ResultBuff obj)
        {
            mResBuffQueue.Enqueue(obj);
        }

        public void SetShowWind(HShowWindow wind)
        {
            this.mShowWind = wind;
        }
        public void Close()
        {
            mThreadRun = false;
            mSaveResultThread.Join();
            mSaveImageThread.Join();
            mResBuffQueue = null;

        }
        //存结果
        private void SaveResultProcess()
        {
            while (mThreadRun)
            {
                if (mResBuffQueue.Count > 0)
                {
                    num = 0;
                    ResultBuff buff;
                    mResBuffQueue.TryDequeue(out buff);

                    SaveImageBuff buff2 = new SaveImageBuff();

                    //判断OKorNG
                    for (int i = 0; i < buff.mOperateStatus.Count; i++)
                    {
                        if (buff.mOperateStatus[i] != 0)
                        {
                            FinalResult = buff.mOperateStatus[i];
                            num = i;
                            break;
                        }
                        num = i;
                        FinalResult = buff.mOperateStatus[i];
                    }


                    if (FinalResult != 0)
                    {
                        mShowWind.DispObj(buff.mResBuff[num]);
                        mShowWind.ShowWindow.SetColor("red");
                        mShowWind.ShowWindow.SetDraw("margin");
                        mShowWind.ShowWindow.SetLineWidth(2);
                        HOperatorSet.GetImageSize(buff.mResBuff[num], out HTuple w, out HTuple h);
                        if (buff.mShowNGResult != null)
                        {
                            mShowWind.ShowWindow.DispObj(buff.mShowNGResult);
                        }
                        mShowWind.ShowWindow.SetFont("微软雅黑-Bold-40");
                        mShowWind.ShowWindow.DispText("NG", "image", 0, 0, "red", "box", "false");
                    }
                    else
                    {
                        mShowWind.DispObj(buff.mResBuff[num]);
                        mShowWind.ShowWindow.SetColor("green");
                        mShowWind.ShowWindow.SetDraw("margin");
                        mShowWind.ShowWindow.SetLineWidth(2);
                        mShowWind.ShowWindow.SetFont("微软雅黑-Bold-40");
                        mShowWind.ShowWindow.DispText("PASS", "image", 0, 0, "green", "box", "false");

                        if (buff.mShowOKResult != null)
                        {
                            mShowWind.ShowWindow.DispObj(buff.mShowOKResult);
                        }
                    }

                    buff2.mResBuff = buff.mResBuff;
                    buff2.mOperateStatus = buff.mOperateStatus;
                    buff2.mSavePath = buff.mSavePath;
                    buff2.mErrorToolName = buff.mErrorToolName;
                    buff2.mName = buff.mName;
                    mSaveImageBuffQueue.Enqueue(buff2);
                    Thread.Sleep(1);
                }
                else
                {
                    Thread.Sleep(1);
                }
            }
        }

        //存图
        private void SaveImageProcess()
        {
            while (mThreadRun)
            {
                if (mSaveImageBuffQueue.Count > 0)
                {

                    SaveImageBuff buff;
                    mSaveImageBuffQueue.TryDequeue(out buff);
                    if (GetRemainMemeory("E") == 0)
                    {
                        for (int i = 0; i < buff.mOperateStatus.Count; i++)
                        {
                            //存图
                            if (buff.mOperateStatus[i] != 0)
                            {
                                if (mMachine.SettingInfo.IsSaveNgByClass)
                                {
                                    SaveNGImageByClass(buff.mResBuff[i], buff.mSavePath, buff.mErrorToolName, buff.mName + "-" + (i + 1).ToString());
                                }
                                else
                                {
                                    SaveNGImage(buff.mResBuff[i], buff.mSavePath, buff.mName + "-" + (i + 1).ToString());
                                }
                            }
                            else
                            {
                                SaveOKImage(buff.mResBuff[i], buff.mSavePath, buff.mName + "-" + (i + 1).ToString());
                            }
                            //释放资源
                            buff.mResBuff[i].Dispose();
                            Thread.Sleep(1);
                        }

                    }
                }
                Thread.Sleep(1);
            }
        }

        private void SaveOKImage(HObject obj, string path, string name)
        {
            try
            {
                string mFinalFath = path + "\\OK\\";
                if (!Directory.Exists(mFinalFath))
                    Directory.CreateDirectory(mFinalFath);
                if (!Directory.Exists(mFinalFath))
                    Directory.CreateDirectory(mFinalFath);
                if (mMachine.SettingInfo.SaveOKMode == 0)
                    return;
                string fomat = "jpeg";
                if (mMachine.SettingInfo.SaveOKMode == 1)
                    fomat = "jpeg";
                else if (mMachine.SettingInfo.SaveOKMode == 2)
                    fomat = "png";
                else if (mMachine.SettingInfo.SaveOKMode == 3)
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
        private void SaveNGImage(HObject obj, string path, string name)
        {
            try
            {
                string mFinalFath = path + "\\NG\\";
                if (!Directory.Exists(mFinalFath))
                    Directory.CreateDirectory(mFinalFath);
                if (mMachine.SettingInfo.SaveNGMode == 0)
                    return;
                string fomat = "jpeg";
                if (mMachine.SettingInfo.SaveNGMode == 1)
                    fomat = "jpeg";
                else if (mMachine.SettingInfo.SaveNGMode == 2)
                    fomat = "png";
                else if (mMachine.SettingInfo.SaveNGMode == 3)
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
        //分类存图
        private void SaveNGImageByClass(HObject obj, string path, string folderName, string name)
        {
            try
            {
                string mFinalFath = path + "\\NgClass\\" + folderName + "\\";
                if (!Directory.Exists(mFinalFath))
                    Directory.CreateDirectory(mFinalFath);
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Save NG Image Error:" + ex);
            }
        }

        private int GetRemainMemeory(string str_HardDiskName) //磁盘号
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
                if (freeSpace < 20)
                    return 1;
                return 0;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(ex.Message);
                return -1;
            }
        }
    }

    public class ResultBuff
    {
        public List<HObject> mResBuff;
        public HObject mShowOKResult;
        public HObject mShowNGResult;
        public List<int> mOperateStatus;
        public string mSavePath;
        public string mName;
        public string mErrorToolName;
        public List<string> mStrShowList;

        public ResultBuff()
        {
            mShowOKResult = new HObject();
            HOperatorSet.GenEmptyObj(out mShowOKResult);
            mShowNGResult = new HObject();
            HOperatorSet.GenEmptyObj(out mShowNGResult);

            mResBuff = new List<HObject>();
            mOperateStatus = new List<int>();
        }
    }
    public class SaveImageBuff
    {
        public List<HObject> mResBuff;
        public List<int> mOperateStatus;
        public string mSavePath;
        public string mName;
        public string mErrorToolName;

        public SaveImageBuff()
        {

            mResBuff = new List<HObject>();
            mOperateStatus = new List<int>();

        }
    }
}
