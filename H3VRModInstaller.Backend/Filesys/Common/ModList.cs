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
			string[,] installargs = new string[Enum.GetNames(typeof(MainClass.ListMods)).Length + 2, 11];
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
					installargs[(int)mod, 2] = "download.zip"; //file to move
					installargs[(int)mod, 3] = "Mods/"; //dir to move to
					installargs[(int)mod, 4] = "WurstMod.deli"; //name it as
					break;
                case MainClass.ListMods.TnHTweaker:
					info = TnHTweaker;
					installargs[(int)mod, 0] = "moveToFolder"; //argument
					installargs[(int)mod, 2] = "download.zip"; //file to move
					installargs[(int)mod, 3] = "BepInEx/plugins/"; //dir to move to
					installargs[(int)mod, 4] = "TakeAndHoldTweaker.dll"; //name it as
					break;
				case MainClass.ListMods.Sideloader:
					info = SideloaderInfo;
					break;
				case MainClass.ListMods.LSIIC:
					info = LSIICInfo;
					installargs[(int)mod, 0] = "addFolder";
					installargs[(int)mod, 2] = "VirtualObjects/";
					installargs[(int)mod, 10] = "DoNotParse";
					break;
				case MainClass.ListMods.H3VRUtilities:
					info = H3VRUtilsInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "Mods/";
					break;
				case MainClass.ListMods.pccg:
					info = pccgInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "VirtualObjects/";
					break;
				case MainClass.ListMods.meatyceiver:
					info = meatyceiverInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "BepInEx/plugins";
					break;
				case MainClass.ListMods.meatssidecharger:
					info = meatsSideChargerInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "VirtualObjects/";
					break;
				case MainClass.ListMods.meatsrigs:
					info = meatsRigsInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "VirtualObjects/";
					break;
				case MainClass.ListMods.meatsmags:
					info = meatsMagsInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "VirtualObjects/";
					break;
				case MainClass.ListMods.meatsmodulsr:
					info = meatsModulSRInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "VirtualObjects/";
					break;
				case MainClass.ListMods.meatsmodulpp:
					info = meatsModulPPInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "VirtualObjects/";
					break;
				case MainClass.ListMods.meatsmodulak:
					info = meatsModulAKInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "VirtualObjects/";
					break;
				case MainClass.ListMods.modular:
					info = ModulARInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "VirtualObjects/";
					break;
				case MainClass.ListMods.meatsmodularparts:
					info = meatsModulARPartsInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "VirtualObjects/";
					break;
				case MainClass.ListMods.ebr:
					info = ebrInfo;
					installargs[(int)mod, 0] = "unzipToDir";
					installargs[(int)mod, 2] = "VirtualObjects/";
					break;
			}
			installargs[(int)mod, 1] = info[0];
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
		public string[] SideloaderInfo = { "H3VR.Sideloader_v0.3.3.zip", "https://github.com/denikson/H3VR.Sideloader/releases/download/v0.3.3/", "BepInEx", "ResourceRedirector" };
		public string[] LSIICInfo = { "LSIIC-v1.3.zip", "https://github.com/BlockBuilder57/LSIIC/releases/download/v1.3/", "BepInEx", "Sideloader" };

		public string[] CursedDllsInfo = { "CursedDlls.BepInEx_v1.3.zip", "https://github.com/drummerdude2003/CursedDlls.BepinEx/releases/download/v1.3/", "BepInEx", "Monomod" };
		public string[] WurstModInfo = { "WurstMod.deli", "https://github.com/Nolenz/WurstMod/releases/download/v2.0.2.0/", "BepInEx", "Deli"};
		public string[] TnHTweaker = { "TakeAndHoldTweaker.dll", "https://github.com/devyndamonster/TakeAndHoldTweaker/releases/download/v1.3.0/", "BepInEx" };
		public string[] H3VRUtilsInfo = { "H3VRUtilities.zip", "https://bonetome.com/download.php?file=MTRmZjdkYWM4M2YzNDdmNCszNjUrODUx", "BepInEx", "Sideloader" };
		public string[] pccgInfo = { "PotatoesCustomGuns.zip", "https://bonetome.com/download.php?file=NGFmYTMxOWRjNmEwMTdhMSszNjUrNzUw", "LSIIC" };
		public string[] meatyceiverInfo = { "Meatyceiver032.zip", "https://bonetome.com/download.php?file=ZDMxZjYzMTgxYTg5OTdlYiszNjUrODk0", "BepInEx" };
		public string[] meatsSideChargerInfo = { "TurtsSidechARger.zip", "https://bonetome.com/download.php?file=OTI3NTY5Y2ZlYThiMzZkNCszNjUrOTQ2", "LSIIC" };
		public string[] meatsRigsInfo = { "MeatsRigs.zip", "https://bonetome.com/download.php?file=OGViNjM0MGVlOTUwMGYzNyszNjUrOTMw", "LSIIC" };
		public string[] meatsMagsInfo = { "MeatsMagazines.zip", "https://bonetome.com/download.php?file=MzZmNmEzNDZmNzJhNDdiMiszNjUrODkw", "LSIIC" };
		public string[] meatsModulSRInfo = { "MeatsModulSR1.1.zip", "https://bonetome.com/download.php?file=YjQzZTQ1MTM2MDQ0ODg3MSszNjUrODgz", "LSIIC" };
		public string[] meatsModulPPInfo = { "MeatsModulPP.zip", "https://bonetome.com/download.php?file=ODQ4YThkNDZjMGZhYzNmYSszNjUrODc3", "LSIIC" };
		public string[] ModulARInfo = { "modular.zip", "https://bonetome.com/download.php?file=MjgxMDkxOThkYTE0Mjg4MCszNjUrODUw", "LSIIC" };
		public string[] meatsModulAKInfo = { "MeatsModulAK1.1.zip", "https://bonetome.com/download.php?file=NzFhNzc3MWJiZjQ2OWJhOCszNjUrODYx", "LSIIC" };
		public string[] meatsModulARPartsInfo = { "MeatsARParts.zip", "https://bonetome.com/download.php?file=NDU1MzQwZmVkOTA4YmYzYyszNjUrODQ3", "LSIIC" };
		public string[] ebrInfo = { "mk14+dcsb.zip", "https://bonetome.com/download.php?file=YzM2MTcyN2ZlYTRjNWRhNiszNjUrODg4", "LSIIC"};

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
