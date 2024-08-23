namespace WstControls
{
    partial class UListViewItem
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Cost = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_ToolInnerID = new System.Windows.Forms.Label();
            this.label_State = new System.Windows.Forms.Label();
            this.label_First = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uSplitLineH1 = new WstControls.USplitLineH();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_ToolInnerID);
            this.panel1.Controls.Add(this.label_Cost);
            this.panel1.Controls.Add(this.label_Name);
            this.panel1.Controls.Add(this.label_State);
            this.panel1.Controls.Add(this.label_First);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(364, 46);
            this.panel1.TabIndex = 1;
            // 
            // label_Cost
            // 
            this.label_Cost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_Cost.Font = new System.Drawing.Font("微软雅黑", 9.5F);
            this.label_Cost.Location = new System.Drawing.Point(277, 0);
            this.label_Cost.Name = "label_Cost";
            this.label_Cost.Size = new System.Drawing.Size(87, 46);
            this.label_Cost.TabIndex = 29;
            this.label_Cost.Text = "0.00 ms";
            this.label_Cost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Name
            // 
            this.label_Name.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_Name.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label_Name.Location = new System.Drawing.Point(108, 0);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(169, 46);
            this.label_Name.TabIndex = 28;
            this.label_Name.Text = "tool name";
            this.label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_ToolInnerID
            // 
            this.label_ToolInnerID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ToolInnerID.AutoSize = true;
            this.label_ToolInnerID.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.label_ToolInnerID.ForeColor = System.Drawing.Color.Magenta;
            this.label_ToolInnerID.Location = new System.Drawing.Point(275, 0);
            this.label_ToolInnerID.Name = "label_ToolInnerID";
            this.label_ToolInnerID.Size = new System.Drawing.Size(18, 20);
            this.label_ToolInnerID.TabIndex = 18;
            this.label_ToolInnerID.Text = "0";
            // 
            // label_State
            // 
            this.label_State.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_State.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label_State.Image = global::WstControls.Properties.Resources.OK;
            this.label_State.Location = new System.Drawing.Point(64, 0);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(44, 46);
            this.label_State.TabIndex = 27;
            this.label_State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_First
            // 
            this.label_First.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_First.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label_First.Location = new System.Drawing.Point(28, 0);
            this.label_First.Name = "label_First";
            this.label_First.Size = new System.Drawing.Size(36, 46);
            this.label_First.TabIndex = 26;
            this.label_First.Text = "nu";
            this.label_First.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::WstControls.Properties.Resources.sort;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 46);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // uSplitLineH1
            // 
            this.uSplitLineH1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(238)))), ((int)(((byte)(238)))));
            this.uSplitLineH1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uSplitLineH1.Location = new System.Drawing.Point(0, 46);
            this.uSplitLineH1.Name = "uSplitLineH1";
            this.uSplitLineH1.Size = new System.Drawing.Size(364, 1);
            this.uSplitLineH1.TabIndex = 0;
            this.uSplitLineH1.TabStop = false;
            // 
            // UListViewItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.uSplitLineH1);
            this.Name = "UListViewItem";
            this.Size = new System.Drawing.Size(364, 47);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private USplitLineH uSplitLineH1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_ToolInnerID;
        private System.Windows.Forms.Label label_First;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_Cost;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_State;
    }
}
