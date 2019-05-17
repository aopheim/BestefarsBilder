using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestefarsBilder
{
    class Logic
    {
        IStorage _storage;

        public Logic(IStorage s)
        {
            _storage = s;
        }

        public Art GetArtPostById(int id)
        {
            var arts = _storage.GetFromStorage();
            var res = arts.FirstOrDefault(x => x.id == id);
            return res;
        }

        // Should return a unique ID that is not present in the JSON file. + 1 of the highest registered ID
        public int GetUniqueId()
        {
            List<Art> arts = _storage.GetFromStorage().ToList();
            List<int> ids = arts.Select(x => x.id).ToList();
            return ids.Max() + 1;
        }

        public void AddArt(Art a)
        {
            var arts = _storage.GetFromStorage().ToList();
            arts.Add(a);
            _storage.PutInStorage(arts);
        }
        

        /// <summary>
        /// Editing an Art post. Return 1 if success. 0 if not success (bad ID)
        /// </summary>
        public int EditArt(int id, Art newArt)
        {
            var arts = _storage.GetFromStorage().ToList();
            List<int> validIDs = arts.Select(x => x.id).ToList();
            if (!validIDs.Contains(id))
            {
                return 0;
            }
            Art oldArt = GetArtPostById(id);
            arts.Insert(oldArt.id - 1, newArt);
            arts.Remove(arts[oldArt.id]);
            _storage.PutInStorage(arts);
            return 1;
        }
    }
}
