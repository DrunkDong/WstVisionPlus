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
    public partial class UTreeTools : UserControl
    {
        public UTreeTools()
        {
            InitializeComponent();
            treeView1.ImageList = imageList1;
            InitTreeView();
            treeView1.ExpandAll();
            treeView1.AllowDrop = true;
        }
        Dictionary<string, Bitmap> valueDic = new Dictionary<string, Bitmap>();

        private void InitTreeView()
        {
            TreeNode ImageNode1 = treeView1.Nodes.Add("", "Image Operation Tools", 0, 0);
            {
                ImageNode1.Nodes.Add("", "Image Convert", 1, 1);
                ImageNode1.Nodes.Add("", "Image Threshold", 2, 2);
                ImageNode1.Nodes.Add("", "Image Matching", 3, 3);

                valueDic.Add("Image Operation Tools", (Bitmap)imageList1.Images[0]);
                valueDic.Add("Image Convert", (Bitmap)imageList1.Images[1]);
                valueDic.Add("Image Threshold", (Bitmap)imageList1.Images[2]);
                valueDic.Add("Image Matching", (Bitmap)imageList1.Images[3]);
            }
            TreeNode ImageNode2 = treeView1.Nodes.Add("", "Lines and Circle", 4, 4);
            {
                ImageNode2.Nodes.Add("", "Find Line", 4, 4);
                ImageNode2.Nodes.Add("", "Find Circle", 5, 5);
                ImageNode2.Nodes.Add("", "If Else", 6, 6);
                ImageNode2.Nodes.Add("", "If", 7, 7);
                ImageNode2.Nodes.Add("", "Camera", 8, 8);

                valueDic.Add("Find Line", (Bitmap)imageList1.Images[0]);
                valueDic.Add("Find Circle", (Bitmap)imageList1.Images[1]);
            }
        }

        private void TreeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (treeView1.SelectedNode.Level == 0)          //工具箱层级不应该被拖动，直接返回
                return;
            if (e.Button.Equals(MouseButtons.Left))
            {
                TreeNode dragNode = e.Item as TreeNode;
                treeView1.DoDragDrop(dragNode, DragDropEffects.Move);
            }
        }

        private void TreeView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void TreeView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (sender != null && sender is TreeView)
                {
                    TreeView trv = sender as TreeView;
                    if (trv.Tag != null)
                    {
                        //MoveTreeView move = (MoveTreeView)Convert.ToInt32(trv.Tag);
                        //if (move == MoveTo) { DragNode = null; NodeSource = null; }
                        //else
                        //{
                        //    System.Drawing.Point point = trv.PointToClient(new System.Drawing.Point(e.X, e.Y));
                        //    TreeNode node = trv.GetNodeAt(point);
                        //    node.Nodes.Add(DragNode);
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex);
            }
        }

        private void TreeView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                TreeNode tn = treeView1.GetNodeAt(e.X, e.Y);
                if (tn != null)
                    treeView1.SelectedNode = tn;
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex);
            }
        }
    }
}
