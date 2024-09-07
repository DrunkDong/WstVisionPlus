using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WstCommonTools;
using WstControls;
using HalconDotNet;
using Sunny.UI;
using System.IO;
using System.Threading;
using System.Collections;
using System.ComponentModel.Design;

namespace WstVisionPlus
{
    public partial class FrmProjectSet : UIForm
    {
        public FrmProjectSet()
        {
            InitializeComponent();
            mWindow = new HDebugWindow();
            mWindow.Dock = DockStyle.Fill;
            mWindow.Parent = panel_Camera;

            mMessageView = new UMessageListView();
            mMessageView.Dock = DockStyle.Fill;
            mMessageView.Parent = panel_ToolInfo;

            mTreeTool = new UTreeTools();
            mTreeTool.Dock = DockStyle.Fill;
            mTreeTool.Parent = panel_ToolTree;

            mToolTreeView = new UToolTreeView();
            mToolTreeView.Dock = DockStyle.Fill;
            mToolTreeView.Parent = panel_Tool;


            uiSymbolButton_Num1.Click += SwitchBtn;
            uiSymbolButton_Num2.Click += SwitchBtn;
            uiSymbolButton_Num3.Click += SwitchBtn;
            uiSymbolButton_Num4.Click += SwitchBtn;
            uiSymbolButton_Num5.Click += SwitchBtn;
            uiSymbolButton_Num6.Click += SwitchBtn;
            uiSymbolButton_Num7.Click += SwitchBtn;
            uiSymbolButton_Num8.Click += SwitchBtn;
            uiSymbolButton_Num9.Click += SwitchBtn;

            btnList = new List<UISymbolButton>
            {
                uiSymbolButton_Num1, uiSymbolButton_Num2, uiSymbolButton_Num3,
                uiSymbolButton_Num4,uiSymbolButton_Num5,uiSymbolButton_Num6,
                uiSymbolButton_Num7,uiSymbolButton_Num8,uiSymbolButton_Num9,
            };

            mMachine = Machine.GetInstance();
            mLock = new object();
            autoEv = new ManualResetEvent(false);
            autoBreak = false;
            toolStripComboBox_StopMode.Width = 150;
            toolStripComboBox_StopMode.SelectedIndex = 0;
        }

        object mLock;
        int mCurrIndex;
        int mCamIndex;
        int mPicIndex;

        Machine mMachine;
        UTreeTools mTreeTool;
        UToolTreeView mToolTreeView;
        HDebugWindow mWindow;
        UMessageListView mMessageView;
        HObject mCurrImage;
        ProjectInfo mCurrProject;
        List<UISymbolButton> btnList;
        HaikCamera mCamera;
        List<string> mImagePathList;
        ToolBase mSelectedTool;


        ManualResetEvent autoEv;
        bool autoBreak;

        Thread mLoopImage;


        public ProjectInfo CurrProject
        {
            get => mCurrProject;
            set => mCurrProject = value;
        }
        //public List<ToolBase> ToolList
        //{
        //    get => uToolTreeView_Tools.ToolList;
        //}
        public HObject CurrImage
        {
            get => mCurrImage;
            set => mCurrImage = value;
        }
        public HaikCamera Camera
        {
            get => mCamera;
            set => mCamera = value;
        }
        public UToolTreeView ToolTreeView
        {
            get => mToolTreeView;
            set => mToolTreeView = value;
        }

        private void ToolStrip_MainButton_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, toolStrip_MainButton.Width, toolStrip_MainButton.Height - 2);
            e.Graphics.SetClip(rect);
        }

        private void ToolStripButton_OpenFile_Click(object sender, EventArgs e)
        {
            string nPath = "";
            OpenFileDialog openfiledialog1 = new OpenFileDialog();
            openfiledialog1.Filter = "所有图像文件|*.bmp;*.pcx;*.png;*.jpg;*.gif;*.jpeg";
            openfiledialog1.Title = "打开图像文件";
            if (openfiledialog1.ShowDialog() == DialogResult.OK)
            {
                nPath = openfiledialog1.FileName;
            }
            if (nPath != "")
            {
                mWindow.IsMove = false;
                HObject image;
                HOperatorSet.GenEmptyObj(out image);
                HOperatorSet.ReadImage(out image, nPath);
                CurrImage = image;
                mWindow.DispImage(mCurrImage);
                //运行一次
                ClickRunOnce();
            }
        }

        private void ToolStripButton_Save_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Project\\" + mMachine.CurrProjectInfo.mProjectName + "\\" + 0 + ".dat";
            if (ToolOP.SaveToolList(path, ToolTreeView.ToolList) == OperateStatus.OK)
                MessageBox.Show("save suceess", "successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("save failed", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmProjectSet_Load(object sender, EventArgs e)
        {
            mCamIndex = 0;
            mImagePathList = new List<string>();
            mToolTreeView.NodeSelected += ToolTreeView_NodeSelected;
            mToolTreeView.NodeDoubleClick += ToolTreeView_NodeDoubleClick;
            mToolTreeView.NodeDeleClick += ToolTreeView_NodeDeleClick;

            //读取当前配置
            string path = AppDomain.CurrentDomain.BaseDirectory + "Project\\" + mMachine.CurrProjectInfo.mProjectName + "\\" + 0 + ".dat";
            ReadToolList(path);
        }

        private void ToolTreeView_NodeDeleClick(object sender, EventArgs e)
        {
            if (mToolTreeView.SelectNode != null)
                mSelectedTool = mToolTreeView.SelectNode.InnerTool;
            else
                mSelectedTool = null;
        }

        private void ToolTreeView_NodeDoubleClick(object sender, EventArgs e)
        {
            ToolTreeNode toolTreeNode = sender as ToolTreeNode;
            mSelectedTool = toolTreeNode.InnerTool;
            OpenToolWindow(toolTreeNode.InnerTool);
        }

        private void ToolTreeView_NodeSelected(object sender, EventArgs e)
        {
            ToolTreeNode clickTreeNode = (ToolTreeNode)(sender as TreeNode);
            mSelectedTool = clickTreeNode.InnerTool;
            //ClickRunOnce();
        }

        private void 重命名ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 上移ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 下移ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SwitchBtn(object sender, EventArgs e)
        {
            try
            {
                lock (mLock)
                {
                    UISymbolButton bu = sender as UISymbolButton;
                    //获取索引
                    int index = btnList.IndexOf(bu);
                    //if (mCamera != null)
                    //    //停止上一次相机采集
                    //    mCamera.StopGrab();
                    if (index != mCamIndex)
                    {
                        UIFormServiceHelper.ShowProcessForm(this);
                        foreach (var item in btnList)
                        {
                            //
                            if (item == bu)
                            {
                                item.FillColor = Color.OrangeRed;
                                item.FillColor2 = Color.OrangeRed;
                                item.RectColor = Color.OrangeRed;
                                item.FillHoverColor = Color.FromArgb(255, 109, 0);
                                item.FillPressColor = Color.FromArgb(255, 29, 0);
                                item.FillSelectedColor = Color.FromArgb(255, 29, 0);
                                item.RectHoverColor = Color.FromArgb(255, 109, 0);
                                item.RectSelectedColor = Color.FromArgb(255, 29, 0);
                                item.RectPressColor = Color.FromArgb(255, 29, 0);
                            }
                            else
                            {
                                item.FillColor = Color.FromArgb(110, 190, 40);
                                item.FillColor2 = Color.FromArgb(110, 190, 40);
                                item.RectColor = Color.FromArgb(110, 190, 40);
                                item.FillHoverColor = Color.FromArgb(139, 203, 83);
                                item.FillPressColor = Color.FromArgb(88, 152, 32);
                                item.FillSelectedColor = Color.FromArgb(88, 152, 32);
                                item.RectHoverColor = Color.FromArgb(139, 203, 83);
                                item.RectSelectedColor = Color.FromArgb(88, 152, 32);
                                item.RectPressColor = Color.FromArgb(88, 152, 32);
                            }
                        }
                        string path = AppDomain.CurrentDomain.BaseDirectory + "Project\\" + mMachine.CurrProjectInfo.mProjectName + "\\" + index + ".dat";
                        ReadToolList(path);

                        mCamIndex = index;
                        UIFormServiceHelper.HideProcessForm(this);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("窗体打开失败!\r\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmProjectSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            //工具强行停止
            foreach (var item in ToolTreeView.ToolList)
            {
                item.ToolForceStop();
            }
            //线程注销
            autoBreak = false;
            autoEv.Set();
        }

        private void toolStripButton_LoadFolder_Click(object sender, EventArgs e)
        {
            mImagePathList = new List<string>();
            string dir = "";
            if (DirEx.SelectDirEx("扩展打开文件夹", ref dir))
            {
                if (dir != "")
                {
                    mImagePathList = new List<string>();
                    mPicIndex = 0;
                    DirectoryInfo theFolder = new DirectoryInfo(dir);
                    FileInfo[] fileInfo = theFolder.GetFiles();
                    for (int i = 0; i < fileInfo.Length; i++)
                    {
                        var fi = new FileInfo(fileInfo[i].FullName);
                        if (fi.Extension == ".png" || fi.Extension == ".jpeg" || fi.Extension == ".jpg"
                            || fi.Extension == ".bmp" || fi.Extension == ".tiff")
                        {
                            mImagePathList.Add(fileInfo[i].FullName);
                        }
                    }
                    if (mImagePathList.Count > 0)
                    {
                        mWindow.IsMove = false;
                        HObject image;
                        HOperatorSet.ReadImage(out image, mImagePathList[0]);
                        CurrImage = image;
                        mWindow.DispImage(image);
                        //运行一次
                        ClickRunOnce();
                    }
                }
            }
        }

        private void toolStripButton_Up_Click(object sender, EventArgs e)
        {
            if (mImagePathList.Count == 0)
                return;
            if (mPicIndex < 0)
                return;
            if (mPicIndex > 0)
                mPicIndex--;
            else
                mPicIndex = 0;
            mWindow.IsMove = false;
            HObject image;
            HOperatorSet.ReadImage(out image, mImagePathList[mPicIndex]);
            mMessageView.OutputMsg($"read image success! image index[{mPicIndex + 1}] {mImagePathList[mPicIndex]}");
            CurrImage = image;
            mWindow.DispImage(image);
            //运行一次
            ClickRunOnce();
        }

        private void toolStripButton_Down_Click(object sender, EventArgs e)
        {
            if (mImagePathList.Count == 0)
                return;
            if (mPicIndex < 0)
                return;
            if (mPicIndex < mImagePathList.Count - 1)
                mPicIndex++;
            else
                mPicIndex = mImagePathList.Count - 1;

            mWindow.IsMove = false;
            HObject image;
            HOperatorSet.ReadImage(out image, mImagePathList[mPicIndex]);
            mMessageView.OutputMsg($"read image success! image index[{mPicIndex + 1}] {mImagePathList[mPicIndex]}");
            CurrImage = image;
            mWindow.DispImage(image);
            //运行一次
            ClickRunOnce();
        }

        private void LoopImageFromFiles()
        {
            while (autoBreak)
            {
                int mode = -1;
                toolStrip_MainButton.Invoke(new Action(() =>
                {
                    mode = toolStripComboBox_StopMode.SelectedIndex;
                }));

                for (int i = 0; i < mImagePathList.Count; i++)
                {
                    autoEv.WaitOne();
                    if (!autoBreak)
                        return;
                    HObject image;
                    HOperatorSet.ReadImage(out image, mImagePathList[i]);
                    mMessageView.OutputMsg($"success! image index[{i}] {mImagePathList[i]}");
                    CurrImage = image;
                    mWindow.DispImage(image);
                    int res = DebugRunForFile(image);
                    //遇到NG停止
                    if (res != 0 && mode == 0)
                    {
                        toolStrip_MainButton.Invoke(new Action(() =>
                        {
                            toolStripButton_OpenFile.Enabled = false;
                            toolStripButton_LoadFolder.Enabled = false;
                            toolStripComboBox_StopMode.Enabled = true;
                            toolStripButton_LoopRun.Enabled = true;
                            toolStripButton_RunOnce.Enabled = false;
                            toolStripButton_Up.Enabled = false;
                            toolStripButton_Down.Enabled = false;
                            toolStripButton_Save.Enabled = false;
                            toolStripButton_Stop.Enabled = true;
                            toolStripButton_TriggerIOnce.Enabled = false;
                            toolStripButton_Contiue.Enabled = false;
                            ControlBox = false;

                        }));
                        autoEv.Reset();
                    }
                    //遇到OK停止
                    else if (res == 0 && mode == 1)
                    {
                        toolStrip_MainButton.Invoke(new Action(() =>
                        {
                            toolStripButton_OpenFile.Enabled = false;
                            toolStripButton_LoadFolder.Enabled = false;
                            toolStripComboBox_StopMode.Enabled = true;
                            toolStripButton_LoopRun.Enabled = true;
                            toolStripButton_RunOnce.Enabled = false;
                            toolStripButton_Up.Enabled = false;
                            toolStripButton_Down.Enabled = false;
                            toolStripButton_Save.Enabled = false;
                            toolStripButton_Stop.Enabled = true;
                            toolStripButton_TriggerIOnce.Enabled = false;
                            toolStripButton_Contiue.Enabled = false;
                            ControlBox = false;
                        }));
                        autoEv.Reset();
                    }
                }

                //重置所有状态
                autoBreak = false;
                autoEv.Set();

                toolStrip_MainButton.Invoke(new Action(() =>
                {
                    toolStripButton_OpenFile.Enabled = true;
                    toolStripButton_LoadFolder.Enabled = true;
                    toolStripComboBox_StopMode.Enabled = true;
                    toolStripButton_LoopRun.Enabled = true;
                    toolStripButton_RunOnce.Enabled = true;
                    toolStripButton_Up.Enabled = true;
                    toolStripButton_Down.Enabled = true;
                    toolStripButton_Save.Enabled = true;
                    toolStripButton_Stop.Enabled = false; ;
                    toolStripButton_Contiue.Enabled = true;
                    toolStripButton_TriggerIOnce.Enabled = true;

                    panel_ToolTree.Enabled = true;
                    panel_Camera.Enabled = true;
                    uiTitlePanel_Tool.Enabled = true;
                    ControlBox = true;
                }));
            }
        }

        private int DebugRunForFile(HObject mCurrImage)
        {
            if (!HObjectHelper.ObjectValided(mCurrImage))
                return 1;
            mWindow.DispImage(mCurrImage);
            //传入图片源
            foreach (var item in ToolTreeView.ToolList)
            {
                if (item.Type == ToolType.Camera)
                {
                    CameraAcqTool acqTool = (CameraAcqTool)item;
                    acqTool.FolderImageQueue.Enqueue(mCurrImage.CopyObj(1, 1));
                    mWindow.DispImage(mCurrImage);
                    break;
                }
            }
            mWindow.ClearWindow();
            if (ToolTreeView.ToolList.Count > 0)
            {
                if (mSelectedTool != null)
                {
                    //正在运行标志打开
                    ToolTreeView.IsToolRunning = true;
                    //tool列表显示窗口
                    SetToolRunWind(ToolTreeView.ToolList);
                    OperateStatus res;
                    foreach (var item in ToolTreeView.ToolList)
                    {
                        ToolTreeNode iRunNode = null;
                        foreach (TreeNode item1 in ToolTreeView.Nodes)
                        {
                            if (((ToolTreeNode)item1).InnerTool == item)
                            {
                                iRunNode = (ToolTreeNode)item1;
                                break;
                            }
                        }
                        if (iRunNode != null)
                        {
                            mToolTreeView.Invoke(new Action(() =>
                            {
                                mToolTreeView.CurrRunStepNode = iRunNode;
                                mToolTreeView.Refresh();
                            }));
                        }
                        if (item != mSelectedTool && item.Type != ToolType.Camera)
                            res = item.ToolRun(ToolTreeView.ToolList, false);
                        else
                            res = item.ToolRun(ToolTreeView.ToolList, true);
                        if (res == OperateStatus.Break)
                        {
                            ToolTreeView.IsToolRunning = false;
                            return 0;
                        }
                        //刷新显示
                        RefleshToolInfo(item);
                    }
                    //正在运行标志取消
                    ToolTreeView.IsToolRunning = false;
                }
                if (IsHandleCreated)
                    mToolTreeView.Invoke(new Action(() => { mToolTreeView.Invalidate(); }));
            }
            return 0;
        }

        private void LoopImageFromCameras()
        {
            while (autoBreak)
            {
                autoEv.WaitOne();
                if (!autoBreak)
                    return;
                int mode = -1;
                toolStrip_MainButton.Invoke(new Action(() =>
                {
                    mode = toolStripComboBox_StopMode.SelectedIndex;
                }));
                int res = DebugRunForCamera();
                //遇到NG停止
                if (res != 0 && mode == 0)
                {
                    toolStrip_MainButton.Invoke(new Action(() =>
                    {
                        toolStripButton_OpenFile.Enabled = false;
                        toolStripButton_LoadFolder.Enabled = false;
                        toolStripComboBox_StopMode.Enabled = true;
                        toolStripButton_LoopRun.Enabled = true;
                        toolStripButton_RunOnce.Enabled = false;
                        toolStripButton_Up.Enabled = false;
                        toolStripButton_Down.Enabled = false;
                        toolStripButton_Save.Enabled = false;
                        toolStripButton_Stop.Enabled = true;
                        toolStripButton_TriggerIOnce.Enabled = false;
                        toolStripButton_Contiue.Enabled = false;
                        ControlBox = false;

                    }));
                    autoEv.Reset();
                }
                //遇到OK停止
                else if (res == 0 && mode == 1)
                {
                    toolStrip_MainButton.Invoke(new Action(() =>
                    {
                        toolStripButton_OpenFile.Enabled = false;
                        toolStripButton_LoadFolder.Enabled = false;
                        toolStripComboBox_StopMode.Enabled = true;
                        toolStripButton_LoopRun.Enabled = true;
                        toolStripButton_RunOnce.Enabled = false;
                        toolStripButton_Up.Enabled = false;
                        toolStripButton_Down.Enabled = false;
                        toolStripButton_Save.Enabled = false;
                        toolStripButton_Stop.Enabled = true;
                        toolStripButton_TriggerIOnce.Enabled = false;
                        toolStripButton_Contiue.Enabled = false;
                        ControlBox = false;
                    }));
                    autoEv.Reset();
                }
                HOperatorSet.CountSeconds(out HTuple S2);
                //mPicIndex = 0;
                //autoEv.Reset();
                //toolStrip_MainButton.Invoke(new Action(() =>
                //{
                //    toolStripButton_OpenFile.Enabled = true;
                //    toolStripButton_LoadFolder.Enabled = true;
                //    toolStripComboBox_StopMode.Enabled = true;
                //    toolStripButton_LoopRun.Enabled = true;
                //    toolStripButton_RunOnce.Enabled = true;
                //    toolStripButton_Up.Enabled = true;
                //    toolStripButton_Down.Enabled = true;
                //    toolStripButton_Save.Enabled = true;
                //    toolStripButton_Stop.Enabled = false;
                //}));
                Thread.Sleep(1);
            }
        }

        private void toolStripButton_Stop_Click(object sender, EventArgs e)
        {
            mPicIndex = 0;

            //工具强行停止
            foreach (var item in ToolTreeView.ToolList)
            {
                item.ToolForceStop();
            }
            autoBreak = false;
            autoEv.Set();
            //mLoopImage.Join();

            toolStripButton_OpenFile.Enabled = true;
            toolStripButton_LoadFolder.Enabled = true;
            toolStripComboBox_StopMode.Enabled = true;
            toolStripButton_LoopRun.Enabled = true;
            toolStripButton_RunOnce.Enabled = true;
            toolStripButton_Up.Enabled = true;
            toolStripButton_Down.Enabled = true;
            toolStripButton_Save.Enabled = true;
            toolStripButton_Stop.Enabled = false; ;
            toolStripButton_Contiue.Enabled = true;
            toolStripButton_TriggerIOnce.Enabled = true;

            panel_ToolTree.Enabled = true;
            panel_Camera.Enabled = true;
            uiTitlePanel_Tool.Enabled = true;
            ControlBox = true;
        }

        private void OpenToolWindow(ToolBase tool)
        {
            ToolType type = tool.Type;
            switch (type)
            {
                case ToolType.TransImage:
                    Frm_ImageConvert tool1 = new Frm_ImageConvert();
                    tool1.Tool = (ImageConvertTool)tool;
                    tool1.Tool.DebugWind = mWindow;
                    tool1.Text = tool.ShowName;
                    tool1.ToolList = mToolTreeView.ToolList;
                    tool1.ShowDialog();
                    break;
                case ToolType.BlobImage:
                    Frm_ImageBlob tool2 = new Frm_ImageBlob();
                    tool2.Tool = (ImageBlobTool)tool;
                    tool2.Tool.DebugWind = mWindow;
                    tool2.Text = tool.ShowName;
                    tool2.ToolList = mToolTreeView.ToolList;
                    tool2.ShowDialog();
                    break;
                case ToolType.ShapeModel:
                    Frm_ShapeModel tool3 = new Frm_ShapeModel();
                    tool3.Tool = (ShapeModelTool)tool;
                    tool3.Tool.DebugWind = mWindow;
                    tool3.Text = tool.ShowName;
                    tool3.ToolList = mToolTreeView.ToolList;
                    tool3.ShowDialog();
                    break;
                case ToolType.FindLine:
                    Frm_FindLine tool4 = new Frm_FindLine();
                    tool4.Tool = (ImageFindLineTool)tool;
                    tool4.Tool.DebugWind = mWindow;
                    tool4.Text = tool.ShowName;
                    tool4.ToolList = mToolTreeView.ToolList;
                    tool4.ShowDialog();
                    break;
                case ToolType.FindCircle:
                    Frm_FindCircle tool5 = new Frm_FindCircle();
                    tool5.Tool = (ImageFindCircleTool)tool;
                    tool5.Tool.DebugWind = mWindow;
                    tool5.Text = tool.ShowName;
                    tool5.ToolList = mToolTreeView.ToolList;
                    tool5.ShowDialog();
                    break;
                case ToolType.Camera:
                    Frm_CameraAcq tool6 = new Frm_CameraAcq();
                    tool6.CameraInfos = mMachine.SettingInfo.CameraInfoList;
                    tool6.CamList = mMachine.CamList;
                    tool6.Tool = (CameraAcqTool)tool;
                    tool6.Tool.DebugWind = mWindow;
                    tool6.Text = tool.ShowName;
                    tool6.ToolList = mToolTreeView.ToolList;
                    tool6.ShowDialog();
                    break;
                default:
                    break;
            }
        }

        private void SetToolRunWind(List<ToolBase> toolBases)
        {
            foreach (var item in toolBases)
            {
                item.DebugWind = mWindow;
                if (item.ChildToolList.Count > 0)
                    SetToolRunWind(item.ChildToolList);
            }
        }

        private void RefleshToolInfo(ToolBase tool)
        {
            if (mToolTreeView.ToolInfoList.Count > 0)
            {
                ToolInfo toolInfo = mToolTreeView.ToolInfoList.Where(x => x.ToolCurr == tool).FirstOrDefault();
                if (toolInfo != null)
                {
                    toolInfo.CostTime = tool.CostTime;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in mMachine.CamList)
            {
                item.SetCameraMode(TriggerMode.Mode_Trigger);
                item.SetTriggerSource(TriggerSource.Software);
                item.StartGrab();
            }
            foreach (var item in mMachine.CamList)
            {
                item.SoftTrigger();
            }
        }

        private void ClickRunOnce()
        {
            if (ToolTreeView.ToolList.Count > 0)
            {
                mWindow.ClearWindow();
                //判断当前图片
                if (!HObjectHelper.ObjectValided(mCurrImage))
                    return;
                //传入图片源
                foreach (var item in ToolTreeView.ToolList)
                {
                    if (item.Type == ToolType.Camera)
                    {
                        CameraAcqTool acqTool = (CameraAcqTool)item;
                        acqTool.FolderImageQueue.Enqueue(mCurrImage.CopyObj(1, 1));
                        mWindow.DispImage(mCurrImage);
                        break;
                    }
                }
                //运行工具
                if (mSelectedTool != null)
                {
                    //tool列表显示窗口
                    SetToolRunWind(ToolTreeView.ToolList);
                    OperateStatus res;
                    foreach (var item in ToolTreeView.ToolList)
                    {
                        if (item.Type != ToolType.Camera)
                        {
                            if (item != mSelectedTool)
                                res = item.ToolRun(ToolTreeView.ToolList, false);
                            else
                                res = item.ToolRun(ToolTreeView.ToolList, true);
                            //刷新显示
                            RefleshToolInfo(item);
                        }
                    }
                }
                if (IsHandleCreated)
                    mToolTreeView.Invoke(new Action(() => { mToolTreeView.Invalidate(); }));
            }
        }

        private void toolStripButton_Contiue_Click(object sender, EventArgs e)
        {
            //if (mImagePathList.Count == 0)
            //{
            //    MessageBox.Show("Image folder is empty！");
            //    return;
            //}

            autoBreak = true;
            mLoopImage = new Thread(new ThreadStart(LoopImageFromCameras));
            mLoopImage.IsBackground = true;
            mLoopImage.Start();

            autoEv.Set();
            toolStripButton_OpenFile.Enabled = false;
            toolStripButton_LoadFolder.Enabled = false;
            toolStripComboBox_StopMode.Enabled = false;
            toolStripButton_LoopRun.Enabled = false;
            toolStripButton_RunOnce.Enabled = false;
            toolStripButton_Up.Enabled = false;
            toolStripButton_Down.Enabled = false;
            toolStripButton_Save.Enabled = false;
            toolStripButton_Stop.Enabled = true;
            toolStripButton_TriggerIOnce.Enabled = false;
            toolStripButton_Contiue.Enabled = false;

            panel_ToolTree.Enabled = false;
            panel_Camera.Enabled = false;
            uiTitlePanel_Tool.Enabled = false;
            ControlBox = false;
        }

        private int DebugRunForCamera()
        {
            if (ToolTreeView.ToolList.Count > 0)
            {
                if (mSelectedTool != null)
                {
                    //tool列表显示窗口
                    SetToolRunWind(ToolTreeView.ToolList);
                    bool jumpFlag = false;
                    bool isContinue = false;
                    ToolBase jumpTool = null;
                    OperateStatus res;
                    ToolTreeView.IsToolRunning = true;
                    foreach (var item in ToolTreeView.ToolList)
                    {
                        //若跳转标志位打开且跳转工具不为空
                        if (jumpFlag)
                        {
                            if (jumpTool == null || jumpTool.ToolID != item.ToolID)
                            {
                                MessageBox.Show("跳转标志位存在，但无分支条件");
                                break;
                            }
                            else
                            {
                                jumpTool = null;
                                jumpFlag = false;
                            }
                        }
                        if (isContinue)
                        {
                            isContinue = false;
                            continue;
                        }
                        ToolTreeNode iRunNode = null;
                        foreach (TreeNode item1 in ToolTreeView.Nodes)
                        {
                            if (((ToolTreeNode)item1).InnerTool == item)
                            {
                                iRunNode = (ToolTreeNode)item1;
                                break;
                            }
                        }
                        if (iRunNode != null)
                        {
                            mToolTreeView.Invoke(new Action(() =>
                            {
                                mToolTreeView.CurrRunStepNode = iRunNode;
                                mToolTreeView.Refresh();
                            }));
                        }
                        res = RunTools(iRunNode, item, out jumpTool);
                        if (res == OperateStatus.RunElse)
                        {
                            //跳转标志位打开
                            jumpFlag = true;
                        }
                        else if (res == OperateStatus.Error || res == OperateStatus.Break)
                        {
                            //跳出循环
                            break;
                        }
                        else if (res == OperateStatus.EndIf)
                        {
                            isContinue = true;
                        }
                    }
                    ToolTreeView.IsToolRunning = false;
                    ToolTreeView.Invalidate();
                }
                if (IsHandleCreated)
                    mToolTreeView.Invoke(new Action(() => { mToolTreeView.Invalidate(); }));
            }
            return 0;
        }

        private async void toolStripButton_TriggerIOnce_Click(object sender, EventArgs e)
        {
            //使能控件
            toolStripButton_OpenFile.Enabled = false;
            toolStripButton_LoadFolder.Enabled = false;
            toolStripComboBox_StopMode.Enabled = false;
            toolStripButton_LoopRun.Enabled = false;
            toolStripButton_RunOnce.Enabled = false;
            toolStripButton_Up.Enabled = false;
            toolStripButton_Down.Enabled = false;
            toolStripButton_Save.Enabled = false;
            toolStripButton_Stop.Enabled = true;
            toolStripButton_TriggerIOnce.Enabled = false;
            toolStripButton_Contiue.Enabled = false;

            panel_ToolTree.Enabled = false;
            panel_Camera.Enabled = false;
            uiTitlePanel_Tool.Enabled = false;
            ControlBox = false;

            if (ToolTreeView.ToolList.Count > 0)
            {
                await Task.Run(new Action(() =>
                {
                    //清除显示窗口
                    mWindow.ClearWindow();
                    if (mSelectedTool != null)
                    {
                        //tool列表显示窗口
                        SetToolRunWind(ToolTreeView.ToolList);
                        bool jumpFlag = false;
                        bool isContinue = false;
                        ToolBase jumpTool = null;
                        OperateStatus res;
                        ToolTreeView.IsToolRunning = true;
                        foreach (var item in ToolTreeView.ToolList)
                        {
                            //若跳转标志位打开且跳转工具不为空
                            if (jumpFlag)
                            {
                                if (jumpTool == null || jumpTool.ToolID != item.ToolID)
                                {
                                    MessageBox.Show("跳转标志位存在，但无分支条件");
                                    break;
                                }
                                else
                                {
                                    jumpTool = null;
                                    jumpFlag = false;
                                }
                            }
                            if (isContinue) 
                            {
                                isContinue = false;
                                continue;
                            }
                            ToolTreeNode iRunNode = null;
                            foreach (TreeNode item1 in ToolTreeView.Nodes)
                            {
                                if (((ToolTreeNode)item1).InnerTool == item)
                                {
                                    iRunNode = (ToolTreeNode)item1;
                                    break;
                                }
                            }
                            if (iRunNode != null)
                            {
                                mToolTreeView.Invoke(new Action(() =>
                                {
                                    mToolTreeView.CurrRunStepNode = iRunNode;
                                    mToolTreeView.Refresh();
                                }));
                            }
                            res = RunTools(iRunNode, item, out jumpTool);
                            if (res == OperateStatus.RunElse)
                            {
                                //跳转标志位打开
                                jumpFlag = true;
                            }
                            else if (res == OperateStatus.Error || res == OperateStatus.Break)
                            {
                                //跳出循环
                                break;
                            }
                            else if (res == OperateStatus.EndIf)
                            {
                                isContinue = true;
                            }
                        }
                        ToolTreeView.IsToolRunning = false;
                        ToolTreeView.Invalidate();
                    }
                }));
            }

            toolStripButton_OpenFile.Enabled = true;
            toolStripButton_LoadFolder.Enabled = true;
            toolStripComboBox_StopMode.Enabled = true;
            toolStripButton_LoopRun.Enabled = true;
            toolStripButton_RunOnce.Enabled = true;
            toolStripButton_Up.Enabled = true;
            toolStripButton_Down.Enabled = true;
            toolStripButton_Save.Enabled = true;
            toolStripButton_Stop.Enabled = false;
            toolStripButton_TriggerIOnce.Enabled = true;
            toolStripButton_Contiue.Enabled = true;
            toolStripButton_Contiue.Enabled = true;

            panel_ToolTree.Enabled = true;
            panel_Camera.Enabled = true;
            uiTitlePanel_Tool.Enabled = true;
            ControlBox = true;
        }

        private void toolStripButton_LoopRun_Click(object sender, EventArgs e)
        {
            autoBreak = true;
            mLoopImage = new Thread(new ThreadStart(LoopImageFromFiles));
            mLoopImage.IsBackground = true;
            mLoopImage.Start();

            autoEv.Set();
            toolStripButton_OpenFile.Enabled = false;
            toolStripButton_LoadFolder.Enabled = false;
            toolStripComboBox_StopMode.Enabled = false;
            toolStripButton_LoopRun.Enabled = false;
            toolStripButton_RunOnce.Enabled = false;
            toolStripButton_Up.Enabled = false;
            toolStripButton_Down.Enabled = false;
            toolStripButton_Save.Enabled = false;
            toolStripButton_Stop.Enabled = true;
            toolStripButton_TriggerIOnce.Enabled = false;
            toolStripButton_Contiue.Enabled = false;

            panel_ToolTree.Enabled = false;
            panel_Camera.Enabled = false;
            uiTitlePanel_Tool.Enabled = false;
            ControlBox = false;
        }

        private void toolStripButton_RunOnce_Click(object sender, EventArgs e)
        {
            ClickRunOnce();
        }

        //读取工具列表
        private void ReadToolList(string path)
        {
            List<ToolBase> toolsList = new List<ToolBase>();
            mToolTreeView.Nodes.Clear();
            mToolTreeView.ToolList.Clear();
            mToolTreeView.ToolInfoList.Clear();
            if (!File.Exists(path))
                return;
            ToolOP.ReadToolList(path, out toolsList);
            if (toolsList.Count > 0)
            {
                //加载tools
                ToolTreeView.LoadTools(toolsList);

                //初始化各类tools
                foreach (var item in toolsList)
                {
                    InitTools(item);
                }
                mSelectedTool = mToolTreeView.ToolList[0];
                mToolTreeView.SelectNode = ((ToolTreeNode)mToolTreeView.Nodes[0]);
                mToolTreeView.Invalidate();
            }
        }

        private void InitTools(ToolBase iBase)
        {
            //先初始化工具
            iBase.InitTool();
            if (iBase.Type == ToolType.Camera)
            {
                CameraAcqTool itool = (CameraAcqTool)iBase;
                if (itool.CurrCamera != null && itool.CurrCamera.SerialNum != null)
                {
                    CameraBase camera = Machine.GetInstance().CamList.Where(i => i != null && i.SerialNum == itool.CurrCamera.SerialNum).FirstOrDefault();
                    itool.CurrCamera = camera;
                }
            }
            if (iBase.ChildToolList.Count > 0)
            {
                foreach (var item in iBase.ChildToolList)
                    InitTools(item);
            }
        }

        private OperateStatus RunTools(ToolTreeNode iRunNode, ToolBase item, out ToolBase jumpTool)
        {
            jumpTool = null;
            OperateStatus res = 0;
            //若当前工具非选定，且不是相机工具，则不显示运行结果至窗口
            if (item != mSelectedTool && item.Type != ToolType.Camera)
                res = item.ToolRun(ToolTreeView.ToolList, false);
            else //显示运行结果至窗口
                res = item.ToolRun(ToolTreeView.ToolList, true);

            //若当前工具是相机工具，则将工具的结果提取
            if (res == OperateStatus.OK && item.Type == ToolType.Camera)
            {
                CameraAcqTool tool = item as CameraAcqTool;
                mCurrImage = tool.CurrReceiveImage.CopyObj(1, 1);
            }
            //判断是否需要中途跳转
            else if (res == OperateStatus.Break)
            {
                return OperateStatus.Break;
            }
            //若当前工具为IF 
            //判断if工具的运行结果
            if (item.Type == ToolType.If || item.Type == ToolType.Else || item.Type == ToolType.For)
            {
                //若if判断为真
                if (res == OperateStatus.RunIf)
                {
                    ToolBase innnerTool = null;
                    bool jumpFlag = false;
                    bool continueFlag = false;
                    List<ToolBase> toolsInners = item.ChildToolList;
                    foreach (ToolBase tool in toolsInners)
                    {
                        if (jumpFlag)
                        {
                            if (innnerTool == null || innnerTool.ToolID != tool.ToolID)
                            {
                                MessageBox.Show("跳转标志位存在，但无分支条件");
                                break;
                            }
                            else
                            {
                                jumpTool = null;
                                jumpFlag = false;
                            }
                        }
                        if (continueFlag) 
                        {
                            continueFlag = false;
                            continue;
                        }
                        ToolTreeNode iRunNodeInner = null;
                        foreach (TreeNode item1 in iRunNode.Nodes)
                        {
                            if (((ToolTreeNode)item1).InnerTool == tool)
                            {
                                iRunNodeInner = (ToolTreeNode)item1;
                                break;
                            }
                        }
                        if (iRunNodeInner != null)
                        {
                            mToolTreeView.Invoke(new Action(() =>
                            {
                                mToolTreeView.CurrRunStepNode = iRunNodeInner;
                                mToolTreeView.Refresh();
                            }));
                        }
                        //直接返回函数
                        OperateStatus ress = RunTools(iRunNodeInner, tool, out innnerTool);
                        if (ress == OperateStatus.RunElse)
                        {
                            //跳转标志位打开
                            jumpFlag = true;
                        }
                        else if (ress == OperateStatus.Error)
                        {
                            //跳出循环
                            break;
                        }
                        else if (ress == OperateStatus.EndIf) 
                        {
                            continueFlag = true;
                        }
                    }
                    RefleshToolInfo(item);
                    return OperateStatus.EndIf;
                }
                //跳转至else
                else if (res == OperateStatus.RunElse)
                {
                    IfTool tool = item as IfTool;
                    if (tool != null)
                        jumpTool = tool.BingdingTool;
                    return OperateStatus.RunElse;
                }
                //若结果为执行Else分支
                else if (res == OperateStatus.ExcuteElse)
                {
                    ToolBase innnerTool = null;
                    bool jumpFlag = false;
                    List<ToolBase> toolsInners = item.ChildToolList;
                    foreach (ToolBase tool in toolsInners)
                    {
                        if (jumpFlag)
                        {
                            if (innnerTool == null || innnerTool.ToolID != tool.ToolID)
                            {
                                MessageBox.Show("跳转标志位存在，但无分支条件");
                                break;
                            }
                            else
                            {
                                jumpTool = null;
                                jumpFlag = false;
                            }
                        }
                        ToolTreeNode iRunNodeInner = null;
                        foreach (TreeNode item1 in iRunNode.Nodes)
                        {
                            if (((ToolTreeNode)item1).InnerTool == tool)
                            {
                                iRunNodeInner = (ToolTreeNode)item1;
                                break;
                            }
                        }
                        if (iRunNodeInner != null)
                        {
                            mToolTreeView.Invoke(new Action(() =>
                            {
                                mToolTreeView.CurrRunStepNode = iRunNodeInner;
                                mToolTreeView.Refresh();
                            }));
                        }
                        //直接返回函数
                        OperateStatus ress = RunTools(iRunNodeInner, tool, out innnerTool);
                        if (ress == OperateStatus.RunElse)
                        {
                            //跳转标志位打开
                            jumpFlag = true;
                        }
                        else if (ress == OperateStatus.Error)
                        {
                            //跳出循环
                            break;
                        }
                    }
                }
            }
            //刷新显示
            RefleshToolInfo(item);
            return OperateStatus.OK;
        }
    }
}
