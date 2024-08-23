namespace WstControls
{
    partial class HDebugWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HDebugWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_SaveImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ZoomImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Reduce = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel_ZoomMes = new System.Windows.Forms.ToolStripLabel();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Hand = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Arrow = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_ImageSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ImageRGB = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Row = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Column = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_SaveImage,
            this.toolStripButton_ZoomImage,
            this.toolStripSeparator1,
            this.toolStripButton_Reduce,
            this.toolStripLabel_ZoomMes,
            this.toolStripButton_Add,
            this.toolStripSeparator2,
            this.toolStripButton_Hand,
            this.toolStripButton_Arrow,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(409, 30);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_SaveImage
            // 
            this.toolStripButton_SaveImage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_SaveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_SaveImage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_SaveImage.Image")));
            this.toolStripButton_SaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_SaveImage.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton_SaveImage.Name = "toolStripButton_SaveImage";
            this.toolStripButton_SaveImage.Size = new System.Drawing.Size(28, 27);
            this.toolStripButton_SaveImage.Text = "SaveImage";
            this.toolStripButton_SaveImage.Click += new System.EventHandler(this.ToolStripButton_SaveImage_Click);
            // 
            // toolStripButton_ZoomImage
            // 
            this.toolStripButton_ZoomImage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_ZoomImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ZoomImage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ZoomImage.Image")));
            this.toolStripButton_ZoomImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ZoomImage.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton_ZoomImage.Name = "toolStripButton_ZoomImage";
            this.toolStripButton_ZoomImage.Size = new System.Drawing.Size(28, 27);
            this.toolStripButton_ZoomImage.Text = "ZoomSize";
            this.toolStripButton_ZoomImage.Click += new System.EventHandler(this.ToolStripButton_ZoomImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton_Reduce
            // 
            this.toolStripButton_Reduce.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Reduce.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Reduce.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Reduce.Image")));
            this.toolStripButton_Reduce.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Reduce.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton_Reduce.Name = "toolStripButton_Reduce";
            this.toolStripButton_Reduce.Size = new System.Drawing.Size(28, 27);
            this.toolStripButton_Reduce.Text = "Shrink";
            this.toolStripButton_Reduce.Click += new System.EventHandler(this.ToolStripButton_Reduce_Click);
            // 
            // toolStripLabel_ZoomMes
            // 
            this.toolStripLabel_ZoomMes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel_ZoomMes.AutoSize = false;
            this.toolStripLabel_ZoomMes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripLabel_ZoomMes.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripLabel_ZoomMes.Name = "toolStripLabel_ZoomMes";
            this.toolStripLabel_ZoomMes.Size = new System.Drawing.Size(60, 27);
            this.toolStripLabel_ZoomMes.Text = "100%";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Add.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Add.Image")));
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(28, 27);
            this.toolStripButton_Add.Text = "Magnify";
            this.toolStripButton_Add.Click += new System.EventHandler(this.ToolStripButton_Add_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton_Hand
            // 
            this.toolStripButton_Hand.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Hand.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Hand.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Hand.Image")));
            this.toolStripButton_Hand.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Hand.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton_Hand.Name = "toolStripButton_Hand";
            this.toolStripButton_Hand.Size = new System.Drawing.Size(28, 27);
            this.toolStripButton_Hand.Text = "Move";
            this.toolStripButton_Hand.Click += new System.EventHandler(this.ToolStripButton_Hand_Click);
            // 
            // toolStripButton_Arrow
            // 
            this.toolStripButton_Arrow.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_Arrow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Arrow.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Arrow.Image")));
            this.toolStripButton_Arrow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Arrow.Margin = new System.Windows.Forms.Padding(3, 1, 3, 2);
            this.toolStripButton_Arrow.Name = "toolStripButton_Arrow";
            this.toolStripButton_Arrow.Size = new System.Drawing.Size(28, 27);
            this.toolStripButton_Arrow.Text = "Arrow";
            this.toolStripButton_Arrow.Click += new System.EventHandler(this.ToolStripButton_Arrow_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(70, 27);
            this.toolStripLabel2.Text = "window";
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_ImageSize,
            this.toolStripStatusLabel_ImageRGB,
            this.toolStripStatusLabel_Row,
            this.toolStripStatusLabel_Column});
            this.statusStrip1.Location = new System.Drawing.Point(0, 330);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(409, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // toolStripStatusLabel_ImageSize
            // 
            this.toolStripStatusLabel_ImageSize.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel_ImageSize.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
            this.toolStripStatusLabel_ImageSize.Name = "toolStripStatusLabel_ImageSize";
            this.toolStripStatusLabel_ImageSize.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel_ImageSize.Text = "Size(0,0)";
            // 
            // toolStripStatusLabel_ImageRGB
            // 
            this.toolStripStatusLabel_ImageRGB.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel_ImageRGB.Name = "toolStripStatusLabel_ImageRGB";
            this.toolStripStatusLabel_ImageRGB.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel_ImageRGB.Text = "RGB(0,0,0)";
            // 
            // toolStripStatusLabel_Row
            // 
            this.toolStripStatusLabel_Row.Margin = new System.Windows.Forms.Padding(5, 3, 5, 2);
            this.toolStripStatusLabel_Row.Name = "toolStripStatusLabel_Row";
            this.toolStripStatusLabel_Row.Size = new System.Drawing.Size(49, 17);
            this.toolStripStatusLabel_Row.Text = "Row=0";
            // 
            // toolStripStatusLabel_Column
            // 
            this.toolStripStatusLabel_Column.Name = "toolStripStatusLabel_Column";
            this.toolStripStatusLabel_Column.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusLabel_Column.Text = "Column=0";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 300);
            this.panel1.TabIndex = 2;
            // 
            // HDebugWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "HDebugWindow";
            this.Size = new System.Drawing.Size(409, 352);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_SaveImage;
        private System.Windows.Forms.ToolStripButton toolStripButton_ZoomImage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ImageSize;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ImageRGB;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Reduce;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_ZoomMes;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Hand;
        private System.Windows.Forms.ToolStripButton toolStripButton_Arrow;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Row;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Column;
    }
}
