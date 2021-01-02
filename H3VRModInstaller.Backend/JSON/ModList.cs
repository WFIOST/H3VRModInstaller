using System;
using H3VRModInstaller.Common;
using H3VRModInstaller.JSON;


namespace H3VRModInstaller.Filesys.Common.reetard
{
	
    class ModList
    {
	    
	    public static Tuple<string[,]> parseInfo(string[] infopath, string[,] modlist, string mod)
		{
			ModInstallerCommon.DebugLog("Parsing " + infopath[0]);
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
		public static ModListFormat[] ml = null;

		public static Tuple<string[,]> getModInfo(string mod, string[,] modlist = null)
		{
			if (modlist == null)
			{
				modlist = new string[10, 5];
			}
			ml = JsonModList.GetmodLists();


			Tuple<string[,]> result;
			ModInstallerCommon.DebugLog("Getting mod info for " + mod);
			string[] info = new string[1];

			for (int i = 0; i < ml.Length; i++)
			{
				for (int x = 0; x < ml[i].Modlist.Length; x++)
				{
					if (ml[i].Modlist[x].ModId == mod)
					{
						string[] _modresult = { ml[i].Modlist[x].RawName, ml[i].Modlist[x].Path, ml[i].Modlist[x].Arguments };
						Array.Resize<string>(ref _modresult, _modresult.Length + ml[i].Modlist[x].Dependencies.Length);
						for (int y = 0; y < ml[i].Modlist[x].Dependencies.Length; y++)
						{
							_modresult[3 + y] = ml[i].Modlist[x].Dependencies[y];
						}
						info = _modresult;
					}
				}
			}

			if(info.Length == 1) { Console.WriteLine("Fail to find mod!"); return null; }
			result = parseInfo(info, modlist, mod);

			for (int i = 0; i < modlist.GetLength(0) - 1; i++) {
				if (modlist[i, 0] == null) break;
				ModInstallerCommon.DebugLog("mod info:" + modlist[i, 0] + ", " + modlist[i, 1] + ", " + modlist[i, 2]);
			}
			return Tuple.Create<string[,]>(result.Item1);
        }
    }
}
