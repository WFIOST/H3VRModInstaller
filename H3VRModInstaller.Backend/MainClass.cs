using System;
using System.Diagnostics;
using System.IO;
using H3VRModInstaller.Net;
using H3VRModInstaller.JSON;
using GlobExpressions;
using H3VRModInstaller.Common;
using System.Linq;
using H3VRModInstaller.Filesys;

namespace H3VRModInstaller
{
	/// <summary>
	/// MainClass, dunno what you expected
	/// </summary>
	public class MainClass
	{

		/// <summary>
		/// Main function, the args arent used though
		/// </summary>
		/// <param name="args">dunno why these are here</param>
		public static void Main(string[] args)
		{
			Console.WriteLine("Detecting if " + ModInstallerCommon.Execdir + " exists...");

			//exe check
			if (!File.Exists(ModInstallerCommon.Execdir) && !ModInstallerCommon.BypassExec) { ModInstallerCommon.Throwexept("H3VR not found!"); return; } else { Console.WriteLine("H3VR found!"); }
			//online check
			if (!NetCheck.isOnline(ModInstallerCommon.Pingsite)) { ModInstallerCommon.Throwexept("Cannot connect to github!"); return; }
			//gets the whole dl list possible
			JsonModList.DlModList();
			Console.WriteLine("Welcome to the H3VR Mod installer!");
			Console.WriteLine("Please select the mod you would like to install using 'dl [modnamehere]' ");
			Console.WriteLine("ex: 'dl wurstmod'");
			Console.WriteLine("To see a list of downloadable mods, type 'modlists'");
			Console.WriteLine("To see a list of commands, type 'help' \n");
			CheckVersion();
		Start:
			var input = Console.ReadLine();

			string[] inputargs = input.Split(' ');

			Array.Resize<string>(ref inputargs, 10); //ensures no "OUT OF INDEX TIME TO SHIT MYSELF REEEE"

		

			switch (inputargs[0])
			{
				case "reload":
					JsonModList.GetModLists(true);
					break;
				case "wipe":
					File.Delete(Directory.GetCurrentDirectory() + @"\installedmods.json");
					Console.WriteLine("Wiped!");
					break;
				case "modlists":
					Listmodlists();
					break;
				case "check":
					
					ModListFormat[] ml = JsonModList.GetModLists();

					for (int i = 0; i < ml.Length; i++)
					{
						for (int x = 0; x < ml[i].Modlist.Length; x++)
						{
							if (ml[i].Modlist[x].ModId == inputargs[1])
							{
								string link = ml[i].Modlist[x].Website;
								var psi = new ProcessStartInfo
								{
									FileName = link,
									UseShellExecute = true
								};
								Process.Start(psi);
							}
						}
					}

					break;
				case "dl":
					Downloader.DownloadModDirector(inputargs[1]);
					break;
				case "install":
					Downloader.DownloadModDirector(inputargs[1], true);
					break;
				case "list":
					if (inputargs[1] == "installedmods")
					{
						ModFile[] mf = InstalledMods.GetInstalledMods();
						for (int i = 0; i < mf.Length; i++) { Console.WriteLine(mf[i].ModId); }
					}
					else { List(inputargs[1]); }
					break;
				case "exit":
					return;
				case "help":
					Console.WriteLine("wipe - Wipes the installed registry (DOES NOT DELETE MODS)");
					Console.WriteLine("modlists - Lists all modlists, which are lists of mods.");
					Console.WriteLine("dl [modname] - Downloads mod listed.");
					Console.WriteLine("check [modname] - Opens browser to modpage.");
					Console.WriteLine("list [modlist] - Lists all mods contained in a modlist.");
					Console.WriteLine("list installedmods - Lists all mods registered as installed.");
					Console.WriteLine("exit - Close H3VRModInstaller.");
					break;
				case "toggledebugging":
					ModInstallerCommon.EnableDebugging = !ModInstallerCommon.EnableDebugging;
					Console.WriteLine("Debugging is now " + ModInstallerCommon.EnableDebugging);
					break;
				//deletion
				case "rm":
					Console.WriteLine($"Deleting {inputargs[1]}...");
					Uninstaller.DeleteMod(inputargs[1]);
					break;
				default:
					Console.WriteLine("Invalid command!");
					break;
				
			}
			Console.WriteLine("");
			goto Start;
		}



		//returns list of modlists, aka modlists
		public static void Listmodlists()
		{
			string[] jsonfiles = Glob.FilesAndDirectories(Directory.GetCurrentDirectory() + @"/ModInstallerLists/", "**.json").ToArray();
			for (int i = 0; i < jsonfiles.Length; i++)
			{
				jsonfiles[i] = jsonfiles[i].Remove(jsonfiles[i].Length - 5, 5);
				Console.WriteLine(jsonfiles[i]);
			}
		}

		//returns list of mods in a modlist
		public static void List(string input)
		{
			string jsonname = input + ".json";
			string[] jsonfiles = Glob.FilesAndDirectories(Directory.GetCurrentDirectory() + @"/ModInstallerLists/", "**.json").ToArray();
			bool foundmod = false;
			for (int i = 0; i < jsonfiles.Length; i++)
			{
				if (jsonname == jsonfiles[i])
				{
					foundmod = true;
					ModListFormat mods = JsonModList.DeserializeModListFormat(jsonname);
					for (int x = 0; x < mods.Modlist.Length; x++)
					{
						Console.WriteLine(mods.Modlist[x].ModId);
					}
				}
			}
			if (foundmod == false)
			{
				Console.WriteLine("List not found!");
			}
		}

		public static void CheckVersion()
		{
			Version publicversion = null;
			Version.TryParse(JsonModList.GetOnlineModInstallerInfo().Version, out publicversion); //turns string ModFile.Version to a Version variable
			switch(ModInstallerCommon.ModInstallerVersion.CompareTo(publicversion))
			{
				case 0: //if same version
					Console.WriteLine("Mod installer is up to date!");
					break;
				case 1: //if it has a higher version than listed online
					Console.WriteLine("Mod installer is a newer version than is found online! What's going on?!");
					Console.WriteLine("(Current version is {0}, version found is {1})", ModInstallerCommon.ModInstallerVersion, publicversion);
					break;
					break;
				case -1: //if out of date
					Console.WriteLine("Mod installer is out of date! Please update!");
					Console.WriteLine("(Current version is {0}, version found is {1})", ModInstallerCommon.ModInstallerVersion, publicversion);
					break;
			}
		}
	}
}