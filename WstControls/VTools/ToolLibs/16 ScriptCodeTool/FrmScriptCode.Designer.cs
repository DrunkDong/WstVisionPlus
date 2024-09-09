namespace WstControls
{
    partial class FrmScriptCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScriptCode));
            this.panel_CodeEdit = new System.Windows.Forms.Panel();
            this.PanelSearch = new System.Windows.Forms.Panel();
            this.BtnNextSearch = new System.Windows.Forms.Button();
            this.BtnPrevSearch = new System.Windows.Forms.Button();
            this.BtnCloseSearch = new System.Windows.Forms.Button();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.richTextBox_Res = new System.Windows.Forms.RichTextBox();
            this.button_Action = new System.Windows.Forms.Button();
            this.button_Compile = new System.Windows.Forms.Button();
            this.panel_CodeEdit.SuspendLayout();
            this.PanelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_CodeEdit
            // 
            this.panel_CodeEdit.Controls.Add(this.PanelSearch);
            this.panel_CodeEdit.Location = new System.Drawing.Point(2, 0);
            this.panel_CodeEdit.Margin = new System.Windows.Forms.Padding(4);
            this.panel_CodeEdit.Name = "panel_CodeEdit";
            this.panel_CodeEdit.Size = new System.Drawing.Size(995, 400);
            this.panel_CodeEdit.TabIndex = 1;
            // 
            // PanelSearch
            // 
            this.PanelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelSearch.BackColor = System.Drawing.Color.White;
            this.PanelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelSearch.Controls.Add(this.BtnNextSearch);
            this.PanelSearch.Controls.Add(this.BtnPrevSearch);
            this.PanelSearch.Controls.Add(this.BtnCloseSearch);
            this.PanelSearch.Controls.Add(this.TxtSearch);
            this.PanelSearch.Location = new System.Drawing.Point(601, 14);
            this.PanelSearch.Margin = new System.Windows.Forms.Padding(4);
            this.PanelSearch.Name = "PanelSearch";
            this.PanelSearch.Size = new System.Drawing.Size(389, 50);
            this.PanelSearch.TabIndex = 14;
            this.PanelSearch.Visible = false;
            // 
            // BtnNextSearch
            // 
            this.BtnNextSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNextSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNextSearch.ForeColor = System.Drawing.Color.White;
            this.BtnNextSearch.Image = ((System.Drawing.Image)(resources.GetObject("BtnNextSearch.Image")));
            this.BtnNextSearch.Location = new System.Drawing.Point(311, 5);
            this.BtnNextSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnNextSearch.Name = "BtnNextSearch";
            this.BtnNextSearch.Size = new System.Drawing.Size(33, 38);
            this.BtnNextSearch.TabIndex = 9;
            this.BtnNextSearch.Tag = "Find next (Enter)";
            this.BtnNextSearch.UseVisualStyleBackColor = true;
            // 
            // BtnPrevSearch
            // 
            this.BtnPrevSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPrevSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPrevSearch.ForeColor = System.Drawing.Color.White;
            this.BtnPrevSearch.Image = ((System.Drawing.Image)(resources.GetObject("BtnPrevSearch.Image")));
            this.BtnPrevSearch.Location = new System.Drawing.Point(273, 5);
            this.BtnPrevSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnPrevSearch.Name = "BtnPrevSearch";
            this.BtnPrevSearch.Size = new System.Drawing.Size(33, 38);
            this.BtnPrevSearch.TabIndex = 8;
            this.BtnPrevSearch.Tag = "Find previous (Shift+Enter)";
            this.BtnPrevSearch.UseVisualStyleBackColor = true;
            // 
            // BtnCloseSearch
            // 
            this.BtnCloseSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCloseSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCloseSearch.ForeColor = System.Drawing.Color.White;
            this.BtnCloseSearch.Image = ((System.Drawing.Image)(resources.GetObject("BtnCloseSearch.Image")));
            this.BtnCloseSearch.Location = new System.Drawing.Point(348, 5);
            this.BtnCloseSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnCloseSearch.Name = "BtnCloseSearch";
            this.BtnCloseSearch.Size = new System.Drawing.Size(33, 38);
            this.BtnCloseSearch.TabIndex = 7;
            this.BtnCloseSearch.Tag = "Close (Esc)";
            this.BtnCloseSearch.UseVisualStyleBackColor = true;
            // 
            // TxtSearch
            // 
            this.TxtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtSearch.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearch.Location = new System.Drawing.Point(5, 9);
            this.TxtSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(252, 31);
            this.TxtSearch.TabIndex = 6;
            // 
            // richTextBox_Res
            // 
            this.richTextBox_Res.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.richTextBox_Res.Location = new System.Drawing.Point(2, 406);
            this.richTextBox_Res.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_Res.Name = "richTextBox_Res";
            this.richTextBox_Res.Size = new System.Drawing.Size(839, 206);
            this.richTextBox_Res.TabIndex = 2;
            this.richTextBox_Res.Text = "";
            // 
            // button_Action
            // 
            this.button_Action.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button_Action.Location = new System.Drawing.Point(865, 471);
            this.button_Action.Margin = new System.Windows.Forms.Padding(4);
            this.button_Action.Name = "button_Action";
            this.button_Action.Size = new System.Drawing.Size(120, 39);
            this.button_Action.TabIndex = 4;
            this.button_Action.Text = "执行";
            this.button_Action.UseVisualStyleBackColor = true;
            // 
            // button_Compile
            // 
            this.button_Compile.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button_Compile.Location = new System.Drawing.Point(865, 424);
            this.button_Compile.Margin = new System.Windows.Forms.Padding(4);
            this.button_Compile.Name = "button_Compile";
            this.button_Compile.Size = new System.Drawing.Size(120, 39);
            this.button_Compile.TabIndex = 3;
            this.button_Compile.Text = "编译";
            this.button_Compile.UseVisualStyleBackColor = true;
            // 
            // FrmScriptCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 615);
            this.Controls.Add(this.button_Action);
            this.Controls.Add(this.button_Compile);
            this.Controls.Add(this.richTextBox_Res);
            this.Controls.Add(this.panel_CodeEdit);
            this.Name = "FrmScriptCode";
            this.Text = "FrmScriptCode";
            this.panel_CodeEdit.ResumeLayout(false);
            this.PanelSearch.ResumeLayout(false);
            this.PanelSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_CodeEdit;
        private System.Windows.Forms.Panel PanelSearch;
        private System.Windows.Forms.Button BtnNextSearch;
        private System.Windows.Forms.Button BtnPrevSearch;
        private System.Windows.Forms.Button BtnCloseSearch;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.RichTextBox richTextBox_Res;
        private System.Windows.Forms.Button button_Action;
        private System.Windows.Forms.Button button_Compile;
    }
}