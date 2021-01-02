using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using GlobExpressions;
using System.Net;
using System.IO.Compression;

namespace H3VRModInstaller.JSON
{
	public class ModFile
    {
		public string ModId { get; set; }
		public string Name { get; set; }
		public string RawName { get; set; }
		public string[] Author { get; set; }
		public string Version { get; set; }
		public string Description { get; set; }
		public string Path { get; set; }
		public string Website { get; set; }
		public string Arguments { get; set; }
        public string[] Dependencies { get; set; }
    }

	/// <summary>
	/// Another level to the JSON I guess?
	/// </summary>
	public class ModListFormat
	{
		public ModFile[] Modlist { get; set; }
	}
	
    public class JsonModList
    {
		private static readonly WebClient Client = new WebClient();
		public static string H3Vrdir = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
		public static string Modinstallerdir = Directory.GetCurrentDirectory() + @"/ModInstallerLists/";
		public static string[] Modlistloc = { "https://github.com/Frityet/H3VRModInstaller/releases/download/database/", "ModList.zip" };
		public static ModListFormat[] Ml = null;

		public static void DlModList()
		{
			Uri fileloc = new Uri(Modlistloc[0] + Modlistloc[1]);
			Console.WriteLine("Downloading Mod Database...");
			Client.DownloadFile(fileloc, Modlistloc[1]);
			Console.WriteLine("Successfully Downloaded Mod Database");
			Directory.CreateDirectory(Modinstallerdir);
			ZipFile.ExtractToDirectory(Modlistloc[1], Modinstallerdir, true);
			File.Delete(Modlistloc[1]);
		}

		public static ModListFormat[] GetmodLists(bool enabledebugging, bool reload = false)
		{
			if (Ml == null || reload) { Ml = LoadModLists(enabledebugging); }
			return Ml;
		}

        public static ModListFormat[] LoadModLists(bool enabledebugging, string[] jsonfiles = null)
        {
			if (jsonfiles == null)
			{
				jsonfiles = Glob.FilesAndDirectories(Modinstallerdir, "**.json").ToArray();
				if(enabledebugging) Console.WriteLine("Found " + jsonfiles.Length + " json files to read from!");
			}
			ModListFormat[] mods = new ModListFormat[jsonfiles.Length];
			for (int i = 0; i < jsonfiles.Length; i++)
			{
				mods[i] = DeserializeModListFormat(jsonfiles[i], enabledebugging);
			}
			return mods;
		}

		public static ModListFormat DeserializeModListFormat(string jsontoload, bool enabledebugging)
		{
			ModListFormat modList = new ModListFormat();
			if (enabledebugging) Console.WriteLine("Loading " + jsontoload);
			modList = JsonConvert.DeserializeObject<ModListFormat>(File.ReadAllText(Modinstallerdir + jsontoload));
			return modList;
		}
	}

	public class InstalledModsFormat
	{
		public string[] InstalledMods { get; set; }
	}

	public class InstalledMods
	{

		public static string[] GetInstalledMods()
		{
			if (!File.Exists(Directory.GetCurrentDirectory() + @"\installedmods.json")) return new string[0];
			InstalledModsFormat input = JsonConvert.DeserializeObject<InstalledModsFormat>(File.ReadAllText(Directory.GetCurrentDirectory() + "/installedmods.json"));
			if (input == null) return new string[0];
			return input.InstalledMods;
		}

		public static void AddInstalledMods(string addmod)
		{
			string[] file = new string[0];
			file = GetInstalledMods();
			Array.Resize<string>(ref file, file.Length + 1);
			InstalledModsFormat modexport = new InstalledModsFormat();
			file[file.Length - 1] = addmod;
			modexport.InstalledMods = file;
			string output = JsonConvert.SerializeObject(modexport);
			File.WriteAllText(Directory.GetCurrentDirectory() + @"\installedmods.json", output);
		}
	}
}