using System.IO;

namespace H3VRModInstaller.Backend.Files
{
    public class FileSys
    {
        public static bool moveFileToPlugins(string fileToMove, string locationToMoveTo = "BepInEx/Plugins")
        {
            //this is even more redundant!
            File.Move(fileToMove, locationToMoveTo + fileToMove);
            return true;
        }
    }
}