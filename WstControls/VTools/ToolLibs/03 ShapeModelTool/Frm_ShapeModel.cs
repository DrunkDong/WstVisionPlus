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
    public partial class Frm_ShapeModel : UIForm, FrmInterface
    {
        bool mIsInit;
        HDebugWindow window;
        HShowWindow show_window;
        public HDebugWindow Window
        {
            get => window;
            set => window = value;
        }
        ShapeModelTool tool;
        public ShapeModelTool Tool
        {
            get => tool;
            set => tool = value;
        }
        public HShowWindow Show_window
        {
            get => show_window;
            set => show_window = value;
        }
        public HObject CurrImage { get; set; }
        public List<ToolBase> ToolList { get; set; }

        public Frm_ShapeModel()
        {
            InitializeComponent();
            window = new HDebugWindow();
            Window.Size = panel1.Size;
            Window.Location = new Point(0, 0);
            Window.Parent = panel1;

            show_window = new HShowWindow();
            show_window.Size = panel_showWind.Size;
            show_window.Location = new Point(0, 0);
            show_window.Parent = panel_showWind;

            uNumericUpDown_FindStartAngle.ValueChanged += ParamChanged;
            uNumericUpDown_FindStartExtent.ValueChanged += ParamChanged;
            uNumericUpDown_FindScoreMin.ValueChanged += ParamChanged;
            uNumericUpDown_FindNums.ValueChanged += ParamChanged;
            uNumericUpDown_FindGreediness.ValueChanged += ParamChanged;
            uNumericUpDown_FindOverlap.ValueChanged += ParamChanged;
            uNumericUpDown_FindTimeOut.ValueChanged += ParamChanged;
        }

        private void Frm_ShapeModel_Load(object sender, EventArgs e)
        {
            //指定显示窗口句柄
            Tool.ToolWind = Window;
            InitParam();
            AddInputItems();
            InitAllComboboxNode();
            LoadToolImage();
            LoadToolRegion();
            mIsInit = true;
            UiButton_RunTool_Click(null, null);
            if (tool.SearchShapeModel != null && tool.ShapeModelImage != null)
            {
                HImage image1 = tool.ShapeModelImage.ReduceDomain(Tool.CreateRegion).CropDomain();
                HOperatorSet.AreaCenter(image1, out HTuple area, out HTuple row, out HTuple column);
                HHomMat2D homat = new HHomMat2D();
                homat.HomMat2dIdentity();
                HHomMat2D homat1 = homat.HomMat2dTranslate(row, column);
                HXLDCont contours = tool.SearchShapeModel.GetShapeModelContours(1);
                HXLDCont contourResult = contours.AffineTransContourXld(homat1);
                Show_window.Window.HalconWindow.ClearWindow();
                Show_window.DispObj(image1);
                Show_window.Window.HalconWindow.SetLineWidth(2);
                Show_window.Window.HalconWindow.SetColor("magenta");
                Show_window.Window.HalconWindow.DispObj(contourResult);
                Show_window.Window.SetFullImagePart();
                image1.Dispose();
            }

        }

        private void ParamChanged(object sender, EventArgs e)
        {
            if (!mIsInit) return;
            GetParam();
            if (Window.CurrImage == null || !Window.CurrImage.IsInitialized()) return;

        }

        private void ParamChanged(double e)
        {
            if (!mIsInit) return;
            GetParam();
            if (Window.CurrImage == null || !Window.CurrImage.IsInitialized()) return;


        }

        private void GetParam()
        {
            tool.FindStartAngle = (int)uNumericUpDown_FindStartAngle.Value;
            tool.FindStartExtent = (int)uNumericUpDown_FindStartExtent.Value;
            tool.FindScoreMin = uNumericUpDown_FindScoreMin.Value;
            tool.FindNums = (int)uNumericUpDown_FindNums.Value;
            tool.FindGreediness = uNumericUpDown_FindGreediness.Value;
            tool.FindOverlap = uNumericUpDown_FindOverlap.Value;
            tool.FindTimeOut = (int)uNumericUpDown_FindTimeOut.Value;
        }

        private void InitParam()
        {
            uNumericUpDown_FindStartAngle.Value = tool.FindStartAngle;
            uNumericUpDown_FindStartExtent.Value = tool.FindStartExtent;
            uNumericUpDown_FindScoreMin.Value = tool.FindScoreMin;
            uNumericUpDown_FindNums.Value = tool.FindNums;
            uNumericUpDown_FindGreediness.Value = tool.FindGreediness;
            uNumericUpDown_FindOverlap.Value = tool.FindOverlap;
            uNumericUpDown_FindTimeOut.Value = tool.FindTimeOut;

            uiColorPicker_CheckRegion.Value = tool.SearchRegionColor.color;
            uiColorPicker_ResultSrting.Value = tool.ShowStringColor.color;
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
            Window.IsMove = false;
            tool.DrawRoi1(window, 0, str, uiTrackBar_Size.Value, out objl);
            uTabControl_Setting.Enabled = true;
            panel_Status.Enabled = true;
            this.ControlBox = true;
            Window.ShowRegionList.Clear();
            Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.SearchRegion.CopyObj(1, 1), color = tool.SearchRegionColor });
            Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.CreateRegion.CopyObj(1, 1), color = tool.CreateRegionColor });
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
            Window.IsMove = false;
            tool.DrawRoi1(window, 1, str, uiTrackBar_Size.Value, out objl);
            uTabControl_Setting.Enabled = true;
            panel_Status.Enabled = true;
            this.ControlBox = true;
            Window.ShowRegionList.Clear();
            Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.SearchRegion.CopyObj(1, 1), color = tool.SearchRegionColor });
            Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.CreateRegion.CopyObj(1, 1), color = tool.CreateRegionColor });
        }

        private void UiTrackBar_Size_ValueChanged(object sender, EventArgs e)
        {
            label_Size.Text = "大小：" + uiTrackBar_Size.Value;
        }

        private void UiColorPicker_CheckRegion_ValueChanged(object sender, Color value)
        {
            //初始化
            Window.ShowRegionList.Clear();
            Window.ShowStringInfoList.Clear();

            //获取颜色
            tool.SearchRegionColor = new ColorEx(value);
            tool.SearchRegionColor.showMode = ShowMode.Margin;

            Window.DebugWindow.HalconWindow.ClearWindow();
            Window.DebugWindow.HalconWindow.SetDraw(tool.SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
            Window.SetColorRgba(tool.SearchRegionColor);
            Window.DebugWindow.HalconWindow.DispObj(tool.SearchRegion);
            Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.SearchRegion.CopyObj(1, 1), color = tool.SearchRegionColor });
            Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.CreateRegion.CopyObj(1, 1), color = tool.CreateRegionColor });
        }

        private void UiButton_Create_Click(object sender, EventArgs e)
        {
            string mode = "circle";
            if (uiRadioButton_Circle.Checked)
                mode = "circle";
            else if (uiRadioButton_Rec1.Checked)
                mode = "rectangle1";
            else if (uiRadioButton_Rec2.Checked)
                mode = "rectangle2";
            else if (uiRadioButton_Ellipse.Checked)
                mode = "ellipse";

            HObject objl;
            uTabControl_Setting.Enabled = false;
            panel_Status.Enabled = false;
            this.ControlBox = false;
            Window.IsMove = false;
            tool.DrawRegion1(window, mode, out objl);
            uTabControl_Setting.Enabled = true;
            panel_Status.Enabled = true;
            this.ControlBox = true;
            Window.ShowRegionList.Clear();
            Window.ShowStringInfoList.Clear();
            Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.SearchRegion.CopyObj(1, 1), color = tool.SearchRegionColor });
            Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.CreateRegion.CopyObj(1, 1), color = tool.CreateRegionColor });
        }

        private void UiButton_ShapeModelEdit_Click(object sender, EventArgs e)
        {
            Frm_EditShapeModel frm = new Frm_EditShapeModel();
            frm.Tool = tool;
            frm.ToolList = ToolList;
            frm.Child_window.DispImage(Window.CurrImage);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Window.ShowRegionList.Clear();
                Window.DebugWindow.HalconWindow.ClearWindow();
                Window.DebugWindow.HalconWindow.SetLineWidth(2);
                if (tool.SearchRegion.Area > 0)
                {
                    Window.DebugWindow.HalconWindow.SetDraw(tool.SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                    Window.SetColorRgba(tool.SearchRegionColor);
                    Window.DebugWindow.HalconWindow.DispObj(tool.SearchRegion);
                    Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.SearchRegion.CopyObj(1, 1), color = Tool.SearchRegionColor });
                }
                if (tool.CreateRegion.Area > 0)
                {
                    Window.DebugWindow.HalconWindow.SetDraw(tool.CreateRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                    Window.SetColorRgba(tool.CreateRegionColor);
                    Window.DebugWindow.HalconWindow.DispObj(tool.CreateRegion);
                    Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.CreateRegion.CopyObj(1, 1), color = Tool.CreateRegionColor });
                }

                if (tool.SearchShapeModel != null)
                {
                    HXLDCont hXLD = tool.SearchShapeModel.GetShapeModelContours(1);
                    HOperatorSet.HomMat2dIdentity(out HTuple tup1);
                    HOperatorSet.HomMat2dTranslate(tup1, tool.CreateRegion.Row, tool.CreateRegion.Column, out HTuple tup2);
                    HOperatorSet.AffineTransContourXld(hXLD, out HObject affines, tup2);
                    if (affines != null)
                    {
                        Window.DebugWindow.HalconWindow.SetColored(12);
                        Window.DebugWindow.HalconWindow.DispObj(affines);
                        Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = affines.Clone(), color = Tool.CreateRegionColor, colorMode = 1 });
                    }
                }

                if (tool.SearchShapeModel != null && tool.ShapeModelImage != null)
                {
                    HImage image = tool.ShapeModelImage.ReduceDomain(Tool.CreateRegion).CropDomain();
                    HOperatorSet.AreaCenter(image, out HTuple area, out HTuple row, out HTuple column);
                    HHomMat2D homat = new HHomMat2D();
                    homat.HomMat2dIdentity();
                    HHomMat2D homat1 = homat.HomMat2dTranslate(row, column);
                    HXLDCont contours = tool.SearchShapeModel.GetShapeModelContours(1);
                    HXLDCont contourResult = contours.AffineTransContourXld(homat1);
                    Show_window.Window.HalconWindow.ClearWindow();
                    Show_window.DispObj(image);
                    Show_window.Window.HalconWindow.SetLineWidth(2);
                    Show_window.Window.HalconWindow.SetColored(12);
                    Show_window.Window.HalconWindow.DispObj(contourResult);
                    Show_window.Window.SetFullImagePart();
                }
            }
        }

        private void FindShapeModel(HObject image)
        {
            //显示
            ShowToolRunMessage("", false, "", false);
            Window.DebugWindow.HalconWindow.SetFont("Consolas-18");
            //模板
            window.ClearWindow();
            if (tool.SearchRegion.Area <= 0)
            {
                window.DebugWindow.HalconWindow.DispText("SearchRegion is null！", "image", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                ShowToolRunMessage("", false, "SearchRegion is null!", true);
                return;
            }
            if (tool.SearchShapeModel == null)
            {
                window.DebugWindow.HalconWindow.DispText("ShapeModel is null！", "image", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                ShowToolRunMessage("", false, "SearchRegion is null!", true);
                return;
            }
            //初始化窗口和所有集合
            Window.DebugWindow.HalconWindow.ClearWindow();
            Window.DebugWindow.HalconWindow.SetLineWidth(2);
            Window.ShowRegionList.Clear();
            Window.ShowStringInfoList.Clear();
            try
            {
                //运行
                HImage imageSource = new HImage(image);
                HOperatorSet.CountSeconds(out HTuple s1);
                tool.SearchShapeModel.FindScaledShapeModel(imageSource,
                    new HTuple(tool.FindStartAngle).TupleRad().D,
                    new HTuple(tool.FindStartExtent).TupleRad().D,
                    (double)tool.CreateScaleMin,
                    (double)tool.CreateScaleMax,
                    (HTuple)tool.FindScoreMin,
                    (int)tool.FindNums,
                    (double)tool.FindOverlap,
                    new HTuple("least_squares"),
                    (new HTuple(7)).TupleConcat(3),
                    (double)tool.FindGreediness,
                    out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score);
                HOperatorSet.CountSeconds(out HTuple s2);
                imageSource.Dispose();
                if (row.TupleLength() == 1)
                {
                    HTuple HomMat2D, HomMat2D1, HomMat2D2, HomMat2D3;
                    HObject affine1;
                    HObject affine2;
                    HXLDCont objXlds = tool.SearchShapeModel.GetShapeModelContours(1);

                    HOperatorSet.HomMat2dIdentity(out HomMat2D1);
                    HOperatorSet.HomMat2dScale(HomMat2D1, scale, scale, 0, 0, out HomMat2D2);
                    HOperatorSet.HomMat2dRotate(HomMat2D2, angle, 0, 0, out HomMat2D3);
                    HOperatorSet.HomMat2dTranslate(HomMat2D3, row, column, out HomMat2D1);
                    //转换模板轮廓
                    HOperatorSet.AffineTransContourXld(objXlds, out affine1, HomMat2D1);
                    //加入区域缩放
                    HOperatorSet.VectorAngleToRigid(tool.CreateRegion.Row, tool.CreateRegion.Column, 0, row, column, angle, out HomMat2D);
                    HTuple HomMat2D4;
                    HOperatorSet.HomMat2dIdentity(out HomMat2D4);
                    HOperatorSet.HomMat2dScale(HomMat2D, scale, scale, row, column, out HomMat2D4);
                    HOperatorSet.AffineTransRegion(tool.CreateRegion, out affine2, HomMat2D4, "nearest_neighbor");

                    tool.FindRows = row[0].D;
                    tool.FindColumns = column[0].D;
                    tool.FindAngles = angle[0].D;
                    tool.FindScores = score[0].D;
                    tool.FindScale = scale[0].D;
                    tool.AffineMatrix = HomMat2D.Clone();

                    //搜索区域
                    Window.DebugWindow.HalconWindow.SetDraw(tool.SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                    Window.SetColorRgba(tool.SearchRegionColor);
                    Window.DebugWindow.HalconWindow.DispObj(tool.SearchRegion);
                    Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.SearchRegion.CopyObj(1, 1), color = Tool.SearchRegionColor });

                    //创建区域，矫正后的
                    Window.DebugWindow.HalconWindow.SetDraw(tool.CreateRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                    Window.SetColorRgba(tool.CreateRegionColor);
                    Window.DebugWindow.HalconWindow.DispObj(affine2);
                    Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = affine2.Clone(), color = Tool.CreateRegionColor });

                    //模板轮廓
                    Window.DebugWindow.HalconWindow.SetColored(12);
                    Window.DebugWindow.HalconWindow.DispObj(affine1);
                    Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = affine1.Clone(), color = Tool.CreateRegionColor, colorMode = 1 });

                    //string类别显示,提示成功
                    Window.DebugWindow.HalconWindow.DispText("find success！", "window", 0, 0, tool.ShowStringColor.color.RgbToHex(), (HTuple)"box", (HTuple)"false");
                    Window.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "find success！", color = tool.ShowStringColor.color, location = new PointEx(0, 0) });

                    //string类别显示,提示查找信息
                    string result =
                        "score=" + score[0].D.ToString("f3") +
                        ",row=" + row[0].D.ToString("f2") +
                        ",column=" + column[0].D.ToString("f2") +
                        ",angle=" + angle[0].D.ToString("f3") +
                        ",scale=" + scale[0].D.ToString("f3");
                    Window.DebugWindow.HalconWindow.DispText(result, "window", 18, 0, tool.ShowStringColor.color.RgbToHex(), (HTuple)"box", (HTuple)"false");
                    Window.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = result, color = tool.ShowStringColor.color, location = new PointEx(18, 0) });

                    //显示
                    tool.CostTime = (s2.D - s1.D) * 1000;
                    ShowToolRunMessage(tool.CostTime.ToString(), false, "find success", false);



                }
                else
                {
                    //搜索区域
                    Window.DebugWindow.HalconWindow.SetDraw(tool.SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                    Window.SetColorRgba(tool.SearchRegionColor);
                    Window.DebugWindow.HalconWindow.DispObj(tool.SearchRegion);
                    //string类别显示
                    Window.ShowStringInfoList.Clear();
                    Window.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "查找失败！", color = System.Drawing.Color.Red, location = new PointEx(0, 0) });
                    Window.DebugWindow.HalconWindow.DispText("find fail！", "window", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                    tool.CostTime = (s2.D - s1.D) * 1000;
                    ShowToolRunMessage("", false, "find fail", true);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("time out"))
                    ShowToolRunMessage("", false, "find time out", true);
                else
                    ShowToolRunMessage("", false, ex.Message, true);
            }
        }

        private void UiButton_RunTool_Click(object sender, EventArgs e)
        {
            if (!HObjectHelper.ObjectValided(Window.CurrImage))
            {
                ShowToolRunMessage("", false, "image is null,please check imagesource!", true);
                return;
            }
            FindShapeModel(Window.CurrImage);
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

        private void uiComboTreeView_ImageSource_NodeSelected(object sender, TreeNode node)
        {
            if (!mIsInit)
                return;
            uiComboTreeView_ImageSource.Text = node.Parent.Text + "/" + node.Text;
            tool.ImageSourceToolIDMark = int.Parse(node.Parent.Text.Split('/')[0]);
            tool.ImageSourceParam = node.Text;
            LoadToolImage();
        }

        private void uiComboTreeView_RegionStep_NodeSelected(object sender, TreeNode node)
        {
            if (!mIsInit)
                return;
            uiComboTreeView_RegionStep.Text = node.Parent.Text + "/" + node.Text;
            tool.RegionSourceToolIDMark = int.Parse(node.Parent.Text.Split('/')[0]);
            tool.RegionSourceParam = node.Text;
            LoadToolRegion();
        }

        private void LoadToolImage()
        {
            ShowToolRunMessage("", false, "", false);
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

        private void LoadToolRegion()
        {
            //获取工具源输入
            if (tool.RegionSourceToolIDMark > 0)
            {
                ToolBase ibase = ToolList.Where(x => x.RegionSourceToolIDMark == tool.RegionSourceToolIDMark).FirstOrDefault();
                HRegion inRegion = ToolParamHelper.GetParamValueByName<HRegion>(ibase, tool.RegionSourceParam);
                if (inRegion.Area > 0)
                    Window.DebugWindow.HalconWindow.DispObj(inRegion);
                else
                    ShowToolRunMessage("", false, "Image source is null!", true);
            }
            else
            {
                //若无工具源，则是本地搜索区域
                //if (HObjectHelper.ObjectValided(          Machine.GetInstance().FrmProject.CurrImage))
                //    Window.DispImage(          Machine.GetInstance().FrmProject.CurrImage);
            }
        }

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

            //区域源
            foreach (ToolBase item in ToolList)
            {
                if (item.Equals(this.tool))
                    break;
                List<string> lit = ToolParamHelper.GetParamsNames(item, ToolResultType.Region, ParamType.region);
                if (lit.Count > 0)
                {
                    TreeNode root = new TreeNode(item.ToolID + "/" + item.ShowName);
                    for (int i = 0; i < lit.Count; i++)
                    {
                        root.Nodes.Add(lit[i]);
                    }
                    uiComboTreeView_RegionStep.TreeView.Nodes.Add(root);
                }

                List<string> lit1 = ToolParamHelper.GetParamsNames(item, ToolResultType.RegionAndTuple, ParamType.region);
                if (lit1.Count > 0)
                {
                    TreeNode root = new TreeNode(item.ToolID + "/" + item.ShowName);
                    for (int i = 0; i < lit1.Count; i++)
                    {
                        root.Nodes.Add(lit1[i]);
                    }
                    uiComboTreeView_RegionStep.TreeView.Nodes.Add(root);
                }
            }
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

            if (tool.RegionSourceToolIDMark > 0)
            {
                string name = ToolList.Where(x => x.ToolID == tool.RegionSourceToolIDMark).FirstOrDefault().ShowName;
                uiComboTreeView_RegionStep.Text = tool.RegionSourceToolIDMark + "/" + name + "/" + tool.RegionSourceParam;
            }
            LoadToolRegion();
        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            tool.SearchRegion.GenEmptyObj();
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            //清除所有显示
            show_window.Window.HalconWindow.ClearWindow();
            Window.ShowRegionList.Clear();
            Window.ShowStringInfoList.Clear();
            Tool.CreateRegion.GenEmptyRegion();
            Window.DebugWindow.HalconWindow.ClearWindow();
            Window.DebugWindow.HalconWindow.SetLineWidth(2);
            tool.ShapeModelImage = null;
            tool.SearchShapeModel = null;
            if (tool.SearchRegion.Area > 0)
            {
                Window.DebugWindow.HalconWindow.SetDraw(tool.SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                Window.SetColorRgba(tool.SearchRegionColor);
                Window.DebugWindow.HalconWindow.DispObj(tool.SearchRegion);
                Window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.SearchRegion.CopyObj(1, 1), color = Tool.SearchRegionColor });
            }
        }
        private void uiColorPicker1_ValueChanged(object sender, Color value)
        {
            //初始化
            Window.ShowRegionList.Clear();
            Window.ShowStringInfoList.Clear();
            //获取颜色
            tool.ShowStringColor = new ColorEx(value);
            UiButton_RunTool_Click(null, null);
        }

    }
}
