﻿using AsusSystemAnalysis;
using System.Collections.Generic;

namespace AsusFanControl
{
    public class AsusControl
    {
        public AsusControl()
        {
            AsusWinIO64.InitializeWinIo();
        }

        ~AsusControl()
        {
            AsusWinIO64.ShutdownWinIo();
        }

        public void SetFanSpeed(byte value, byte fanIndex = 0)
        {
            AsusWinIO64.HealthyTable_SetFanIndex(fanIndex);
            AsusWinIO64.HealthyTable_SetFanTestMode((char)(value > 0 ? 0x01 : 0x00));
            AsusWinIO64.HealthyTable_SetFanPwmDuty(value);
        }

        public void SetFanSpeed(int percent, byte fanIndex = 0)
        {
            var value = (byte)(percent / 100.0f * 255);
            SetFanSpeed(value, fanIndex);
        }

        public void SetFanSpeeds(byte value)
        {
            int fanCount = AsusWinIO64.HealthyTable_FanCounts();
            for(byte fanIndex = 0; fanIndex < (byte)fanCount; fanIndex++)
            {
                SetFanSpeed(value, fanIndex);
            }
        }

        public void SetFanSpeeds(int percent)
        {
            var value = (byte)(percent / 100.0f * 255);
            SetFanSpeeds(value);
        }

        public int GetFanSpeed(byte fanIndex = 0)
        {
            AsusWinIO64.HealthyTable_SetFanIndex(fanIndex);
            var fanSpeed = AsusWinIO64.HealthyTable_FanRPM();
            return fanSpeed;
        }

        public List<int> GetFanSpeeds()
        {
            var fanSpeeds = new List<int>();

            var fanCount = AsusWinIO64.HealthyTable_FanCounts();
            for (byte fanIndex = 0; fanIndex < fanCount; fanIndex++)
            {
                var fanSpeed = GetFanSpeed(fanIndex);
                fanSpeeds.Add(fanSpeed);
            }

            return fanSpeeds;
        }

        public int HealthyTable_FanCounts()
        {
            return AsusWinIO64.HealthyTable_FanCounts();
        }

        public ulong Thermal_Read_Cpu_Temperature()
        {
            return AsusWinIO64.Thermal_Read_Cpu_Temperature();
        }

        public ulong Thermal_Read_GpuTS1L_Temperature()
        {
            return AsusWinIO64.Thermal_Read_GpuTS1L_Temperature();
        }

        public ulong Thermal_Read_GpuTS1R_Temperature()
        {
            return AsusWinIO64.Thermal_Read_GpuTS1R_Temperature();
        }

        public ulong Thermal_Read_Highest_Gpu_Temperature()
        {
            ulong left = AsusWinIO64.Thermal_Read_GpuTS1L_Temperature();
            ulong right = AsusWinIO64.Thermal_Read_GpuTS1R_Temperature();

            if (left > right)
                return left;
            else
                return right;
        }
    }
}