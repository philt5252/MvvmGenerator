using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Olf.MvvmGenerator;

namespace LauncherApp
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Launcher.Launch();
        }
    }
}
