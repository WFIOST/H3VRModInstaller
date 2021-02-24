using System;
using System.Linq;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller.Filesys
{
    /// <summary>
    ///     Handles getting specific data from modfiles
    /// </summary>
    public class ModParsing
    {
        /// <summary>
        ///     Gets the mod info and dependencies of a deserialized <c>ModFile</c> class
        /// </summary>
        /// <param name="modid">Modid of mod and dependencies you want</param>
        /// <returns></returns>
        public static ModFile[] GetModInfoAndDependencies(string modid)
        {
            var result = new ModFile[1];
            var mf = GetSpecificMod(modid); //get modfile of main mod
            result[result.Length - 1] = mf;
            result = result.Concat(GetDependencies(mf)).ToArray(); //get dependencies and add them to result

            return result;
        }

        /// <summary>
        ///     Gets dependencies given a <c>ModFile</c> class
        /// </summary>
        /// <param name="mod">Modfile of mod you want dependencies of</param>
        /// <returns></returns>
        public static ModFile[] GetDependencies(ModFile mod)
        {
            var result = new ModFile[0];
            for (var i = 0; i < mod.Dependencies.Length; i++) //for every dependency,
            {
                Array.Resize(ref result, result.Length + 1);
                result[result.Length - 1] = GetSpecificMod(mod.Dependencies[i]); //add the modfile to the modfile array
                result = result.Concat(GetDependencies(result[result.Length - 1]))
                    .ToArray(); //then add their dependencies
            }

            return result;
        }

        /// <summary>
        ///     Gets the mod info of a deserialized <c>ModFile</c> class
        /// </summary>
        /// <param name="modid">Modid of mod you want</param>
        /// <returns></returns>
        public static ModFile GetSpecificMod(string modid)
        {
            var ml = JsonModList.GetModLists(); //get all modlists

            for (var i = 0; i < ml.Length; i++) //for each modlist
            {
                for (var x = 0; x < ml[i].Modlist.Length; x++) //for each mod in each modlist
                {
                    if (ml[i].Modlist[x].ModId == modid) //if the mod matches modid
                    {
                        return ml[i].Modlist[x];
                        //sift through every goddamn modfile and find the one with the matching modid
                    }
                }
            }

            return null;
        }
        
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
        ///     Given modid, returns all dependents
        /// </summary>
        /// <returns><c>ModFile</c> Array</returns>
        public static ModFile[] GetDependants(ModFile mf, bool GetNonInstalledToo = false)
        {
            ModFile[] mods = null;
            if (!GetNonInstalledToo) { mods = GetAllMods(); } //if get dependants of non-installed too
            else { mods = InstalledMods.GetInstalledMods();} //otherwise, by default, get all installed mods to compare to
            ModFile[] dependents = new ModFile[0]; //list of dependants
            for(int i = 0; i < mods.Length; i++) //for every mod
            {
                for (int x = 0; x < mods[i].Dependencies.Length; x++) //for every mod's dependencies
                {
                    if (mods[i].Dependencies[x] == mf.ModId) //if the dependencies include the modid of the mf
                    {
                        Array.Resize<ModFile>(ref dependents, dependents.Length + 1); 
                        dependents[dependents.Length - 1] = mods[i]; //add to list of dependents (apparently ^1 is the same as length - 1. huh.)
                    }
                }
            }
            return dependents;
        }
    }
}