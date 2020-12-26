using System;
using System.IO;
using H3VRModInstaller.Net;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller.Filesys.Common
{
    class ModList
    {
	    private ModCheck modCheck = new ModCheck();
		public Tuple<string[,]> parseInfo(string[] infopath, string[,] modlist, string mod)
		{
			Console.WriteLine("Parsing " + infopath[0]);
			for (int i = 0; i < modlist.GetLength(0); i++)
			{
				bool _brk = false;
				if (modlist[i, 0] == "" || modlist[i, 0] == null)
				{
					modlist[i, 0] = infopath[0];
					modlist[i, 1] = infopath[1];
					modlist[i, 2] = infopath[2];
					modlist[i, 3] = mod;
					_brk = true;
				}
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
				modlist = new string[10, 5];
			}

			Tuple<string[,]> result;
			Console.WriteLine("Getting mod info for " + mod);
			string[] info = new string[1];

			ModListFormat[] ml = ModLists.LoadModLists();

			for (int i = 0; i < ml.Length; i++)
			{
				for (int x = 0; x < ml[i].modlist.Length; x++)
				{
					if (ml[i].modlist[x].modID == mod)
					{
						string[] _modresult = { ml[i].modlist[x].RawName, ml[i].modlist[x].Path, ml[i].modlist[x].Arguments };
						Array.Resize<string>(ref _modresult, _modresult.Length + ml[i].modlist[x].Dependencies.Length);
						for (int y = 0; y < ml[i].modlist[x].Dependencies.Length; y++)
						{
							_modresult[3 + y] = ml[i].modlist[x].Dependencies[y];
						}
						info = _modresult;
					}
				}
			}

			if(info.Length == 1) { Console.WriteLine("Fail to find mod!"); return null; }
			result = parseInfo(info, modlist, mod);

			for (int i = 0; i < modlist.GetLength(0) - 1; i++) {
				if (modlist[i, 0] == null) break;
				Console.WriteLine("mod info:" + modlist[i, 0] + ", " + modlist[i, 1] + ", " + modlist[i, 2]);
			}
			return Tuple.Create<string[,]>(result.Item1);
        }

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


		
		//this was a pain to make
		public string wurstModFile = Directory.GetCurrentDirectory() + "Mods/WurstMod.deli";
		public string tnhTweakerFile = Directory.GetCurrentDirectory() + "Mods/TakeAndHoldTweaker.deli";
		public string[] cursedDLLFiles = { Directory.GetCurrentDirectory() + "BepInEx/Plugins/CursedDlls/Cursed.BetterBipods.dll", Directory.GetCurrentDirectory() + "BepInEx/Plugins/CursedDlls/Cursed.FullAuto.dll", Directory.GetCurrentDirectory() + "BepInEx/Plugins/CursedDlls/Cursed.LoadScene.dll", Directory.GetCurrentDirectory() + "BepInEx/Plugins/CursedDlls/Cursed.RemoveAttachmentChecks.dll", Directory.GetCurrentDirectory() + "BepInEx/Plugins/CursedDlls/Cursed.RemoveMagCheck.dll", Directory.GetCurrentDirectory() + "BepInEx/Plugins/CursedDlls/Cursed.RemoveRoundTypeCheck.dll", Directory.GetCurrentDirectory() + "BepInEx/Plugins/CursedDlls/Cursed.SuppressAssemblyLoadErrors.dll", Directory.GetCurrentDirectory() + "BepInEx/Plugins/CursedDlls/Cursed.TimeScale.dll", Directory.GetCurrentDirectory() + "BepInEx/Plugins/CursedDlls/Cursed.UnlockAll.dll"};
		public string[] deliFiles = { Directory.GetCurrentDirectory() + "BepInEx/Plugins/Deli/Deli.Runtime.dll", Directory.GetCurrentDirectory() + "BepInEx/Patchers/Deli/ADepIn.dll", Directory.GetCurrentDirectory() + "BepInEx/Patchers/Deli/Deli.dll", Directory.GetCurrentDirectory() + "BepInEx/Patchers/Deli/DotNetZip.dll", Directory.GetCurrentDirectory() + "BepInEx/Patchers/Deli/I18N.dll", Directory.GetCurrentDirectory() + "BepInEx/Patchers/Deli/I18N.West.dll", Directory.GetCurrentDirectory() + "Mods/Deli.Core.deli", Directory.GetCurrentDirectory() + "Mods/Deli.MonoMod.deli"};
		

















    }
}
