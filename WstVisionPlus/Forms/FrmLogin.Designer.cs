namespace WstVisionPlus
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.uiAvatar1 = new Sunny.UI.UIAvatar();
            this.uiLine4 = new Sunny.UI.UILine();
            this.uiTextBox_Name = new Sunny.UI.UITextBox();
            this.uiTextBox_PassWord = new Sunny.UI.UITextBox();
            this.uiSymbolButton_Cancel = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton_OK = new Sunny.UI.UISymbolButton();
            this.SuspendLayout();
            // 
            // uiAvatar1
            // 
            this.uiAvatar1.AvatarSize = 55;
            this.uiAvatar1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiAvatar1.ForeColor = System.Drawing.Color.Teal;
            this.uiAvatar1.Location = new System.Drawing.Point(90, 38);
            this.uiAvatar1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiAvatar1.Name = "uiAvatar1";
            this.uiAvatar1.Size = new System.Drawing.Size(101, 88);
            this.uiAvatar1.SymbolSize = 48;
            this.uiAvatar1.TabIndex = 25;
            this.uiAvatar1.Text = "uiAvatar1";
            // 
            // uiLine4
            // 
            this.uiLine4.BackColor = System.Drawing.Color.Transparent;
            this.uiLine4.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine4.LineColor = System.Drawing.Color.Teal;
            this.uiLine4.Location = new System.Drawing.Point(24, 117);
            this.uiLine4.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(239, 20);
            this.uiLine4.TabIndex = 106;
            this.uiLine4.Text = "User";
            // 
            // uiTextBox_Name
            // 
            this.uiTextBox_Name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_Name.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox_Name.Location = new System.Drawing.Point(24, 149);
            this.uiTextBox_Name.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_Name.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox_Name.Name = "uiTextBox_Name";
            this.uiTextBox_Name.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_Name.RectColor = System.Drawing.Color.Teal;
            this.uiTextBox_Name.ScrollBarColor = System.Drawing.Color.Teal;
            this.uiTextBox_Name.ScrollBarStyleInherited = false;
            this.uiTextBox_Name.ShowText = false;
            this.uiTextBox_Name.Size = new System.Drawing.Size(239, 29);
            this.uiTextBox_Name.Symbol = 61447;
            this.uiTextBox_Name.SymbolColor = System.Drawing.Color.Teal;
            this.uiTextBox_Name.TabIndex = 107;
            this.uiTextBox_Name.Text = "admin";
            this.uiTextBox_Name.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_Name.Watermark = "";
            // 
            // uiTextBox_PassWord
            // 
            this.uiTextBox_PassWord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_PassWord.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox_PassWord.Location = new System.Drawing.Point(24, 188);
            this.uiTextBox_PassWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_PassWord.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox_PassWord.Name = "uiTextBox_PassWord";
            this.uiTextBox_PassWord.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_PassWord.PasswordChar = '*';
            this.uiTextBox_PassWord.RectColor = System.Drawing.Color.Teal;
            this.uiTextBox_PassWord.ScrollBarColor = System.Drawing.Color.Teal;
            this.uiTextBox_PassWord.ScrollBarStyleInherited = false;
            this.uiTextBox_PassWord.ShowText = false;
            this.uiTextBox_PassWord.Size = new System.Drawing.Size(239, 29);
            this.uiTextBox_PassWord.Symbol = 61475;
            this.uiTextBox_PassWord.SymbolColor = System.Drawing.Color.Teal;
            this.uiTextBox_PassWord.TabIndex = 108;
            this.uiTextBox_PassWord.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_PassWord.Watermark = "";
            this.uiTextBox_PassWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UiTextBox_PassWord_KeyDown);
            // 
            // uiSymbolButton_Cancel
            // 
            this.uiSymbolButton_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_Cancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton_Cancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton_Cancel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.uiSymbolButton_Cancel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Cancel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Cancel.Font = new System.Drawing.Font("宋体", 12F);
            this.uiSymbolButton_Cancel.Location = new System.Drawing.Point(148, 238);
            this.uiSymbolButton_Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_Cancel.Name = "uiSymbolButton_Cancel";
            this.uiSymbolButton_Cancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton_Cancel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.uiSymbolButton_Cancel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Cancel.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Cancel.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton_Cancel.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton_Cancel.StyleCustomMode = true;
            this.uiSymbolButton_Cancel.Symbol = 61453;
            this.uiSymbolButton_Cancel.TabIndex = 110;
            this.uiSymbolButton_Cancel.Text = "Cancel";
            this.uiSymbolButton_Cancel.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
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
            this.uiSymbolButton_OK.Font = new System.Drawing.Font("宋体", 12F);
            this.uiSymbolButton_OK.Location = new System.Drawing.Point(34, 238);
            this.uiSymbolButton_OK.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_OK.Name = "uiSymbolButton_OK";
            this.uiSymbolButton_OK.RectColor = System.Drawing.Color.Teal;
            this.uiSymbolButton_OK.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiSymbolButton_OK.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_OK.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_OK.Size = new System.Drawing.Size(100, 35);
            this.uiSymbolButton_OK.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton_OK.StyleCustomMode = true;
            this.uiSymbolButton_OK.TabIndex = 109;
            this.uiSymbolButton_OK.Text = "Login";
            this.uiSymbolButton_OK.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSymbolButton_OK.Click += new System.EventHandler(this.UiSymbolButton_OK_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(282, 306);
            this.ControlBox = false;
            this.ControlBoxFillHoverColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.uiSymbolButton_Cancel);
            this.Controls.Add(this.uiSymbolButton_OK);
            this.Controls.Add(this.uiTextBox_PassWord);
            this.Controls.Add(this.uiTextBox_Name);
            this.Controls.Add(this.uiLine4);
            this.Controls.Add(this.uiAvatar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "FrmLogin";
            this.RectColor = System.Drawing.Color.Teal;
            this.Text = "\nUser Login";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.TitleColor = System.Drawing.Color.Teal;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIAvatar uiAvatar1;
        private Sunny.UI.UILine uiLine4;
        private Sunny.UI.UITextBox uiTextBox_Name;
        private Sunny.UI.UITextBox uiTextBox_PassWord;
        private Sunny.UI.UISymbolButton uiSymbolButton_Cancel;
        private Sunny.UI.UISymbolButton uiSymbolButton_OK;
    }
}