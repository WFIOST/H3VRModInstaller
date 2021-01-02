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
		public static ModListFormat[] ModList = null;

		public static void dlModList()
		{
			Uri fileloc = new Uri(MICommon.Modlistloc[0] + MICommon.Modlistloc[1]);
			Console.WriteLine("Downloading Mod Database...");
			Client.DownloadFile(fileloc, MICommon.Modlistloc[1]);
			Console.WriteLine("Successfully Downloaded Mod Database");
			Directory.CreateDirectory(MICommon.Modinstallerdir);
			ZipFile.ExtractToDirectory(MICommon.Modlistloc[1], MICommon.Modinstallerdir, true);
			File.Delete(MICommon.Modlistloc[1]);
		}

		public static ModListFormat[] GetmodLists(bool reload = false, string[] jsonfiles = null)
		{
			if (ModList == null || reload)
			{
				if (jsonfiles == null)
				{
					jsonfiles = Glob.FilesAndDirectories(MICommon.Modinstallerdir, "**.json").ToArray();
					MICommon.DebugLog("Found " + jsonfiles.Length + " json files to read from!");
				}
				ModListFormat[] mods = new ModListFormat[jsonfiles.Length];
				for (int i = 0; i < jsonfiles.Length; i++)
				{
					mods[i] = DeserializeModListFormat(jsonfiles[i]);
				}
			}
			return ModList;
		}

		public static ModListFormat DeserializeModListFormat(string jsontoload)
		{
			ModListFormat modList = new ModListFormat();
			MICommon.DebugLog("Loading " + jsontoload);
			modList = JsonConvert.DeserializeObject<ModListFormat>(File.ReadAllText(MICommon.Modinstallerdir + jsontoload));
			return modList;
		}
	}
}