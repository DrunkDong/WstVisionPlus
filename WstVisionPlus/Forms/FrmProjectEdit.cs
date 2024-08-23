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
    public partial class FrmProjectEdit : UIForm
    {
        public FrmProjectEdit()
        {
            InitializeComponent();
        }

        ProjectInfo info;
        int mRowIndex;

        Machine mMachine;
        public int RowIndex
        { get; set; }
        public ProjectInfo Info
        {
            get => info;
            set => info = value;
        }

        private void FrmProjectEdit_Load(object sender, EventArgs e)
        {
            mMachine = Machine.GetInstance();
            uiIntegerUpDown_CamNums.Value = info.mActiveCamNum;
            uiTextBox_ProjectName.Text = info.mProjectName;
            uiTextBox_CreateTime.Text = info.mProjectCreateTime;
            uiRichTextBox_ProjectDescribe.Text = info.mProjectDescribe;
        }

        private void UiSymbolButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void UiSymbolButton_OK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mMachine.SettingInfo.ProjectInfoList.Count; i++)
            {
                if (i != RowIndex) 
                {
                    if (mMachine.SettingInfo.ProjectInfoList[i].mProjectName == uiTextBox_ProjectName.Text)
                    {
                        MessageBox.Show("项目名重复，请重命名!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } 
                }
            }
            ProjectInfo info2 = new ProjectInfo();
            info2.mActiveCamNum = uiIntegerUpDown_CamNums.Value;
            info2.mProjectName = uiTextBox_ProjectName.Text;
            info2.mProjectCreateTime = uiTextBox_CreateTime.Text;
            info2.mProjectDescribe = uiRichTextBox_ProjectDescribe.Text;

            //是否更改了项目名
            if (info2.mProjectName != info.mProjectName) 
            {
                string oldFolderPath = Application.StartupPath + "\\Project\\" + info.mProjectName;
                string newFolderName = Application.StartupPath + "\\Project\\" + info2.mProjectName;
                DirectoryInfo directory = new DirectoryInfo(oldFolderPath);
                string newFolderPath = Path.Combine(directory.Parent.FullName, newFolderName);
                directory.MoveTo(newFolderPath);
            }

            Info = info2; 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
