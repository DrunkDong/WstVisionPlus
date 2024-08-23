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
    [ToolboxItem(false)]
    public partial class UListViewItem : UserControl
    {
        public UListViewItem()
        {
            InitializeComponent();
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            this.UpdateStyles();

            label_Cost.DoubleClick += DoubleLabelClick;
            label_First.DoubleClick += DoubleLabelClick;
            label_Name.DoubleClick += DoubleLabelClick;
            label_State.DoubleClick += DoubleLabelClick;
            label_ToolInnerID.DoubleClick += DoubleLabelClick;

            label_Cost.MouseClick += Label_State_Click;
            label_First.MouseClick += Label_State_Click;
            label_Name.MouseClick += Label_State_Click;
            label_State.MouseClick += Label_State_Click;
            label_ToolInnerID.MouseClick += Label_State_Click;
        }

        public event MouseEventHandler ItemClick;
        public event EventHandler ItemDoubleClick;

        public string FirstLabelText
        {
            get { return label_First.Text; }
            set { label_First.Text = value; }
        }

        public string NameLabelText
        {
            get { return label_Name.Text; }
            set { label_Name.Text = value; }
        }
        public string LabelInnerID 
        {
            get { return label_ToolInnerID.Text; }
            set { label_ToolInnerID.Text = value; }
        }

        Color itemBackColor = Color.White;
        public Color ItemBackColor
        {
            get { return itemBackColor; }
            set
            {
                itemBackColor = value;
                label_First.BackColor = value;
                label_Cost.BackColor = value;
                label_Name.BackColor = value;
                label_State.BackColor = value;
                this.BackColor = value;
            }
        }
        Color itemForeColor = Color.Black;
        public Color ItemForeColor
        {
            get { return itemForeColor; }
            set
            {
                itemForeColor = value;
                label_First.ForeColor = value;
                label_Cost.ForeColor = value;
                label_Name.ForeColor = value;
                label_State.ForeColor = value;
            }
        }
        public void SetLabelColors(Color color)
        {
            label_Cost.BackColor = color;
            label_First.BackColor = color;
            label_Name.BackColor = color;
            label_State.BackColor = color;
            this.BackColor = color;
        }

        Color splitLineColor = Color.Black;
        public Color SplitLineColor { get => splitLineColor; set => uSplitLineH1.BackColor = value; }

        public void SetName(string str)
        {
            label_Name.Text = str;
        }
        public void SetState(bool state)
        {
            this.Invoke(new Action(() =>
            {
                if (state)
                    label_State.Image = Properties.Resources.OK;
                else
                    label_State.Image = Properties.Resources.NG;
            }));
        }
        public void SetCostTime(double cost)
        {
            this.Invoke(new Action(() =>
            {
                label_Cost.Text = cost.ToString("f2") + " ms";
            }));
        }

        public void SetInnerID(int mark) 
        {
            label_ToolInnerID.Text = mark.ToString();
        }

        private void Label_State_Click(object sender, MouseEventArgs e)
        {
            ItemClick?.Invoke(this, e);
        }

        private void DoubleLabelClick(object sender, EventArgs e)
        {
            ItemDoubleClick?.Invoke(this, e);
        }

        public void SetPictureBoxShow(bool isShow) 
        {
            pictureBox1.Visible = isShow;
        }
    }
}
