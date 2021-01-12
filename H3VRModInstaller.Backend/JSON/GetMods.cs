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
        public static ModFile[] GetMods(ModFile[] AmongDrip = null)
        {
            //May god forgive me for my sins

            foreach (var c in JsonCommon.OnlineDatabaseTEST)
            {
                var webClient = new WebClient();
                var serialisedJSON = webClient.DownloadString(c);
                var serialised = JsonConvert.DeserializeObject<ModListFormat>(serialisedJSON);
                foreach (var p in serialised.Modlist) Console.WriteLine("Name: {0}", p.Name);
            }


            return null;
        }
    }
}