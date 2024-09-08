using AsusFanControlGUI.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AsusFanControlGUI
{
    public partial class SliderPage : UserControl
    {
        private MainForm main;

        public SliderPage()
        {
            InitializeComponent();
        }

        public void UpdateData(MainForm parent)
        {
            main = parent;
            setCheckbox();
            trackBarFanSpeed.Value = main.fanSpeed;
        }

        private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            main.controlEnabled = checkBoxEnabled.Checked;
            Settings.Default.Enabled = main.controlEnabled;
            Settings.Default.Save();
            main.SetFansSpeed();
        }

        public void setCheckbox()
        {
            checkBoxEnabled.CheckedChanged -= checkBoxEnabled_CheckedChanged;
            checkBoxEnabled.Checked = main.controlEnabled;
            checkBoxEnabled.CheckedChanged += checkBoxEnabled_CheckedChanged;
        }

        public void setStatusLabel(string text)
        {
            labelValue.Text = text;
        }

        private void refreshRPM_Click(object sender, EventArgs e)
        {
            if (main.serviceLoaded)
            {
                List<int> fans = main.asusControl.GetFanSpeeds();
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
            if (main.serviceLoaded)
            {
                ulong gpuTemp = main.asusControl.Thermal_Read_Highest_Gpu_Temperature();

                if (gpuTemp > 0)
                    labelTemps.Text = $"Current temps: (CPU: {main.asusControl.Thermal_Read_Cpu_Temperature()}, GPU: {gpuTemp})";
                else
                    labelTemps.Text = $"Current temps: (CPU: {main.asusControl.Thermal_Read_Cpu_Temperature()})";
            }
        }

        private void trackBarFanSpeed_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Left && e.KeyCode != Keys.Right)
                return;

            trackBarFanSpeed_MouseCaptureChanged(sender, e);
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

            main.fanSpeed = (ushort)trackBarFanSpeed.Value;
            main.SetFansSpeed();
        }

        #region Themes

        public void setDarkMode()
        {
            checkBoxEnabled.ForeColor = Color.White;
            labelValue.ForeColor = Color.White;
            labelRPM.ForeColor = Color.White;
            labelTemps.ForeColor = Color.White;
            labelVersion.ForeColor = Color.White;
        }

        public void setLightMode()
        {
            checkBoxEnabled.ForeColor = SystemColors.ControlText;
            labelValue.ForeColor = SystemColors.ControlText;
            labelRPM.ForeColor = SystemColors.ControlText;
            labelTemps.ForeColor = SystemColors.ControlText;
            labelVersion.ForeColor = SystemColors.ControlText;
        }

        #endregion
    }
}