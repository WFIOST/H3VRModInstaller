using System;
using System.IO;
using Newtonsoft.Json;

namespace H3VRModInstaller.Common
{
    public class ModInstallerConfig
    {
        public string DatabaseInfoLocation    { get; set; }
        public string GameDirectory           { get; set; }

        [JsonIgnore]
        public static string ConfigPath => Path.Combine(ModInstallerCommon.ModInstallerDir + "\\config.json");
        
        
        public static string GenerateModInstallerConfig()
        {

            if (!Directory.Exists(ModInstallerCommon.ModInstallerDir))
            {
                Console.WriteLine("ModInstaller Directory not found, creating!");
                Directory.CreateDirectory(ModInstallerCommon.ModInstallerDir);
            }
            if (!File.Exists(ConfigPath))
            {
                Console.WriteLine("Config file not found, creating!");
                var f = File.Create(ConfigPath);
                f.Close();

                var defaultConfig = new ModInstallerConfig()
                {
                    DatabaseInfoLocation = "https://raw.githubusercontent.com/Frityet/H3VRModInstaller/master/src/Backend/JSON/Database/modinstallerinfo.h3vrmi",
                    GameDirectory = Utilities.GameDirectory
                };
                
                File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(defaultConfig, Formatting.Indented));
                
            }
            return ConfigPath;
        }

        public static ModInstallerConfig Config
        {
            get => JsonConvert.DeserializeObject<ModInstallerConfig>(File.ReadAllText(ConfigPath));
            
            set => 
                File.WriteAllText
                (
                    ConfigPath,
                JsonConvert.SerializeObject
                    (
                        value,
                        Formatting.Indented
                    )
                );
        }
        
    }
    
}