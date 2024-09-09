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
using HalconDotNet;

namespace WstControls
{
    public partial class Frm_IfTool : UIForm, FrmInterface
    {
        HDrawingObject selected_drawing_object;
        List<HDrawingObject> objList = new List<HDrawingObject>();
        bool mIsInit;
        IfTool tool;
        public IfTool Tool
        {
            get => tool;
            set => tool = value;
        }
        public List<ToolBase> ToolList { get; set; }
        public HObject CurrImage { get; set; }
        public Frm_IfTool()
        {
            InitializeComponent();
        }

        private void Frm_ImageConvert_Load(object sender, EventArgs e)
        {
            this.Text = tool.ShowName;
            this.TitleFont = new Font("微软雅黑", 16F);
            this.TextAlignment = StringAlignment.Center;
            //赋值
            InitParam();
            mIsInit = true;
        }
        private void ParamChanged(object sender, EventArgs e)
        {
            if (!mIsInit) return;
            GetParam();
            try
            {
            }
            catch (Exception ex)
            {
                ShowToolRunMessage("", false, ex.Message, true);
            }
        }

        private void GetParam()
        {

        }
        private void InitParam()
        {
           
        }

        
        public void ShowToolRunMessage(string mes1 = "", bool isRed1 = false, string mes2 = "", bool isRed2 = false)
        {
            label_runTime.Invoke(new Action(() =>
            {
                if (!isRed1)
                    label_runTime.ForeColor = Color.Black;
                else
                    label_runTime.ForeColor = Color.Red;
                if (mes1 != "")
                    label_runTime.Text = "Cost：" + Tool.CostTime.ToString("f2") + "ms";
                else
                    label_runTime.Text = "Cost：0ms";
            }));
            label_State.Invoke(new Action(() =>
            {
                if (!isRed2)
                    label_State.ForeColor = Color.Black;
                else
                    label_State.ForeColor = Color.Red;
                if (mes2 != "")
                    label_State.Text = "State：" + mes2;
                else
                    label_State.Text = "State：";
            }));
        }
    }
}
