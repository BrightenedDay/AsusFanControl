using System;

namespace AsusFanControl
{
    internal static class Program
    {
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage: AsusFanControl <args>");
                Console.WriteLine("\t--get-fan-speeds");
                Console.WriteLine("\t--set-fan-speeds=0-100 (percent value, 0 for turning off test mode)");
                Console.WriteLine("\t--get-fan-count");
                Console.WriteLine("\t--get-fan-speed=fanId (comma separated)");
                Console.WriteLine("\t--set-fan-speed=fanId:0-100 (comma separated, percent value, 0 for turning off test mode)");
                Console.WriteLine("\t--get-cpu-temp");
                Console.WriteLine("\t--get-gpu-ts1l-temp");
                Console.WriteLine("\t--get-gpu-ts1r-temp");
                Console.WriteLine("\t--get-highest-gpu-temp");
                return 1;
            }

            var asusControl = new AsusControl();

            foreach (var arg in args)
            {
                if (arg.StartsWith("--get-fan-speeds"))
                {
                    var fanSpeeds = asusControl.GetFanSpeeds();
                    Console.WriteLine($"Current fan speeds: {string.Join(" ", fanSpeeds)} RPM");
                }

                if (arg.StartsWith("--set-fan-speeds"))
                {
                    var newSpeedStr = arg.Split('=')[1];
                    var newSpeed = int.Parse(newSpeedStr);
                    asusControl.SetFanSpeeds(newSpeed);

                    if(newSpeed == 0)
                        Console.WriteLine("Test mode turned off");
                    else
                        Console.WriteLine($"New fan speeds: {newSpeed}%");
                }

                if (arg.StartsWith("--get-fan-speed="))
                {
                    var fanIds = arg.Split('=')[1].Split(',');
                    foreach (var fanIdStr in fanIds)
                    {
                        var fanId = int.Parse(fanIdStr);
                        var fanSpeed = asusControl.GetFanSpeed((byte)fanId);
                        Console.WriteLine($"Current fan speed for fan {fanId}: {fanSpeed} RPM");
                    }
                }

                if (arg.StartsWith("--get-fan-count"))
                {
                    var fanCount = asusControl.HealthyTable_FanCounts();
                    Console.WriteLine($"Fan count: {fanCount}");
                }

                if (arg.StartsWith("--set-fan-speed="))
                {
                    var fanSettings = arg.Split('=')[1].Split(',');
                    foreach (var fanSetting in fanSettings)
                    {
                        var fanId = int.Parse(fanSetting.Split(':')[0]);
                        var fanSpeed = int.Parse(fanSetting.Split(':')[1]);
                        asusControl.SetFanSpeed(fanSpeed, (byte)fanId);

                        if (fanSpeed == 0)
                            Console.WriteLine($"Test mode turned off for fan {fanId}");
                        else
                            Console.WriteLine($"New fan speed for fan {fanId}: {fanSpeed}%");
                    }
                }

                if (arg.StartsWith("--get-cpu-temp"))
                {
                    var cpuTemp = asusControl.Thermal_Read_Cpu_Temperature();
                    Console.WriteLine($"Current CPU temp: {cpuTemp}");
                }

                if (arg.StartsWith("--get-gpu-ts1l-temp"))
                {
                    var temp = asusControl.Thermal_Read_GpuTS1L_Temperature();
                    Console.WriteLine($"Current GPU TS1L temp: {temp}");
                }

                if (arg.StartsWith("--get-gpu-ts1r-temp"))
                {
                    var temp = asusControl.Thermal_Read_GpuTS1R_Temperature();
                    Console.WriteLine($"Current GPU TS1R temp: {temp}");
                }

                if (arg.StartsWith("--get-highest-gpu-temp"))
                {
                    var temp = asusControl.Thermal_Read_Highest_Gpu_Temperature();
                    Console.WriteLine($"Current Highest GPU temp: {temp}");
                }
            }

            return 0;
        }
    }
}