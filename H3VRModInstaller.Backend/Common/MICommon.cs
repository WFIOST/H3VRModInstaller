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

namespace H3VRModInstaller
{
	//For commonly used vars and voids.
	public class MICommon
	{
		/// <summary>
		/// Enables Debugging
		/// </summary>
		public static bool enableDebugging = false;
		/// <summary>
		/// Bypasses the check for H3VR.EXE
		/// </summary>
		public static bool BypassExec = false;
		/// <summary>
		/// Location of H3VR.EXE, auto stops if not detected
		/// </summary>
		public static readonly string execdir = MainFiledir + @"\H3VR.exe";
		/// <summary>
		/// Website used to ping to ensure internet access
		/// </summary>
		public static string pingsite = "www.github.com";
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

		public static void DebugLog(string input)
		{
			if (enableDebugging) Console.WriteLine(input);
		}
	}
}
