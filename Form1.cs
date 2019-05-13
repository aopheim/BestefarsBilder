using Newtonsoft.Json;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestefarsBilder
{
    public partial class Form1 : Form
    {
        private bool isNewReg = false;
        private bool isReadReg = false;
        private bool isEditReg = false;
        private Color inactiveColor = SystemColors.InactiveCaption;
        private Color activeColor = SystemColors.Window;
        private Color warningColor = Color.Red;
        private string jsonPath = "";
        private List<TextBox> txtBoxes;
        private List<ComboBox> comboBoxes;
        private Logic _logic;



        // Constructor
        public Form1()
        {
            InitializeComponent();
            txtBoxes = new List<TextBox>()
            {
                txtbxTitle, txtbxYear, txtbxComment
            };
            comboBoxes = new List<ComboBox>
            {
                cmbxArtForm, cmbxExhibition, cmbxDimensions
            };
            jsonPath = @"C:\Users\adrian\Documents\Adrian\Hornsgate\lib\kunst.json";
            txtbxJsonPath.Text = jsonPath;
            _logic = new Logic(new Storage(jsonPath));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        // Sets all text and combobox fields to readonly
        private void DisableFields()
        {
            foreach (TextBox txt in txtBoxes)
            {
                txt.ReadOnly = true;
            }

            foreach (ComboBox cmb in comboBoxes)
            {
                cmb.Enabled = false;
            }

        }

        private void EnableTextFields()
        {
            foreach (TextBox txt in txtBoxes)
            {
                txt.ReadOnly = false;
            }

            foreach (ComboBox cmb in comboBoxes)
            {
                cmb.Enabled = true;
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsJsonFile())
            {
                return;
            }
            // Collecting user data
            int id = Int32.Parse(txtbxID.Text);
            string title = txtbxTitle.Text;
            string artform = cmbxArtForm.Text;
            string exhibition = cmbxExhibition.Text;
            string dimensions = cmbxDimensions.Text;
            string year = txtbxYear.Text;       // Saving as string makes it possible to save no year as ""
            string comment = txtbxComment.Text;

            // Creating art object.
            Art newArt = new Art
            {
                id = id,
                title = title,
                artform = artform,
                exhibition = exhibition,
                dimensions = dimensions,
                year = year,
                comment = comment,
            };

            if (this.isNewReg == true) // Registration is to be appended to the JSON file
            {
                _logic.AddArt(newArt);
                this.isNewReg = false;      // Resetting boolean.
                linkRead_LinkClicked(1, new LinkLabelLinkClickedEventArgs(lnkRead.Links[0]));           // Simulating that the user clicked the read button for resetting styling.
                return;
            }

            if (this.isEditReg == true)
            {
                // Edit entry in JSON file
                _logic.EditArt(newArt.id, newArt);
                this.isEditReg = false;
                return;
            }



            // Generating QR code
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string qrString = "" +
                "Katalognr.: " + id.ToString() + ", " +
                "Tittel: " + title + ", " +
                "Kunstform: " + artform + ", " +
                "Utstilling: " + exhibition + ", " +
                "Dimensjoner: " + dimensions + ", " +
                "År: " + year + ", " +
                "Kommentar: " + comment;


            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save(@"C:\Users\adrian\Documents\Adrian\Hornsgate\lib\" + id.ToString() + ".bmp");

            // Make fields non-editable 

            txtbxConsole.Text = "Kunst lagret";
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


            this.isNewReg = true;       // Indicating this is a new registration. Should be appended to json file.
            this.isReadReg = false;
            this.isEditReg = false;
            // Changing background color of link
            lnkRegister.BackColor = System.Drawing.Color.PaleGreen;
            lnkRead.BackColor = SystemColors.Control;
            lnkEdit.BackColor = SystemColors.Control;

            // Setting text on the GroupBox
            groupBox1.Text = "Registrer nytt bilde";
            txtbxID.Text = GetUniqueID().ToString();
            ClearTextBoxes();
            FormStyleRegister();        // Styling the form to registering mode
        }


        // Should return a unique ID that is not present in the JSON file
        private int GetUniqueID()
        {
            string jsonString = File.ReadAllText(jsonPath);
            List<Art> artworks = JsonConvert.DeserializeObject<List<Art>>(jsonString);
            List<int> ids = artworks.Select(o => o.id).ToList();
            int max = ids.Max();
            return max + 1;
        }

        private void linkRead_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Resetting the other boolean values
            this.isReadReg = true;
            this.isEditReg = false;
            this.isNewReg = false;
            // Changing background color of link
            lnkRead.BackColor = System.Drawing.Color.PaleGreen;
            lnkRegister.BackColor = SystemColors.Control;
            lnkEdit.BackColor = SystemColors.Control;

            // Setting text on GroupBox
            groupBox1.Text = "Se oppføring";
            FormStyleRead();
        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.isEditReg = true;
            this.isNewReg = false;
            this.isReadReg = false;
            // Changing background color of link
            lnkEdit.BackColor = System.Drawing.Color.PaleGreen;
            lnkRead.BackColor = SystemColors.Control;
            lnkRegister.BackColor = SystemColors.Control;

            // Setting text on GroupBox:
            groupBox1.Text = "Rediger oppføring";
            FormStyleEdit();
        }

        // Styles the form for acctepting new registrations.
        private void FormStyleRegister()
        {
            // Setting colors
            txtbxID.BackColor = inactiveColor;
            txtbxTitle.BackColor = activeColor;
            cmbxArtForm.BackColor = activeColor;
            cmbxExhibition.BackColor = activeColor;
            cmbxDimensions.BackColor = activeColor;
            txtbxYear.BackColor = activeColor;
            txtbxComment.BackColor = activeColor;


            btnSave.Enabled = true;  // Enabling save button
            txtbxID.ReadOnly = true;  // Disabling ID field
            EnableTextFields();     // Enabling the other fields
            if (!IsJsonFile())
            {
                return;
            }




        }

        private bool IsJsonFile()
        {
            if (txtbxJsonPath.Text.Length < 1)
            {
                txtbxConsole.Text = "Du må velge en biblioteksfil.";
                txtbxConsole.ForeColor = warningColor;
                return false;
            }
            else
            {
                return true;
            }
        }


        // Filling in text boxes in form with data from the JSON file. 
        // If id is not in JSON file, set all fields empty.
        // id: ID to edit. 
        private void FormContentRegister(int id)
        {
            var art = _logic.GetArtPostById(id);
            if (art == null)
                ClearTextBoxes();
            else
                FillTextBoxes(art);
        }

        // Setting all text boxes to content of foundItem
        private void FillTextBoxes(Art foundItem)
        {
            txtbxTitle.Text = foundItem.title;
            cmbxArtForm.Text = foundItem.artform;
            cmbxExhibition.Text = foundItem.exhibition;
            cmbxDimensions.Text = foundItem.dimensions;
            txtbxYear.Text = foundItem.year;
            txtbxComment.Text = foundItem.comment;
        }

        // Setting all text boxes to ""
        private void ClearTextBoxes()
        {
            txtbxTitle.Text = "";
            cmbxArtForm.Text = "";
            cmbxExhibition.Text = "";
            cmbxDimensions.Text = "";
            txtbxYear.Text = "";
            txtbxComment.Text = "";
        }

        // Styles the form for reading registrations.
        private void FormStyleRead()
        {
            // Setting colors
            txtbxID.BackColor = activeColor;
            txtbxTitle.BackColor = inactiveColor;
            cmbxArtForm.BackColor = inactiveColor;
            cmbxExhibition.BackColor = inactiveColor;
            cmbxDimensions.BackColor = inactiveColor;
            txtbxYear.BackColor = inactiveColor;
            txtbxComment.BackColor = inactiveColor;



            btnSave.Enabled = false;        // Unabling the save button if in read mode.
            txtbxID.ReadOnly = false;       // Enabling user to enter ID
            DisableFields();        // Disabling all text fields and comboboxes

            if (!IsJsonFile())
            {
                return;
            }

            txtbxID.KeyUp += TxtbxID_KeyUp;     // Binding event. 
            txtbxID.KeyDown += TxtbxID_KeyDown;
        }

        private void FormStyleEdit()
        {
            // Styles the form for editing entries
            FormStyleRead();
            txtbxID.KeyUp += TxtbxID_KeyUp;     // Binding event. 
            txtbxID.KeyDown += TxtbxID_KeyDown;         // Turning off sound when hitting enter.
        }


        // Turning of the sound when pressing enter
        private void TxtbxID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }


        // Changes style of the form to "registering" if enter key is pressed.
        private void TxtbxID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && isEditReg)
            {
                FormStyleRegister();
                FormContentRegister(Int32.Parse(txtbxID.Text));
                return;
            }
            if (e.KeyCode == Keys.Enter && isReadReg)
            {
                // Setting text field data if the ID is known.
                FormContentRegister(Int32.Parse(txtbxID.Text));
            }
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Velg biblioteksfil",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "json",
                Filter = "json files (*.json)|*.json|All files|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,

            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtbxJsonPath.Text = openFileDialog1.FileName;
                this.jsonPath = openFileDialog1.FileName;
                txtbxJsonPath.ReadOnly = true;
                txtbxJsonPath.BackColor = inactiveColor;
            }
        }
    }
}
