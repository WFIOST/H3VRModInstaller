using System;
using Newtonsoft.Json;
using System.IO;

namespace H3VRModInstaller.JSON
{
    public class ModFile
    {
        public string Name { get; set; }
        public string File { get; set; }
        public string[] Author { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string[] Arguments { get; set; }
        public string[] Dependencies { get; set; }
    }

    public class GetModLists
    {
        private ModFile BepInEx = new ModFile();
        public bool SerialiseBepInEx()
        {
            BepInEx.Name = "BepInEx";
            BepInEx.File = "BepInEx_x64_5.4.4.0.zip";
            BepInEx.Author[0] = "Bepis";
            BepInEx.Author[1] = "Horse";
            BepInEx.Version = "5.4.4.0";
            BepInEx.Description = "BepInEx is a plugin / modding framework for Unity Mono, IL2CPP and .NET framework games (XNA, FNA, MonoGame, etc.)";
            BepInEx.Path = "https://github.com/BepInEx/BepInEx/releases/download/v5.4.4/";
            BepInEx.Arguments[0] = "";
            BepInEx.Dependencies[0] = "";
            
            string serialisedBepInEx = JsonConvert.SerializeObject(BepInEx);
            makeModFilesDir();
            File.Create(Directory.GetCurrentDirectory() + "/ModFiles/BepInEx.json");
            File.WriteAllText(Directory.GetCurrentDirectory() + "/ModFiles/BepInEx.json", serialisedBepInEx);
            Console.WriteLine(serialisedBepInEx);
            return true;
        }

        private bool makeModFilesDir()
        {
            if (!Directory.Exists("/ModFiles/"))
            {
                Directory.CreateDirectory("/ModFiles/");
            }
            return true;
        }
        
    }
    
}