using System;
using System.Net;
using H3VRModInstaller.JSON.Common;
using H3VRModInstaller.JSON;
using Newtonsoft.Json;

namespace H3VRModInstaller.Sandbox.JSON
{
    /// <summary>
    ///<c>(NEW)</c> Gets the JSON ModFiles from GitHub itself instead of downloading it
    /// </summary>
    public class OnlineDatabase
    {
        /// <summary>
        /// Gets all mods, from github, no downloading required
        /// </summary>
        /// <returns>ModFile Array</returns>
        public static ModFile[] GetMods()
        {
            ModListFormat mods = new ModListFormat();
            foreach (var URL in JsonCommon.OnlineDatabaseTEST)
            {
                var client = new WebClient();
                var serialised = client.DownloadString(URL);
                mods = JsonConvert.DeserializeObject<ModListFormat>(serialised);
            }
            Console.WriteLine("Got Mods!");
            return mods.Modlist;
        }
        
    }
}