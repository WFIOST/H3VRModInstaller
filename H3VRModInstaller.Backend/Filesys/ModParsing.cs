using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller
{
	/// <summary>
	/// Parses together the deserialised JSON files
	/// </summary>
	public class ModParsing
	{
		/// <summary>
		/// Gets the mod info of a deserialized <c>ModFile</c> class
		/// </summary>
		/// <param name="mod">Mod</param>
		/// <param name="result">ModFile array to be returned</param>
		/// <param name="returndependencies">Defines if dependencies would be returned</param>
		/// <returns></returns>
		public static ModFile[] getModInfo(string mod, ModFile[] result = null, bool returndependencies = true)
		{
			if (result == null) result = new ModFile[0];
			ModListFormat[] ML = JsonModList.getmodLists();

			for (int i = 0; i < ML.Length; i++)
			{
				for (int x = 0; x < ML[i].Modlist.Length; x++)
				{
					if (ML[i].Modlist[x].ModId == mod)
					{
						Array.Resize<ModFile>(ref result, result.Length + 1);
						result[result.Length - 1] = ML[i].Modlist[x];
						if (returndependencies)
						{
							for (int y = 0; y < result[result.Length - 1].Dependencies.Length; y++)
							{
								result = getModInfo(result[result.Length - 1].Dependencies[y], result);
							}
						}
					}
				}
			}
			return result;
		}
	}
}
