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

        private Graphics _graphics;
        private Logic _logic;



        // Constructor
        public ArtForm()
        {
            InitializeComponent();
            _txtBoxes = new List<TextBox>()
            {
                txtbxId, txtbxTitle, txtbxYear, txtbxComment
            };
            _comboBoxes = new List<ComboBox>
            {
                cmbxArtForm, cmbxExhibition, cmbxDimensions
            };
            _jsonPath = @"C:\Users\adrian\Documents\Adrian\Hornsgate\form\BestefarsBilder\BestefarsBilder\lib\kunst.json";
            txtbxJsonPath.Text = _jsonPath;
            _logic = new Logic(new Storage(_jsonPath), this);
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

        public Graphics GetGraphics()
        {
            return _graphics;
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        public List<LinkLabel> GetLinkLabels()
        {
            return new List<LinkLabel>() { lnkRegister, lnkRead, lnkEdit };
        }

        public Logic GetLogic()
        {
            return this._logic;
        }

        public TextBox GetTxtBxId()
        {
            return txtbxId;
        }

        public TextBox GetTxtBxWarning()
        {
            return txtbxConsole;
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
            _logic.OnSave();
            linkRead_LinkClicked(1, new LinkLabelLinkClickedEventArgs(lnkRead.Links[0]));           // Simulating that the user clicked the read button for resetting styling.
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _logic.IsNewReg = true;
            _logic.IsReadReg = false;
            _logic.IsEditReg = false;
            _graphics.FormStyleAdd();        // Styling the form to registering mode
        }


    

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
            txtbxId.BackColor = _activeColor;
            txtbxTitle.BackColor = _inactiveColor;
            cmbxArtForm.BackColor = _inactiveColor;
            cmbxExhibition.BackColor = _inactiveColor;
            cmbxDimensions.BackColor = _inactiveColor;
            txtbxYear.BackColor = _inactiveColor;
            txtbxComment.BackColor = _inactiveColor;



            btnSave.Enabled = false;        // Unabling the save button if in read mode.
            txtbxId.ReadOnly = false;       // Enabling user to enter ID
            _graphics.DisableFields();        // Disabling all text fields and comboboxes

            if (!IsJsonFile())
            {
                return;
            }

            txtbxId.KeyUp += TxtbxID_KeyUp;     // Binding event. 
            txtbxId.KeyDown += TxtbxID_KeyDown;
        }

        private void FormStyleEdit()
        {
            // Styles the form for editing entries
            FormStyleRead();
            txtbxId.KeyUp += TxtbxID_KeyUp;     // Binding event. 
            txtbxId.KeyDown += TxtbxID_KeyDown;         // Turning off sound when hitting enter.
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
                FormContentRegister(Int32.Parse(txtbxId.Text));
                return;
            }
            if (e.KeyCode == Keys.Enter && _isReadReg)
            {
                // Setting text field data if the ID is known.
                FormContentRegister(Int32.Parse(txtbxId.Text));
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
