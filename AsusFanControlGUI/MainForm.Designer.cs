namespace AsusFanControlGUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.trackBarFanSpeed = new System.Windows.Forms.TrackBar();
            this.labelValue = new System.Windows.Forms.Label();
            this.labelRPM = new System.Windows.Forms.Label();
            this.refreshRPM = new System.Windows.Forms.Button();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.refreshTemps = new System.Windows.Forms.Button();
            this.labelTemps = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMinimizeToTray = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRunOnStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemForbidUnsafeSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemResetSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemThemeSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemThemeLight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemThemeDark = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.labelVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFanSpeed)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBarFanSpeed
            // 
            this.trackBarFanSpeed.Location = new System.Drawing.Point(16, 76);
            this.trackBarFanSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarFanSpeed.Maximum = 100;
            this.trackBarFanSpeed.Name = "trackBarFanSpeed";
            this.trackBarFanSpeed.Size = new System.Drawing.Size(400, 56);
            this.trackBarFanSpeed.TabIndex = 0;
            this.trackBarFanSpeed.Value = 100;
            this.trackBarFanSpeed.KeyUp += new System.Windows.Forms.KeyEventHandler(this.trackBarFanSpeed_KeyUp);
            this.trackBarFanSpeed.MouseCaptureChanged += new System.EventHandler(this.trackBarFanSpeed_MouseCaptureChanged);
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValue.Location = new System.Drawing.Point(13, 121);
            this.labelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(156, 20);
            this.labelValue.TabIndex = 1;
            this.labelValue.Text = "Status: Disabled (N/A)";
            // 
            // labelRPM
            // 
            this.labelRPM.AutoSize = true;
            this.labelRPM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRPM.Location = new System.Drawing.Point(53, 171);
            this.labelRPM.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRPM.Name = "labelRPM";
            this.labelRPM.Size = new System.Drawing.Size(131, 20);
            this.labelRPM.TabIndex = 3;
            this.labelRPM.Text = "Current RPMs: N/A";
            this.labelRPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // refreshRPM
            // 
            this.refreshRPM.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshRPM.Location = new System.Drawing.Point(16, 171);
            this.refreshRPM.Margin = new System.Windows.Forms.Padding(4);
            this.refreshRPM.Name = "refreshRPM";
            this.refreshRPM.Size = new System.Drawing.Size(29, 28);
            this.refreshRPM.TabIndex = 4;
            this.refreshRPM.Text = "↻";
            this.refreshRPM.UseVisualStyleBackColor = true;
            this.refreshRPM.Click += new System.EventHandler(this.refreshRPM_Click);
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxEnabled.Location = new System.Drawing.Point(16, 46);
            this.checkBoxEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(76, 24);
            this.checkBoxEnabled.TabIndex = 6;
            this.checkBoxEnabled.Text = "Enable";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            this.checkBoxEnabled.CheckedChanged += new System.EventHandler(this.checkBoxEnabled_CheckedChanged);
            // 
            // refreshTemps
            // 
            this.refreshTemps.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshTemps.Location = new System.Drawing.Point(16, 201);
            this.refreshTemps.Margin = new System.Windows.Forms.Padding(4);
            this.refreshTemps.Name = "refreshTemps";
            this.refreshTemps.Size = new System.Drawing.Size(29, 28);
            this.refreshTemps.TabIndex = 8;
            this.refreshTemps.Text = "↻";
            this.refreshTemps.UseVisualStyleBackColor = true;
            this.refreshTemps.Click += new System.EventHandler(this.refreshTemps_Click);
            // 
            // labelTemps
            // 
            this.labelTemps.AutoSize = true;
            this.labelTemps.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTemps.Location = new System.Drawing.Point(53, 207);
            this.labelTemps.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTemps.Name = "labelTemps";
            this.labelTemps.Size = new System.Drawing.Size(146, 20);
            this.labelTemps.TabIndex = 7;
            this.labelTemps.Text = "Current temps: (N/A)";
            this.labelTemps.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.White;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSettings,
            this.menuItemCheckForUpdates});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip.Size = new System.Drawing.Size(432, 30);
            this.menuStrip.TabIndex = 10;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.BackColor = System.Drawing.Color.White;
            this.menuItemSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMinimizeToTray,
            this.menuItemRunOnStartup,
            this.menuItemForbidUnsafeSettings,
            this.menuItemResetSettings,
            this.menuItemTheme,
            this.menuItemQuit});
            this.menuItemSettings.Name = "menuItemSettings";
            this.menuItemSettings.Size = new System.Drawing.Size(76, 26);
            this.menuItemSettings.Text = "Settings";
            // 
            // menuItemMinimizeToTray
            // 
            this.menuItemMinimizeToTray.CheckOnClick = true;
            this.menuItemMinimizeToTray.Name = "menuItemMinimizeToTray";
            this.menuItemMinimizeToTray.Size = new System.Drawing.Size(315, 26);
            this.menuItemMinimizeToTray.Text = "Minimize to tray on window close";
            this.menuItemMinimizeToTray.CheckedChanged += new System.EventHandler(this.menuItemMinimizeToTray_CheckedChanged);
            // 
            // menuItemRunOnStartup
            // 
            this.menuItemRunOnStartup.CheckOnClick = true;
            this.menuItemRunOnStartup.Name = "menuItemRunOnStartup";
            this.menuItemRunOnStartup.Size = new System.Drawing.Size(315, 26);
            this.menuItemRunOnStartup.Text = "Run on startup";
            this.menuItemRunOnStartup.CheckedChanged += new System.EventHandler(this.menuItemRunOnStartup_CheckedChanged);
            // 
            // menuItemForbidUnsafeSettings
            // 
            this.menuItemForbidUnsafeSettings.CheckOnClick = true;
            this.menuItemForbidUnsafeSettings.Name = "menuItemForbidUnsafeSettings";
            this.menuItemForbidUnsafeSettings.Size = new System.Drawing.Size(315, 26);
            this.menuItemForbidUnsafeSettings.Text = "Forbid unsafe settings";
            this.menuItemForbidUnsafeSettings.CheckedChanged += new System.EventHandler(this.menuItemForbidUnsafeSettings_CheckedChanged);
            // 
            // menuItemResetSettings
            // 
            this.menuItemResetSettings.Name = "menuItemResetSettings";
            this.menuItemResetSettings.Size = new System.Drawing.Size(315, 26);
            this.menuItemResetSettings.Text = "Reset settings";
            this.menuItemResetSettings.Click += new System.EventHandler(this.menuItemResetSettings_Click);
            // 
            // menuItemTheme
            // 
            this.menuItemTheme.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemThemeSystem,
            this.menuItemThemeLight,
            this.menuItemThemeDark});
            this.menuItemTheme.Name = "menuItemTheme";
            this.menuItemTheme.Size = new System.Drawing.Size(315, 26);
            this.menuItemTheme.Text = "Theme: System";
            // 
            // menuItemThemeSystem
            // 
            this.menuItemThemeSystem.Name = "menuItemThemeSystem";
            this.menuItemThemeSystem.Size = new System.Drawing.Size(139, 26);
            this.menuItemThemeSystem.Text = "System";
            this.menuItemThemeSystem.Click += new System.EventHandler(this.menuItemThemeSystem_Click);
            // 
            // menuItemThemeLight
            // 
            this.menuItemThemeLight.Name = "menuItemThemeLight";
            this.menuItemThemeLight.Size = new System.Drawing.Size(139, 26);
            this.menuItemThemeLight.Text = "Light";
            this.menuItemThemeLight.Click += new System.EventHandler(this.menuItemThemeLight_Click);
            // 
            // menuItemThemeDark
            // 
            this.menuItemThemeDark.Name = "menuItemThemeDark";
            this.menuItemThemeDark.Size = new System.Drawing.Size(139, 26);
            this.menuItemThemeDark.Text = "Dark";
            this.menuItemThemeDark.Click += new System.EventHandler(this.menuItemThemeDark_Click);
            // 
            // menuItemQuit
            // 
            this.menuItemQuit.Name = "menuItemQuit";
            this.menuItemQuit.Size = new System.Drawing.Size(315, 26);
            this.menuItemQuit.Text = "Quit";
            this.menuItemQuit.Click += new System.EventHandler(this.QuitApplication_Click);
            // 
            // menuItemCheckForUpdates
            // 
            this.menuItemCheckForUpdates.Name = "menuItemCheckForUpdates";
            this.menuItemCheckForUpdates.Size = new System.Drawing.Size(142, 26);
            this.menuItemCheckForUpdates.Text = "Check for updates";
            this.menuItemCheckForUpdates.Click += new System.EventHandler(this.menuItemCheckForUpdates_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVersion.Font = new System.Drawing.Font("Cascadia Code SemiLight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(309, 222);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelVersion.Size = new System.Drawing.Size(117, 20);
            this.labelVersion.TabIndex = 11;
            this.labelVersion.Text = "v1.5";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(432, 244);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.refreshTemps);
            this.Controls.Add(this.labelTemps);
            this.Controls.Add(this.checkBoxEnabled);
            this.Controls.Add(this.refreshRPM);
            this.Controls.Add(this.labelRPM);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.trackBarFanSpeed);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asus Fan Control";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFanSpeed)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBarFanSpeed;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Label labelRPM;
        private System.Windows.Forms.Button refreshRPM;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.Button refreshTemps;
        private System.Windows.Forms.Label labelTemps;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemMinimizeToTray;
        private System.Windows.Forms.ToolStripMenuItem menuItemForbidUnsafeSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemCheckForUpdates;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.ToolStripMenuItem menuItemTheme;
        private System.Windows.Forms.ToolStripMenuItem menuItemThemeSystem;
        private System.Windows.Forms.ToolStripMenuItem menuItemThemeLight;
        private System.Windows.Forms.ToolStripMenuItem menuItemThemeDark;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuit;
        private System.Windows.Forms.ToolStripMenuItem menuItemRunOnStartup;
        private System.Windows.Forms.ToolStripMenuItem menuItemResetSettings;
    }
}

