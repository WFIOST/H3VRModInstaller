using System;
using System.IO;
using H3VRModInstaller.Common;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller.Filesys
{
	/// <summary>
	///     Uninstaller for mods
	/// </summary>
	public static class Uninstaller
    {
	    /// <summary>
	    ///     Function for deleting mods
	    /// </summary>
	    /// <param name="modid">ModID to delte</param>
	    public static void DeleteMod(string modid)
        {
            var instmods = InstalledMods.GetInstalledMods();
            for (var i = 0; i < instmods.Length; i++)
            {
                if (instmods[i].ModId == modid)
                {
                    parseDelArgs(instmods[i]);
                    break;
                }
            }

            InstalledMods.RemoveInstalledMod(modid);
        }

        private static void parseDelArgs(ModFile mf)
        {
            if (mf.DelInfo == null)
            {
                mf = ModParsing.GetSpecificMod(mf.ModId);
                if (string.IsNullOrEmpty(mf.DelInfo))
                {
                    Console.WriteLine(
                        "There's no info on how to delete this mod! Please ask the creators to add that in!");
                    return;
                }
            }

            var args = mf.DelInfo.Split('?');

            foreach (var target in args)
            {
                // If something is broken, skip this target since continuing would delete the h3 directory.
                if (string.IsNullOrEmpty(target)){ continue;}

                var path = Path.Combine(ModInstallerConfig.GetConfig().GameDirectory, target);
                if (File.Exists(path)) { File.Delete(path); }
                else if (Directory.Exists(path)) {Directory.Delete(path, true);}
            }
        }
    }
}