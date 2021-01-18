using System;
using System.IO;
using System.Linq;
using H3VRModInstaller.Backend.Common;
using Newtonsoft.Json;

namespace H3VRModInstaller.Backend.JSON.Common
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

        /// <summary>
        ///     Function that gets the overrides for debugging
        /// </summary>
        public static void OverrideModInstallerVariables()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "/" + "MICoverride.json")) return;
            Console.WriteLine("MICOverride.json detected!");
            var depinput =
                JsonConvert.DeserializeObject<CommonVariables>(
                    File.ReadAllText(Directory.GetCurrentDirectory() + "/" + "MICoverride.json"));
            if (CommonVariables.Execname != null)
                ModInstallerCommon.Files.execdir =
                    ModInstallerCommon.Files.MainFiledir + "/" + CommonVariables.Execname;
            if (CommonVariables.DatabaseInfo != null) DatabaseInfo = CommonVariables.DatabaseInfo;
        }
    }
}