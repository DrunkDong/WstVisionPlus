namespace WstVisionPlus
{
    partial class FrmCommunicate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCommunicate));
            this.uiLine4 = new Sunny.UI.UILine();
            this.dataGridView_SerialPort = new System.Windows.Forms.DataGridView();
            this.uiLine1 = new Sunny.UI.UILine();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SerialPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // uiLine4
            // 
            this.uiLine4.BackColor = System.Drawing.Color.Transparent;
            this.uiLine4.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine4.LineColor = System.Drawing.Color.Teal;
            this.uiLine4.Location = new System.Drawing.Point(3, 38);
            this.uiLine4.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine4.Name = "uiLine4";
            this.uiLine4.Size = new System.Drawing.Size(1074, 20);
            this.uiLine4.TabIndex = 107;
            this.uiLine4.Text = "串口设置";
            this.uiLine4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView_SerialPort
            // 
            this.dataGridView_SerialPort.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SerialPort.Location = new System.Drawing.Point(3, 61);
            this.dataGridView_SerialPort.Name = "dataGridView_SerialPort";
            this.dataGridView_SerialPort.RowHeadersWidth = 51;
            this.dataGridView_SerialPort.RowTemplate.Height = 23;
            this.dataGridView_SerialPort.Size = new System.Drawing.Size(1074, 222);
            this.dataGridView_SerialPort.TabIndex = 108;
            // 
            // uiLine1
            // 
            this.uiLine1.BackColor = System.Drawing.Color.Transparent;
            this.uiLine1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLine1.LineColor = System.Drawing.Color.Teal;
            this.uiLine1.Location = new System.Drawing.Point(3, 292);
            this.uiLine1.MinimumSize = new System.Drawing.Size(16, 16);
            this.uiLine1.Name = "uiLine1";
            this.uiLine1.Size = new System.Drawing.Size(1074, 20);
            this.uiLine1.TabIndex = 109;
            this.uiLine1.Text = "Scoket";
            this.uiLine1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 315);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1074, 233);
            this.dataGridView2.TabIndex = 110;
            // 
            // FrmCommunicate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1080, 554);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.uiLine1);
            this.Controls.Add(this.dataGridView_SerialPort);
            this.Controls.Add(this.uiLine4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCommunicate";
            this.RectColor = System.Drawing.Color.Teal;
            this.Text = "通讯设定界面";
            this.TextAlignment = System.Drawing.StringAlignment.Center;
            this.TitleColor = System.Drawing.Color.Teal;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.FrmCommunicate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SerialPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UILine uiLine4;
        private System.Windows.Forms.DataGridView dataGridView_SerialPort;
        private Sunny.UI.UILine uiLine1;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}