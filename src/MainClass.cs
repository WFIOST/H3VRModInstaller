using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using GlobExpressions;
using H3VRModInstaller.Common;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.JSON;
using H3VRModInstaller.Net;

namespace H3VRModInstaller
{
    /// <summary>
    ///     MainClass, dunno what you expected
    /// </summary>
    public class MainClass
    {
		public static void doCommand(string inputstring)
		{
			doCommand(inputstring.Split(' '));
		}

        /// <summary>
        ///     Backend input
        /// </summary>
        /// <param name="inputargs">Input</param>
		/// 
        public static void doCommand(string[] inputargs)
        {
            switch (inputargs[0])
            {
                case "wipe":
                    File.Delete(Utilities.ModCache);
                    Console.WriteLine("Wiped!");
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
    }
}