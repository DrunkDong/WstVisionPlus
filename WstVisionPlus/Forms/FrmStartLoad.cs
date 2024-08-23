using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WstControls;

namespace WstVisionPlus
{
    public partial class FrmStartLoad : Form
    {
        public FrmStartLoad()
        {
            InitializeComponent();
        }

        public void SetValue(int value, string text)
        {
            label1.Text = value + "%  " + text;
            uProcressBar1.Value = value;
            this.Invalidate();
        }
    }
}
