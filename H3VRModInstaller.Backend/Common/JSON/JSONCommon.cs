using System.Collections.Generic;
using System.Linq;
using GlobExpressions;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.JSON.Common
{
    /// <summary>
    /// Common fields and functions for JSON!
    /// </summary>
    public static class JsonCommon
    {
        /// <summary>
        /// All JSON files in the database!
        /// </summary>
        public static string[] JsonFiles = Glob.FilesAndDirectories(H3VRModInstaller.Common.ModInstallerCommon.Files.Modinstallerdir, "**.json").ToArray();
        
        public static ModListFormat[] Jsonfiles = JsonModList.GetModLists();
        
    }
}