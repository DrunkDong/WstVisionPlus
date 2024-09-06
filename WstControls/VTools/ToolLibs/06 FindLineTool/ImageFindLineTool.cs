using WstCommonTools;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstControls
{
    [Serializable]
    public class ImageFindLineTool : ToolBase
    {
        public ImageFindLineTool()
        {
            Type = ToolType.FindLine;
            ResultType = ToolResultType.line;

            mMeasureWidth = 20;
            mMeasureHeight = 10;
            mMeasureNums = 10;
            mMeasureThreshold = 10;
            mMeasureSelect = "all";
            mMeasureTransition = "all";
            mIsShowMeasureObj = false;

            LineSourceToolIDMark = -1;
            LineSourceParam = "";

            Row1 = 100;
            Column1 = 100;
            Row2 = 300;
            Column2 = 100;

            mLineShowColor = new ColorEx(System.Drawing.Color.Red);
            mLineShowColor.showType = ShowType.contours;

            mFindLineColor = new ColorEx(System.Drawing.Color.Red);
            mFindLineColor.showType = ShowType.contours;

            mShowStringColor = new ColorEx(System.Drawing.Color.Red);
            mShowStringColor.showType = ShowType.contours;

            mLineResult = new LineROI();
            mLineStartRow = 0;
            mLineStartColumn = 0;
            mLineEndRow = 0;
            mLineEndColumn = 0;
        }

        public int mMeasureWidth;
        public int mMeasureHeight;
        public int mMeasureNums;
        public int mMeasureThreshold;
        public string mMeasureSelect;
        public string mMeasureTransition;
        public bool mIsShowMeasureObj;

        public double Row1;
        public double Column1;
        public double Row2;
        public double Column2;

        public ColorEx mLineShowColor;
        public ColorEx mFindLineColor;
        public ColorEx mShowStringColor;


        LineROI mLineResult;
        double mLineStartRow;
        double mLineStartColumn;
        double mLineEndRow;
        double mLineEndColumn;

        public int LineSourceToolIDMark;
        public string LineSourceParam;


        [ToolParamType(ParamType._line)]
        [ToolResult("LineResult")]
        public LineROI LineResult
        {
            get => mLineResult;
            set => mLineResult = value;
        }

        [ToolParamType(ParamType._double)]
        [ToolResult("LineStartRow")]
        public double LineStartRow
        {
            get => mLineStartRow;
            set => mLineStartRow = value;
        }

        [ToolParamType(ParamType._double)]
        [ToolResult("LineStartColumn")]
        public double LineStartColumn
        {
            get => mLineStartColumn;
            set => mLineStartColumn = value;
        }

        [ToolParamType(ParamType._double)]
        [ToolResult("LineEndRow")]
        public double LineEndRow
        {
            get => mLineEndRow;
            set => mLineEndRow = value;
        }

        [ToolParamType(ParamType._double)]
        [ToolResult("LineEndColumn")]
        public double LineEndColumn
        {
            get => mLineEndColumn;
            set => mLineEndColumn = value;
        }

        public override void ReleaseReslut()
        {
            mLineResult = new LineROI();
            mLineStartRow = 0;
            mLineStartColumn = 0;
            mLineEndRow = 0;
            mLineEndColumn = 0;
        }

        public override OperateStatus ToolRun(List<ToolBase> toolList, bool mIsShowResult)
        {
            System.Threading.Thread.Sleep(1000);
            if (mIsShowResult)
            {
                //初始化窗口和所有集合
                DebugWind.DebugWindow.HalconWindow.ClearWindow();
                DebugWind.DebugWindow.HalconWindow.SetLineWidth(2);
                DebugWind.ShowRegionList.Clear();
                DebugWind.ShowStringInfoList.Clear();
            }

            HObject objFinal;
            //获取图片源
            if (ImageSourceToolIDMark > 0)
            {
                ToolBase ibase = toolList.Where(x => x.ToolID == ImageSourceToolIDMark).FirstOrDefault();
                objFinal = ToolParamHelper.GetParamValueByName<HObject>(ibase, ImageSourceParam);
                if (!HObjectHelper.ObjectValided(objFinal))
                {
                    if (mIsShowResult)
                    {
                        //显示字符1
                        DebugWind.DebugWindow.HalconWindow.DispText("image source is null!", "window", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                        DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "image source is null!", color = System.Drawing.Color.Red, location = new PointEx(0, 0) });
                    }
                    return OperateStatus.Error;
                }
            }
            else
            {
                //没有图像源，则直接返回NG
                return OperateStatus.Error;
            }
            //获取模板信息
            HTuple row1Result = 0;
            HTuple column1Result = 0;
            HTuple row2Result = 0;
            HTuple column2Result = 0;
            if (ShapeModelSourceToolIDMark > 0)
            {
                ToolBase ibase = toolList.Where(x => x.ToolID == ShapeModelSourceToolIDMark).FirstOrDefault();
                HTuple hTuple = ToolParamHelper.GetParamValueByName<HTuple>(ibase, ShapeModelSourceParam);
                if (hTuple.Length > 0)
                {
                    HOperatorSet.AffineTransPoint2d(hTuple, Row1, Column1, out row1Result, out column1Result);
                    HOperatorSet.AffineTransPoint2d(hTuple, Row2, Column2, out row2Result, out column2Result);
                }
            }
            else
            {
                row1Result = Row1;
                column1Result = Column1;
                row2Result = Row2;
                column2Result = Column2;
            }
            //生成二位测量句柄
            HTuple hv_MetrologyHandle = new HTuple();

            //参数1
            HTuple param = new HTuple();
            param[0] = "num_measures";
            param[1] = "measure_select";
            param[2] = "measure_transition";
            //参数2
            HTuple paramValue = new HTuple();
            paramValue[0] = mMeasureNums;
            paramValue[1] = mMeasureSelect;
            paramValue[2] = mMeasureTransition;

            HOperatorSet.CountSeconds(out HTuple s1);
            HOperatorSet.GetImageSize(objFinal, out HTuple hv_Width, out HTuple hv_Height);//获取大小
            hv_MetrologyHandle.Dispose();
            HOperatorSet.CreateMetrologyModel(out hv_MetrologyHandle);//创建搜索模型
            HOperatorSet.SetMetrologyModelImageSize(hv_MetrologyHandle, hv_Width / 2, hv_Height / 2);//设置大小
            HOperatorSet.AddMetrologyObjectLineMeasure(hv_MetrologyHandle, row1Result, column1Result, row2Result, column2Result,//参数导入模型
                 mMeasureWidth, mMeasureHeight, 0.4, mMeasureThreshold, param, paramValue, out HTuple hv_Index);
            HOperatorSet.ApplyMetrologyModel(objFinal, hv_MetrologyHandle);//获取模型结果                                                                              
            HOperatorSet.GetMetrologyObjectResult(hv_MetrologyHandle, 0, "all", "result_type", "all_param", out HTuple hv_Parameter); //获取参数结果
            //轮廓
            HOperatorSet.GetMetrologyObjectResultContour(out HObject resultLine, hv_MetrologyHandle, 0, "all", 1.5);
            if (mIsShowResult)
            {
                if (mIsShowMeasureObj)
                {
                    HOperatorSet.GetMetrologyObjectMeasures(out HObject ho_Contours, hv_MetrologyHandle, "all", "all", out HTuple hv_Row, out HTuple hv_Column);//获取检测框
                    ShowRegionInfoItem infoItem = new ShowRegionInfoItem();
                    infoItem.region = ho_Contours.Clone();
                    infoItem.color = new ColorEx(System.Drawing.Color.Red);
                    infoItem.color.showType = ShowType.Xld;
                    infoItem.colorMode = 1;
                    DebugWind.ShowRegionList.Add(infoItem);
                    DebugWind.DebugWindow.HalconWindow.SetColored(12);
                    DebugWind.DebugWindow.HalconWindow.DispObj(ho_Contours);
                    ho_Contours.Dispose();
                    hv_Row.Dispose();
                    hv_Column.Dispose();
                }
            }
            if (resultLine.CountObj() < 1)
            {
                if (mIsShowResult)
                {
                    DebugWind.DebugWindow.HalconWindow.DispText("find line failed!", "window", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                    DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "find line failed!", color = System.Drawing.Color.Red, location = new PointEx(0, 0) });
                }
                resultLine.Dispose();
                hv_MetrologyHandle.Dispose();
                return OperateStatus.Error;
            }
            if (mIsShowResult)
            {
                //显示直线
                DebugWind.DebugWindow.HalconWindow.SetColor(mFindLineColor.color.RgbToHex());
                DebugWind.DebugWindow.HalconWindow.DispObj(resultLine);
                DebugWind.ShowRegionList.Add(new ShowRegionInfoItem() { region = resultLine.Clone(), color = new ColorEx(mFindLineColor.color), colorMode = 1 });

                //显示字符1
                DebugWind.DebugWindow.HalconWindow.DispText("find line success!", "window", 0, 0, mShowStringColor.color.RgbToHex(), (HTuple)"box", (HTuple)"false");
                DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "find line success!", color = mShowStringColor.color, location = new PointEx(0, 0) });

                //显示字符2
                string result = $"row1= {hv_Parameter[0].D.ToString("f1")}, column1= {hv_Parameter[1].D.ToString("f1")},row2= {hv_Parameter[2].D.ToString("f1")},column2= {hv_Parameter[3].D.ToString("f1")}";
                DebugWind.DebugWindow.HalconWindow.DispText(result, "window", 18, 0, mShowStringColor.color.RgbToHex(), (HTuple)"box", (HTuple)"false");
                DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = result, color = mShowStringColor.color, location = new PointEx(18, 0) });
            }

            HOperatorSet.CountSeconds(out HTuple s2);
            CostTime = (s2.D - s1.D) * 1000;

            mLineStartRow = hv_Parameter[0].D;
            mLineStartColumn = hv_Parameter[1].D;
            mLineEndRow = hv_Parameter[2].D;
            mLineEndColumn = hv_Parameter[3].D;
            mLineResult = new LineROI();
            mLineResult.RowStart1 = hv_Parameter[0].D;
            mLineResult.ColumnStart1 = hv_Parameter[1].D;
            mLineResult.RowEnd1 = hv_Parameter[2].D;
            mLineResult.ColumnEnd1 = hv_Parameter[3].D;
            hv_MetrologyHandle.Dispose();
            hv_Parameter.Dispose();
            return OperateStatus.OK;
        }

        public override void RefreshToolSource(List<ToolBase> toolList)
        {
            int res = -1;
            //若输入源
            if (ImageSourceToolIDMark > 0)
            {
                foreach (var item in toolList)
                {
                    //扫描到自己就跳出
                    if (item.Equals(this))
                        break;
                    //扫到输入源就跳出
                    if (item.ToolID == ImageSourceToolIDMark)
                    {
                        res = 1;
                        break;
                    }
                }
                if (res < 1)
                {
                    ImageSourceToolIDMark = -1;
                    ImageSourceParam = "";
                }
            }
            res = -1;
            //若输入源
            if (ShapeModelSourceToolIDMark > 0)
            {
                foreach (var item in toolList)
                {
                    //扫描到自己就跳出
                    if (item.Equals(this))
                        break;
                    //扫到输入源就跳出
                    if (item.ToolID == ShapeModelSourceToolIDMark)
                    {
                        res = 1;
                        break;
                    }
                }
                if (res < 1)
                {
                    ShapeModelSourceToolIDMark = -1;
                    ShapeModelSourceParam = "";
                }
            }
            res = -1;
            //若输入源
            if (LineSourceToolIDMark > 0)
            {
                foreach (var item in toolList)
                {
                    //扫描到自己就跳出
                    if (item.Equals(this))
                        break;
                    //扫到输入源就跳出
                    if (item.ToolID == LineSourceToolIDMark)
                    {
                        res = 1;
                        break;
                    }
                }
                if (res < 1)
                {
                    LineSourceToolIDMark = -1;
                    LineSourceParam = "";
                }
            }
        }
    }
}
