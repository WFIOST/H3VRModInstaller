using System.Linq;
using GlobExpressions;

namespace H3VRModInstaller.JSON.Common
{
    public class Common
    {
        public string[] JsonFiles = Glob.FilesAndDirectories(JsonModList.Modinstallerdir, "**.json").ToArray();
        
        //public 
    }
}