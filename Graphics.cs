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
        private Button _btnSave;
        private List<TextBox> _txtBoxes;
        private TextBox _txtbxId;
        private List<ComboBox> _comboBoxes;
        private ArtForm _form;


        public Graphics(IArtForm f)
        {
            _txtBoxes = f.GetTextBoxes();
            _txtbxId = f.GetTxtBxId();
            _btnSave = f.GetButtonSave();
            _comboBoxes = f.GetComboBoxes();
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
        /// Styling form for adding new registration
        /// </summary>
        public void FormStyleAdd()
        {
            _txtbxId.BackColor = _inactiveColor;
            _txtbxId.ReadOnly = true;  // Disabling ID field
            foreach(TextBox bx in _txtBoxes) { bx.BackColor = _activeColor; };
            foreach(ComboBox cbx in _comboBoxes) { cbx.BackColor = _activeColor; };
            EnableFields();
            _btnSave.Enabled = true;  // Enabling save button
        }
        
    }
}
