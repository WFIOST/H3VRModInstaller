using System;
using System.IO;
using ModInstaller.Common;

namespace ModInstaller.Filesys.Logging
{
    public static class Logger
    {
        public static void InitialiseLog()
        {
            var writer = new StringWriter();
            #if !DEBUG //if this is enabled during debugging, it stops rider's console from working, epic!!!! -potatoes
			Console.SetOut(sw); //redirect all console info to sw
			Console.SetError(sw);
            #endif
            
            File.WriteAllText(Utilities.LogPath, writer.ToString());
            Console.WriteLine($"Log Initialised, exporting to {Utilities.LogPath}");
        }
    }
}