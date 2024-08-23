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
    public class ImageConvertTool : ToolBase
    {
        public ImageConvertTool()
        {
            TransMode = 0;
            TransString = "hsv";
            Type = ToolType.TransImage;
            ResultType = ToolResultType.Image;
            mImageGray = null;
            mImageRed = null;
            mImageGreen = null;
            mImageBlue = null;
            mImageResult1 = null;
            mImageResult2 = null;
            mImageResult3 = null;

        }

        public int TransMode;
        public string TransString;

        [NonSerialized]
        HObject mImageGray;
        [NonSerialized]
        HObject mImageRed;
        [NonSerialized]
        HObject mImageGreen;
        [NonSerialized]
        HObject mImageBlue;
        [NonSerialized]
        HObject mImageResult1;
        [NonSerialized]
        HObject mImageResult2;
        [NonSerialized]
        HObject mImageResult3;

        [ToolParamType(ParamType.image)]
        [ToolResult("ImageGray")]
        public HObject ImageGray
        {
            get => mImageGray;
            set => mImageGray = value;
        }

        [ToolParamType(ParamType.image)]
        [ToolResult("ImageRed")]
        public HObject ImageRed
        {
            get => mImageRed;
            set => mImageRed = value;
        }

        [ToolParamType(ParamType.image)]
        [ToolResult("ImageGreen")]
        public HObject ImageGreen
        {
            get => mImageGreen;
            set => mImageGreen = value;
        }

        [ToolParamType(ParamType.image)]
        [ToolResult("ImageBlue")]
        public HObject ImageBlue
        {
            get => mImageBlue;
            set => mImageBlue = value;
        }

        [ToolParamType(ParamType.image)]
        [ToolResult("ImageResult1")]
        public HObject ImageResult1
        {
            get => mImageResult1;
            set => mImageResult1 = value;
        }

        [ToolParamType(ParamType.image)]
        [ToolResult("ImageResult2")]
        public HObject ImageResult2
        {
            get => mImageResult2;
            set => mImageResult2 = value;
        }

        [ToolParamType(ParamType.image)]
        [ToolResult("ImageResult3")]
        public HObject ImageResult3
        {
            get => mImageResult3;
            set => mImageResult3 = value;
        }

        public int TransImage(HObject imageSource)
        {
            try
            {
                CostTime = 0;
                HObject temp = null;
                HOperatorSet.CountSeconds(out HTuple s1);
                if (TransMode == 1)
                {
                    HOperatorSet.Rgb1ToGray(imageSource, out mImageGray);
                    temp = mImageGray.CopyObj(1, 1);
                }
                HOperatorSet.CountChannels(imageSource, out HTuple channels);
                if (channels.I != 3 && TransMode > 0)
                {
                    throw new Exception("This image is not RGB");
                }
                if (TransMode == 2)
                {
                    HOperatorSet.Decompose3(imageSource, out mImageRed, out mImageGreen, out mImageBlue);
                    temp = mImageRed.CopyObj(1, 1);
                }
                else if (TransMode == 3)
                {
                    HOperatorSet.Decompose3(imageSource, out mImageRed, out mImageGreen, out mImageBlue);
                    temp = mImageGreen.CopyObj(1, 1);
                }
                else if (TransMode == 4)
                {
                    HOperatorSet.Decompose3(imageSource, out mImageRed, out mImageGreen, out mImageBlue);
                    temp = mImageBlue.CopyObj(1, 1);
                }
                else if (TransMode == 5)
                {
                    HOperatorSet.Decompose3(imageSource, out mImageRed, out mImageGreen, out mImageBlue);
                    HOperatorSet.TransFromRgb(mImageRed, mImageGreen, mImageBlue, out mImageResult1, out mImageResult2, out mImageResult3, TransString);
                    temp = mImageResult1.CopyObj(1, 1);
                }
                else if (TransMode == 6)
                {
                    HOperatorSet.Decompose3(imageSource, out mImageRed, out mImageGreen, out mImageBlue);
                    HOperatorSet.TransFromRgb(mImageRed, mImageGreen, mImageBlue, out mImageResult1, out mImageResult2, out mImageResult3, TransString);
                    temp = mImageResult2.CopyObj(1, 1);
                }
                else if (TransMode == 7)
                {
                    HOperatorSet.Decompose3(imageSource, out mImageRed, out mImageGreen, out mImageBlue);
                    HOperatorSet.TransFromRgb(mImageRed, mImageGreen, mImageBlue, out mImageResult1, out mImageResult2, out mImageResult3, TransString);
                    temp = mImageResult3.CopyObj(1, 1);
                }
                HOperatorSet.CountSeconds(out HTuple s2);
                CostTime = (s2.D - s1.D) * 1000;
                //显示
                if (HObjectHelper.ObjectValided(temp))
                    ToolWind.DispShowImage(temp);
                else
                    ToolWind.DispImage(imageSource);
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void ReleaseReslut()
        {
            HOperatorSet.GenEmptyObj(out mImageGray);
            HOperatorSet.GenEmptyObj(out mImageRed);
            HOperatorSet.GenEmptyObj(out mImageBlue);
            HOperatorSet.GenEmptyObj(out mImageResult1);
            HOperatorSet.GenEmptyObj(out mImageResult2);
            HOperatorSet.GenEmptyObj(out mImageResult3);
        }

        public override OperateStatus ToolRun(List<ToolBase> toolList, bool mIsShowResult)
        {
            try
            {

                //获取图像输入源
                CostTime = 0;
                HOperatorSet.CountSeconds(out HTuple s1);
                HObject inFinalImage = null;
                if (ImageSourceToolIDMark > 0)
                {
                    ToolBase ibase = toolList.Where(x => x.ToolID == ImageSourceToolIDMark).FirstOrDefault();
                    inFinalImage = ToolParamHelper.GetParamValueByName<HObject>(ibase, ImageSourceParam);
                }
                else
                    //没有图像源，则直接返回NG
                    return OperateStatus.Error;

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
                    LogHelper.WriteExceptionLog("ImageSource is null in ImageConvertTool");
                    return OperateStatus.Error;
                }

                //main code
                HObject temp = null;
                if (TransMode == 1)
                {
                    HOperatorSet.Rgb1ToGray(inFinalImage, out mImageGray);
                    temp = mImageGray.CopyObj(1, 1);
                }
                HOperatorSet.CountChannels(inFinalImage, out HTuple channels);
                if (channels.I != 3 && TransMode > 0)
                {
                    if (mIsShowResult)
                    {
                        //初始化窗口和所有集合
                        DebugWind.ClearWindow();
                        DebugWind.ShowRegionList.Clear();
                        DebugWind.ShowStringInfoList.Clear();
                        DebugWind.DebugWindow.HalconWindow.SetLineWidth(2);
                        DebugWind.DebugWindow.HalconWindow.SetFont("Consolas-18");
                        DebugWind.DebugWindow.HalconWindow.DispText("ImageConvert is Error. This image is not RGB!", "image", 0, 0, "red", (HTuple)"box", (HTuple)"false");
                        DebugWind.ShowStringInfoList.Add(new ShowStringInfoItem() { showMes = "ImageConvert is Error. This image is not RGB!", color = System.Drawing.Color.Red, location = new PointEx(0, 0) });
                    }
                    LogHelper.WriteExceptionLog("ImageConvert is Error. This image is not RGB");
                    return OperateStatus.Error;
                }
                if (TransMode == 2)
                {
                    HOperatorSet.Decompose3(inFinalImage, out mImageRed, out mImageGreen, out mImageBlue);
                    temp = mImageRed.CopyObj(1, 1);
                }
                else if (TransMode == 3)
                {
                    HOperatorSet.Decompose3(inFinalImage, out mImageRed, out mImageGreen, out mImageBlue);
                    temp = mImageGreen.CopyObj(1, 1);
                }
                else if (TransMode == 4)
                {
                    HOperatorSet.Decompose3(inFinalImage, out mImageRed, out mImageGreen, out mImageBlue);
                    temp = mImageBlue.CopyObj(1, 1);
                }
                else if (TransMode == 5)
                {
                    HOperatorSet.Decompose3(inFinalImage, out mImageRed, out mImageGreen, out mImageBlue);
                    HOperatorSet.TransFromRgb(mImageRed, mImageGreen, mImageBlue, out mImageResult1, out mImageResult2, out mImageResult3, TransString);
                    temp = mImageResult1.CopyObj(1, 1);
                }
                else if (TransMode == 6)
                {
                    HOperatorSet.Decompose3(inFinalImage, out mImageRed, out mImageGreen, out mImageBlue);
                    HOperatorSet.TransFromRgb(mImageRed, mImageGreen, mImageBlue, out mImageResult1, out mImageResult2, out mImageResult3, TransString);
                    temp = mImageResult2.CopyObj(1, 1);
                }
                else if (TransMode == 7)
                {
                    HOperatorSet.Decompose3(inFinalImage, out mImageRed, out mImageGreen, out mImageBlue);
                    HOperatorSet.TransFromRgb(mImageRed, mImageGreen, mImageBlue, out mImageResult1, out mImageResult2, out mImageResult3, TransString);
                    temp = mImageResult3.CopyObj(1, 1);
                }
                HOperatorSet.CountSeconds(out HTuple s2);
                //计时
                CostTime = (s2.D - s1.D) * 1000;
                //显示
                if (mIsShowResult)
                {
                    DebugWind.ClearWindow();
                    if (HObjectHelper.ObjectValided(temp))
                        DebugWind.DispShowImage(temp);
                    else
                        DebugWind.DispImage(inFinalImage);
                }
                return OperateStatus.OK;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog("ImageConvert is Error\r" + ex.Message);
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
        }
    }
}
