using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using AsusFanControlGUI.Properties;
using Microsoft.Win32;

namespace AsusFanControlGUI
{
    public partial class MainForm : Form
    {
        public dynamic asusControl;
        public bool serviceLoaded = false;
        public bool controlEnabled = false;
        public ushort fanSpeed = 0;
        private NotifyIcon notifyIcon;
        private MenuItem trayCheckBoxEnable;
        private bool resetting = false;


        public MainForm(bool referenceAvailable, bool startup)
        {
            #region ReferenceLoader

            // In case AsusFanControl fails to load
            if (referenceAvailable)
            {
                try
                {
                    Assembly assembly = Assembly.Load("AsusFanControl");
                    Type controlServiceType = assembly.GetType("AsusFanControl.AsusControl");
                    asusControl = Activator.CreateInstance(controlServiceType);
                    serviceLoaded = true;
                }
                catch
                {
                    MessageBox.Show("Couldn't load 'AsusControl. Please make sure that AsusFanControl.exe is in the same folder as 'AsusFanControlGUI.exe'.", "Load Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Couldn't find 'AsusFanControl.exe' in the same folder as 'AsusFanControlGUI.exe'.", "AsusFanControl.exe Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #endregion

            InitializeComponent();

            // Initialize tray if 'AsusFanControl.exe' loaded in
            if (serviceLoaded)
            {
                notifyIcon = new NotifyIcon();
                notifyIcon.Text = "ASUS Fan Control";
                notifyIcon.Icon = Resources.appIcon;

                trayCheckBoxEnable = new MenuItem("Enable", traySwitchState_Click);

                notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] {
                    trayCheckBoxEnable,
                    new MenuItem("Quit", QuitApplication_Click)
                });

                notifyIcon.Visible = false;

                notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            }

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            if (startup)
            {
                notifyIcon.Visible = true;
            }

            // Themes
            if (Settings.Default.Theme == 1)
                setLightTheme();
            else if(Settings.Default.Theme == 2)
                setDarkTheme();
            else
                setSystemTheme();

            LoadSettings(false);
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            if (serviceLoaded)
                asusControl.SetFanSpeeds(0);
        }

        private void QuitApplication_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        #region Fan Speeds Setters

        public void SetFansSpeed()
        {
            ushort value = fanSpeed;
            Settings.Default.FanSpeed = fanSpeed;
            Settings.Default.Save();

            if (!controlEnabled)
                value = 0;

            if (value == 0)
            {
                trayCheckBoxEnable.Text = "Status: Disabled";
                sliderPage.setStatusLabel($"Status: Disabled ({fanSpeed}%)");
            }
            else
            {
                trayCheckBoxEnable.Text = "Status: Enabled";
                sliderPage.setStatusLabel($"Fan Speed: {fanSpeed}%");
            }

            if (serviceLoaded)
                asusControl.SetFanSpeeds(value);
        }

        #endregion

        public bool getEnbd() { return controlEnabled; }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (Settings.Default.MinimizeToTray)
            {
                e.Cancel = true;
                this.Visible = false;;
                notifyIcon.Visible = true;
            }

            base.OnFormClosing(e);
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.ExitThread();
        }

        private void LoadSettings(bool setSystemTheme = true)
        {
            resetting = true;
            menuItemMinimizeToTray.Checked = Settings.Default.MinimizeToTray;
            menuItemRunOnStartup.Checked = Settings.Default.RunOnStartup;
            menuItemForbidUnsafeSettings.Checked = Settings.Default.forbidUnsafeSettings;
            controlEnabled = Settings.Default.Enabled;
            fanSpeed = Settings.Default.FanSpeed;

            if (Settings.Default.Mode == 0)
                menuItemMode.Text = "Mode: Slider";
            else if (Settings.Default.Mode == 1)
                menuItemMode.Text = "Mode: Curve";

            LoadModeTemplate();

            sliderPage.UpdateData(this);

            SetFansSpeed();

            if (setSystemTheme)
                this.setSystemTheme();

            resetting = false;
        }

        private void LoadModeTemplate()
        {
            if (Settings.Default.Mode == 0)
            {
                curvePage.Enabled = false;
                curvePage.Visible = false;

                this.Size = new Size(340, 237);

                sliderPage.Enabled = true;
                sliderPage.Visible = true;

            }
            else if (Settings.Default.Mode == 1)
            {
                sliderPage.Enabled = false;
                sliderPage.Visible = false;

                this.Size = new Size(450, 350);

                curvePage.Enabled = true;
                curvePage.Visible = true;
            }
        }

        #region GUI stuff

        #region Themes

        #region Title bar

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        public static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {
                int attribute = 19;
                if (IsWindows10OrGreater(18985))
                {
                    attribute = 20;
                }

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            return false;
        }

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }

        #endregion

        private void setSystemTheme()
        {
            menuItemTheme.Text = "Theme: System";

            try
            {
                int? systemTheme = (int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\Personalize", "AppsUseLightTheme", -1);

                if (systemTheme != null)
                    if (systemTheme != 1 && systemTheme != 3)
                        setDarkTheme(false);
                    else
                        setLightTheme(false);
            }
            catch { } // I'll leave this empty for now
        }

        private void setDarkTheme(bool setLabel = true)
        {
            if (setLabel)
                menuItemTheme.Text = "Theme: Dark";

            UseImmersiveDarkMode(Handle, true);
            menuStrip.Renderer = new MenuStripDarkModeRenderer();

            this.BackColor = Color.FromArgb(30, 30, 30);
            menuStrip.BackColor = Color.FromArgb(40, 40, 60);

            // Text
            menuItemSettings.ForeColor = Color.White;
            menuItemCheckForUpdates.ForeColor = Color.White;
            menuItemTheme.ForeColor = Color.White;
            menuItemThemeSystem.ForeColor = Color.White;
            menuItemThemeLight.ForeColor = Color.White;
            menuItemThemeDark.ForeColor = Color.White;
            menuItemMinimizeToTray.ForeColor = Color.White;
            menuItemForbidUnsafeSettings.ForeColor = Color.White;
            menuItemQuit.ForeColor = Color.White;
            menuItemRunOnStartup.ForeColor = Color.White;
            menuItemResetSettings.ForeColor = Color.White;
            menuItemMode.ForeColor = Color.White;
            menuItemModeSlider.ForeColor = Color.White;
            menuItemModeCurve.ForeColor = Color.White;

            sliderPage.setDarkMode();
        }

        private void setLightTheme(bool setLabel = true)
        {
            if (setLabel)
                menuItemTheme.Text = "Theme: Light";

            UseImmersiveDarkMode(Handle, false);
            menuStrip.Renderer = new MenuStripLightModeRenderer();

            this.BackColor = SystemColors.Control;
            menuStrip.BackColor = Color.White;


            // Text
            menuItemSettings.ForeColor = SystemColors.ControlText;
            menuItemCheckForUpdates.ForeColor = SystemColors.ControlText;
            menuItemTheme.ForeColor = SystemColors.ControlText;
            menuItemThemeSystem.ForeColor = SystemColors.ControlText;
            menuItemThemeLight.ForeColor = SystemColors.ControlText;
            menuItemThemeDark.ForeColor = SystemColors.ControlText;
            menuItemMinimizeToTray.ForeColor = SystemColors.ControlText;
            menuItemForbidUnsafeSettings.ForeColor = SystemColors.ControlText;
            menuItemQuit.ForeColor = SystemColors.ControlText;
            menuItemRunOnStartup.ForeColor = SystemColors.ControlText;
            menuItemResetSettings.ForeColor = SystemColors.ControlText;
            menuItemMode.ForeColor = SystemColors.ControlText;
            menuItemModeSlider.ForeColor = SystemColors.ControlText;
            menuItemModeCurve.ForeColor = SystemColors.ControlText;

            sliderPage.setLightMode();
        }

        #endregion

        private void traySwitchState_Click(object sender, EventArgs e)
        {
            controlEnabled = !controlEnabled;
            sliderPage.setCheckbox();
            SetFansSpeed();
        }

        private void menuItemThemeSystem_Click(object sender, EventArgs e)
        {
            Settings.Default.Theme = 0;
            Settings.Default.Save();
            setSystemTheme();
        }

        private void menuItemThemeLight_Click(object sender, EventArgs e)
        {
            Settings.Default.Theme = 1;
            Settings.Default.Save();
            setLightTheme();
        }

        private void menuItemThemeDark_Click(object sender, EventArgs e)
        {
            Settings.Default.Theme = 2;
            Settings.Default.Save();
            setDarkTheme();
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.CenterToScreen();
            this.Visible = true;;
            this.BringToFront();
            notifyIcon.Visible = false;
        }

        private void menuItemMinimizeToTray_CheckedChanged(object sender, EventArgs e)
        {
            if (!resetting)
            {
                Settings.Default.MinimizeToTray = menuItemMinimizeToTray.Checked;
                Settings.Default.Save();
            }
        }

        private void menuItemForbidUnsafeSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (!resetting)
            {
                Settings.Default.forbidUnsafeSettings = menuItemForbidUnsafeSettings.Checked;
                Settings.Default.Save();
            }
        }

        private void menuItemCheckForUpdates_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/BrightenedDay/AsusFanControl/releases/latest");
        }

        private void menuItemRunOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                using (RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    if (menuItemRunOnStartup.Checked)
                        rk.SetValue("ASUSFanControl", '"' + Application.ExecutablePath.Replace('/', '\\') + '"' + " -startup");
                    else
                        rk.DeleteValue("ASUSFanControl", false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            if (!resetting)
            {
                Settings.Default.RunOnStartup = menuItemRunOnStartup.Checked;
                Settings.Default.Save();
            }
        }

        private void menuItemResetSettings_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            Settings.Default.Save();
            LoadSettings();
        }

        private void menuItemModeSlider_Click(object sender, EventArgs e)
        {
            Settings.Default.Mode = 0;
            Settings.Default.Save();
            menuItemMode.Text = "Mode: Slider";
            LoadModeTemplate();
        }

        private void menuItemModeCurve_Click(object sender, EventArgs e)
        {
            Settings.Default.Mode = 1;
            Settings.Default.Save();
            menuItemMode.Text = "Mode: Curve";
            LoadModeTemplate();
        }

        #endregion

        //private void graphControl1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    for (int i = 0; i < graphControl1.points.Count; i++)
        //    {
        //        int y = graphControl1.Height - e.Y;
        //        (int, int) current = graphControl1.points[i];
        //        if (current.Item1 == e.X && current.Item2 == y)
        //        {
        //            MessageBox.Show("Clicked: " + i);
        //            break;
        //        }
        //    }
        //}
    }
}