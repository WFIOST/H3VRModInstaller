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
		public string modID { get; set; }
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

	public class ModListFormat
	{
		public ModFile[] modlist { get; set; }
	}

    public class JSONModList
    {
		private static readonly WebClient client = new WebClient();
		public static string h3vrdir = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
		public static string modinstallerdir = Directory.GetCurrentDirectory() + @"/ModInstallerLists/";
		public static string[] modlistloc = { "https://github.com/Frityet/H3VRModInstaller/releases/download/database/", "ModList.zip" };
		public static ModListFormat[] ml = null;

		public static void dlModList()
		{
			Uri fileloc = new Uri(modlistloc[0] + modlistloc[1]);
			Console.WriteLine("Downloading Mod Database...");
			client.DownloadFile(fileloc, modlistloc[1]);
			Console.WriteLine("Successfully Downloaded Mod Database");
			Directory.CreateDirectory(modinstallerdir);
			ZipFile.ExtractToDirectory(modlistloc[1], modinstallerdir, true);
			File.Delete(modlistloc[1]);
		}

		public static ModListFormat[] getmodLists(bool enabledebugging, bool reload = false)
		{
			if (ml == null || reload) { ml = loadModLists(enabledebugging); }
			return ml;
		}

        public static ModListFormat[] loadModLists(bool enabledebugging, string[] jsonfiles = null)
        {
			if (jsonfiles == null)
			{
				jsonfiles = Glob.FilesAndDirectories(modinstallerdir, "**.json").ToArray();
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
			ModListFormat _ml = new ModListFormat();
			if (enabledebugging) Console.WriteLine("Loading " + jsontoload);
			_ml = JsonConvert.DeserializeObject<ModListFormat>(File.ReadAllText(modinstallerdir + jsontoload));
			return _ml;
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