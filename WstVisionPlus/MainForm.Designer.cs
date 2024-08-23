namespace WstVisionPlus
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Project = new System.Windows.Forms.Label();
            this.panel_BtnList = new System.Windows.Forms.Panel();
            this.uiHeaderButton_UserManage = new Sunny.UI.UIHeaderButton();
            this.uiHeaderButton_CommunicateSet = new Sunny.UI.UIHeaderButton();
            this.uiHeaderButton_Data = new Sunny.UI.UIHeaderButton();
            this.uiHeaderButton_SystemSet = new Sunny.UI.UIHeaderButton();
            this.uiHeaderButton_CameraSet = new Sunny.UI.UIHeaderButton();
            this.uiHeaderButton_ProjectSet = new Sunny.UI.UIHeaderButton();
            this.uiHeaderButton_Project = new Sunny.UI.UIHeaderButton();
            this.uiPanel_Control = new Sunny.UI.UIPanel();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.uiTitlePanel3 = new Sunny.UI.UITitlePanel();
            this.label_Percent = new System.Windows.Forms.Label();
            this.label_NG = new System.Windows.Forms.Label();
            this.label5_OK = new System.Windows.Forms.Label();
            this.label_All = new System.Windows.Forms.Label();
            this.uiTitlePanel1 = new Sunny.UI.UITitlePanel();
            this.panel_MessageBox = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Panel_Camera = new System.Windows.Forms.FlowLayoutPanel();
            this.dataGridView_LineList = new System.Windows.Forms.DataGridView();
            this.uiPanel_CameraBody = new Sunny.UI.UIPanel();
            this.panel_ControlBox = new System.Windows.Forms.Panel();
            this.uiHeaderButton_Run = new Sunny.UI.UIHeaderButton();
            this.uiHeaderButton_Stop = new Sunny.UI.UIHeaderButton();
            this.timer_Refresh = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel_BtnList.SuspendLayout();
            this.uiPanel_Control.SuspendLayout();
            this.uiTitlePanel3.SuspendLayout();
            this.uiTitlePanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LineList)).BeginInit();
            this.uiPanel_CameraBody.SuspendLayout();
            this.panel_ControlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.label_Project);
            this.panel1.Controls.Add(this.panel_BtnList);
            this.panel1.Name = "panel1";
            // 
            // label_Project
            // 
            resources.ApplyResources(this.label_Project, "label_Project");
            this.label_Project.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label_Project.Name = "label_Project";
            // 
            // panel_BtnList
            // 
            this.panel_BtnList.Controls.Add(this.uiHeaderButton_UserManage);
            this.panel_BtnList.Controls.Add(this.uiHeaderButton_CommunicateSet);
            this.panel_BtnList.Controls.Add(this.uiHeaderButton_Data);
            this.panel_BtnList.Controls.Add(this.uiHeaderButton_SystemSet);
            this.panel_BtnList.Controls.Add(this.uiHeaderButton_CameraSet);
            this.panel_BtnList.Controls.Add(this.uiHeaderButton_ProjectSet);
            this.panel_BtnList.Controls.Add(this.uiHeaderButton_Project);
            resources.ApplyResources(this.panel_BtnList, "panel_BtnList");
            this.panel_BtnList.Name = "panel_BtnList";
            // 
            // uiHeaderButton_UserManage
            // 
            this.uiHeaderButton_UserManage.CircleColor = System.Drawing.Color.Teal;
            this.uiHeaderButton_UserManage.CircleHoverColor = System.Drawing.Color.Teal;
            resources.ApplyResources(this.uiHeaderButton_UserManage, "uiHeaderButton_UserManage");
            this.uiHeaderButton_UserManage.FillColor = System.Drawing.Color.White;
            this.uiHeaderButton_UserManage.FillDisableColor = System.Drawing.Color.White;
            this.uiHeaderButton_UserManage.FillHoverColor = System.Drawing.Color.Gainsboro;
            this.uiHeaderButton_UserManage.FillPressColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_UserManage.FillSelectedColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_UserManage.ForeColor = System.Drawing.Color.Black;
            this.uiHeaderButton_UserManage.ForeHoverColor = System.Drawing.Color.Gray;
            this.uiHeaderButton_UserManage.Name = "uiHeaderButton_UserManage";
            this.uiHeaderButton_UserManage.Radius = 0;
            this.uiHeaderButton_UserManage.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiHeaderButton_UserManage.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiHeaderButton_UserManage.Symbol = 362470;
            this.uiHeaderButton_UserManage.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiHeaderButton_UserManage.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiHeaderButton_UserManage.Click += new System.EventHandler(this.UiHeaderButton_UserManage_Click);
            // 
            // uiHeaderButton_CommunicateSet
            // 
            this.uiHeaderButton_CommunicateSet.CircleColor = System.Drawing.Color.Teal;
            this.uiHeaderButton_CommunicateSet.CircleHoverColor = System.Drawing.Color.Teal;
            resources.ApplyResources(this.uiHeaderButton_CommunicateSet, "uiHeaderButton_CommunicateSet");
            this.uiHeaderButton_CommunicateSet.FillColor = System.Drawing.Color.White;
            this.uiHeaderButton_CommunicateSet.FillDisableColor = System.Drawing.Color.White;
            this.uiHeaderButton_CommunicateSet.FillHoverColor = System.Drawing.Color.Gainsboro;
            this.uiHeaderButton_CommunicateSet.FillPressColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_CommunicateSet.FillSelectedColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_CommunicateSet.ForeColor = System.Drawing.Color.Black;
            this.uiHeaderButton_CommunicateSet.ForeHoverColor = System.Drawing.Color.Gray;
            this.uiHeaderButton_CommunicateSet.Name = "uiHeaderButton_CommunicateSet";
            this.uiHeaderButton_CommunicateSet.Radius = 0;
            this.uiHeaderButton_CommunicateSet.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiHeaderButton_CommunicateSet.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiHeaderButton_CommunicateSet.Symbol = 361556;
            this.uiHeaderButton_CommunicateSet.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiHeaderButton_CommunicateSet.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiHeaderButton_CommunicateSet.Click += new System.EventHandler(this.UiHeaderButton_CommunicateSet_Click);
            // 
            // uiHeaderButton_Data
            // 
            this.uiHeaderButton_Data.CircleColor = System.Drawing.Color.Teal;
            this.uiHeaderButton_Data.CircleHoverColor = System.Drawing.Color.Teal;
            resources.ApplyResources(this.uiHeaderButton_Data, "uiHeaderButton_Data");
            this.uiHeaderButton_Data.FillColor = System.Drawing.Color.White;
            this.uiHeaderButton_Data.FillDisableColor = System.Drawing.Color.White;
            this.uiHeaderButton_Data.FillHoverColor = System.Drawing.Color.Gainsboro;
            this.uiHeaderButton_Data.FillPressColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_Data.FillSelectedColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_Data.ForeColor = System.Drawing.Color.Black;
            this.uiHeaderButton_Data.ForeHoverColor = System.Drawing.Color.Gray;
            this.uiHeaderButton_Data.Name = "uiHeaderButton_Data";
            this.uiHeaderButton_Data.Radius = 0;
            this.uiHeaderButton_Data.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiHeaderButton_Data.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiHeaderButton_Data.Symbol = 361950;
            this.uiHeaderButton_Data.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiHeaderButton_Data.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiHeaderButton_Data.Click += new System.EventHandler(this.UiHeaderButton_Data_Click);
            // 
            // uiHeaderButton_SystemSet
            // 
            this.uiHeaderButton_SystemSet.CircleColor = System.Drawing.Color.Teal;
            this.uiHeaderButton_SystemSet.CircleHoverColor = System.Drawing.Color.Teal;
            resources.ApplyResources(this.uiHeaderButton_SystemSet, "uiHeaderButton_SystemSet");
            this.uiHeaderButton_SystemSet.FillColor = System.Drawing.Color.White;
            this.uiHeaderButton_SystemSet.FillDisableColor = System.Drawing.Color.White;
            this.uiHeaderButton_SystemSet.FillHoverColor = System.Drawing.Color.Gainsboro;
            this.uiHeaderButton_SystemSet.FillPressColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_SystemSet.FillSelectedColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_SystemSet.ForeColor = System.Drawing.Color.Black;
            this.uiHeaderButton_SystemSet.ForeHoverColor = System.Drawing.Color.Gray;
            this.uiHeaderButton_SystemSet.Name = "uiHeaderButton_SystemSet";
            this.uiHeaderButton_SystemSet.Radius = 0;
            this.uiHeaderButton_SystemSet.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiHeaderButton_SystemSet.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiHeaderButton_SystemSet.Symbol = 361459;
            this.uiHeaderButton_SystemSet.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiHeaderButton_SystemSet.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiHeaderButton_SystemSet.Click += new System.EventHandler(this.UiHeaderButton_SystemSet_Click);
            // 
            // uiHeaderButton_CameraSet
            // 
            this.uiHeaderButton_CameraSet.CircleColor = System.Drawing.Color.Teal;
            this.uiHeaderButton_CameraSet.CircleHoverColor = System.Drawing.Color.Teal;
            resources.ApplyResources(this.uiHeaderButton_CameraSet, "uiHeaderButton_CameraSet");
            this.uiHeaderButton_CameraSet.FillColor = System.Drawing.Color.White;
            this.uiHeaderButton_CameraSet.FillDisableColor = System.Drawing.Color.White;
            this.uiHeaderButton_CameraSet.FillHoverColor = System.Drawing.Color.Gainsboro;
            this.uiHeaderButton_CameraSet.FillPressColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_CameraSet.FillSelectedColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_CameraSet.ForeColor = System.Drawing.Color.Black;
            this.uiHeaderButton_CameraSet.ForeHoverColor = System.Drawing.Color.Gray;
            this.uiHeaderButton_CameraSet.Name = "uiHeaderButton_CameraSet";
            this.uiHeaderButton_CameraSet.Radius = 0;
            this.uiHeaderButton_CameraSet.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiHeaderButton_CameraSet.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiHeaderButton_CameraSet.Symbol = 361488;
            this.uiHeaderButton_CameraSet.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiHeaderButton_CameraSet.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiHeaderButton_CameraSet.Click += new System.EventHandler(this.UiHeaderButton_CameraSet_Click);
            // 
            // uiHeaderButton_ProjectSet
            // 
            this.uiHeaderButton_ProjectSet.CircleColor = System.Drawing.Color.Teal;
            this.uiHeaderButton_ProjectSet.CircleHoverColor = System.Drawing.Color.Teal;
            resources.ApplyResources(this.uiHeaderButton_ProjectSet, "uiHeaderButton_ProjectSet");
            this.uiHeaderButton_ProjectSet.FillColor = System.Drawing.Color.White;
            this.uiHeaderButton_ProjectSet.FillDisableColor = System.Drawing.Color.White;
            this.uiHeaderButton_ProjectSet.FillHoverColor = System.Drawing.Color.Gainsboro;
            this.uiHeaderButton_ProjectSet.FillPressColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_ProjectSet.FillSelectedColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_ProjectSet.ForeColor = System.Drawing.Color.Black;
            this.uiHeaderButton_ProjectSet.ForeHoverColor = System.Drawing.Color.Gray;
            this.uiHeaderButton_ProjectSet.Name = "uiHeaderButton_ProjectSet";
            this.uiHeaderButton_ProjectSet.Radius = 0;
            this.uiHeaderButton_ProjectSet.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiHeaderButton_ProjectSet.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiHeaderButton_ProjectSet.Symbol = 361789;
            this.uiHeaderButton_ProjectSet.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiHeaderButton_ProjectSet.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiHeaderButton_ProjectSet.Click += new System.EventHandler(this.UiHeaderButton_ProjectSet_Click);
            // 
            // uiHeaderButton_Project
            // 
            this.uiHeaderButton_Project.CircleColor = System.Drawing.Color.Teal;
            this.uiHeaderButton_Project.CircleHoverColor = System.Drawing.Color.Teal;
            resources.ApplyResources(this.uiHeaderButton_Project, "uiHeaderButton_Project");
            this.uiHeaderButton_Project.FillColor = System.Drawing.Color.White;
            this.uiHeaderButton_Project.FillDisableColor = System.Drawing.Color.White;
            this.uiHeaderButton_Project.FillHoverColor = System.Drawing.Color.Gainsboro;
            this.uiHeaderButton_Project.FillPressColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_Project.FillSelectedColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_Project.ForeColor = System.Drawing.Color.Black;
            this.uiHeaderButton_Project.ForeHoverColor = System.Drawing.Color.Gray;
            this.uiHeaderButton_Project.Name = "uiHeaderButton_Project";
            this.uiHeaderButton_Project.Radius = 0;
            this.uiHeaderButton_Project.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiHeaderButton_Project.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiHeaderButton_Project.Symbol = 257733;
            this.uiHeaderButton_Project.SymbolOffset = new System.Drawing.Point(-5, 0);
            this.uiHeaderButton_Project.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiHeaderButton_Project.Click += new System.EventHandler(this.UiHeaderButton_Project_Click);
            // 
            // uiPanel_Control
            // 
            this.uiPanel_Control.Controls.Add(this.button3);
            this.uiPanel_Control.Controls.Add(this.textBox1);
            this.uiPanel_Control.Controls.Add(this.button2);
            this.uiPanel_Control.Controls.Add(this.button1);
            this.uiPanel_Control.Controls.Add(this.uiTitlePanel3);
            this.uiPanel_Control.Controls.Add(this.uiTitlePanel1);
            this.uiPanel_Control.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.uiPanel_Control, "uiPanel_Control");
            this.uiPanel_Control.Name = "uiPanel_Control";
            this.uiPanel_Control.RectColor = System.Drawing.Color.Teal;
            this.uiPanel_Control.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // button2
            // 
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // uiTitlePanel3
            // 
            this.uiTitlePanel3.Controls.Add(this.label_Percent);
            this.uiTitlePanel3.Controls.Add(this.label_NG);
            this.uiTitlePanel3.Controls.Add(this.label5_OK);
            this.uiTitlePanel3.Controls.Add(this.label_All);
            this.uiTitlePanel3.FillColor = System.Drawing.Color.White;
            this.uiTitlePanel3.FillColor2 = System.Drawing.Color.White;
            resources.ApplyResources(this.uiTitlePanel3, "uiTitlePanel3");
            this.uiTitlePanel3.Name = "uiTitlePanel3";
            this.uiTitlePanel3.RectColor = System.Drawing.Color.Teal;
            this.uiTitlePanel3.ShowText = false;
            this.uiTitlePanel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel3.TitleColor = System.Drawing.Color.Teal;
            // 
            // label_Percent
            // 
            this.label_Percent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(160)))), ((int)(((byte)(15)))));
            resources.ApplyResources(this.label_Percent, "label_Percent");
            this.label_Percent.ForeColor = System.Drawing.Color.White;
            this.label_Percent.Name = "label_Percent";
            // 
            // label_NG
            // 
            this.label_NG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            resources.ApplyResources(this.label_NG, "label_NG");
            this.label_NG.ForeColor = System.Drawing.Color.White;
            this.label_NG.Name = "label_NG";
            // 
            // label5_OK
            // 
            this.label5_OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(139)))), ((int)(((byte)(60)))));
            resources.ApplyResources(this.label5_OK, "label5_OK");
            this.label5_OK.ForeColor = System.Drawing.Color.White;
            this.label5_OK.Name = "label5_OK";
            // 
            // label_All
            // 
            this.label_All.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(161)))), ((int)(((byte)(12)))));
            resources.ApplyResources(this.label_All, "label_All");
            this.label_All.ForeColor = System.Drawing.Color.White;
            this.label_All.Name = "label_All";
            // 
            // uiTitlePanel1
            // 
            this.uiTitlePanel1.Controls.Add(this.panel_MessageBox);
            resources.ApplyResources(this.uiTitlePanel1, "uiTitlePanel1");
            this.uiTitlePanel1.Name = "uiTitlePanel1";
            this.uiTitlePanel1.RectColor = System.Drawing.Color.Teal;
            this.uiTitlePanel1.ShowText = false;
            this.uiTitlePanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiTitlePanel1.TitleColor = System.Drawing.Color.Teal;
            // 
            // panel_MessageBox
            // 
            resources.ApplyResources(this.panel_MessageBox, "panel_MessageBox");
            this.panel_MessageBox.Name = "panel_MessageBox";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Panel_Camera);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // Panel_Camera
            // 
            resources.ApplyResources(this.Panel_Camera, "Panel_Camera");
            this.Panel_Camera.Name = "Panel_Camera";
            // 
            // dataGridView_LineList
            // 
            this.dataGridView_LineList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.dataGridView_LineList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_LineList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_LineList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            resources.ApplyResources(this.dataGridView_LineList, "dataGridView_LineList");
            this.dataGridView_LineList.Name = "dataGridView_LineList";
            this.dataGridView_LineList.RowTemplate.Height = 23;
            // 
            // uiPanel_CameraBody
            // 
            this.uiPanel_CameraBody.Controls.Add(this.dataGridView_LineList);
            this.uiPanel_CameraBody.Controls.Add(this.panel2);
            this.uiPanel_CameraBody.FillColor = System.Drawing.Color.White;
            resources.ApplyResources(this.uiPanel_CameraBody, "uiPanel_CameraBody");
            this.uiPanel_CameraBody.Name = "uiPanel_CameraBody";
            this.uiPanel_CameraBody.RectColor = System.Drawing.Color.Teal;
            this.uiPanel_CameraBody.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_ControlBox
            // 
            this.panel_ControlBox.BackColor = System.Drawing.Color.White;
            this.panel_ControlBox.Controls.Add(this.uiHeaderButton_Run);
            this.panel_ControlBox.Controls.Add(this.uiHeaderButton_Stop);
            resources.ApplyResources(this.panel_ControlBox, "panel_ControlBox");
            this.panel_ControlBox.Name = "panel_ControlBox";
            // 
            // uiHeaderButton_Run
            // 
            this.uiHeaderButton_Run.CircleColor = System.Drawing.Color.DodgerBlue;
            this.uiHeaderButton_Run.CircleHoverColor = System.Drawing.Color.Teal;
            this.uiHeaderButton_Run.CircleSize = 55;
            resources.ApplyResources(this.uiHeaderButton_Run, "uiHeaderButton_Run");
            this.uiHeaderButton_Run.FillColor = System.Drawing.Color.White;
            this.uiHeaderButton_Run.FillDisableColor = System.Drawing.Color.White;
            this.uiHeaderButton_Run.FillHoverColor = System.Drawing.Color.Gainsboro;
            this.uiHeaderButton_Run.FillPressColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_Run.FillSelectedColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_Run.ForeColor = System.Drawing.Color.Black;
            this.uiHeaderButton_Run.ForeHoverColor = System.Drawing.Color.Gray;
            this.uiHeaderButton_Run.Name = "uiHeaderButton_Run";
            this.uiHeaderButton_Run.Radius = 0;
            this.uiHeaderButton_Run.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiHeaderButton_Run.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiHeaderButton_Run.Symbol = 361764;
            this.uiHeaderButton_Run.SymbolOffset = new System.Drawing.Point(-5, 2);
            this.uiHeaderButton_Run.SymbolSize = 55;
            this.uiHeaderButton_Run.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiHeaderButton_Run.Click += new System.EventHandler(this.UiHeaderButton_Run_Click);
            // 
            // uiHeaderButton_Stop
            // 
            this.uiHeaderButton_Stop.CircleColor = System.Drawing.Color.Red;
            this.uiHeaderButton_Stop.CircleHoverColor = System.Drawing.Color.Teal;
            this.uiHeaderButton_Stop.CircleSize = 55;
            resources.ApplyResources(this.uiHeaderButton_Stop, "uiHeaderButton_Stop");
            this.uiHeaderButton_Stop.FillColor = System.Drawing.Color.White;
            this.uiHeaderButton_Stop.FillDisableColor = System.Drawing.Color.White;
            this.uiHeaderButton_Stop.FillHoverColor = System.Drawing.Color.Gainsboro;
            this.uiHeaderButton_Stop.FillPressColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_Stop.FillSelectedColor = System.Drawing.Color.MediumSeaGreen;
            this.uiHeaderButton_Stop.ForeColor = System.Drawing.Color.Black;
            this.uiHeaderButton_Stop.ForeHoverColor = System.Drawing.Color.Gray;
            this.uiHeaderButton_Stop.Name = "uiHeaderButton_Stop";
            this.uiHeaderButton_Stop.Radius = 0;
            this.uiHeaderButton_Stop.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            this.uiHeaderButton_Stop.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiHeaderButton_Stop.Symbol = 362091;
            this.uiHeaderButton_Stop.SymbolOffset = new System.Drawing.Point(-5, 2);
            this.uiHeaderButton_Stop.SymbolSize = 55;
            this.uiHeaderButton_Stop.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiHeaderButton_Stop.Click += new System.EventHandler(this.UiHeaderButton_Stop_Click);
            // 
            // timer_Refresh
            // 
            this.timer_Refresh.Tick += new System.EventHandler(this.Timer_Refresh_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel_ControlBox);
            this.Controls.Add(this.uiPanel_Control);
            this.Controls.Add(this.uiPanel_CameraBody);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.RectColor = System.Drawing.Color.Teal;
            this.TitleColor = System.Drawing.Color.Teal;
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 1920, 1080);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel_BtnList.ResumeLayout(false);
            this.uiPanel_Control.ResumeLayout(false);
            this.uiPanel_Control.PerformLayout();
            this.uiTitlePanel3.ResumeLayout(false);
            this.uiTitlePanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_LineList)).EndInit();
            this.uiPanel_CameraBody.ResumeLayout(false);
            this.panel_ControlBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private Sunny.UI.UIPanel uiPanel_Control;
        private Sunny.UI.UITitlePanel uiTitlePanel1;
        private Sunny.UI.UITitlePanel uiTitlePanel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel Panel_Camera;
        private System.Windows.Forms.DataGridView dataGridView_LineList;
        private Sunny.UI.UIPanel uiPanel_CameraBody;
        private System.Windows.Forms.Panel panel_BtnList;
        private Sunny.UI.UIHeaderButton uiHeaderButton_UserManage;
        private Sunny.UI.UIHeaderButton uiHeaderButton_CommunicateSet;
        private Sunny.UI.UIHeaderButton uiHeaderButton_Data;
        private Sunny.UI.UIHeaderButton uiHeaderButton_SystemSet;
        private Sunny.UI.UIHeaderButton uiHeaderButton_CameraSet;
        private Sunny.UI.UIHeaderButton uiHeaderButton_ProjectSet;
        private Sunny.UI.UIHeaderButton uiHeaderButton_Project;
        private System.Windows.Forms.Panel panel_ControlBox;
        private Sunny.UI.UIHeaderButton uiHeaderButton_Run;
        private Sunny.UI.UIHeaderButton uiHeaderButton_Stop;
        private System.Windows.Forms.Panel panel_MessageBox;
        private System.Windows.Forms.Label label_Percent;
        private System.Windows.Forms.Label label_NG;
        private System.Windows.Forms.Label label5_OK;
        private System.Windows.Forms.Label label_All;
        private System.Windows.Forms.Timer timer_Refresh;
        private System.Windows.Forms.Label label_Project;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

