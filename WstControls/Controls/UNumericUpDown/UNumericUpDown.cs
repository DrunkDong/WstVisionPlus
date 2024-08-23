using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WstControls
{
    public delegate void DValueChanged(double value);

    [DefaultProperty("ValueChanged")]
    public partial class UNumericUpDown : UserControl
    {
        public UNumericUpDown()
        {
            InitializeComponent();
            nud_value.Text = Value.ToString();
            btn_add.Click += btn_add_Click;
            btn_add.MouseEnter += btn_add_MouseEnter;
            btn_add.MouseLeave += btn_add_MouseLeave;
            btn_sub.Click += btn_sub_Click;
            btn_sub.MouseEnter += btn_sub_MouseEnter;
            btn_sub.MouseLeave += btn_sub_MouseLeave;
        }

        /// <summary>
        /// 值改变事件
        /// </summary>
        public event DValueChanged ValueChanged;
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

        /// <summary>
        /// 下划线颜色
        /// </summary>
        private Color _LineColor = Color.Gray;
        [Description("下划线颜色"), Category("自定义")]
        public Color LineColor
        {
            get => _LineColor;
            set
            {
                _LineColor = value;
                lbl_line.BackColor = value;
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
                btn_add.BackColor = value;
                btn_sub.BackColor = value;
                nud_value.BackColor = value;
                this.BackColor = value;
            } 
        }


        private void btn_add_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                btn_add.BringToFront();
                if (nud_value.Value < MaxValue)
                {
                    btn_add.FlatAppearance.MouseDownBackColor = Color.Gray;
                    btn_add.FlatAppearance.MouseOverBackColor = Color.DarkGray;
                    btn_add.Image = Properties.Resources.blueAdd;
                }
                else
                {
                    btn_add.FlatAppearance.MouseDownBackColor = Color.White;
                    btn_add.FlatAppearance.MouseOverBackColor = Color.White;
                }
            }
            catch { }
        }
        private void btn_sub_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                btn_sub.BringToFront();
                if (nud_value.Value >= MinValue)
                {
                    btn_sub.FlatAppearance.MouseDownBackColor = Color.Gray;
                    btn_sub.FlatAppearance.MouseOverBackColor = Color.DarkGray;
                    btn_sub.Image = Properties.Resources.blueSub;
                }
                else
                {
                    btn_sub.FlatAppearance.MouseDownBackColor = Color.White;
                    btn_sub.FlatAppearance.MouseOverBackColor = Color.White;
                }
            }
            catch { }
        }
        private void btn_add_MouseLeave(object sender, EventArgs e)
        {
            btn_add.Image = Properties.Resources.grayAdd;
        }
        private void btn_sub_MouseLeave(object sender, EventArgs e)
        {
            btn_sub.Image = Properties.Resources.graySub;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (nud_value.Value + Incremeent <= MaxValue)
                    nud_value.Text = (nud_value.Value + Incremeent).ToString();

                if (nud_value.Value >= MaxValue)
                {
                    btn_add.FlatAppearance.MouseDownBackColor = Color.White;
                    btn_add.FlatAppearance.MouseOverBackColor = Color.White;
                    btn_add.Image = Properties.Resources.grayAdd;
                }
            }
            catch { }
        }
        private void btn_sub_Click(object sender, EventArgs e)
        {
            try
            {
                if (nud_value.Value + Incremeent > MinValue)
                    nud_value.Text = (nud_value.Value - Incremeent).ToString();

                if (nud_value.Value <= MinValue)
                {
                    btn_sub.FlatAppearance.MouseDownBackColor = Color.White;
                    btn_sub.FlatAppearance.MouseOverBackColor = Color.White;
                    btn_sub.Image = Properties.Resources.graySub;
                }
            }
            catch { }
        }
        private void nud_value_ValueChanged(object sender, EventArgs e)
        {
            Value = (double)nud_value.Value;
            if (ValueChanged != null)
                ValueChanged(Value);
        }


    }
}
