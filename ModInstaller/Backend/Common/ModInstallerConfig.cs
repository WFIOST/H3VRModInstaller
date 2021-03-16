using System;
using System.IO;
using Newtonsoft.Json;

namespace H3VRModInstaller.Common
{
    public class ModInstallerConfig
    {
        public string DatabaseInfoLocation    { get; set; }
        public string GameDirectory           { get; set; }
        public string OverridePath            { get; set; }
        public bool   DebugMode               { get; set; }
        public bool   RemoveConfigsOnDeletion { get; set; }
        public bool   DeleteArchiveOnFinish   { get; set; }
        
        [JsonIgnore]
        public string ConfigPath => Path.Combine(Utilities.GameDirectory + "/ModInstaller/config.json");

        public static string GenerateModInstallerConfig()
        {
            var conf = new ModInstallerConfig().ConfigPath;

            if (!Directory.Exists(Path.Combine(Utilities.GameDirectory + "ModInstaller/")))
            {
                Console.WriteLine("ModInstaller Directory not found, creating!");
                Directory.CreateDirectory(Path.Combine(Utilities.GameDirectory + "ModInstaller/"));
            }
            if (!File.Exists(conf))
            {
                Console.WriteLine("Config file not found, creating!");
                var cnf = File.Create(conf);
                cnf.Close();

                var defaultConfig = new ModInstallerConfig()
                {
                    DatabaseInfoLocation = "https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/src/Backend/JSON/Database/modinstallerinfo.h3vrmi",
                    GameDirectory = Utilities.GameDirectory,
                    OverridePath = "",
                    DebugMode = false,
                    RemoveConfigsOnDeletion = false,
                    DeleteArchiveOnFinish = true
                };
                
                File.WriteAllText(conf, JsonConvert.SerializeObject(defaultConfig, Formatting.Indented));
                
            }
            return conf;
        }

        public static ModInstallerConfig GetConfig()
        {
            var conf = new ModInstallerConfig().ConfigPath;
            return JsonConvert.DeserializeObject<ModInstallerConfig>(File.ReadAllText(conf));
        }
    }
    
}