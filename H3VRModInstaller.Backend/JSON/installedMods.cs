﻿using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using GlobExpressions;
using System.Net;
using System.IO.Compression;
using H3VRModInstaller.Filesys;

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
		public static ModFile[] GetInstalledMods()
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
					for (int i = 0; i < depinput.InstalledMods.Length; i++) { AddInstalledMod(depinput.InstalledMods[i]); }
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
		/// Adds a <c>ModFile</c> to the InstalledMods JSON file
		/// </summary>
		/// <param name="addmod">Mod to add</param>
		public static void AddInstalledMod(string addmod)
		{
			ModFile[] file = GetInstalledMods(); //gets the installed mods file
			Array.Resize<ModFile>(ref file, file.Length + 1); //adds new room for new mod
			file[file.Length - 1] = ModParsing.GetModInfo(addmod, null, false)[0]; //sets new room in array to modinfo of addmod
			writeInstalledModToJson(file);
		}

		/// <summary>
		/// Removes a <c>ModFile</c> to the InstalledMods JSON file
		/// </summary>
		/// <param name="removemod">Mod to remove</param>
		public static void RemoveInstalledMod(string removemod)
		{
			ModFile[] file = GetInstalledMods(); //gets the installed mods file
			int loc = -1;
			for(int i = 0; i < file.Length; i++) //finds modfile of mod given modid
			{
				if (file[i].ModId == removemod)
				{
					loc = i;
					break;
				}
			}
			if (loc == -1) { Console.WriteLine("Cannot find mod to remove!"); return; }
			file = file.Where(val => val != file[loc]).ToArray(); //removes instance of modfiles exact to file[loc] and shifts it all over so there's no gap in the array
			writeInstalledModToJson(file);
		}

		private static void writeInstalledModToJson(ModFile[] files)
		{
			InstalledModsFormat modexport = new InstalledModsFormat();
			modexport.InstalledMods = files; //drops file into installedmodsformat
			File.WriteAllText(Directory.GetCurrentDirectory() + @"\installedmods.json", JsonConvert.SerializeObject(modexport)); //serialize and write to file
		}
	}
}