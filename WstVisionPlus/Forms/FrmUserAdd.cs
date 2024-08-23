using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WstCommonTools;
using Sunny.UI;

namespace WstVisionPlus
{
    public partial class FrmUserAdd : UIForm
    {
        public FrmUserAdd()
        {
            InitializeComponent();
        }
        UserInfo info = new UserInfo();
        Machine mMachine = Machine.GetInstance();

        private void UiSymbolButton_OK_Click(object sender, EventArgs e)
        {
            if (uiTextBox_UserName.Text == "")
            {
                ShowErrorTip("请输入用户名!");
                return;
            }
            if (uiTextBox_UserPassWords.Text == "") 
            {
                ShowErrorTip("请输入用户密码!");
                return;
            }
            if (!Islegal(uiTextBox_UserName.Text))
            {
                ShowErrorTip("用户名存在非法字符!");
                return;
            }
            if (!Islegal(uiTextBox_UserPassWords.Text))
            {
                ShowErrorTip("用户密码存在非法字符!");
                return;
            }
            string strSql = "select UserPassWord  from UerInfoTable where UserName = '" + uiTextBox_UserName.Text + "'";
            string password = mMachine.UserAccessOp.GetOneData(strSql);
            if (password != "")
            {
                ShowErrorTip("此用户名已存在，请重新输入!");
                return;
            }
            info.UserName = uiTextBox_UserName.Text;
            info.UserPassWord = uiTextBox_UserPassWords.Text;
            info.UserLevel = uiComboBox_UserLevel.Text;
            if (mMachine.UserAccessOp.InsertOneData(info))
            {
                ShowSuccessTip("新增成功!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            
        }

        public bool Islegal(string str)
        {
            Regex regExp = new Regex("[~!@#$%^&*()=+[\\]{}''\";:/?.,><`|！·￥…—（）\\-、；：。，》《]");
            return !regExp.IsMatch(str.Trim());
        }

        private void UiSymbolButton_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void KkeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // 触发btn的事件
                this.UiSymbolButton_OK_Click(sender, e);
            }
        }

        private void FrmUserAdd_Load(object sender, EventArgs e)
        {
            uiTextBox_UserName.KeyDown += KkeyDown;
            uiTextBox_UserPassWords.KeyDown += KkeyDown;
            uiComboBox_UserLevel.KeyDown += KkeyDown;
        }
    }
}
