using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestefarsBilder
{
    internal class Storage: IStorage
    {
        string _jsonPath;
        public Storage(string storagePath)
        {
            _jsonPath = storagePath;
        }

        public IEnumerable<Art> GetFromStorage() {
            string jsonString = File.ReadAllText(_jsonPath);
            return JsonConvert.DeserializeObject<List<Art>>(jsonString);
        }

        public void PutInStorage(IEnumerable<Art> arts) {
            arts.ToList().OrderBy(x => x.id);
            string newJson = JsonConvert.SerializeObject(arts, Formatting.Indented);
            File.WriteAllText(_jsonPath, newJson);
        }
    }
}
