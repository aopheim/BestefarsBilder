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
    public partial class ArtForm : Form, IArtForm
    {
        private bool _isNewReg = false;
        private bool _isReadReg = false;
        private bool _isEditReg = false;
        private Color _inactiveColor;
        private Color _activeColor;
        private Color _warningColor;
        private string _jsonPath = "";
        private List<TextBox> _txtBoxes;
        private List<ComboBox> _comboBoxes;
        private Logic _logic;
        private Graphics _graphics;



        // Constructor
        public ArtForm()
        {
            InitializeComponent();
            _txtBoxes = new List<TextBox>()
            {
                txtbxTitle, txtbxYear, txtbxComment
            };
            _comboBoxes = new List<ComboBox>
            {
                cmbxArtForm, cmbxExhibition, cmbxDimensions
            };
            _jsonPath = @"C:\Users\adrian\Documents\Adrian\Hornsgate\form\BestefarsBilder\BestefarsBilder\lib\kunst.json";
            txtbxJsonPath.Text = _jsonPath;
            _logic = new Logic(new Storage(_jsonPath));
            _graphics = new Graphics(this);

            // Defining colors
            _inactiveColor = _graphics.GetInActiveColor();
            _activeColor = _graphics.GetActiveColor();
            _warningColor = _graphics.GetWarningColor();
        }

        public List<TextBox> GetTextBoxes()
        {
            return _txtBoxes;
        }

        public Button GetButtonSave()
        {
            return btnSave;
        }

        public List<ComboBox> GetComboBoxes()
        {
            return _comboBoxes;
        }

        public TextBox GetTxtBxId()
        {
            return txtbxID;
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

            if (this._isNewReg == true) // Registration is to be appended to the JSON file
            {
                _logic.AddArt(newArt);
                this._isNewReg = false;      // Resetting boolean.
                linkRead_LinkClicked(1, new LinkLabelLinkClickedEventArgs(lnkRead.Links[0]));           // Simulating that the user clicked the read button for resetting styling.
                return;
            }

            if (this._isEditReg == true)
            {
                // Edit entry in JSON file
                int res = _logic.EditArt(newArt.id, newArt);
                this._isEditReg = false;
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


            this._isNewReg = true;       // Indicating this is a new registration. Should be appended to json file.
            this._isReadReg = false;
            this._isEditReg = false;
            // Changing background color of link
            lnkRegister.BackColor = System.Drawing.Color.PaleGreen;
            lnkRead.BackColor = SystemColors.Control;
            lnkEdit.BackColor = SystemColors.Control;

            // Setting text on the GroupBox
            groupBox1.Text = "Registrer nytt bilde";
            txtbxID.Text = _logic.GetUniqueId().ToString();
            ClearTextBoxes();
            _graphics.FormStyleAdd();        // Styling the form to registering mode
        }


        // Should return a unique ID that is not present in the JSON file
        /*
        private int GetUniqueID()
        {
            string jsonString = File.ReadAllText(jsonPath);
            List<Art> artworks = JsonConvert.DeserializeObject<List<Art>>(jsonString);
            List<int> ids = artworks.Select(o => o.id).ToList();
            int max = ids.Max();
            return max + 1;
        }
        */

        private void linkRead_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Resetting the other boolean values
            this._isReadReg = true;
            this._isEditReg = false;
            this._isNewReg = false;
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
            this._isEditReg = true;
            this._isNewReg = false;
            this._isReadReg = false;
            // Changing background color of link
            lnkEdit.BackColor = System.Drawing.Color.PaleGreen;
            lnkRead.BackColor = SystemColors.Control;
            lnkRegister.BackColor = SystemColors.Control;

            // Setting text on GroupBox:
            groupBox1.Text = "Rediger oppføring";
            FormStyleEdit();
        }


        private bool IsJsonFile()
        {
            if (txtbxJsonPath.Text.Length < 1)
            {
                txtbxConsole.Text = "Du må velge en biblioteksfil.";
                txtbxConsole.ForeColor = _warningColor;
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
            txtbxID.BackColor = _activeColor;
            txtbxTitle.BackColor = _inactiveColor;
            cmbxArtForm.BackColor = _inactiveColor;
            cmbxExhibition.BackColor = _inactiveColor;
            cmbxDimensions.BackColor = _inactiveColor;
            txtbxYear.BackColor = _inactiveColor;
            txtbxComment.BackColor = _inactiveColor;



            btnSave.Enabled = false;        // Unabling the save button if in read mode.
            txtbxID.ReadOnly = false;       // Enabling user to enter ID
            _graphics.DisableFields();        // Disabling all text fields and comboboxes

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
            if (e.KeyCode == Keys.Enter && _isEditReg)
            {
                _graphics.FormStyleAdd();
                FormContentRegister(Int32.Parse(txtbxID.Text));
                return;
            }
            if (e.KeyCode == Keys.Enter && _isReadReg)
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
                _jsonPath = openFileDialog1.FileName;
                txtbxJsonPath.ReadOnly = true;
                txtbxJsonPath.BackColor = _inactiveColor;
            }
        }
    }
}
