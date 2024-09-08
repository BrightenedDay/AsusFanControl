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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMinimizeToTray = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRunOnStartup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemForbidUnsafeSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemMode = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemModeSlider = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemModeCurve = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemTheme = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemThemeSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemThemeLight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemThemeDark = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemResetSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.sliderPage = new AsusFanControlGUI.SliderPage();
            this.curvePage = new AsusFanControlGUI.CurvePage();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
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
            this.menuItemMode,
            this.menuItemTheme,
            this.menuItemResetSettings,
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
            // menuItemMode
            // 
            this.menuItemMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemModeSlider,
            this.menuItemModeCurve});
            this.menuItemMode.Name = "menuItemMode";
            this.menuItemMode.Size = new System.Drawing.Size(315, 26);
            this.menuItemMode.Text = "Mode: Slider";
            // 
            // menuItemModeSlider
            // 
            this.menuItemModeSlider.Name = "menuItemModeSlider";
            this.menuItemModeSlider.Size = new System.Drawing.Size(130, 26);
            this.menuItemModeSlider.Text = "Slider";
            this.menuItemModeSlider.Click += new System.EventHandler(this.menuItemModeSlider_Click);
            // 
            // menuItemModeCurve
            // 
            this.menuItemModeCurve.Name = "menuItemModeCurve";
            this.menuItemModeCurve.Size = new System.Drawing.Size(130, 26);
            this.menuItemModeCurve.Text = "Curve";
            this.menuItemModeCurve.Click += new System.EventHandler(this.menuItemModeCurve_Click);
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
            // menuItemResetSettings
            // 
            this.menuItemResetSettings.Name = "menuItemResetSettings";
            this.menuItemResetSettings.Size = new System.Drawing.Size(315, 26);
            this.menuItemResetSettings.Text = "Reset settings";
            this.menuItemResetSettings.Click += new System.EventHandler(this.menuItemResetSettings_Click);
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
            // sliderPage
            // 
            this.sliderPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliderPage.Location = new System.Drawing.Point(0, 30);
            this.sliderPage.Margin = new System.Windows.Forms.Padding(0);
            this.sliderPage.Name = "sliderPage";
            this.sliderPage.Size = new System.Drawing.Size(432, 214);
            this.sliderPage.TabIndex = 12;
            this.sliderPage.TabStop = false;
            // 
            // curvePage
            // 
            this.curvePage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.curvePage.Location = new System.Drawing.Point(0, 0);
            this.curvePage.Margin = new System.Windows.Forms.Padding(0);
            this.curvePage.Name = "curvePage";
            this.curvePage.Size = new System.Drawing.Size(432, 244);
            this.curvePage.TabIndex = 13;
            this.curvePage.TabStop = false;
            this.curvePage.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(432, 244);
            this.Controls.Add(this.sliderPage);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.curvePage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asus Fan Control";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItemSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemMinimizeToTray;
        private System.Windows.Forms.ToolStripMenuItem menuItemForbidUnsafeSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemCheckForUpdates;
        private System.Windows.Forms.ToolStripMenuItem menuItemTheme;
        private System.Windows.Forms.ToolStripMenuItem menuItemThemeSystem;
        private System.Windows.Forms.ToolStripMenuItem menuItemThemeLight;
        private System.Windows.Forms.ToolStripMenuItem menuItemThemeDark;
        private System.Windows.Forms.ToolStripMenuItem menuItemQuit;
        private System.Windows.Forms.ToolStripMenuItem menuItemRunOnStartup;
        private System.Windows.Forms.ToolStripMenuItem menuItemResetSettings;
        private System.Windows.Forms.ToolStripMenuItem menuItemMode;
        private System.Windows.Forms.ToolStripMenuItem menuItemModeSlider;
        private System.Windows.Forms.ToolStripMenuItem menuItemModeCurve;
        private SliderPage sliderPage;
        private CurvePage curvePage;
    }
}

