using System.Collections.Generic;
using System.Linq;
using GlobExpressions;
using H3VRModInstaller.JSON;

namespace H3VRModInstaller.JSON.Common
{
    /// <summary>
    /// Common fields and functions for JSON!
    /// </summary>
    public class Common
    {
        /// <summary>
        /// All JSON files in the database!
        /// </summary>
        public string[] JsonFiles = Glob.FilesAndDirectories(modLists.Modinstallerdir, "**.json").ToArray();
        /// <summary>
        /// Gets every filepath of the mods, and adds them to the list defined as the secont parameter
        /// </summary>
        /// <param name="Files To Sort"></param>
        /// <param name="List to append to"></param>
        /// <returns>Returns the list which was specified in second parameter</returns>
        public List<string> GetEachPath(string[] FilesToSort, List<string> ListToAppendTo)
        {
            
            return ListToAppendTo;
        }
        
    }
}