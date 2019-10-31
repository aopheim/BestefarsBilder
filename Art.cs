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
        public string tags { get; set; }
        public string room { get; set; }
        public string shelf { get; set; }
        public int numImageFiles { get; set; }
        public DateTime lastEdit = DateTime.Now;


        public override string ToString() {
            return "" +
                "Katalognr.: " + id.ToString() + "\n" +
                "Tittel: " + title + "\n" +
                "Kunstform: " + artform + "\n" +
                //"Utstilling: " + exhibition + "\n" +
                "Dimensjoner: " + dimensions + "\n" +
                "År: " + year + "\n" +
                "Sist endret: " + lastEdit.ToString("dd-MM-yyyy HH:mm:ss") + "\n" +
                "Rom: " + room + "\n" +
                "Hylle: " + shelf + "\n" +
                "Tags: " + tags + "\n" +
                "Kommentar: " + comment + "\n";
        }
    }
}
