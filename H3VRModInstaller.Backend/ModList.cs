using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.NetworkInformation;

namespace H3VRModInstaller.Backend
{
	internal class ModList
	{
		public Tuple<string[], string[]> getModFile(MainClass.ListMods mod)
		{
			string[] resultFile = new string[5];
			string[] resultPath = new string[5];
			switch (mod)
			{
				case MainClass.ListMods.CursedDLLs:
					resultFile = cursedDllsFiles;
					resultPath = cursedDllsPaths;
					break;
				case MainClass.ListMods.WurstMod:
					resultFile = wurstModFiles;
					resultPath = wurstModPaths;
					break;
				case MainClass.ListMods.TnHTweaker:
					resultFile = TNHTweakerFiles;
					resultPath = TNHTweakerPaths;
					break;
			}
			return Tuple.Create<string[], string[]>(resultFile, resultPath);
		}

		public string[] cursedDllsFiles =
			{"BepInEx_x64_5.4.4.0.zip", "BepInEx.MonoMod.Loader_1.0.0.0.zip", "CursedDlls.BepInEx_v1.3.zip"};

		public string[] cursedDllsPaths =
		{
			"https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
			"https://github.com/BepInEx/BepInEx.MonoMod.Loader/releases/download/v1.0.0.0/",
			"https://github.com/drummerdude2003/CursedDlls.BepinEx/releases/download/v1.3/"
		};

		public string[] TNHTweakerFiles = { "BepInEx_x64_5.4.4.0.zip", "TakeAndHoldTweaker.dll" };

		public string[] TNHTweakerPaths =
		{
			"https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
			"https://github.com/devyndamonster/TakeAndHoldTweaker/releases/download/v1.3.0/"
		};

		public string[] wurstModFiles = { "BepInEx_x64_5.4.4.0.zip", "Deli-v0.2.5.zip", "WurstMod.deli" };

		public string[] wurstModPaths =
		{
			"https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
			"https://github.com/Deli-Counter/Deli/releases/download/v0.2.5/",
			"https://github.com/Nolenz/WurstMod/releases/download/v2.0.2.0/"
		};

		public bool onlineCheck()
		{
			if (func.isOnline("www.github.com"))
			{
				Console.WriteLine("GitHub is Online!");
				return true;
			}

			Console.WriteLine("Github is either down, or no internet is detected!");
			return false;
		}
	}
}
