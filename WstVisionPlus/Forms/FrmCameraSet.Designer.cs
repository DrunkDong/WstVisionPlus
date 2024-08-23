namespace WstVisionPlus
{
    partial class FrmCameraSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCameraSet));
            this.panel_Cam = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uiIntegerUpDown_ChangeExposure = new Sunny.UI.UIIntegerUpDown();
            this.uiDoubleUpDown_ChangeGain = new Sunny.UI.UIDoubleUpDown();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.uiIntegerUpDown_ChangeTriggerDelay = new Sunny.UI.UIIntegerUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.uiButton_SaveParam = new Sunny.UI.UIButton();
            this.uiButton_Start = new Sunny.UI.UIButton();
            this.uiButton_Stop = new Sunny.UI.UIButton();
            this.label_Project = new System.Windows.Forms.Label();
            this.uiTitlePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Cam
            // 
            this.panel_Cam.Location = new System.Drawing.Point(4, 39);
            this.panel_Cam.Name = "panel_Cam";
            this.panel_Cam.Size = new System.Drawing.Size(885, 644);
            this.panel_Cam.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "曝光:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "增益:";
            // 
            // uiIntegerUpDown_ChangeExposure
            // 
            this.uiIntegerUpDown_ChangeExposure.Font = new System.Drawing.Font("宋体", 12F);
            this.uiIntegerUpDown_ChangeExposure.Location = new System.Drawing.Point(136, 44);
            this.uiIntegerUpDown_ChangeExposure.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiIntegerUpDown_ChangeExposure.Maximum = 1000000;
            this.uiIntegerUpDown_ChangeExposure.Minimum = 0;
            this.uiIntegerUpDown_ChangeExposure.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiIntegerUpDown_ChangeExposure.Name = "uiIntegerUpDown_ChangeExposure";
            this.uiIntegerUpDown_ChangeExposure.RectColor = System.Drawing.Color.Teal;
            this.uiIntegerUpDown_ChangeExposure.ShowText = false;
            this.uiIntegerUpDown_ChangeExposure.Size = new System.Drawing.Size(146, 29);
            this.uiIntegerUpDown_ChangeExposure.TabIndex = 36;
            this.uiIntegerUpDown_ChangeExposure.Text = null;
            this.uiIntegerUpDown_ChangeExposure.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiIntegerUpDown_ChangeExposure.Value = 10;
            this.uiIntegerUpDown_ChangeExposure.ValueChanged += new Sunny.UI.UIIntegerUpDown.OnValueChanged(this.UiIntegerUpDown_ChangeExposure_ValueChanged);
            // 
            // uiDoubleUpDown_ChangeGain
            // 
            this.uiDoubleUpDown_ChangeGain.DecimalPlaces = 0;
            this.uiDoubleUpDown_ChangeGain.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDoubleUpDown_ChangeGain.Location = new System.Drawing.Point(136, 79);
            this.uiDoubleUpDown_ChangeGain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiDoubleUpDown_ChangeGain.Maximum = 100D;
            this.uiDoubleUpDown_ChangeGain.Minimum = 0D;
            this.uiDoubleUpDown_ChangeGain.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiDoubleUpDown_ChangeGain.Name = "uiDoubleUpDown_ChangeGain";
            this.uiDoubleUpDown_ChangeGain.RectColor = System.Drawing.Color.Teal;
            this.uiDoubleUpDown_ChangeGain.ShowText = false;
            this.uiDoubleUpDown_ChangeGain.Size = new System.Drawing.Size(147, 29);
            this.uiDoubleUpDown_ChangeGain.Step = 1D;
            this.uiDoubleUpDown_ChangeGain.TabIndex = 37;
            this.uiDoubleUpDown_ChangeGain.Text = null;
            this.uiDoubleUpDown_ChangeGain.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiDoubleUpDown_ChangeGain.ValueChanged += new Sunny.UI.UIDoubleUpDown.OnValueChanged(this.UiDoubleUpDown_ChangeGain_ValueChanged);
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.uiIntegerUpDown_ChangeTriggerDelay);
            this.uiTitlePanel1.Controls.Add(this.label3);
            this.uiTitlePanel1.Controls.Add(this.uiDoubleUpDown_ChangeGain);
            this.uiTitlePanel1.Controls.Add(this.label1);
            this.uiTitlePanel1.Controls.Add(this.uiIntegerUpDown_ChangeExposure);
            this.uiTitlePanel1.Controls.Add(this.label2);
            this.uiTitlePanel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTitlePanel1.Location = new System.Drawing.Point(895, 39);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.RectColor = System.Drawing.Color.Teal;
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(305, 164);
            this.uiTitlePanel1.TabIndex = 38;
            this.uiTitlePanel1.Text = "参数设定";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTitlePanel1.TitleColor = System.Drawing.Color.Teal;
            // 
            // uiIntegerUpDown_ChangeTriggerDelay
            // 
            this.uiIntegerUpDown_ChangeTriggerDelay.Font = new System.Drawing.Font("宋体", 12F);
            this.uiIntegerUpDown_ChangeTriggerDelay.Location = new System.Drawing.Point(137, 114);
            this.uiIntegerUpDown_ChangeTriggerDelay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiIntegerUpDown_ChangeTriggerDelay.Maximum = 1000000;
            this.uiIntegerUpDown_ChangeTriggerDelay.Minimum = 0;
            this.uiIntegerUpDown_ChangeTriggerDelay.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiIntegerUpDown_ChangeTriggerDelay.Name = "uiIntegerUpDown_ChangeTriggerDelay";
            this.uiIntegerUpDown_ChangeTriggerDelay.RectColor = System.Drawing.Color.Teal;
            this.uiIntegerUpDown_ChangeTriggerDelay.ShowText = false;
            this.uiIntegerUpDown_ChangeTriggerDelay.Size = new System.Drawing.Size(146, 29);
            this.uiIntegerUpDown_ChangeTriggerDelay.TabIndex = 39;
            this.uiIntegerUpDown_ChangeTriggerDelay.Text = null;
            this.uiIntegerUpDown_ChangeTriggerDelay.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiIntegerUpDown_ChangeTriggerDelay.Value = 10;
            this.uiIntegerUpDown_ChangeTriggerDelay.ValueChanged += new Sunny.UI.UIIntegerUpDown.OnValueChanged(this.UiIntegerUpDown_ChangeTriggerDelay_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "触发延时:";
            // 
            // uiButton_SaveParam
            // 
            this.uiButton_SaveParam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_SaveParam.FillColor = System.Drawing.Color.Teal;
            this.uiButton_SaveParam.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_SaveParam.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_SaveParam.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_SaveParam.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_SaveParam.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_SaveParam.Location = new System.Drawing.Point(1100, 691);
            this.uiButton_SaveParam.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_SaveParam.Name = "uiButton_SaveParam";
            this.uiButton_SaveParam.RectColor = System.Drawing.Color.Teal;
            this.uiButton_SaveParam.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_SaveParam.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_SaveParam.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_SaveParam.Size = new System.Drawing.Size(100, 35);
            this.uiButton_SaveParam.TabIndex = 39;
            this.uiButton_SaveParam.Text = "保存";
            this.uiButton_SaveParam.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_SaveParam.Click += new System.EventHandler(this.UiButton_SaveParam_Click);
            // 
            // uiButton_Start
            // 
            this.uiButton_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_Start.FillColor = System.Drawing.Color.Teal;
            this.uiButton_Start.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Start.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Start.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Start.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Start.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_Start.Location = new System.Drawing.Point(3, 691);
            this.uiButton_Start.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_Start.Name = "uiButton_Start";
            this.uiButton_Start.RectColor = System.Drawing.Color.Teal;
            this.uiButton_Start.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Start.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Start.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Start.Size = new System.Drawing.Size(100, 35);
            this.uiButton_Start.TabIndex = 40;
            this.uiButton_Start.Text = "开始采集";
            this.uiButton_Start.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_Start.Click += new System.EventHandler(this.UiButton_Start_Click);
            // 
            // uiButton_Stop
            // 
            this.uiButton_Stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_Stop.Enabled = false;
            this.uiButton_Stop.FillColor = System.Drawing.Color.Teal;
            this.uiButton_Stop.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Stop.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Stop.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Stop.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Stop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_Stop.Location = new System.Drawing.Point(119, 691);
            this.uiButton_Stop.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_Stop.Name = "uiButton_Stop";
            this.uiButton_Stop.RectColor = System.Drawing.Color.Teal;
            this.uiButton_Stop.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiButton_Stop.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Stop.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiButton_Stop.Size = new System.Drawing.Size(100, 35);
            this.uiButton_Stop.TabIndex = 41;
            this.uiButton_Stop.Text = "停止采集";
            this.uiButton_Stop.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_Stop.Click += new System.EventHandler(this.UiButton_Stop_Click);
            // 
            // label_Project
            // 
            this.label_Project.AutoSize = true;
            this.label_Project.Font = new System.Drawing.Font("楷体", 16F, System.Drawing.FontStyle.Bold);
            this.label_Project.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_Project.Location = new System.Drawing.Point(471, 696);
            this.label_Project.Name = "label_Project";
            this.label_Project.Size = new System.Drawing.Size(146, 27);
            this.label_Project.TabIndex = 96;
            this.label_Project.Text = "Project：";
            // 
            // FrmCameraSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1204, 733);
            this.ControlBoxFillHoverColor = System.Drawing.Color.Teal;
            this.Controls.Add(this.label_Project);
            this.Controls.Add(this.uiButton_Stop);
            this.Controls.Add(this.uiButton_Start);
            this.Controls.Add(this.uiButton_SaveParam);
            this.Controls.Add(this.uiTitlePanel1);
            this.Controls.Add(this.panel_Cam);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCameraSet";
            this.RectColor = System.Drawing.Color.Teal;
            this.Text = "相机设定界面";
            this.TitleColor = System.Drawing.Color.Teal;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCameraSet_FormClosing);
            this.Load += new System.EventHandler(this.FrmCameraSet_Load);
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTitlePanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_Cam;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UIIntegerUpDown uiIntegerUpDown_ChangeExposure;
        private Sunny.UI.UIDoubleUpDown uiDoubleUpDown_ChangeGain;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UIIntegerUpDown uiIntegerUpDown_ChangeTriggerDelay;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UIButton uiButton_SaveParam;
        private Sunny.UI.UIButton uiButton_Start;
        private Sunny.UI.UIButton uiButton_Stop;
        private System.Windows.Forms.Label label_Project;
    }
}