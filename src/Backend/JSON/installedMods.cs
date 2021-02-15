using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using H3VRModInstaller.Common;
using H3VRModInstaller.Filesys;
using Newtonsoft.Json;

namespace H3VRModInstaller.JSON
{
    /// <summary>
    ///     Another layer for multiple mods in one file
    /// </summary>
    public class InstalledModsFormat
    {
        /// <summary>
        ///     <c>ModFile</c> iarray of installed mods
        /// </summary>
        public ModFile[] InstalledMods { get; set; }
    }

    /// <summary>
    ///     Old installed mods format, dont use this
    /// </summary>
    public class DeprecatedInstalledModsFormat
    {
        /// <summary>
        ///     String array of installed mods (DEPRECIATED)
        /// </summary>
        public string[] InstalledMods { get; set; }
    }

    /// <summary>
    ///     Actions for the installed mods. Serialised
    /// </summary>
    public class InstalledMods
    {
        /// <summary>
        ///     Gets the currently installed mods from the JSON files
        /// </summary>
        /// <returns>String array with the installed mods</returns>
        public static ModFile[] GetInstalledMods()
        {
            if (!File.Exists(Utilities.ModCache)) return Array.Empty<ModFile>();
            Console.WriteLine("Reading from " + Utilities.ModCache);
            InstalledModsFormat input = null;
            try
            {
                input = JsonConvert.DeserializeObject<InstalledModsFormat>(File.ReadAllText(Utilities.ModCache));
            }
            catch
            {
                //this here tries to convert the json file into a new file. If it doesn't work, it just deletes and starts over.
                try
                {
                    var depInput =
                        JsonConvert.DeserializeObject<DeprecatedInstalledModsFormat>(
                            File.ReadAllText(Directory.GetCurrentDirectory() + "/installedmods.json"));
                    File.Delete(Utilities.ModCache);
                    Console.WriteLine("Mods cache is in a deprecated format, converting!");
                    foreach (var t in depInput.InstalledMods)
                        AddInstalledMod(t);
                }
                catch
                {
                    var err = MessageBox.Show("Mod cache (installed_mods.json) IS INVALID!\nThis is most likely because Deli Counter was used for installing mods, before Mod Installer!\n(if you had any installed mods with Deli Counter from before, it could cause serious issues!)\n\nThese programs are not compatible, delete?", "Mod Cache INVALID!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (err == DialogResult.Yes)
                    {
                        File.Delete(Utilities.ModCache);
                    }
                }
            }

            return input == null ? Array.Empty<ModFile>() : input.InstalledMods;
        }

        /// <summary>
        ///     Adds a <c>ModFile</c> to the InstalledMods JSON file
        /// </summary>
        /// <param name="addmod">Mod to add</param>
        public static void AddInstalledMod(string addmod)
        {
            var file = GetInstalledMods(); //gets the installed mods file
            Array.Resize(ref file, file.Length + 1); //adds new room for new mod
            file[file.Length - 1] = ModParsing.GetSpecificMod(addmod); //sets new room in array to modinfo of addmod
            writeInstalledModToJson(file);
        }

        /// <summary>
        ///     Removes a <c>ModFile</c> to the InstalledMods JSON file
        /// </summary>
        /// <param name="removemod">Mod to remove</param>
        public static void RemoveInstalledMod(string removemod)
        {
            var file = GetInstalledMods(); //gets the installed mods file
            var loc = -1;
            for (var i = 0; i < file.Length; i++) //finds modfile of mod given modid
                if (file[i].ModId == removemod)
                {
                    loc = i;
                    break;
                }

            if (loc == -1)
            {
                Console.WriteLine("Cannot find mod to remove!");
                return;
            }

            file = file.Where(val => val != file[loc])
                .ToArray(); //removes instance of modfiles exact to file[loc] and shifts it all over so there's no gap in the array
            writeInstalledModToJson(file);
        }

        private static void writeInstalledModToJson(ModFile[] files)
        {
            var modexport = new InstalledModsFormat();
            modexport.InstalledMods = files; //drops file into installedmodsformat
            File.WriteAllText(Utilities.ModCache,
                JsonConvert.SerializeObject(modexport, Formatting.Indented)); //serialize and write to file
        }
    }
}