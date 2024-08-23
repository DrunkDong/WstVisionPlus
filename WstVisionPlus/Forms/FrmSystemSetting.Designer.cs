namespace WstVisionPlus
{
    partial class FrmSystemSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSystemSetting));
            this.uiButton_Save = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // uiButton_Save
            // 
            this.uiButton_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_Save.FillColor = System.Drawing.Color.Teal;
            this.uiButton_Save.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_Save.Location = new System.Drawing.Point(708, 398);
            this.uiButton_Save.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_Save.Name = "uiButton_Save";
            this.uiButton_Save.RectColor = System.Drawing.Color.Teal;
            this.uiButton_Save.Size = new System.Drawing.Size(73, 47);
            this.uiButton_Save.TabIndex = 9;
            this.uiButton_Save.Text = "保存";
            this.uiButton_Save.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_Save.Click += new System.EventHandler(this.UiButton_Save_Click);
            // 
            // FrmSystemSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(785, 450);
            this.Controls.Add(this.uiButton_Save);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSystemSetting";
            this.RectColor = System.Drawing.Color.Teal;
            this.Text = "System Settings";
            this.TitleColor = System.Drawing.Color.Teal;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FrmSystemSetting_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private Sunny.UI.UIButton uiButton_Save;
    }
}