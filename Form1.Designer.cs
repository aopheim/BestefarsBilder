namespace BestefarsBilder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.strTitle = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblForm = new System.Windows.Forms.Label();
            this.cmbxArtForm = new System.Windows.Forms.ComboBox();
            this.cmbxExhibition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxDimensions = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbxComment = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtbxComment);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbxDimensions);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbxExhibition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbxArtForm);
            this.groupBox1.Controls.Add(this.lblForm);
            this.groupBox1.Controls.Add(this.strTitle);
            this.groupBox1.Controls.Add(this.id);
            this.groupBox1.Controls.Add(this.lblTitle);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Location = new System.Drawing.Point(33, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 469);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Registrer nytt bilde";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(19, 31);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(121, 20);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "Katalognummer";
            this.lblID.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(19, 72);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(43, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Tittel";
            this.lblTitle.Click += new System.EventHandler(this.label3_Click);
            // 
            // id
            // 
            this.id.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.id.Cursor = System.Windows.Forms.Cursors.Default;
            this.id.Location = new System.Drawing.Point(171, 30);
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Size = new System.Drawing.Size(208, 26);
            this.id.TabIndex = 2;
            this.id.TabStop = false;
            this.id.WordWrap = false;
            this.id.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // strTitle
            // 
            this.strTitle.Location = new System.Drawing.Point(171, 77);
            this.strTitle.Name = "strTitle";
            this.strTitle.Size = new System.Drawing.Size(208, 26);
            this.strTitle.TabIndex = 3;
            this.strTitle.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(459, 571);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 32);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lagre";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Location = new System.Drawing.Point(19, 118);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(82, 20);
            this.lblForm.TabIndex = 4;
            this.lblForm.Text = "Kunstform";
            // 
            // cmbxArtForm
            // 
            this.cmbxArtForm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbxArtForm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxArtForm.FormattingEnabled = true;
            this.cmbxArtForm.Items.AddRange(new object[] {
            "Collage",
            "Skulptur",
            "Håndtegning",
            "Portrett"});
            this.cmbxArtForm.Location = new System.Drawing.Point(171, 124);
            this.cmbxArtForm.Name = "cmbxArtForm";
            this.cmbxArtForm.Size = new System.Drawing.Size(208, 28);
            this.cmbxArtForm.TabIndex = 5;
            this.cmbxArtForm.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cmbxExhibition
            // 
            this.cmbxExhibition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbxExhibition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxExhibition.FormattingEnabled = true;
            this.cmbxExhibition.Items.AddRange(new object[] {
            "Utstilling 1",
            "Utstilling 2"});
            this.cmbxExhibition.Location = new System.Drawing.Point(171, 173);
            this.cmbxExhibition.Name = "cmbxExhibition";
            this.cmbxExhibition.Size = new System.Drawing.Size(208, 28);
            this.cmbxExhibition.TabIndex = 7;
            this.cmbxExhibition.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Utstilling";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // cmbxDimensions
            // 
            this.cmbxDimensions.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbxDimensions.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxDimensions.FormattingEnabled = true;
            this.cmbxDimensions.Items.AddRange(new object[] {
            "30x30",
            "50x50"});
            this.cmbxDimensions.Location = new System.Drawing.Point(171, 222);
            this.cmbxDimensions.Name = "cmbxDimensions";
            this.cmbxDimensions.Size = new System.Drawing.Size(208, 28);
            this.cmbxDimensions.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dimensjoner";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 271);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(208, 26);
            this.textBox1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Årstall";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 322);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Kommentar";
            // 
            // txtbxComment
            // 
            this.txtbxComment.Location = new System.Drawing.Point(171, 318);
            this.txtbxComment.Multiline = true;
            this.txtbxComment.Name = "txtbxComment";
            this.txtbxComment.Size = new System.Drawing.Size(287, 130);
            this.txtbxComment.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 649);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox strTitle;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.ComboBox cmbxArtForm;
        private System.Windows.Forms.ComboBox cmbxExhibition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxDimensions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbxComment;
        private System.Windows.Forms.Label label4;
    }
}

