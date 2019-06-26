using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestefarsBilder
{
    public class Graphics
    {
        private Color _inactiveColor = SystemColors.InactiveCaption;
        private Color _activeColor = SystemColors.Window;
        private Color _warningColor = Color.Red;
        private Color _backgroundColor = SystemColors.Control;
        private Color _activeLinkColor = System.Drawing.Color.PaleGreen;

        private Button _btnSave;
        private List<TextBox> _txtBoxes;
        private TextBox _txtbxWarning;
        private NumericUpDown _txtbxId;
        private GroupBox _groupBox;
        private List<ComboBox> _comboBoxes;
        private IArtForm _form;
        private LinkLabel _lnkAdd, _lnkRead, _lnkEdit;
        private PictureBox _pictureBox;

        // private Logic _logic;

        public Graphics(IArtForm f)
        {
            _txtBoxes = f.GetTextBoxes();
            _groupBox = f.GetGroupBox();
            _txtbxId = f.GetTxtBxId();
            _txtbxWarning = f.GetTxtBxWarning();
            _btnSave = f.GetButtonSave();
            _comboBoxes = f.GetComboBoxes();
            _pictureBox = f.GetPictureBox();
            _lnkAdd = f.GetLinkLabels().Find(x => x.Name == "lnkRegister");
            _lnkRead = f.GetLinkLabels().Find(x => x.Name == "lnkRead");
            _lnkEdit = f.GetLinkLabels().Find(x => x.Name == "lnkEdit");
            _form = f;
        }
        

        public void SetGroupBoxText(string t)
        {
            _groupBox.Text = t;
        }


        public void ClearFields()
        {
            foreach(TextBox tbx in _txtBoxes)
            {
                tbx.Text = "";
            }
            foreach(ComboBox cbx in _comboBoxes)
            {
                cbx.Text = "";
            }
            SetTxtBxWarning("");
            _pictureBox.Image = null;
        }
        
        public void DisableFields()
        {
            foreach (TextBox txt in _txtBoxes)
            {
                txt.ReadOnly = true;
            }

            foreach (ComboBox cmb in _comboBoxes)
            {
                cmb.Enabled = false;
            }

        }

        public void DisableTextBox(NumericUpDown t)
        {
            t.ReadOnly = true;
            t.Increment = 0;
        }

        public void EnableTextBox(TextBox txtbx)
        {
            txtbx.ReadOnly = false;
        }
        
        public void EnableFields()
        {
            foreach (TextBox txt in _txtBoxes)
            {
                txt.ReadOnly = false;
            }

            foreach (ComboBox cmb in _comboBoxes)
            {
                cmb.Enabled = true;
            };
        }

        public Color GetInActiveColor()
        {
            return _inactiveColor;
        }

        public Color GetActiveColor()
        {
            return _activeColor;
        }

        public Color GetWarningColor()
        {
            return _warningColor;
        }


        /// <summary>
        /// Styling form for adding new registration.
        /// </summary>
        public void FormStyleAdd()
        {
            // Changing background color of link
            _lnkAdd.BackColor = _activeLinkColor;
            _lnkRead.BackColor = _backgroundColor;
            _lnkEdit.BackColor = _backgroundColor;

            SetGroupBoxText("Registrer nytt bilde");
            ClearFields();
            EnableFields();     
            DisableTextBox(_txtbxId);       // Disabling the id text box
            foreach(TextBox bx in _txtBoxes) { bx.BackColor = _activeColor;  };
            foreach(ComboBox cbx in _comboBoxes) { cbx.BackColor = _activeColor; };
            //_txtbxId.BackColor = _inactiveColor;
            _btnSave.Enabled = true;  // Enabling save button
        }

        public void FormStyleRead()
        {
            _form.GetLogic().IsReadReg = true;
            _form.GetLogic().IsEditReg = false;
            _form.GetLogic().IsNewReg = false;

            _lnkRead.BackColor = _activeLinkColor;
            _lnkAdd.BackColor = _backgroundColor;
            _lnkEdit.BackColor = _backgroundColor;
            _groupBox.Text = "Se oppføring";
            _txtbxId.ReadOnly = false;
            _txtbxId.Increment = 1;
            foreach(TextBox tbx in _txtBoxes)
            {
                tbx.BackColor = _inactiveColor;
                tbx.ReadOnly = true;
            }
            foreach (ComboBox cbx in _comboBoxes)
            {
                cbx.BackColor = _inactiveColor;
                cbx.Enabled = false;
            }
            _btnSave.Enabled = false;
            

        }


        /// <summary>
        /// Styles the form for editing entries
        /// </summary>
        public void FormStyleEdit()
        {
            this.FormStyleRead();           // Almost same design as for reading entries - using FormStyleRead
                                            // and changing you the single parameters different. 
            _form.GetLogic().IsReadReg = false;
            _form.GetLogic().IsEditReg = true;
            _form.GetLogic().IsNewReg = false;

            _lnkEdit.BackColor = _activeLinkColor;
            _lnkAdd.BackColor = _backgroundColor;
            _lnkRead.BackColor = _backgroundColor;

            _groupBox.Text = "Rediger oppføring";
        }




        /// <summary>
        /// Fill all text boxes and combo boxes with id
        /// </summary>
        /// <param name="id">Id of the Art object to fill fields with</param>
        public void FillFields(int id)
        {
            Art a;
            try
            {
                a = _form.GetLogic().GetArtPostById(id);
            }
            catch(ArgumentException e)
            {
                SetTxtBxWarning("Ingen oppføring med id " + id.ToString() + " funnet");
                ClearFields();
                return;
            }
            
            _form.GetTxtBxId().Value = a.id;

            _txtBoxes.Find(x => x.Name == "txtbxTitle").Text = a.title;
            _txtBoxes.Find(x => x.Name == "txtbxYear").Text = a.year;
            _txtBoxes.Find(x => x.Name == "txtbxComment").Text = a.comment;

            _comboBoxes.Find(x => x.Name == "cmbxArtForm").Text = a.artform;
            _comboBoxes.Find(x => x.Name == "cmbxExhibition").Text = a.exhibition;
            _comboBoxes.Find(x => x.Name == "cmbxDimensions").Text = a.dimensions;

            if (a.numImageFiles > 0)
            {
                try
                {
                _pictureBox.Image = Image.FromFile(_form.GetImagesPath() + a.id.ToString() + "_" + "1" + ".jpg");
                } catch( Exception e)
                {
                    _pictureBox.Image = _pictureBox.InitialImage;
                }
            }

        }


        public DialogResult ShowWarningBox(Art a)
        {
            DialogResult result = MessageBox.Show(
                "Vil du lagre katalognummer " + a.id.ToString() + " uten bildefiler?",
                "Lagre oppføring uten bilder?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );
            return result;
        }

        public void SetTxtBxWarning(string s)
        {
            _txtbxWarning.Text = s;
        }

    }

}
