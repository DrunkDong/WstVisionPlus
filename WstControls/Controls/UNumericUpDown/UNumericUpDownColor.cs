using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WeiControls
{
    public delegate void UValueChanged(object sender, EventArgs e);
    [DefaultProperty("ValueChanged")]
    public partial class UNumericUpDownColor : UserControl
    {
        public UNumericUpDownColor()
        {
            InitializeComponent();
            nud_value.Text = Value.ToString();
        }



        /// <summary>
        /// 值改变事件
        /// </summary>
        public event UValueChanged ValueChanged;
        /// <summary>
        /// 单击的值变化量
        /// </summary>
        private decimal _incremeent = 1;
        [Description("单击的值变化量"), Category("自定义")]
        public decimal Incremeent
        {
            get { return _incremeent; }
            set { _incremeent = value; }
        }

        /// <summary>
        /// 值的小数位数
        /// </summary>
        private int _decimalPlaces = 0;
        [Description("值的小数位数"), Category("自定义")]
        public int DecimalPlaces
        {
            get { return _decimalPlaces; }
            set
            {
                _decimalPlaces = value;
                nud_value.DecimalPlaces = value;
            }
        }

        /// <summary>
        /// 最小值
        /// </summary>
        private decimal _minValue = 0;

        [Description("最小值"), Category("自定义")]
        public decimal MinValue
        {
            get { return _minValue; }
            set
            {
                _minValue = value;
                nud_value.Minimum = value;
            }
        }

        /// <summary>
        /// 最大值
        /// </summary>
        private decimal _maxValue = 100;

        [Description("最大值"), Category("自定义")]
        public decimal MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                nud_value.Maximum = value;
            }
        }

        /// <summary>
        /// 值
        /// </summary>
        private double _value = 0;

        [Description("当前值"), Category("自定义")]
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                nud_value.Text = value.ToString();
            }
        }

        private Color _AllBlackColor = Color.White;
        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color AllBlackColor
        {
            get => _AllBlackColor;
            set
            {
                _AllBlackColor = value;
                nud_value.BackColor = value;
                this.BackColor = value;
            }
        }
        Color _RectColor = Color.Black;
        [Description("边框颜色"), Category("自定义")]
        public Color RectColor
        {
            get => _RectColor;
            set => _RectColor = value;
        }

        private void nud_value_ValueChanged(object sender, EventArgs e)
        {
            Value = (double)nud_value.Value;
            if (ValueChanged != null)
                ValueChanged(sender, e);
        }

        private void UNumericUpDownColor_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                this.ClientRectangle,
                                _RectColor,//7f9db9
                                1,
                                ButtonBorderStyle.Solid,
                                _RectColor,
                                1,
                                ButtonBorderStyle.Solid,
                                _RectColor,
                                1,
                                ButtonBorderStyle.Solid,
                                _RectColor,
                                1,
                                ButtonBorderStyle.Solid);
        }
    }
}
