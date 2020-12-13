using System;
using H3VRModInstaller.Net;

namespace H3VRModInstaller.Filesys.Common
{
    class ModList
    {
		public Tuple<string[], string[]> parseInfo(string[] infopath, string[] resultFile, string[] resultPath)
		{
			Console.WriteLine("Parsing " + infopath[0]);
			for (int i = 0; i < resultFile.Length; i++)
			{
				if (resultFile[i] == null || resultFile[i] == "")
				{
					resultFile[i] = infopath[0];
					resultPath[i] = infopath[1];
					break;
				}
			}

			for (int i = 2; i < infopath.Length; i++)
			{
				if (infopath[i] == "") { Console.WriteLine("End of dependencies!"); break; }
				int num = i - 1;
				int numofdep = infopath.Length - 2;
				Console.WriteLine(infopath[0] + " is getting dependency " + infopath[i] + ", dependency " + num + " of " + numofdep);
				Enum.TryParse(infopath[i], out MainClass.ListMods dependency);
				getModInfo(dependency, resultFile, resultPath);
			}
			if (infopath.Length < 2) { Console.WriteLine("No dependencies, skipping!"); }
			return Tuple.Create<string[], string[]>(resultFile, resultPath);
		}


        public Tuple<string[], string[], string[], string[,]> getModInfo(MainClass.ListMods mod, string[] resultFile = null, string[] resultPath = null)
        {
			if (resultFile == null)
			{
				resultFile = new string[50];
			}
			if (resultPath == null)
			{
				resultPath = new string[50];
			}
			Tuple<string[], string[]> result;
			result = Tuple.Create<string[], string[]>(BepInExInfo, ResourceRedirectorInfo);
			Console.WriteLine("Getting mod info for " + mod);
			string[,] installargs = new string[Enum.GetNames(typeof(MainClass.ListMods)).Length + 2, 10];
			string[] info = new string[1];
			switch (mod)
            {
				case MainClass.ListMods.BepInEx:
					info = BepInExInfo;
					break;
				case MainClass.ListMods.ResourceRedirector:
					info = ResourceRedirectorInfo;
					break;
				case MainClass.ListMods.Deli:
					info = DeliInfo;
					break;
				case MainClass.ListMods.Monomod:
					info = MonomodInfo;
					break;

				case MainClass.ListMods.CursedDLLs:
					info = CursedDllsInfo;
					break;
				case MainClass.ListMods.WurstMod:
					info = WurstModInfo;
					installargs[(int)mod, 0] = "moveToFolder"; //argument
					installargs[(int)mod, 1] = "WurstMod.deli"; //mod to move
					installargs[(int)mod, 2] = "download.zip"; //file to move
					installargs[(int)mod, 3] = "Mods/"; //dir to move to
					installargs[(int)mod, 4] = "WurstMod.deli"; //name it as
					break;
                case MainClass.ListMods.TnHTweaker:
					info = TnHTweaker;
					break;
				case MainClass.ListMods.Sideloader:
					info = SideLoaderInfo;
					break;
				case MainClass.ListMods.LSIIC:
					info = LSIICInfo;
					break;
			}
			result = parseInfo(info, resultFile, resultPath);
			resultFile = result.Item1;
			resultPath = result.Item2;
			installargs[Enum.GetNames(typeof(MainClass.ListMods)).Length + 1, 0] = "break";

			Console.WriteLine(resultFile[0] + ", " + resultFile[1] + ", " + resultFile[2] + ", " + resultFile[3] + ", " + resultFile[4] + ", " + resultFile[5]);

			return Tuple.Create<string[], string[], string[], string[,]>(resultFile, resultPath, info, installargs);
        }

		public string[] BepInExInfo = { "BepInEx_x64_5.4.4.0.zip", "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/" };
		public string[] ResourceRedirectorInfo = { "XUnity.ResourceRedirector-BepIn-5x-1.1.3.zip", "https://github.com/bbepis/XUnity.AutoTranslator/releases/download/v4.13.0/"};
		public string[] DeliInfo = { "Deli-v0.2.5.zip", "https://github.com/Deli-Counter/Deli/releases/download/v0.2.5/"};
		public string[] MonomodInfo = { "BepInEx.MonoMod.Loader_1.0.0.0.zip", "https://github.com/BepInEx/BepInEx.MonoMod.Loader/releases/download/v1.0.0.0/" };

		public string[] CursedDllsInfo = { "CursedDlls.BepInEx_v1.3.zip", "https://github.com/drummerdude2003/CursedDlls.BepinEx/releases/download/v1.3/", "BepInEx", "Monomod" };
		public string[] WurstModInfo = { "WurstMod.deli", "https://github.com/Nolenz/WurstMod/releases/download/v2.0.2.0/", "BepInEx", "Deli"};
		public string[] TnHTweaker = { "TakeAndHoldTweaker.dll", "https://github.com/devyndamonster/TakeAndHoldTweaker/releases/download/v1.3.0/", "BepInEx" };
		public string[] SideLoaderInfo = { "H3VR.Sideloader_v0.3.3.zip", "https://github.com/denikson/H3VR.Sideloader/releases/tag/v0.3.3", "BepInEx", "ResourceRedirector" };
		public string[] LSIICInfo = { };


		/*       public string[] cursedDllsFiles =
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

			   public string[] SideloaderFiles = { "BepInEx_x64_5.4.4.0.zip", "XUnity.ResourceRedirector-BepIn-5x-1.1.3.zip", "H3VR.Sideloader_v0.3.3.zip" };

			   public string[] SideloaderPaths =
			   {
				   "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/",
				   "https://github.com/bbepis/XUnity.AutoTranslator/releases/download/v4.13.0/",
				   "https://github.com/denikson/H3VR.Sideloader/releases/tag/v0.3.3"
			   };*/

		public bool onlineCheck()
        {
            if (NetCheck.isOnline("www.github.com"))
            {
                Console.WriteLine("GitHub is Online!");
                return true;
            }

            Console.WriteLine("Github is either down, or no internet is detected!");
            return false;
        }
    }
}
