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

    public class ModLists
    {
		private static readonly WebClient client = new WebClient();
		public static string h3vrdir = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
		public static void ModListDownload()
		{
			string locationOfFile = "https://github.com/Frityet/H3VRModInstaller/releases/download/database/";
			string fileToDownload = "ModList.zip";
			Uri fileloc = new Uri(locationOfFile + fileToDownload);
			Console.WriteLine("Downloading Mod Database...");
			client.DownloadFile(fileloc, fileToDownload);
			Console.WriteLine("Successfully Downloaded Mod Database");
			Directory.CreateDirectory(@"/ModInstallerLists/");
			Console.WriteLine("Unzipping " + fileToDownload);
			ZipFile.ExtractToDirectory(fileToDownload, Directory.GetCurrentDirectory() + @"/ModInstallerLists/", true);
			File.Delete(fileToDownload);
		}

        public static ModListFormat[] LoadModLists()
        {
			ModListFormat _ml = new ModListFormat();
			string[] jsonfiles = Glob.FilesAndDirectories(Directory.GetCurrentDirectory() + @"/ModInstallerLists/", "**.json").ToArray();
			Console.WriteLine("Found " + jsonfiles.Length + " json files to read from!");
			ModListFormat[] mods = new ModListFormat[jsonfiles.Length];
			for (int i = 0; i < jsonfiles.Length; i++)
			{
				
				mods[i] = JsonConvert.DeserializeObject<ModListFormat>(File.ReadAllText(Directory.GetCurrentDirectory() + @"/ModInstallerLists/" + jsonfiles[i]));
			}
			return mods;
		}

		public static ModListFormat LoadSpecificJSON(string jsontoload)
		{
			ModListFormat _ml = new ModListFormat();
			Console.WriteLine("Loading " + jsontoload);
			_ml = JsonConvert.DeserializeObject<ModListFormat>(File.ReadAllText(Directory.GetCurrentDirectory() + @"/ModInstallerLists/" + jsontoload));
			return _ml;
		}
	}
}