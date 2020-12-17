using GlobExpressions;
using System.IO;
using System.Linq;


namespace H3VRModInstaller.Filesys
{
    public class Uninstall
    {
        public bool Remove(string modToRemove)
        {
            File.Delete(modToRemove);
            return true;
        }

        public bool DeleteAllMods()
        {
            string[] dllFilesToDelete = Glob.FilesAndDirectories(@"BepInEx/Plugins/", "**.dll").ToArray();
            string[] h3ModsToDelete = Glob.FilesAndDirectories(@"Mods/", "**.h3mod").ToArray();
            string[] hotModsToDelete = Glob.FilesAndDirectories(@"Mods/", "**.hotmod").ToArray();
            string[] deliModsToDelete = Glob.FilesAndDirectories(@"Mods/", "**.deli").ToArray();
            for (int i = 0; i <= dllFilesToDelete.Length; i++)
            {
                File.Delete(dllFilesToDelete[i]);
            }
            for (int i = 0; i <= h3ModsToDelete.Length; i++)
            {
                File.Delete(h3ModsToDelete[i]);
            }
            for (int i = 0; i <= hotModsToDelete.Length; i++)
            {
                File.Delete(hotModsToDelete[i]);
            }
            for (int i = 0; i <= deliModsToDelete.Length; i++)
            {
                File.Delete(deliModsToDelete[i]);
            }
            return true;
        }
        
    }
}