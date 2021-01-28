using System;
using System.Windows.Forms;

namespace H3VRModInstaller.GUI
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Console.WriteLine(Utilities.GameLocation);
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new NewWindow());
        }
    }
}