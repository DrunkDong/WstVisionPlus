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
    public partial class FrmSystemSetting : UIForm
    {
        public FrmSystemSetting()
        {
            InitializeComponent();
        }
        Machine mMachine;
        private void FrmSystemSetting_Load(object sender, EventArgs e)
        {
            mMachine = Machine.GetInstance();;
            this.ActiveControl = uiButton_Save;
        }
        private void UiButton_Save_Click(object sender, EventArgs e)
        {
            mMachine.SerializeFuc(mMachine.SettingInfoSavePath, mMachine.SettingInfo);
            mMachine.SavePath = mMachine.SettingInfo.SaveImagePath;
        }
    }
}
