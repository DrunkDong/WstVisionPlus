using WstCommonTools;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WstControls
{
    [Serializable]
    public class ShapeModelTool : ToolBase
    {
        double mCreateScaleMin;
        double mCreateScaleMax;
        int mCreateContrastLow;
        int mCreateContrastHigh;

        //create param
        public double CreateAngleStart;
        public double CreateAngleExtent;
        public int CreateNumLevels;
        public double CreateScaleMin
        {
            get { return mCreateScaleMin; }
            set
            {
                if (value >= 0.5 && value <= 2 && value <= mCreateScaleMax)
                {
                    mCreateScaleMin = value;
                }
            }
        }
        public double CreateScaleMax
        {
            get { return mCreateScaleMax; }
            set
            {
                if (value >= 0.5 && value <= 2 && value >= mCreateScaleMin)
                {
                    mCreateScaleMax = value;
                }
            }
        }
        public int CreateContrastLow
        {
            get { return mCreateContrastLow; }
            set
            {
                if (value >= 0 && value <= 255 && value <= mCreateContrastHigh)
                    mCreateContrastLow = value;
            }
        }
        public int CreateContrastHigh
        {
            get { return mCreateContrastHigh; }
            set
            {
                if (value >= 0 && value <= 255 && value > mCreateContrastLow)
                    mCreateContrastHigh = value;
            }
        }



        public HRegion SearchRegion;
        public ColorEx SearchRegionColor;

        public HRegion CreateRegion;
        public ColorEx CreateRegionColor;

        public ColorEx ShowStringColor;


        public HShapeModel SearchShapeModel;
        public HImage ShapeModelImage;

        public int CreateContrastSize;
        public string CreateMetric;
        public string CreateOptimization;


        //find param
        public int FindStartAngle;
        public int FindStartExtent;
        public double FindScoreMin;
        public int FindNums;
        public double FindGreediness;
        public double FindOverlap;
        public int FindTimeOut;

        //output params

        double mFindScores;
        double mFindRows;
        double mFindColumns;
        double mFindAngles;
        double mFindScale;
        HTuple mAffineMatrix;


        [ToolParamType(ParamType._double)]
        [ToolResult("FindScores")]
        public double FindScores
        {
            get => mFindScores;
            set => mFindScores = value;
        }

        [ToolParamType(ParamType._double)]
        [ToolResult("FindRows")]
        public double FindRows
        {
            get => mFindRows;
            set => mFindRows = value;
        }

        [ToolParamType(ParamType._double)]
        [ToolResult("FindColumns")]
        public double FindColumns
        {
            get => mFindColumns;
            set => mFindColumns = value;
        }

        [ToolParamType(ParamType._double)]
        [ToolResult("FindAngles")]
        public double FindAngles
        {
            get => mFindAngles;
            set => mFindAngles = value;
        }


        [ToolParamType(ParamType._double)]
        [ToolResult("FindScaleMaxs")]
        public double FindScale
        {
            get => mFindScale;
            set => mFindScale = value;
        }

        [ToolParamType(ParamType._tuple)]
        [ToolResult("AffineMatrix")]
        public HTuple AffineMatrix
        {
            get => mAffineMatrix;
            set => mAffineMatrix = value;
        }


        public ShapeModelTool()
        {
            //find param
            FindStartAngle = 0;
            FindStartExtent = 360;
            FindScoreMin = 0.5;
            FindNums = 1;
            FindGreediness = 0.5;
            FindOverlap = 0.5;
            FindTimeOut = 30;

            SearchRegion = new HRegion();
            SearchRegion.GenEmptyRegion();
            SearchRegionColor = new ColorEx(Color.Red);
            SearchRegionColor.showMode = ShowMode.Margin;

            CreateRegion = new HRegion();
            CreateRegion.GenEmptyRegion();
            CreateRegionColor = new ColorEx(Color.Magenta);
            CreateRegionColor.showMode = ShowMode.Margin;

            ShowStringColor = new ColorEx(Color.Blue);

            ShapeModelImage = null;
            Type = ToolType.ShapeModel;
            ResultType = ToolResultType.AlignData;

            mCreateScaleMin = 0;
            mCreateScaleMax = 360;
            mCreateContrastLow = 20;
            mCreateContrastHigh = 60;
            CreateAngleStart = 0;
            CreateAngleExtent = 360;
            CreateNumLevels = 7;
            CreateContrastSize = 30;
            CreateMetric = "use_polarity";
            CreateOptimization = "none";
        }

        public int DrawRoi1(HDebugWindow currWind, int type, string mRoiType, int mMarkSize, out HObject showRegion)
        {
            currWind.DebugWindow.HalconWindow.SetLineWidth(2);
            HOperatorSet.GenEmptyObj(out showRegion);
            try
            {
                int row, column, buttom;
                buttom = 0;
                row = -1;
                column = -1;
                while (buttom != 4)
                {
                    Application.DoEvents();
                    try
                    {
                        currWind.DebugWindow.HalconWindow.GetMposition(out row, out column, out buttom);
                    }
                    catch (System.Exception)
                    {
                        buttom = 0;
                    }
                    currWind.DebugWindow.HalconWindow.SetDraw("fill");
                    currWind.SetColorRgba(SearchRegionColor);
                    if (row > 0 && column > 0)
                    {
                        HObject obj;
                        HObject objshow;
                        if (mRoiType == "circle")
                        {
                            HOperatorSet.GenCircle(out obj, row, column, mMarkSize / 2);
                            HOperatorSet.GenCircleContourXld(out objshow, row, column, mMarkSize / 2, 0, 6.28318, "positive", 1);
                        }
                        else
                        {
                            HOperatorSet.GenRectangle1(out obj, row - mMarkSize / 2, column - mMarkSize / 2, row + mMarkSize / 2, column + mMarkSize / 2);
                            HOperatorSet.GenContourRegionXld(obj, out objshow, "border");
                        }

                        currWind.DebugWindow.HalconWindow.SetTposition(50, 50);
                        currWind.DebugWindow.HalconWindow.WriteString("");
                        HOperatorSet.SetSystem("flush_graphic", "false");
                        if (buttom == 1)
                        {
                            if (type == 0)
                            {
                                HObject ExpTmpOutVar_0;
                                HOperatorSet.Union2(SearchRegion, obj, out ExpTmpOutVar_0);
                                SearchRegion.Dispose();
                                HRegion r1 = new HRegion(ExpTmpOutVar_0);
                                SearchRegion = r1;
                            }
                            else
                            {
                                HObject ExpTmpOutVar_0;
                                HOperatorSet.Difference(SearchRegion, obj, out ExpTmpOutVar_0);
                                SearchRegion.Dispose();
                                HRegion r1 = new HRegion(ExpTmpOutVar_0);
                                SearchRegion = r1;
                            }
                        }
                        currWind.DebugWindow.HalconWindow.ClearWindow();
                        currWind.SetColorRgba(SearchRegionColor);
                        //ToolWind.DebugWindow.HalconWindow.DispObj(obj1);
                        currWind.DebugWindow.HalconWindow.DispObj(SearchRegion);
                        currWind.DebugWindow.HalconWindow.DispObj(objshow);
                        HOperatorSet.SetSystem("flush_graphic", "true");
                        currWind.DebugWindow.HalconWindow.SetTposition(50, 50);
                        currWind.DebugWindow.HalconWindow.WriteString("");

                        obj.Dispose();
                        objshow.Dispose();
                    }
                }
                currWind.DebugWindow.HalconWindow.ClearWindow();
                currWind.DebugWindow.HalconWindow.SetDraw("margin");
                currWind.SetColorRgba(SearchRegionColor);
                //ToolWind.DebugWindow.HalconWindow.DispObj(obj1);
                currWind.DebugWindow.HalconWindow.DispObj(SearchRegion);
                showRegion = SearchRegion;
                Thread.Sleep(1);
                return 0;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public int DrawRegion1(HDebugWindow currWind, string mRoiType, out HObject showRegion)
        {
            currWind.DebugWindow.HalconWindow.ClearWindow();
            currWind.DebugWindow.HalconWindow.SetDraw(SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
            currWind.DebugWindow.HalconWindow.SetLineWidth(2);
            currWind.SetColorRgba(SearchRegionColor);
            currWind.DebugWindow.HalconWindow.DispObj(SearchRegion);
            HOperatorSet.GenEmptyObj(out showRegion);
            try
            {
                if (mRoiType == "circle")
                {
                    double row, column, radius;
                    HObject obj;
                    currWind.DebugWindow.HalconWindow.DrawCircle(out row, out column, out radius);
                    HOperatorSet.GenCircle(out obj, row, column, radius);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(SearchRegion, obj, out temp);
                    showRegion = temp;
                    SearchRegion = new HRegion(temp);
                }
                else if (mRoiType == "rectangle1")
                {
                    double row, column, row2, column2;
                    HObject obj;
                    currWind.DebugWindow.HalconWindow.DrawRectangle1(out row, out column, out row2, out column2);
                    HOperatorSet.GenRectangle1(out obj, row, column, row2, column2);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(SearchRegion, obj, out temp);
                    showRegion = temp;
                    SearchRegion = new HRegion(temp);
                }
                else if (mRoiType == "rectangle2")
                {
                    double row, column, phi, length1, length2;
                    HObject obj;
                    currWind.DebugWindow.HalconWindow.DrawRectangle2(out row, out column, out phi, out length1, out length2);
                    HOperatorSet.GenRectangle2(out obj, row, column, phi, length1, length2);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(SearchRegion, obj, out temp);
                    showRegion = temp;
                    SearchRegion = new HRegion(temp);
                }
                else if (mRoiType == "ellipse")
                {
                    double row, column, phi, radius1, radius2;
                    HObject obj;
                    currWind.DebugWindow.HalconWindow.DrawEllipse(out row, out column, out phi, out radius1, out radius2);
                    HOperatorSet.GenEllipse(out obj, row, column, phi, radius1, radius2);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(SearchRegion, obj, out temp);
                    showRegion = temp;
                    SearchRegion = new HRegion(temp);
                }
                else if (mRoiType == "any")
                {
                    HRegion obj = currWind.DebugWindow.HalconWindow.DrawRegion();
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(SearchRegion, obj, out temp);
                    showRegion = temp;
                    SearchRegion = new HRegion(temp);
                }

                currWind.SetColorRgba(SearchRegionColor);
                currWind.DebugWindow.HalconWindow.ClearWindow();
                currWind.DebugWindow.HalconWindow.DispObj(SearchRegion);
                return 0;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public int DeleRoi1(HDebugWindow currWind)
        {
            SearchRegion.Dispose();
            SearchRegion.GenEmptyRegion();
            currWind.DebugWindow.HalconWindow.ClearWindow();
            return 0;
        }

        public int DrawRoi2(HDebugWindow currWind, int type, string mRoiType, int mMarkSize, out HObject showRegion)
        {
            currWind.DebugWindow.HalconWindow.SetLineWidth(2);
            HOperatorSet.GenEmptyObj(out showRegion);
            try
            {
                int row, column, buttom;
                buttom = 0;
                row = -1;
                column = -1;
                while (buttom != 4)
                {
                    Application.DoEvents();
                    try
                    {
                        currWind.DebugWindow.HalconWindow.GetMposition(out row, out column, out buttom);
                    }
                    catch (System.Exception)
                    {
                        buttom = 0;
                    }
                    currWind.DebugWindow.HalconWindow.SetDraw("fill");
                    currWind.SetColorRgba(CreateRegionColor);
                    if (row > 0 && column > 0)
                    {
                        HObject obj;
                        HObject objshow;
                        if (mRoiType == "circle")
                        {
                            HOperatorSet.GenCircle(out obj, row, column, mMarkSize / 2);
                            HOperatorSet.GenCircleContourXld(out objshow, row, column, mMarkSize / 2, 0, 6.28318, "positive", 1);
                        }
                        else
                        {
                            HOperatorSet.GenRectangle1(out obj, row - mMarkSize / 2, column - mMarkSize / 2, row + mMarkSize / 2, column + mMarkSize / 2);
                            HOperatorSet.GenContourRegionXld(obj, out objshow, "border");
                        }

                        currWind.DebugWindow.HalconWindow.SetTposition(50, 50);
                        currWind.DebugWindow.HalconWindow.WriteString("");
                        HOperatorSet.SetSystem("flush_graphic", "false");
                        if (buttom == 1)
                        {
                            if (type == 0)
                            {
                                HObject ExpTmpOutVar_0;
                                HOperatorSet.Union2(CreateRegion, obj, out ExpTmpOutVar_0);
                                CreateRegion.Dispose();
                                HRegion r1 = new HRegion(ExpTmpOutVar_0);
                                CreateRegion = r1;
                            }
                            else
                            {
                                HObject ExpTmpOutVar_0;
                                HOperatorSet.Difference(CreateRegion, obj, out ExpTmpOutVar_0);
                                CreateRegion.Dispose();
                                HRegion r1 = new HRegion(ExpTmpOutVar_0);
                                CreateRegion = r1;
                            }
                        }
                        currWind.DebugWindow.HalconWindow.ClearWindow();
                        currWind.SetColorRgba(CreateRegionColor);
                        //currWind.DebugWindow.HalconWindow.DispObj(obj1);
                        currWind.DebugWindow.HalconWindow.DispObj(CreateRegion);
                        currWind.DebugWindow.HalconWindow.DispObj(objshow);
                        HOperatorSet.SetSystem("flush_graphic", "true");
                        currWind.DebugWindow.HalconWindow.SetTposition(50, 50);
                        currWind.DebugWindow.HalconWindow.WriteString("");

                        obj.Dispose();
                        objshow.Dispose();
                    }
                }
                currWind.SetColorRgba(CreateRegionColor);
                //currWind.DebugWindow.HalconWindow.DispObj(obj1);
                currWind.DebugWindow.HalconWindow.DispObj(CreateRegion);
                showRegion = CreateRegion;
                Thread.Sleep(1);
                return 0;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public int DrawRegion2(HDebugWindow currWind, string mRoiType, out HObject showRegion)
        {
            currWind.DebugWindow.HalconWindow.ClearWindow();
            currWind.DebugWindow.HalconWindow.SetDraw(CreateRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
            currWind.SetColorRgba(CreateRegionColor);
            currWind.DebugWindow.HalconWindow.DispObj(CreateRegion);
            HOperatorSet.GenEmptyObj(out showRegion);
            try
            {
                if (mRoiType == "circle")
                {
                    double row, column, radius;
                    HObject obj;
                    currWind.DebugWindow.HalconWindow.DrawCircle(out row, out column, out radius);
                    HOperatorSet.GenCircle(out obj, row, column, radius);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(CreateRegion, obj, out temp);
                    showRegion = temp;
                    CreateRegion = new HRegion(temp);
                }
                else if (mRoiType == "rectangle1")
                {
                    double row, column, row2, column2;
                    HObject obj;
                    currWind.DebugWindow.HalconWindow.DrawRectangle1(out row, out column, out row2, out column2);
                    HOperatorSet.GenRectangle1(out obj, row, column, row2, column2);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(CreateRegion, obj, out temp);
                    showRegion = temp;
                    CreateRegion = new HRegion(temp);
                }
                else if (mRoiType == "rectangle2")
                {
                    double row, column, phi, length1, length2;
                    HObject obj;
                    currWind.DebugWindow.HalconWindow.DrawRectangle2(out row, out column, out phi, out length1, out length2);
                    HOperatorSet.GenRectangle2(out obj, row, column, phi, length1, length2);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(CreateRegion, obj, out temp);
                    showRegion = temp;
                    CreateRegion = new HRegion(temp);
                }
                else if (mRoiType == "ellipse")
                {
                    double row, column, phi, radius1, radius2;
                    HObject obj;
                    currWind.DebugWindow.HalconWindow.DrawEllipse(out row, out column, out phi, out radius1, out radius2);
                    HOperatorSet.GenEllipse(out obj, row, column, phi, radius1, radius2);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(CreateRegion, obj, out temp);
                    showRegion = temp;
                    CreateRegion = new HRegion(temp);
                }
                else if (mRoiType == "any")
                {
                    HRegion obj = currWind.DebugWindow.HalconWindow.DrawRegion();
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(CreateRegion, obj, out temp);
                    showRegion = temp;
                    CreateRegion = new HRegion(temp);
                }

                currWind.SetColorRgba(CreateRegionColor);
                currWind.DebugWindow.HalconWindow.ClearWindow();
                currWind.DebugWindow.HalconWindow.DispObj(CreateRegion);
                return 0;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public int DeleRoi2(HDebugWindow currWind)
        {
            CreateRegion.Dispose();
            CreateRegion.GenEmptyRegion();
            currWind.DebugWindow.HalconWindow.ClearWindow();
            return 0;
        }

        public override void ReleaseReslut()
        {
            mFindScores = 0;
            mFindRows = 0;
            mFindColumns = 0;
            mFindAngles = 0;
            mFindScale = 0;
            mAffineMatrix = new HTuple();
        }

        public override OperateStatus ToolRun(List<ToolBase> toolList, bool mIsShowResult)
        {
            System.Threading.Thread.Sleep(1000);
            try
            {
                CostTime = 0;
                HOperatorSet.CountSeconds(out HTuple s1);
                //检查所有区域
                if (SearchRegion.Area <= 0)
                {
                    if (mIsShowResult)
                    {
                        //初始化窗口和所有集合
                        DebugWind.ClearWindow();
                        DebugWind.ShowRegionList.Clear();
                        DebugWind.ShowStringInfoList.Clear();
                        DebugWind.DebugWindow.HalconWindow.SetLineWidth(2);
                        DebugWind.DebugWindow.HalconWindow.SetFont("Consolas-18");
                        DebugWind.DebugWindow.HalconWindow.DispText("Image matching SearchRegion is null!", "image", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                        DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "Image matching SearchRegion is null!", color = System.Drawing.Color.Red, location = new PointEx(0, 0) });
                    }
                    LogHelper.WriteExceptionLog("Image matching SearchRegion is null!");
                    return OperateStatus.Error;
                }
                if (SearchShapeModel == null)
                {
                    if (mIsShowResult)
                    {
                        //初始化窗口和所有集合
                        DebugWind.ClearWindow();
                        DebugWind.ShowRegionList.Clear();
                        DebugWind.ShowStringInfoList.Clear();
                        DebugWind.DebugWindow.HalconWindow.SetLineWidth(2);
                        DebugWind.DebugWindow.HalconWindow.SetFont("Consolas-18");
                        DebugWind.DebugWindow.HalconWindow.DispText("Image matching ShapeModel is null!", "image", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                        DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "Image matching ShapeModel is null!", color = System.Drawing.Color.Red, location = new PointEx(0, 0) });
                    }
                    DebugWind.DebugWindow.HalconWindow.DispText("Image matching ShapeModel is null!", "image", 0, 0, "red", (HTuple)"box", (HTuple)"false"); LogHelper.WriteExceptionLog("Image matching ShapeModel is null!");
                    return OperateStatus.Error;
                }
                HObject inFinalImage = null;
                if (ImageSourceToolIDMark > 0)
                {
                    ToolBase ibase = toolList.Where(x => x.ToolID == ImageSourceToolIDMark).FirstOrDefault();
                    inFinalImage = ToolParamHelper.GetParamValueByName<HObject>(ibase, ImageSourceParam);
                }
                else 
                {
                    //没有图像源，则直接返回NG
                    return OperateStatus.Error;
                }
                //判断图像输入源
                if (!HObjectHelper.ObjectValided(inFinalImage))
                {
                    if (mIsShowResult)
                    {
                        //初始化窗口和所有集合
                        DebugWind.ClearWindow();
                        DebugWind.ShowRegionList.Clear();
                        DebugWind.ShowStringInfoList.Clear();
                        DebugWind.DebugWindow.HalconWindow.SetLineWidth(2);
                        DebugWind.DebugWindow.HalconWindow.SetFont("Consolas-18");
                        DebugWind.DebugWindow.HalconWindow.DispText("ImageSource is null in ImageConvertTool!", "image", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                        DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "ImageSource is null in ImageConvertTool!", color = System.Drawing.Color.Red, location = new PointEx(0, 0) });
                    }
                    LogHelper.WriteExceptionLog("ImageSource is null in ImageConvertTool!");
                    HObjectHelper.ObjectValided(inFinalImage);
                    return OperateStatus.Error;
                }
                DebugWind.DispImage(inFinalImage);
                //运行
                HImage imageSource = new HImage(inFinalImage);
                SearchShapeModel.FindScaledShapeModel(imageSource, new HTuple(FindStartAngle).TupleRad().D,
                    new HTuple(FindStartExtent).TupleRad().D, (double)CreateScaleMin, (double)CreateScaleMax,
                    (HTuple)FindScoreMin, (int)FindNums, (double)FindOverlap, new HTuple("least_squares"), (new HTuple(7)).TupleConcat(3), (double)FindGreediness,
                    out HTuple row, out HTuple column, out HTuple angle, out HTuple scale, out HTuple score);
                HOperatorSet.CountSeconds(out HTuple s2);
                imageSource.Dispose();
                if (row.TupleLength() == 1)
                {
                    //添加平移、旋转
                    HOperatorSet.VectorAngleToRigid(CreateRegion.Row, CreateRegion.Column, 0, row, column, angle, out HTuple HomMat2D);
                    //添加缩放
                    HOperatorSet.HomMat2dIdentity(out HTuple HomMat4);
                    HOperatorSet.HomMat2dScale(HomMat2D, scale, scale, row, column, out HomMat4);
                    //写入值
                    FindRows = row[0].D;
                    FindColumns = column[0].D;
                    FindAngles = angle[0].D;
                    FindScores = score[0].D;
                    FindScale = scale[0].D;
                    AffineMatrix = HomMat4.Clone();

                    //显示
                    if (mIsShowResult)
                    {
                        //初始化窗口和所有集合
                        DebugWind.ClearWindow();
                        DebugWind.ShowRegionList.Clear();
                        DebugWind.ShowStringInfoList.Clear();
                        DebugWind.DebugWindow.HalconWindow.SetLineWidth(2);
                        DebugWind.DebugWindow.HalconWindow.SetFont("Consolas-18");

                        HObject affine1;
                        HObject affine2;
                        HTuple HomMat2D1, HomMat2D2, HomMat2D3;

                        //获取模板轮廓，中心点（0,0）
                        HXLDCont objXlds = SearchShapeModel.GetShapeModelContours(1);
                        HOperatorSet.HomMat2dIdentity(out HomMat2D1);
                        HOperatorSet.HomMat2dScale(HomMat2D1, scale, scale, 0, 0, out HomMat2D2);          //区域缩放
                        HOperatorSet.HomMat2dRotate(HomMat2D2, angle, 0, 0, out HomMat2D3);                //区域旋转
                        HOperatorSet.HomMat2dTranslate(HomMat2D3, row[0], column[0], out HomMat2D1);             //区域平移
                        //转换模板轮廓
                        HOperatorSet.AffineTransContourXld(objXlds, out affine1, HomMat2D1);
                        //转换创建区域
                        HOperatorSet.AffineTransRegion(CreateRegion, out affine2, HomMat4, "nearest_neighbor");

                        //搜索区域
                        DebugWind.DebugWindow.HalconWindow.SetDraw(SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                        DebugWind.SetColorRgba(SearchRegionColor);
                        DebugWind.DebugWindow.HalconWindow.DispObj(SearchRegion);
                        DebugWind.ShowRegionList.Add(new ShowRegionInfoItem() { region = SearchRegion.CopyObj(1, 1), color = SearchRegionColor });

                        //创建区域，矫正后的
                        DebugWind.DebugWindow.HalconWindow.SetDraw(CreateRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                        DebugWind.SetColorRgba(CreateRegionColor);
                        DebugWind.DebugWindow.HalconWindow.DispObj(affine2);
                        DebugWind.ShowRegionList.Add(new ShowRegionInfoItem() { region = affine2.Clone(), color = CreateRegionColor });

                        //模板轮廓
                        DebugWind.DebugWindow.HalconWindow.SetColored(12);
                        DebugWind.DebugWindow.HalconWindow.DispObj(affine1);
                        DebugWind.ShowRegionList.Add(new ShowRegionInfoItem() { region = affine1.Clone(), color = CreateRegionColor, colorMode = 1 });

                        //string类别显示,提示成功
                        DebugWind.DebugWindow.HalconWindow.DispText("find success！", "window", 0, 0, ShowStringColor.color.RgbToHex(), (HTuple)"box", (HTuple)"false");
                        DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "find success!", color = ShowStringColor.color, location = new PointEx(0, 0) });

                        //string类别显示,提示查找信息
                        string result =
                            "score=" + score[0].D.ToString("f3") +
                            ",row=" + row[0].D.ToString("f2") +
                            ",column=" + column[0].D.ToString("f2") +
                            ",angle=" + angle[0].D.ToString("f3") +
                            ",scale=" + scale[0].D.ToString("f3");
                        DebugWind.DebugWindow.HalconWindow.DispText(result, "window", 18, 0, ShowStringColor.color.RgbToHex(), (HTuple)"box", (HTuple)"false");
                        DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = result, color = ShowStringColor.color, location = new PointEx(18, 0) });
                        affine1.Dispose();
                        affine2.Dispose();

                    }
                    CostTime = (s2.D - s1.D) * 1000;
                    return OperateStatus.OK;
                }
                else
                {
                    CostTime = (s2.D - s1.D) * 1000;
                    if (mIsShowResult)
                    {
                        //初始化窗口和所有集合
                        DebugWind.ClearWindow();
                        DebugWind.ShowRegionList.Clear();
                        DebugWind.ShowStringInfoList.Clear();
                        DebugWind.DebugWindow.HalconWindow.SetLineWidth(2);
                        DebugWind.DebugWindow.HalconWindow.SetFont("Consolas-18");
                        //搜索区域
                        DebugWind.DebugWindow.HalconWindow.SetDraw(SearchRegionColor.showMode == ShowMode.Margin ? "margin" : "fill");
                        DebugWind.SetColorRgba(SearchRegionColor);
                        DebugWind.DebugWindow.HalconWindow.DispObj(SearchRegion);
                        //string类别显示
                        DebugWind.ShowStringInfoList.Clear();
                        DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "查找失败！", color = System.Drawing.Color.Red, location = new PointEx(0, 0) });
                        DebugWind.DebugWindow.HalconWindow.DispText("find fail!", "window", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                        DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "find fail!", color = System.Drawing.Color.Red, location = new PointEx(0, 0) });
                    }
                    return OperateStatus.Error;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("Image Matching is Error\r" + ex.Message);
                return OperateStatus.Error;
            }

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
            if (RegionSourceToolIDMark > 0)
            {
                foreach (var item in toolList)
                {
                    //扫描到自己就跳出
                    if (item.Equals(this))
                        break;
                    //扫到输入源就跳出
                    if (item.ToolID == RegionSourceToolIDMark)
                    {
                        res = 1;
                        break;
                    }
                }
                if (res < 1)
                {
                    RegionSourceToolIDMark = -1;
                    RegionSourceParam = "";
                }
            }
        }
    }
}
