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
using WstCommonTools;

namespace WstVisionPlus
{
    public partial class FrmLogin : UIForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        Machine mMachine;
        List<UserInfo> infoList;
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            mMachine = Machine.GetInstance();
            infoList = new List<UserInfo>();
            this.ActiveControl = uiTextBox_PassWord;
            DataTable table = mMachine.UserAccessOp.ReadAllData();
            if (table.Rows.Count > 0)
                uiTextBox_Name.Text = table.Rows[0].ItemArray[0].ToString();          
        }

        private void UiSymbolButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void UiSymbolButton_OK_Click(object sender, EventArgs e)
        {
            string strSql = "select UserPassWord  from UerInfoTable where UserName = '" + uiTextBox_Name.Text + "'";
            string password = mMachine.UserAccessOp.GetOneData(strSql);
            if (password == "")
                ShowErrorTip("User does not exist!");
            else if (password != uiTextBox_PassWord.Text)
                ShowErrorTip("Password Error!");
            else if (password == uiTextBox_PassWord.Text)
            {
                ShowSuccessTip("Success!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void UiTextBox_PassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 触发btn的事件
                this.UiSymbolButton_OK_Click(sender, e);
            }
        }
    }
}
