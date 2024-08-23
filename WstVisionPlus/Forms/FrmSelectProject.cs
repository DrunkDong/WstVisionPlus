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
    public partial class FrmSelectProject : UIForm
    {
        public FrmSelectProject()
        {
            InitializeComponent();
        }

        ProjectInfo mCurrProject;
        public ProjectInfo CurrProject
        {
            get => mCurrProject;
            set => mCurrProject = value;
        }

        private void ComboBox_SelectProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            mCurrProject = Machine.GetInstance().ProjectInfoList[comboBox_SelectProject.SelectedIndex];
        }

        private void UiSymbolButton_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UiSymbolButton_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void FrmSelectProject_Load(object sender, EventArgs e)
        {
            this.ActiveControl = uiSymbolButton_OK;
            List<string> lst = new List<string>();
            foreach (var item in Machine.GetInstance().ProjectInfoList)
            {
                lst.Add(item.mProjectName);
            }
            comboBox_SelectProject.DataSource = lst;
        }
    }
}
