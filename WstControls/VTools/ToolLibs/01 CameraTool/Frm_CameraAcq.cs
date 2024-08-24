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
using WstCommonTools;

namespace WstControls
{
    public partial class Frm_CameraAcq : UIForm, FrmInterface
    {
        List<CameraInfo> mCameraInfos = new List<CameraInfo>();
        List<CameraBase> mCamList;
        HDrawingObject selected_drawing_object;
        List<HDrawingObject> objList = new List<HDrawingObject>();
        bool mIsInit;
        HDebugWindow window = new HDebugWindow();
        public HDebugWindow Window
        {
            get => window;
            set => window = value;
        }
        CameraAcqTool tool;
        public CameraAcqTool Tool
        {
            get => tool;
            set => tool = value;
        }
        public Frm_CameraAcq()
        {
            InitializeComponent();
            Window.Size = panel1.Size;
            Window.Location = new Point(0, 0);
            Window.Parent = panel1;
        }

        private void AttachDrawObj(HDrawingObject obj)
        {
            obj.OnSelect(OnSelectDrawingObject);
            obj.OnResize(OnResizeDrawingObject);
            Window.DebugWindow.HalconWindow.AttachDrawingObjectToWindow(obj);
        }
        private void OnSelectDrawingObject(HDrawingObject dobj, HWindow hwin, string type)
        {
            selected_drawing_object = dobj;

        }
        private void OnResizeDrawingObject(HDrawingObject dobj, HWindow hwin, string type)
        {

        }

        private void Frm_Camera_Load(object sender, EventArgs e)
        {
            mIsInit = false;
            this.Text = tool.ShowName;
            this.TitleFont = new Font("微软雅黑", 16F);
            this.TextAlignment = StringAlignment.Center;
            //赋值
            tool.ToolWind = Window;
            InitParam();
            AddInputItems();
            InitAllComboboxNode();
            mIsInit = true;
            ParamChanged(null, null);
        }
        private void ParamChanged(object sender, EventArgs e)
        {
            if (!mIsInit) return;
            GetParam();
            try
            {
                if (HObjectHelper.ObjectValided(Window.CurrImage))
                {
                    //tool.TransImage(Window.CurrImage);
                    ShowToolRunMessage(Tool.CostTime.ToString(), false, "", false);
                }
                else
                    ShowToolRunMessage("", false, "图片为空!", true);
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
            if (tool.CurrCamera != null)
                textBox_SN.Text = tool.CurrCamera.SerialNum;
        }

        private void InitAllComboboxNode()
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

        public List<ToolBase> ToolList { get; set; }

        public List<CameraInfo> CameraInfos
        {
            get => mCameraInfos;
            set => mCameraInfos = value;
        }
        public List<CameraBase> CamList
        {
            get => mCamList;
            set => mCamList = value;
        }

        public void AddInputItems()
        {
            
        }      

        private void uiButton_RunTool_Click(object sender, EventArgs e)
        {
            ParamChanged(null, null);
        }

        private void uiSymbolButton_Remove_Click(object sender, EventArgs e)
        {
            textBox_SN.Text = "";
            //相机句柄置空
            tool.CurrCamera = null;
        }

        private void uiSymbolButton_Select_Click(object sender, EventArgs e)
        {
            FrmCamList lit = new FrmCamList();
            lit.CamInfoList = CameraInfos;
            if (lit.ShowDialog() == DialogResult.OK) 
            {
                textBox_SN.Text = lit.SelectCamera;
                //相机句柄赋值
                tool.CurrCamera = CamList.Where(i => i.SerialNum == lit.SelectCamera).FirstOrDefault();
                tool.CurrCamera.OnCameraFrameReceived += tool.CameraReceiveHandler;
            }
        }
    }
}
