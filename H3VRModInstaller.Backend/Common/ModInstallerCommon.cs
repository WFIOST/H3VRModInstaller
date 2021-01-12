using System;
using System.IO;

namespace H3VRModInstaller.Common
{
    public struct CommonVariables
    {
        public static bool EnableDebugging { get; set; }
        public static bool BypassExec { get; set; }
        public static string Execname { get; set; }
        public static string Pingsite { get; set; }
        public static string[] Modlistloc { get; set; }
    }

    /// <summary>
    ///     Commonly used functions and fields
    /// </summary>
    public class ModInstallerCommon
    {
	    /// <summary>
	    ///     Enables Debugging
	    /// </summary>
	    public static bool enableDebugging = true;

	    /// <summary>
	    ///     Bypasses the check for H3VR.EXE
	    /// </summary>
	    public static bool BypassExec = true;

	    /// <summary>
	    ///     Website used to ping to ensure internet access
	    /// </summary>
	    public static string Pingsite = "www.github.com";

	    /// <summary>
	    ///     Current version.
	    /// </summary>
	    public static Version ModInstallerVersion = new(1, 0, 0);


	    /// <summary>
	    ///     Writes line if enabledebugging is true.
	    /// </summary>
	    public static void DebugLog(string input)
        {
            if (enableDebugging) Console.WriteLine(input);
        }

        //i'm not even sure why i made this, i was just too lazy to write two lines.
        public static void throwexept(string error)
        {
            Console.WriteLine(error);
            Console.ReadKey();
        }

        /// <summary>
        ///     returns a string array as foo[1], foo[2], foo[3], etc
        /// </summary>
        public static string ReturnArrayInString(string[] array)
        {
            var strng = "";
            for (var i = 0; i < array.Length; i++)
            {
                strng += array[i];
                strng += ", ";
            }

            return strng;
        }

        public struct Files
        {
	        /// <summary>
	        ///     Location of H3VR.EXE, auto stops if not detected
	        /// </summary>
	        public static string execdir = MainFiledir + @"\H3VR.exe";

	        /// <summary>
	        ///     Loc of the main file with the exe inside
	        /// </summary>
	        public static string MainFiledir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

	        /// <summary>
	        ///     loc of the MI lists.
	        /// </summary>
	        public static string Modinstallerdir = Directory.GetCurrentDirectory() + @"/ModInstallerLists/";

	        /// <summary>
	        ///     Website where the database is located.
	        /// </summary>
	        public static string[] Modlistloc =
                {"https://github.com/Frityet/H3VRModInstaller/releases/download/database/ModList.zip", "ModList.zip"};
        }
    }
}