using System;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using H3VRModInstaller.Common;
using H3VRModInstaller.JSON.Common;
using H3VRModInstaller.JSON;

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
			CheckCache();
			CheckForManualInstalledMods();



			Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			mainwindow mainform = new mainwindow();
			mainform.KeyPreview = true;
            Application.Run(mainform);

		}

		private static void CheckCache()
		{
			string loc;
			if (!File.Exists(Utilities.ModCache))
			{
				loc = Path.Combine(Utilities.GameDirectory, "H3VRMI/installedmods.json");
				if (File.Exists(loc))
				{
					goto setcache;
				}
				loc = Path.Combine(Utilities.GameDirectory, "H3VR Mod Installer/installedmods.json");
				if (File.Exists(loc))
				{
					goto setcache;
				}
				goto skip;
			setcache:
				/*Utilities.ModCache = loc;
				Console.WriteLine("Mod cache location overwritten to {0}!", loc);*/
				Console.WriteLine("Old mod cache location found, moving to {0}!", Utilities.GameDirectory + "/installed_mods.json");
				File.Move(loc, Utilities.GameDirectory + "/installed_mods.json");
			skip:; //FUCK YOU, I USE GOTO IF I WANT TO USE GOTO AND YOU CAN'T STOP ME -potatoes
			}
		}

		private static void CheckForManualInstalledMods()
		{
			ModFile[] mods = JsonCommon.GetAllMods();
			ModFile[] instmods = InstalledMods.GetInstalledMods();
			string addedmods = "";
			for (int i = 0; i < mods.Length; i++)
			{
				if (!string.IsNullOrEmpty(mods[i].DelInfo))
				{
					if (File.Exists(Path.Combine(Utilities.GameDirectory, mods[i].DelInfo)))
					{
						bool IsInstalled = false;
						for (int x = 0; x < instmods.Length; x++)
						{
							if (mods[i].ModId == instmods[x].ModId)
							{
								IsInstalled = true;
								break;
							}
						}
						if (!IsInstalled)
						{
							addedmods += mods[i].ModId + ", ";
							InstalledMods.AddInstalledMod(mods[i].ModId);
						}
					}
				}
			}
			if (!String.IsNullOrEmpty(addedmods))
			{
				var conf = MessageBox.Show($"Some manually installed mods have been detected, adding it to database. Detected mods: {addedmods.Split(',').Length} \n" + addedmods, "Installed mods detected!", MessageBoxButtons.OK);
			}
		}
    }
}