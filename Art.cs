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

        /*
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
        */
    }
}
