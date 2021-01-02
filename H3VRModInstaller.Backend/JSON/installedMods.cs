using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using GlobExpressions;
using System.Net;
using System.IO.Compression;
using H3VRModInstaller;

namespace H3VRModInstaller.JSON
{
	/// <summary>
	/// Another layer for multiple mods in one file
	/// </summary>
	public class InstalledModsFormat
	{
		public ModFile[] InstalledMods { get; set; }
	}

	public class DeprecatedInstalledModsFormat
	{
		public string[] InstalledMods { get; set; }
	}

	/// <summary>
	/// Actions for the installed mods. Serialised
	/// </summary>
	public class InstalledMods
	{
		/// <summary>
		/// Gets the currently installed mods from the JSON files
		/// </summary>
		/// <returns>String array with the installed mods</returns>
		public static string[] GetInstalledMods()
		{
			if (!File.Exists(Directory.GetCurrentDirectory() + @"\installedmods.json")) return new ModFile[0];
			InstalledModsFormat input = null;
			DeprecatedInstalledModsFormat depinput = null;
			try { input = JsonConvert.DeserializeObject<InstalledModsFormat>(File.ReadAllText(Directory.GetCurrentDirectory() + "/installedmods.json")); }
			catch { //this here tries to convert the json file into a new file. If it doesn't work, it just deletes and starts over.
				try {
					depinput = JsonConvert.DeserializeObject<DeprecatedInstalledModsFormat>(File.ReadAllText(Directory.GetCurrentDirectory() + "/installedmods.json"));
					File.Delete(Directory.GetCurrentDirectory() + @"\installedmods.json");
					Console.WriteLine("installedmods.json is in a deprecated format, converting!");
					for (int i = 0; i < depinput.InstalledMods.Length; i++) { AddInstalledMods(depinput.InstalledMods[i]); }
				}
				catch {
					Console.WriteLine("installedmods.json isn't formatted correctly, deleting!");
					File.Delete(Directory.GetCurrentDirectory() + @"\installedmods.json");
				}
			}
			if (input == null) return new ModFile[0];
			return input.InstalledMods;
		}
		
		/// <summary>
		/// Adds a <c>ModID</c> to the JSON file
		/// </summary>
		/// <param name="addmod">Mod to add</param>
		public static void AddInstalledMods(string addmod)
		{
			ModFile[] file = GetInstalledMods(); //gets the installed mods file
			Array.Resize<ModFile>(ref file, file.Length + 1); //adds new room for new mod
			file[file.Length - 1] = ModParsing.getModInfo(addmod, null, false)[0]; //sets new room in array to modinfo of addmod
			InstalledModsFormat modexport = new InstalledModsFormat();
			modexport.InstalledMods = file; //drops file into installedmodsformat
			File.WriteAllText(Directory.GetCurrentDirectory() + @"\installedmods.json", JsonConvert.SerializeObject(modexport)); //serialize and write to file
		}
	}
}
