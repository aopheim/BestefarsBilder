namespace BestefarsBilder
{
    partial class ArtForm
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbxShelf = new System.Windows.Forms.ComboBox();
            this.storageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.cmbxRoom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelectImages = new System.Windows.Forms.Button();
            this.txtbxImages = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbxId = new System.Windows.Forms.NumericUpDown();
            this.txtbxTags = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbxComment = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbxYear = new System.Windows.Forms.TextBox();
            this.txtbxConsole = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbxDimensions = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbxExhibition = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbxArtForm = new System.Windows.Forms.ComboBox();
            this.lblForm = new System.Windows.Forms.Label();
            this.txtbxTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lnkRegister = new System.Windows.Forms.LinkLabel();
            this.lnkEdit = new System.Windows.Forms.LinkLabel();
            this.lnkRead = new System.Windows.Forms.LinkLabel();
            this.txtbxJsonPath = new System.Windows.Forms.TextBox();
            this.btnBrowseArtFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtbxImagesFolder = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.artFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.storageBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.storageBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.btnPersistFilePaths = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbxId)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.artFormBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbxShelf);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cmbxRoom);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnSelectImages);
            this.groupBox1.Controls.Add(this.txtbxImages);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtbxId);
            this.groupBox1.Controls.Add(this.txtbxTags);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtbxComment);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbxYear);
            this.groupBox1.Controls.Add(this.txtbxConsole);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.cmbxDimensions);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbxExhibition);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbxArtForm);
            this.groupBox1.Controls.Add(this.lblForm);
            this.groupBox1.Controls.Add(this.txtbxTitle);
            this.groupBox1.Controls.Add(this.lblTitle);
            this.groupBox1.Controls.Add(this.lblID);
            this.groupBox1.Location = new System.Drawing.Point(33, 255);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 570);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cmbxShelf
            // 
            this.cmbxShelf.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbxShelf.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxShelf.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbxShelf.DataSource = this.storageBindingSource;
            this.cmbxShelf.FormattingEnabled = true;
            this.cmbxShelf.Location = new System.Drawing.Point(310, 365);
            this.cmbxShelf.Name = "cmbxShelf";
            this.cmbxShelf.Size = new System.Drawing.Size(208, 28);
            this.cmbxShelf.TabIndex = 10;
            // 
            // storageBindingSource
            // 
            this.storageBindingSource.DataSource = typeof(BestefarsBilder.Storage);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(397, 419);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "tag1, tag2, tag3";
            // 
            // cmbxRoom
            // 
            this.cmbxRoom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbxRoom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxRoom.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbxRoom.FormattingEnabled = true;
            this.cmbxRoom.Items.AddRange(new object[] {
            "Hovedrom",
            "Mot bakgård",
            "Mot Hornsgate",
            "Skulpturrommet"});
            this.cmbxRoom.Location = new System.Drawing.Point(171, 365);
            this.cmbxRoom.Name = "cmbxRoom";
            this.cmbxRoom.Size = new System.Drawing.Size(119, 28);
            this.cmbxRoom.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 368);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Plassering";
            // 
            // btnSelectImages
            // 
            this.btnSelectImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectImages.Location = new System.Drawing.Point(401, 469);
            this.btnSelectImages.Name = "btnSelectImages";
            this.btnSelectImages.Size = new System.Drawing.Size(123, 26);
            this.btnSelectImages.TabIndex = 13;
            this.btnSelectImages.Text = "Bla gjennom...";
            this.btnSelectImages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectImages.UseVisualStyleBackColor = true;
            this.btnSelectImages.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtbxImages
            // 
            this.txtbxImages.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtbxImages.Location = new System.Drawing.Point(171, 469);
            this.txtbxImages.Name = "txtbxImages";
            this.txtbxImages.Size = new System.Drawing.Size(208, 26);
            this.txtbxImages.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Bildefiler";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtbxId
            // 
            this.txtbxId.Location = new System.Drawing.Point(171, 31);
            this.txtbxId.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.txtbxId.Name = "txtbxId";
            this.txtbxId.Size = new System.Drawing.Size(208, 26);
            this.txtbxId.TabIndex = 14;
            this.txtbxId.ValueChanged += new System.EventHandler(this.txtbxId_ValueChanged);
            // 
            // txtbxTags
            // 
            this.txtbxTags.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtbxTags.Location = new System.Drawing.Point(171, 404);
            this.txtbxTags.Multiline = true;
            this.txtbxTags.Name = "txtbxTags";
            this.txtbxTags.Size = new System.Drawing.Size(208, 56);
            this.txtbxTags.TabIndex = 11;
            this.txtbxTags.TextChanged += new System.EventHandler(this.txtbxComment_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 407);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tags ";
            // 
            // txtbxComment
            // 
            this.txtbxComment.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtbxComment.Location = new System.Drawing.Point(171, 268);
            this.txtbxComment.Multiline = true;
            this.txtbxComment.Name = "txtbxComment";
            this.txtbxComment.Size = new System.Drawing.Size(208, 84);
            this.txtbxComment.TabIndex = 8;
            this.txtbxComment.TextChanged += new System.EventHandler(this.txtbxComment_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 271);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Kommentar";
            // 
            // txtbxYear
            // 
            this.txtbxYear.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtbxYear.Location = new System.Drawing.Point(171, 227);
            this.txtbxYear.Name = "txtbxYear";
            this.txtbxYear.Size = new System.Drawing.Size(208, 26);
            this.txtbxYear.TabIndex = 7;
            // 
            // txtbxConsole
            // 
            this.txtbxConsole.BackColor = System.Drawing.SystemColors.Control;
            this.txtbxConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbxConsole.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtbxConsole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbxConsole.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtbxConsole.Location = new System.Drawing.Point(171, 617);
            this.txtbxConsole.Multiline = true;
            this.txtbxConsole.Name = "txtbxConsole";
            this.txtbxConsole.ReadOnly = true;
            this.txtbxConsole.Size = new System.Drawing.Size(208, 32);
            this.txtbxConsole.TabIndex = 3;
            this.txtbxConsole.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Årstall";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(433, 504);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(91, 32);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Lagre";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbxDimensions
            // 
            this.cmbxDimensions.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbxDimensions.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxDimensions.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbxDimensions.FormattingEnabled = true;
            this.cmbxDimensions.Items.AddRange(new object[] {
            "30x30",
            "50x50",
            "42x52",
            "42x62",
            "25x25"});
            this.cmbxDimensions.Location = new System.Drawing.Point(171, 184);
            this.cmbxDimensions.Name = "cmbxDimensions";
            this.cmbxDimensions.Size = new System.Drawing.Size(208, 28);
            this.cmbxDimensions.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Dimensjoner";
            // 
            // cmbxExhibition
            // 
            this.cmbxExhibition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbxExhibition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxExhibition.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbxExhibition.FormattingEnabled = true;
            this.cmbxExhibition.Items.AddRange(new object[] {
            "Utstilling 1",
            "Utstilling 2"});
            this.cmbxExhibition.Location = new System.Drawing.Point(171, 142);
            this.cmbxExhibition.Name = "cmbxExhibition";
            this.cmbxExhibition.Size = new System.Drawing.Size(208, 28);
            this.cmbxExhibition.TabIndex = 5;
            this.cmbxExhibition.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Utstilling";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // cmbxArtForm
            // 
            this.cmbxArtForm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbxArtForm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbxArtForm.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cmbxArtForm.FormattingEnabled = true;
            this.cmbxArtForm.Items.AddRange(new object[] {
            "Collage",
            "Skulptur",
            "Portrett",
            "Persienne",
            "Voks",
            "Maleri",
            "Assemblage"});
            this.cmbxArtForm.Location = new System.Drawing.Point(171, 100);
            this.cmbxArtForm.Name = "cmbxArtForm";
            this.cmbxArtForm.Size = new System.Drawing.Size(208, 28);
            this.cmbxArtForm.TabIndex = 4;
            this.cmbxArtForm.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblForm
            // 
            this.lblForm.AutoSize = true;
            this.lblForm.Location = new System.Drawing.Point(19, 94);
            this.lblForm.Name = "lblForm";
            this.lblForm.Size = new System.Drawing.Size(82, 20);
            this.lblForm.TabIndex = 4;
            this.lblForm.Text = "Kunstform";
            // 
            // txtbxTitle
            // 
            this.txtbxTitle.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtbxTitle.Location = new System.Drawing.Point(171, 63);
            this.txtbxTitle.Name = "txtbxTitle";
            this.txtbxTitle.Size = new System.Drawing.Size(208, 26);
            this.txtbxTitle.TabIndex = 3;
            this.txtbxTitle.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(19, 63);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(43, 20);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Tittel";
            this.lblTitle.Click += new System.EventHandler(this.label3_Click);
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
            // lnkRegister
            // 
            this.lnkRegister.AutoSize = true;
            this.lnkRegister.BackColor = System.Drawing.SystemColors.Control;
            this.lnkRegister.Location = new System.Drawing.Point(29, 28);
            this.lnkRegister.Name = "lnkRegister";
            this.lnkRegister.Size = new System.Drawing.Size(117, 20);
            this.lnkRegister.TabIndex = 4;
            this.lnkRegister.TabStop = true;
            this.lnkRegister.Text = "Registrer kunst";
            this.lnkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);
            // 
            // lnkEdit
            // 
            this.lnkEdit.AutoSize = true;
            this.lnkEdit.Location = new System.Drawing.Point(375, 28);
            this.lnkEdit.Name = "lnkEdit";
            this.lnkEdit.Size = new System.Drawing.Size(136, 20);
            this.lnkEdit.TabIndex = 5;
            this.lnkEdit.TabStop = true;
            this.lnkEdit.Text = "Rediger oppføring";
            this.lnkEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEdit_LinkClicked);
            // 
            // lnkRead
            // 
            this.lnkRead.AutoSize = true;
            this.lnkRead.Location = new System.Drawing.Point(223, 28);
            this.lnkRead.Name = "lnkRead";
            this.lnkRead.Size = new System.Drawing.Size(100, 20);
            this.lnkRead.TabIndex = 6;
            this.lnkRead.TabStop = true;
            this.lnkRead.Text = "Se oppføring";
            this.lnkRead.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRead_LinkClicked);
            // 
            // txtbxJsonPath
            // 
            this.txtbxJsonPath.Location = new System.Drawing.Point(23, 28);
            this.txtbxJsonPath.Name = "txtbxJsonPath";
            this.txtbxJsonPath.Size = new System.Drawing.Size(312, 26);
            this.txtbxJsonPath.TabIndex = 7;
            // 
            // btnBrowseArtFile
            // 
            this.btnBrowseArtFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseArtFile.Location = new System.Drawing.Point(361, 28);
            this.btnBrowseArtFile.Name = "btnBrowseArtFile";
            this.btnBrowseArtFile.Size = new System.Drawing.Size(123, 26);
            this.btnBrowseArtFile.TabIndex = 15;
            this.btnBrowseArtFile.Text = "Bla gjennom...";
            this.btnBrowseArtFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowseArtFile.UseVisualStyleBackColor = true;
            this.btnBrowseArtFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowseArtFile);
            this.groupBox2.Controls.Add(this.txtbxJsonPath);
            this.groupBox2.Location = new System.Drawing.Point(33, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(530, 74);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Biblioteksfil";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtbxImagesFolder);
            this.groupBox3.Location = new System.Drawing.Point(33, 135);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(530, 74);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bildemappe";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(361, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 26);
            this.button1.TabIndex = 15;
            this.button1.Text = "Bla gjennom...";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txtbxImagesFolder
            // 
            this.txtbxImagesFolder.Location = new System.Drawing.Point(23, 28);
            this.txtbxImagesFolder.Name = "txtbxImagesFolder";
            this.txtbxImagesFolder.Size = new System.Drawing.Size(312, 26);
            this.txtbxImagesFolder.TabIndex = 7;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(648, 246);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(330, 219);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 18;
            this.pictureBox.TabStop = false;
            // 
            // artFormBindingSource
            // 
            this.artFormBindingSource.DataSource = typeof(BestefarsBilder.ArtForm);
            this.artFormBindingSource.CurrentChanged += new System.EventHandler(this.artFormBindingSource_CurrentChanged);
            // 
            // storageBindingSource1
            // 
            this.storageBindingSource1.DataSource = typeof(BestefarsBilder.Storage);
            // 
            // storageBindingSource2
            // 
            this.storageBindingSource2.DataSource = typeof(BestefarsBilder.Storage);
            // 
            // btnPersistFilePaths
            // 
            this.btnPersistFilePaths.Location = new System.Drawing.Point(33, 215);
            this.btnPersistFilePaths.Name = "btnPersistFilePaths";
            this.btnPersistFilePaths.Size = new System.Drawing.Size(140, 34);
            this.btnPersistFilePaths.TabIndex = 19;
            this.btnPersistFilePaths.Text = "Angi filbaner";
            this.btnPersistFilePaths.UseVisualStyleBackColor = true;
            this.btnPersistFilePaths.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // ArtForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(990, 881);
            this.Controls.Add(this.btnPersistFilePaths);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lnkRead);
            this.Controls.Add(this.lnkEdit);
            this.Controls.Add(this.lnkRegister);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ArtForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtbxId)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.artFormBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storageBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtbxTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblForm;
        private System.Windows.Forms.ComboBox cmbxArtForm;
        private System.Windows.Forms.ComboBox cmbxExhibition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbxDimensions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbxYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbxComment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbxConsole;
        private System.Windows.Forms.LinkLabel lnkRegister;
        private System.Windows.Forms.LinkLabel lnkEdit;
        private System.Windows.Forms.LinkLabel lnkRead;
        private System.Windows.Forms.TextBox txtbxJsonPath;
        private System.Windows.Forms.Button btnBrowseArtFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown txtbxId;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtbxImagesFolder;
        private System.Windows.Forms.TextBox txtbxImages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelectImages;
        private System.Windows.Forms.ComboBox cmbxRoom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbxTags;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource artFormBindingSource;
        private System.Windows.Forms.BindingSource storageBindingSource;
        private System.Windows.Forms.BindingSource storageBindingSource1;
        private System.Windows.Forms.BindingSource storageBindingSource2;
        private System.Windows.Forms.ComboBox cmbxShelf;
        private System.Windows.Forms.Button btnPersistFilePaths;
    }
}

