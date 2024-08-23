using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Sunny.UI;
using WstControls;
using HalconDotNet;
using WstCommonTools;

namespace WstVisionPlus
{
    public partial class MainForm : UIForm
    {
        public MainForm()
        {
            InitializeComponent();
            mRunMessageWindow = new UMessageListView();
            mRunMessageWindow.Size = panel_MessageBox.Size;
            mRunMessageWindow.Parent = panel_MessageBox;
        }

        Machine mMachine;
        UMessageListView mRunMessageWindow;
        DataTable info;

        bool mThreadRun;
        bool mIsStart;
        Thread mThreadGetFinalResult;
        string[] RobotStep = new string[10];
        string[] RobotState = new string[4];

        private void MainForm_Load(object sender, EventArgs e)
        {
            //设置线程池状态
            ThreadPool.SetMinThreads(5, 5);
            ThreadPool.SetMaxThreads(12, 12);
            FrmStartLoad load = new FrmStartLoad();
            load.StartPosition = FormStartPosition.CenterScreen;
            load.Show();
            load.Refresh();

            HOperatorSet.SetSystem("clip_region", "false");
            mMachine = Machine.GetInstance();
            load.SetValue(10, "配置文件读取中...");
            //初始化配置文件
            SettingInfo info;
            if (mMachine.DeSerializeFuc(mMachine.SettingInfoSavePath, out info))
            {
                mMachine.SettingInfo = info;
                mMachine.ProjectInfoList = info.ProjectInfoList;
                mMachine.CurrProjectInfo = info.SelectProject;
            }
            else
            {
                MessageBox.Show("配置文件读取失败!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                info = new SettingInfo();
                mMachine.SettingInfo = info;
            }
            int va = 20;
            //初始化相机
            for (int i = 0; i < mMachine.SettingInfo.CameraInfoList.Count; i++)
            {
                va += 5 * 1;
                load.SetValue(va, "相机 " + mMachine.SettingInfo.CameraInfoList[i].CamSerialNumber + " 打开中");
                Application.DoEvents();
                CameraBase cam = GetCameraClass(mMachine.SettingInfo.CameraInfoList[i].CamManufacturerType);
                if (cam == null) 
                {
                    MessageBox.Show("未知相机类型");
                    continue;
                }             
                if (cam.OpenCamera(mMachine.SettingInfo.CameraInfoList[i].CamSerialNumber) && mMachine.SettingInfo.CameraInfoList[i].CamSerialNumber != "")
                {
                    mMachine.CamList.Add(cam);
                }
                else
                {
                    if (mMachine.SettingInfo.CameraInfoList[i].CamSerialNumber != "")
                        MessageBox.Show("相机序列号为[" + mMachine.SettingInfo.CameraInfoList[i].CamSerialNumber + "]的相机打开失败!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mMachine.CamList.Add(null);
                }
            }
            //初始化任务
            load.SetValue(70, "任务初始化中...");
            InitTask();
            //初始化任务窗口
            load.SetValue(80, "窗口初始化中...");
            InitImageShowWindow(6);
            InitDataGridView(6);
            InitTaskWindow();

            //mThreadRun = true;
            //mIsStart = false;
            //mThreadGetFinalResult = new Thread(new ThreadStart(GetFinalResult));
            //mThreadGetFinalResult.IsBackground = true;
            //mThreadGetFinalResult.Start();

            timer_Refresh.Start();
            this.Refresh();
            load.SetValue(100, "加载完成");
            load.Close();
        }


        private void InitImageShowWindow(int num)
        {
            for (int i = 0; i < num; i++)
            {
                HShowWindow window = new HShowWindow();
                this.Panel_Camera.Controls.Add(window);
                mMachine.HWindowControlList.Add(window);
            }
        }

        private void InitDataGridView(int num)
        {
            info = new DataTable();
            info.Columns.Add("相机序号", typeof(string));
            info.Columns.Add("拍照次数", typeof(string));
            info.Columns.Add("产品个数", typeof(string));
            info.Columns.Add("良品总数", typeof(string));
            info.Columns.Add("不良总数", typeof(string));
            info.Columns.Add("良品比例", typeof(string));
            info.Columns.Add("表面压伤", typeof(string));
            info.Columns.Add("表面破损", typeof(string));
            info.Columns.Add("对比度缺陷", typeof(string));
            info.Columns.Add("尺寸不良", typeof(string));
            info.Columns.Add("检测耗时", typeof(string));
            dataGridView_LineList.DataSource = info;
            dataGridView_LineList.AllowUserToAddRows = false;//禁止添加行
            dataGridView_LineList.AllowUserToResizeRows = false;//禁止调整行高
            dataGridView_LineList.AllowUserToDeleteRows = false;//禁止删除行
            dataGridView_LineList.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_LineList.RowsDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_LineList.RowTemplate.Height = 30;
            dataGridView_LineList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //剔除第一列
            dataGridView_LineList.RowHeadersVisible = false;
            dataGridView_LineList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_LineList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView_LineList.Columns[0].Width = 120;

            for (int i = 0; i < dataGridView_LineList.Columns.Count; i++)
            {
                dataGridView_LineList.Columns[i].ReadOnly = true;
                dataGridView_LineList.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView_LineList.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_LineList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView_LineList.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView_LineList.DefaultCellStyle.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dataGridView_LineList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView_LineList.Rows.Add(mMachine.TaskList.Count);
            //dataGridView_LineList.Rows[0].Selected = false;

            for (int i = 0; i < mMachine.TaskList.Count; i++)
            {
                object[] obj = new object[11];
                obj[0] = "Cam" + (i + 1);
                obj[1] = "0";
                obj[2] = "0";
                obj[3] = "0";
                obj[4] = "0";
                obj[5] = "NA";
                obj[6] = "0";
                obj[7] = "0";
                obj[8] = "0";
                obj[9] = "0";
                obj[10] = "00.00ms";
                info.Rows.Add(obj);
            }
            if (dataGridView_LineList.Rows.Count > 0)
                dataGridView_LineList.Rows[0].Selected = false;
        }

        private void UiHeaderButton_CameraSet_Click(object sender, EventArgs e)
        {
            FrmSelectProject se = new FrmSelectProject();
            if (se.ShowDialog() == DialogResult.OK)
            {
                FrmCamListView frm = new FrmCamListView();
                frm.CurrProject = se.CurrProject;
                frm.ShowDialog();
            }

            uiHeaderButton_CameraSet.Selected = false;
        }

        private void UiHeaderButton_Project_Click(object sender, EventArgs e)
        {
            FrmProjectManager fem = new FrmProjectManager();
            fem.ShowDialog();
            uiHeaderButton_Project.Selected = false;
        }

        private void UiHeaderButton_UserManage_Click(object sender, EventArgs e)
        {
            FrmUsers frm = new FrmUsers();
            frm.ShowDialog();
            uiHeaderButton_UserManage.Selected = false;
        }

        private void UiHeaderButton_Data_Click(object sender, EventArgs e)
        {

        }

        private void UiHeaderButton_CommunicateSet_Click(object sender, EventArgs e)
        {
            FrmCommunicate frm = new FrmCommunicate();
            frm.ShowDialog();
            uiHeaderButton_CommunicateSet.Selected = false;
        }

        private void UiHeaderButton_ProjectSet_Click(object sender, EventArgs e)
        {
            FrmSelectProject se = new FrmSelectProject();
            if (se.ShowDialog() == DialogResult.OK)
            {
                Machine.GetInstance().FrmProject = new FrmProjectSet();
                Machine.GetInstance().FrmProject.CurrProject = se.CurrProject;
                Machine.GetInstance().FrmProject.ShowDialog();
            }
            uiHeaderButton_ProjectSet.Selected = false;
        }

        private void ReceiveMessage(string str)
        {
            mMachine.SoceketReceive?.Invoke(str);
        }

        private void InitTask()
        {
            mMachine.TaskList = new List<DetectTaskBase>();
        }

        private void InitTaskWindow()
        {
            for (int i = 0; i < mMachine.TaskList.Count; i++)
            {
                mMachine.TaskList[i].SaveProcess.SetShowWind(mMachine.HWindowControlList[i]);
                mMachine.TaskList[i].Camera = mMachine.CamList[i];
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //关闭相机
            foreach (var item in mMachine.CamList)
            {
                if (item != null) 
                {
                    item.StopGrab();
                    item.CloseCamera();
                }
            }
            //释放线程资源
            foreach (var item in mMachine.TaskList)
                item.Dispose();
            timer_Refresh.Stop();
            mIsStart = false;
            mThreadRun = false;
            //mThreadGetFinalResult.Join();
        }

        private void UiHeaderButton_SystemSet_Click(object sender, EventArgs e)
        {
            FrmSystemSetting frm = new FrmSystemSetting();
            frm.ShowDialog();
            uiHeaderButton_SystemSet.Selected = false;
        }


        private void UiHeaderButton_Run_Click(object sender, EventArgs e)
        {
            UIFormServiceHelper.ShowProcessForm(this);
            string path = Application.StartupPath + "\\Project\\" + mMachine.SettingInfo.SelectProject.mProjectName + "\\CamPar.cam";
            if (!mMachine.GetRemainMemeory("E"))
            {
                MessageBox.Show("硬盘剩余容量过低!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UIFormServiceHelper.HideProcessForm(this);
                uiHeaderButton_Run.Selected = false;
                return;
            }
            //设置相机
            //设置曝光参数
            CamParam infoCam;
            if (Machine.GetInstance().DeSoapSerializeFuc(path, out infoCam))
            {
                mMachine.CameraParam = infoCam;
                for (int i = 0; i < mMachine.CamList.Count; i++)
                {
                    if (mMachine.CamList[i] != null)
                    {
                        CamParamInfo info;
                        Machine.GetInstance().CameraParam.GetParamValue(i, out info);
                        mMachine.CamList[i].SetCameraExposure(info.CameraExposure);
                        mMachine.CamList[i].SetCameraGain((float)info.CameraGain);
                        mMachine.CamList[i].SetTriggerDelay(info.TriggerDelay);
                    }
                }
            }

            //清除所有数据/清除相机图像队列
            ClearTaskCount();

            //设置所有相机工作方式
            for (int i = 0; i < mMachine.CamList.Count; i++)
            {
                mMachine.CamList[i].SetCameraMode(TriggerMode.Mode_SoftTrigger);
                mMachine.CamList[i].SetTriggerSource(TriggerSource.Line0);
            }
            mMachine.CamList[1].SetCameraMode(TriggerMode.Mode_SoftTrigger);
            mMachine.CamList[1].SetTriggerSource(TriggerSource.Software);

            //Task文件夹赋值
            string mFoldNameMain = System.DateTime.Now.ToString("yyyy-MM-dd");
            string mFoldName = System.DateTime.Now.ToString("HH-mm-sss");
            //启动所有线程
            foreach (var item in mMachine.TaskList)
            {
                item.SaveFolderName = mFoldNameMain + "\\" + mFoldName;
                item.Camera.StartGrab();
                item.CheckStart();
            }
            //使能控件
            EnableControl(false);
            uiHeaderButton_Run.Enabled = false;
            uiHeaderButton_Stop.Enabled = true;
            uiHeaderButton_Run.Selected = false;
            UIFormServiceHelper.HideProcessForm(this);
        }

        private void EnableControl(bool misEnable)
        {
            panel_BtnList.Enabled = misEnable;
            //uiTitlePanel1.Enabled = misEnable;
            //uiTitlePanel2.Enabled = misEnable;
            uiTitlePanel3.Enabled = misEnable;
            uiTitlePanel1.Enabled = misEnable;
            this.ControlBox = misEnable;
        }

        private void UiHeaderButton_Stop_Click(object sender, EventArgs e)
        {
            UIFormServiceHelper.ShowProcessForm(this);
            foreach (var item in mMachine.TaskList)
            {
                item.CheckStop();
            }
            //使能控件
            EnableControl(true);
            uiHeaderButton_Run.Enabled = true;
            uiHeaderButton_Stop.Enabled = false;
            uiHeaderButton_Stop.Selected = false;
            UIFormServiceHelper.HideProcessForm(this);
        }

        private void ClearTaskCount()
        {
            for (int i = 0; i < mMachine.TaskList.Count; i++)
            {
                mMachine.TaskList[i].Count = 0;
                mMachine.TaskList[i].CostTime = 0;
                mMachine.TaskList[i].OkCount = 0;
                mMachine.TaskList[i].NgCount = 0;
                mMachine.TaskList[i].TaskResultQueue = new System.Collections.Concurrent.ConcurrentQueue<string>();
                if (mMachine.TaskList[i].Camera != null)
                {
                    mMachine.TaskList[i].Camera.ImageBuff = new System.Collections.Concurrent.ConcurrentQueue<HObject>();
                    mMachine.TaskList[i].Camera.ImageCount = 0;
                }

            }
        }

        private void GetFinalResult()
        {
            while (mThreadRun)
            {
                if (mMachine.TaskList.Count != 6)
                {
                    Thread.Sleep(50);
                    continue;
                }
                if (!mIsStart)
                {
                    Thread.Sleep(50);
                    continue;
                }

                if (mMachine.TaskList[1].TaskResultQueue.Count() > 0 &&
                    mMachine.TaskList[2].TaskResultQueue.Count() > 0 &&
                    mMachine.TaskList[3].TaskResultQueue.Count() > 0 &&
                    mMachine.TaskList[4].TaskResultQueue.Count() > 0)
                {
                    List<int> mCountList = new List<int>();
                    List<int> mResultList = new List<int>();

                    mMachine.TaskList[1].TaskResultQueue.TryDequeue(out string res1);
                    mMachine.TaskList[2].TaskResultQueue.TryDequeue(out string res2);
                    mMachine.TaskList[3].TaskResultQueue.TryDequeue(out string res3);
                    mMachine.TaskList[4].TaskResultQueue.TryDequeue(out string res4);

                    mCountList.Add(int.Parse(res1.Split('_')[0]));
                    mCountList.Add(int.Parse(res2.Split('_')[0]));
                    mCountList.Add(int.Parse(res3.Split('_')[0]));
                    mCountList.Add(int.Parse(res4.Split('_')[0]));

                    mResultList.Add(int.Parse(res1.Split('_')[2]));
                    mResultList.Add(int.Parse(res2.Split('_')[2]));
                    mResultList.Add(int.Parse(res3.Split('_')[2]));
                    mResultList.Add(int.Parse(res4.Split('_')[2]));

                    int res = 1;
                    //OK
                    if (mResultList.All(i => i == 0))
                    {
                        res = 0;
                        break;
                    }
                    else if (mResultList.Contains(-1))
                    {
                        res = -1;
                        break;
                    }
                    //-199 反料或无料
                    else if (mResultList.Contains(-199))
                    {
                        res = -199;
                        break;
                    }
                    else
                    {
                        res = 1;
                    }

                    if (res == 0)
                    {
                        mMachine.OkNumber++;
                        mMachine.AllNumber++;
                    }
                    else
                    {
                        mMachine.NGNumber++;
                        mMachine.AllNumber++;
                    }
                }
            }
        }

        private void Timer_Refresh_Tick(object sender, EventArgs e)
        {
            float pos = Machine.GetInstance().Zmotion.GetFbkPosition(0);

            label_Project.Text = "Project：" + mMachine.SettingInfo.SelectProject.mProjectName;
            label_All.Text = "总数：" + mMachine.AllNumber;
            if (mMachine.AllNumber > 0)
                label_Percent.Text = "良品率：" + (mMachine.OkNumber / mMachine.AllNumber).ToString("P");
            else
                label_Percent.Text = "良品率：" + (0).ToString("P");
            label5_OK.Text = "良品数：" + mMachine.OkNumber;
            label_NG.Text = "不良数：" + mMachine.NGNumber;


            this.BeginInvoke(new Action(() =>
            {
                for (int i = 0; i < mMachine.TaskList.Count; i++)
                {
                    if (mMachine.TaskList[i].Camera != null)
                    {
                        dataGridView_LineList.Rows[i].Cells[0].Value = "Cam" + (i + 1);
                        dataGridView_LineList.Rows[i].Cells[1].Value = mMachine.TaskList[i].Camera.ImageCount;
                        dataGridView_LineList.Rows[i].Cells[2].Value = mMachine.TaskList[i].Count;
                        dataGridView_LineList.Rows[i].Cells[3].Value = mMachine.TaskList[i].OkCount;
                        dataGridView_LineList.Rows[i].Cells[4].Value = mMachine.TaskList[i].NgCount;
                        if (mMachine.TaskList[i].Count > 0)
                            dataGridView_LineList.Rows[i].Cells[5].Value = (mMachine.TaskList[i].OkCount / mMachine.TaskList[i].Count).ToString("f2");
                        else
                            dataGridView_LineList.Rows[i].Cells[5].Value = "NA";
                        dataGridView_LineList.Rows[i].Cells[6].Value = "0";
                        dataGridView_LineList.Rows[i].Cells[7].Value = "0";
                        dataGridView_LineList.Rows[i].Cells[8].Value = "0";
                        dataGridView_LineList.Rows[i].Cells[9].Value = "0";
                        dataGridView_LineList.Rows[i].Cells[10].Value = mMachine.TaskList[i].CostTime.ToString("f2") + "ms";
                    }
                }

            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadingHelper.ShowLoadingScreen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadingHelper.CloseForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "") 
            {
                LoadingHelper.ShowLoadingMessage(textBox1.Text);
            }
        }


        private CameraBase GetCameraClass(CameraType cameraType)
        {
            CameraBase camera = null;
            switch (cameraType)
            {
                case CameraType.CameraType_HiKang:
                    camera = new HaikCamera();
                    break;
                case CameraType.CameraType_Daheng:
                    camera = new DahengCamera();
                    break;
                default:
                    break;
            }
            return camera;
        }
    }
}
