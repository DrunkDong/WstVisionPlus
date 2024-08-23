using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;
using Sunny.UI;
using WstCommonTools;

namespace WstVisionPlus
{
    public partial class FrmCommunicate : UIForm
    {
        public BindingList<SerialPortInfo> Info { get; set; }
        public FrmCommunicate()
        {
            InitializeComponent();

            Info = new BindingList<SerialPortInfo>();
            this.dataGridView_SerialPort.DataBindings.Add("DataSource", this, "Info", false);
        }

        private void FrmCommunicate_Load(object sender, EventArgs e)
        {
            InitDataGridView();
        }

        private void InitDataGridView()
        {
            dataGridView_SerialPort.AllowUserToAddRows = false;//禁止添加行
            dataGridView_SerialPort.AllowUserToResizeRows = false;//禁止调整行高
            dataGridView_SerialPort.AllowUserToDeleteRows = false;//禁止删除行
            dataGridView_SerialPort.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_SerialPort.RowsDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_SerialPort.RowTemplate.Height = 30;
            dataGridView_SerialPort.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //剔除第一列
            dataGridView_SerialPort.RowHeadersVisible = false;
            dataGridView_SerialPort.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_SerialPort.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView_SerialPort.Columns[0].Width = 120;

            for (int i = 0; i < dataGridView_SerialPort.Columns.Count; i++)
            {
                dataGridView_SerialPort.Columns[i].ReadOnly = true;
                dataGridView_SerialPort.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView_SerialPort.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView_SerialPort.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView_SerialPort.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dataGridView_SerialPort.DefaultCellStyle.SelectionForeColor = Color.FromArgb(48, 48, 48);
            dataGridView_SerialPort.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }


}
