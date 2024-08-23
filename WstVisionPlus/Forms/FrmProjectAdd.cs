using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace WstVisionPlus
{
    public partial class FrmProjectAdd : UIForm
    {
        public FrmProjectAdd()
        {
            InitializeComponent();
        }

        ProjectInfo info;
        Machine mMachine;

        public ProjectInfo Info
        {
            get => info;
            set => info = value;
        }

        private void FrmProjectAdd_Load(object sender, EventArgs e)
        {
            mMachine = Machine.GetInstance();
            timer1.Start();
            uiTextBox_ProjectName.Text = "项目" + System.DateTime.Now.ToString("ffff");
            uiIntegerUpDown_CamNums.Value = mMachine.SettingInfo.GlobalEnableCamNums;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            uiTextBox_CreateTime.Text = System.DateTime.Now.ToString();
        }

        private void UiSymbolButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void UiSymbolButton_OK_Click(object sender, EventArgs e)
        {
            if (mMachine.SettingInfo.ProjectInfoList.Any(i => i.mProjectName == uiTextBox_ProjectName.Text)) 
            {
                MessageBox.Show("项目名重复，请重命名!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            info = new ProjectInfo();
            info.mActiveCamNum = uiIntegerUpDown_CamNums.Value;
            info.mProjectName = uiTextBox_ProjectName.Text;
            info.mProjectCreateTime = uiTextBox_CreateTime.Text;
            info.mProjectDescribe = uiRichTextBox_ProjectDescribe.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
