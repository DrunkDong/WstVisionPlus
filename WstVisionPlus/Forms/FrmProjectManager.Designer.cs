namespace WstVisionPlus
{
    partial class FrmProjectManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProjectManager));
            this.dataGridView_ProjectList = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.切换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.克隆ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uiButton_CreateNew = new Sunny.UI.UIButton();
            this.uiButton_Dele = new Sunny.UI.UIButton();
            this.uiButton_Edit = new Sunny.UI.UIButton();
            this.uiButton_Change = new Sunny.UI.UIButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjectList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_ProjectList
            // 
            this.dataGridView_ProjectList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProjectList.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView_ProjectList.Location = new System.Drawing.Point(3, 41);
            this.dataGridView_ProjectList.Name = "dataGridView_ProjectList";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_ProjectList.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_ProjectList.RowHeadersWidth = 51;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.dataGridView_ProjectList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_ProjectList.RowTemplate.Height = 23;
            this.dataGridView_ProjectList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ProjectList.Size = new System.Drawing.Size(889, 344);
            this.dataGridView_ProjectList.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.切换ToolStripMenuItem,
            this.克隆ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 92);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.编辑ToolStripMenuItem.Text = "编辑";
            this.编辑ToolStripMenuItem.Click += new System.EventHandler(this.编辑ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // 切换ToolStripMenuItem
            // 
            this.切换ToolStripMenuItem.Name = "切换ToolStripMenuItem";
            this.切换ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.切换ToolStripMenuItem.Text = "选定";
            this.切换ToolStripMenuItem.Click += new System.EventHandler(this.切换ToolStripMenuItem_Click);
            // 
            // 克隆ToolStripMenuItem
            // 
            this.克隆ToolStripMenuItem.Name = "克隆ToolStripMenuItem";
            this.克隆ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.克隆ToolStripMenuItem.Text = "克隆";
            this.克隆ToolStripMenuItem.Click += new System.EventHandler(this.克隆ToolStripMenuItem_Click);
            // 
            // uiButton_CreateNew
            // 
            this.uiButton_CreateNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_CreateNew.FillColor = System.Drawing.Color.Teal;
            this.uiButton_CreateNew.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_CreateNew.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_CreateNew.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_CreateNew.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_CreateNew.Font = new System.Drawing.Font("宋体", 12F);
            this.uiButton_CreateNew.Location = new System.Drawing.Point(93, 391);
            this.uiButton_CreateNew.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_CreateNew.Name = "uiButton_CreateNew";
            this.uiButton_CreateNew.Radius = 15;
            this.uiButton_CreateNew.RectColor = System.Drawing.Color.Teal;
            this.uiButton_CreateNew.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_CreateNew.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_CreateNew.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_CreateNew.Size = new System.Drawing.Size(103, 40);
            this.uiButton_CreateNew.TabIndex = 72;
            this.uiButton_CreateNew.Text = "新增";
            this.uiButton_CreateNew.TipsFont = new System.Drawing.Font("宋体", 14F);
            this.uiButton_CreateNew.Click += new System.EventHandler(this.UiButton_CreateNew_Click);
            // 
            // uiButton_Dele
            // 
            this.uiButton_Dele.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_Dele.FillColor = System.Drawing.Color.Teal;
            this.uiButton_Dele.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Dele.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Dele.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Dele.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Dele.Font = new System.Drawing.Font("宋体", 12F);
            this.uiButton_Dele.Location = new System.Drawing.Point(280, 391);
            this.uiButton_Dele.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_Dele.Name = "uiButton_Dele";
            this.uiButton_Dele.Radius = 15;
            this.uiButton_Dele.RectColor = System.Drawing.Color.Teal;
            this.uiButton_Dele.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Dele.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Dele.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Dele.Size = new System.Drawing.Size(103, 40);
            this.uiButton_Dele.TabIndex = 73;
            this.uiButton_Dele.Text = "删除";
            this.uiButton_Dele.TipsFont = new System.Drawing.Font("宋体", 14F);
            this.uiButton_Dele.Click += new System.EventHandler(this.UiButton_Dele_Click);
            // 
            // uiButton_Edit
            // 
            this.uiButton_Edit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_Edit.FillColor = System.Drawing.Color.Teal;
            this.uiButton_Edit.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Edit.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Edit.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Edit.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Edit.Font = new System.Drawing.Font("宋体", 12F);
            this.uiButton_Edit.Location = new System.Drawing.Point(467, 391);
            this.uiButton_Edit.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_Edit.Name = "uiButton_Edit";
            this.uiButton_Edit.Radius = 15;
            this.uiButton_Edit.RectColor = System.Drawing.Color.Teal;
            this.uiButton_Edit.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Edit.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Edit.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Edit.Size = new System.Drawing.Size(103, 40);
            this.uiButton_Edit.TabIndex = 74;
            this.uiButton_Edit.Text = "编辑";
            this.uiButton_Edit.TipsFont = new System.Drawing.Font("宋体", 14F);
            this.uiButton_Edit.Click += new System.EventHandler(this.UiButton_Edit_Click);
            // 
            // uiButton_Change
            // 
            this.uiButton_Change.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_Change.FillColor = System.Drawing.Color.Teal;
            this.uiButton_Change.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Change.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Change.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Change.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Change.Font = new System.Drawing.Font("宋体", 12F);
            this.uiButton_Change.Location = new System.Drawing.Point(654, 391);
            this.uiButton_Change.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_Change.Name = "uiButton_Change";
            this.uiButton_Change.Radius = 15;
            this.uiButton_Change.RectColor = System.Drawing.Color.Teal;
            this.uiButton_Change.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Change.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Change.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Change.Size = new System.Drawing.Size(103, 40);
            this.uiButton_Change.TabIndex = 75;
            this.uiButton_Change.Text = "选定";
            this.uiButton_Change.TipsFont = new System.Drawing.Font("宋体", 14F);
            this.uiButton_Change.Click += new System.EventHandler(this.UiButton_Change_Click);
            // 
            // FrmProjectManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(895, 440);
            this.Controls.Add(this.uiButton_Change);
            this.Controls.Add(this.uiButton_Edit);
            this.Controls.Add(this.uiButton_Dele);
            this.Controls.Add(this.uiButton_CreateNew);
            this.Controls.Add(this.dataGridView_ProjectList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProjectManager";
            this.RectColor = System.Drawing.Color.Teal;
            this.Text = "工程列表";
            this.TitleColor = System.Drawing.Color.Teal;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FrmProjectManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProjectList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_ProjectList;
        private Sunny.UI.UIButton uiButton_CreateNew;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 切换ToolStripMenuItem;
        private Sunny.UI.UIButton uiButton_Dele;
        private Sunny.UI.UIButton uiButton_Edit;
        private Sunny.UI.UIButton uiButton_Change;
        private System.Windows.Forms.ToolStripMenuItem 克隆ToolStripMenuItem;
    }
}