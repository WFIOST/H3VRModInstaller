using System;
using System.Windows.Forms;
using H3VRModInstaller.Filesys.Logging;
using System.IO;
using H3VRModInstaller.Common;
using H3VRModInstaller.Filesys;
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
			//start initialization
			Logger.InitialiseLog();
			CheckCache();
			CheckForManualInstalledMods();
			CheckForManuallyUninstalledMods();
			//end initialization
			//start mainform init
			Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			mainwindow mainform = new mainwindow();
			mainform.KeyPreview = true;
            Application.Run(mainform);
            //end mainform init
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

		public static void CheckForManualInstalledMods()
		{
			ModFile[] mods = ModParsing.GetAllMods();
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

		public static void CheckForManuallyUninstalledMods()
		{
			ModFile[] instmods = InstalledMods.GetInstalledMods();
			string addedmods = "";
			for (int i = 0; i < instmods.Length; i++)
			{
				if (!string.IsNullOrEmpty(instmods[i].DelInfo) && instmods[i].Version != "0.0.0" ) 
				{
					string delinfo = instmods[i].DelInfo.Split('?')[0];
					string delinfo1 = Path.Combine(Utilities.GameDirectory, delinfo);
					string delinfo2 = Path.Combine(Utilities.DisableCache, new DirectoryInfo(delinfo).Name);
					if (File.Exists(delinfo1) || Directory.Exists(delinfo1) || File.Exists(delinfo2) || Directory.Exists(delinfo2)) //if not exist in files or discache
					{

					}
					else
					{
						Console.WriteLine("Mod {0} not detected at {1}, or {2}!", instmods[i].ModId, delinfo1, delinfo2);
						addedmods += instmods[i].Name + ", ";
						InstalledMods.RemoveInstalledMod(instmods[i].ModId);
						instmods[i].Version = "0.0.0";
						InstalledMods.AddInstalledMod(instmods[i]);
					}
				}
			}
			if (!String.IsNullOrEmpty(addedmods))
			{
				var conf = MessageBox.Show($"We cannot find some mods that you've downloaded! Did you delete them?\n Either way, we've highlighted them in yellow if you want to reinstall them or delete them. (Their version reads 0.0.0.)\n Detected mods: {addedmods.Split(',').Length} \n" + addedmods, "Installed mods detected!", MessageBoxButtons.OK);
			}
		}
    }
}