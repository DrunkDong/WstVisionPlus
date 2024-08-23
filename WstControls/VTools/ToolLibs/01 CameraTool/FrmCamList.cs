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
using HalconDotNet;
using WstCommonTools;

namespace WstControls
{
    public partial class FrmCamList : UIForm
    {
        string mSelectCamera;
        DataTable info;
        List<CameraInfo> mCamInfoList = new List<CameraInfo>();
        public List<CameraInfo> CamInfoList
        {
            get => mCamInfoList;
            set => mCamInfoList = value;
        }
        public string SelectCamera
        {
            get => mSelectCamera;
            set => mSelectCamera = value;
        }

        public FrmCamList()
        {
            InitializeComponent();
        }
        private void Frm_Camera_Load(object sender, EventArgs e)
        {
            InitDataGridView();
            info.Rows.Clear();
            for (int i = 0; i < CamInfoList.Count; i++)
            {
                object[] obj = new object[5];
                obj[0] = i + 1;
                obj[1] = CamInfoList[i].CamType;
                obj[2] = CamInfoList[i].CamName;
                obj[3] = CamInfoList[i].CamSerialNumber;
                obj[4] = GetManufacturer(CamInfoList[i].CamManufacturerType);
                info.Rows.Add(obj);
            }
        }
        private void InitDataGridView()
        {
            info = new DataTable();
            info.Columns.Add("No", typeof(int));
            info.Columns.Add("Camera Type", typeof(string));
            info.Columns.Add("Camera Name", typeof(string));
            info.Columns.Add("Serial number", typeof(string));
            info.Columns.Add("Manufacturer", typeof(string));

            dataGridView_CamList.DataSource = info;
            dataGridView_CamList.AllowUserToAddRows = false;//禁止添加行
            dataGridView_CamList.AllowUserToResizeRows = false;//禁止调整行高
            dataGridView_CamList.AllowUserToDeleteRows = false;//禁止删除行
            dataGridView_CamList.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_CamList.RowsDefaultCellStyle.Font = new Font("微软雅黑", 12, FontStyle.Regular);
            dataGridView_CamList.RowTemplate.Height = 30;
            dataGridView_CamList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //剔除第一列
            dataGridView_CamList.RowHeadersVisible = false;
            //设置首行不可修改
            dataGridView_CamList.Columns[0].Width = 40;
            dataGridView_CamList.Columns[1].Width = 120;
            dataGridView_CamList.Columns[0].ReadOnly = true;
            dataGridView_CamList.Columns[1].ReadOnly = true;
            dataGridView_CamList.Columns[2].ReadOnly = true;
            dataGridView_CamList.Columns[3].ReadOnly = true;
            dataGridView_CamList.Columns[4].ReadOnly = true;
            //设置所有列不可排序
            dataGridView_CamList.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_CamList.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_CamList.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_CamList.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridView_CamList.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            dataGridView_CamList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private string GetManufacturer(CameraType ty)
        {
            if (ty == CameraType.CameraType_HiKang)
                return "Hikrobot";
            else if (ty == CameraType.CameraType_Daheng)
                return "Daheng Imaging";
            else
                return "";
        }

        private void uiSymbolButton_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void uiSymbolButton_OK_Click(object sender, EventArgs e)
        {
            if (dataGridView_CamList.Rows.Count > 0)
            {
                if (dataGridView_CamList.SelectedCells != null) 
                {
                    int selectedRowIndex = dataGridView_CamList.SelectedCells[0].RowIndex;
                    if (selectedRowIndex > -1) 
                    {
                        mSelectCamera = info.Rows[selectedRowIndex][3].ToString();
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
