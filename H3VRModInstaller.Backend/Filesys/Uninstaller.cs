using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H3VRModInstaller.JSON;
using System.IO;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.Filesys
{
	public class Uninstaller
	{

		public static void DeleteMod(string modid)
		{
			ModFile[] instmods = InstalledMods.GetInstalledMods();
			for (int i = 0; i < instmods.Length; i++)
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
				if (mf.DelInfo == null)
				{
					Console.WriteLine("There's no info on how to delete this mod! Please ask the creators to add that in!");
					return;
				}
			}
			string[] args = mf.DelInfo.Split('?');

			for (int i = 0; i < args.Length; i++)
			{
				if (File.Exists(ModInstallerCommon.Files.MainFiledir + @"\" + args[i])) File.Delete(ModInstallerCommon.Files.MainFiledir + @"\" + args[i]);
				else if (Directory.Exists(ModInstallerCommon.Files.MainFiledir + @"\" + args[i])) Directory.Delete(ModInstallerCommon.Files.MainFiledir + @"\" + args[i]);
			}
		}
	}
}
