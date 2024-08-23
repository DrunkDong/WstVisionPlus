using System.Drawing;

namespace WstControls
{
    partial class Frm_ImageConvert
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
            this.uiRadioButton_None = new Sunny.UI.UIRadioButton();
            this.uiComboBox_TransMode = new Sunny.UI.UIComboBox();
            this.uiRadioButton_V = new Sunny.UI.UIRadioButton();
            this.uiRadioButton_S = new Sunny.UI.UIRadioButton();
            this.uiRadioButton_H = new Sunny.UI.UIRadioButton();
            this.uiRadioButton_G = new Sunny.UI.UIRadioButton();
            this.uiRadioButton_Gray = new Sunny.UI.UIRadioButton();
            this.uiRadioButton_B = new Sunny.UI.UIRadioButton();
            this.uiRadioButton_R = new Sunny.UI.UIRadioButton();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.uiComboTreeView_ImageSource = new Sunny.UI.UIComboTreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.uTabControl_Setting.SuspendLayout();
            this.tabPage_Param.SuspendLayout();
            this.uiTitlePanel2.SuspendLayout();
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
            this.label_runTime.Size = new System.Drawing.Size(70, 17);
            this.label_runTime.TabIndex = 117;
            this.label_runTime.Text = "Cost：0ms";
            // 
            // lbl_toolTip
            // 
            this.lbl_toolTip.AutoSize = true;
            this.lbl_toolTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_toolTip.Location = new System.Drawing.Point(122, 591);
            this.lbl_toolTip.Name = "lbl_toolTip";
            this.lbl_toolTip.Size = new System.Drawing.Size(56, 17);
            this.lbl_toolTip.TabIndex = 116;
            this.lbl_toolTip.Text = "状态：无";
            // 
            // label_State
            // 
            this.label_State.AutoSize = true;
            this.label_State.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_State.Location = new System.Drawing.Point(122, 613);
            this.label_State.Name = "label_State";
            this.label_State.Size = new System.Drawing.Size(60, 17);
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
            this.tabPage_Param.Text = "Settings";
            // 
            // uiTitlePanel2
            // 
            this.uiTitlePanel2.Controls.Add(this.uiRadioButton_None);
            this.uiTitlePanel2.Controls.Add(this.uiComboBox_TransMode);
            this.uiTitlePanel2.Controls.Add(this.uiRadioButton_V);
            this.uiTitlePanel2.Controls.Add(this.uiRadioButton_S);
            this.uiTitlePanel2.Controls.Add(this.uiRadioButton_H);
            this.uiTitlePanel2.Controls.Add(this.uiRadioButton_G);
            this.uiTitlePanel2.Controls.Add(this.uiRadioButton_Gray);
            this.uiTitlePanel2.Controls.Add(this.uiRadioButton_B);
            this.uiTitlePanel2.Controls.Add(this.uiRadioButton_R);
            this.uiTitlePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTitlePanel2.Font = new System.Drawing.Font("宋体", 11F);
            this.uiTitlePanel2.Location = new System.Drawing.Point(3, 94);
            this.uiTitlePanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel2.Name = "uiTitlePanel2";
            this.uiTitlePanel2.Radius = 0;
            this.uiTitlePanel2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel2.ShowText = false;
            this.uiTitlePanel2.Size = new System.Drawing.Size(384, 379);
            this.uiTitlePanel2.TabIndex = 13;
            this.uiTitlePanel2.Text = "Param Settings";
            this.uiTitlePanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTitlePanel2.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel2.TitleHeight = 28;
            // 
            // uiRadioButton_None
            // 
            this.uiRadioButton_None.Checked = true;
            this.uiRadioButton_None.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton_None.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButton_None.Location = new System.Drawing.Point(12, 46);
            this.uiRadioButton_None.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton_None.Name = "uiRadioButton_None";
            this.uiRadioButton_None.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiRadioButton_None.Size = new System.Drawing.Size(125, 29);
            this.uiRadioButton_None.TabIndex = 12;
            this.uiRadioButton_None.Text = "None";
            // 
            // uiComboBox_TransMode
            // 
            this.uiComboBox_TransMode.DataSource = null;
            this.uiComboBox_TransMode.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox_TransMode.DropDownWidth = 200;
            this.uiComboBox_TransMode.FillColor = System.Drawing.Color.White;
            this.uiComboBox_TransMode.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.uiComboBox_TransMode.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(186)))), ((int)(((byte)(224)))));
            this.uiComboBox_TransMode.Items.AddRange(new object[] {
            "hsv",
            "hsi",
            "yiq",
            "yuv",
            "argyb",
            "ciexyz",
            "hls",
            "ihs",
            "cielab"});
            this.uiComboBox_TransMode.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiComboBox_TransMode.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox_TransMode.Location = new System.Drawing.Point(248, 42);
            this.uiComboBox_TransMode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_TransMode.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_TransMode.Name = "uiComboBox_TransMode";
            this.uiComboBox_TransMode.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_TransMode.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiComboBox_TransMode.Size = new System.Drawing.Size(132, 35);
            this.uiComboBox_TransMode.TabIndex = 11;
            this.uiComboBox_TransMode.Text = "hsv";
            this.uiComboBox_TransMode.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_TransMode.Watermark = "";
            // 
            // uiRadioButton_V
            // 
            this.uiRadioButton_V.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton_V.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButton_V.Location = new System.Drawing.Point(12, 263);
            this.uiRadioButton_V.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton_V.Name = "uiRadioButton_V";
            this.uiRadioButton_V.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiRadioButton_V.Size = new System.Drawing.Size(144, 29);
            this.uiRadioButton_V.TabIndex = 6;
            this.uiRadioButton_V.Text = "Image Result3";
            // 
            // uiRadioButton_S
            // 
            this.uiRadioButton_S.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton_S.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButton_S.Location = new System.Drawing.Point(12, 232);
            this.uiRadioButton_S.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton_S.Name = "uiRadioButton_S";
            this.uiRadioButton_S.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiRadioButton_S.Size = new System.Drawing.Size(144, 29);
            this.uiRadioButton_S.TabIndex = 5;
            this.uiRadioButton_S.Text = "Image Result2";
            // 
            // uiRadioButton_H
            // 
            this.uiRadioButton_H.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton_H.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButton_H.Location = new System.Drawing.Point(12, 201);
            this.uiRadioButton_H.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton_H.Name = "uiRadioButton_H";
            this.uiRadioButton_H.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiRadioButton_H.Size = new System.Drawing.Size(144, 29);
            this.uiRadioButton_H.TabIndex = 4;
            this.uiRadioButton_H.Text = "Image Result1";
            // 
            // uiRadioButton_G
            // 
            this.uiRadioButton_G.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton_G.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButton_G.Location = new System.Drawing.Point(12, 139);
            this.uiRadioButton_G.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton_G.Name = "uiRadioButton_G";
            this.uiRadioButton_G.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiRadioButton_G.Size = new System.Drawing.Size(125, 29);
            this.uiRadioButton_G.TabIndex = 2;
            this.uiRadioButton_G.Text = "Image Green";
            // 
            // uiRadioButton_Gray
            // 
            this.uiRadioButton_Gray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton_Gray.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButton_Gray.Location = new System.Drawing.Point(12, 77);
            this.uiRadioButton_Gray.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton_Gray.Name = "uiRadioButton_Gray";
            this.uiRadioButton_Gray.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiRadioButton_Gray.Size = new System.Drawing.Size(125, 29);
            this.uiRadioButton_Gray.TabIndex = 0;
            this.uiRadioButton_Gray.Text = "Image Gray";
            // 
            // uiRadioButton_B
            // 
            this.uiRadioButton_B.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton_B.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButton_B.Location = new System.Drawing.Point(12, 170);
            this.uiRadioButton_B.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton_B.Name = "uiRadioButton_B";
            this.uiRadioButton_B.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiRadioButton_B.Size = new System.Drawing.Size(125, 29);
            this.uiRadioButton_B.TabIndex = 3;
            this.uiRadioButton_B.Text = "Image Blue";
            // 
            // uiRadioButton_R
            // 
            this.uiRadioButton_R.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButton_R.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiRadioButton_R.Location = new System.Drawing.Point(12, 108);
            this.uiRadioButton_R.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButton_R.Name = "uiRadioButton_R";
            this.uiRadioButton_R.RadioButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiRadioButton_R.Size = new System.Drawing.Size(125, 29);
            this.uiRadioButton_R.TabIndex = 1;
            this.uiRadioButton_R.Text = "Image Red";
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.uiComboTreeView_ImageSource);
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
            this.uiTitlePanel1.Size = new System.Drawing.Size(384, 91);
            this.uiTitlePanel1.TabIndex = 12;
            this.uiTitlePanel1.Text = "Input Step";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTitlePanel1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel1.TitleHeight = 28;
            // 
            // uiComboTreeView_ImageSource
            // 
            this.uiComboTreeView_ImageSource.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboTreeView_ImageSource.FillColor = System.Drawing.Color.White;
            this.uiComboTreeView_ImageSource.Font = new System.Drawing.Font("宋体", 12F);
            this.uiComboTreeView_ImageSource.Location = new System.Drawing.Point(103, 45);
            this.uiComboTreeView_ImageSource.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboTreeView_ImageSource.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboTreeView_ImageSource.Name = "uiComboTreeView_ImageSource";
            this.uiComboTreeView_ImageSource.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboTreeView_ImageSource.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiComboTreeView_ImageSource.ShowLines = true;
            this.uiComboTreeView_ImageSource.Size = new System.Drawing.Size(268, 29);
            this.uiComboTreeView_ImageSource.TabIndex = 150;
            this.uiComboTreeView_ImageSource.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboTreeView_ImageSource.Watermark = "";
            this.uiComboTreeView_ImageSource.NodeSelected += new Sunny.UI.UIComboTreeView.OnNodeSelected(this.uiComboTreeView1_NodeSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 149;
            this.label1.Text = "Image Step:";
            // 
            // Frm_ImageConvert
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
            this.Name = "Frm_ImageConvert";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.Frm_ImageConvert_Load);
            this.uTabControl_Setting.ResumeLayout(false);
            this.tabPage_Param.ResumeLayout(false);
            this.uiTitlePanel2.ResumeLayout(false);
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
        private Sunny.UI.UIComboBox uiComboBox_TransMode;
        private Sunny.UI.UIRadioButton uiRadioButton_Gray;
        private Sunny.UI.UIRadioButton uiRadioButton_V;
        private Sunny.UI.UIRadioButton uiRadioButton_S;
        private Sunny.UI.UIRadioButton uiRadioButton_H;
        private Sunny.UI.UIRadioButton uiRadioButton_B;
        private Sunny.UI.UIRadioButton uiRadioButton_G;
        private Sunny.UI.UIRadioButton uiRadioButton_R;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIRadioButton uiRadioButton_None;
        private Sunny.UI.UIComboTreeView uiComboTreeView_ImageSource;
    }
}