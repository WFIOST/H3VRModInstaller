using System;
using System.Collections.Generic;
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
            List<ModFile> mods = new();
            foreach (var URL in JsonCommon.DatabaseURLs)
            {
                var client = new WebClient();
                var serialised = client.DownloadString(URL);
                var modList = JsonConvert.DeserializeObject<ModListFormat>(serialised);
                for (int i = 0; i < modList.Modlist.Length; i++)
                {
                    mods.Add(modList.Modlist[i]);
                }
            }
            Console.WriteLine("Got Mods!");
            return mods.ToArray();
        }
        
    }
}