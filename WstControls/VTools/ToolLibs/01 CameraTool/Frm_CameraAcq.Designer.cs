using System.Drawing;

namespace WstControls
{
    partial class Frm_CameraAcq
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.uiSwitch1 = new Sunny.UI.UISwitch();
            this.label_runTime = new System.Windows.Forms.Label();
            this.lbl_toolTip = new System.Windows.Forms.Label();
            this.label_State = new System.Windows.Forms.Label();
            this.uiButton_RunTool = new Sunny.UI.UIButton();
            this.uiButton_Sure = new Sunny.UI.UIButton();
            this.uiButton_Cancel = new Sunny.UI.UIButton();
            this.uTabControl_Setting = new WstControls.UTabControl();
            this.tabPage_Param = new System.Windows.Forms.TabPage();
            this.uiTitlePanel2 = new Sunny.UI.UITitlePanel();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.uiSymbolButton_Remove = new Sunny.UI.UISymbolButton();
            this.uiSymbolButton_Select = new Sunny.UI.UISymbolButton();
            this.textBox_SN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.uTabControl_Setting.SuspendLayout();
            this.tabPage_Param.SuspendLayout();
            this.uiTitlePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(407, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 543);
            this.panel1.TabIndex = 0;
            // 
            // uiSwitch1
            // 
            this.uiSwitch1.Active = true;
            this.uiSwitch1.ActiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiSwitch1.ActiveText = "Enable";
            this.uiSwitch1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiSwitch1.InActiveText = "Disable";
            this.uiSwitch1.Location = new System.Drawing.Point(7, 591);
            this.uiSwitch1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSwitch1.Name = "uiSwitch1";
            this.uiSwitch1.Size = new System.Drawing.Size(96, 38);
            this.uiSwitch1.TabIndex = 2;
            this.uiSwitch1.Text = "uiSwitch1";
            // 
            // label_runTime
            // 
            this.label_runTime.AutoSize = true;
            this.label_runTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_runTime.Location = new System.Drawing.Point(122, 591);
            this.label_runTime.Name = "label_runTime";
            this.label_runTime.Size = new System.Drawing.Size(87, 20);
            this.label_runTime.TabIndex = 117;
            this.label_runTime.Text = "Cost：0ms";
            // 
            // lbl_toolTip
            // 
            this.lbl_toolTip.AutoSize = true;
            this.lbl_toolTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_toolTip.Location = new System.Drawing.Point(122, 591);
            this.lbl_toolTip.Name = "lbl_toolTip";
            this.lbl_toolTip.Size = new System.Drawing.Size(69, 20);
            this.lbl_toolTip.TabIndex = 116;
            this.lbl_toolTip.Text = "状态：无";
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_State.Location = new System.Drawing.Point(122, 613);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(75, 20);
            this.label_State.TabIndex = 118;
            this.label_State.Text = "state：无";
            // 
            // uiButton_RunTool
            // 
            this.uiButton_RunTool.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_RunTool.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiButton_RunTool.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiButton_RunTool.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(146)))), ((int)(((byte)(184)))));
            this.uiButton_RunTool.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_RunTool.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_RunTool.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_RunTool.Location = new System.Drawing.Point(677, 596);
            this.uiButton_RunTool.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_RunTool.Name = "uiButton_RunTool";
            this.uiButton_RunTool.Radius = 15;
            this.uiButton_RunTool.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiButton_RunTool.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(146)))), ((int)(((byte)(184)))));
            this.uiButton_RunTool.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_RunTool.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_RunTool.Size = new System.Drawing.Size(100, 35);
            this.uiButton_RunTool.TabIndex = 119;
            this.uiButton_RunTool.Text = "Run Once";
            this.uiButton_RunTool.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_RunTool.Click += new System.EventHandler(this.uiButton_RunTool_Click);
            // 
            // uiButton_Sure
            // 
            this.uiButton_Sure.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_Sure.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiButton_Sure.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiButton_Sure.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(146)))), ((int)(((byte)(184)))));
            this.uiButton_Sure.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_Sure.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_Sure.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_Sure.Location = new System.Drawing.Point(860, 596);
            this.uiButton_Sure.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_Sure.Name = "uiButton_Sure";
            this.uiButton_Sure.Radius = 15;
            this.uiButton_Sure.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiButton_Sure.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(146)))), ((int)(((byte)(184)))));
            this.uiButton_Sure.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_Sure.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_Sure.Size = new System.Drawing.Size(100, 35);
            this.uiButton_Sure.TabIndex = 120;
            this.uiButton_Sure.Text = "Save";
            this.uiButton_Sure.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uiButton_Cancel
            // 
            this.uiButton_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_Cancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiButton_Cancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiButton_Cancel.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(146)))), ((int)(((byte)(184)))));
            this.uiButton_Cancel.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_Cancel.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_Cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_Cancel.Location = new System.Drawing.Point(979, 596);
            this.uiButton_Cancel.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_Cancel.Name = "uiButton_Cancel";
            this.uiButton_Cancel.Radius = 15;
            this.uiButton_Cancel.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiButton_Cancel.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(146)))), ((int)(((byte)(184)))));
            this.uiButton_Cancel.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_Cancel.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(106)))), ((int)(((byte)(144)))));
            this.uiButton_Cancel.Size = new System.Drawing.Size(100, 35);
            this.uiButton_Cancel.TabIndex = 121;
            this.uiButton_Cancel.Text = "Cancel";
            this.uiButton_Cancel.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // uTabControl_Setting
            // 
            this.uTabControl_Setting.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uTabControl_Setting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(247)))), ((int)(((byte)(254)))));
            this.uTabControl_Setting.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(222)))), ((int)(((byte)(255)))));
            this.uTabControl_Setting.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uTabControl_Setting.Controls.Add(this.tabPage_Param);
            this.uTabControl_Setting.ItemSize = new System.Drawing.Size(65, 22);
            this.uTabControl_Setting.Location = new System.Drawing.Point(3, 39);
            this.uTabControl_Setting.Name = "uTabControl_Setting";
            this.uTabControl_Setting.SelectedIndex = 0;
            this.uTabControl_Setting.Size = new System.Drawing.Size(398, 543);
            this.uTabControl_Setting.TabIndex = 1;
            // 
            // tabPage_Param
            // 
            this.tabPage_Param.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.tabPage_Param.Controls.Add(this.uiTitlePanel2);
            this.tabPage_Param.Controls.Add(this.uiTitlePanel1);
            this.tabPage_Param.Font = new System.Drawing.Font("宋体", 10F);
            this.tabPage_Param.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Param.Name = "tabPage_Param";
            this.tabPage_Param.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Param.Size = new System.Drawing.Size(390, 513);
            this.tabPage_Param.TabIndex = 2;
            this.tabPage_Param.Text = "设置";
            // 
            // uiTitlePanel2
            // 
            this.uiTitlePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTitlePanel2.Font = new System.Drawing.Font("宋体", 11F);
            this.uiTitlePanel2.Location = new System.Drawing.Point(3, 124);
            this.uiTitlePanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel2.Name = "uiTitlePanel2";
            this.uiTitlePanel2.Radius = 0;
            this.uiTitlePanel2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel2.ShowText = false;
            this.uiTitlePanel2.Size = new System.Drawing.Size(384, 354);
            this.uiTitlePanel2.TabIndex = 13;
            this.uiTitlePanel2.Text = "相机参数设定";
            this.uiTitlePanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTitlePanel2.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel2.TitleHeight = 28;
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.uiSymbolButton_Remove);
            this.uiTitlePanel1.Controls.Add(this.uiSymbolButton_Select);
            this.uiTitlePanel1.Controls.Add(this.textBox_SN);
            this.uiTitlePanel1.Controls.Add(this.label1);
            this.uiTitlePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTitlePanel1.Font = new System.Drawing.Font("宋体", 11F);
            this.uiTitlePanel1.Location = new System.Drawing.Point(3, 3);
            this.uiTitlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.Radius = 0;
            this.uiTitlePanel1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.Size = new System.Drawing.Size(384, 121);
            this.uiTitlePanel1.TabIndex = 12;
            this.uiTitlePanel1.Text = "相机选择";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTitlePanel1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel1.TitleHeight = 28;
            // 
            // uiSymbolButton_Remove
            // 
            this.uiSymbolButton_Remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_Remove.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton_Remove.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton_Remove.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.uiSymbolButton_Remove.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Remove.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Remove.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.uiSymbolButton_Remove.Location = new System.Drawing.Point(283, 61);
            this.uiSymbolButton_Remove.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_Remove.Name = "uiSymbolButton_Remove";
            this.uiSymbolButton_Remove.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.uiSymbolButton_Remove.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(115)))), ((int)(((byte)(115)))));
            this.uiSymbolButton_Remove.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Remove.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.uiSymbolButton_Remove.Size = new System.Drawing.Size(90, 36);
            this.uiSymbolButton_Remove.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton_Remove.StyleCustomMode = true;
            this.uiSymbolButton_Remove.Symbol = 362189;
            this.uiSymbolButton_Remove.SymbolSize = 30;
            this.uiSymbolButton_Remove.TabIndex = 154;
            this.uiSymbolButton_Remove.Text = "移除";
            this.uiSymbolButton_Remove.TipsFont = new System.Drawing.Font("微软雅黑", 14F);
            this.uiSymbolButton_Remove.Click += new System.EventHandler(this.uiSymbolButton_Remove_Click);
            // 
            // uiSymbolButton_Select
            // 
            this.uiSymbolButton_Select.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiSymbolButton_Select.FillColor = System.Drawing.Color.Teal;
            this.uiSymbolButton_Select.FillColor2 = System.Drawing.Color.Teal;
            this.uiSymbolButton_Select.FillHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiSymbolButton_Select.FillPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_Select.FillSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_Select.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.uiSymbolButton_Select.Location = new System.Drawing.Point(180, 61);
            this.uiSymbolButton_Select.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiSymbolButton_Select.Name = "uiSymbolButton_Select";
            this.uiSymbolButton_Select.RectColor = System.Drawing.Color.Teal;
            this.uiSymbolButton_Select.RectHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.uiSymbolButton_Select.RectPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_Select.RectSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.uiSymbolButton_Select.Size = new System.Drawing.Size(90, 36);
            this.uiSymbolButton_Select.Style = Sunny.UI.UIStyle.Custom;
            this.uiSymbolButton_Select.StyleCustomMode = true;
            this.uiSymbolButton_Select.Symbol = 561890;
            this.uiSymbolButton_Select.SymbolSize = 30;
            this.uiSymbolButton_Select.TabIndex = 153;
            this.uiSymbolButton_Select.Text = "选定";
            this.uiSymbolButton_Select.TipsFont = new System.Drawing.Font("微软雅黑", 14F);
            this.uiSymbolButton_Select.Click += new System.EventHandler(this.uiSymbolButton_Select_Click);
            // 
            // textBox_SN
            // 
            this.textBox_SN.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.textBox_SN.Location = new System.Drawing.Point(13, 62);
            this.textBox_SN.Name = "textBox_SN";
            this.textBox_SN.ReadOnly = true;
            this.textBox_SN.Size = new System.Drawing.Size(155, 40);
            this.textBox_SN.TabIndex = 151;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 13F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 30);
            this.label1.TabIndex = 150;
            this.label1.Text = "相机序列号";
            // 
            // Frm_CameraAcq
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1085, 642);
            this.Controls.Add(this.uiButton_Cancel);
            this.Controls.Add(this.uiButton_Sure);
            this.Controls.Add(this.uiButton_RunTool);
            this.Controls.Add(this.label_State);
            this.Controls.Add(this.label_runTime);
            this.Controls.Add(this.lbl_toolTip);
            this.Controls.Add(this.uiSwitch1);
            this.Controls.Add(this.uTabControl_Setting);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_CameraAcq";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.Frm_Camera_Load);
            this.uTabControl_Setting.ResumeLayout(false);
            this.tabPage_Param.ResumeLayout(false);
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTitlePanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private WstControls.UTabControl uTabControl_Setting;
        private System.Windows.Forms.TabPage tabPage_Param;
        private Sunny.UI.UISwitch uiSwitch1;
        public System.Windows.Forms.Label label_runTime;
        public System.Windows.Forms.Label lbl_toolTip;
        public System.Windows.Forms.Label label_State;
        private Sunny.UI.UIButton uiButton_RunTool;
        private Sunny.UI.UIButton uiButton_Sure;
        private Sunny.UI.UIButton uiButton_Cancel;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_SN;
        private Sunny.UI.UISymbolButton uiSymbolButton_Remove;
        private Sunny.UI.UISymbolButton uiSymbolButton_Select;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
    }
}