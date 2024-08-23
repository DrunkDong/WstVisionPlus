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

namespace WstControls
{
    [ToolboxItem(false)]
    public partial class HShowWindow : UserControl
    {
        HSmartWindowControl window;
        bool mIsInit;
        HImage mCurrImage;
        int mImageHeight;
        int mImageWidth;

        public HWindow ShowWindow
        {
            get{ return Window.HalconWindow; }
        }

        public bool IsInit
        {
            get => mIsInit;
            set => mIsInit = value;
        }
        public HSmartWindowControl Window
        {
            get => window;
            set => window = value;
        }
        public HImage CurrImage
        {
            get => mCurrImage;
            set => mCurrImage = value;
        }

        public HShowWindow()
        {
            HOperatorSet.SetWindowAttr("background_color", "gray");
            InitializeComponent();
            mImageHeight = 0;
            mImageWidth = 0;
            mIsInit = false;
            window = new HSmartWindowControl();
            Window.Location = new Point(0, 0);
            Window.Dock = DockStyle.Fill;
            this.Controls.Add(Window);
            Window.MouseWheel += Window.HSmartWindowControl_MouseWheel;

        }

        public void ResetWindowSize(double ImageScale)
        {
            int Width, Height;
            double RealScale, ViewScale;
            int PanelX, PanelY;

            RealScale = ImageScale;
            ViewScale = (double)this.Height / this.Width;
            if (RealScale > ViewScale)//以宽为标准
            {
                Height = this.Height;
                Width = (int)(Height / RealScale);
                PanelX = (this.Width - Width) / 2;
                PanelY = 0;
            }
            else//以长为标准
            {
                Width = this.Width;
                Height = (int)(Width * RealScale);
                PanelX = 0;
                PanelY = (this.Height - Height) / 2;
            }
            Window.Parent = this;
            Window.Location = new Point(PanelX, PanelY);
            Window.Height = Height;
            Window.Width = Width;
            Window.HalconWindow.SetWindowExtents(0, 0, Width, Height);
        }

        public void DispObj(HObject obj)
        {
            if (obj != null && obj.IsInitialized()) 
            {
                CurrImage?.Dispose();
                CurrImage = new HImage(obj);
                ShowWindow.DispObj(obj);

                CurrImage.GetImageSize(out HTuple width, out HTuple height);
                if (mImageHeight != height.I || mImageWidth != width.I) 
                {
                    window.SetFullImagePart();
                    mImageHeight = height.I;
                    mImageWidth = width.I;
                }
            }
        }


        private void 自适应缩放ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Window.SetFullImagePart();
        }

        private void 保存图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mCurrImage == null || !mCurrImage.IsInitialized())
                return;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "BMP图像|*.bmp|所有文件|*.*";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(sfd.FileName))
                    return;
                mCurrImage.WriteImage("bmp", 0, sfd.FileName);
            }
        }
    }
}
