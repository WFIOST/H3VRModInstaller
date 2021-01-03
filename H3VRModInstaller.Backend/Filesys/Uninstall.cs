using GlobExpressions;
using System.IO;
using System.Linq;


namespace H3VRModInstaller.Filesys
{

    /// <summary>
    /// Enums for choosing directories
    /// </summary>
    public enum Dirs
    {
        /// <summary>
        /// The <c>/Mods/</c> Directory
        /// </summary>
        Mods,
        /// <summary>
        /// The <c>/BepInEx/Plugins/</c> Directory
        /// </summary>
        Plugins,
        /// <summary>
        /// The <c>/VirtualObjects/</c> Directory
        /// </summary>
        VirtualObjects,
        /// <summary>
        /// The <c>/CustomCharacters/</c> Directory
        /// </summary>
        CustomCharacters,
        /// <summary>
        /// The <c>/CustomLevels/</c> Directory
        /// </summary>
        Maps
    }
    
    /// <summary>
    /// WIP class to handle uninstallation
    /// </summary>
    public class Uninstall
    {
        /// <summary>
        /// Gets all of the assemblies to delete, located in the "BepInEx/Plugins" directory
        /// </summary>
        string[] _dllFilesToDelete = Glob.FilesAndDirectories(@"BepInEx/Plugins/", "**.dll").ToArray();
        
        /// <summary>
        /// Gets all the h3mods to delete, located in the "Mods/" directory
        /// </summary>
        string[] _h3ModsToDelete = Glob.FilesAndDirectories(@"Mods/", "**.h3mod").ToArray();
        
        /// <summary>
        /// Gets all the hotmods to delete, located in the "Mods/" directory
        /// </summary>
        string[] _hotModsToDelete = Glob.FilesAndDirectories(@"Mods/", "**.hotmod").ToArray();
        
        /// <summary>
        /// Gets all the deli mods to delete, located in the "Mods/" directory
        /// </summary>
        string[] _deliModsToDelete = Glob.FilesAndDirectories(@"Mods/", "**.deli").ToArray();
        
        
        /// <summary>
        /// Deletes the mod based off the arguments, to be revamped soon
        /// </summary>
        /// <param name="modToRemove">The mod to delete</param>
        /// <param name="directory">the directory to delete from</param>
        /// <returns></returns>
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
            for (int i = 0; i <= _dllFilesToDelete.Length; i++)
            {
                File.Delete(_dllFilesToDelete[i]);
            }
            return true;
        }

        public bool DeleteAllH3Mods()
        {
            for (int i = 0; i <= _h3ModsToDelete.Length; i++)
            {
                File.Delete(_h3ModsToDelete[i]);
            }
            for (int i = 0; i <= _hotModsToDelete.Length; i++)
            {
                File.Delete(_hotModsToDelete[i]);
            }
            return true;
        }

        public bool DeleteAllDeliMods()
        {
            for (int i = 0; i <= _deliModsToDelete.Length; i++)
            {
                File.Delete(_deliModsToDelete[i]);
            }
            return true;
        }


    }
}