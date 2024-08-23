using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using WstCommonTools;
using System.Diagnostics.Eventing.Reader;

namespace WstControls
{
    [ToolboxItem(false)]
    public partial class HDebugWindow : UserControl
    {
        public HDebugWindow()
        {
            HOperatorSet.SetWindowAttr("background_color", "gray");
            InitializeComponent();
            mDebugWindow = new HWindowControl();
            mDebugWindow.Dock = DockStyle.Fill;
            mDebugWindow.Location = new Point(0, 0);
            this.panel1.Controls.Add(mDebugWindow);

            mDebugWindow.HMouseDown += DebugWindow_HMouseDown;
            mDebugWindow.HMouseMove += DebugWindow_HMouseMove;
            mDebugWindow.HMouseWheel += DebugWindow_HMouseWheel;
            mImageHeigt = 0;
            mImageWidth = 0;
            RowDown = 0;
            ColDown = 0;
            IsMove = false;
            IsDrawing = false;
            mScaleValue = 1;

            mShowRegionList = new List<ShowRegionInfoItem>();
            mShowStringInfoList = new List<ShowStringInfoItem>();
            mDebugWindow.HalconWindow.SetFont("Consolas-18");
        }

        HWindowControl mDebugWindow;
        HObject mCurrImage;
        HObject mShowImage;
        int mImageHeigt;
        int mImageWidth;
        double RowDown;//鼠标按下时的行坐标
        double ColDown;//鼠标按下时的列坐标

        bool mIsMove;
        bool mIsDrawing;
        double mScaleValue;

        List<ShowRegionInfoItem> mShowRegionList;
        List<ShowStringInfoItem> mShowStringInfoList;

        public HWindowControl DebugWindow
        {
            get => mDebugWindow;
            set => mDebugWindow = value;
        }
        public bool IsMove
        {
            get => mIsMove;
            set => mIsMove = value;
        }
        public bool IsDrawing
        {
            get => mIsDrawing;
            set => mIsDrawing = value;
        }

        /// <summary>
        /// 底图
        /// </summary>
        public HObject CurrImage
        {
            get => mCurrImage;
            set => mCurrImage = value;
        }
        /// <summary>
        /// 显示图
        /// </summary>
        public HObject ShowImage
        {
            get => mShowImage;
            set => mShowImage = value;
        }
        public List<ShowRegionInfoItem> ShowRegionList
        {
            get => mShowRegionList;
            set => mShowRegionList = value;
        }
        public List<ShowStringInfoItem> ShowStringInfoList
        {
            get => mShowStringInfoList;
            set => mShowStringInfoList = value;
        }

        private void DebugWindow_HMouseWheel(object sender, HMouseEventArgs e)
        {
            if (mCurrImage == null || !mCurrImage.IsInitialized())
                return;
            if (e.Delta > 0)
                ZoomImage(1);
            else
                ZoomImage(-1);

        }

        private void DebugWindow_HMouseMove(object sender, HMouseEventArgs e)
        {
            if (!IsMove)
                mDebugWindow.Cursor = Cursors.Arrow;
            else
                mDebugWindow.Cursor = Cursors.Hand;
            if (mCurrImage == null || !mCurrImage.IsInitialized())
                return;
            try
            {
                int row, colunm, button;
                mDebugWindow.HalconWindow.GetMposition(out row, out colunm, out button);
                HTuple mChannels;
                HOperatorSet.CountChannels(mCurrImage, out mChannels);
                HTuple width, height;
                HOperatorSet.GetImageSize(mCurrImage, out width, out height);
                if (mChannels > 0)
                {
                    HTuple val;
                    HOperatorSet.GetGrayval(mCurrImage, row, colunm, out val);
                    if (mChannels == 1)
                    {
                        toolStripStatusLabel_Row.Text = "Row=" + row;
                        toolStripStatusLabel_Column.Text = "Column=" + colunm;
                        toolStripStatusLabel_ImageSize.Text = "Size(" + width + "," + height + ")";
                        toolStripStatusLabel_ImageRGB.Text = "RGB(" + val + "," + val + "," + val + " )";
                    }
                    else
                    {
                        toolStripStatusLabel_Row.Text = "Row=" + row;
                        toolStripStatusLabel_Column.Text = "Column=" + colunm;
                        toolStripStatusLabel_ImageSize.Text = "Size(" + width + "," + height + ")";
                        toolStripStatusLabel_ImageRGB.Text = "RGB(" + val[0] + "," + val[1] + "," + val[2] + " )";
                    }
                }
                else
                {
                    toolStripStatusLabel_Row.Text = "Row=" + 0;
                    toolStripStatusLabel_Column.Text = "Column=" + 0;
                    toolStripStatusLabel_ImageSize.Text = "Size(" + 0 + "," + 0 + ")";
                    toolStripStatusLabel_ImageRGB.Text = "RGB(" + 0 + "," + 0 + "," + 0 + " )";
                }
            }
            catch (Exception)
            {

            }
            if (e.Button == MouseButtons.Left && IsMove)
            {
                try
                {
                    HTuple width, height;
                    HOperatorSet.GetImageSize(mCurrImage, out width, out height);

                    int Row, Column, Button;
                    mDebugWindow.HalconWindow.GetMposition(out Row, out Column, out Button);


                    HTuple row1, col1, row2, col2;
                    mDebugWindow.HalconWindow.GetPart(out row1, out col1, out row2, out col2);//得到当前的窗口坐标
                    double RowMove = (Row - RowDown) / 5;   //鼠标弹起时的行坐标减去按下时的行坐标，得到行坐标的移动值
                    double ColMove = (Column - ColDown) / 5;//鼠标弹起时的列坐标减去按下时的列坐标，得到列坐标的移动值

                    mDebugWindow.HalconWindow.SetPart(row1 - RowMove, col1 - ColMove, row2 - RowMove, col2 - ColMove);//这里可能有些不好理解。以左上角原点为参考点
                    //HOperatorSet.SetSystem("flush_graphic", "false");
                    mDebugWindow.HalconWindow.ClearWindow();
                    //显示背景图
                    //mDebugWindow.HalconWindow.DispObj(mCurrImage);
                    //HOperatorSet.SetSystem("flush_graphic", "true");
                    //mDebugWindow.HalconWindow.SetTposition(50, 50);
                    //mDebugWindow.HalconWindow.WriteString("");

                    //显示区域列表
                    mDebugWindow.HalconWindow.SetLineWidth(2);
                    for (int i = 0; i < mShowRegionList.Count; i++)
                    {
                        if (mShowRegionList[i].color.showMode == ShowMode.Margin)
                            mDebugWindow.HalconWindow.SetDraw("margin");
                        else
                            mDebugWindow.HalconWindow.SetDraw("fill");

                        if (mShowRegionList[i].region != null)
                        {
                            mDebugWindow.HalconWindow.SetColored(12);
                            mDebugWindow.HalconWindow.DispObj(mShowRegionList[i].region);
                        }
                        else
                        {
                            SetColorRgba(mShowRegionList[i].color);
                            if (mShowRegionList[i].region != null && new HRegion(mShowRegionList[i].region).Area > 0)
                                mDebugWindow.HalconWindow.DispObj(mShowRegionList[i].region);
                        }
                    }
                    mDebugWindow.HalconWindow.SetFont("Consolas-18");
                    for (int i = 0; i < mShowStringInfoList.Count; i++)
                    {
                        mDebugWindow.HalconWindow.DispText(
                            mShowStringInfoList[i].showMes,
                            "window",
                            mShowStringInfoList[i].location.X,
                            mShowStringInfoList[i].location.Y,
                            mShowStringInfoList[i].color.RgbToHex(),
                            (HTuple)"box",
                            (HTuple)"false");
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void DebugWindow_HMouseDown(object sender, HMouseEventArgs e)
        {
            if (!IsMove)
                mDebugWindow.Cursor = Cursors.Arrow;
            else
                mDebugWindow.Cursor = Cursors.Hand;
            if (mCurrImage == null || !mCurrImage.IsInitialized())
                return;
            try
            {
                int Row, Column, Button;
                mDebugWindow.HalconWindow.GetMposition(out Row, out Column, out Button);
                RowDown = Row;    //鼠标按下时的行坐标
                ColDown = Column; //鼠标按下时的列坐标
            }
            catch (Exception ex)
            {

            }
        }


        private void ZoomImage(double mode)
        {
            try
            {
                double Zoom;
                int Row, Col;
                int Button;
                HTuple Row0, Column0, Row00, Column00, Ht, Wt, r1, c1, r2, c2;
                if (mode > 0)
                {
                    Zoom = 1.1;
                    mScaleValue = mScaleValue * Zoom;
                    toolStripLabel_ZoomMes.Text = mScaleValue.ToString("p");
                }
                else
                {
                    Zoom = 0.9;
                    mScaleValue = mScaleValue * Zoom;
                    toolStripLabel_ZoomMes.Text = mScaleValue.ToString("p");
                }
                try
                {
                    mDebugWindow.HalconWindow.GetMposition(out Row, out Col, out Button);
                }
                catch (Exception)
                {
                    Row = mImageHeigt / 2;
                    Col = mImageWidth / 2;
                }
                mDebugWindow.HalconWindow.GetPart(out Row0, out Column0, out Row00, out Column00);
                Ht = Row00 - Row0;
                Wt = Column00 - Column0;
                if (Ht * Wt < 12000 * 12000 || Zoom == 1.1)//普通版halcon能处理的图像最大尺寸是32K*32K。如果无限缩小原图像，导致显示的图像超出限制，则会造成程序崩溃
                {
                    r1 = (Row0 + ((1 - (1.0 / Zoom)) * (Row - Row0)));
                    c1 = (Column0 + ((1 - (1.0 / Zoom)) * (Col - Column0)));
                    r2 = r1 + (Ht / Zoom);
                    c2 = c1 + (Wt / Zoom);
                    mDebugWindow.HalconWindow.SetPart(r1, c1, r2, c2);
                    mDebugWindow.HalconWindow.ClearWindow();
                    //显示区域列表
                    mDebugWindow.HalconWindow.SetLineWidth(2);
                    for (int i = 0; i < mShowRegionList.Count; i++)
                    {
                        if (mShowRegionList[i].color.showMode == ShowMode.Margin)
                            mDebugWindow.HalconWindow.SetDraw("margin");
                        else
                            mDebugWindow.HalconWindow.SetDraw("fill");

                        if (mShowRegionList[i].region != null)
                        {
                            if (mShowRegionList[i].color.showType == ShowType.Xld)  
                            {
                                mDebugWindow.HalconWindow.SetColored(12);
                                mDebugWindow.HalconWindow.DispObj(mShowRegionList[i].region);
                            }
                            else
                            {
                                mDebugWindow.HalconWindow.SetColor(mShowRegionList[i].color.color.RgbToHex());
                                mDebugWindow.HalconWindow.DispObj(mShowRegionList[i].region);
                            }

                        }
                        else
                        {
                            SetColorRgba(mShowRegionList[i].color);
                            if (mShowRegionList[i].region != null && new HRegion(mShowRegionList[i].region).Area > 0)
                                mDebugWindow.HalconWindow.DispObj(mShowRegionList[i].region);
                        }
                    }
                    mDebugWindow.HalconWindow.SetFont("Consolas-18");
                    for (int i = 0; i < mShowStringInfoList.Count; i++)
                    {
                        mDebugWindow.HalconWindow.DispText(
                            mShowStringInfoList[i].showMes,
                            "window",
                            mShowStringInfoList[i].location.X,
                            mShowStringInfoList[i].location.Y,
                            mShowStringInfoList[i].color.RgbToHex(),
                            (HTuple)"box",
                            (HTuple)"false"); ;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 显示图片类
        /// </summary>
        /// <param name="image"></param>
        public void DispImage(HObject image)
        {
            //判断图片源
            if (!HObjectHelper.ObjectValided(image)) return;
            HOperatorSet.SetSystem("flush_graphic", "false");
            HOperatorSet.GetImageSize(image, out HTuple width, out HTuple height);
            mDebugWindow.HalconWindow.SetPart(0, 0, -2, -2);
            HOperatorSet.CountSeconds(out HTuple s1);
            mDebugWindow.HalconWindow.AttachBackgroundToWindow(new HImage(image));
            HOperatorSet.SetSystem("flush_graphic", "true");
            HOperatorSet.CountSeconds(out HTuple s2);
            //Console.WriteLine(((s2 - s1) * 1000).ToString());
            mCurrImage = image.CopyObj(1, 1);
            if (mImageWidth != width.I || mImageHeigt != height.I)
            {
                mImageWidth = width.I;
                mImageHeigt = height.I;
                mDebugWindow.HalconWindow.SetPart(0, 0, -2, -2);
                //mDebugWindow.HalconWindow.ClearWindow();
                //mDebugWindow.HalconWindow.DispObj(image);
            }
        }
        public void DispShowImage(HObject processImage)
        {
            HOperatorSet.GetImageSize(processImage, out HTuple width, out HTuple height);
            mDebugWindow.HalconWindow.SetPart(0, 0, -2, -2);
            HOperatorSet.CountSeconds(out HTuple s1);
            mDebugWindow.HalconWindow.AttachBackgroundToWindow(new HImage(processImage));
            HOperatorSet.CountSeconds(out HTuple s2);
            Console.WriteLine(((s2 - s1) * 1000).ToString());
            mShowImage = processImage.CopyObj(1, 1);
            if (mImageWidth != width.I || mImageHeigt != height.I)
            {
                mImageWidth = width.I;
                mImageHeigt = height.I;
                mDebugWindow.HalconWindow.SetPart(0, 0, -2, -2);
                //mDebugWindow.HalconWindow.ClearWindow();
                //mDebugWindow.HalconWindow.DispObj(image);
            }
        }

        private void ToolStripButton_Arrow_Click(object sender, EventArgs e)
        {
            IsMove = false;
        }

        private void ToolStripButton_Hand_Click(object sender, EventArgs e)
        {
            IsMove = true;
        }

        private void ToolStripButton_ZoomImage_Click(object sender, EventArgs e)
        {
            if (mCurrImage == null || !mCurrImage.IsInitialized())
                return;
            RowDown = 0;
            ColDown = 0;
            mScaleValue = 1;
            toolStripLabel_ZoomMes.Text = "100%";
            mDebugWindow.HalconWindow.SetPart(0, 0, -2, -2);
            mDebugWindow.HalconWindow.ClearWindow();

            //显示区域列表
            mDebugWindow.HalconWindow.SetLineWidth(2);
            for (int i = 0; i < mShowRegionList.Count; i++)
            {
                if (mShowRegionList[i].color.showMode == ShowMode.Margin)
                    mDebugWindow.HalconWindow.SetDraw("margin");
                else
                    mDebugWindow.HalconWindow.SetDraw("fill");

                if (mShowRegionList[i].region != null)
                {
                    if (mShowRegionList[i].color.showType == ShowType.Xld)
                    {
                        mDebugWindow.HalconWindow.SetColored(12);
                        mDebugWindow.HalconWindow.DispObj(mShowRegionList[i].region);
                    }
                    else
                    {
                        mDebugWindow.HalconWindow.SetColor(mShowRegionList[i].color.color.RgbToHex());
                        mDebugWindow.HalconWindow.DispObj(mShowRegionList[i].region);
                    }

                }
                else
                {
                    SetColorRgba(mShowRegionList[i].color);
                    if (mShowRegionList[i].region != null && new HRegion(mShowRegionList[i].region).Area > 0)
                        mDebugWindow.HalconWindow.DispObj(mShowRegionList[i].region);
                }
            }
            mDebugWindow.HalconWindow.SetFont("Consolas-18");
            for (int i = 0; i < mShowStringInfoList.Count; i++)
            {
                mDebugWindow.HalconWindow.DispText(
                    mShowStringInfoList[i].showMes,
                    "window",
                    mShowStringInfoList[i].location.X,
                    mShowStringInfoList[i].location.Y,
                    mShowStringInfoList[i].color.RgbToHex(),
                    (HTuple)"box",
                    (HTuple)"false"); ;
            }

        }

        private void ToolStripButton_SaveImage_Click(object sender, EventArgs e)
        {
            if (mCurrImage == null || !mCurrImage.IsInitialized())
                return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP图像|*.bmp|所有文件|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(sfd.FileName))
                    return;
                new HImage(mCurrImage).WriteImage("bmp", 0, sfd.FileName);
            }
        }

        private void ToolStripButton_Add_Click(object sender, EventArgs e)
        {
            if (mCurrImage == null || !mCurrImage.IsInitialized())
                return;
            ZoomImage(1);
        }

        private void ToolStripButton_Reduce_Click(object sender, EventArgs e)
        {
            if (mCurrImage == null || !mCurrImage.IsInitialized())
                return;
            ZoomImage(-1);
        }


        /// <summary>
        /// 设置显示颜色
        /// </summary>
        /// <param name="color"></param>
        public void SetColorRgba(ColorEx col)
        {
            mDebugWindow.HalconWindow.SetRgba((int)col.color.R, col.color.G, col.color.B, col.color.A);
        }

        public void ClearWindow()
        {
            mDebugWindow.HalconWindow.ClearWindow();
            mShowRegionList.Clear();
            mShowStringInfoList.Clear();
        }
    }
    public class ShowRegionInfoItem
    {
        public HObject region;
        public ColorEx color;
        public int colorMode;

        public ShowRegionInfoItem()
        {
            region = new HObject();
            region.GenEmptyObj();
        }
    }
    public class ShowStringInfoItem
    {
        public string showMes;
        public Color color;
        public PointEx location;

        public ShowStringInfoItem()
        {
            showMes = "";
            color = Color.Red;
        }
    }
}
