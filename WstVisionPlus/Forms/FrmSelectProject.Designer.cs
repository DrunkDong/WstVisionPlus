namespace WstVisionPlus
{
    partial class FrmSelectProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSelectProject));
            this.comboBox_SelectProject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uiSymbolButton_Cancel = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton_OK = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // comboBox_SelectProject
            // 
            this.comboBox_SelectProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SelectProject.Font = new System.Drawing.Font("微软雅黑", 22F);
            this.comboBox_SelectProject.FormattingEnabled = true;
            this.comboBox_SelectProject.Location = new System.Drawing.Point(32, 103);
            this.comboBox_SelectProject.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_SelectProject.Name = "comboBox_SelectProject";
            this.comboBox_SelectProject.Size = new System.Drawing.Size(412, 46);
            this.comboBox_SelectProject.TabIndex = 26;
            this.comboBox_SelectProject.SelectedIndexChanged += new System.EventHandler(this.ComboBox_SelectProject_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(149, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 35);
            this.label1.TabIndex = 23;
            this.label1.Text = "工程名称";
            // 
            // uiSymbolButton_Cancel
            // 
            this.uiSymbolButton_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_Cancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton_Cancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton_Cancel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.uiSymbolButton_Cancel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Cancel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Cancel.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.uiSymbolButton_Cancel.Location = new System.Drawing.Point(84, 176);
            this.uiSymbolButton_Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_Cancel.Name = "uiSymbolButton_Cancel";
            this.uiSymbolButton_Cancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton_Cancel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.uiSymbolButton_Cancel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Cancel.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Cancel.Size = new System.Drawing.Size(124, 44);
            this.uiSymbolButton_Cancel.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton_Cancel.StyleCustomMode = true;
            this.uiSymbolButton_Cancel.Symbol = 61453;
            this.uiSymbolButton_Cancel.TabIndex = 116;
            this.uiSymbolButton_Cancel.Text = "Cancel";
            this.uiSymbolButton_Cancel.TipsFont = new System.Drawing.Font("微软雅黑", 14F);
            this.uiSymbolButton_Cancel.Click += new System.EventHandler(this.UiSymbolButton_Cancel_Click);
            // 
            // uiSymbolButton_OK
            // 
            this.uiSymbolButton_OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_OK.FillColor = System.Drawing.Color.Teal;
            this.uiSymbolButton_OK.FillColor2 = System.Drawing.Color.Teal;
            this.uiSymbolButton_OK.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiSymbolButton_OK.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_OK.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_OK.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.uiSymbolButton_OK.Location = new System.Drawing.Point(244, 176);
            this.uiSymbolButton_OK.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_OK.Name = "uiSymbolButton_OK";
            this.uiSymbolButton_OK.RectColor = System.Drawing.Color.Teal;
            this.uiSymbolButton_OK.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiSymbolButton_OK.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_OK.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_OK.Size = new System.Drawing.Size(124, 44);
            this.uiSymbolButton_OK.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton_OK.StyleCustomMode = true;
            this.uiSymbolButton_OK.TabIndex = 115;
            this.uiSymbolButton_OK.Text = "Sure";
            this.uiSymbolButton_OK.TipsFont = new System.Drawing.Font("微软雅黑", 14F);
            this.uiSymbolButton_OK.Click += new System.EventHandler(this.UiSymbolButton_OK_Click);
            // 
            // FrmSelectProject
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(472, 258);
            this.ControlBox = false;
            this.Controls.Add(this.uiSymbolButton_Cancel);
            this.Controls.Add(this.uiSymbolButton_OK);
            this.Controls.Add(this.comboBox_SelectProject);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSelectProject";
            this.RectColor = System.Drawing.Color.Teal;
            this.Text = "选定工程";
            this.TitleColor = System.Drawing.Color.Teal;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 558, 237);
            this.Load += new System.EventHandler(this.FrmSelectProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_SelectProject;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UISymbolButton uiSymbolButton_Cancel;
        private Sunny.UI.UISymbolButton uiSymbolButton_OK;
    }
}