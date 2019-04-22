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
        private Color inactiveColor = SystemColors.InactiveCaption;
        private Color activeColor = SystemColors.Window;

        public Form1()
        {
            InitializeComponent();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
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
            int id = Int32.Parse(txtbxID.Text);
            string title = txtbxTitle.Text;
            string artForm = cmbxArtForm.Text;
            string exhibition = cmbxExhibition.Text;
            string dimensions = cmbxDimensions.Text;
            String year = txtbxYear.Text;       // Saving as string makes it possible to save no year as ""
            string comment = txtbxComment.Text;

            // Generating JSON file
            Art art = new Art(id, title, artForm, exhibition, dimensions, year, comment);
            File.WriteAllText(@"C:\Users\adrian\Documents\Adrian\Hornsgate\lib\kunst.json", JsonConvert.SerializeObject(art, Formatting.Indented));

            // Generating QR code
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            string qrString = "" +
                "Katalognr.: " + id.ToString() + ", " +
                "Tittel: " + title + ", " +
                "Kunstform: " + artForm + ", " +
                "Utstilling: " + exhibition + ", " +
                "Dimensjoner: " + dimensions + ", " +
                "År: " + year + ", " +
                "Kommentar: " + comment;

                
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            qrCodeImage.Save(@"C:\Users\adrian\Documents\Adrian\Hornsgate\lib\" + id.ToString() + ".bmp");

            // Make fields non-editable 
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Changing background color of link
            lnkRegister.BackColor = System.Drawing.Color.PaleGreen;
            lnkRead.BackColor = SystemColors.Control;
            lnkEdit.BackColor = SystemColors.Control;

            FormStyleRegister();
        }

        private void linkRead_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Changing background color of link
            lnkRead.BackColor = System.Drawing.Color.PaleGreen;
            lnkRegister.BackColor = SystemColors.Control;
            lnkEdit.BackColor = SystemColors.Control;

            FormStyleRead();
        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Changing background color of link
            lnkEdit.BackColor = System.Drawing.Color.PaleGreen;
            lnkRead.BackColor = SystemColors.Control;
            lnkRegister.BackColor = SystemColors.Control;

            FormStyleEdit();
        }
        private void FormStyleRegister()
        {
            // Styles the form for acctepting new registrations.
            txtbxID.BackColor = inactiveColor;
            txtbxTitle.BackColor = activeColor;
            cmbxArtForm.BackColor = activeColor;
            cmbxExhibition.BackColor = activeColor;
            cmbxDimensions.BackColor = activeColor;
            txtbxYear.BackColor = activeColor;
            txtbxComment.BackColor = activeColor;
        }

        private void FormStyleRead()
        {
            // Styles the form for reading registrations.
            txtbxID.BackColor = activeColor;
            txtbxTitle.BackColor = inactiveColor;
            cmbxArtForm.BackColor = inactiveColor;
            cmbxExhibition.BackColor = inactiveColor;
            cmbxDimensions.BackColor = inactiveColor;
            txtbxYear.BackColor = inactiveColor;
            txtbxComment.BackColor = inactiveColor;
        }

        private void FormStyleEdit()
        {
            // Styles the form for editing entries
            FormStyleRead();
            txtbxID.KeyUp += TxtbxID_KeyUp;     // Binding event. 
        }

        // Changes style of the form to "registering" if enter key is pressed.
        private void TxtbxID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormStyleRegister();
            }
        }
    }
}
