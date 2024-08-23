using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WstCommonTools;

namespace WstControls
{
    public partial class UMessageListView : UserControl
    {
        public UMessageListView()
        {
            InitializeComponent();
        }
        private int numGreen = 0;
        private int numYellow = 0;
        private int numRed = 0;
        List<MessageListViewItem> mItemList = new List<MessageListViewItem>();
        object obj = new object();

        private void ToolStrip1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, toolStrip1.Width, toolStrip1.Height - 2);
            e.Graphics.SetClip(rect);
        }

        public void ClearList()
        {
            numGreen = 0;
            numRed = 0;
            numYellow = 0;
            this.listView1.Items.Clear();
            mItemList.Clear();
            toolStripButton_Info.Text = string.Format("Info({0})", numGreen);
            toolStripButton_Warnning.Text = string.Format("Warning({0})", numYellow);
            toolStripButton_Error.Text = string.Format("Error({0})", numRed);
        }

        private void UpdateCount()
        {
            toolStripButton_Info.Text = string.Format("Info({0})", numGreen);
            toolStripButton_Warnning.Text = string.Format("Warning({0})", numYellow);
            toolStripButton_Error.Text = string.Format("Error({0})", numRed);
        }

        private void 清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mItemList.Clear();
            listView1.Items.Clear();
            numGreen = 0;
            numRed = 0;
            numYellow = 0;
            UpdateCount();
        }

        private void ToolStripButton_Info_Click(object sender, EventArgs e)
        {
            if (toolStripButton_Info.Checked)
            {
                toolStripButton_Warnning.Checked = false;
                toolStripButton_Error.Checked = false;

                listView1.Items.Clear();
                for (int i = 0; i < mItemList.Count; i++)
                {
                    if (mItemList[i].color == Color.Black)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = (listView1.Items.Count + 1).ToString();
                        item.SubItems.Add(mItemList[i].time);
                        item.SubItems.Add(mItemList[i].msg);
                        item.ForeColor = mItemList[i].color;
                        listView1.Items.Add(item);
                        listView1.EnsureVisible(listView1.Items.Count - 1);
                    }
                }
            }
            else
            {
                listView1.Items.Clear();
                for (int i = 0; i < mItemList.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = (listView1.Items.Count + 1).ToString();
                    item.SubItems.Add(mItemList[i].time);
                    item.SubItems.Add(mItemList[i].msg);
                    item.ForeColor = mItemList[i].color;
                    listView1.Items.Add(item);
                    listView1.EnsureVisible(listView1.Items.Count - 1);
                }
            }
        }

        private void ToolStripButton_Warnning_Click(object sender, EventArgs e)
        {
            if (toolStripButton_Warnning.Checked)
            {
                toolStripButton_Info.Checked = false;
                toolStripButton_Error.Checked = false;

                listView1.Items.Clear();
                for (int i = 0; i < mItemList.Count; i++)
                {
                    if (mItemList[i].color == Color.Yellow)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = (listView1.Items.Count + 1).ToString();
                        item.SubItems.Add(mItemList[i].time);
                        item.SubItems.Add(mItemList[i].msg);
                        item.ForeColor = mItemList[i].color;
                        listView1.Items.Add(item);
                        listView1.EnsureVisible(listView1.Items.Count - 1);
                    }
                }
            }
            else
            {
                listView1.Items.Clear();
                for (int i = 0; i < mItemList.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = (listView1.Items.Count + 1).ToString();
                    item.SubItems.Add(mItemList[i].time);
                    item.SubItems.Add(mItemList[i].msg);
                    item.ForeColor = mItemList[i].color;
                    listView1.Items.Add(item);
                    listView1.EnsureVisible(listView1.Items.Count - 1);
                }
            }
        }

        private void ToolStripButton_Error_Click(object sender, EventArgs e)
        {
            if (toolStripButton_Error.Checked)
            {
                toolStripButton_Info.Checked = false;
                toolStripButton_Warnning.Checked = false;

                listView1.Items.Clear();
                for (int i = 0; i < mItemList.Count; i++)
                {
                    if (mItemList[i].color == Color.Red)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = (listView1.Items.Count + 1).ToString();
                        item.SubItems.Add(mItemList[i].time);
                        item.SubItems.Add(mItemList[i].msg);
                        item.ForeColor = mItemList[i].color;
                        listView1.Items.Add(item);
                        listView1.EnsureVisible(listView1.Items.Count - 1);
                    }
                }
            }
            else
            {
                listView1.Items.Clear();
                for (int i = 0; i < mItemList.Count; i++)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = (listView1.Items.Count + 1).ToString();
                    item.SubItems.Add(mItemList[i].time);
                    item.SubItems.Add(mItemList[i].msg);
                    item.ForeColor = mItemList[i].color;
                    listView1.Items.Add(item);
                    listView1.EnsureVisible(listView1.Items.Count - 1);
                }
            }
        }


        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="msg">信息内容</param>
        /// <param name="color">颜色显示</param>
        public void OutputMsg(string msg, Color color)
        {
            this.Invoke(new Action(() => 
            {
                try
                {
                    lock (obj)
                    {
                        if (msg == string.Empty)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = string.Empty;
                            item.SubItems.Add(msg);
                            item.ForeColor = color;
                            listView1.Items.Add(item);
                        }
                        else
                        {

                            if (color == Color.Yellow)
                                numYellow++;
                            else if (color == Color.Red)
                                numRed++;
                            else
                                numGreen++;

                            string time = DateTime.Now.ToString();

                            MessageListViewItem outputItem = new MessageListViewItem();
                            outputItem.msg = msg;
                            outputItem.color = color;
                            outputItem.time = time;

                            ListViewItem item = new ListViewItem();
                            item.Text = (listView1.Items.Count + 1).ToString();
                            item.SubItems.Add(time);
                            item.SubItems.Add(msg);
                            item.ForeColor = color;

                            listView1.Items.Add(item);
                            mItemList.Add(outputItem);
                            if (mItemList.Count > 1000)
                            {
                                if (mItemList[0].color == Color.Yellow)
                                    numYellow--;
                                else if (mItemList[0].color == Color.Red)
                                    numRed--;
                                else
                                    numGreen--;
                                mItemList.RemoveAt(0);
                            }
                            UpdateCount();
                            listView1.EnsureVisible(listView1.Items.Count - 1);
                        }
                        Application.DoEvents();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteExceptionLog(ex);
                }
            }));

        }

        public void OutputMsg(string msg)
        {
            this.Invoke(new Action(() =>
            {
                try
                {
                    lock (obj)
                    {
                        if (msg == string.Empty)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Text = string.Empty;
                            item.SubItems.Add(msg);
                            item.ForeColor = Color.Black;
                            listView1.Items.Add(item);
                        }
                        else
                        {
                            numGreen++;

                            string time = DateTime.Now.ToString();

                            MessageListViewItem outputItem = new MessageListViewItem();
                            outputItem.msg = msg;
                            outputItem.color = Color.Black;
                            outputItem.time = time;

                            ListViewItem item = new ListViewItem();
                            item.Text = (listView1.Items.Count + 1).ToString();
                            item.SubItems.Add(time);
                            item.SubItems.Add(msg);
                            item.ForeColor = Color.Black;

                            listView1.Items.Add(item);
                            mItemList.Add(outputItem);
                            if (mItemList.Count > 1000)
                            {
                                if (mItemList[0].color == Color.Yellow)
                                    numYellow--;
                                else if (mItemList[0].color == Color.Red)
                                    numRed--;
                                else
                                    numGreen--;
                                mItemList.RemoveAt(0);
                            }
                            UpdateCount();
                            listView1.EnsureVisible(listView1.Items.Count - 1);
                        }
                        Application.DoEvents();
                    }
                }
                catch (Exception ex)
                {
                    LogHelper.WriteExceptionLog(ex);
                }
            }));

        }

    }


    public struct MessageListViewItem
    {
        public string msg;
        public string time;
        public Color color;
    }
}
