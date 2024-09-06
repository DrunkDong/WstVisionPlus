using WstCommonTools;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WstControls
{
    [Serializable]
    public class ImageFindCircleTool : ToolBase
    {
        public ImageFindCircleTool()
        {
            Type = ToolType.FindCircle;
            ResultType = ToolResultType.circle;

            mMeasureWidth = 20;
            mMeasureHeight = 10;
            mMeasureNums = 10;
            mMeasureThreshold = 10;
            mMeasureSelect = "all";
            mMeasureTransition = "all";
            mIsShowMeasureObj = false;

            CircleSourceToolIDMark = -1;
            CircleSourceParam = "";

            mCricleShowColor = new ColorEx(System.Drawing.Color.Red);
            mCricleShowColor.showType = ShowType.contours;

            mFindCircleColor = new ColorEx(System.Drawing.Color.Red);
            mFindCircleColor.showType = ShowType.contours;

            mShowStringColor = new ColorEx(System.Drawing.Color.Red);
            mShowStringColor.showType = ShowType.contours;

            Row1 = 200;
            Column1 = 200;
            Radius1 = 100; ;

            mCircleResult = new CircleROI();
            mCircleRow = 0;
            mCircleColumn = 0;
            mCircleRadius = 0;
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
        public double Radius1;

        public ColorEx mCricleShowColor;
        public ColorEx mFindCircleColor;
        public ColorEx mShowStringColor;


        CircleROI mCircleResult;
        double mCircleRow;
        double mCircleColumn;
        double mCircleRadius;

        public int CircleSourceToolIDMark;
        public string CircleSourceParam;


        [ToolParamType(ParamType._line)]
        [ToolResult("CircleResult")]
        public CircleROI CircleResult
        {
            get => mCircleResult;
            set => mCircleResult = value;
        }

        [ToolParamType(ParamType._double)]
        [ToolResult("CircleRow")]
        public double CircleRow
        {
            get => mCircleRow;
            set => mCircleRow = value;
        }

        [ToolParamType(ParamType._double)]
        [ToolResult("CircleColumn")]
        public double CircleColumn
        {
            get => mCircleColumn;
            set => mCircleColumn = value;
        }

        [ToolParamType(ParamType._double)]
        [ToolResult("CircleRadius")]
        public double CircleRadius
        {
            get => mCircleRadius;
            set => mCircleRadius = value;
        }


        public override void ReleaseReslut()
        {
            mCircleResult = new CircleROI();
            mCircleRow = 0;
            mCircleColumn = 0;
            mCircleRadius = 0;
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
                //没有图像源，则直接返回NG
                return OperateStatus.Error;

            //获取模板信息
            HTuple row1Result = 0;
            HTuple column1Result = 0;
            HTuple radiusResult = 0;
            if (ShapeModelSourceToolIDMark > 0)
            {
                ToolBase ibase = toolList.Where(x => x.ToolID == ShapeModelSourceToolIDMark).FirstOrDefault();
                HTuple hTuple = ToolParamHelper.GetParamValueByName<HTuple>(ibase, ShapeModelSourceParam);
                if (hTuple.Length > 0)
                {
                    HOperatorSet.AffineTransPoint2d(hTuple, Row1, Column1, out row1Result, out column1Result);
                    radiusResult = Radius1;
                }
            }
            else
            {
                row1Result = Row1;
                column1Result = Column1;
                radiusResult = Radius1;
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
            HOperatorSet.AddMetrologyObjectCircleMeasure(hv_MetrologyHandle, row1Result, column1Result, radiusResult,//参数导入模型
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
                    DebugWind.DebugWindow.HalconWindow.DispText("find circle failed!", "window", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                    DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "find circle failed!", color = System.Drawing.Color.Red, location = new PointEx(0, 0) });
                }
                resultLine.Dispose();
                hv_MetrologyHandle.Dispose();
                return OperateStatus.Error;
            }
            if (mIsShowResult)
            {
                //显示直线
                DebugWind.DebugWindow.HalconWindow.SetColor(mFindCircleColor.color.RgbToHex());
                DebugWind.DebugWindow.HalconWindow.DispObj(resultLine);
                DebugWind.ShowRegionList.Add(new ShowRegionInfoItem() { region = resultLine.Clone(), color = new ColorEx(mFindCircleColor.color), colorMode = 1 });

                //显示字符1
                DebugWind.DebugWindow.HalconWindow.DispText("find circle success!", "window", 0, 0, mShowStringColor.color.RgbToHex(), (HTuple)"box", (HTuple)"false");
                DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "find circle success!", color = mShowStringColor.color, location = new PointEx(0, 0) });

                //显示字符2
                string result = $"row= {hv_Parameter[0].D.ToString("f1")}, column= {hv_Parameter[1].D.ToString("f1")},radius= {hv_Parameter[2].D.ToString("f1")}";
                DebugWind.DebugWindow.HalconWindow.DispText(result, "window", 18, 0, mShowStringColor.color.RgbToHex(), (HTuple)"box", (HTuple)"false");
                DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = result, color = mShowStringColor.color, location = new PointEx(18, 0) });
            }

            HOperatorSet.CountSeconds(out HTuple s2);
            CostTime = (s2.D - s1.D) * 1000;

            mCircleRow = hv_Parameter[0].D;
            mCircleColumn = hv_Parameter[1].D;
            mCircleRadius = hv_Parameter[2].D;

            mCircleResult = new CircleROI();
            mCircleResult.RowCenter = hv_Parameter[0].D;
            mCircleResult.ColumnCenter = hv_Parameter[1].D;
            mCircleResult.Radius = hv_Parameter[2].D;

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
            if (CircleSourceToolIDMark > 0)
            {
                foreach (var item in toolList)
                {
                    //扫描到自己就跳出
                    if (item.Equals(this))
                        break;
                    //扫到输入源就跳出
                    if (item.ToolID == CircleSourceToolIDMark)
                    {
                        res = 1;
                        break;
                    }
                }
                if (res < 1)
                {
                    CircleSourceToolIDMark = -1;
                    CircleSourceParam = "";
                }
            }
        }
    }
}
