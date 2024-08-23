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
using WstCommonTools;
using Sunny.UI;
using Sunny.UI.Win32;

namespace WstVisionPlus
{
    public partial class FrmCamListView : UIForm
    {
        public FrmCamListView()
        {
            InitializeComponent();
            btnList.Add(uiButton_Debug1);
            btnList.Add(uiButton_Debug2);
            btnList.Add(uiButton_Debug3);
            btnList.Add(uiButton_Debug4);
            btnList.Add(uiButton_Debug5);
            btnList.Add(uiButton_Debug6);
            btnList.Add(uiButton_Debug7);
            btnList.Add(uiButton_Debug8);
            btnList.Add(uiButton_Debug9);
            btnList.Add(uiButton_Debug10);
            btnList.Add(uiButton_Debug11);
            btnList.Add(uiButton_Debug12);

            textBoxList.Add(textBox_Cam1SN);
            textBoxList.Add(textBox_Cam2SN);
            textBoxList.Add(textBox_Cam3SN);
            textBoxList.Add(textBox_Cam4SN);
            textBoxList.Add(textBox_Cam5SN);
            textBoxList.Add(textBox_Cam6SN);
            textBoxList.Add(textBox_Cam7SN);
            textBoxList.Add(textBox_Cam8SN);
            textBoxList.Add(textBox_Cam9SN);
            textBoxList.Add(textBox_Cam10SN);
            textBoxList.Add(textBox_Cam11SN);
            textBoxList.Add(textBox_Cam12SN);

            labelList.Add(label_Cam1);
            labelList.Add(label_Cam2);
            labelList.Add(label_Cam3);
            labelList.Add(label_Cam4);
            labelList.Add(label_Cam5);
            labelList.Add(label_Cam6);
            labelList.Add(label_Cam7);
            labelList.Add(label_Cam8);
            labelList.Add(label_Cam9);
            labelList.Add(label_Cam10);
            labelList.Add(label_Cam11);
            labelList.Add(label_Cam12);
        }

        List<UIButton> btnList = new List<UIButton>();
        List<TextBox> textBoxList = new List<TextBox>();
        List<Label> labelList = new List<Label>();
        Machine mMachine;
        DataTable info;
        List<CameraInfo> lit;

        ProjectInfo mCurrProject;
        public ProjectInfo CurrProject
        {
            get => mCurrProject;
            set => mCurrProject = value;
        }

        private void FrmCamListView_Load(object sender, EventArgs e)
        {
            mMachine = Machine.GetInstance();
            for (int i = 0; i < btnList.Count; i++)
            {
                if (i < mMachine.SettingInfo.GlobalEnableCamNums)
                {
                    btnList[i].Click += BtnClick;
                }
                else
                {
                    labelList[i].Visible = false;
                    btnList[i].Visible = false;
                    textBoxList[i].Visible = false;
                }
            }
            InitDataGridView();
            HaikCamera.QueryCamera(out lit);
            info.Rows.Clear();
            for (int i = 0; i < lit.Count; i++)
            {
                object[] obj = new object[5];
                obj[0] = i + 1;
                obj[1] = lit[i].CamType;
                obj[2] = lit[i].CamName;
                obj[3] = lit[i].CamSerialNumber;
                obj[4] = GetManufacturer(lit[i].CamManufacturerType);
                info.Rows.Add(obj);
            }
            InitParam();
            string path = Application.StartupPath + "\\Project\\" + CurrProject.mProjectName + "\\CamPar.cam";
            CamParam infoCam;
            Machine.GetInstance().DeSoapSerializeFuc(path, out infoCam);
            mMachine.CameraParam = infoCam;
            this.Refresh();
        }

        private void BtnClick(object sender, EventArgs e)
        {
            UIButton button = (UIButton)sender;
            for (int i = 0; i < btnList.Count; i++)
            {
                if (btnList[i] == button)
                {
                    //传递相机句柄
                    string camSn = textBoxList[i].Text.Trim();
                    if (camSn == "")
                    {
                        MessageBox.Show("Serial Number Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (mMachine.CamList.Any(k => k != null && k.SerialNum == camSn))
                    {
                        foreach (var item in mMachine.CamList)
                        {
                            if (item.SerialNum == camSn)
                            {
                                FrmCameraSet cam = new FrmCameraSet();
                                cam.CurrProject = CurrProject;
                                cam.Camera = item;
                                cam.CameraIndex = i;
                                cam.ShowDialog();
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (JudgeCameaSn(camSn))
                        {
                            if (MessageBox.Show("This camera is not initialized.Perform this initialization Now?", "Tips", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                HaikCamera haik = new HaikCamera();
                                haik.OpenCamera(camSn);
                                FrmCameraSet cam = new FrmCameraSet();
                                cam.CurrProject = CurrProject;
                                cam.Camera = haik;
                                cam.CameraIndex = i;
                                if (cam.ShowDialog() == DialogResult.OK)
                                {
                                    Task.Run(new Action(() =>
                                    {
                                        cam.Camera.StopGrab();
                                        cam.Camera.CloseCamera();
                                    }));
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Camera is Null!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void InitDataGridView()
        {
            info = new DataTable();
            info.Columns.Add("No", typeof(int));
            info.Columns.Add("Camera Type", typeof(string));
            info.Columns.Add("Camera Name", typeof(string));
            info.Columns.Add("Serial number", typeof(string));
            info.Columns.Add("Manufacturer", typeof(string));

            dataGridView_CamList.DataSource = info;
            dataGridView_CamList.AllowUserToAddRows = false;//禁止添加行
            dataGridView_CamList.AllowUserToResizeRows = false;//禁止调整行高
            dataGridView_CamList.AllowUserToDeleteRows = false;//禁止删除行
            dataGridView_CamList.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_CamList.RowsDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_CamList.RowTemplate.Height = 30;
            dataGridView_CamList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //剔除第一列
            dataGridView_CamList.RowHeadersVisible = false;
            //设置首行不可修改
            dataGridView_CamList.Columns[0].Width = 40;
            dataGridView_CamList.Columns[1].Width = 120;
            dataGridView_CamList.Columns[0].ReadOnly = true;
            dataGridView_CamList.Columns[1].ReadOnly = true;
            dataGridView_CamList.Columns[2].ReadOnly = true;
            dataGridView_CamList.Columns[3].ReadOnly = true;
            //设置所有列不可排序
            dataGridView_CamList.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_CamList.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_CamList.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_CamList.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView_CamList.Columns[3].ContextMenuStrip = contextMenuStrip_Copy;
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = dataGridView_CamList.CurrentCell.Value.ToString();
            Clipboard.SetDataObject(str);
        }

        private void UiButton_Save_Click(object sender, EventArgs e)
        {
            string path = mMachine.SettingInfoSavePath;
            GetParam();
            if (!mMachine.SerializeFuc(path, mMachine.SettingInfo))
                MessageBox.Show("Save Error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("success!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GetParam()
        {
            int val = (int)numericUpDown_GlobalEnableCams.Value;
            mMachine.SettingInfo.GlobalEnableCamNums = val;
            mMachine.SettingInfo.CameraInfoList.Clear();
            for (int i = 0; i < val; i++)
            {
                string sn = textBoxList[i].Text.Trim();
                mMachine.SettingInfo.CameraInfoList.Add(lit.Where(m => m.CamSerialNumber == sn).FirstOrDefault());
            }

        }

        private void InitParam()
        {
            for (int i = 0; i < mMachine.SettingInfo.CameraInfoList.Count; i++)
            {
                textBoxList[i].Text = mMachine.SettingInfo.CameraInfoList[i].CamSerialNumber;
            }
            numericUpDown_GlobalEnableCams.Value = mMachine.SettingInfo.GlobalEnableCamNums;
        }

        private bool JudgeCameaSn(string sn)
        {
            foreach (DataRow item in info.Rows)
            {
                if (item[3].ToString() == sn)
                {
                    return true;
                }
            }
            return false;
        }

        private void numericUpDown_GlobalEnableCams_ValueChanged(object sender, EventArgs e)
        {
            int val = (int)numericUpDown_GlobalEnableCams.Value;
            mMachine.SettingInfo.GlobalEnableCamNums = val;
            for (int i = 0; i < btnList.Count; i++)
            {
                if (i < val)
                {
                    labelList[i].Visible = true;
                    btnList[i].Visible = true;
                    textBoxList[i].Visible = true;
                }
                else
                {
                    labelList[i].Visible = false;
                    btnList[i].Visible = false;
                    textBoxList[i].Visible = false;
                }
            }
        }

        private string GetManufacturer(CameraType ty) 
        {
            if (ty == CameraType.CameraType_HiKang)
                return "Hikrobot";
            else if (ty == CameraType.CameraType_Daheng)
                return "Daheng Imaging";
            else
                return "";
        }
    }
}
