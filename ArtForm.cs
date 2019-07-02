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
        private Color _inactiveColor, _activeColor, _warningColor;
        private string _jsonPath, _imagesPath;
        private List<String> _origImagePaths = new List<string>();
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
                txtbxTitle, txtbxYear, txtbxComment, txtbxImages
            };
            _comboBoxes = new List<ComboBox>
            {
                cmbxArtForm, cmbxExhibition, cmbxDimensions
            };
            _jsonPath = @"C:\Users\adrian\Documents\Adrian\Hornsgate\form\BestefarsBilder\BestefarsBilder\lib\kunst.json";
            _imagesPath = @"C:\Users\adrian\Documents\Adrian\Hornsgate\lib\";
            txtbxJsonPath.Text = _jsonPath;
            txtbxImagesFolder.Text = _imagesPath;
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

        public PictureBox GetPictureBox()
        {
            return this.pictureBox;
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

        public NumericUpDown GetTxtBxId()
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
            GetTxtBxId().Text = GetLogic().GetUniqueId().ToString();
        }


    

        private void linkRead_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _graphics.FormStyleRead();

            txtbxId.KeyUp += TxtbxID_KeyUp;     // Binding event. 
            txtbxId.KeyDown += TxtbxID_KeyDown;
        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _graphics.FormStyleEdit();

            txtbxId.KeyUp += TxtbxID_KeyUp;     // Binding event. 
            txtbxId.KeyDown += TxtbxID_KeyDown;
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
        

        public List<String> GetOrigImagePaths()
        {
            return this._origImagePaths;
        }

        public string GetImagesPath()
        {
            return _imagesPath;
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
            if (e.KeyCode == Keys.Enter)
            {
                _graphics.ClearFields();
                if (_logic.IsEditReg)
                {
                    _graphics.FormStyleAdd();
                    _graphics.FillFields(Int32.Parse(txtbxId.Text));
                    return;
                }
                if (_logic.IsReadReg)
                {
                    // Setting text field data if the ID is known.
                    _graphics.FormStyleRead();
                    _graphics.FillFields(Int32.Parse(txtbxId.Text));
                }

            }
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _origImagePaths.Clear();     // Removes all earlier instances.
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\Users\adrian\Documents\Adrian\Hornsgate\origImageLib\",
                Title = "Velg bilder",

                CheckFileExists = true,
                CheckPathExists = true,

                Filter = "jpg files (*.jpg)|*.jpg|All files|*.*",
                Multiselect = true,
                FilterIndex = 1,
                RestoreDirectory = true,

            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach(string s in openFileDialog1.SafeFileNames)  // File names to be visualized
                {
                    string newS = _logic.RemoveSpaces(s);
                    txtbxImages.Text +=  newS + " ";
                }

                foreach(string s in openFileDialog1.FileNames)
                {
                    _origImagePaths.Add(s);
                }
            }
        }

        private void txtbxId_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                Description = "Velg mappe der bildefilene er lagret",
            };

            if (browserDialog.ShowDialog() == DialogResult.OK)
            {
                txtbxImagesFolder.Text = browserDialog.SelectedPath;
                txtbxImagesFolder.ReadOnly = true;
                txtbxImagesFolder.BackColor = _inactiveColor;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
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

        private void txtbxComment_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
