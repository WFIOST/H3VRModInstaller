using System;
using System.Diagnostics;
using System.IO;
using ModInstaller.Common;
using ModInstaller.Filesys;
using ModInstaller.Filesys.Logging;
using ModInstaller.Net;

namespace ModInstaller
{
    /// <summary>
    ///     Interpreter between backend and frontend
    /// </summary>
    public static class CommandInterpreter
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
                case "wipe":
                    File.Delete(Utilities.ModCache);
                    Console.WriteLine("Wiped!");
                    break;
            }
        }
    }
}