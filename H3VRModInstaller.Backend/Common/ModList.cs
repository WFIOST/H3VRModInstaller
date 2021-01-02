using System;
using System.IO;
using H3VRModInstaller.Net;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller.Filesys.Common
{	
    class ModList
    {
		//parses mod info to get the dependencies of the mod
	    public static Tuple<string[,]> parseInfo(string[] infopath, string[,] modlist, string mod)
		{
			if (MainClass.enableDebugging) Console.WriteLine("Parsing " + infopath[0]);
			for (int i = 0; i < modlist.GetLength(0); i++) //for every mod...
			{
				bool _brk = false;
				if (modlist[i, 0] == "" || modlist[i, 0] == null)
				{
					//load all the individual modinfo into the modlist
					modlist[i, 0] = infopath[0]; // raw name
					modlist[i, 1] = infopath[1]; // path
					modlist[i, 2] = infopath[2]; // args
					modlist[i, 3] = mod; //modid
					_brk = true;
				}
				if (_brk) break; //i should probably fix this. later!
			}

			for (int i = 3; i < infopath.Length; i++) //this is probably wrong; i should be 4. this needs a rewrite.
			{
				if (infopath[i] == "") { Console.WriteLine("End of dependencies!"); break; }
				int num = i - 2; 
				int numofdep = infopath.Length - 3;
				Console.WriteLine(infopath[0] + " is getting dependency " + infopath[i] + ", dependency " + num + " of " + numofdep);
				getModInfo(infopath[i], modlist); //get modinfo for dependency
			}
			if (infopath.Length < 2) { Console.WriteLine("No dependencies, skipping!"); } //i don't think this ever gets called. again, rewrite.
			return Tuple.Create<string[,]>(modlist);
		}

		private const string VO = "VirtualObjects/";
		public static ModListFormat[] ml = null;

		//first thing to be called. this thing gets the relevant mod data for the downloader/installer from a given mod.
		public static Tuple<string[,]> getModInfo(string mod, string[,] modlist = null)
		{
			//starts a modlist of dependencies if it doesn't exist.
			if (modlist == null)
			{
				modlist = new string[10, 5];
			}
			ml = JsonModList.GetmodLists(MainClass.enableDebugging); //gets the modlist.


			Tuple<string[,]> result;
			if (MainClass.enableDebugging) Console.WriteLine("Getting mod info for " + mod);
			string[] info = new string[1];

			for (int i = 0; i < ml.Length; i++)
			{
				for (int x = 0; x < ml[i].Modlist.Length; x++)
				{
					if (ml[i].Modlist[x].ModId == mod)
					{
						//this part's done whenever it finds the mod.
						string[] _modresult = { ml[i].Modlist[x].RawName, ml[i].Modlist[x].Path, ml[i].Modlist[x].Arguments }; //stuffs all the needed info into one string array
						Array.Resize<string>(ref _modresult, _modresult.Length + ml[i].Modlist[x].Dependencies.Length); //resizes array to add room for all dependencies
						for (int y = 0; y < ml[i].Modlist[x].Dependencies.Length; y++)
						{
							_modresult[3 + y] = ml[i].Modlist[x].Dependencies[y]; //adds dependencies one at a time
						}
						info = _modresult; //now sets info to _modresult.
					}
				}
			}

			//if info.length is the default length (1) it means it didnt find a mod.
			if(info.Length == 1) { Console.WriteLine("Fail to find mod!"); return null; }
			result = parseInfo(info, modlist, mod); 

			//exports all the relevant modinfo about a mod
			for (int i = 0; i < modlist.GetLength(0) - 1; i++) {
				if (modlist[i, 0] == null) break;
				if (MainClass.enableDebugging) Console.WriteLine("mod info:" + modlist[i, 0] + ", " + modlist[i, 1] + ", " + modlist[i, 2]);
			}
			return Tuple.Create<string[,]>(result.Item1);
        }
    }
}
