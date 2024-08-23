using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WstControls
{
    [ToolboxItem(true)]
    public partial class UProcressBar : UserControl
    {
        public UProcressBar()
        {
            InitializeComponent();
        }

        private int val = 20;//进度值
        private Color PBackgroundColor = Color.FromArgb(217, 218, 219);//初始化颜色
        private Color PForegroundColor = Color.Green;

        [Description("背景色"), Category("自定义")]
        /// <summary>
        /// 背景色
        /// </summary>
        public Color pBackgroundColor
        {
            get => PBackgroundColor;
            set
            {
                PBackgroundColor = value;
                this.BackColor = PBackgroundColor;
            }
        }
        [Description("前景色"), Category("自定义")]
        /// <summary>
        /// 前景色
        /// </summary>
        public Color pForegroundColor
        {
            get => PForegroundColor;
            set => PForegroundColor = value;
        }
        [Description("当前值"), Category("自定义")]
        /// <summary>
        /// 当前值
        /// </summary>
        public int Value
        {
            get => val;
            set
            {
                val = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush brush = new SolidBrush(PForegroundColor);
            float percent = val / 100f;
            Rectangle rect = this.ClientRectangle;
            rect.Width = (int)((float)rect.Width * percent);
            rect.Height = this.Height;
            g.FillRectangle(brush, rect);
            brush.Dispose();
            g.Dispose();
        }
    }
}
