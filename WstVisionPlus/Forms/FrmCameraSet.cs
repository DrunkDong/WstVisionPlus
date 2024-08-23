using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Sunny.UI;
using WstControls;
using WstCommonTools;
using HalconDotNet;

namespace WstVisionPlus
{
    public partial class FrmCameraSet : UIForm
    {
        public FrmCameraSet()
        {
            InitializeComponent();
        }

        HShowWindow mShowWindow;
        CameraBase mCamera;
        bool mIsInit;
        bool mIsStart;
        Thread mThread;

        bool mIsTrigger;
        Thread mTriggerThread;

        int mImageCount;
        int mCameraIndex;

        public CameraBase Camera
        {
            get => mCamera;
            set => mCamera = value;
        }

        ProjectInfo mCurrProject;
        public ProjectInfo CurrProject
        {
            get => mCurrProject;
            set => mCurrProject = value;
        }
        public int CameraIndex
        {
            get => mCameraIndex;
            set => mCameraIndex = value;
        }

        private void FrmCameraSet_Load(object sender, EventArgs e)
        {
            mShowWindow = new HShowWindow();
            mShowWindow.Size = panel_Cam.Size;
            mShowWindow.Location = new Point(0, 0);
            panel_Cam.Controls.Add(mShowWindow);

            //设置字体
            mShowWindow.ShowWindow.SetFont("Consolas-26");
            //设置颜色
            mShowWindow.ShowWindow.SetColor("green");

            mIsStart = true;
            mThread = new Thread(new ThreadStart(GrabImage));
            mThread.IsBackground = true;
            mThread.Start();

            mTriggerThread = new Thread(new ThreadStart(TriggerCamera));
            mTriggerThread.IsBackground = true;
            mTriggerThread.Start();

            if (Camera != null)
            {
                Camera.SetTriggerSource(TriggerSource.Software);
                Camera.SetCameraMode(TriggerMode.Mode_SoftTrigger);
            }

            CamParamInfo info;
            Machine.GetInstance().CameraParam.GetParamValue(mCameraIndex, out info);
            Camera.SetCameraExposure(info.CameraExposure);
            Camera.SetCameraGain((float)info.CameraGain);
            Camera.SetTriggerDelay(info.TriggerDelay);

            InitControl();
            mIsInit = true;
            label_Project.Text = "项目：" + CurrProject.mProjectName;
        }


        private void GrabImage()
        {
            while (mIsStart)
            {
                if (!Camera.ImageBuff.IsEmpty)
                {
                    mImageCount++;
                    HObject obj;
                    Camera.ImageBuff.TryDequeue(out obj);
                    mShowWindow.ShowWindow.ClearWindow();
                    mShowWindow.DispObj(obj);
                    mShowWindow.ShowWindow.DispText("已采集: " + mImageCount + "pcs", "image", 0, 0, "green", (HTuple)"box", (HTuple)"false");
                    obj.Dispose();
                    Application.DoEvents();
                }
                else
                    Thread.Sleep(1);
            }
        }

        private void FrmCameraSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            mIsStart = false;
            mThread.Join();
            mTriggerThread.Join();
            this.DialogResult = DialogResult.OK;
        }

        private void UiButton_Start_Click(object sender, EventArgs e)
        {
            if (Camera != null)
            {
                Camera.StartGrab();
                uiButton_Start.Enabled = false;
                uiButton_Stop.Enabled = true;
                ControlBox = false;
                mIsTrigger = true;
                mImageCount = 0;
            }
        }

        private void UiButton_Stop_Click(object sender, EventArgs e)
        {
            if (Camera != null)
            {
                mIsTrigger = false;
                Camera.StopGrab();
                uiButton_Start.Enabled = true;
                uiButton_Stop.Enabled = false;
                ControlBox = true;
            }
        }

        private void UiIntegerUpDown_ChangeExposure_ValueChanged(object sender, int value)
        {
            if (!mIsInit)
                return;
            if (Camera != null)
                Camera.SetCameraExposure(uiIntegerUpDown_ChangeExposure.Value);

        }

        private void UiDoubleUpDown_ChangeGain_ValueChanged(object sender, double value)
        {
            if (!mIsInit)
                return;
            if (Camera != null)
                Camera.SetCameraGain((float)uiDoubleUpDown_ChangeGain.Value);
        }

        private void UiIntegerUpDown_ChangeTriggerDelay_ValueChanged(object sender, int value)
        {
            if (!mIsInit)
                return;
            if (Camera != null)
                Camera.SetTriggerDelay(uiIntegerUpDown_ChangeTriggerDelay.Value);
        }


        private void InitControl()
        {
            if (Camera != null)
            {
                FloatValue value1;
                FloatValue value2;
                FloatValue value3;
                Camera.GetCameraExposure(out value1);
                Camera.GetCameraGain(out value2);
                Camera.GetTriggerDelay(out value3);

                uiIntegerUpDown_ChangeExposure.Minimum = (int)value1.FloarMin;
                uiIntegerUpDown_ChangeExposure.Maximum = (int)value1.FloatMax;
                uiIntegerUpDown_ChangeExposure.Value = (int)value1.FloatCurr;

                uiDoubleUpDown_ChangeGain.Minimum = Math.Round(value2.FloarMin, 0);
                uiDoubleUpDown_ChangeGain.Maximum = Math.Round(value2.FloatMax, 0);
                uiDoubleUpDown_ChangeGain.Value = Math.Round(value2.FloatCurr, 0);

                uiIntegerUpDown_ChangeTriggerDelay.Minimum = (int)value3.FloarMin;
                uiIntegerUpDown_ChangeTriggerDelay.Maximum = (int)value3.FloatMax;
                uiIntegerUpDown_ChangeTriggerDelay.Value = (int)value3.FloatCurr;

            }
        }

        private void TriggerCamera()
        {
            while (mIsStart)
            {
                if (!mIsTrigger)
                {
                    Thread.Sleep(100);
                    continue;
                }
                if (Camera != null)
                {
                    Camera.SoftTrigger();
                }
                Thread.Sleep(50);
            }
        }

        private void UiButton_SaveParam_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "Project\\" + CurrProject.mProjectName + "\\camPar.cam";
            FloatValue value1;
            FloatValue value2;
            FloatValue value3;
            Camera.GetCameraExposure(out value1);
            Camera.GetCameraGain(out value2);
            Camera.GetTriggerDelay(out value3);
            CamParamInfo info = new CamParamInfo();
            info.CameraExposure = (int)Math.Round(value1.FloatCurr, 0);
            info.CameraGain = (int)Math.Round(value2.FloatCurr, 0);
            info.TriggerDelay = (int)Math.Round(value3.FloatCurr, 0);
            Machine.GetInstance().CameraParam.SetParamValue(mCameraIndex, info);

            if (Machine.GetInstance().SoapSerializeFuc(path, Machine.GetInstance().CameraParam))
                MessageBox.Show("保存成功");
            else
                MessageBox.Show("保存失败!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
