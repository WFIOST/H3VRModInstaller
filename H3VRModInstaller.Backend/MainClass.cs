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
<<<<<<< Updated upstream
		/// <summary>
		/// Bypasses the check for H3VR.EXE
		/// </summary>
		public static bool BypassExec = false; 
		
		/// <summary>
		/// Location of H3VR.EXE, auto stops if not detected
		/// </summary>
		public static readonly string execdir = JsonModList.H3Vrdir + @"\H3VR.exe"; 
		/// <summary>
		/// Website used to ping to ensure internet access
		/// </summary>
		public static string pingsite = "www.github.com"; 
		/// <summary>
		/// Enables Debugging
		/// </summary>
		public static bool enableDebugging = false; 
=======
		public static bool BypassExec = false; //bypasses check for the exe
		public static readonly string execdir = modLists.H3Vrdir + @"\H3VR.exe"; //loc of the exe, auto stops if not detected
		public static string pingsite = "www.github.com"; //website used to ping to ensure internet access
		public static bool enableDebugging = false; //shits all over the console if true
>>>>>>> Stashed changes

		public static void Main(string[] args)
		{
			Console.WriteLine("Detecting if " + execdir + " exists...");

			//exe check
			if (!File.Exists(execdir) && !BypassExec) { throwexept("H3VR not found!"); return; } else { Console.WriteLine("H3VR found!"); }
			//online check
			if (!NetCheck.isOnline(pingsite)) { throwexept("Cannot connect to github!"); return; }
			//gets the whole dl list possible
			modLists.DlModList();
			Console.WriteLine("Welcome to the H3VR Mod installer!");
			Console.WriteLine("Please select the mod you would like to install using 'dl [modnamehere]' ");
			Console.WriteLine("ex: 'dl wurstmod'");
			Console.WriteLine("To see a list of downloadable mods, type 'modlists'");
			Console.WriteLine("To see a list of commands, type 'help' \n");
		Start:
			var input = Console.ReadLine();

			string[] inputargs = input.Split(' ');

			Array.Resize<string>(ref inputargs, 10); //ensures no "OUT OF INDEX TIME TO SHIT MYSELF REEEE"

		

			switch (inputargs[0])
			{
				
				case "reload":
					modLists.GetmodLists(enableDebugging, true);
					break;
				case "wipe":
					File.Delete(Directory.GetCurrentDirectory() + @"\installedmods.json");
					Console.WriteLine("Wiped!");
					break;
				case "modlists":
					listmodlists();
					break;
				case "check":
					
					ModListFormat[] ml = modLists.GetmodLists(MainClass.enableDebugging);

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

		//i'm not even sure why i made this, i was just too lazy to write two lines.
		public static void throwexept(string error)
		{
			Console.WriteLine(error);
			Console.ReadKey();
		}

		//returns a string array as foo[1], foo[2], foo[3], etc
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

		//returns list of modlists, aka modlists
		public static void listmodlists()
		{
			string[] jsonfiles = Glob.FilesAndDirectories(Directory.GetCurrentDirectory() + @"/ModInstallerLists/", "**.json").ToArray();
			for (int i = 0; i < jsonfiles.Length; i++)
			{
				jsonfiles[i] = jsonfiles[i].Remove(jsonfiles[i].Length - 5, 5);
				Console.WriteLine(jsonfiles[i]);
			}
		}

		//returns list of mods in a modlist
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
					ModListFormat[] modarray = modLists.LoadModLists(MainClass.enableDebugging, jsonarray);
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