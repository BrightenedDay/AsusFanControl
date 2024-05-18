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
    public partial class Form1 : Form
    {
        private dynamic asusControl;
        private int fanSpeed = 0;
        private bool serviceLoaded = false;

        public Form1(bool referenceAvailable)
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

            // Themes
            if (Settings.Default.Theme == 1)
                setLightTheme();
            else if(Settings.Default.Theme == 2)
                setDarkTheme();
            else
                SystemTheme();

            labelValue.Text = $"Status: Disabled ({Settings.Default.fanSpeed}%)";

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            menuItemDisableOnExit.Checked = Settings.Default.turnOffControlOnExit;
            menuItemForbidUnsafeSettings.Checked = Settings.Default.forbidUnsafeSettings;
            trackBarFanSpeed.Value = Settings.Default.fanSpeed;
        }

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

        private void SystemTheme()
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
            menuItemDisableOnExit.ForeColor = Color.White;
            menuItemForbidUnsafeSettings.ForeColor = Color.White;
            labelValue.ForeColor = Color.White;
            labelRPM.ForeColor = Color.White;
            labelTemps.ForeColor = Color.White;
            //refreshRPM.ForeColor = Color.White;
            //refreshCPUTemp.ForeColor = Color.White;
            labelVersion.ForeColor = Color.White;
            checkBoxEnabled.ForeColor = Color.White;
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
            menuItemDisableOnExit.ForeColor = SystemColors.ControlText;
            menuItemForbidUnsafeSettings.ForeColor = SystemColors.ControlText;
            labelValue.ForeColor = SystemColors.ControlText;
            labelRPM.ForeColor = SystemColors.ControlText;
            labelTemps.ForeColor = SystemColors.ControlText;
            //refreshRPM.ForeColor = SystemColors.ControlText;
            //refreshCPUTemp.ForeColor = SystemColors.ControlText;
            labelVersion.ForeColor = SystemColors.ControlText;
            checkBoxEnabled.ForeColor = SystemColors.ControlText;
        }

        #endregion

        private void OnProcessExit(object sender, EventArgs e)
        {
            if (serviceLoaded)
                if (Settings.Default.turnOffControlOnExit)
                    asusControl.SetFanSpeeds(0);
        }

        private void menuItemDisableOnExit_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.turnOffControlOnExit = menuItemDisableOnExit.Checked;
            Settings.Default.Save();
        }

        private void menuItemForbidUnsafeSettings_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.forbidUnsafeSettings = menuItemForbidUnsafeSettings.Checked;
            Settings.Default.Save();
        }

        private void menuItemCheckForUpdates_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Karmel0x/AsusFanControl/releases");
        }

        private void setFanSpeed()
        {
            int value = trackBarFanSpeed.Value;
            Settings.Default.fanSpeed = value;
            Settings.Default.Save();

            if (!checkBoxEnabled.Checked)
                value = 0;

            if (value == 0)
                labelValue.Text = $"Status: Disabled ({trackBarFanSpeed.Value}%)";
            else
                labelValue.Text = $"Fan Speed: {value}%";

            if (fanSpeed == value)
                return;

            fanSpeed = value;

            if (serviceLoaded)
                asusControl.SetFanSpeeds(fanSpeed);
        }

        private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
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

        private void refreshCPUTemp_Click(object sender, EventArgs e)
        {
            if (serviceLoaded)
            {
                ulong gpuTemp = asusControl.Thermal_Read_GpuTS1L_Temperature() + asusControl.Thermal_Read_GpuTS1R_Temperature();

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
            SystemTheme();
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
    }
}