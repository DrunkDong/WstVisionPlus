using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WstCommonTools;
using Sunny.UI;

namespace WstVisionPlus
{
    public partial class FrmUsers : UIForm
    {
        public FrmUsers()
        {
            InitializeComponent();
        }

        Machine mMachine;
        private void FrmUsers_Load(object sender, EventArgs e)
        {
            mMachine = Machine.GetInstance();
            //初始化
            InitDataGridView();
            ReadData();
        }

        private void DataGridView_UserList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;
            if (dataGridView.CurrentCell.GetType().Name == "DataGridViewComboBoxCell")
            {
                ComboBox comboBox = (ComboBox)e.Control;
                if (comboBox != null)
                {
                    comboBox.SelectedIndexChanged += comboBox_SelectedIndexChanged;
                }
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comboBox.Leave += combox_Leave;

            string name = dataGridView_UserList.CurrentRow.Cells[1].Value.ToString();
            string level = dataGridView_UserList.CurrentRow.Cells[3].Value.ToString();

            if (mMachine.UserAccessOp.UpdateUserLevel(name, level))
            {
                ShowSuccessTip("修改成功!");
            }

        }

        private void combox_Leave(object sender, EventArgs e)
        {
            ComboBox combox = sender as ComboBox;
            combox.SelectedIndexChanged -= comboBox_SelectedIndexChanged;

        }


        private void InitDataGridView()
        {
            dataGridView_UserList.AllowUserToAddRows = false;//禁止添加行
            dataGridView_UserList.AllowUserToResizeRows = false;//禁止调整行高
            dataGridView_UserList.AllowUserToDeleteRows = false;//禁止删除行
            dataGridView_UserList.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_UserList.RowsDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_UserList.RowTemplate.Height = 30;
            dataGridView_UserList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //剔除第一列
            dataGridView_UserList.RowHeadersVisible = false;
            dataGridView_UserList.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView_UserList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dataGridView_UserList.Columns[0].Width = 80;
            dataGridView_UserList.Columns[1].Width = 150;
            dataGridView_UserList.Columns[0].ReadOnly = true;
            dataGridView_UserList.Columns[1].ReadOnly = true;
            dataGridView_UserList.Columns[2].ReadOnly = true;
            //设置所有列不可排序
            dataGridView_UserList.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_UserList.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_UserList.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_UserList.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void ReadData()
        {
            DataTable info = mMachine.UserAccessOp.ReadAllData();
            for (int i = 0; i < info.Rows.Count; i++)
            {
                object[] obj = new object[4];
                obj[0] = (i + 1);
                obj[1] = info.Rows[i][0];
                obj[2] = info.Rows[i][1];
                obj[3] = info.Rows[i][2];
                dataGridView_UserList.Rows.Add(obj);
            }
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUserAdd frm = new FrmUserAdd();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                dataGridView_UserList.Rows.Clear();
                ReadData();
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_UserList.Rows.Count <= 0)
                return;
            if (dataGridView_UserList.Rows.Count == 1)
            {
                MessageBox.Show("列表只有一条用户数据，不可删除!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string name = dataGridView_UserList.CurrentRow.Cells[1].Value.ToString();
            if (MessageBox.Show("是否确定删除此条数据?", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            if (mMachine.UserAccessOp.DeleOneData(name))
            {
                dataGridView_UserList.Rows.Clear();
                ReadData();
                ShowSuccessTip("删除成功");
            }
        }
    }
}
