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
using WstControls;
using HalconDotNet;
using WstCommonTools;

namespace WstControls
{
    public partial class Frm_ImageBlob : UIForm, FrmInterface
    {
        bool mIsInit;

        HDebugWindow window = new HDebugWindow();
        public HDebugWindow Window
        {
            get => window;
            set => window = value;
        }
        ImageBlobTool tool;
        public ImageBlobTool Tool
        {
            get => tool;
            set => tool = value;
        }
        public List<ToolInfo> StepInfolist { get; set; }
        public HObject CurrImage { get; set; }
        public List<ToolBase> ToolList { get; set; }

        public Frm_ImageBlob()
        {
            InitializeComponent();
            Window.Size = panel1.Size;
            Window.Location = new Point(0, 0);
            Window.Parent = panel1;
        }



        private void Frm_ImageBlob_Load(object sender, EventArgs e)
        {
            Tool.ToolWind = Window;
            uiColorPicker_CheckRegion.Value = tool.CheckRegionColor.color;
            mIsInit = true;
        }
        private void AttachDrawObj(HDrawingObject obj)
        {
            obj.OnSelect(OnSelectDrawingObject);
            obj.OnResize(OnResizeDrawingObject);
            Window.DebugWindow.HalconWindow.AttachDrawingObjectToWindow(obj);
        }
        private void OnSelectDrawingObject(HDrawingObject dobj, HWindow hwin, string type)
        {


        }
        private void OnResizeDrawingObject(HDrawingObject dobj, HWindow hwin, string type)
        {

        }

        private void UiTrackBar_Size_ValueChanged(object sender, EventArgs e)
        {
            label_Size.Text = "大小：" + uiTrackBar_Size.Value;
        }

        private void UiButton_Daub_Click(object sender, EventArgs e)
        {
            string str;
            if (uiRadioButton_CircleStruct.Checked)
                str = "circle";
            else
                str = "rectangle";
            HObject objl;
            uTabControl_Setting.Enabled = false;
            panel_Status.Enabled = false;
            this.ControlBox = false;
            tool.DrawRoi(0, str, uiTrackBar_Size.Value, out objl);
            uTabControl_Setting.Enabled = true;
            panel_Status.Enabled = true;
            this.ControlBox = true;
        }

        private void UiButton_Wipe_Click(object sender, EventArgs e)
        {
            string str;
            if (uiRadioButton_CircleStruct.Checked)
                str = "circle";
            else
                str = "rectangle";
            HObject objl;
            uTabControl_Setting.Enabled = false;
            panel_Status.Enabled = false;
            this.ControlBox = false;
            tool.DrawRoi(1, str, uiTrackBar_Size.Value, out objl);
            uTabControl_Setting.Enabled = true;
            panel_Status.Enabled = true;
            this.ControlBox = true;
        }

        private void UiColorPicker_CheckRegion_ValueChanged(object sender, Color value)
        {
            tool.CheckRegionColor = new ColorEx(value);
        }

        public void ShowToolRunMessage(string mes1 = "", bool isRed1 = false, string mes2 = "", bool isRed2 = false)
        {
            throw new NotImplementedException();
        }
    }
}
