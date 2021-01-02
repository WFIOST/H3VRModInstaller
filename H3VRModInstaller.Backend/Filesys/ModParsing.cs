using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller
{
	public class ModParsing
	{
		
		public static ModFile[] getModInfo(string mod, ModFile[] result = null, bool returndependencies = true)
		{
			if (result == null) result = new ModFile[0];
			ModListFormat[] ML = JsonModList.GetmodLists();

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
