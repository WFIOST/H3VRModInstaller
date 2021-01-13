using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using GlobExpressions;
using H3VRModInstaller.Common;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.JSON;
using H3VRModInstaller.JSON.Common;
using H3VRModInstaller.Net;


namespace H3VRModInstaller
{

	/// <summary>
	///     MainClass, dunno what you expected
	/// </summary>
	public class MainClass
    {
	    /// <summary>
	    ///     Main function, the args arent used though
	    /// </summary>
	    /// <param name="args">dunno why these are here</param>
	    public static void Main(string[] args)
        {
            JsonCommon.OverrideModInstallerVariables();
            //exe check
            Console.WriteLine("Detecting if " + ModInstallerCommon.Files.execdir + " exists...");
            if (!File.Exists(ModInstallerCommon.Files.execdir) && !ModInstallerCommon.BypassExec)
            {
                ModInstallerCommon.throwexept("H3VR not found!");
                return;
            }

            Console.WriteLine("H3VR found!");
            //online check
            if (!NetCheck.isOnline(ModInstallerCommon.Pingsite))
            {
                ModInstallerCommon.throwexept("Cannot connect to github!");
                return;
            }

            //gets the whole dl list possible
            JsonModList.DlModList();
            Console.WriteLine("Welcome to the H3VR Mod installer!");
            Console.WriteLine("Please select the mod you would like to install using 'dl [modnamehere]' ");
            Console.WriteLine("ex: 'dl wurstmod'");
            Console.WriteLine("To see a list of downloadable mods, type 'modlists'");
            Console.WriteLine("To see a list of commands, type 'help' \n");
            Start:
            var input = Console.ReadLine();

            var inputargs = input.Split(' ');

            Array.Resize(ref inputargs, 10); //ensures no "OUT OF INDEX TIME TO SHIT MYSELF REEEE"


            doCommand(inputargs);

            Console.WriteLine("");
            goto Start;
        }

        /// <summary>
        /// Backend input
        /// </summary>
        /// <param name="inputargs">Input</param>
        public static void doCommand(string[] inputargs)
        {
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
                    listmodlists();
                    break;
                case "check":

                    var ml = JsonModList.GetModLists();

                    for (var i = 0; i < ml.Length; i++)
                    for (var x = 0; x < ml[i].Modlist.Length; x++)
                        if (ml[i].Modlist[x].ModId == inputargs[1])
                        {
                            var link = ml[i].Modlist[x].Website;
                            var psi = new ProcessStartInfo
                            {
                                FileName = link,
                                UseShellExecute = true
                            };
                            Process.Start(psi);
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
                        var mf = InstalledMods.GetInstalledMods();
                        for (var i = 0; i < mf.Length; i++) Console.WriteLine(mf[i].Name);
                    }
                    else
                    {
                        list(inputargs[1]);
                    }

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
                    ModInstallerCommon.enableDebugging = !ModInstallerCommon.enableDebugging;
                    Console.WriteLine("Debugging is now " + ModInstallerCommon.enableDebugging);
                    break;
                //deletion
                case "rm":
                    Console.WriteLine($"Deleting {inputargs[1]}");
                    Uninstaller.DeleteMod(inputargs[1]);
                    break;
                default:
                    Console.WriteLine("Invalid command!");
                    break;
            }
        }


        
        ///returns list of modlists, aka modlists
        public static void listmodlists()
        {
            var jsonfiles = Glob.FilesAndDirectories(Directory.GetCurrentDirectory() + @"/ModInstallerLists/", "**.json").ToArray();
            for (var i = 0; i < jsonfiles.Length; i++)
            {
                jsonfiles[i] = jsonfiles[i].Remove(jsonfiles[i].Length - 5, 5);
                Console.WriteLine(jsonfiles[i]);
            }
        }

        ///returns list of mods in a modlist
        public static void list(string input)
        {
            var jsonname = input + ".json";
            var jsonfiles = Glob
                .FilesAndDirectories(Directory.GetCurrentDirectory() + @"/ModInstallerLists/", "**.json").ToArray();
            var foundmod = false;
            for (var i = 0; i < jsonfiles.Length; i++)
                if (jsonname == jsonfiles[i])
                {
                    foundmod = true;
                    var mods = JsonModList.DeserializeModListFormat(jsonname);
                    for (var x = 0; x < mods.Modlist.Length; x++) Console.WriteLine(mods.Modlist[x].ModId);
                }

            if (foundmod == false) Console.WriteLine("List not found!");
        }
    }
}