using System.Drawing;

namespace WstControls
{
    partial class Frm_IfTool
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
            this.uiSwitch1 = new Sunny.UI.UISwitch();
            this.label_runTime = new System.Windows.Forms.Label();
            this.lbl_toolTip = new System.Windows.Forms.Label();
            this.label_State = new System.Windows.Forms.Label();
            this.uiButton_RunTool = new Sunny.UI.UIButton();
            this.uiButton_Sure = new Sunny.UI.UIButton();
            this.uiButton_Cancel = new Sunny.UI.UIButton();
            this.SuspendLayout();
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
            // Frm_IfTool
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_IfTool";
            this.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "";
            this.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(126)))), ((int)(((byte)(164)))));
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.Load += new System.EventHandler(this.Frm_ImageConvert_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Sunny.UI.UISwitch uiSwitch1;
        public System.Windows.Forms.Label label_runTime;
        public System.Windows.Forms.Label lbl_toolTip;
        public System.Windows.Forms.Label label_State;
        private Sunny.UI.UIButton uiButton_RunTool;
        private Sunny.UI.UIButton uiButton_Sure;
        private Sunny.UI.UIButton uiButton_Cancel;
    }
}