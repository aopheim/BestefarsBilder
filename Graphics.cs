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
        private TextBox _txtbxId, _txtbxWarning;
        private GroupBox _groupBox;
        private List<ComboBox> _comboBoxes;
        private IArtForm _form;
        private LinkLabel _lnkAdd, _lnkRead, _lnkEdit;

        // private Logic _logic;

        public Graphics(IArtForm f)
        {
            _txtBoxes = f.GetTextBoxes();
            _groupBox = f.GetGroupBox();
            _txtbxId = f.GetTxtBxId();
            _txtbxWarning = f.GetTxtBxWarning();
            _btnSave = f.GetButtonSave();
            _comboBoxes = f.GetComboBoxes();
            _lnkAdd = f.GetLinkLabels().Find(x => x.Name == "lnkRegister");
            _lnkRead = f.GetLinkLabels().Find(x => x.Name == "lnkRead");
            _lnkEdit = f.GetLinkLabels().Find(x => x.Name == "lnkEdit");
            _form = f;
        }


        public void SetWarningText(string t)
        {
            _txtbxWarning.Text = t;
        }

        public void SetGroupBoxText(string t)
        {
            _groupBox.Text = t;
        }


        public void ClearText()
        {
            foreach(TextBox tbx in _txtBoxes)
            {
                tbx.Text = "";
            }
            foreach(ComboBox cbx in _comboBoxes)
            {
                cbx.Text = "";
            }
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

        public void DisableTextBox(TextBox t)
        {
            t.ReadOnly = true;
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
            ClearText();
            EnableFields();     
            _txtbxId.Text = _form.GetLogic().GetUniqueId().ToString();
            DisableTextBox(_txtbxId);       // Disabling the id text box
            foreach(TextBox bx in _txtBoxes)
            {
                if (bx.Name == "txtbxId")
                {
                    bx.BackColor = _inactiveColor;
                    continue;
                }
                bx.BackColor = _activeColor;
            };
            foreach(ComboBox cbx in _comboBoxes) { cbx.BackColor = _activeColor; };
            _btnSave.Enabled = true;  // Enabling save button
        }
        
    }
}
