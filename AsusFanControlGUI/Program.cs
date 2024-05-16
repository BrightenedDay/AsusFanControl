﻿using System;
using System.IO;
using System.Windows.Forms;

namespace AsusFanControlGUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "AsusFanControl.exe")))
                Application.Run(new Form1(true));
            else
                Application.Run(new Form1(false));
        }
    }
}
