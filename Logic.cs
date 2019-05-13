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

        public void AddArt(Art a)
        {
            var arts = _storage.GetFromStorage().ToList();
            arts.Add(a);
            _storage.PutInStorage(arts);
        }
        
        public void EditArt(int id, Art newArt)
        {
            var arts = _storage.GetFromStorage().ToList();
            Art oldArt = GetArtPostById(id);
            oldArt = newArt;
            arts.Insert(oldArt.id - 1, newArt);
            _storage.PutInStorage(arts);
        }
    }
}
