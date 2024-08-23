namespace WeiControls
{
    partial class UNumericUpDownColor
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.nud_value = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_value)).BeginInit();
            this.SuspendLayout();
            // 
            // nud_value
            // 
            this.nud_value.BackColor = System.Drawing.Color.White;
            this.nud_value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nud_value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nud_value.Font = new System.Drawing.Font("宋体", 13F);
            this.nud_value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.nud_value.Location = new System.Drawing.Point(0, 0);
            this.nud_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.nud_value.Name = "nud_value";
            this.nud_value.Size = new System.Drawing.Size(144, 23);
            this.nud_value.TabIndex = 8;
            this.nud_value.ValueChanged += new System.EventHandler(this.nud_value_ValueChanged);
            // 
            // UNumericUpDownColor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.nud_value);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximumSize = new System.Drawing.Size(300, 26);
            this.MinimumSize = new System.Drawing.Size(50, 26);
            this.Name = "UNumericUpDownColor";
            this.Size = new System.Drawing.Size(144, 26);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UNumericUpDownColor_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.nud_value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NumericUpDown nud_value;
    }
}
