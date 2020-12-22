using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace H3VRModInstaller.JSON
{
	public class InstalledMods
	{
		public class InstalledModsFormat
		{
			public string[] InstalledMods { get; set; }
		}
	
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
