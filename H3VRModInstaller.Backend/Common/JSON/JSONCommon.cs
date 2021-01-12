using System;
using System.IO;
using System.Linq;
using GlobExpressions;
using H3VRModInstaller.Common;
using Newtonsoft.Json;

namespace H3VRModInstaller.JSON.Common
{
    /// <summary>
    ///     Common fields and functions for JSON!
    /// </summary>
    public static class JsonCommon
    {
        /// <summary>
        ///     All JSON files in the database!
        /// </summary>
        public static string[] JsonFiles =
            Glob.FilesAndDirectories(ModInstallerCommon.Files.Modinstallerdir, "**.json").ToArray();

        //public static ModListFormat[] Jsonfiles = JsonModList.GetModLists();

        /// <summary>
        ///     Stores where the JSON files are in the Github repo
        /// </summary>
        /*
        public static readonly Dictionary<string, Uri> OnlineDatabase = new()
        {
            {"CharacterMods", new Uri("https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/H3VRModInstaller.Backend/JSON/Database/charactermods.json")},
            {"CodeMods", new Uri("https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/H3VRModInstaller.Backend/JSON/Database/codemods.json")},
            {"CustomItems", new Uri("https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/H3VRModInstaller.Backend/JSON/Database/customitems.json")},
            {"Dependencies", new Uri("https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/H3VRModInstaller.Backend/JSON/Database/dependencies.json")},
            {"MapMods", new Uri("https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/H3VRModInstaller.Backend/JSON/Database/mapmods.json")}
        };
        */
        public static Uri[] OnlineDatabaseTEST =
        {
            new(
                "https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/H3VRModInstaller.Backend/JSON/Database/charactermods.json"),
            new(
                "https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/H3VRModInstaller.Backend/JSON/Database/codemods.json"),
            new(
                "https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/H3VRModInstaller.Backend/JSON/Database/dependencies.json"),
            new(
                "https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/H3VRModInstaller.Backend/JSON/Database/customitems.json"),
            new(
                "https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/H3VRModInstaller.Backend/JSON/Database/mapmods.json")
        };

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

        public static void OverrideModInstallerVariables()
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\" + "MICoverride.json")) return;
            Console.WriteLine("MICOverride.json detected!");
            var depinput =
                JsonConvert.DeserializeObject<CommonVariables>(
                    File.ReadAllText(Directory.GetCurrentDirectory() + @"\" + "MICoverride.json"));
            if (CommonVariables.EnableDebugging != null)
                CommonVariables.EnableDebugging = CommonVariables.EnableDebugging;
            if (CommonVariables.BypassExec != null) CommonVariables.BypassExec = CommonVariables.BypassExec;
            if (CommonVariables.Execname != null)
                ModInstallerCommon.Files.execdir = ModInstallerCommon.Files.MainFiledir + CommonVariables.Execname;
            if (CommonVariables.Pingsite != null) CommonVariables.Pingsite = CommonVariables.Pingsite;
            if (CommonVariables.Modlistloc != null) ModInstallerCommon.Files.Modlistloc = CommonVariables.Modlistloc;
        }
    }
}