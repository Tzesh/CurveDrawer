﻿using System;
using System.Windows.Forms;

namespace _CurveDrawer
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CurveForm());
        }
    }
}
