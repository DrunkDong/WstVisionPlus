using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace WstVisionPlus
{
    public partial class FrmProjectManager : UIForm
    {
        public FrmProjectManager()
        {
            InitializeComponent();
        }

        Machine mMachine;
        DataTable info;
        private void InitDataGridView()
        {
            info = new DataTable();
            info.Columns.Add("序号", typeof(int));
            info.Columns.Add("工程名称", typeof(string));
            info.Columns.Add("工程描述", typeof(string));
            info.Columns.Add("创建时间", typeof(string));
            info.Columns.Add("任务数量", typeof(string));

            dataGridView_ProjectList.DataSource = info;
            dataGridView_ProjectList.AllowUserToAddRows = false;//禁止添加行
            dataGridView_ProjectList.AllowUserToResizeRows = false;//禁止调整行高
            dataGridView_ProjectList.AllowUserToDeleteRows = false;//禁止删除行
            dataGridView_ProjectList.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_ProjectList.RowsDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_ProjectList.RowTemplate.Height = 30;
            dataGridView_ProjectList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //剔除第一列
            dataGridView_ProjectList.RowHeadersVisible = false;
            dataGridView_ProjectList.SelectionMode = DataGridViewSelectionMode.CellSelect;

            dataGridView_ProjectList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView_ProjectList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //设置首行不可修改
            dataGridView_ProjectList.Columns[0].Width = 50;
            dataGridView_ProjectList.Columns[1].Width = 150;
            dataGridView_ProjectList.Columns[2].Width = 200;
            dataGridView_ProjectList.Columns[3].Width = 150;
            dataGridView_ProjectList.Columns[4].Width = 120;

            dataGridView_ProjectList.Columns[0].ReadOnly = true;
            dataGridView_ProjectList.Columns[1].ReadOnly = true;
            dataGridView_ProjectList.Columns[2].ReadOnly = true;
            dataGridView_ProjectList.Columns[3].ReadOnly = true;
            dataGridView_ProjectList.Columns[4].ReadOnly = true;
            //设置所有列不可排序
            dataGridView_ProjectList.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_ProjectList.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_ProjectList.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_ProjectList.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_ProjectList.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView_ProjectList.MultiSelect = false;

        }

        private void FrmProjectManager_Load(object sender, EventArgs e)
        {
            mMachine = Machine.GetInstance();
            InitDataGridView();
            UpdataView();
            RefreshView();
        }


        private void UiButton_CreateNew_Click(object sender, EventArgs e)
        {
            FrmProjectAdd frm = new FrmProjectAdd();
            if (frm.ShowDialog() == DialogResult.OK) 
            {
                object[] obj = new object[5];
                obj[0] = info.Rows.Count + 1;
                obj[1] = frm.Info.mProjectName;
                obj[2] = frm.Info.mProjectDescribe;
                obj[3] = frm.Info.mProjectCreateTime;
                obj[4] = frm.Info.mActiveCamNum;
                info.Rows.Add(obj);
                mMachine.SettingInfo.ProjectInfoList.Add(frm.Info);
                mMachine.SerializeFuc(mMachine.SettingInfoSavePath, mMachine.SettingInfo);
                RefreshView();
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Project\\" + frm.Info.mProjectName);
                    dir.Create();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void UpdataView()
        {
            info.Rows.Clear();
            for (int i = 0; i < mMachine.SettingInfo.ProjectInfoList.Count; i++)
            {
                object[] obj = new object[5];
                obj[0] = info.Rows.Count + 1;
                obj[1] = mMachine.SettingInfo.ProjectInfoList[i].mProjectName;
                obj[2] = mMachine.SettingInfo.ProjectInfoList[i].mProjectDescribe;
                obj[3] = mMachine.SettingInfo.ProjectInfoList[i].mProjectCreateTime;
                obj[4] = mMachine.SettingInfo.ProjectInfoList[i].mActiveCamNum;
                info.Rows.Add(obj);
            }
        }

        private void UiButton_Dele_Click(object sender, EventArgs e)
        {
            if (dataGridView_ProjectList.Rows.Count > 0) 
            {
                if (MessageBox.Show("是否确定删除此条数据?", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    int selectedRowIndex = dataGridView_ProjectList.SelectedCells[0].RowIndex;
                    string name = mMachine.SettingInfo.ProjectInfoList[selectedRowIndex].mProjectName;
                    info.Rows.RemoveAt(selectedRowIndex);
                    mMachine.SettingInfo.ProjectInfoList.RemoveAt(selectedRowIndex);
                    UpdataView();
                    mMachine.SerializeFuc(mMachine.SettingInfoSavePath, mMachine.SettingInfo);
                    RefreshView();
                    try
                    {
                        DirectoryInfo dir = new DirectoryInfo(Application.StartupPath + "\\Project\\" + name);
                        dir.Delete(true);

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void UiButton_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_ProjectList.Rows.Count > 0)
            {
                int selectedRowIndex = dataGridView_ProjectList.SelectedCells[0].RowIndex;
                FrmProjectEdit frm = new FrmProjectEdit();
                frm.Info = mMachine.SettingInfo.ProjectInfoList[selectedRowIndex];
                frm.RowIndex = selectedRowIndex;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    ProjectInfo infoo = frm.Info;
                    info.Rows[selectedRowIndex].ItemArray[1] = infoo.mProjectName;
                    info.Rows[selectedRowIndex].ItemArray[2] = infoo.mProjectDescribe;
                    info.Rows[selectedRowIndex].ItemArray[3] = infoo.mProjectCreateTime;
                    info.Rows[selectedRowIndex].ItemArray[4] = infoo.mActiveCamNum;

                    dataGridView_ProjectList.CurrentRow.Cells[1].Value= infoo.mProjectName;
                    dataGridView_ProjectList.CurrentRow.Cells[2].Value = infoo.mProjectDescribe;
                    dataGridView_ProjectList.CurrentRow.Cells[3].Value = infoo.mProjectCreateTime;
                    dataGridView_ProjectList.CurrentRow.Cells[4].Value = infoo.mActiveCamNum;
                    mMachine.SettingInfo.ProjectInfoList[selectedRowIndex] = infoo;
                }
                mMachine.SerializeFuc(mMachine.SettingInfoSavePath, mMachine.SettingInfo);
            }

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UiButton_Dele_Click(null, new EventArgs());
            RefreshView();
        }

        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UiButton_Edit_Click(null, new EventArgs());
            RefreshView();
        }

        private void UiButton_Change_Click(object sender, EventArgs e)
        {
            if (dataGridView_ProjectList.Rows.Count > 0)
            {
                int selectedRowIndex = dataGridView_ProjectList.SelectedCells[0].RowIndex;
                if (selectedRowIndex >= 0) 
                {
                    //获取选择的
                    mMachine.SettingInfo.SelectProject = mMachine.SettingInfo.ProjectInfoList[selectedRowIndex];
                    mMachine.CurrProjectInfo = mMachine.SettingInfo.ProjectInfoList[selectedRowIndex];
                    RefreshView();
                }
            }
        }

        private void RefreshView()
        {
            for (int i = 0; i < mMachine.SettingInfo.ProjectInfoList.Count; i++)
            {
                if (mMachine.SettingInfo.SelectProject != null) 
                {
                    if (mMachine.SettingInfo.ProjectInfoList[i].mProjectName == mMachine.SettingInfo.SelectProject.mProjectName)
                        dataGridView_ProjectList.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    else
                        dataGridView_ProjectList.Rows[i].DefaultCellStyle.BackColor = Color.White;

                    mMachine.SerializeFuc(mMachine.SettingInfoSavePath, mMachine.SettingInfo);
                }
            }
        }

        private void 切换ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UiButton_Change_Click(new object(), new EventArgs());
        }

        private void 克隆ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_ProjectList.Rows.Count > 0)
            {
                if (dataGridView_ProjectList.SelectedCells != null)
                {
                    int selectedRowIndex = dataGridView_ProjectList.SelectedCells[0].RowIndex;
                    if (selectedRowIndex > -1) 
                    {
                        ProjectInfo infoClone = new ProjectInfo();

                        infoClone.mProjectName = mMachine.SettingInfo.ProjectInfoList[selectedRowIndex].mProjectName+"_Clone";
                        infoClone.mProjectCreateTime = DateTime.Now.ToString();
                        infoClone.mProjectDescribe = mMachine.SettingInfo.ProjectInfoList[selectedRowIndex].mProjectDescribe;
                        infoClone.mActiveCamNum = mMachine.SettingInfo.ProjectInfoList[selectedRowIndex].mActiveCamNum;

                        object[] obj = new object[5];
                        obj[0] = info.Rows.Count + 1;
                        obj[1] = infoClone.mProjectName;
                        obj[2] = infoClone.mProjectDescribe;
                        obj[3] = infoClone.mProjectCreateTime;
                        obj[4] = infoClone.mActiveCamNum;
                        info.Rows.Add(obj);
                        mMachine.SettingInfo.ProjectInfoList.Add(infoClone);
                        RefreshView();
                        try
                        {
                            CopyDirectory(Application.StartupPath + "\\Project\\" + mMachine.SettingInfo.ProjectInfoList[selectedRowIndex].mProjectName,
                                Application.StartupPath + "\\Project\\" + infoClone.mProjectName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                   
                }

            }
        }

        public void CopyDirectory(string sourceDir, string targetDir)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            DirectoryInfo[] dirs = dir.GetDirectories();

            // If the source directory does not exist, throw an exception.
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException($"Source directory does not exist or could not be found: {sourceDir}");
            }

            // If the destination directory does not exist, create it.
            if (!Directory.Exists(targetDir))
            {
                Directory.CreateDirectory(targetDir);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(targetDir, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to the new location.
            foreach (DirectoryInfo subdir in dirs)
            {
                string tempPath = Path.Combine(targetDir, subdir.Name);
                CopyDirectory(subdir.FullName, tempPath);
            }
        }
    }
}
