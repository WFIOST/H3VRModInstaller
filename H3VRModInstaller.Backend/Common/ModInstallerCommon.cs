using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H3VRModInstaller.JSON;
using Newtonsoft.Json;
using System.IO;
using GlobExpressions;
using System.Net;
using System.IO.Compression;

namespace H3VRModInstaller.Common
{
	/// <summary>
	/// Commonly used functions and fields
	/// </summary>
	public class ModInstallerCommon
	{
		/// <summary>
		/// Enables Debugging
		/// </summary>
		public static bool EnableDebugging = true;
		/// <summary>
		/// Bypasses the check for H3VR.EXE
		/// </summary>
		public static bool BypassExec = true;
		/// <summary>
		/// Location of H3VR.EXE, auto stops if not detected
		/// </summary>
		public static readonly string Execdir = MainFiledir + @"\H3VR.exe";
		/// <summary>
		/// Website used to ping to ensure internet access
		/// </summary>
		public static string Pingsite = "www.github.com";
		/// <summary>
		/// Loc of the main file with the exe inside
		/// </summary>
		public static string MainFiledir = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
		/// <summary>
		/// loc of the MI lists.
		/// </summary>
		public static string Modinstallerdir = Directory.GetCurrentDirectory() + @"/ModInstallerLists/";
		/// <summary>
		/// Website where the database is located.
		/// </summary>
		public static string[] Modlistloc = { "https://github.com/Frityet/H3VRModInstaller/releases/download/database/", "ModList.zip" };

		/// <summary>
		/// Writes line if enabledebugging is true.
		/// </summary>
		public static void DebugLog(string input)
		{
			if (EnableDebugging) Console.WriteLine(input);
		}

		//i'm not even sure why i made this, i was just too lazy to write two lines.
		public static void Throwexept(string error)
		{
			Console.WriteLine(error);
			Console.ReadKey();
		}

		/// <summary>
		/// returns a string array as foo[1], foo[2], foo[3], etc
		/// </summary>
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
		

		/// <summary>
		/// Commonly used directories
		/// </summary>
		public struct Directories
		{
			/// <summary>
			/// H3VR Directory
			/// </summary>
			public static string H3VrDir = Directory.GetCurrentDirectory() + "/";
			/// <summary>
			/// BepInEx Directory
			/// </summary>
			public static string BepinexDir = Directory.GetCurrentDirectory() + "/" + "BepInEx/";
			/// <summary>
			/// Plugins Directory
			/// </summary>
			public static string PluginsDir = Directory.GetCurrentDirectory() + "/" + "BepInEx/" + "Plugins/";
			/// <summary>
			/// Mods Directory
			/// </summary>
			public static string ModsDirs = Directory.GetCurrentDirectory() + "/" + "mods/";
		}
	}
	
	

}
