using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestefarsBilder
{
    public class Art
    {
        public int id;
        public string title;
        public string artform;
        public string exhibition;
        public string dimensions;
        public string year;
        public string comment;

        public Art(int id)
        {
            this.id = id;
        }

        public Art(int id, string title, string artform, 
            string exhibition, string dimensions, string year, string comment)
        {
            this.id = id;
            this.title = title;
            this.artform = artform;
            this.exhibition = exhibition;
            this.dimensions = dimensions;
            this.year = year;
            this.comment = comment;
        }
    }
}
