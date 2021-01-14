using System;
using System.IO;
using System.Linq;
using GlobExpressions;
using H3VRModInstaller.Common;
using Newtonsoft.Json;

namespace H3VRModInstaller.JSON.Common
{
	/// <summary>
	///     Common fields and functions for JSON!
	/// </summary>
	public static class JsonCommon
	{
		public static String DatabaseInfo = "https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/H3VRModInstaller.Backend/JSON/Database/modinstallerinfo.h3vrmi";

		/// <summary>
		///     Gets all mods, from the JSON files
		/// </summary>
		/// <returns><c>ModFile</c> Array</returns>
		public static ModFile[] GetAllMods()
		{
			var result = new ModFile[0];
			var jsonfiles = JsonModList.GetModLists();
			for (var i = 0; i < jsonfiles.Length; i++) result = result.Concat(jsonfiles[i].Modlist).ToArray();
			return result;
		}

		public static void OverrideModInstallerVariables()
		{
			if (!File.Exists(Directory.GetCurrentDirectory() + "/" + "MICoverride.json")) return;
			Console.WriteLine("MICOverride.json detected!");
			var depinput = JsonConvert.DeserializeObject<CommonVariables>(File.ReadAllText(Directory.GetCurrentDirectory() + "/" + "MICoverride.json"));
			if (CommonVariables.Execname != null)
				ModInstallerCommon.Files.execdir = ModInstallerCommon.Files.MainFiledir + "/" + CommonVariables.Execname;
			if (CommonVariables.DatabaseInfo != null) DatabaseInfo = CommonVariables.DatabaseInfo;
		}
	}
}