using System;
using System.Diagnostics;
using System.IO;
using H3VRModInstaller.Net;
using H3VRModInstaller.JSON;
using GlobExpressions;
using System.Collections.Generic;
using System.Linq;

namespace H3VRModInstaller
{
    class MainClass
    {
	    //private static Serialisation Json = new Serialisation();
        private static bool BypassH3VR = false;
        private static readonly Downloader downloader = new Downloader();
        public static void Main(string[] args)
        {
			Console.WriteLine("Detecting if " + ModLists.h3vrdir + @"\H3VR.exe" + " exists...");
	        
	        if (File.Exists(ModLists.h3vrdir + @"\H3VR.exe") || BypassH3VR)
			{
				Console.WriteLine("H3VR.exe detected");
				ModLists.ModListDownload();
				Console.WriteLine("Welcome to the H3VR Mod installer!");
				Console.WriteLine("Please select the mod you would like to install using 'dl [modnamehere]' ");
				Console.WriteLine("ex: 'dl wurstmod'");
				Console.WriteLine("To see a list of downloadable mods, type 'modlists'");
				Console.WriteLine("To see a list of commands, type 'help'");
			Start:
				var input = Console.ReadLine();

				string[] inputargs = input.Split(' ');

				Array.Resize<string>(ref inputargs, 10);

				switch (inputargs[0])
				{
					case "wipe":
						File.Delete(Directory.GetCurrentDirectory() + @"\installedmods.json");
						Console.WriteLine("Wiped!");
						break;
					case "modlists":
						listmodlists();
						break;
					case "check":

						ModListFormat[] ml = ModLists.LoadModLists();

						for (int i = 0; i < ml.Length; i++)
						{
							for (int x = 0; x < ml[i].modlist.Length; x++)
							{
								if (ml[i].modlist[x].modID == inputargs[1])
								{
									string link = ml[i].modlist[x].Website;
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
						if (inputargs[1] == "installedmods") { Console.WriteLine(ReturnArrayInString(InstalledMods.GetInstalledMods())); }
						else { list(inputargs[1]); }
						break;
					case "exit":
						return;
					case "help":
						Console.WriteLine("wipe - Wipes all data for installed mods.");
						Console.WriteLine("modlists - Lists all modlists, which are lists of mods.");
						Console.WriteLine("dl [modname] - Downloads mod listed.");
						Console.WriteLine("check [modname] - Opens browser to modpage.");
						Console.WriteLine("list [modlist] - Lists all mods contained in a modlist.");
						Console.WriteLine("list installedmods - Lists all mods registered as installed.");
						Console.WriteLine("exit - Close H3VRModInstaller.");
						break;
					default:
						Console.WriteLine("Invalid command!");
						break;
				}

				goto Start;

			}
			else
			{
				Console.WriteLine("H3VR.exe not detected!");
				Console.ReadKey();
			}
			Console.ReadKey();
		}

		public static string ReturnArrayInString(string[] array)
		{
			string strng = "";
			for (int i = 0; i < array.Length; i++)
			{
				strng += array[i];
				strng += ", ";
			}
			return strng;
		}

		public static void listmodlists()
		{
			Console.WriteLine("");
			string[] jsonfiles = Glob.FilesAndDirectories(Directory.GetCurrentDirectory() + @"/ModInstallerLists/", "**.json").ToArray();
			for (int i = 0; i < jsonfiles.Length; i++)
			{
				jsonfiles[i] = jsonfiles[i].Remove(jsonfiles[i].Length - 5, 5);
				Console.WriteLine(jsonfiles[i]);
			}
			Console.WriteLine("");
		}

		public static void list(string input)
		{
			Console.WriteLine("");
			string jsonname = input + ".json";
			string[] jsonfiles = Glob.FilesAndDirectories(Directory.GetCurrentDirectory() + @"/ModInstallerLists/", "**.json").ToArray();
			bool foundmod = false;
			for (int i = 0; i < jsonfiles.Length; i++)
			{
				if(jsonname == jsonfiles[i])
				{
					foundmod = true;
					ModListFormat mods = ModLists.LoadSpecificJSON(jsonname);
					for (int x = 0; x < mods.modlist.Length; x++)
					{
						Console.WriteLine(mods.modlist[x].modID);
					}
				}
			}
			if(foundmod == false)
			{
				Console.WriteLine("List not found!");
			}
			Console.WriteLine("");
		}
	}
}