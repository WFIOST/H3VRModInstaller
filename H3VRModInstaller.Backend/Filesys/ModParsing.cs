using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H3VRModInstaller.JSON;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.Filesys
{
	/// <summary>
	/// Parses together the deserialised JSON files
	/// </summary>
	public class ModParsing
	{
		/// <summary>
		/// Gets the mod info and dependencies of a deserialized <c>ModFile</c> class
		/// </summary>
		/// <param name="modid">Modid of mod and dependencies you want</param>
		/// <returns></returns>
		public static ModFile[] GetModInfoAndDependencies(string modid)
		{
			ModFile[] result = new ModFile[1];
			ModFile mf = GetSpecificMod(modid); //get modfile of main mod
			result[result.Length - 1] = mf;
			result = result.Concat(GetDependencies(mf)).ToArray(); //get dependencies and add them to result
			
			return result;
		}

		/// <summary>
		/// Gets dependencies given a <c>ModFile</c> class
		/// </summary>
		/// <param name="mod">Modfile of mod you want dependencies of</param>
		/// <returns></returns>
		public static ModFile[] GetDependencies(ModFile mod)
		{
			ModFile[] result = new ModFile[0];
			for (int i = 0; i < mod.Dependencies.Length; i++) //for every dependency,
			{
				Array.Resize<ModFile>(ref result, result.Length + 1);
				result[result.Length - 1] = GetSpecificMod(mod.Dependencies[i]); //add the modfile to the modfile array
				result = result.Concat(GetDependencies(result[result.Length - 1])).ToArray(); //then add their dependencies
			}
			return result;
		}

		/// <summary>
		/// Gets the mod info of a deserialized <c>ModFile</c> class
		/// </summary>
		/// <param name="modid">Modid of mod and dependencies you want</param>
		/// <returns></returns>
		public static ModFile GetSpecificMod(string modid)
		{
			ModListFormat[] ml = JsonModList.GetModLists();

			for (int i = 0; i < ml.Length; i++)
			{
				for (int x = 0; x < ml[i].Modlist.Length; x++)
				{
					if (ml[i].Modlist[x].ModId == modid)
					{
						return ml[i].Modlist[x]; //sift through every goddamn modfile and find the one with the matching modid
					}
				}
			}
			return null;
		}
	}
}
