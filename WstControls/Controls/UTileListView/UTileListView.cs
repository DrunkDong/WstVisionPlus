using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using WstCommonTools;

namespace WstControls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class UTileListView : UserControl, IContainerControl
    {
        public UTileListView()
        {
            InitializeComponent();
            label1.Height = 50;
            this.AllowDrop = true;
        }
        List<UListViewItem> itemsList = new List<UListViewItem>();

        [Description("标题文本"), Category("自定义")]
        public string TileName
        {
            get => label1.Text;
            set
            {
                label1.Text = value;
            }
        }
        [Description("标题背景颜色"), Category("自定义")]
        public Color TileBackColor
        {
            get => label1.BackColor;
            set
            {
                label1.BackColor = value;
            }
        }
        [Description("标题文本颜色"), Category("自定义")]
        public Color TileForeColor
        {
            get => label1.ForeColor;
            set
            {
                label1.ForeColor = value;
            }
        }
        [Description("标题文本字体"), Category("自定义")]
        public Font TileFont
        {
            get => label1.Font;
            set
            {
                label1.Font = value;
            }
        }
        [Description("标题高度"), Category("自定义")]
        public int TileHeight
        {
            get { return label1.Height; }
            set { label1.Height = value; }
        }

        private Font firstLabelFont = new Font("微软雅黑", 14F);
        [Description("序号字体"), Category("自定义")]
        public Font FirstLabelFont
        {
            get { return firstLabelFont; }
            set { firstLabelFont = value; }
        }

        private Color firstLabelForeColor = Color.Black;
        [Description("序号文本色"), Category("自定义")]
        public Color FirstLabelForeColor
        {
            get { return firstLabelForeColor; }
            set { firstLabelForeColor = value; }
        }

        private Font nameLabelFont = new Font("微软雅黑", 14F);
        [Description("工具名字体"), Category("自定义")]
        public Font NameLabelFont
        {
            get { return nameLabelFont; }
            set { nameLabelFont = value; }
        }

        private Color nameLabelForeColor = Color.FromArgb(255, 77, 59);
        [Description("工具名文本色"), Category("自定义")]
        public Color NameLabelForeColor
        {
            get { return nameLabelForeColor; }
            set { nameLabelForeColor = value; }
        }

        private Color itemBackColor = Color.White;
        [Description("Item背景色"), Category("自定义")]
        public Color ItemBackColor
        {
            get { return itemBackColor; }
            set { itemBackColor = value; }
        }

        private Color itemSelectedBackColor = Color.FromArgb(255, 77, 59);
        [Description("Item选中后的背景色"), Category("自定义")]
        public Color ItemSelectedBackColor
        {
            get { return itemSelectedBackColor; }
            set { itemSelectedBackColor = value; }
        }


        private Color itemSelectedForeColor = Color.White;
        [Description("Item选中后的文本颜色"), Category("自定义")]
        public Color ItemSelectedForeColor
        {
            get { return itemSelectedForeColor; }
            set { itemSelectedForeColor = value; }
        }

        private int itemHeight = 50;
        [Description("Item显示高度"), Category("自定义")]
        public int ItemHeight
        {
            get { return itemHeight; }
            set { itemHeight = value; }
        }

        private bool _autoSelectFirst = true;
        [Description("自动选中第一项"), Category("自定义")]
        public bool AutoSelectFirst
        {
            get { return _autoSelectFirst; }
            set { _autoSelectFirst = value; }
        }

        private Color splitLineColor = Color.FromArgb(238, 238, 238);
        [Description("分割线颜色"), Category("自定义"), Browsable(true)]
        public Color SplitLineColor
        {
            get { return splitLineColor; }
            set { splitLineColor = value; }
        }

        public delegate void ItemDoubleClickEvent(UListViewItem item, int index);
        public delegate void ItemClickEvent(UListViewItem index, int id);

        public event ItemDoubleClickEvent itemsDoubleClick;
        public event ItemClickEvent itemOnceClick;

       public Panel ShowPanel
        {
            get { return panel1; }
        }
        UListViewItem itemSelect = null;
        /// <summary>
        /// 当前选择项
        /// </summary>
        public UListViewItem ItemSelect
        {
            get { return itemSelect; }
            private set { itemSelect = value; }
        }
        //代码设计器不默认生成
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<UListViewItem> ItemsList
        {
            get => itemsList;
            set => itemsList = value;
        }

        private void RefreshItems()
        {
            this.SuspendLayout();
            this.panel1.Controls.Clear();
            if (itemSelect == null)
            {
                itemSelect = ItemsList[0];
                SelectItem(ItemsList[0]);
            }
            for (int i = ItemsList.Count - 1; i >= 0; i--)
            {
                UListViewItem item1 = ItemsList[i];
                item1.FirstLabelText = (i + 1).ToString();
                item1.NameLabelText = item1.NameLabelText;
                item1.SplitLineColor = this.SplitLineColor;
                item1.Height = ItemHeight;
                item1.Dock = DockStyle.Top;
                item1.ItemClick += (s, e) => { SelectItem((UListViewItem)s); };
                item1.ItemDoubleClick -= ItemsDoubleClick;
                item1.ItemDoubleClick += ItemsDoubleClick;
                panel1.Controls.Add(item1);
            }
            panel1.AutoScrollPosition = new Point(0, panel1.DisplayRectangle.Height);
            this.ResumeLayout(false);
        }
        private void SelectItem(UListViewItem li)
        {
            try
            {
                if (li != null)
                {
                    foreach (var item in ItemsList)
                    {
                        if (item != li)
                        {
                            item.ItemBackColor = ItemBackColor;
                        }
                        else
                        {
                            item.ItemBackColor = ItemSelectedBackColor;
                            ItemSelect = item;
                            int id = ItemsList.IndexOf(item);
                            itemOnceClick?.Invoke(item, id);
                        }

                    }
                }
            }
            catch { }
        }

        public void AddControl(UListViewItem li)
        {
            ItemsList.Add(li);
            RefreshItems();
        }

        public void RemoveControl() 
        {
            ItemsList.Remove(ItemSelect);
            RefreshItems();
        }

        private void ItemsDoubleClick(object sender, EventArgs e)
        {
            if (ItemSelect != null&& ItemSelect== sender as UListViewItem) 
            {
                int index = ItemsList.IndexOf(ItemSelect);
                itemsDoubleClick?.Invoke(ItemSelect, index);
            }
        }

        public void SwapItemList(int indexA, int indexB) 
        {
            ListHelper.Swap(ItemsList, indexA, indexB);
            RefreshItems();
        }

        public int GetCurrItemIndex() 
        {
            return ItemsList.IndexOf(ItemSelect);
        }
    }
}
