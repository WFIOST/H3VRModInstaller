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
        ///     Gets the mods
        /// </summary>
        public static ModFile[] GetMods(ModFile[] ModFilesToGet = null)
        {
            foreach (var URL in JsonCommon.OnlineDatabaseTEST)
            {
                var client = new WebClient();
                var serialised = client.DownloadString(URL);
                //Console.WriteLine(serialised);
                var deserialised = JsonConvert.DeserializeObject<ModListFormat>(serialised);
                for (int i = 0; i < deserialised.Modlist.Length; i++)
                {
                    Console.WriteLine("Name: {0}", deserialised.Modlist[i].Name);
                }
            }

            return null;
        }
        
    }
}