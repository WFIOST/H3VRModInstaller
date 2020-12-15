using System;
using H3VRModInstaller.Net;

namespace H3VRModInstaller.Filesys.Common
{
    class ModList
    {
		public Tuple<string[,]> parseInfo(string[] infopath, string[,] modlist)
		{
			Console.WriteLine("Parsing " + infopath[0]);
			Console.WriteLine("modlist is " + modlist.GetLength(0) + " by " + modlist.GetLength(1));
			for (int i = 0; i < modlist.GetLength(0); i++)
			{
				bool _brk = false;
				if (modlist[i, 0] == "" || modlist[i, 0] == null)
				{
					modlist[i, 0] = infopath[0];
					modlist[i, 1] = infopath[1];
					modlist[i, 2] = infopath[2];
					_brk = true;
				}
				else Console.WriteLine("Line is " + modlist[i, 0] + " , not empty!");
				if (_brk) break;
			}

			for (int i = 3; i < infopath.Length; i++)
			{
				if (infopath[i] == "") { Console.WriteLine("End of dependencies!"); break; }
				int num = i - 2;
				int numofdep = infopath.Length - 3;
				Console.WriteLine(infopath[0] + " is getting dependency " + infopath[i] + ", dependency " + num + " of " + numofdep);
//				Enum.TryParse(infopath[i], out MainClass.ListMods dependency);
				getModInfo(infopath[i], modlist);
			}
			if (infopath.Length < 2) { Console.WriteLine("No dependencies, skipping!"); }
			return Tuple.Create<string[,]>(modlist);
		}

		private const string VO = "VirtualObjects/";

		public Tuple<string[,]> getModInfo(string mod, string[,] modlist = null)
        {
			if (modlist == null)
			{
				modlist = new string[10,5];
			}

			Tuple<string[,]> result;
			Console.WriteLine("Getting mod info for " + mod);
			string[] info = new string[1];
			switch (mod)
            {
				case "configurationmanager":
					info = ConfigurationManagerInfo;
					break;
				case "bepinex":
					info = BepInExInfo;
					break;
				case "resourceredirector":
					info = ResourceRedirectorInfo;
					break;
				case "deli":
					info = DeliInfo;
					break;
				case "monomod":
					info = MonomodInfo;
					break;
				case "curseddlls":
					info = CursedDllsInfo;
					break;
				case "wurstmod":
					info = WurstModInfo;
					break;
                case "tnhtweaker":
					info = TnHTweaker;
					break;
				case "sideloader":
					info = SideloaderInfo;
					break;
				case "lsiic":
					info = LSIICInfo;
					break;
				case "h3vrutils":
					info = H3VRUtilsInfo;
					break;
				case "pccg":
					info = pccgInfo;
					break;
				case "meatyceiver":
					info = meatyceiverInfo;
					break;
				case "meatssidecharger":
					info = meatsSideChargerInfo;
					break;
				case "meatsrigs":
					info = meatsRigsInfo;
					break;
				case "meatsmags":
					info = meatsMagsInfo;
					break;
				case "meatsmodulsr":
					info = meatsModulSRInfo;
					break;
				case "meatsmodulpp":
					info = meatsModulPPInfo;
					break;
				case "meatsmodulak":
					info = meatsModulAKInfo;
					break;
				case "modular":
					info = ModulARInfo;
					break;
				case "meatsmodularparts":
					info = meatsModulARPartsInfo;
					break;
				case "meatsmpx":
					info = meatsmpxInfo;
					break;
				case "ebr":
					info = ebrInfo;
					break;
			}
			if(info.Length == 1) { Console.WriteLine("Fail to find mod!"); return null; }
			result = parseInfo(info, modlist);

			for (int i = 0; i < modlist.GetLength(0) - 1; i++) {
				if (modlist[i, 0] == null) break;
				Console.WriteLine("mod info:" + modlist[i, 0] + ", " + modlist[i, 1] + ", " + modlist[i, 2]);
			}
			return Tuple.Create<string[,]>(result.Item1);
        }

		public string[] BepInExInfo = { "BepInEx_x64_5.4.4.0.zip", "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/", "" };
		public string[] ResourceRedirectorInfo = { "XUnity.ResourceRedirector-BepIn-5x-1.1.3.zip", "https://github.com/bbepis/XUnity.AutoTranslator/releases/download/v4.13.0/", "" };
		public string[] DeliInfo = { "Deli-v0.2.5.zip", "https://github.com/Deli-Counter/Deli/releases/download/v0.2.5/", "" };
		public string[] MonomodInfo = { "BepInEx.MonoMod.Loader_1.0.0.0.zip", "https://github.com/BepInEx/BepInEx.MonoMod.Loader/releases/download/v1.0.0.0/", "" };
		public string[] SideloaderInfo = { "H3VR.Sideloader_v0.3.3.zip", "https://github.com/denikson/H3VR.Sideloader/releases/download/v0.3.3/", "",  "bepinex", "resourceredirector" };
		public string[] LSIICInfo = { "LSIIC-v1.3.zip", "https://github.com/BlockBuilder57/LSIIC/releases/download/v1.3/", "addFolder?VirtualObjects/?unzipToDir?", "bepinex", "sideloader" };
		public string[] ConfigurationManagerInfo = { "BepInEx.ConfigurationManager_v16.1.zip", "https://github.com/BepInEx/BepInEx.ConfigurationManager/releases/download/v16.1/", "", "bepinex" };

		public string[] CursedDllsInfo = { "CursedDlls.BepInEx_v1.3.zip", "https://github.com/drummerdude2003/CursedDlls.BepinEx/releases/download/v1.3/", "", "bepinex", "monomod" };
		public string[] WurstModInfo = { "WurstMod.deli", "https://github.com/Nolenz/WurstMod/releases/download/v2.0.2.0/", "moveToFolder?WurstMod.deli?Mods/?WurstMod.deli", "bepinex", "deli"};
		public string[] TnHTweaker = { "TakeAndHoldTweaker.dll", "https://github.com/devyndamonster/TakeAndHoldTweaker/releases/download/v1.3.0/", "moveToFolder?TakeAndHoldTweaker.dll?BepInEx/plugins/?TakeAndHoldTweaker.dll", "bepinex" };
		public string[] H3VRUtilsInfo = { "H3VRUtilities.zip", "https://bonetome.com/download.php?file=MTRmZjdkYWM4M2YzNDdmNCszNjUrODUx", "unzipToDir?Mods/", "bepinex", "sideloader" };
		public string[] pccgInfo = { "PotatoesCustomGuns.zip", "https://bonetome.com/download.php?file=NGFmYTMxOWRjNmEwMTdhMSszNjUrNzUw", "unzipToDir?VirtualObjects/", "lsiic" };
		public string[] meatyceiverInfo = { "Meatyceiver032.zip", "https://bonetome.com/download.php?file=ZDMxZjYzMTgxYTg5OTdlYiszNjUrODk0", "unzipToDir?BepInEx/plugins/", "bepinex", "configurationmanager" };
		public string[] meatsSideChargerInfo = { "TurtsSidechARger.zip", "https://bonetome.com/download.php?file=OTI3NTY5Y2ZlYThiMzZkNCszNjUrOTQ2", "unzipToDir?VirtualObjects/", "lsiic" };
		public string[] meatsRigsInfo = { "MeatsRigs.zip", "https://bonetome.com/download.php?file=OGViNjM0MGVlOTUwMGYzNyszNjUrOTMw", "unzipToDir?VirtualObjects/", "lsiic" };
		public string[] meatsMagsInfo = { "MeatsMagazines.zip", "https://bonetome.com/download.php?file=MzZmNmEzNDZmNzJhNDdiMiszNjUrODkw", "unzipToDir?VirtualObjects/", "lsiic" };
		public string[] meatsModulSRInfo = { "MeatsModulSR1.1.zip", "https://bonetome.com/download.php?file=YjQzZTQ1MTM2MDQ0ODg3MSszNjUrODgz", "unzipToDir?VirtualObjects/", "lsiic" };
		public string[] meatsModulPPInfo = { "MeatsModulPP.zip", "https://bonetome.com/download.php?file=ODQ4YThkNDZjMGZhYzNmYSszNjUrODc3", "unzipToDir?VirtualObjects/", "lsiic", "meatsmodulak" };
		public string[] ModulARInfo = { "modular.zip", "https://bonetome.com/download.php?file=MjgxMDkxOThkYTE0Mjg4MCszNjUrODUw", "unzipToDir?VirtualObjects/", "lsiic" };
		public string[] meatsModulAKInfo = { "MeatsModulAK1.1.zip", "https://bonetome.com/download.php?file=NzFhNzc3MWJiZjQ2OWJhOCszNjUrODYx", "unzipToDir?VirtualObjects/", "lsiic", "h3vrutils" };
		public string[] meatsModulARPartsInfo = { "MeatsARParts.zip", "https://bonetome.com/download.php?file=NDU1MzQwZmVkOTA4YmYzYyszNjUrODQ3", "unzipToDir?VirtualObjects/", "lsiic", "modular" };
		public string[] ebrInfo = { "mk14+dcsb.zip", "https://bonetome.com/download.php?file=YzM2MTcyN2ZlYTRjNWRhNiszNjUrODg4", "unzipToDir?VirtualObjects/", "lsiic" };
		public string[] meatsmpxInfo = { "MeatsModulMPX", "https://bonetome.com/download.php?file=ZmZjNzFkZjA3NjM4NTI2NCszNjUrOTU1", "unzipToDir?VirtualObjects/", "lsiic", "h3vrutils", "modular"};

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
