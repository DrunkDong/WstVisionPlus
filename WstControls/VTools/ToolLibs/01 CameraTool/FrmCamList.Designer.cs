using System.Drawing;

namespace WstControls
{
    partial class FrmCamList
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
            this.dataGridView_CamList = new System.Windows.Forms.DataGridView();
            this.uiSymbolButton_Cancel = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton_OK = new Sunny.UI.UISymbolButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CamList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_CamList
            // 
            this.dataGridView_CamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CamList.Location = new System.Drawing.Point(3, 38);
            this.dataGridView_CamList.MultiSelect = false;
            this.dataGridView_CamList.Name = "dataGridView_CamList";
            this.dataGridView_CamList.RowHeadersWidth = 51;
            this.dataGridView_CamList.RowTemplate.Height = 23;
            this.dataGridView_CamList.Size = new System.Drawing.Size(608, 469);
            this.dataGridView_CamList.TabIndex = 122;
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
            this.uiSymbolButton_Cancel.Location = new System.Drawing.Point(340, 515);
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
            this.uiSymbolButton_Cancel.TabIndex = 124;
            this.uiSymbolButton_Cancel.Text = "Cancel";
            this.uiSymbolButton_Cancel.TipsFont = new System.Drawing.Font("微软雅黑", 14F);
            this.uiSymbolButton_Cancel.Click += new System.EventHandler(this.uiSymbolButton_Cancel_Click);
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
            this.uiSymbolButton_OK.Location = new System.Drawing.Point(176, 515);
            this.uiSymbolButton_OK.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_OK.Name = "uiSymbolButton_OK";
            this.uiSymbolButton_OK.RectColor = System.Drawing.Color.Teal;
            this.uiSymbolButton_OK.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiSymbolButton_OK.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_OK.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_OK.Size = new System.Drawing.Size(124, 44);
            this.uiSymbolButton_OK.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton_OK.StyleCustomMode = true;
            this.uiSymbolButton_OK.TabIndex = 123;
            this.uiSymbolButton_OK.Text = "Sure";
            this.uiSymbolButton_OK.TipsFont = new System.Drawing.Font("微软雅黑", 14F);
            this.uiSymbolButton_OK.Click += new System.EventHandler(this.uiSymbolButton_OK_Click);
            // 
            // FrmCamList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(614, 570);
            this.Controls.Add(this.uiSymbolButton_Cancel);
            this.Controls.Add(this.uiSymbolButton_OK);
            this.Controls.Add(this.dataGridView_CamList);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCamList";
            this.RectColor = System.Drawing.Color.Teal;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera List";
            this.TitleColor = System.Drawing.Color.Teal;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.Frm_Camera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CamList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_CamList;
        private Sunny.UI.UISymbolButton uiSymbolButton_Cancel;
        private Sunny.UI.UISymbolButton uiSymbolButton_OK;
    }
}