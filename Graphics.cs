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
        private Color inactiveColor = SystemColors.InactiveCaption;
        private Color activeColor = SystemColors.Window;
        private Color warningColor = Color.Red;
        private List<TextBox> txtBoxes;
        private List<ComboBox> comboBoxes;
        private ArtForm _form;


        public Graphics(IArtForm f)
        {
            txtBoxes = f.GetTextBoxes();
            comboBoxes = f.GetComboBoxes();
        }


        // Sets all text and combobox fields to readonly
        public void DisableFields()
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

        public void EnableFields()
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
    }
}
