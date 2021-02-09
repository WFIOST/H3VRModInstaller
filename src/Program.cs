using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using H3VRModInstaller.Common;

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
			string loc;
			//SETUP
			if (!File.Exists(Utilities.ModCache))
			{
				loc = Utilities.GameDirectory + "/H3VRMI/installedmods.json";
				if (File.Exists(loc))
				{
					goto setcache;
				}
				loc = Utilities.GameDirectory + "/H3VR Mod Installer/installedmods.json";
				if (File.Exists(loc))
				{
					goto setcache;
				}
				goto skip;
				setcache:
				Utilities.ModCache = loc;
				Console.WriteLine("Mod cache location overwritten to {0}!", loc);
				skip:; //FUCK YOU, I USE GOTO IF I WANT TO USE GOTO AND YOU CAN'T STOP ME -potatoes
			}
			//END SETUP
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			mainwindow mainform = new mainwindow();
			mainform.KeyPreview = true;
            Application.Run(mainform);

		}
    }
}