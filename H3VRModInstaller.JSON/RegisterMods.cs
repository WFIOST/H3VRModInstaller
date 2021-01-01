using System.IO;
using System.Linq;
using GlobExpressions;
using Newtonsoft.Json;

namespace H3VRModInstaller.JSON
{
    public class Register
    {
        
        public bool RegisterMods()
        {
            var jsonfiles = Glob.FilesAndDirectories(JsonModList.Modinstallerdir, "**.json").ToArray();

            for (int i = 0; i <= jsonfiles.Length; i++)
            {
                var ModList = JsonConvert.DeserializeObject<ModListFormat>(File.ReadAllText(jsonfiles[i]));
            }

            return true;
            
        }
    }
}