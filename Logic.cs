using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;



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
                ExportImageToPrint(newArt);
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
                        Console.WriteLine(e);
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

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width)
        {
            double ratio = (double) width / image.Width;
            
            int height = (int) (image.Height * ratio);
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = System.Drawing.Graphics.FromImage(destImage))
            {
                /*
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                */
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public void ExportImageToPrint(Art a)
        {
            //Load the Image to be written on.
            string imgPath = System.IO.Path.Combine(_form.GetImagesPath(), a.id.ToString() + "_1" + ".jpg");
            Image img = Image.FromFile(imgPath);

            Font arialFont = new Font("Arial", 10);
            Bitmap bitmap = ResizeImage(img, 300); // Resizing to save disk space


            // Determining needed size for the text
            Bitmap measureBmp = new Bitmap(1, 1);
            System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(measureBmp);
            using (var measureGraphics = System.Drawing.Graphics.FromImage(measureBmp))
            {
                var stringSize = measureGraphics.MeasureString(a.ToString(), arialFont);
                graphics = AddWhiteSpaceToImage(bitmap, img, stringSize);
            }

            PointF location = new PointF(0, bitmap.Height);
            using (graphics)
            {   
                graphics.DrawString(a.ToString(), arialFont, Brushes.Black, location);   
            }
            graphics.to
            imgPath = System.IO.Path.Combine(_form.GetImagesPath(), a.id.ToString() + "_1");
            bitmap.Save(imgPath + ".bmp", ImageFormat.Bmp );             //save the image file
        }


        public System.Drawing.Graphics AddWhiteSpaceToImage(Bitmap bmpSrc, Image imgSrc, SizeF stringSize)
        {
            System.Drawing.Graphics whiteBmp = System.Drawing.Graphics.FromImage(bmpSrc);
            Size size = stringSize.ToSize();
            whiteBmp.FillRectangle(Brushes.White, 0, size.Height, bmpSrc.Width, size.Height);
            
            return whiteBmp;
            //whiteImage.DrawImageUnscaled(imgSrc, 0, 0, 240, 320);
            //whiteImage.DrawImageUnscaled(0)
            //whiteImage.Save("file.jpg", ImageFormat.Jpeg);
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
