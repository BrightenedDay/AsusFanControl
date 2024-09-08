namespace AsusFanControlGUI
{
    partial class SliderPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelVersion = new System.Windows.Forms.Label();
            this.refreshTemps = new System.Windows.Forms.Button();
            this.labelTemps = new System.Windows.Forms.Label();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.refreshRPM = new System.Windows.Forms.Button();
            this.labelRPM = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.trackBarFanSpeed = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFanSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.Font = new System.Drawing.Font("Cascadia Code SemiLight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(322, 211);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelVersion.Size = new System.Drawing.Size(117, 20);
            this.labelVersion.TabIndex = 19;
            this.labelVersion.Text = "v1.6";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // refreshTemps
            // 
            this.refreshTemps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshTemps.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshTemps.Location = new System.Drawing.Point(17, 187);
            this.refreshTemps.Margin = new System.Windows.Forms.Padding(4);
            this.refreshTemps.Name = "refreshTemps";
            this.refreshTemps.Size = new System.Drawing.Size(29, 28);
            this.refreshTemps.TabIndex = 18;
            this.refreshTemps.Text = "↻";
            this.refreshTemps.UseVisualStyleBackColor = true;
            this.refreshTemps.Click += new System.EventHandler(this.refreshTemps_Click);
            // 
            // labelTemps
            // 
            this.labelTemps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTemps.AutoSize = true;
            this.labelTemps.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemps.Location = new System.Drawing.Point(54, 193);
            this.labelTemps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTemps.Name = "labelTemps";
            this.labelTemps.Size = new System.Drawing.Size(146, 20);
            this.labelTemps.TabIndex = 17;
            this.labelTemps.Text = "Current temps: (N/A)";
            this.labelTemps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEnabled.Location = new System.Drawing.Point(17, 32);
            this.checkBoxEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(76, 24);
            this.checkBoxEnabled.TabIndex = 16;
            this.checkBoxEnabled.Text = "Enable";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            this.checkBoxEnabled.CheckedChanged += new System.EventHandler(this.checkBoxEnabled_CheckedChanged);
            // 
            // refreshRPM
            // 
            this.refreshRPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.refreshRPM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshRPM.Location = new System.Drawing.Point(17, 157);
            this.refreshRPM.Margin = new System.Windows.Forms.Padding(4);
            this.refreshRPM.Name = "refreshRPM";
            this.refreshRPM.Size = new System.Drawing.Size(29, 28);
            this.refreshRPM.TabIndex = 15;
            this.refreshRPM.Text = "↻";
            this.refreshRPM.UseVisualStyleBackColor = true;
            this.refreshRPM.Click += new System.EventHandler(this.refreshRPM_Click);
            // 
            // labelRPM
            // 
            this.labelRPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelRPM.AutoSize = true;
            this.labelRPM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRPM.Location = new System.Drawing.Point(54, 157);
            this.labelRPM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRPM.Name = "labelRPM";
            this.labelRPM.Size = new System.Drawing.Size(131, 20);
            this.labelRPM.TabIndex = 14;
            this.labelRPM.Text = "Current RPMs: N/A";
            this.labelRPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValue.Location = new System.Drawing.Point(14, 107);
            this.labelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(156, 20);
            this.labelValue.TabIndex = 13;
            this.labelValue.Text = "Status: Disabled (N/A)";
            // 
            // trackBarFanSpeed
            // 
            this.trackBarFanSpeed.Location = new System.Drawing.Point(17, 62);
            this.trackBarFanSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarFanSpeed.Maximum = 100;
            this.trackBarFanSpeed.Name = "trackBarFanSpeed";
            this.trackBarFanSpeed.Size = new System.Drawing.Size(400, 56);
            this.trackBarFanSpeed.TabIndex = 12;
            this.trackBarFanSpeed.Value = 100;
            this.trackBarFanSpeed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackBarFanSpeed_KeyUp);
            this.trackBarFanSpeed.MouseCaptureChanged += new System.EventHandler(this.trackBarFanSpeed_MouseCaptureChanged);
            // 
            // SliderPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.refreshTemps);
            this.Controls.Add(this.labelTemps);
            this.Controls.Add(this.checkBoxEnabled);
            this.Controls.Add(this.refreshRPM);
            this.Controls.Add(this.labelRPM);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.trackBarFanSpeed);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SliderPage";
            this.Size = new System.Drawing.Size(440, 232);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFanSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Button refreshTemps;
        private System.Windows.Forms.Label labelTemps;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.Button refreshRPM;
        private System.Windows.Forms.Label labelRPM;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TrackBar trackBarFanSpeed;
    }
}
