using System.IO;
using System.Net.NetworkInformation;

namespace H3VRModInstaller.Backend
{
    internal class func
    {
        public static bool isOnline(string URL)
        {
            var ping = new Ping();
            var reply = ping.Send(URL, 1000);


            if (reply.Status == IPStatus.Success)
                return true;
            return false;
        }
        public static bool moveFileToPlugins(string fileToMove, string locationToMoveTo = "BepInEx/Plugins")
        {
            //this is even more redundant!
            File.Move(fileToMove, locationToMoveTo + fileToMove);
            return true;
        }
    }
}
