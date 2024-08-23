using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;

namespace WstControls
{
    public partial class FrmRemarks : UIForm
    {
        public FrmRemarks()
        {
            InitializeComponent();
        }

        string mRemarks;

        public string Remarks
        {
            get => mRemarks;
            set => mRemarks = value;
        }

        public FrmRemarks(string value)
        {
            InitializeComponent();

            Remarks = value;
            textBox1.Text = value;
            textBox1.Focus();
            ActiveControl = textBox1;
        }

        private void uiSymbolButton_OK_Click(object sender, EventArgs e)
        {
            mRemarks = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void uiSymbolButton_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
