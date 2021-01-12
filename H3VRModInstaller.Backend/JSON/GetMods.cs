using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using H3VRModInstaller.JSON.Common;
using Newtonsoft.Json.Linq;

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
        public static ModFile[] GetMods(ModFile[] AmoungDrip = null)
        {



            try
            {
                for (int i = 0; i < JsonCommon.OnlineDatabaseTEST.Length; i++)
                {
                    var shitCumPiss = new WebClient();
                
                    var bigBigChungus = shitCumPiss.DownloadString(JsonCommon.OnlineDatabaseTEST[i]);
                
                    //Console.WriteLine(bigBigChungus);
                
                    var whenTheImposterIsSus = JsonConvert.DeserializeObject<ModListFormat>(bigBigChungus);


                    for (int j = 0; j < whenTheImposterIsSus.Modlist.Length; j++)
                    {
                        Console.WriteLine("Name: {0}", whenTheImposterIsSus.Modlist[j].Name);
                    }
                
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("lmfao it error, *cums*");
            }
            
            return null;
        }
    }
}