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
    public partial class Frm_ImageConvert : UIForm, FrmInterface
    {
        HDrawingObject selected_drawing_object;
        List<HDrawingObject> objList = new List<HDrawingObject>();
        bool mIsInit;
        HDebugWindow window = new HDebugWindow();
        public HDebugWindow Window
        {
            get => window;
            set => window = value;
        }
        ImageConvertTool tool;
        public ImageConvertTool Tool
        {
            get => tool;
            set => tool = value;
        }
        public Frm_ImageConvert()
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

        private void Frm_ImageConvert_Load(object sender, EventArgs e)
        {
            this.Text = tool.ShowName;
            this.TitleFont = new Font("微软雅黑", 16F);
            this.TextAlignment = StringAlignment.Center;
            uiComboBox_TransMode.SelectedIndex = 0;
            //赋值
            tool.ToolWind = Window;
            InitParam();
            AddInputItems();
            InitAllComboboxNode();
            uiComboBox_TransMode.SelectedIndexChanged += ParamChanged;
            uiRadioButton_None.CheckedChanged += ParamChanged;
            uiRadioButton_Gray.CheckedChanged += ParamChanged;
            uiRadioButton_R.CheckedChanged += ParamChanged;
            uiRadioButton_G.CheckedChanged += ParamChanged;
            uiRadioButton_B.CheckedChanged += ParamChanged;
            uiRadioButton_H.CheckedChanged += ParamChanged;
            uiRadioButton_S.CheckedChanged += ParamChanged;
            uiRadioButton_V.CheckedChanged += ParamChanged;
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
                    tool.TransImage(Window.CurrImage);
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
            tool.TransString = uiComboBox_TransMode.SelectedItem.ToString();
            if (uiRadioButton_Gray.Checked)
                tool.TransMode = 1;
            else if (uiRadioButton_R.Checked)
                tool.TransMode = 2;
            else if (uiRadioButton_G.Checked)
                tool.TransMode = 3;
            else if (uiRadioButton_B.Checked)
                tool.TransMode = 4;
            else if (uiRadioButton_H.Checked)
                tool.TransMode = 5;
            else if (uiRadioButton_S.Checked)
                tool.TransMode = 6;
            else if (uiRadioButton_V.Checked)
                tool.TransMode = 7;
            else
                tool.TransMode = 0;
        }
        private void InitParam()
        {
            uiComboBox_TransMode.SelectedItem = tool.TransString;
            if (tool.TransMode == 0)
                uiRadioButton_None.Checked = true;
            else if (tool.TransMode == 1)
                uiRadioButton_Gray.Checked = true;
            else if (tool.TransMode == 2)
                uiRadioButton_R.Checked = true;
            else if (tool.TransMode == 3)
                uiRadioButton_G.Checked = true;
            else if (tool.TransMode == 4)
                uiRadioButton_B.Checked = true;
            else if (tool.TransMode == 5)
                uiRadioButton_H.Checked = true;
            else if (tool.TransMode == 6)
                uiRadioButton_S.Checked = true;
            else if (tool.TransMode == 7)
                uiRadioButton_V.Checked = true;
        }

        private void InitAllComboboxNode()
        {
            if (tool.ImageSourceToolIDMark > 0)
            {
                string name = ToolList.Where(x => x.ToolID == tool.ImageSourceToolIDMark).FirstOrDefault().ShowName;
                uiComboTreeView_ImageSource.Text = tool.ImageSourceToolIDMark + "/" + name + "/" + tool.ImageSourceParam;
            }
            else
                uiComboTreeView_ImageSource.Text = "0/LocalResources/Picture";
            LoadToolImage();
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
        public HObject CurrImage { get; set; }

        public void AddInputItems()
        {
            TreeNode rootNode = new TreeNode("0/LocalResources");
            rootNode.Nodes.Add("Picture");
            uiComboTreeView_ImageSource.TreeView.Nodes.Add(rootNode);
            foreach (ToolBase item in ToolList)
            {
                if (item.Equals(this.tool))
                    break;
                List<string> lit = ToolParamHelper.GetParamsNames(item, ToolResultType.Image, ParamType.image);
                if (lit.Count > 0)
                {
                    TreeNode root = new TreeNode(item.ToolID + "/" + item.ShowName);
                    for (int i = 0; i < lit.Count; i++)
                    {
                        root.Nodes.Add(lit[i]);
                    }
                    uiComboTreeView_ImageSource.TreeView.Nodes.Add(root);
                }
            }
        }

        private void uiComboTreeView1_NodeSelected(object sender, TreeNode node)
        {
            if (!mIsInit)
                return;
            uiComboTreeView_ImageSource.Text = node.Parent.Text + "/" + node.Text;
            tool.ImageSourceToolIDMark = int.Parse(node.Parent.Text.Split('/')[0]);
            tool.ImageSourceParam = node.Text;
            LoadToolImage();
        }

        private void LoadToolImage()
        {
            if (tool.ImageSourceToolIDMark > 0)
            {
                ToolBase ibase = ToolList.Where(x => x.ToolID == tool.ImageSourceToolIDMark).FirstOrDefault();
                HObject inImage = ToolParamHelper.GetParamValueByName<HObject>(ibase, tool.ImageSourceParam);
                if (HObjectHelper.ObjectValided(inImage))
                    Window.DispImage(inImage);
                else
                    ShowToolRunMessage("", false, "Image source is null!", true);
            }
            else
            {
                if (HObjectHelper.ObjectValided(CurrImage))
                    Window.DispImage(CurrImage);
            }
        }

        private void uiButton_RunTool_Click(object sender, EventArgs e)
        {
            ParamChanged(null, null);
        }
    }
}
