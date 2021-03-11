using System;
using System.IO;
using System.Windows.Forms.VisualStyles;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.Filesys.Logging
{
    public static class Logger
    {
        static StringWriter sw = new StringWriter();
        public static void InitialiseLog()
        {
           
            #if !DEBUG //if this is enabled during debugging, it stops rider's console from working, epic!!!! -potatoes
			Console.SetOut(sw); //redirect all console info to sw
			Console.SetError(sw);
            #endif
            Console.WriteLine("Now starting log output- time is " + DateTime.Now + "!");
        }

        public static void FinalizeLog()
        {
            File.WriteAllText(Utilities.LogPath, sw.ToString());
            Console.WriteLine($"Log Initialised, exporting to {Utilities.LogPath}");
        }
    }
}