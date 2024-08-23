using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WstControls
{
    public class ToolTreeNode : TreeNode
    {
        //工具信息
        ToolInfo mToolInfo;
        //工具对象
        ToolBase mInnerTool;

        public ToolInfo ToolInfo
        {
            get => mToolInfo;
            set => mToolInfo = value;
        }
        public ToolBase InnerTool 
        { 
            get => mInnerTool; 
            set => mInnerTool = value;
        }
        public ToolTreeNode() 
        {

        }

        public ToolTreeNode(ToolBase tool) : base(tool.ShowName) 
        {
            mToolInfo = new ToolInfo();
            mToolInfo.ToolName = tool.ShowName;//名字
            mToolInfo.ToolID = tool.ToolID;//内部ID
            mToolInfo.ToolCurr = tool;
            mInnerTool = tool;//内部tool
        }
        public override object Clone()
        {
            ToolTreeNode node = (ToolTreeNode)base.Clone();
            node.ToolInfo = mToolInfo;
            node.InnerTool = mInnerTool;
            return node;
        }



        /// <summary>
        /// 绘制节点
        /// </summary>
        /// <param name="g">画布对象</param>
        /// <param name="node">节点</param>
        /// <param name="ItemWidth">显示的宽度</param>
        /// <param name="ItemHeight">显示的高度</param>
        /// <param name="mouseMoveNote">拖拽时鼠标停留的节点</param>
        /// <param name="mCurrRunNode">运作时，正在运行的步骤</param>
        /// <param name="mIsRun">是否正在运行</param>
        internal void PaintItems(Graphics g, TreeNode node, int ItemWidth, int ItemHeight, TreeNode mouseMoveNote,TreeNode mCurrRunNode,bool mIsRun)
        {
            TreeNode tn = node;
            if (tn == null || !tn.IsVisible)
                return;
            //GDI对象
            Graphics graphics = g;
            //指定为GDI单位为像素
            graphics.PageUnit = GraphicsUnit.Pixel;
            //消除锯齿
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //获取节点的剩余宽度
            int remain_width = ItemWidth - tn.Bounds.X;        
            //当前节点选中后的颜色
            Brush select_color = new SolidBrush(Color.FromArgb(217, 197, 230));
            //当前节点选中后的颜色
            Brush select_movecolor = new SolidBrush(Color.FromArgb(247, 227, 255));
            //其余未选中节点的颜色
            Brush back_color = new SolidBrush(Color.FromArgb(255, 255, 255));
            //当前运行节点的颜色
            Brush isRun_color = new SolidBrush(Color.FromArgb(255, 182, 193));
            //treeNode的重绘大小
            Rectangle bcrt = new Rectangle(tn.Bounds.X, tn.Bounds.Y, remain_width, tn.Bounds.Height - 1);
            //选定节点以及非选定节点的状态
            if (tn.IsSelected)
                graphics.FillRectangle(select_color, bcrt);
            else
                graphics.FillRectangle(back_color, bcrt);
            //拖拽时的效果
            if (mouseMoveNote != null)
            {
                if (tn == mouseMoveNote && !mouseMoveNote.IsSelected)
                {
                    graphics.FillRectangle(select_movecolor, bcrt);
                }
            }
            if (mCurrRunNode != null && mIsRun)
            {
                if (tn == mCurrRunNode) 
                {
                    graphics.FillRectangle(isRun_color, bcrt);
                }
            }
            //节点外框
            using (Pen focusPen = new Pen(Color.FromArgb(192, 192, 192)))
            {
                focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                graphics.DrawRectangle(focusPen, bcrt);
            }
            //画状态
            using (SolidBrush brush = new SolidBrush(Color.White))
            {
                graphics.DrawImage(Properties.Resources.OK, tn.Bounds.X + 45, tn.Bounds.Y + ((ItemHeight - 32) / 2));
            }
            //画索引
            using (Pen pen = new Pen(Color.Blue))
            {
                Font f = new Font("微软雅黑", 15, FontStyle.Regular);
                graphics.DrawString(mToolInfo.StepIndex.ToString(), f, pen.Brush, tn.Bounds.X + 3, tn.Bounds.Y + ((ItemHeight - 15) / 2 - 15 / 2));
            }
            //画工具ID
            using (Pen pen = new Pen(Color.Magenta))
            {
                Font f = new Font("微软雅黑", 10, FontStyle.Italic);
                graphics.DrawString(mToolInfo.ToolID.ToString(), f, pen.Brush, tn.Bounds.X + 35, tn.Bounds.Y + 2);
            }
            //画工具名称
            using (Pen pen = new Pen(Color.FromArgb(20, 66, 104)))
            {
                Font f = new Font("微软雅黑", 12.5f, FontStyle.Regular);
                graphics.DrawString(mToolInfo.ToolName, f, pen.Brush, tn.Bounds.X + 95, tn.Bounds.Y + 2);
            }
            //画注释
            using (Pen pen = new Pen(Color.FromArgb(70,70,70)))
            {
                Font f = new Font("微软雅黑", 9, FontStyle.Italic);
                SizeF stringSize = graphics.MeasureString("注释: ", f);
                graphics.DrawString("注释: " + mToolInfo.ToolRemarks, f, pen.Brush, tn.Bounds.X + 95, tn.Bounds.Y - stringSize.Height + ItemHeight);
            }
            //画耗时
            using (Pen pen = new Pen(Color.Black))
            {
                Font f = new Font("微软雅黑", 10, FontStyle.Italic);
                SizeF stringSize = graphics.MeasureString(mToolInfo.CostTime.ToString("f2") + "ms", f);
                graphics.DrawString(mToolInfo.CostTime.ToString("f2") + "ms", f, pen.Brush, tn.Bounds.X + remain_width - stringSize.Width - 20, tn.Bounds.Y + ((ItemHeight - stringSize.Height) / 2));
            }

        }
    }
}
