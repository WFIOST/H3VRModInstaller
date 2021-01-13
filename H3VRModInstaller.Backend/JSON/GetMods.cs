using System;
using System.Net;
using H3VRModInstaller.JSON.Common;
using Newtonsoft.Json;

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
        public static ModFile[] GetMods(ModFile[] ModFilesToGet = null)
        {
            //May god forgive me for my sins
            foreach (var c in JsonCommon.OnlineDatabaseTEST)
            {
                var webClient = new WebClient();
                var serialised = webClient.DownloadString(c);
                var deserialised = JsonModList.DeserializeModListFormat(serialised);
                ModFilesToGet = deserialised.Modlist;
            }
            return ModFilesToGet;
        }
        
        
        
    }
}