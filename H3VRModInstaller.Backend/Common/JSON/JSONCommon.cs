using System.Collections.Generic;
using System.Linq;
using GlobExpressions;
using H3VRModInstaller.Common;

namespace H3VRModInstaller.JSON.Common
{
    /// <summary>
    /// Common fields and functions for JSON!
    /// </summary>
    public class CommonJson
    {
        /// <summary>
        /// All JSON files in the database!
        /// </summary>
        public string[] JsonFiles = Glob.FilesAndDirectories(H3VRModInstaller.Common.ModInstallerCommon.Files.Modinstallerdir, "**.json").ToArray();
        /// <summary>
        /// Gets every filepath of the mods, and adds them to the list defined as the secont parameter
        /// </summary>
        /// <param name="filesToSort">Files to sort</param>
        /// <param name="listToAppendTo">List to Append to</param>
        /// <returns>Returns the list which was specified in second parameter</returns>
        public List<string> GetEachPath(string[] filesToSort, List<string> listToAppendTo)
        {
            
            return listToAppendTo;
        }
        
    }
}