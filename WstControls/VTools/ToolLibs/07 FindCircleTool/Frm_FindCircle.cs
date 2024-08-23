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
    public partial class Frm_FindCircle : UIForm, FrmInterface
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
        ImageFindCircleTool tool;
        public ImageFindCircleTool Tool
        {
            get => tool;
            set => tool = value;
        }
        public Frm_FindCircle()
        {
            InitializeComponent();
            Window.Size = panel1.Size;
            Window.Location = new Point(0, 0);
            Window.Parent = panel1;
        }

        private void AttachDrawObj(HDrawingObject obj)
        {
            obj.OnResize(OnResizeDrawingObject);
            obj.OnDrag(OnDragDrawingObject);
            Window.DebugWindow.HalconWindow.AttachDrawingObjectToWindow(obj);
        }

        private void OnResizeDrawingObject(HDrawingObject dobj, HWindow hwin, string type)
        {
            selected_drawing_object = dobj;
            string[] parms = new string[] { "row", "column", "radius" };
            HTuple hv_Parms = selected_drawing_object.GetDrawingObjectParams(parms);
            tool.Row1 = hv_Parms[0].D;
            tool.Column1 = hv_Parms[1].D;
            tool.Radius1 = hv_Parms[2].D;
            ParamChanged(null, null);
        }

        private void OnDragDrawingObject(HDrawingObject dobj, HWindow hwin, string type)
        {
            selected_drawing_object = dobj;
            string[] parms = new string[] { "row", "column", "radius" };
            HTuple hv_Parms = selected_drawing_object.GetDrawingObjectParams(parms);
            tool.Row1 = hv_Parms[0].D;
            tool.Column1 = hv_Parms[1].D;
            tool.Radius1 = hv_Parms[2].D;
            ParamChanged(null, null);
        }

        private void Frm_FindCircle_Load(object sender, EventArgs e)
        {
            this.Text = tool.ShowName;
            this.TitleFont = new Font("微软雅黑", 16F);
            this.TextAlignment = StringAlignment.Center;
            uiComboBox_Transition.SelectedIndex = 0;
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
                    FindLine(Window.CurrImage);
                    ShowToolRunMessage(Tool.CostTime.ToString(), false, "", false);
                }
                else
                    ShowToolRunMessage("", false, "image is null,please check imagesource!", true);
            }
            catch (Exception ex)
            {
                ShowToolRunMessage("", false, ex.Message, true);
            }
        }

        private void ParamChanged(double value)
        {
            if (!mIsInit) return;
            GetParam();
            try
            {
                if (HObjectHelper.ObjectValided(Window.CurrImage))
                {
                    FindLine(Window.CurrImage);
                    ShowToolRunMessage(Tool.CostTime.ToString(), false, "", false);
                }
                else
                    ShowToolRunMessage("", false, "image is null,please check imagesource!", true);
            }
            catch (Exception ex)
            {
                ShowToolRunMessage("", false, ex.Message, true);
            }
        }

        private void GetParam()
        {
            tool.mIsShowMeasureObj = uiCheckBox_IsShowMeasureObj.Checked;
            tool.mMeasureHeight = (int)uNumericUpDown_MeasureHeight.Value;
            tool.mMeasureWidth = (int)uNumericUpDown_MeasureWidth.Value;
            tool.mMeasureThreshold = (int)uNumericUpDown_MeasureThreshold.Value;
            tool.mMeasureNums = (int)uNumericUpDown_MeasureNums.Value;
            tool.mMeasureTransition = uiComboBox_Transition.SelectedItem.ToString();
            tool.mMeasureSelect = uiComboBox_Select.SelectedItem.ToString();
        }

        private void InitParam()
        {
            uiCheckBox_IsShowMeasureObj.Checked = tool.mIsShowMeasureObj;
            uNumericUpDown_MeasureHeight.Value = tool.mMeasureHeight;
            uNumericUpDown_MeasureWidth.Value = tool.mMeasureWidth;
            uNumericUpDown_MeasureThreshold.Value = tool.mMeasureThreshold;
            uNumericUpDown_MeasureNums.Value = tool.mMeasureNums;
            uiComboBox_Transition.SelectedItem = tool.mMeasureTransition;
            uiComboBox_Select.SelectedItem = tool.mMeasureSelect;

            uiCheckBox_IsShowMeasureObj.CheckedChanged += ParamChanged;
            uNumericUpDown_MeasureHeight.ValueChanged += ParamChanged;
            uNumericUpDown_MeasureWidth.ValueChanged += ParamChanged;
            uNumericUpDown_MeasureThreshold.ValueChanged += ParamChanged;
            uNumericUpDown_MeasureNums.ValueChanged += ParamChanged;
            uiComboBox_Transition.SelectedValueChanged += ParamChanged;
            uiComboBox_Select.SelectedValueChanged += ParamChanged;

            uiColorPicker_CheckRegion.Value = tool.mCricleShowColor.color;
            uiColorPicker_FindLineColor.Value = tool.mFindCircleColor.color;
            uiColorPicker_TextColor.Value = tool.mShowStringColor.color;

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

            if (tool.ShapeModelSourceToolIDMark > 0)
            {
                string name = ToolList.Where(x => x.ToolID == tool.ShapeModelSourceToolIDMark).FirstOrDefault().ShowName;
                uiComboTreeView_MatchingStep.Text = tool.ShapeModelSourceToolIDMark + "/" + name + "/" + tool.ShapeModelSourceParam;
            }
            else
                uiComboTreeView_MatchingStep.Text = "";
            MatchToLine();
        }

        public void ShowToolRunMessage(string mes1 = "", bool isRed1 = false, string mes2 = "", bool isRed2 = false)
        {
            label_runTime.Invoke(new Action(() =>
            {
                if (!isRed1)
                    label_runTime.ForeColor = System.Drawing.Color.Black;
                else
                    label_runTime.ForeColor = System.Drawing.Color.Red;
                if (mes1 != "")
                    label_runTime.Text = "Cost：" + Tool.CostTime.ToString("f2") + "ms";
                else
                    label_runTime.Text = "Cost：0ms";
            }));
            label_State.Invoke(new Action(() =>
            {
                if (!isRed2)
                    label_State.ForeColor = System.Drawing.Color.Black;
                else
                    label_State.ForeColor = System.Drawing.Color.Red;
                if (mes2 != "")
                    label_State.Text = "State：" + mes2;
                else
                    label_State.Text = "State：";
            }));
        }

        public HObject CurrImage { get; set ; }
        public List<ToolBase> ToolList { get; set ; }

        public void AddInputItems()
        {
            //图像源
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

            //模板匹配源
            TreeNode rootNode1 = new TreeNode("0/LocalData");
            rootNode1.Nodes.Add("None");
            uiComboTreeView_MatchingStep.TreeView.Nodes.Add(rootNode1);
            foreach (ToolBase item in ToolList)
            {
                if (item.Equals(this.tool))
                    break;
                List<string> lit1 = ToolParamHelper.GetParamsNames(item, ToolResultType.AlignData, ParamType._tuple);
                if (lit1.Count > 0)
                {
                    TreeNode root = new TreeNode(item.ToolID + "/" + item.ShowName);
                    for (int i = 0; i < lit1.Count; i++)
                    {
                        root.Nodes.Add(lit1[i]);
                    }
                    uiComboTreeView_MatchingStep.TreeView.Nodes.Add(root);
                }
            }

            //直线源
            foreach (ToolBase item in ToolList)
            {
                if (item.Equals(this.tool))
                    break;
                List<string> lit1 = ToolParamHelper.GetParamsNames(item, ToolResultType.line, ParamType._line);
                if (lit1.Count > 0)
                {
                    TreeNode root = new TreeNode(item.ToolID + "/" + item.ShowName);
                    for (int i = 0; i < lit1.Count; i++)
                    {
                        root.Nodes.Add(lit1[i]);
                    }
                    uiComboTreeView_LineStep.TreeView.Nodes.Add(root);
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

        private void FindLine(HObject objFinal)
        {
            //初始化窗口和所有集合
            Window.DebugWindow.HalconWindow.ClearWindow();
            Window.DebugWindow.HalconWindow.SetLineWidth(2);
            Window.ShowRegionList.Clear();
            Window.ShowStringInfoList.Clear();
            ShowToolRunMessage();

            //二位测量句柄
            HTuple hv_MetrologyHandle = new HTuple();

            HTuple param = new HTuple();
            param[0] = "num_measures";
            param[1] = "measure_select";
            param[2] = "measure_transition";

            HTuple paramValue = new HTuple();
            paramValue[0] = tool.mMeasureNums;
            paramValue[1] = tool.mMeasureSelect;
            paramValue[2] = tool.mMeasureTransition;

            HOperatorSet.CountSeconds(out HTuple s1);
            HOperatorSet.GetImageSize(objFinal, out HTuple hv_Width, out HTuple hv_Height);//获取大小
            hv_MetrologyHandle.Dispose();
            HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);//创建搜索模型
            HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width / 2, hv_Height / 2);//设置大小
            HOperatorSet.AddMetrologyObjectCircleMeasure(hv_MetrologyHandle, tool.Row1, tool.Column1, tool.Radius1,//参数导入模型
                 tool.mMeasureWidth, tool.mMeasureHeight, 0.4, tool.mMeasureThreshold, param, paramValue, out HTuple hv_Index);
            HOperatorSet.ApplyMetrologyModel(objFinal, hv_MetrologyHandle);//获取模型结果                                                                              
            HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, 0, "all", "result_type", "all_param", out HTuple hv_Parameter); //获取参数结果
            //轮廓
            HOperatorSet.GetMetrologyObjectResultContour(out HObject resultLine, hv_MetrologyHandle, 0, "all", 1.5);
            if (tool.mIsShowMeasureObj)
            {
                HOperatorSet.GetMetrologyObjectMeasures(out HObject ho_Contours, hv_MetrologyHandle, "all", "all", out HTuple hv_Row, out HTuple hv_Column);//获取检测框
                ShowRegionInfoItem infoItem = new ShowRegionInfoItem();
                infoItem.region = ho_Contours.Clone();
                infoItem.color = new ColorEx(System.Drawing.Color.Red);
                infoItem.color.showType = ShowType.Xld;
                infoItem.colorMode = 1;
                window.ShowRegionList.Add(infoItem);
                window.DebugWindow.HalconWindow.SetColored(12);
                window.DebugWindow.HalconWindow.DispObj(ho_Contours);
                ho_Contours.Dispose();
            }
            if (resultLine.CountObj() < 1)
            {
                resultLine.Dispose();
                hv_MetrologyHandle.Dispose();
                window.DebugWindow.HalconWindow.DispText("find circle failed!", "window", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                ShowToolRunMessage(tool.CostTime.ToString("f2"), false, "find circle failed!", true);
                return;
            }
            //显示直线
            window.DebugWindow.HalconWindow.SetColor(tool.mFindCircleColor.color.RgbToHex());
            window.DebugWindow.HalconWindow.DispObj(resultLine);
            window.ShowRegionList.Add(new ShowRegionInfoItem() { region = resultLine.Clone(), color = new ColorEx(tool.mFindCircleColor.color), colorMode = 1 });

            //显示字符1
            window.DebugWindow.HalconWindow.DispText("find circle success!", "window", 0, 0, tool.mShowStringColor.color.RgbToHex(), (HTuple)"box", (HTuple)"false");
            Window.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "find circle success!", color = tool.mShowStringColor.color, location = new PointEx(0, 0) });

            //显示字符2
            string result = $"row= {hv_Parameter[0].D.ToString("f1")}, column= {hv_Parameter[1].D.ToString("f1")},radius= {hv_Parameter[2].D.ToString("f1")}";
            window.DebugWindow.HalconWindow.DispText(result, "window", 18, 0, tool.mShowStringColor.color.RgbToHex(), (HTuple)"box", (HTuple)"false");
            Window.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = result, color = tool.mShowStringColor.color, location = new PointEx(18, 0) });

            tool.CircleRow = hv_Parameter[0].D;
            tool.CircleColumn = hv_Parameter[1].D;
            tool.CircleRadius = hv_Parameter[2].D;

            tool.CircleResult = new CircleROI();
            tool.CircleResult.RowCenter = hv_Parameter[0].D;
            tool.CircleResult.ColumnCenter = hv_Parameter[1].D;
            tool.CircleResult.Radius = hv_Parameter[2].D;

            HOperatorSet.CountSeconds(out HTuple s2);
            tool.CostTime = (s2.D - s1.D) * 1000;
            hv_MetrologyHandle.Dispose();
        }

        private void uiComboTreeView_MatchingStep_NodeSelected(object sender, TreeNode node)
        {
            if (!mIsInit)
                return;
            uiComboTreeView_MatchingStep.Text = node.Parent.Text + "/" + node.Text;
            tool.ShapeModelSourceToolIDMark = int.Parse(node.Parent.Text.Split('/')[0]);
            tool.ShapeModelSourceParam = node.Text;
            MatchToLine();
        }

        private void uiComboTreeView_LineStep_NodeSelected(object sender, TreeNode node)
        {
            if (!mIsInit)
                return;
            uiComboTreeView_LineStep.Text = node.Parent.Text + "/" + node.Text;
            tool.CircleSourceToolIDMark = int.Parse(node.Parent.Text.Split('/')[0]);
            tool.CircleSourceParam = node.Text;
        }

        private void MatchToLine()
        {
            HTuple row1Result = 0;
            HTuple column1Result = 0;
            HTuple radiusResult = 0;
            if (tool.ShapeModelSourceToolIDMark > 0)
            {
                ToolBase ibase = ToolList.Where(x => x.ToolID == tool.ShapeModelSourceToolIDMark).FirstOrDefault();
                HTuple hTuple = ToolParamHelper.GetParamValueByName<HTuple>(ibase, tool.ShapeModelSourceParam);
                if (hTuple.Length > 0)
                {
                    HOperatorSet.AffineTransPoint2d(hTuple, tool.Row1, tool.Column1, out row1Result, out column1Result);
                    radiusResult = tool.Radius1;
                }
                else
                {
                    row1Result = tool.Row1;
                    column1Result = tool.Column1;
                    radiusResult = tool.Radius1;
                }

            }
            else
            {
                row1Result = tool.Row1;
                column1Result = tool.Column1;
                radiusResult = tool.Radius1;
            }
            foreach (var item in objList)
            {
                Window.DebugWindow.HalconWindow.DetachDrawingObjectFromWindow(item);
            }
            HDrawingObject circle = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.CIRCLE, row1Result, column1Result, radiusResult);
            string colo = tool.mCricleShowColor.color.RgbToHex();
            circle.SetDrawingObjectParams("color", tool.mCricleShowColor.color.RgbToHex());
            AttachDrawObj(circle);
            objList.Add(circle);

        }

        private void uiColorPicker_CheckRegion_ValueChanged(object sender, System.Drawing.Color value)
        {
            tool.mCricleShowColor.color = value;
            foreach (HDrawingObject obj in objList)
            {
                obj.SetDrawingObjectParams("color", tool.mCricleShowColor.color.RgbToHex());
            }
        }

        private void uiColorPicker_FindLineColor_ValueChanged(object sender, System.Drawing.Color value)
        {
            tool.mFindCircleColor.color = value;
            ParamChanged(null, null);
        }

        private void uiColorPicker_TextColor_ValueChanged(object sender, System.Drawing.Color value)
        {
            tool.mShowStringColor.color = value;
            ParamChanged(null, null);
        }
    }
}
