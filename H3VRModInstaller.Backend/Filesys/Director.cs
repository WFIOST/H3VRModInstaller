using System.IO;

namespace H3VRModInstaller.Filesys
{
    public class Director
    {
        public static bool moveFileToPlugins(string fileToMove, string locationToMoveTo = "BepInEx/Plugins")
        {
            //this is even more redundant!
            File.Move(fileToMove, locationToMoveTo + fileToMove);
            return true;
        } 
    }
}