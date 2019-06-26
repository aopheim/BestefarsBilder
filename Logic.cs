using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BestefarsBilder
{
    public class Logic
    {
        private IStorage _storage;
        private IArtForm _form;
        public bool IsNewReg { get; set; }
        public bool IsReadReg { get; set; }
        public bool IsEditReg { get; set; }

        public Logic(IStorage s, IArtForm form)
        {
            _storage = s;
            _form = form;
            IsNewReg = false;
            IsReadReg = false;
            IsEditReg = false;
        }

        /// <summary>
        /// Defining what actions to take when clicking the save button
        /// </summary>
        public void OnSave()
        {
            Art newArt = this.GetArtFromForm(_form);

            if (newArt.numImageFiles == 0)
            {
                DialogResult result = _form.GetGraphics().ShowWarningBox(newArt);
                if (result == DialogResult.No)
                {
                    _form.GetGraphics().FillFields(newArt.id);
                    return;
                }
            }

            if (IsNewReg) // Registration is to be added to the JSON file
            {
                AddArt(newArt);
                SaveImages(_form.GetOrigImagePaths(), newArt);
                System.Drawing.Image img = ExportImageToPrint(newArt);
                string fileToPrintPath = System.IO.Path.Combine(_form.GetImagesPath(), newArt.id.ToString(), ".png");
                img.Save(fileToPrintPath, System.Drawing.Imaging.ImageFormat.Png);
                IsNewReg = false;      // Resetting boolean.
            }

            if (IsEditReg == true)
            {
                // Edit entry in JSON file
                int res = EditArt(newArt.id, newArt);
                if (res == 0)
                {
                    _form.GetGraphics().SetTxtBxWarning("Redigerer en ugyldig ID");
                    return;
                }
                SaveImages(_form.GetOrigImagePaths(), newArt);
                IsEditReg = false;
            }
            _form.GetGraphics().SetTxtBxWarning("Kunst lagret");
            _form.GetGraphics().FillFields(newArt.id);
        }


        public void SaveImages(List<String> fullPaths, Art a)
        {
            int counter = 1;
            foreach(string sourcePath in fullPaths)
            {
                string filename = a.id.ToString() + "_" + counter.ToString() + ".jpg";
                string newPath = System.IO.Path.Combine(_form.GetImagesPath(), filename);
                _form.GetPictureBox().Image = _form.GetPictureBox().InitialImage;     // Setting the displayer image to null if the displayed image is to be overwritten
                if (System.IO.File.Exists(newPath))
                {
                    try
                    {
                        System.IO.File.Delete(newPath);             // Deleting the existing file if it is to be overwritten
                    }
                    catch(Exception e)
                    {
                        
                    }
                }
                try
                {
                    System.IO.File.Copy(sourcePath, newPath, true);
                } catch(Exception e)
                {
                    _form.GetGraphics().SetTxtBxWarning(e.ToString());
                }
                counter += 1;
            }
        }

        public System.Drawing.Image ExportImageToPrint(Art a)
        {
            //first, create a dummy bitmap just to get a graphics object
            System.Drawing.Image img = new System.Drawing.Bitmap(1, 1);
            System.Drawing.Graphics drawing = System.Drawing.Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            System.Drawing.SizeF textSize = drawing.MeasureString(a.ToString(), TextBox.DefaultFont);

            //free up the dummy image and old graphics object
            //img.Dispose();
            //drawing.Dispose();

            //create a new image of the right size
            img = new System.Drawing.Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = System.Drawing.Graphics.FromImage(img);

            //paint the background
            drawing.Clear(System.Drawing.Color.White);

            //create a brush for the text
            System.Drawing.Brush textBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            drawing.DrawString(a.ToString(), TextBox.DefaultFont, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

            
        }



        public Art GetArtFromForm(IArtForm form)
        {
            List<TextBox> txtboxes = form.GetTextBoxes();
            List<ComboBox> comboBoxes = form.GetComboBoxes();

            int id = (int) _form.GetTxtBxId().Value;
            string title = txtboxes.Find(x => x.Name == "txtbxTitle").Text;
            string artform = comboBoxes.Find(x => x.Name == "cmbxArtForm").Text;
            string exhibition = comboBoxes.Find(x => x.Name == "cmbxExhibition").Text;
            string dimensions = comboBoxes.Find(x => x.Name == "cmbxDimensions").Text;
            string year = txtboxes.Find(x => x.Name == "txtbxYear").Text;       // Saving as string makes it possible to save no year as ""
            string comment = txtboxes.Find(x => x.Name == "txtbxComment").Text;
            int numImageFiles = GetNumImageFiles(txtboxes.Find(x => x.Name == "txtbxImages").Text);

            Art a = new Art
            {
                id = id,
                title = title,
                artform = artform,
                exhibition = exhibition,
                dimensions = dimensions,
                year = year,
                comment = comment,
                numImageFiles = numImageFiles
            };
            return a;
        }


        public string RemoveSpaces(string s)
        {
            return new string(s.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        public int GetNumImageFiles(string s)
        {
            if (s == "")
            {
                return 0;
            }
            return s.Split(' ').Length;
        }

        public Art GetArtPostById(int id)
        {
            var arts = _storage.GetFromStorage();
            var res = arts.FirstOrDefault(x => x.id == id);
            if (res == null)
            {
                throw new ArgumentException();
            }
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
