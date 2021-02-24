using System;
using System.Net.NetworkInformation;

namespace H3VRModInstaller.Net
{
    /// <summary>
    ///     Checks if you are online
    /// </summary>
    internal class NetCheck
    {
        /// <summary>
        ///     Pings a URL (first param) with a timeout of 1000
        /// </summary>
        /// <param name="url">
        ///     URL of the site you would like to ping
        ///     <para>Keep in mind, this cannot have <c>https://</c></para>
        /// </param>
        /// <returns></returns>
        public static bool isOnline(string url)
        {
            var ping = new Ping();

            try
            {
                var reply = ping.Send(url, 1000);
                if (reply.Status == IPStatus.Success) {return true;}
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}