using System;
using Newtonsoft.Json;
using System.IO;

namespace H3VRModInstaller.Json
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

    public class Serialisation
    {
        private ModFile ModFile = new ModFile();
       
        public string Deserialise(string FileToDeserialise)
        {
            ModFile DeserialisedModFile = JsonConvert.DeserializeObject<ModFile>(File.ReadAllText(@FileToDeserialise));

            Console.WriteLine("Deserialised Json: " + DeserialisedModFile);

            return "Deserialised JSON file " + FileToDeserialise;
        }

        public string Serialise(string FileToSerialise)
        {
            string SerialisedObject = JsonConvert.SerializeObject(ModFile);
            
            return "Serialised JSON file " + FileToSerialise;
        }
        

    }
}