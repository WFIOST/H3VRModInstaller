using System;
using System.Collections.Generic;
using System.Linq;
using H3VRModInstaller.Common;
using GlobExpressions;

namespace H3VRModInstaller.Filesys.Common
{
    public class ModCheck
    {
        private static string[] listOfMods;
        public static string[] PluginModsToArray()
        {
            listOfMods = Glob.Files(Directories.pluginsDir, "*.dll").ToArray();
            
            Console.WriteLine(listOfMods);
            
            
            return listOfMods;
        }

        public List<string> ModsToList(List<string> listOfMods)
        {


            return listOfMods;
        }
        
        
    }
}