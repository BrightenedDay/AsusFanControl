using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace AsusFanControlGUI
{
    internal static class Program
    {
        private const string appGuid = "s0h87b5a-122ab-88j5-b5d9-dg5hfal6e7p9";

        [STAThread]
        static void Main(string[] args)
        {
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (args.Length > 0 && args[0] == "-startup")
                {
                    MainForm main = new MainForm(true, true);
                    main.Visible = false;
                    Application.Run();
                }
                else
                {
                    if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "AsusFanControl.exe")))
                        Application.Run(new MainForm(true, false));
                    else
                        Application.Run(new MainForm(false, false));
                }
            }
        }
    }
}
