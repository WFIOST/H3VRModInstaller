using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using H3VRModInstaller.JSON.Common;

namespace H3VRModInstaller.JSON
{
    /// <summary>
    /// (NEW) Gets the JSON ModFiles from GitHub itself instead of downloading it 
    /// </summary>
    public class OnlineDatabase
    {
        /// <summary>
        /// Gets the mods
        /// </summary>
        public static async IAsyncEnumerable<ModFile[]> GetMods()
        {
                for (var i = 0; i <= JsonCommon.OnlineDatabaseTEST.Length; i++)
                {
                    var client = new HttpClient();
                    var response = await client.GetAsync(JsonCommon.OnlineDatabaseTEST[i]);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var mods = JsonConvert.DeserializeObject<ModListFormat>(responseBody);
                    yield return mods.Modlist;
                }
        }
    }
}