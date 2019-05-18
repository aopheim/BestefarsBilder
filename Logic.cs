using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestefarsBilder
{
    class Logic
    {
        IStorage _storage;

        public Logic(IStorage s)
        {
            _storage = s;
        }

        public Art GetArtFromForm(IArtForm form)
        {
            List<TextBox> txtboxes = form.GetTextBoxes();
            List<ComboBox> comboBoxes = form.GetComboBoxes();

            int id = Int32.Parse(txtboxes.Find(x => x.Name == "txtbxId").Text);
            string title = txtboxes.Find(x => x.Name == "txtbxTitle").Text;
            string artform = comboBoxes.Find(x => x.Name == "cmbxArtForm").Text;
            string exhibition = comboBoxes.Find(x => x.Name == "cmbxExhibition").Text;
            string dimensions = comboBoxes.Find(x => x.Name == "cmbxDimensions").Text;
            string year = txtboxes.Find(x => x.Name == "txtbxYear").Text;       // Saving as string makes it possible to save no year as ""
            string comment = txtboxes.Find(x => x.Name == "txtbxComment").Text;

            Art a = new Art
            {
                id = id,
                title = title,
                artform = artform,
                exhibition = exhibition,
                dimensions = dimensions,
                year = year,
                comment = comment,
            };
            return a;
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
