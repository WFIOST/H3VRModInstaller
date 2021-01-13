using System;
using System.Net;
using H3VRModInstaller.JSON.Common;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace H3VRModInstaller.JSON
{
    /// <summary>
    ///<c>(NEW)</c> Gets the JSON ModFiles from GitHub itself instead of downloading it
    /// </summary>
    public class OnlineDatabase
    {
        /// <summary>
        ///     Gets the mods
        /// </summary>
        public static ModFile[] GetMods()
        {
            List<ModFile> mods = new();
            foreach (var URL in JsonCommon.OnlineDatabaseTEST)
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