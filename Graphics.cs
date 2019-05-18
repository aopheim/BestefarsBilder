using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestefarsBilder
{
    class Graphics
    {
        private Color _inactiveColor = SystemColors.InactiveCaption;
        private Color _activeColor = SystemColors.Window;
        private Color _warningColor = Color.Red;
        private Color _backgroundColor = SystemColors.Control;
        private Color _activeLinkColor = System.Drawing.Color.PaleGreen;

        private Button _btnSave;
        private List<TextBox> _txtBoxes;
        private TextBox _txtbxId;
        private List<ComboBox> _comboBoxes;
        private ArtForm _form;
        private LinkLabel _lnkAdd, _lnkRead, _lnkEdit;



        public Graphics(IArtForm f)
        {
            _txtBoxes = f.GetTextBoxes();
            _txtbxId = f.GetTxtBxId();
            _btnSave = f.GetButtonSave();
            _comboBoxes = f.GetComboBoxes();
            _lnkAdd = f.GetLinkLabels().Find(x => x.Name == "lnkRegister");
            _lnkRead = f.GetLinkLabels().Find(x => x.Name == "lnkRead");
            _lnkEdit = f.GetLinkLabels().Find(x => x.Name == "lnkEdit");
        }


        // Sets all text and combobox fields to readonly
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

            EnableFields();     // Enabling all fields
            _txtbxId.BackColor = _inactiveColor;
            DisableTextBox(_txtbxId);       // Disabling the id text box
            foreach(TextBox bx in _txtBoxes)
            {
                if (bx.Name == "txtbxId")
                {
                    continue;
                }
                bx.BackColor = _activeColor;
            };
            foreach(ComboBox cbx in _comboBoxes) { cbx.BackColor = _activeColor; };
            _btnSave.Enabled = true;  // Enabling save button
        }
        
    }
}
