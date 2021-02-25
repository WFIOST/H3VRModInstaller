using System;
using System.Diagnostics;
using System.IO;
using H3VRModInstaller.Common;
using H3VRModInstaller.Filesys;
using H3VRModInstaller.Filesys.Logging;
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
            for (int repeat = 1; repeat < inputargs.Length; repeat++)
            {
                Console.WriteLine("doing {0} {1}", inputargs[0], inputargs[repeat]);
                switch (inputargs[0])
                {
                    case "dl":
                        Downloader.DownloadModDirector(inputargs[repeat]);
                        break;
                    //deletion
                    case "rm":
                        Console.WriteLine($"Deleting {inputargs[repeat]}");
                        Uninstaller.DeleteMod(inputargs[repeat]);
                        break;
                    case "disable":
                        Disabler.EnableDisableMod(inputargs[repeat]);
                        break;
                    default:
                        Console.WriteLine("Invalid command!");
                        break;
                }
            }

            switch (inputargs[0])
            {
                case "toggledebugging":
                    ModInstallerCommon.enableDebugging = !ModInstallerCommon.enableDebugging;
                    Console.WriteLine("Debugging is now " + ModInstallerCommon.enableDebugging);
                    break;
                case "wipe":
                    File.Delete(Utilities.ModCache);
                    Console.WriteLine("Wiped!");
                    break;
            }
        }
    }
}