using System.Net.NetworkInformation;

namespace H3VRModInstaller.Net
{
    class NetCheck
    {
        public static bool isOnline(string URL)
        {
            var ping = new Ping();
            var reply = ping.Send(URL, 1000);


            if (reply.Status == IPStatus.Success)
                return true;
            return false;
        }

    }
}
