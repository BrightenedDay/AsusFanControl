using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AsusFanControlGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            bool canRun = false;
            bool startup = false;

            if (args.Length > 0  && args[0] == "/startup")
            {
                startup = true;
                byte tries = 200;

                while (tries > 0)
                {
                    tries--;
                    Thread.Sleep(1000);

                    if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "AsusFanControl.exe")))
                        canRun = true;
                }
            }
            else canRun = true;

            if (canRun && File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "AsusFanControl.exe")))
                Application.Run(new Form1(true, startup));
            else if (canRun)
                Application.Run(new Form1(false, false));
        }
    }
}
