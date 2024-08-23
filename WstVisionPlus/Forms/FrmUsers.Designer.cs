namespace WstVisionPlus
{
    partial class FrmUsers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsers));
            this.dataGridView_UserList = new System.Windows.Forms.DataGridView();
            this.Column_Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_PassWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Level = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserList)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_UserList
            // 
            this.dataGridView_UserList.AllowDrop = true;
            this.dataGridView_UserList.AllowUserToAddRows = false;
            this.dataGridView_UserList.AllowUserToDeleteRows = false;
            this.dataGridView_UserList.AllowUserToResizeRows = false;
            this.dataGridView_UserList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.dataGridView_UserList.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dataGridView_UserList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_UserList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Index,
            this.Column_UserName,
            this.Column_PassWord,
            this.Column_Level});
            this.dataGridView_UserList.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView_UserList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView_UserList.Location = new System.Drawing.Point(3, 37);
            this.dataGridView_UserList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView_UserList.MultiSelect = false;
            this.dataGridView_UserList.Name = "dataGridView_UserList";
            this.dataGridView_UserList.RowHeadersVisible = false;
            this.dataGridView_UserList.RowHeadersWidth = 43;
            this.dataGridView_UserList.RowTemplate.Height = 23;
            this.dataGridView_UserList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_UserList.Size = new System.Drawing.Size(567, 305);
            this.dataGridView_UserList.TabIndex = 9;
            this.dataGridView_UserList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridView_UserList_EditingControlShowing);
            // 
            // Column_Index
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_Index.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column_Index.HeaderText = "No";
            this.Column_Index.Name = "Column_Index";
            this.Column_Index.ReadOnly = true;
            this.Column_Index.Width = 80;
            // 
            // Column_UserName
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_UserName.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column_UserName.HeaderText = "User Name";
            this.Column_UserName.Name = "Column_UserName";
            this.Column_UserName.ReadOnly = true;
            this.Column_UserName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_UserName.Width = 150;
            // 
            // Column_PassWord
            // 
            this.Column_PassWord.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column_PassWord.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column_PassWord.HeaderText = "User Password";
            this.Column_PassWord.Name = "Column_PassWord";
            this.Column_PassWord.ReadOnly = true;
            this.Column_PassWord.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_PassWord.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_Level
            // 
            this.Column_Level.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.Column_Level.HeaderText = "Authority";
            this.Column_Level.Items.AddRange(new object[] {
            "操作工",
            "工程师",
            "管理员"});
            this.Column_Level.Name = "Column_Level";
            this.Column_Level.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Level.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column_Level.Width = 150;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增ToolStripMenuItem,
            this.删除ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // 新增ToolStripMenuItem
            // 
            this.新增ToolStripMenuItem.Name = "新增ToolStripMenuItem";
            this.新增ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.新增ToolStripMenuItem.Text = "Add ";
            this.新增ToolStripMenuItem.Click += new System.EventHandler(this.新增ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.删除ToolStripMenuItem.Text = "Delete";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // FrmUsers
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(572, 346);
            this.ControlBoxFillHoverColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.dataGridView_UserList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUsers";
            this.RectColor = System.Drawing.Color.Teal;
            this.Text = "Users Management";
            this.TitleColor = System.Drawing.Color.Teal;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FrmUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_UserList)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_UserList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新增ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_PassWord;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_Level;
    }
}