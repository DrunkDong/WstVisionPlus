namespace WstVisionPlus
{
    partial class FrmUserAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.uiTextBox_UserName = new Sunny.UI.UITextBox();
            this.uiTextBox_UserPassWords = new Sunny.UI.UITextBox();
            this.uiComboBox_UserLevel = new Sunny.UI.UIComboBox();
            this.uiSymbolButton_Cancel = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton_OK = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label1.Location = new System.Drawing.Point(14, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label2.Location = new System.Drawing.Point(14, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.label3.Location = new System.Drawing.Point(14, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Authority:";
            // 
            // uiTextBox_UserName
            // 
            this.uiTextBox_UserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_UserName.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.uiTextBox_UserName.Location = new System.Drawing.Point(167, 56);
            this.uiTextBox_UserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_UserName.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox_UserName.Name = "uiTextBox_UserName";
            this.uiTextBox_UserName.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_UserName.RectColor = System.Drawing.Color.Teal;
            this.uiTextBox_UserName.ShowText = false;
            this.uiTextBox_UserName.Size = new System.Drawing.Size(208, 40);
            this.uiTextBox_UserName.TabIndex = 4;
            this.uiTextBox_UserName.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_UserName.Watermark = "";
            // 
            // uiTextBox_UserPassWords
            // 
            this.uiTextBox_UserPassWords.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_UserPassWords.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.uiTextBox_UserPassWords.Location = new System.Drawing.Point(167, 105);
            this.uiTextBox_UserPassWords.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_UserPassWords.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox_UserPassWords.Name = "uiTextBox_UserPassWords";
            this.uiTextBox_UserPassWords.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_UserPassWords.RectColor = System.Drawing.Color.Teal;
            this.uiTextBox_UserPassWords.ShowText = false;
            this.uiTextBox_UserPassWords.Size = new System.Drawing.Size(208, 40);
            this.uiTextBox_UserPassWords.TabIndex = 5;
            this.uiTextBox_UserPassWords.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_UserPassWords.Watermark = "";
            // 
            // uiComboBox_UserLevel
            // 
            this.uiComboBox_UserLevel.DataSource = null;
            this.uiComboBox_UserLevel.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox_UserLevel.FillColor = System.Drawing.Color.White;
            this.uiComboBox_UserLevel.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.uiComboBox_UserLevel.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uiComboBox_UserLevel.Items.AddRange(new object[] {
            "操作工",
            "工程师",
            "管理员"});
            this.uiComboBox_UserLevel.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox_UserLevel.Location = new System.Drawing.Point(167, 154);
            this.uiComboBox_UserLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_UserLevel.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_UserLevel.Name = "uiComboBox_UserLevel";
            this.uiComboBox_UserLevel.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_UserLevel.RectColor = System.Drawing.Color.Teal;
            this.uiComboBox_UserLevel.Size = new System.Drawing.Size(208, 40);
            this.uiComboBox_UserLevel.TabIndex = 6;
            this.uiComboBox_UserLevel.Text = "操作工";
            this.uiComboBox_UserLevel.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_UserLevel.Watermark = "";
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
            this.uiSymbolButton_Cancel.Location = new System.Drawing.Point(213, 227);
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
            this.uiSymbolButton_Cancel.TabIndex = 112;
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
            this.uiSymbolButton_OK.Location = new System.Drawing.Point(62, 227);
            this.uiSymbolButton_OK.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_OK.Name = "uiSymbolButton_OK";
            this.uiSymbolButton_OK.RectColor = System.Drawing.Color.Teal;
            this.uiSymbolButton_OK.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiSymbolButton_OK.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_OK.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_OK.Size = new System.Drawing.Size(124, 44);
            this.uiSymbolButton_OK.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton_OK.StyleCustomMode = true;
            this.uiSymbolButton_OK.TabIndex = 111;
            this.uiSymbolButton_OK.Text = "Sure";
            this.uiSymbolButton_OK.TipsFont = new System.Drawing.Font("微软雅黑", 14F);
            this.uiSymbolButton_OK.Click += new System.EventHandler(this.UiSymbolButton_OK_Click);
            // 
            // FrmUserAdd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(402, 311);
            this.ControlBox = false;
            this.ControlBoxFillHoverColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.uiSymbolButton_Cancel);
            this.Controls.Add(this.uiSymbolButton_OK);
            this.Controls.Add(this.uiComboBox_UserLevel);
            this.Controls.Add(this.uiTextBox_UserPassWords);
            this.Controls.Add(this.uiTextBox_UserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserAdd";
            this.RectColor = System.Drawing.Color.Teal;
            this.ShowInTaskbar = false;
            this.Text = "新增用户";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.TitleColor = System.Drawing.Color.Teal;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FrmUserAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UITextBox uiTextBox_UserName;
        private Sunny.UI.UITextBox uiTextBox_UserPassWords;
        private Sunny.UI.UIComboBox uiComboBox_UserLevel;
        private Sunny.UI.UISymbolButton uiSymbolButton_Cancel;
        private Sunny.UI.UISymbolButton uiSymbolButton_OK;
    }
}