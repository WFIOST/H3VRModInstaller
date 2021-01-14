using System;
using System.IO;

namespace H3VRModInstaller.Common
{
    /// <summary>
    /// Some common variables used across the project
    /// </summary>
    public struct CommonVariables
    {
        /// <summary>
        /// Name for the executable targeted
        /// </summary>
        /// <value>String</value>
        public static string Execname { get; set; }
        /// <summary>
        /// Location of the modinstallerinfo.h3vrmi
        /// </summary>
        /// <value></value>
        public static string DatabaseInfo { get; set; }
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

        /// <summary>
        /// "better" errors
        /// </summary>
        /// <param name="error">Error to write</param>
        public static void throwexept(string error)
        {
            Console.Title = "ERROR! - " + error;
            Console.ForegroundColor = System.ConsoleColor.Red;
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

        /// <summary>
        /// Useful fields for filesystem work
        /// </summary>
        public struct Files
        {
	        /// <summary>
	        ///     Location of H3VR.EXE, auto stops if not detected
	        /// </summary>
	        public static string execdir = MainFiledir + "/H3VR.exe";

	        /// <summary>
	        ///     Loc of the main file with the exe inside
	        /// </summary>
	        public static string MainFiledir = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

	        /// <summary>
	        ///     loc of the MI lists.
	        /// </summary>
	        public static string Modinstallerdir = Directory.GetCurrentDirectory() + @"/ModInstallerLists/";
        }
    }
}