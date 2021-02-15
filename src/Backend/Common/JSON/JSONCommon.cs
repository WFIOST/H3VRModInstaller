using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace H3VRModInstaller.JSON.Common
{
	/// <summary>
	///     Common fields and functions for JSON!
	/// </summary>
	public static class JsonCommon
    {
	    /// <summary>
	    ///     Where the database for modinstaller is kept
	    /// </summary>
	    public static string DatabaseInfo =
            "https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/src/Backend/JSON/Database/modinstallerinfo.h3vrmi";

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

		public static ModFile[] GetDependants(ModFile mod, bool GetNonInstalledToo = false) { return GetDependants(mod.ModId, GetNonInstalledToo); }

		public static ModFile[] GetDependants(string modid, bool GetNonInstalledToo = false)
		{
			ModFile[] mods = null;
			if (!GetNonInstalledToo) mods = GetAllMods();
			else mods = InstalledMods.GetInstalledMods();
			ModFile[] dependants = new ModFile[0];
			for(int i = 0; i < mods.Length; i++)
			{
				for (int x = 0; x < mods[i].Dependencies.Length; x++)
				{
					if (mods[i].Dependencies[x] == modid)
					{
						Array.Resize<ModFile>(ref dependants, dependants.Length + 1);
						dependants[dependants.Length - 1] = mods[i];
					}
				}
			}
			return dependants;
		}

	    /// <summary>
	    ///     Function that gets the overrides for debugging
	    /// </summary>
	    public static void OverrideModInstallerVariables()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + "MICoverride.json")) return;
            Console.WriteLine("MICOverride.json detected!");
            var depinput =
                JsonConvert.DeserializeObject<MICoverrideVars>(
                    File.ReadAllText(Directory.GetCurrentDirectory() + "/" + "MICoverride.json"));
            if (depinput.DatabaseInfo != null)
            {
                Console.WriteLine("Overriding DatabaseInfo with " + depinput.DatabaseInfo);
                DatabaseInfo = depinput.DatabaseInfo;
            }
        }

        public class MICoverrideVars
        {
            public string Execname { get; set; }
            public string DatabaseInfo { get; set; }
        }
    }
}