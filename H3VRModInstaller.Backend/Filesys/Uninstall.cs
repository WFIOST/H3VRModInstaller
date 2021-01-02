using GlobExpressions;
using System.IO;
using System.Linq;


namespace H3VRModInstaller.Filesys
{
    /// <summary>
    /// Enum for the directories, pretty useless,
    /// </summary>
    public enum Dirs
    {
        Mods,
        Plugins,
        VirtualObjects,
        CustomCharacters,
        Maps
    }
    
    public class Uninstall
    {
        /// <summary>
        /// Gets all of the assemblies to delete, located in the "BepInEx/Plugins" directory
        /// </summary>
        string[] dllFilesToDelete = Glob.FilesAndDirectories(@"BepInEx/Plugins/", "**.dll").ToArray();
        
        /// <summary>
        /// Gets all the h3mods to delete, located in the "Mods/" directory
        /// </summary>
        string[] h3ModsToDelete = Glob.FilesAndDirectories(@"Mods/", "**.h3mod").ToArray();
        
        /// <summary>
        /// Gets all the hotmods to delete, located in the "Mods/" directory
        /// </summary>
        string[] hotModsToDelete = Glob.FilesAndDirectories(@"Mods/", "**.hotmod").ToArray();
        
        /// <summary>
        /// Gets all the deli mods to delete, located in the "Mods/" directory
        /// </summary>
        string[] deliModsToDelete = Glob.FilesAndDirectories(@"Mods/", "**.deli").ToArray();
        
        
        public bool Delete(string modToRemove, Dirs directory)
        {
            string dir = "";
            switch (directory)
            {
                case Dirs.Mods:
                    dir = "Mods/";
                    break;
                case Dirs.Plugins:
                    dir = "BepInEx/Plugins/";
                    break;
                case Dirs.VirtualObjects:
                    dir = "VirtualObjects/";
                    break;
                case Dirs.CustomCharacters:
                    dir = "TNH_Tweaker/";
                    break;
                case Dirs.Maps:
                    dir = "CustomLevels/";
                    break;
            }
            File.Delete(dir + modToRemove);
            return true;
        }

        public bool DeleteAllMods()
        {
                
            DeleteAllDlls();
            
            DeleteAllH3Mods();
            
            DeleteAllDeliMods();
            
            return true;
        }

        public bool DeleteAllDlls()
        {
            for (int i = 0; i <= dllFilesToDelete.Length; i++)
            {
                File.Delete(dllFilesToDelete[i]);
            }
            return true;
        }

        public bool DeleteAllH3Mods()
        {
            for (int i = 0; i <= h3ModsToDelete.Length; i++)
            {
                File.Delete(h3ModsToDelete[i]);
            }
            for (int i = 0; i <= hotModsToDelete.Length; i++)
            {
                File.Delete(hotModsToDelete[i]);
            }
            return true;
        }

        public bool DeleteAllDeliMods()
        {
            for (int i = 0; i <= deliModsToDelete.Length; i++)
            {
                File.Delete(deliModsToDelete[i]);
            }
            return true;
        }


    }
}