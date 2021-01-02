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
	public class MainClass
	{



		
		//private static Serialisation Json = new Serialisation();
		public static bool BypassExec = false;
		public static readonly string execdir = JsonModList.H3Vrdir + @"\H3VR.exe";
		public static string pingsite = "www.github.com";
		public static bool enableDebugging = false;

		public static void Main(string[] args)
		{
			Console.WriteLine("Detecting if " + execdir + " exists...");

			if (!File.Exists(execdir) && !BypassExec) { throwexept("H3VR not found!"); return; } else { Console.WriteLine("H3VR found!"); }
			if (!NetCheck.isOnline(pingsite)) { throwexept("Cannot connect to github!"); return; }
			JsonModList.DlModList();
			Console.WriteLine("Welcome to the H3VR Mod installer!");
			Console.WriteLine("Please select the mod you would like to install using 'dl [modnamehere]' ");
			Console.WriteLine("ex: 'dl wurstmod'");
			Console.WriteLine("To see a list of downloadable mods, type 'modlists'");
			Console.WriteLine("To see a list of commands, type 'help'");
		Start:
			var input = Console.ReadLine();

			string[] inputargs = input.Split(' ');

			Array.Resize<string>(ref inputargs, 10);

			Console.WriteLine("");

			switch (inputargs[0])
			{
				case "reload":
					JsonModList.GetmodLists(enableDebugging, true);
					break;
				case "wipe":
					File.Delete(Directory.GetCurrentDirectory() + @"\installedmods.json");
					Console.WriteLine("Wiped!");
					break;
				case "modlists":
					listmodlists();
					break;
				case "check":

					ModListFormat[] ml = JsonModList.GetmodLists(MainClass.enableDebugging);

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
					if (inputargs[1] == "installedmods") { Console.WriteLine(ReturnArrayInString(InstalledMods.GetInstalledMods())); }
					else { list(inputargs[1]); }
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
					enableDebugging = !enableDebugging;
					Console.WriteLine("Debugging is now " + enableDebugging);
					break;
				//deletion
				case "rm":
					Console.WriteLine($"Deleting {inputargs[1]}");
					 
					break;
					
				
				
				default:
					Console.WriteLine("Invalid command!");
					break;
				
			}
			Console.WriteLine("");
			goto Start;
		}

		public static void throwexept(string error)
		{
			Console.WriteLine(error);
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
			string[] jsonfiles = Glob.FilesAndDirectories(Directory.GetCurrentDirectory() + @"/ModInstallerLists/", "**.json").ToArray();
			for (int i = 0; i < jsonfiles.Length; i++)
			{
				jsonfiles[i] = jsonfiles[i].Remove(jsonfiles[i].Length - 5, 5);
				Console.WriteLine(jsonfiles[i]);
			}
		}

		public static void list(string input)
		{
			string jsonname = input + ".json";
			string[] jsonfiles = Glob.FilesAndDirectories(Directory.GetCurrentDirectory() + @"/ModInstallerLists/", "**.json").ToArray();
			bool foundmod = false;
			for (int i = 0; i < jsonfiles.Length; i++)
			{
				if (jsonname == jsonfiles[i])
				{
					foundmod = true;
					string[] jsonarray = { jsonname };
					ModListFormat[] modarray = JsonModList.LoadModLists(MainClass.enableDebugging, jsonarray);
					ModListFormat mods = modarray[0];
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
	}
}