using System.Net.NetworkInformation;

namespace H3VRModInstaller.Net
{
    /// <summary>
    /// Checks if you are online
    /// </summary>
    class NetCheck
    {
        /// <summary>
        /// Pings a URL (first param) with a timeout of 1000
        /// </summary>
        /// <param name="URL">
        /// URL of the site you would like to ping
        /// 
        /// <para>Keep in mind, this cannot have <c>https://</c></para>
        /// </param>
        /// <returns></returns>
        public static bool isOnline(string URL)
        {
            var ping = new Ping();
            var reply = ping.Send(URL, 1000);

			if (reply.Status == IPStatus.Success) return true;
            
            
            return false;
        }

    }
}
