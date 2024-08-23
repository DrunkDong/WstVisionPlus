using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using WstCommonTools;
using HalconDotNet;
using Sunny.UI;

namespace WstControls
{
    public partial class Frm_EditShapeModel : UIForm, FrmInterface
    {
        public Frm_EditShapeModel()
        {
            InitializeComponent();
            child_window = new HDebugWindow();
            child_window.Size = panel1.Size;
            child_window.Location = new Point(0, 0);
            panel1.Controls.Add(child_window);
            uiComboBox_CreateMetric.SelectedIndex = 0;
            uiComboBox_CreateOptimization.SelectedIndex = 0;

            uNumericUpDown_CreateAngleStart.ValueChanged += ControlParamChanged;
            uNumericUpDown_CreateAngleExtent.ValueChanged += ControlParamChanged;
            uNumericUpDown_CreateNumLevels.ValueChanged += ControlParamChanged;
            uNumericUpDown_CreateScaleMin.ValueChanged += ControlParamChanged;
            uNumericUpDown_CreateScaleMax.ValueChanged += ControlParamChanged;
            uNumericUpDown_CreateContrastLow.ValueChanged += ControlParamChanged;
            uNumericUpDown_CreateContrastHigh.ValueChanged += ControlParamChanged;
            uNumericUpDown_CreateContrastSize.ValueChanged += ControlParamChanged;
            uiComboBox_CreateMetric.SelectedIndexChanged += ControlParamChanged;
            uiComboBox_CreateOptimization.SelectedIndexChanged += ControlParamChanged;
        }

        HDebugWindow child_window;
        ShapeModelTool tool;
        bool mIsInit;

        public ShapeModelTool Tool
        {
            get => tool;
            set => tool = value;
        }
        public HDebugWindow Child_window
        {
            get => child_window;
            set => child_window = value;
        }
        public HObject CurrImage { get; set; }
        public List<ToolBase> ToolList { get; set; }

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
            panel2.Enabled = false;
            this.ControlBox = false;
            child_window.IsMove = false;
            Tool.DrawRegion2(child_window, mode, out objl);
            panel2.Enabled = true;
            this.ControlBox = true;
            child_window.ShowRegionList.Clear();
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.SearchRegion.CopyObj(1, 1), color = Tool.SearchRegionColor });
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.CreateRegion.CopyObj(1, 1), color = Tool.CreateRegionColor });
            //child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.ShapeModelXld.Clone(), color = Tool.CreateRegionColor, colorMode = 1 });
        }
        private void UiButton_Daub_Click(object sender, EventArgs e)
        {
            string str;
            if (uiRadioButton_CircleStruct.Checked)
                str = "circle";
            else
                str = "rectangle";
            HObject objl;
            panel2.Enabled = false;
            this.ControlBox = false;
            child_window.IsMove = false;
            tool.DrawRoi2(child_window, 0, str, uiTrackBar_Size.Value, out objl);
            panel2.Enabled = true;
            this.ControlBox = true;
            child_window.ShowRegionList.Clear();
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.SearchRegion.CopyObj(1, 1), color = tool.SearchRegionColor });
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.CreateRegion.CopyObj(1, 1), color = tool.CreateRegionColor });
        }

        private void UiButton_Wipe_Click(object sender, EventArgs e)
        {
            string str;
            if (uiRadioButton_CircleStruct.Checked)
                str = "circle";
            else
                str = "rectangle";
            HObject objl;
            panel2.Enabled = false;
            this.ControlBox = false;
            child_window.IsMove = false;
            tool.DrawRoi2(child_window, 1, str, uiTrackBar_Size.Value, out objl);
            panel2.Enabled = true;
            this.ControlBox = true;
            child_window.ShowRegionList.Clear();
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.SearchRegion.CopyObj(1, 1), color = tool.SearchRegionColor });
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.CreateRegion.CopyObj(1, 1), color = tool.CreateRegionColor });
        }

        private void UiColorPicker_CreateRegion_ValueChanged(object sender, Color value)
        {
            tool.CreateRegionColor.color = value;
            child_window.DebugWindow.HalconWindow.ClearWindow();
            child_window.ShowRegionList.Clear();

            child_window.DebugWindow.HalconWindow.SetDraw(tool.SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
            child_window.SetColorRgba(tool.SearchRegionColor);
            child_window.DebugWindow.HalconWindow.DispObj(tool.SearchRegion);
            child_window.SetColorRgba(tool.CreateRegionColor);
            child_window.DebugWindow.HalconWindow.DispObj(tool.CreateRegion);

            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.SearchRegion.CopyObj(1, 1), color = tool.SearchRegionColor });
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = tool.CreateRegion.CopyObj(1, 1), color = tool.CreateRegionColor });
        }

        private void Frm_EditShapeModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void UiButton_AutoCreate_Click(object sender, EventArgs e)
        {
            AutoCreateShapeModel();
        }

        private void UiComboBox_CreateOptimization_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetParam()
        {
            tool.CreateAngleStart = uNumericUpDown_CreateAngleStart.Value;
            tool.CreateAngleExtent = uNumericUpDown_CreateAngleExtent.Value;
            tool.CreateNumLevels = (int)uNumericUpDown_CreateNumLevels.Value;
            tool.CreateScaleMin = uNumericUpDown_CreateScaleMin.Value;
            uNumericUpDown_CreateScaleMin.Value = tool.CreateScaleMin;
            tool.CreateScaleMax = uNumericUpDown_CreateScaleMax.Value;
            uNumericUpDown_CreateScaleMax.Value = tool.CreateScaleMax;
            tool.CreateContrastLow = (int)uNumericUpDown_CreateContrastLow.Value;
            uNumericUpDown_CreateContrastLow.Value = tool.CreateContrastLow;
            tool.CreateContrastHigh = (int)uNumericUpDown_CreateContrastHigh.Value;
            uNumericUpDown_CreateContrastHigh.Value = tool.CreateContrastHigh;
            tool.CreateContrastSize = (int)uNumericUpDown_CreateContrastSize.Value;
            tool.CreateMetric = uiComboBox_CreateMetric.SelectedItem.ToString();
            tool.CreateOptimization = uiComboBox_CreateOptimization.SelectedItem.ToString();
        }
        private void InitParam()
        {
            uNumericUpDown_CreateAngleStart.Value = tool.CreateAngleStart;
            uNumericUpDown_CreateAngleExtent.Value = tool.CreateAngleExtent;
            uNumericUpDown_CreateNumLevels.Value = tool.CreateNumLevels;
            uNumericUpDown_CreateScaleMin.Value = tool.CreateScaleMin;
            uNumericUpDown_CreateScaleMax.Value = tool.CreateScaleMax;
            uNumericUpDown_CreateContrastLow.Value = tool.CreateContrastLow;
            uNumericUpDown_CreateContrastHigh.Value = tool.CreateContrastHigh;
            uNumericUpDown_CreateContrastSize.Value = tool.CreateContrastSize;
            uiComboBox_CreateMetric.SelectedItem = tool.CreateMetric;
            uiComboBox_CreateOptimization.SelectedItem = tool.CreateOptimization;
            uiColorPicker_CreateRegion.Value = tool.CreateRegionColor.color;
        }


        private void AutoCreateShapeModel()
        {
            if (tool.SearchRegion.Area <= 0)
            {
                child_window.DebugWindow.HalconWindow.SetFont("Consolas-18");
                child_window.DebugWindow.HalconWindow.DispText("搜索区域未建立！", "image", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                return;
            }
            HOperatorSet.CountSeconds(out HTuple s1);
            HImage source = new HImage(child_window.CurrImage);
            if (tool.SearchShapeModel == null)
                tool.SearchShapeModel = new HShapeModel();
            tool.SearchShapeModel.CreateShapeModel(source.ReduceDomain(tool.CreateRegion), "auto", new HTuple(tool.CreateAngleStart).TupleRad().D, new HTuple(tool.CreateAngleExtent).TupleRad().D, "auto", "auto", "use_polarity",
                "auto", "auto");
            HTuple NumLevels = tool.SearchShapeModel.GetShapeModelParams(out double AngleStart, out double AngleExtent, out double AngleStep,
                  out HTuple ScaleMin, out HTuple ScaleMax, out HTuple ScaleStep, out string Metric, out int MinContrast);

            HHomMat2D homat = new HHomMat2D();
            homat.HomMat2dIdentity();
            HHomMat2D homat1 = homat.HomMat2dTranslate(tool.CreateRegion.Row, tool.CreateRegion.Column);

            HXLDCont contours = tool.SearchShapeModel.GetShapeModelContours(1);
            HXLDCont contourResult = contours.AffineTransContourXld(homat1);


            HTuple contrast_low = tool.SearchShapeModel.GetGenericShapeModelParam("contrast_low");
            HTuple contrast_high = tool.SearchShapeModel.GetGenericShapeModelParam("contrast_high");
            HTuple min_size = tool.SearchShapeModel.GetGenericShapeModelParam("min_size");
            HTuple optimization = tool.SearchShapeModel.GetGenericShapeModelParam("optimization");

            uNumericUpDown_CreateNumLevels.Value = NumLevels;
            uNumericUpDown_CreateScaleMin.Value = ScaleMin.D;
            uNumericUpDown_CreateScaleMax.Value = ScaleMax.D;
            uNumericUpDown_CreateContrastLow.Value = contrast_low.I;
            uNumericUpDown_CreateContrastHigh.Value = contrast_high.I;
            uNumericUpDown_CreateContrastSize.Value = min_size.I;
            uiComboBox_CreateMetric.SelectedItem = Metric;
            uiComboBox_CreateOptimization.SelectedItem = optimization;


            child_window.DebugWindow.HalconWindow.ClearWindow();
            child_window.DebugWindow.HalconWindow.SetLineWidth(2);
            child_window.ShowRegionList.Clear();
            //搜索区域
            child_window.DebugWindow.HalconWindow.SetDraw(tool.SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
            child_window.SetColorRgba(tool.SearchRegionColor);
            child_window.DebugWindow.HalconWindow.DispObj(tool.SearchRegion);
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.SearchRegion.CopyObj(1, 1), color = Tool.SearchRegionColor });
            //创建区域
            child_window.DebugWindow.HalconWindow.SetDraw(tool.CreateRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
            child_window.SetColorRgba(tool.CreateRegionColor);
            child_window.DebugWindow.HalconWindow.DispObj(tool.CreateRegion);
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.CreateRegion.CopyObj(1, 1), color = Tool.CreateRegionColor });
            //模板XLD
            child_window.DebugWindow.HalconWindow.SetColored(12);
            child_window.DebugWindow.HalconWindow.DispObj(contourResult);
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = contourResult.Clone(), color = Tool.CreateRegionColor, colorMode = 1 });
            //模板图片
            tool.ShapeModelImage = source.CopyObj(1, 1);
            HOperatorSet.CountSeconds(out HTuple s2);
            uToolStrip1.Invoke(new Action(() => { toolStripLabel_RunLabel.Text = "创建成功！  创建耗时：" + ((s2.D - s1.D) * 1000).ToString("f2") + " ms"; }));
        }

        private void CreateShapeModel()
        {
            if (tool.SearchRegion.Area <= 0)
                return;
            if (tool.CreateRegion.Area <= 10)
                return;
            HOperatorSet.CountSeconds(out HTuple s1);
            HImage source = new HImage(child_window.CurrImage);
            if (tool.SearchShapeModel == null)
                tool.SearchShapeModel = new HShapeModel();
            HTuple contrast = new HTuple();
            contrast[0] = tool.CreateContrastLow;
            contrast[1] = tool.CreateContrastHigh;
            contrast[2] = tool.CreateContrastSize;
            tool.SearchShapeModel.CreateShapeModel(source.ReduceDomain(tool.CreateRegion),
                tool.CreateNumLevels,
                new HTuple(tool.CreateAngleStart).TupleRad().D,
                new HTuple(tool.CreateAngleExtent).TupleRad().D,
                "auto",
                tool.CreateOptimization,
                tool.CreateMetric,
                contrast,
                "auto");

            HHomMat2D homat = new HHomMat2D();
            homat.HomMat2dIdentity();
            HHomMat2D homat1 = homat.HomMat2dTranslate(tool.CreateRegion.Row, tool.CreateRegion.Column);

            HXLDCont contours = tool.SearchShapeModel.GetShapeModelContours(1);
            HXLDCont contourResult = contours.AffineTransContourXld(homat1);

            child_window.DebugWindow.HalconWindow.ClearWindow();
            child_window.DebugWindow.HalconWindow.SetLineWidth(2);
            child_window.DebugWindow.HalconWindow.SetDraw(tool.SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
            child_window.SetColorRgba(tool.SearchRegionColor);
            child_window.DebugWindow.HalconWindow.DispObj(tool.SearchRegion);
            child_window.DebugWindow.HalconWindow.SetDraw(tool.CreateRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
            child_window.SetColorRgba(tool.CreateRegionColor);
            child_window.DebugWindow.HalconWindow.DispObj(tool.CreateRegion);
            child_window.ShowRegionList.Clear();
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.SearchRegion.CopyObj(1, 1), color = Tool.SearchRegionColor });
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.CreateRegion.CopyObj(1, 1), color = Tool.CreateRegionColor });
            child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = contourResult.Clone(), color = Tool.CreateRegionColor, colorMode = 1 });

            child_window.DebugWindow.HalconWindow.SetColored(12);
            child_window.DebugWindow.HalconWindow.DispObj(contourResult);

            tool.ShapeModelImage = source.CopyObj(1, 1);
            HOperatorSet.CountSeconds(out HTuple s2);
            uToolStrip1.Invoke(new Action(() => { toolStripLabel_RunLabel.Text = "创建成功！  创建耗时：" + ((s2.D - s1.D) * 1000).ToString("f2") + " ms"; }));
        }

        private void ControlParamChanged(double value)
        {
            if (!mIsInit) return;
            GetParam();
            CreateShapeModel();
        }

        private void ControlParamChanged(object sender, EventArgs e)
        {
            if (!mIsInit) return;
            GetParam();
            CreateShapeModel();
        }

        private void Frm_EditShapeModel_Load(object sender, EventArgs e)
        {
            InitParam();
            InitShowWinodw();
            mIsInit = true;
        }

        private void UiButton_ClearAll_Click(object sender, EventArgs e)
        {
            child_window.ShowRegionList.Clear();
            child_window.ShowStringInfoList.Clear();
            Tool.CreateRegion.GenEmptyRegion();
            child_window.DebugWindow.HalconWindow.ClearWindow();
            child_window.DebugWindow.HalconWindow.SetLineWidth(2);
            tool.ShapeModelImage = null;
            tool.SearchShapeModel = null;
            if (tool.SearchRegion.Area > 0)
            {
                child_window.DebugWindow.HalconWindow.SetDraw(tool.SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                child_window.SetColorRgba(tool.SearchRegionColor);
                child_window.DebugWindow.HalconWindow.DispObj(tool.SearchRegion);
                child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.SearchRegion.CopyObj(1, 1), color = Tool.SearchRegionColor });
            }
        }

        public void ShowToolRunMessage(string mes1 = "", bool isRed1 = false, string mes2 = "", bool isRed2 = false)
        {
            throw new NotImplementedException();
        }

        private void InitShowWinodw()
        {
            Child_window.ShowRegionList.Clear();
            Child_window.DebugWindow.HalconWindow.ClearWindow();
            //模板不为空的时候
            if (tool.SearchShapeModel != null)
            {
                Child_window.DispImage(tool.ShapeModelImage);
                Child_window.DebugWindow.HalconWindow.SetLineWidth(2);
                if (tool.SearchRegion.Area > 0)
                {
                    Child_window.DebugWindow.HalconWindow.SetDraw(tool.SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                    Child_window.SetColorRgba(tool.SearchRegionColor);
                    Child_window.DebugWindow.HalconWindow.DispObj(tool.SearchRegion);
                    Child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.SearchRegion.CopyObj(1, 1), color = Tool.SearchRegionColor });
                }
                if (tool.CreateRegion.Area > 0)
                {
                    Child_window.DebugWindow.HalconWindow.SetDraw(tool.CreateRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                    Child_window.SetColorRgba(tool.CreateRegionColor);
                    Child_window.DebugWindow.HalconWindow.DispObj(tool.CreateRegion);
                    Child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.CreateRegion.CopyObj(1, 1), color = Tool.CreateRegionColor });
                }
                HXLDCont hXLD = tool.SearchShapeModel.GetShapeModelContours(1);
                HOperatorSet.HomMat2dIdentity(out HTuple tup1);
                HOperatorSet.HomMat2dTranslate(tup1, tool.CreateRegion.Row, tool.CreateRegion.Column, out HTuple tup2);
                HOperatorSet.AffineTransContourXld(hXLD, out HObject affines, tup2);
                if (affines != null)
                {
                    Child_window.DebugWindow.HalconWindow.SetColored(12);
                    Child_window.DebugWindow.HalconWindow.DispObj(affines);
                    Child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = affines.Clone(), color = Tool.CreateRegionColor, colorMode = 1 });
                }
            }
            else
            {
                //显示图片
                if (tool.ImageSourceToolIDMark > 0)
                {
                    ToolBase ibase = ToolList.Where(x => x.ToolID == tool.ImageSourceToolIDMark).FirstOrDefault();
                    HObject inImage = ToolParamHelper.GetParamValueByName<HObject>(ibase, tool.ImageSourceParam);
                    if (HObjectHelper.ObjectValided(inImage))
                        Child_window.DispImage(inImage);
                }
                else
                {
                    if (HObjectHelper.ObjectValided(CurrImage))
                        Child_window.DispImage(CurrImage);
                }
                //显示区域
                if (tool.SearchRegion.Area > 0)
                {
                    Child_window.DebugWindow.HalconWindow.SetDraw(tool.SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                    Child_window.SetColorRgba(tool.SearchRegionColor);
                    Child_window.DebugWindow.HalconWindow.DispObj(tool.SearchRegion);
                    Child_window.ShowRegionList.Add(new ShowRegionInfoItem() { region = Tool.SearchRegion.CopyObj(1, 1), color = Tool.SearchRegionColor });
                }
            }
        }
    }
}
