using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using GlobExpressions;
using System.Net;
using System.IO.Compression;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.JSON
{
	/// <summary>
	/// Standard JSON file info for a mod
	/// </summary>
	public class ModFile
    {
	    /// <summary>
	    /// Unique identifier given to each mod for use in the UI
	    /// </summary>
		public string ModId { get; set; }
	    /// <summary>
	    /// Name of the mod, for use in <c>help</c>
	    /// </summary>
		public string Name { get; set; }
	    /// <summary>
	    /// The raw filename of the mod once downloaded
	    /// </summary>
		public string RawName { get; set; }
	    /// <summary>
	    /// Author(s) of the mod
	    /// </summary>
		public string[] Author { get; set; }
	    /// <summary>
	    /// Version of the mod
	    /// </summary>
		public string Version { get; set; }
	    /// <summary>
	    /// Description of the mod
	    /// </summary>
		public string Description { get; set; }
	    /// <summary>
	    /// URL of the download path, combines with <c>RawName</c> to download the mod
	    /// </summary>
		public string Path { get; set; }
	    /// <summary>
	    /// Website of the mod, if there isn't any, type the Github/Bonetome page
	    /// </summary>
		public string Website { get; set; }
	    /// <summary>
	    /// How the file should be handled once downloaded
	    /// </summary>
	    /// <example>
	    /// moveToFolder?ComradeKolbasa.zip?Mods/?ComradeKolbasa.zip
	    /// </example>
	    /// <remarks>
	    /// The <c>?</c> in the arguments are used as they cannot be inputted normally, and seperate the arguments
	    /// </remarks>
		public string Arguments { get; set; }
		/// <summary>
		/// Info needed to delete this file.
		/// </summary>
		public string DelInfo { get; set; }
		/// <summary>
		/// All the dependencies of the mod, must be the <c>ModID</c>
		/// </summary>
		public string[] Dependencies { get; set; }
    }

	/// <summary>
	/// Contains an array of ModFiles.
	/// </summary>
	public class ModListFormat
	{
		/// <summary>
		/// Allows for multiple mods in 1 file to be added
		/// </summary>
		public ModFile[] Modlist { get; set; }
	}
	
	/// <summary>
	/// This class manages the modlists, including downloading and loading
	/// </summary>
    public class JsonModList
    {
		private static readonly WebClient Client = new();
		public static ModListFormat[] ModList;

		/// <summary>
		/// Downloads mods from ModInstallerCommon.Modlistloc
		/// </summary>
		public static void DlModList()
		{
			if (ModInstallerCommon.dlmodlist == false) { Console.WriteLine("Download aborted."); return; }
			Uri fileloc = new Uri(ModInstallerCommon.Modlistloc[0] + ModInstallerCommon.Modlistloc[1]);
			Console.WriteLine("Downloading Mod Database...");
			Client.DownloadFile(fileloc, ModInstallerCommon.Modlistloc[1]);
			Console.WriteLine("Successfully Downloaded Mod Database");
			Directory.CreateDirectory(ModInstallerCommon.Modinstallerdir);
			ZipFile.ExtractToDirectory(ModInstallerCommon.Modlistloc[1], ModInstallerCommon.Modinstallerdir, true);
			File.Delete(ModInstallerCommon.Modlistloc[1]);
		}
		
		/// <summary>
		/// Gets the modlists and deseralises them, returning a ModList
		/// </summary>
		/// <param name="reload">Forces reloading ModLists.</param>
		/// <param name="jsonfiles">Specify the json file(s) you want to use</param>
		/// <returns>ModList</returns>
		public static ModListFormat[] GetModLists(bool reload = false, string[] jsonfiles = null)
		{
			if (ModList == null || reload)
			{
				Console.WriteLine("Modlist null!");
				if (jsonfiles == null)
				{
					Console.WriteLine("jsonfiles null!");
					jsonfiles = Glob.FilesAndDirectories(ModInstallerCommon.Modinstallerdir, "**.json").ToArray();
					ModInstallerCommon.DebugLog("Found " + jsonfiles.Length + " json files to read from!");
				}
				ModList = new ModListFormat[jsonfiles.Length];
				for (int i = 0; i < jsonfiles.Length; i++)
				{
					ModList[i] = DeserializeModListFormat(jsonfiles[i]);
				}
			}
			return ModList;
		}

		/// <summary>
		/// Deserializes JSON file given JSON file name.
		/// </summary>
		/// <param name="jsontoload">Json file to load</param>
		/// <returns>ModList</returns>
		public static ModListFormat DeserializeModListFormat(string jsontoload)
		{
			ModListFormat modList = new ModListFormat();
			ModInstallerCommon.DebugLog("Loading " + jsontoload);
			modList = JsonConvert.DeserializeObject<ModListFormat>(File.ReadAllText(ModInstallerCommon.Modinstallerdir + jsontoload));
			return modList;
		}

		/// <summary>
		/// Returns the modfile of modinstallerinfo.h3vrmi.
		/// </summary>
		public static ModFile GetOnlineModInstallerInfo()
		{
			return JsonConvert.DeserializeObject<ModListFormat>(File.ReadAllText(ModInstallerCommon.Modinstallerdir + "modinstallerinfo.h3vrmi")).Modlist[0];
		}
	}
}