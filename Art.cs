using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestefarsBilder
{
    public class Art
    {
        public int id { get; set; }
        public string title { get; set; }
        public string artform { get; set; }
        public string exhibition { get; set; }
        public string dimensions { get; set; }
        public string year { get; set; }
        public string comment { get; set; }
        public int numImageFiles { get; set; }
    }
}
