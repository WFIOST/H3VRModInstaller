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
       
        public string Deserialise(string FileToDeserialise)
        {
            ModFile ModFile = JsonConvert.DeserializeObject<ModFile>(File.ReadAllText(@FileToDeserialise));

            

            return "Deserialised JSON file " + FileToDeserialise;
        }
        
    }
}