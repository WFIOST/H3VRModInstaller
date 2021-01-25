using System;
using System.IO;
using H3VRModInstaller.Backend.Common;
using H3VRModInstaller.Backend.JSON;

namespace H3VRModInstaller.Backend.Filesys
{
    /// <summary>
    ///     Uninstaller for mods
    /// </summary>
    public class Uninstaller
    {
        /// <summary>
        ///     Function for deleting mods
        /// </summary>
        /// <param name="modid">ModID to delte</param>
        public static void DeleteMod(string modid)
        {
			Console.WriteLine("0");
			var instmods = InstalledMods.GetInstalledMods();
            for (var i = 0; i < instmods.Length; i++)
                if (instmods[i].ModId == modid)
                {
                    parseDelArgs(instmods[i]);
                    break;
                }

            InstalledMods.RemoveInstalledMod(modid);
        }

		private static void parseDelArgs(ModFile mf)
		{
			Console.WriteLine("1");
			if (mf.DelInfo == null)
			{
				mf = ModParsing.GetSpecificMod(mf.ModId);
				if (mf.DelInfo == null || mf.DelInfo == "")
				{
					Console.WriteLine(
						"There's no info on how to delete this mod! Please ask the creators to add that in!");
					return;
				}
			}

			var args = mf.DelInfo.Split('?');

			for (var i = 0; i < args.Length; i++)
			{
				if (args[i] == "")
				{
					continue;
				}
				Console.WriteLine("Finding " + ModInstallerCommon.Files.MainFiledir + @"\" + args[i]);
				if (File.Exists(ModInstallerCommon.Files.MainFiledir + @"\" + args[i]))
				{
					Console.WriteLine("Removing " + ModInstallerCommon.Files.MainFiledir + @"\" + args[i] + " as file");
					File.Delete(ModInstallerCommon.Files.MainFiledir + @"\" + args[i]);
				}
				else if (Directory.Exists(ModInstallerCommon.Files.MainFiledir + @"\" + args[i]))
				{
					Console.WriteLine("Removing " + ModInstallerCommon.Files.MainFiledir + @"\" + args[i] + " as dir");
					Directory.Delete(ModInstallerCommon.Files.MainFiledir + "/" + args[i], true);
				}
			}
		}
    }
}