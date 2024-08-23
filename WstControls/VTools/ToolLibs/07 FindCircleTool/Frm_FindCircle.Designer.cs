using System.Drawing;

namespace WstControls
{
    partial class Frm_FindCircle
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
            this.uiColorPicker_CheckRegion = new Sunny.UI.UIColorPicker();
            this.label10 = new System.Windows.Forms.Label();
            this.uiComboBox_Select = new Sunny.UI.UIComboBox();
            this.uiComboBox_Transition = new Sunny.UI.UIComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.uNumericUpDown_MeasureThreshold = new WstControls.UNumericUpDown();
            this.uNumericUpDown_MeasureNums = new WstControls.UNumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.uNumericUpDown_MeasureHeight = new WstControls.UNumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.uNumericUpDown_MeasureWidth = new WstControls.UNumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.uiCheckBox_IsShowMeasureObj = new Sunny.UI.UICheckBox();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.uiComboTreeView_LineStep = new Sunny.UI.UIComboTreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.uiComboTreeView_MatchingStep = new Sunny.UI.UIComboTreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.uiComboTreeView_ImageSource = new Sunny.UI.UIComboTreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.uiTitlePanel3 = new Sunny.UI.UITitlePanel();
            this.uiColorPicker_TextColor = new Sunny.UI.UIColorPicker();
            this.label12 = new System.Windows.Forms.Label();
            this.uiColorPicker_FindLineColor = new Sunny.UI.UIColorPicker();
            this.label11 = new System.Windows.Forms.Label();
            this.uTabControl_Setting.SuspendLayout();
            this.tabPage_Param.SuspendLayout();
            this.uiTitlePanel2.SuspendLayout();
            this.uiTitlePanel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.uiTitlePanel3.SuspendLayout();
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
            this.label_State.Size = new System.Drawing.Size(48, 17);
            this.label_State.TabIndex = 118;
            this.label_State.Text = "state：";
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
            this.uTabControl_Setting.Controls.Add(this.tabPage1);
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
            this.uiTitlePanel2.Controls.Add(this.uiColorPicker_CheckRegion);
            this.uiTitlePanel2.Controls.Add(this.label10);
            this.uiTitlePanel2.Controls.Add(this.uiComboBox_Select);
            this.uiTitlePanel2.Controls.Add(this.uiComboBox_Transition);
            this.uiTitlePanel2.Controls.Add(this.label9);
            this.uiTitlePanel2.Controls.Add(this.label7);
            this.uiTitlePanel2.Controls.Add(this.uNumericUpDown_MeasureThreshold);
            this.uiTitlePanel2.Controls.Add(this.uNumericUpDown_MeasureNums);
            this.uiTitlePanel2.Controls.Add(this.label6);
            this.uiTitlePanel2.Controls.Add(this.label5);
            this.uiTitlePanel2.Controls.Add(this.uNumericUpDown_MeasureHeight);
            this.uiTitlePanel2.Controls.Add(this.label4);
            this.uiTitlePanel2.Controls.Add(this.uNumericUpDown_MeasureWidth);
            this.uiTitlePanel2.Controls.Add(this.label8);
            this.uiTitlePanel2.Controls.Add(this.uiCheckBox_IsShowMeasureObj);
            this.uiTitlePanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTitlePanel2.Font = new System.Drawing.Font("宋体", 11F);
            this.uiTitlePanel2.Location = new System.Drawing.Point(3, 159);
            this.uiTitlePanel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel2.Name = "uiTitlePanel2";
            this.uiTitlePanel2.Radius = 0;
            this.uiTitlePanel2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel2.ShowText = false;
            this.uiTitlePanel2.Size = new System.Drawing.Size(384, 349);
            this.uiTitlePanel2.TabIndex = 13;
            this.uiTitlePanel2.Text = "Param Settings";
            this.uiTitlePanel2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTitlePanel2.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel2.TitleHeight = 28;
            // 
            // uiColorPicker_CheckRegion
            // 
            this.uiColorPicker_CheckRegion.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker_CheckRegion.FillColor = System.Drawing.Color.White;
            this.uiColorPicker_CheckRegion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker_CheckRegion.Location = new System.Drawing.Point(122, 74);
            this.uiColorPicker_CheckRegion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker_CheckRegion.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker_CheckRegion.Name = "uiColorPicker_CheckRegion";
            this.uiColorPicker_CheckRegion.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker_CheckRegion.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiColorPicker_CheckRegion.Size = new System.Drawing.Size(231, 30);
            this.uiColorPicker_CheckRegion.TabIndex = 171;
            this.uiColorPicker_CheckRegion.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiColorPicker_CheckRegion.Value = System.Drawing.Color.Red;
            this.uiColorPicker_CheckRegion.Watermark = "";
            this.uiColorPicker_CheckRegion.ValueChanged += new Sunny.UI.UIColorPicker.OnColorChanged(this.uiColorPicker_CheckRegion_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label10.Location = new System.Drawing.Point(9, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 20);
            this.label10.TabIndex = 170;
            this.label10.Text = "Circle Color:";
            // 
            // uiComboBox_Select
            // 
            this.uiComboBox_Select.DataSource = null;
            this.uiComboBox_Select.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox_Select.DropDownWidth = 200;
            this.uiComboBox_Select.FillColor = System.Drawing.Color.White;
            this.uiComboBox_Select.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.uiComboBox_Select.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(186)))), ((int)(((byte)(224)))));
            this.uiComboBox_Select.Items.AddRange(new object[] {
            "all",
            "first",
            "last"});
            this.uiComboBox_Select.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiComboBox_Select.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox_Select.Location = new System.Drawing.Point(123, 303);
            this.uiComboBox_Select.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_Select.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_Select.Name = "uiComboBox_Select";
            this.uiComboBox_Select.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_Select.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiComboBox_Select.Size = new System.Drawing.Size(230, 35);
            this.uiComboBox_Select.TabIndex = 169;
            this.uiComboBox_Select.Text = "all";
            this.uiComboBox_Select.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_Select.Watermark = "";
            // 
            // uiComboBox_Transition
            // 
            this.uiComboBox_Transition.DataSource = null;
            this.uiComboBox_Transition.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboBox_Transition.DropDownWidth = 200;
            this.uiComboBox_Transition.FillColor = System.Drawing.Color.White;
            this.uiComboBox_Transition.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.uiComboBox_Transition.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(186)))), ((int)(((byte)(224)))));
            this.uiComboBox_Transition.Items.AddRange(new object[] {
            "all",
            "positive",
            "negative"});
            this.uiComboBox_Transition.ItemSelectBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiComboBox_Transition.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox_Transition.Location = new System.Drawing.Point(123, 261);
            this.uiComboBox_Transition.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox_Transition.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox_Transition.Name = "uiComboBox_Transition";
            this.uiComboBox_Transition.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox_Transition.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiComboBox_Transition.Size = new System.Drawing.Size(230, 35);
            this.uiComboBox_Transition.TabIndex = 168;
            this.uiComboBox_Transition.Text = "all";
            this.uiComboBox_Transition.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox_Transition.Watermark = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(8, 310);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 20);
            this.label9.TabIndex = 167;
            this.label9.Text = "Select:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(8, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 166;
            this.label7.Text = "Transition:";
            // 
            // uNumericUpDown_MeasureThreshold
            // 
            this.uNumericUpDown_MeasureThreshold.AllBlackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uNumericUpDown_MeasureThreshold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uNumericUpDown_MeasureThreshold.DecimalPlaces = 0;
            this.uNumericUpDown_MeasureThreshold.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uNumericUpDown_MeasureThreshold.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureThreshold.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uNumericUpDown_MeasureThreshold.Location = new System.Drawing.Point(123, 226);
            this.uNumericUpDown_MeasureThreshold.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uNumericUpDown_MeasureThreshold.MaximumSize = new System.Drawing.Size(300, 26);
            this.uNumericUpDown_MeasureThreshold.MaxValue = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureThreshold.MinimumSize = new System.Drawing.Size(50, 26);
            this.uNumericUpDown_MeasureThreshold.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureThreshold.Name = "uNumericUpDown_MeasureThreshold";
            this.uNumericUpDown_MeasureThreshold.Size = new System.Drawing.Size(230, 26);
            this.uNumericUpDown_MeasureThreshold.TabIndex = 165;
            this.uNumericUpDown_MeasureThreshold.Value = 10D;
            // 
            // uNumericUpDown_MeasureNums
            // 
            this.uNumericUpDown_MeasureNums.AllBlackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uNumericUpDown_MeasureNums.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uNumericUpDown_MeasureNums.DecimalPlaces = 0;
            this.uNumericUpDown_MeasureNums.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uNumericUpDown_MeasureNums.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureNums.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uNumericUpDown_MeasureNums.Location = new System.Drawing.Point(123, 189);
            this.uNumericUpDown_MeasureNums.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uNumericUpDown_MeasureNums.MaximumSize = new System.Drawing.Size(300, 26);
            this.uNumericUpDown_MeasureNums.MaxValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureNums.MinimumSize = new System.Drawing.Size(50, 26);
            this.uNumericUpDown_MeasureNums.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureNums.Name = "uNumericUpDown_MeasureNums";
            this.uNumericUpDown_MeasureNums.Size = new System.Drawing.Size(230, 26);
            this.uNumericUpDown_MeasureNums.TabIndex = 164;
            this.uNumericUpDown_MeasureNums.Value = 10D;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(6, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 163;
            this.label6.Text = "Threshold:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(6, 191);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 162;
            this.label5.Text = "Check Nums:";
            // 
            // uNumericUpDown_MeasureHeight
            // 
            this.uNumericUpDown_MeasureHeight.AllBlackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uNumericUpDown_MeasureHeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uNumericUpDown_MeasureHeight.DecimalPlaces = 0;
            this.uNumericUpDown_MeasureHeight.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uNumericUpDown_MeasureHeight.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureHeight.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uNumericUpDown_MeasureHeight.Location = new System.Drawing.Point(123, 151);
            this.uNumericUpDown_MeasureHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uNumericUpDown_MeasureHeight.MaximumSize = new System.Drawing.Size(300, 26);
            this.uNumericUpDown_MeasureHeight.MaxValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureHeight.MinimumSize = new System.Drawing.Size(50, 26);
            this.uNumericUpDown_MeasureHeight.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureHeight.Name = "uNumericUpDown_MeasureHeight";
            this.uNumericUpDown_MeasureHeight.Size = new System.Drawing.Size(230, 26);
            this.uNumericUpDown_MeasureHeight.TabIndex = 161;
            this.uNumericUpDown_MeasureHeight.Value = 20D;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(6, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 160;
            this.label4.Text = "Check Width:";
            // 
            // uNumericUpDown_MeasureWidth
            // 
            this.uNumericUpDown_MeasureWidth.AllBlackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uNumericUpDown_MeasureWidth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uNumericUpDown_MeasureWidth.DecimalPlaces = 0;
            this.uNumericUpDown_MeasureWidth.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uNumericUpDown_MeasureWidth.Incremeent = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureWidth.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uNumericUpDown_MeasureWidth.Location = new System.Drawing.Point(123, 112);
            this.uNumericUpDown_MeasureWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uNumericUpDown_MeasureWidth.MaximumSize = new System.Drawing.Size(300, 26);
            this.uNumericUpDown_MeasureWidth.MaxValue = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureWidth.MinimumSize = new System.Drawing.Size(50, 26);
            this.uNumericUpDown_MeasureWidth.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.uNumericUpDown_MeasureWidth.Name = "uNumericUpDown_MeasureWidth";
            this.uNumericUpDown_MeasureWidth.Size = new System.Drawing.Size(230, 26);
            this.uNumericUpDown_MeasureWidth.TabIndex = 159;
            this.uNumericUpDown_MeasureWidth.Value = 10D;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(6, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 20);
            this.label8.TabIndex = 158;
            this.label8.Text = "Check Height:";
            // 
            // uiCheckBox_IsShowMeasureObj
            // 
            this.uiCheckBox_IsShowMeasureObj.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiCheckBox_IsShowMeasureObj.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox_IsShowMeasureObj.Font = new System.Drawing.Font("宋体", 12F);
            this.uiCheckBox_IsShowMeasureObj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiCheckBox_IsShowMeasureObj.Location = new System.Drawing.Point(3, 31);
            this.uiCheckBox_IsShowMeasureObj.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox_IsShowMeasureObj.Name = "uiCheckBox_IsShowMeasureObj";
            this.uiCheckBox_IsShowMeasureObj.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox_IsShowMeasureObj.Size = new System.Drawing.Size(188, 35);
            this.uiCheckBox_IsShowMeasureObj.TabIndex = 50;
            this.uiCheckBox_IsShowMeasureObj.Text = "show check details";
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.uiComboTreeView_LineStep);
            this.uiTitlePanel1.Controls.Add(this.label3);
            this.uiTitlePanel1.Controls.Add(this.uiComboTreeView_MatchingStep);
            this.uiTitlePanel1.Controls.Add(this.label2);
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
            this.uiTitlePanel1.Size = new System.Drawing.Size(384, 156);
            this.uiTitlePanel1.TabIndex = 12;
            this.uiTitlePanel1.Text = "Input Step";
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTitlePanel1.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel1.TitleHeight = 28;
            // 
            // uiComboTreeView_LineStep
            // 
            this.uiComboTreeView_LineStep.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboTreeView_LineStep.FillColor = System.Drawing.Color.White;
            this.uiComboTreeView_LineStep.Font = new System.Drawing.Font("宋体", 12F);
            this.uiComboTreeView_LineStep.Location = new System.Drawing.Point(103, 116);
            this.uiComboTreeView_LineStep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboTreeView_LineStep.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboTreeView_LineStep.Name = "uiComboTreeView_LineStep";
            this.uiComboTreeView_LineStep.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboTreeView_LineStep.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiComboTreeView_LineStep.ShowLines = true;
            this.uiComboTreeView_LineStep.Size = new System.Drawing.Size(268, 29);
            this.uiComboTreeView_LineStep.TabIndex = 154;
            this.uiComboTreeView_LineStep.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboTreeView_LineStep.Watermark = "";
            this.uiComboTreeView_LineStep.NodeSelected += new Sunny.UI.UIComboTreeView.OnNodeSelected(this.uiComboTreeView_LineStep_NodeSelected);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(8, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 20);
            this.label3.TabIndex = 153;
            this.label3.Text = "Circle Step:";
            // 
            // uiComboTreeView_MatchingStep
            // 
            this.uiComboTreeView_MatchingStep.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiComboTreeView_MatchingStep.FillColor = System.Drawing.Color.White;
            this.uiComboTreeView_MatchingStep.Font = new System.Drawing.Font("宋体", 12F);
            this.uiComboTreeView_MatchingStep.Location = new System.Drawing.Point(103, 80);
            this.uiComboTreeView_MatchingStep.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboTreeView_MatchingStep.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboTreeView_MatchingStep.Name = "uiComboTreeView_MatchingStep";
            this.uiComboTreeView_MatchingStep.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboTreeView_MatchingStep.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiComboTreeView_MatchingStep.ShowLines = true;
            this.uiComboTreeView_MatchingStep.Size = new System.Drawing.Size(268, 29);
            this.uiComboTreeView_MatchingStep.TabIndex = 152;
            this.uiComboTreeView_MatchingStep.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboTreeView_MatchingStep.Watermark = "";
            this.uiComboTreeView_MatchingStep.NodeSelected += new Sunny.UI.UIComboTreeView.OnNodeSelected(this.uiComboTreeView_MatchingStep_NodeSelected);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(8, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 151;
            this.label2.Text = "Match Step:";
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.uiTitlePanel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(390, 513);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "ShowResult";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // uiTitlePanel3
            // 
            this.uiTitlePanel3.Controls.Add(this.uiColorPicker_TextColor);
            this.uiTitlePanel3.Controls.Add(this.label12);
            this.uiTitlePanel3.Controls.Add(this.uiColorPicker_FindLineColor);
            this.uiTitlePanel3.Controls.Add(this.label11);
            this.uiTitlePanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiTitlePanel3.Font = new System.Drawing.Font("宋体", 11F);
            this.uiTitlePanel3.Location = new System.Drawing.Point(3, 3);
            this.uiTitlePanel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTitlePanel3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiTitlePanel3.Name = "uiTitlePanel3";
            this.uiTitlePanel3.Radius = 0;
            this.uiTitlePanel3.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel3.ShowText = false;
            this.uiTitlePanel3.Size = new System.Drawing.Size(384, 505);
            this.uiTitlePanel3.TabIndex = 13;
            this.uiTitlePanel3.Text = "results";
            this.uiTitlePanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTitlePanel3.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiTitlePanel3.TitleHeight = 28;
            // 
            // uiColorPicker_TextColor
            // 
            this.uiColorPicker_TextColor.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker_TextColor.FillColor = System.Drawing.Color.White;
            this.uiColorPicker_TextColor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker_TextColor.Location = new System.Drawing.Point(139, 74);
            this.uiColorPicker_TextColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker_TextColor.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker_TextColor.Name = "uiColorPicker_TextColor";
            this.uiColorPicker_TextColor.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker_TextColor.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiColorPicker_TextColor.Size = new System.Drawing.Size(231, 30);
            this.uiColorPicker_TextColor.TabIndex = 175;
            this.uiColorPicker_TextColor.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiColorPicker_TextColor.Value = System.Drawing.Color.Red;
            this.uiColorPicker_TextColor.Watermark = "";
            this.uiColorPicker_TextColor.ValueChanged += new Sunny.UI.UIColorPicker.OnColorChanged(this.uiColorPicker_TextColor_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label12.Location = new System.Drawing.Point(7, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 174;
            this.label12.Text = "Text Color:";
            // 
            // uiColorPicker_FindLineColor
            // 
            this.uiColorPicker_FindLineColor.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            this.uiColorPicker_FindLineColor.FillColor = System.Drawing.Color.White;
            this.uiColorPicker_FindLineColor.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiColorPicker_FindLineColor.Location = new System.Drawing.Point(139, 34);
            this.uiColorPicker_FindLineColor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiColorPicker_FindLineColor.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiColorPicker_FindLineColor.Name = "uiColorPicker_FindLineColor";
            this.uiColorPicker_FindLineColor.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiColorPicker_FindLineColor.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.uiColorPicker_FindLineColor.Size = new System.Drawing.Size(231, 30);
            this.uiColorPicker_FindLineColor.TabIndex = 173;
            this.uiColorPicker_FindLineColor.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiColorPicker_FindLineColor.Value = System.Drawing.Color.Red;
            this.uiColorPicker_FindLineColor.Watermark = "";
            this.uiColorPicker_FindLineColor.ValueChanged += new Sunny.UI.UIColorPicker.OnColorChanged(this.uiColorPicker_FindLineColor_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(7, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 20);
            this.label11.TabIndex = 172;
            this.label11.Text = "Find Circle Color:";
            // 
            // Frm_FindCircle
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
            this.Name = "Frm_FindCircle";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.Frm_FindCircle_Load);
            this.uTabControl_Setting.ResumeLayout(false);
            this.tabPage_Param.ResumeLayout(false);
            this.uiTitlePanel2.ResumeLayout(false);
            this.uiTitlePanel2.PerformLayout();
            this.uiTitlePanel1.ResumeLayout(false);
            this.uiTitlePanel1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.uiTitlePanel3.ResumeLayout(false);
            this.uiTitlePanel3.PerformLayout();
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
        private Sunny.UI.UITitlePanel uiTitlePanel2;
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIComboTreeView uiComboTreeView_ImageSource;
        private Sunny.UI.UIComboTreeView uiComboTreeView_LineStep;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UIComboTreeView uiComboTreeView_MatchingStep;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UICheckBox uiCheckBox_IsShowMeasureObj;
        private WstControls.UNumericUpDown uNumericUpDown_MeasureWidth;
        private System.Windows.Forms.Label label8;
        private WstControls.UNumericUpDown uNumericUpDown_MeasureHeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private WstControls.UNumericUpDown uNumericUpDown_MeasureThreshold;
        private WstControls.UNumericUpDown uNumericUpDown_MeasureNums;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private Sunny.UI.UIComboBox uiComboBox_Select;
        private Sunny.UI.UIComboBox uiComboBox_Transition;
        private System.Windows.Forms.Label label10;
        private Sunny.UI.UIColorPicker uiColorPicker_CheckRegion;
        private System.Windows.Forms.TabPage tabPage1;
        private Sunny.UI.UITitlePanel uiTitlePanel3;
        private Sunny.UI.UIColorPicker uiColorPicker_FindLineColor;
        private System.Windows.Forms.Label label11;
        private Sunny.UI.UIColorPicker uiColorPicker_TextColor;
        private System.Windows.Forms.Label label12;
    }
}