using gCursorLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;


namespace WstControls
{
    public partial class UToolTreeView : UserControl
    {
        public event EventHandler NodeSelected;
        public event EventHandler NodeDoubleClick;
        public event EventHandler NodeDeleClick;

        TreeView toolView;
        List<ToolBase> mToolList;
        List<ToolInfo> mToolInfoList;

        bool mMouseDown = false;//鼠标是否被按下
        object lockObj = new object();//拖拽锁
        ToolTreeNode mouseMoveNode = null;//拖拽时鼠标停留的节点
        ToolTreeNode mSelectNode = null;//被选定的节点


        bool mIsToolRunning = false;//运行标志位
        ToolTreeNode mCurrRunStepNode = null;//当前运行的节点


        public UToolTreeView()
        {
            InitializeComponent();

            toolView = new TreeView();
            toolView.AllowDrop = true;
            toolView.Parent = this;
            toolView.Dock = DockStyle.Fill;
            toolView.ItemHeight = 46;
            toolView.ShowNodeToolTips = false;
            toolView.DrawMode = TreeViewDrawMode.OwnerDrawText;

            toolView.DrawNode += DrawNode;
            toolView.MouseDown += OnMouseDown;
            toolView.MouseMove += OnMouseMove;
            toolView.MouseUp += OnMouseUp;
            toolView.ItemDrag += toolView_ItemDrag;
            toolView.DragEnter += toolView_DragEnter;
            toolView.DragDrop += toolView_DragDrop;
            toolView.DragOver += toolView_DragOver;
            toolView.NodeMouseDoubleClick += toolView_NodeMouseDoubleClick;

            toolView.ContextMenuStrip = contextMenuStrip1;

            mToolList = new List<ToolBase>();
            mToolInfoList = new List<ToolInfo>();
        }

        private void toolView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (toolView.SelectedNode != null) 
            {
                NodeDoubleClick?.Invoke(toolView.SelectedNode, e);
            }
        }


        //代码设计器不默认生成
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //工具列表
        public List<ToolBase> ToolList
        {
            get => mToolList;
            set => mToolList = value;
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TreeNodeCollection Nodes
        {
            get
            {
                return toolView.Nodes;
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public List<ToolInfo> ToolInfoList
        {
            get => mToolInfoList;
            set => mToolInfoList = value;
        }
        public ToolTreeNode SelectNode 
        {
            get 
            {
                if (toolView.SelectedNode != null)
                {
                    mSelectNode = (ToolTreeNode)toolView.SelectedNode;
                    return mSelectNode;
                }
                else
                    return null;
                
            }
            set 
            { 
                mSelectNode = value;
                toolView.SelectedNode = mSelectNode;
            }
        }

        public bool IsToolRunning
        {
            get => mIsToolRunning;
            set => mIsToolRunning = value;
        }
        public ToolTreeNode CurrRunStepNode
        {
            get => mCurrRunStepNode;
            set => mCurrRunStepNode = value;
        }
        private void DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            ToolTreeNode note = (ToolTreeNode)e.Node;
            Graphics graphics = e.Graphics;
            if (toolView.Scrollable)
                note.PaintItems(graphics, note, toolView.Width - 20, toolView.ItemHeight, mouseMoveNode, CurrRunStepNode, IsToolRunning);
            else
                note.PaintItems(graphics, note, toolView.Width - 10, toolView.ItemHeight, mouseMoveNode, CurrRunStepNode, IsToolRunning);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = toolView.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                mMouseDown = true;
                toolView.SelectedNode = node;
                NodeSelected?.Invoke(node, e);
                gCursor1.gText = ((ToolTreeNode)toolView.SelectedNode).ToolInfo.ToolName;
                gCursor1.gEffect = gCursor.eEffect.Move;
                gCursor1.gType = gCursor.eType.Both;
                gCursor1.MakeCursor();
                //toolView_ItemDrag(sender, new ItemDragEventArgs(e.Button, node));
            }
            else
            {
                mouseMoveNode = null;
                Invalidate();
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            //当鼠标按下的时
            if (mMouseDown)
            {
                TreeNode node = toolView.GetNodeAt(e.X, e.Y);
                if (node != null)
                    mouseMoveNode = (ToolTreeNode)node;
                else
                    mouseMoveNode = null;
                Invalidate();//进入刷新DrawNode
            }
            else
            {
                mouseMoveNode = null;
                Invalidate();//进入刷新DrawNode
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            mMouseDown = false;
            mouseMoveNode = null;
            Invalidate();//刷新UI
        }

        private void toolView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void toolView_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void toolView_DragOver(object sender, DragEventArgs e)
        {
            mMouseDown = true;
            Point p = new Point(e.X, e.Y);
            Point curr = PointToClient(p);
            MouseEventArgs mMoseArgs = new MouseEventArgs(MouseButtons, 0, curr.X, curr.Y, 0);
            OnMouseMove(sender, mMoseArgs);
        }

        private void toolView_DragDrop(object sender, DragEventArgs e)
        {
            lock (lockObj)
            {
                ToolTreeNode moveNode = (ToolTreeNode)(e.Data.GetData(typeof(ToolTreeNode)));
                //不等于null，本地拖动
                if (moveNode != null)
                {
                    LocalDragNodes((ToolTreeNode)toolView.SelectedNode, mouseMoveNode);
                }
                //异地拖动
                else
                {
                    //外部输入节点
                    TreeNode externalNode = (TreeNode)(e.Data.GetData(typeof(TreeNode)));
                    if (externalNode != null)
                    {
                        AddNewToolNodes(externalNode, mouseMoveNode);
                    }
                }
                UpdataToolStepIndex();
                GetToolInfoList();
                mMouseDown = false;
                mouseMoveNode = null;
                Invalidate();//刷新UI
            }

        }

        /// <summary>
        /// 本地工具节点拖拽更新
        /// </summary>
        /// <param name="selectNode">被拖拽节点</param>
        /// <param name="mouseMoveNote">目标移动位置节点</param>
        private void LocalDragNodes(ToolTreeNode selectNode, ToolTreeNode mouseMoveNote)
        {
            //当前移动的目标节点不为空且不等于选中节点
            if (mouseMoveNote != null && mouseMoveNote != selectNode)
            {
                //克隆节点
                ToolTreeNode nodClone = (ToolTreeNode)selectNode.Clone();
                //选定节点为条件语句 if  else 
                if (selectNode.ToolInfo.ToolName.Contains("If") || selectNode.ToolInfo.ToolName.Contains("Else"))
                {
                    //if else 不支持拖动
                    return;
                }
                //目标位置非条件语句
                if (!mouseMoveNote.ToolInfo.ToolName.Contains("If") && !mouseMoveNote.ToolInfo.ToolName.Contains("Else"))
                {
                    if (mouseMoveNote.Parent != null)
                    {
                        //删除指定工具
                        ToolRemoveAt(selectNode.InnerTool);
                        //指定位置插入
                        mouseMoveNote.Parent.Nodes.Insert(mouseMoveNote.Index + 1, nodClone);
                        //工具进行插入
                        if (mouseMoveNote.Index + 1 >= ((ToolTreeNode)mouseMoveNote.Parent).InnerTool.ChildToolList.Count)
                            ((ToolTreeNode)mouseMoveNote.Parent).InnerTool.ChildToolList.Add(nodClone.InnerTool);
                        else
                            ((ToolTreeNode)mouseMoveNote.Parent).InnerTool.ChildToolList.Insert(mouseMoveNote.Index + 1, nodClone.InnerTool);
                        //删除选定节点
                        toolView.Nodes.Remove(selectNode);
                       
                    }
                    else
                    {
                        //一级插入
                        toolView.Nodes.Insert(mouseMoveNote.Index + 1, nodClone);
                        //工具插入
                        ToolList.Insert(mouseMoveNote.Index + 1, nodClone.InnerTool);
                        //删除指定工具
                        ToolRemoveAt(selectNode.InnerTool);
                        //删除选定节点
                        toolView.Nodes.Remove(selectNode);

                    }
                    //重新指定节点
                    toolView.SelectedNode = nodClone;
                }
                //目标位置节点是条件语句
                else
                {
                    //先删除指定工具
                    ToolRemoveAt(selectNode.InnerTool);
                    //直接添加为子节点
                    mouseMoveNote.Nodes.Add(nodClone);
                    //后添加工具
                    mouseMoveNote.InnerTool.ChildToolList.Add(nodClone.InnerTool);

                    //删除选定节点
                    toolView.Nodes.Remove(selectNode);
                    //重新指定节点
                    toolView.SelectedNode = nodClone;
                }
            }
            GetToolInfoList();
        }

        /// <summary>
        /// 新增工具节点
        /// </summary>
        /// <param name="externalNode">输入的节点</param>
        private void AddNewToolNodes(TreeNode externalNode, ToolTreeNode mouseMoveNote)
        {
            //若添加的工具为  if   else
            if (externalNode.Text.Contains("If") && externalNode.Text.Contains("Else"))
            {
                //生成工具
                ToolBase tool1 = AddNewTool("If");
                ToolBase tool2 = AddNewTool("Else");
                tool2.ToolID = tool1.ToolID + 1;
                //互相绑定
                tool1.BingdingTool = tool2;
                tool2.BingdingTool = tool1;
                //生成节点
                ToolTreeNode node1 = new ToolTreeNode(tool1);
                ToolTreeNode node2 = new ToolTreeNode(tool2);

                if (mouseMoveNote != null)
                {

                    //若是往if else for进行内嵌入
                    if (mouseMoveNote.ToolInfo.ToolName.Contains("if") || mouseMoveNote.ToolInfo.ToolName.Contains("else") || mouseMoveNote.ToolInfo.ToolName.Contains("For"))
                    {
                        //指定位置插入if
                        mouseMoveNote.Nodes.Add(node1);
                        //if子工具进行添加
                        mouseMoveNote.InnerTool.ChildToolList.Add(tool1);
                        //指定位置插入else
                        mouseMoveNote.Nodes.Add(node2);
                        //else子工具进行添加
                        mouseMoveNote.InnerTool.ChildToolList.Add(tool2);
                    }
                    else if (mouseMoveNote.Parent != null)
                    {
                        //指定位置插入
                        mouseMoveNote.Parent.Nodes.Insert(mouseMoveNote.Index + 1, node1);
                        mouseMoveNote.Parent.Nodes.Insert(mouseMoveNote.Index + 2, node2);

                        ((ToolTreeNode)mouseMoveNote.Parent).InnerTool.ChildToolList.Insert(mouseMoveNote.Index + 1, tool1);
                        ((ToolTreeNode)mouseMoveNote.Parent).InnerTool.ChildToolList.Insert(mouseMoveNote.Index + 2, tool2);
                    }
                    else
                    {
                        //一级插入
                        toolView.Nodes.Insert(mouseMoveNote.Index + 1, node1);
                        //一级插入
                        toolView.Nodes.Insert(mouseMoveNote.Index + 2, node2);
                        //一级插入
                        ToolList.Insert(mouseMoveNote.Index + 1, tool1);
                        //一级插入
                        ToolList.Insert(mouseMoveNote.Index + 2, tool2);
                    }
                    //重新指定节点
                    toolView.SelectedNode = node1;
                }
                else
                {
                    //一级插入
                    toolView.Nodes.Add(node1);
                    //工具添加
                    ToolList.Add(tool1);
                    //一级插入
                    toolView.Nodes.Add(node2);
                    //工具添加
                    ToolList.Add(tool2);
                    toolView.SelectedNode = node1;
                }
            }
            else
            {
                if (mouseMoveNote != null)
                {
                    if (mouseMoveNote.ToolInfo.ToolName.Contains("If") || mouseMoveNote.ToolInfo.ToolName.Contains("Else") || mouseMoveNote.ToolInfo.ToolName.Contains("For"))
                    {
                        //生成工具
                        ToolBase tool = AddNewTool(externalNode.Text);
                        //生成节点
                        ToolTreeNode node = new ToolTreeNode(tool);
                        //添加节点
                        mouseMoveNote.Nodes.Add(node);
                        //添加工具
                        mouseMoveNote.InnerTool.ChildToolList.Add(tool);
                        //重新指定节点
                        toolView.SelectedNode = node;
                    }
                    else
                    {
                        //生成工具
                        ToolBase tool = AddNewTool(externalNode.Text);
                        //生成节点
                        ToolTreeNode node = new ToolTreeNode(tool);
                        if (mouseMoveNote.Parent != null)
                        {
                            //指定位置插入
                            mouseMoveNote.Parent.Nodes.Insert(mouseMoveNote.Index + 1, node);
                            //工具插入
                            if (mouseMoveNote.Index + 1 > ((ToolTreeNode)mouseMoveNote.Parent).InnerTool.ChildToolList.Count)
                                ((ToolTreeNode)mouseMoveNote.Parent).InnerTool.ChildToolList.Add(tool);
                            else
                                ((ToolTreeNode)mouseMoveNote.Parent).InnerTool.ChildToolList.Insert(mouseMoveNote.Index + 1, tool);

                        }
                        else
                        {
                            //一级插入
                            toolView.Nodes.Insert(mouseMoveNote.Index + 1, node);
                            //工具插入
                            ToolList.Insert(mouseMoveNote.Index + 1, tool);
                        }
                        //重新指定节点
                        toolView.SelectedNode = node;
                    }
                }
                else
                {
                    //生成工具
                    ToolBase tool = AddNewTool(externalNode.Text);
                    //生成节点
                    ToolTreeNode node = new ToolTreeNode(tool);
                    //一级插入
                    toolView.Nodes.Add(node);
                    //工具添加
                    ToolList.Add(tool);
                    //重新指定节点
                    toolView.SelectedNode = node;
                }
            }
        }

        /// <summary>
        /// 在列表结尾添加新工具
        /// </summary>
        /// <param name="name"></param>
        private ToolBase AddNewTool(string name)
        {
            //工具列表新增
            ToolBase tool = ToolOP.GetToolFromType(ToolOP.GetTypeFromString(name));
            if (tool != null)
            {
                //生成工具索引ID
                tool.ToolID = GetNewToolID();
                //生成工具名称
                tool.ShowName = GetNewToolName(name);
            }
            return tool;
        }

        /// <summary>
        /// 生成内部ID
        /// </summary>
        /// <returns></returns>
        private int GetNewToolID()
        {
            int ToolID = 0;
            if (mToolList.Count > 0)
            {
                //获取工具内部ID
                GetNewToolID(ToolList, ref ToolID);
                return ToolID;
            }
            else
                return 1;
        }
        private void GetNewToolID(List<ToolBase> tools, ref int nameCount) 
        {
            foreach (var item in tools)
            {
                if (item.ToolID >= nameCount)
                    nameCount = item.ToolID + 1;
                if (item.ChildToolList.Count > 0)
                    GetNewToolID(item.ChildToolList, ref nameCount);
            }
        }

        private string GetNewToolName(string name)
        {
            if (mToolList.Count > 0)
            {
                int j = 1;
                GetNewToolName(name, ToolList, ref j);
                return name + " " + j.ToString();
            }
            else
                return name + " " + 1;
        }

        private void GetNewToolName(string name, List<ToolBase> tools, ref int nameCount)
        {
            foreach (var item in tools)
            {
                if (item.ShowName.Contains(name))
                {
                    nameCount++;
                }
                if (item.ChildToolList.Count > 0)
                    GetNewToolName(name, item.ChildToolList, ref nameCount);
            }
        }

        private void ToolRemoveAt(ToolBase baseTool)
        {
            RemoveItems(baseTool, ToolList);
        }

        private void RemoveItems(ToolBase baseTool, List<ToolBase> tools)
        {
            foreach (ToolBase tool in tools)
            {
                if (tool == baseTool)
                {
                    tools.Remove(baseTool);
                    break;
                }
                if (tool.ChildToolList.Count > 0)
                {
                    RemoveItems(baseTool, tool.ChildToolList);
                }
            }
        }

        private void UpdataToolStepIndex()
        {
            int stepindex = 1;
            foreach (ToolTreeNode item in toolView.Nodes)
            {
                item.ToolInfo.StepIndex = stepindex;
                stepindex++;
                if (item.Nodes.Count > 0)
                    GetBeforeToolsCount(ref stepindex, item.Nodes);
            }
        }

        private void GetBeforeToolsCount(ref int step, TreeNodeCollection nodes)
        {
            foreach (ToolTreeNode item in nodes)
            {
                item.ToolInfo.StepIndex = step;
                step++;
                if (item.Nodes.Count > 0)
                {
                    GetBeforeToolsCount(ref step, item.Nodes);
                }
            }
        }

        private void 重命名ReNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolTreeNode node = (ToolTreeNode)toolView.SelectedNode;
            string value = node.ToolInfo.ToolRemarks;
            FrmRemarks frm = new FrmRemarks(value);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //toolInfo修改
                node.ToolInfo.ToolRemarks = frm.Remarks;
                //tool修改
                node.InnerTool.ToolRemarks = frm.Remarks;
                //刷新
                Invalidate();
            }
        }

        private void 删除DeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolView.SelectedNode != null)
            {
                //删除工具
                DeleTool(((ToolTreeNode)toolView.SelectedNode).InnerTool, ToolList);
                //删除节点
                toolView.Nodes.Remove(toolView.SelectedNode);
                //事件发送
                NodeDeleClick?.Invoke(sender, e);
            }
        }

        private void DeleTool(ToolBase tool,List<ToolBase> toolList) 
        { 
            foreach(ToolBase toolBase in toolList)
            {
                if (toolBase == tool) 
                {
                    toolList.Remove(toolBase);
                    break;
                }
                if (toolBase.ChildToolList.Count > 0)
                    DeleTool(tool, toolBase.ChildToolList);
            }
            GetToolInfoList();
        }

        private void GetToolInfoList()
        {
            try
            {
                mToolInfoList.Clear();
                GetToolInfo(Nodes);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetToolInfo(TreeNodeCollection toolNode)
        {
            for (int i = 0; i < toolNode.Count; i++)
            {
                ToolTreeNode node = (ToolTreeNode)toolNode[i];
                if (node != null)
                    mToolInfoList.Add(node.ToolInfo);
                if (node.Nodes.Count > 0)
                    GetToolInfo(node.Nodes);
            }
        }

        private void LoadToolToTrees(List<ToolBase> lit, TreeNodeCollection Nodes)
        {
            if (lit.Count > 0)
            {
                foreach (ToolBase item in lit)
                {
                    ToolTreeNode toolTree = new ToolTreeNode(item);
                    Nodes.Add(toolTree);
                    if (item.ChildToolList.Count > 0) 
                    {
                        TreeNodeCollection nodes = toolTree.Nodes;
                        LoadToolToTrees(item.ChildToolList.ToList(), nodes);
                    }
                }
            }
        }

        public void LoadTools(List<ToolBase> lit) 
        {
            LoadToolToTrees(lit, this.Nodes);
            UpdataToolStepIndex();
            GetToolInfoList();
            Invalidate();//刷新UI
            mToolList = lit;
            toolView.ExpandAll();
        }

    }
}
