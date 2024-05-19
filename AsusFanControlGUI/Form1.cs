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
    public partial class Main : Form
    {
        private NotifyIcon notifyIcon;
        private MenuItem trayCheckBoxEnable;
        private dynamic asusControl;
        private int fanSpeed = 0;
        private bool serviceLoaded = false;
        bool resetting = false;

        public Main(bool referenceAvailable, bool startup)
        {
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

        private void setFanSpeed()
        {
            int value = trackBarFanSpeed.Value;
            Settings.Default.fanSpeed = value;
            Settings.Default.Save();

            if (!checkBoxEnabled.Checked)
                value = 0;

            if (value == 0)
            {
                trayCheckBoxEnable.Text = "Status: Disabled";
                labelValue.Text = $"Status: Disabled ({trackBarFanSpeed.Value}%)";
            }
            else
            {
                trayCheckBoxEnable.Text = "Status: Enabled";
                labelValue.Text = $"Fan Speed: {value}%";
            }

            if (fanSpeed == value)
                return;

            fanSpeed = value;

            if (serviceLoaded)
                asusControl.SetFanSpeeds(fanSpeed);
        }

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
            checkBoxEnabled.Checked = Settings.Default.Enabled;
            trackBarFanSpeed.Value = Settings.Default.fanSpeed;
            setFanSpeed();

            if (setSystemTheme)
                this.setSystemTheme();

            resetting = false;
        }

        #region GUI stuff

        #region Themes

        #region Title Bar

        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
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

        private bool IsWindows10OrGreater(int build = -1)
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
            labelValue.ForeColor = Color.White;
            labelRPM.ForeColor = Color.White;
            labelTemps.ForeColor = Color.White;
            //refreshRPM.ForeColor = Color.White;
            //refreshCPUTemp.ForeColor = Color.White;
            labelVersion.ForeColor = Color.White;
            checkBoxEnabled.ForeColor = Color.White;
            menuItemQuit.ForeColor = Color.White;
            menuItemRunOnStartup.ForeColor = Color.White;
            menuItemResetSettings.ForeColor = Color.White;
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
            labelValue.ForeColor = SystemColors.ControlText;
            labelRPM.ForeColor = SystemColors.ControlText;
            labelTemps.ForeColor = SystemColors.ControlText;
            //refreshRPM.ForeColor = SystemColors.ControlText;
            //refreshCPUTemp.ForeColor = SystemColors.ControlText;
            labelVersion.ForeColor = SystemColors.ControlText;
            checkBoxEnabled.ForeColor = SystemColors.ControlText;
            menuItemQuit.ForeColor = SystemColors.ControlText;
            menuItemRunOnStartup.ForeColor = SystemColors.ControlText;
            menuItemResetSettings.ForeColor = SystemColors.ControlText;
        }

        #endregion

        private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (!resetting)
            {
                Settings.Default.Enabled = checkBoxEnabled.Checked;
                Settings.Default.Save();
                setFanSpeed();
            }
        }

        private void traySwitchState_Click(object sender, EventArgs e)
        {
            checkBoxEnabled.Checked = !checkBoxEnabled.Checked;
            setFanSpeed();
        }

        private void trackBarFanSpeed_MouseCaptureChanged(object sender, EventArgs e)
        {
            if (Settings.Default.forbidUnsafeSettings)
            {
                if (trackBarFanSpeed.Value < 40)
                    trackBarFanSpeed.Value = 40;
                else if (trackBarFanSpeed.Value > 99)
                    trackBarFanSpeed.Value = 99;
            }

            setFanSpeed();
        }

        private void trackBarFanSpeed_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
                return;

            trackBarFanSpeed_MouseCaptureChanged(sender, e);
        }

        private void refreshRPM_Click(object sender, EventArgs e)
        {
            if (serviceLoaded)
            {
                List<int> fans = asusControl.GetFanSpeeds();
                StringBuilder fanRPMs = new StringBuilder();

                fanRPMs.Append("Current RPMs: ");

                for (int i = 0; i < fans.Count; i++)
                {
                    if (i == 0)
                        fanRPMs.Append($"Fan {i + 1}: {fans[i]}");
                    else
                        fanRPMs.Append($", Fan {i + 1}: {fans[i]}");
                }
                labelRPM.Text = fanRPMs.ToString();
            }
        }

        private void refreshTemps_Click(object sender, EventArgs e)
        {
            if (serviceLoaded)
            {
                ulong gpuTemp = asusControl.Thermal_Read_Highest_Gpu_Temperature();

                if (gpuTemp > 0)
                    labelTemps.Text = $"Current temps: (CPU: {asusControl.Thermal_Read_Cpu_Temperature()}, GPU: {gpuTemp})";
                else
                    labelTemps.Text = $"Current temps: (CPU: {asusControl.Thermal_Read_Cpu_Temperature()})";
            }
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
            System.Diagnostics.Process.Start("https://github.com/Karmel0x/AsusFanControl/releases");
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

        #endregion
    }
}