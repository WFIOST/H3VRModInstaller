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
            for (var i = 0; i <= JsonCommon.OnlineDatabaseTEST.Length; i++)
            {
                var client = new HttpClient();
                try	
                {
                    HttpResponseMessage response = await client.GetAsync(JsonCommon.OnlineDatabaseTEST[i]);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    ModListFormat mods = JsonConvert.DeserializeObject<ModListFormat>(responseBody);

                    for (int j = 0; j < mods.Modlist.Length; j++)
                    {
                        Console.WriteLine($"Name: {mods.Modlist[j].Name}\n");
                    }
                    
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");	
                    Console.WriteLine("Message: {0} ",e.Message);
                }
            }
        }
    }
}