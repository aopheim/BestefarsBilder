using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestefarsBilder
{
    public interface IStorage
    {
        void PutInStorage(IEnumerable<Art> arts);
        IEnumerable<Art> GetFromStorage();
    }
}
