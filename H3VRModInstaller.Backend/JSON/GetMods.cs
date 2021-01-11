using System;
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
        public static async void GetMods()
        {

            try
            {
                for (var i = 0; i <= JsonCommon.OnlineDatabaseTEST.Length; i++)
                {
                    var client = new HttpClient();
                    var response = await client.GetAsync(JsonCommon.OnlineDatabaseTEST[i]);
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var mods = JsonConvert.DeserializeObject<ModListFormat>(responseBody);

                    foreach (var t in mods.Modlist)
                    {
                        Console.WriteLine("Name: {0} \n", t.Name);
                    }
                
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("lmfao erro");
                
            }
            
        }
    }
}