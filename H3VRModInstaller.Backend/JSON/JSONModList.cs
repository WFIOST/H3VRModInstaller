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
			Uri fileloc = new Uri(ModInstallerCommon.Modlistloc[0] + ModInstallerCommon.Modlistloc[1]);
			Console.WriteLine("Downloading Mod Database...");
			Client.DownloadFile(fileloc, ModInstallerCommon.Modlistloc[1]);
			Console.WriteLine("Successfully Downloaded Mod Database");
			Directory.CreateDirectory(ModInstallerCommon.Modinstallerdir);
			ZipFile.ExtractToDirectory(ModInstallerCommon.Modlistloc[1], ModInstallerCommon.Modinstallerdir, true);
			File.Delete(ModInstallerCommon.Modlistloc[1]);
		}

		public static ModListFormat[] GetmodLists(bool reload = false, string[] jsonfiles = null)
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

		public static ModListFormat DeserializeModListFormat(string jsontoload)
		{
			ModListFormat modList = new ModListFormat();
			ModInstallerCommon.DebugLog("Loading " + jsontoload);
			modList = JsonConvert.DeserializeObject<ModListFormat>(File.ReadAllText(ModInstallerCommon.Modinstallerdir + jsontoload));
			return modList;
		}
	}
}