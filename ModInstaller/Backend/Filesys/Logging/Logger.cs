using System;
using System.IO;
using System.Windows.Forms.VisualStyles;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.Filesys.Logging
{
    public static class Logger
    {
        static FileStream ostrm;
        static StreamWriter writer;
        static TextWriter oldOut = Console.Out;
        public static void InitialiseLog()
        {
            //#if !DEBUG
            string logpath;
            try
            {
                logpath = Utilities.LogPath;
            }
            catch
            {
                logpath = Directory.GetCurrentDirectory() + "/Modinstaller.log";
            }
            
            try
            {
                File.Delete(logpath);
                ostrm = new FileStream (logpath, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter (ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine ("Cannot open {0} for writing", logpath);
                Console.WriteLine (e.Message);
                return;
            }
            Console.SetOut (writer);
            //#endif
        }

        public static void FinalizeLog()
        {
            //#if !DEBUG
            Utilities.GenerateTree();
            Console.SetOut (oldOut);
            writer.Close();
            ostrm.Close();
            //#endif
        }
    }
}