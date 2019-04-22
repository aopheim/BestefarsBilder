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
            int id = Int32.Parse(intID.Text);
            string title = strTitle.Text;
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
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkRead_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lnkEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
