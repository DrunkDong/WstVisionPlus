namespace WstControls
{
    partial class UMessageListView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UMessageListView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Error = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Warnning = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Info = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.清除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Error,
            this.toolStripButton_Warnning,
            this.toolStripButton_Info,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(419, 24);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Paint += new System.Windows.Forms.PaintEventHandler(this.ToolStrip1_Paint);
            // 
            // toolStripButton_Error
            // 
            this.toolStripButton_Error.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Error.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Error.Image")));
            this.toolStripButton_Error.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Error.Name = "toolStripButton_Error";
            this.toolStripButton_Error.Size = new System.Drawing.Size(88, 21);
            this.toolStripButton_Error.Text = "Error(0)";
            this.toolStripButton_Error.Click += new System.EventHandler(this.ToolStripButton_Error_Click);
            // 
            // toolStripButton_Warnning
            // 
            this.toolStripButton_Warnning.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Warnning.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Warnning.Image")));
            this.toolStripButton_Warnning.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Warnning.Name = "toolStripButton_Warnning";
            this.toolStripButton_Warnning.Size = new System.Drawing.Size(113, 21);
            this.toolStripButton_Warnning.Text = "Warning(0)";
            this.toolStripButton_Warnning.Click += new System.EventHandler(this.ToolStripButton_Warnning_Click);
            // 
            // toolStripButton_Info
            // 
            this.toolStripButton_Info.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Info.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Info.Image")));
            this.toolStripButton_Info.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Info.Name = "toolStripButton_Info";
            this.toolStripButton_Info.Size = new System.Drawing.Size(80, 21);
            this.toolStripButton_Info.Text = "Info(0)";
            this.toolStripButton_Info.Click += new System.EventHandler(this.ToolStripButton_Info_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(101, 21);
            this.toolStripLabel1.Text = "MessageBox";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 56);
            // 
            // 清除ToolStripMenuItem
            // 
            this.清除ToolStripMenuItem.Name = "清除ToolStripMenuItem";
            this.清除ToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.清除ToolStripMenuItem.Text = "clear";
            this.清除ToolStripMenuItem.Click += new System.EventHandler(this.清除ToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.White;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.LabelWrap = false;
            this.listView1.Location = new System.Drawing.Point(0, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(419, 94);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 160;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 900;
            // 
            // UMessageListView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "UMessageListView";
            this.Size = new System.Drawing.Size(419, 118);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Info;
        private System.Windows.Forms.ToolStripButton toolStripButton_Warnning;
        private System.Windows.Forms.ToolStripButton toolStripButton_Error;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 清除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}
