using System;
using System.Windows.Forms;
using System.Threading;

namespace H3VRModInstaller
{
    internal static class Program
    {
		/// <summary>
		///     The main entry point for the application.
		/// </summary>
		[STAThread]
        private static void Main()
        {
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			mainwindow mainform = new mainwindow();
			mainform.KeyPreview = true;
            Application.Run(mainform);

        }
    }
}