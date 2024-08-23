using WstCommonTools;
using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WstControls
{
    [Serializable]
    public class ImageBlobTool : ToolBase
    {
        public int MirrorMode;
        public int RotateValue;
        public bool IsTransImage;
        public int TransMode;
        public string TransString;

        public HRegion CheckRegion;
        public ColorEx CheckRegionColor;

        public ImageBlobTool()
        {
            IsTransImage = false;
            TransMode = 0;
            MirrorMode = 0;
            RotateValue = 0;
            TransString = "";
            CheckRegion = new HRegion();
            CheckRegion.GenEmptyRegion();
            CheckRegionColor = new ColorEx(System.Drawing.Color.Red);
            Type = ToolType.BlobImage;
        }


        public void TransImage(HObject imageSource)
        {
            HObject temp = null;
            try
            {
                HOperatorSet.CountSeconds(out HTuple s1);
                //通道变换
                if (IsTransImage)
                {
                    if (TransMode == 0)
                    {
                        temp = imageSource.CopyObj(1, 1);
                    }
                    if (TransMode == 1)
                    {
                        HOperatorSet.Rgb1ToGray(imageSource, out temp);
                    }
                    HOperatorSet.CountChannels(imageSource, out HTuple channels);
                    if (channels.I != 3)
                    {
                        return;
                    }
                    if (TransMode == 2)
                    {
                        HObject obj1, obj2;
                        HOperatorSet.Decompose3(imageSource, out temp, out obj1, out obj2);
                        obj1.Dispose();
                        obj2.Dispose();
                    }
                    else if (TransMode == 3)
                    {
                        HObject obj1, obj2;
                        HOperatorSet.Decompose3(imageSource, out obj1, out temp, out obj2);
                        obj1.Dispose();
                        obj2.Dispose();
                    }
                    else if (TransMode == 4)
                    {
                        HObject obj1, obj2;
                        HOperatorSet.Decompose3(imageSource, out obj1, out obj2, out temp);
                        obj1.Dispose();
                        obj2.Dispose();
                    }
                    else if (TransMode == 5)
                    {
                        HObject obj1, obj2, obj3, obj4, obj5;
                        HOperatorSet.Decompose3(imageSource, out obj1, out obj2, out obj3);
                        HOperatorSet.TransFromRgb(obj1, obj2, obj3, out temp, out obj4, out obj5, TransString);
                        obj1.Dispose();
                        obj2.Dispose();
                        obj3.Dispose();
                        obj4.Dispose();
                        obj5.Dispose();
                    }
                    else if (TransMode == 6)
                    {
                        HObject obj1, obj2, obj3, obj4, obj5;
                        HOperatorSet.Decompose3(imageSource, out obj1, out obj2, out obj3);
                        HOperatorSet.TransFromRgb(obj1, obj2, obj3, out obj4, out temp, out obj5, TransString);
                        obj1.Dispose();
                        obj2.Dispose();
                        obj3.Dispose();
                        obj4.Dispose();
                        obj5.Dispose();
                    }
                    else if (TransMode == 7)
                    {
                        HObject obj1, obj2, obj3, obj4, obj5;
                        HOperatorSet.Decompose3(imageSource, out obj1, out obj2, out obj3);
                        HOperatorSet.TransFromRgb(obj1, obj2, obj3, out obj4, out obj5, out temp, TransString);
                        obj1.Dispose();
                        obj2.Dispose();
                        obj3.Dispose();
                        obj4.Dispose();
                        obj5.Dispose();
                    }
                }
                //镜像
                //上一步有操作，temp不空
                if (MirrorMode > 0)
                {
                    if (temp != null)
                    {
                        HObject temp1 = null;
                        if (MirrorMode == 1)
                            HOperatorSet.MirrorImage(temp, out temp1, "row");
                        else if (MirrorMode == 2)
                            HOperatorSet.MirrorImage(temp, out temp1, "column");
                        else if (MirrorMode == 3)
                            HOperatorSet.MirrorImage(temp, out temp1, "diagonal");
                        //赋值
                        temp?.Dispose();
                        temp = temp1;

                    }
                    //上一步无操作，temp为空
                    else
                    {
                        HObject temp1 = null;
                        if (MirrorMode == 1)
                            HOperatorSet.MirrorImage(imageSource, out temp1, "row");
                        else if (MirrorMode == 2)
                            HOperatorSet.MirrorImage(imageSource, out temp1, "column");
                        else if (MirrorMode == 3)
                            HOperatorSet.MirrorImage(imageSource, out temp1, "diagonal");
                        temp = temp1;
                    }
                }
                //旋转
                //角度是否为0
                if (RotateValue != 0)
                {
                    HObject temp2;
                    if (temp != null)
                        HOperatorSet.RotateImage(temp, out temp2, RotateValue, "constant");
                    else
                        HOperatorSet.RotateImage(imageSource, out temp2, RotateValue, "constant");
                    temp?.Dispose();
                    temp = temp2;
                }
                HOperatorSet.CountSeconds(out HTuple s2);
                //显示
                if (temp != null)
                    ToolWind.DispShowImage(temp);
                else
                    ToolWind.DispImage(imageSource);
            }
            catch (Exception ex)
            {
            }
        }

        public int DrawRoi(int type, string mRoiType, int mMarkSize, out HObject showRegion)
        {
            ToolWind.DebugWindow.HalconWindow.SetLineWidth(2);
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
                        ToolWind.DebugWindow.HalconWindow.GetMposition(out row, out column, out buttom);
                    }
                    catch (System.Exception)
                    {
                        buttom = 0;
                    }
                    ToolWind.DebugWindow.HalconWindow.SetDraw("fill");
                    ToolWind.SetColorRgba(CheckRegionColor);
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

                        ToolWind.DebugWindow.HalconWindow.SetTposition(50, 50);
                        ToolWind.DebugWindow.HalconWindow.WriteString("");
                        HOperatorSet.SetSystem("flush_graphic", "false");
                        if (buttom == 1)
                        {
                            if (type == 0)
                            {
                                HObject ExpTmpOutVar_0;
                                HOperatorSet.Union2(CheckRegion, obj, out ExpTmpOutVar_0);
                                CheckRegion.Dispose();
                                HRegion r1 = new HRegion(ExpTmpOutVar_0);
                                CheckRegion = r1;
                            }
                            else
                            {
                                HObject ExpTmpOutVar_0;
                                HOperatorSet.Difference(CheckRegion, obj, out ExpTmpOutVar_0);
                                CheckRegion.Dispose();
                                HRegion r1 = new HRegion(ExpTmpOutVar_0);
                                CheckRegion = r1;
                            }
                        }
                        ToolWind.DebugWindow.HalconWindow.ClearWindow();
                        ToolWind.SetColorRgba(CheckRegionColor);
                        //ToolWind.DebugWindow.HalconWindow.DispObj(obj1);
                        ToolWind.DebugWindow.HalconWindow.DispObj(CheckRegion);
                        ToolWind.DebugWindow.HalconWindow.DispObj(objshow);
                        HOperatorSet.SetSystem("flush_graphic", "true");
                        ToolWind.DebugWindow.HalconWindow.SetTposition(50, 50);
                        ToolWind.DebugWindow.HalconWindow.WriteString("");

                        obj.Dispose();
                        objshow.Dispose();
                    }
                }
                ToolWind.DebugWindow.HalconWindow.SetDraw("fill");
                ToolWind.SetColorRgba(CheckRegionColor);
                //ToolWind.DebugWindow.HalconWindow.DispObj(obj1);
                ToolWind.DebugWindow.HalconWindow.DispObj(CheckRegion);
                showRegion = CheckRegion;
                Thread.Sleep(1);
                return 0;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public int DrawRoi2(HObject obj1, string mRoiType, out HObject showRegion)
        {
            ToolWind.DebugWindow.HalconWindow.ClearWindow();
            ToolWind.DebugWindow.HalconWindow.SetDraw("fill");
            ToolWind.DebugWindow.HalconWindow.SetRgba(255, 0, 0, 120);
            ToolWind.DebugWindow.HalconWindow.DispObj(CheckRegion);
            HOperatorSet.GenEmptyObj(out showRegion);
            try
            {
                if (mRoiType == "circle")
                {
                    double row, column, radius;
                    HObject obj;
                    ToolWind.DebugWindow.HalconWindow.DrawCircle(out row, out column, out radius);
                    HOperatorSet.GenCircle(out obj, row, column, radius);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(CheckRegion, obj, out temp);
                    showRegion = temp;
                    CheckRegion = new HRegion(temp);
                }
                else if (mRoiType == "rectangle1")
                {
                    double row, column, row2, column2;
                    HObject obj;
                    ToolWind.DebugWindow.HalconWindow.DrawRectangle1(out row, out column, out row2, out column2);
                    HOperatorSet.GenRectangle1(out obj, row, column, row2, column2);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(CheckRegion, obj, out temp);
                    showRegion = temp;
                    CheckRegion = new HRegion(temp);
                }
                else if (mRoiType == "rectangle2")
                {
                    double row, column, phi, length1, length2;
                    HObject obj;
                    ToolWind.DebugWindow.HalconWindow.DrawRectangle2(out row, out column, out phi, out length1, out length2);
                    HOperatorSet.GenRectangle2(out obj, row, column, phi, length1, length2);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(CheckRegion, obj, out temp);
                    showRegion = temp;
                    CheckRegion = new HRegion(temp);
                }
                else if (mRoiType == "ellipse")
                {
                    double row, column, phi, radius1, radius2;
                    HObject obj;
                    ToolWind.DebugWindow.HalconWindow.DrawEllipse(out row, out column, out phi, out radius1, out radius2);
                    HOperatorSet.GenEllipse(out obj, row, column, phi, radius1, radius2);
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(CheckRegion, obj, out temp);
                    showRegion = temp;
                    CheckRegion = new HRegion(temp);
                }
                else if (mRoiType == "any")
                {
                    HRegion obj = ToolWind.DebugWindow.HalconWindow.DrawRegion();
                    HObject temp = new HObject();
                    temp.GenEmptyObj();
                    HOperatorSet.Union2(CheckRegion, obj, out temp);
                    showRegion = temp;
                    CheckRegion = new HRegion(temp);
                }

                ToolWind.DebugWindow.HalconWindow.SetRgba(255, 0, 0, 120);
                ToolWind.DebugWindow.HalconWindow.ClearWindow();
                ToolWind.DebugWindow.HalconWindow.DispObj(CheckRegion);
                return 0;
            }
            catch (System.Exception ex)
            {
                return -1;
            }
        }

        public int DeleRoi()
        {
            CheckRegion.Dispose();
            CheckRegion.GenEmptyRegion();
            ToolWind.DebugWindow.HalconWindow.ClearWindow();
            return 0;
        }
    }
}
