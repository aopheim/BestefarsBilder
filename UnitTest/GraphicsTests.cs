using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BestefarsBilder.Test

{
    [TestClass]
    public class GraphicsTests
    {
        private Mock<IArtForm> _form;
        private Mock<IStorage> _storage; 
        private Logic _logic;
        private Graphics _graphics;

        private List<Art> _arts;
        private List<TextBox> _txtBoxes;
        private List<ComboBox> _comboBoxes;
        private TextBox _txtbxTitle, _txtbxYear, _txtbxComment, _txtbxWarning;
        private ComboBox _cmbxDimensions, _cmbxExhibition, _cmbxArtForm;
        private NumericUpDown _txtbxId;
        private GroupBox _groupBox;
        private LinkLabel _lnkAdd, _lnkRead, _lnkEdit;
        private List<LinkLabel> _lnkLabels;
        private Button _btnSave;

        private Color _inactiveColor = SystemColors.InactiveCaption;
        private Color _activeColor = SystemColors.Window;
        private Color _warningColor = Color.Red;
        private Color _activeLinkColor = System.Drawing.Color.PaleGreen;
        private Color _backgroundColor = SystemColors.Control;
        

        [TestInitialize]
        public void SetUp()
        {
            _arts = new List<Art>()
            {
                new Art(){
                    id = 1,
                    title = "Title1",
                    year = "1993",
                    comment ="Comment1",
                    artform ="Collage",
                    dimensions="30x50",
                    exhibition="Exhibition1"
                }
            };
            _form = new Mock<IArtForm>(MockBehavior.Strict);
            _storage = new Mock<IStorage>(MockBehavior.Strict);

            _txtbxId = new NumericUpDown() { Name = "txtbxId" };
            _txtbxTitle = new TextBox() { Name = "txtbxTitle" };
            _txtbxYear = new TextBox() { Name = "txtbxYear" };
            _txtbxComment = new TextBox() { Name = "txtbxComment" };
            _cmbxDimensions = new ComboBox() { Name = "cmbxDimensions"};
            _cmbxArtForm = new ComboBox() { Name = "cmbxArtForm" };
            _cmbxExhibition = new ComboBox() { Name = "cmbxExhibition" };
            _txtbxWarning = new TextBox() { Name = "txtbxWarning" };
            _groupBox = new GroupBox();
            _lnkAdd = new LinkLabel() { Name = "lnkRegister" };
            _lnkRead = new LinkLabel() { Name = "lnkRead" };
            _lnkEdit = new LinkLabel() { Name = "lnkEdit" };
            _lnkLabels = new List<LinkLabel>() { _lnkAdd, _lnkEdit, _lnkRead };

            _txtBoxes = new List<TextBox> { _txtbxTitle, _txtbxYear, _txtbxComment };
            _comboBoxes = new List<ComboBox> { _cmbxArtForm, _cmbxDimensions, _cmbxExhibition };
            _btnSave = new Button();

            _storage.Setup(x => x.GetFromStorage()).Returns(_arts);
            _logic = new Logic(_storage.Object, _form.Object);
            
            _form.Setup(x => x.GetTextBoxes()).Returns(_txtBoxes);
            _form.Setup(x => x.GetComboBoxes()).Returns(_comboBoxes);
            _form.Setup(x => x.GetTxtBxId()).Returns(_txtbxId);
            _form.Setup(x => x.GetButtonSave()).Returns(_btnSave);
            _form.Setup(x => x.GetLinkLabels()).Returns(_lnkLabels);
            _form.Setup(x => x.GetGroupBox()).Returns(_groupBox);
            _form.Setup(x => x.GetTxtBxWarning()).Returns(_txtbxWarning);
            _form.Setup(x => x.GetLogic()).Returns(_logic);

            _graphics = new Graphics(_form.Object);
        }

        [TestMethod]
        public void DisableFields()
        {
            _graphics.DisableFields();
            foreach (TextBox txt in _txtBoxes)
            {
                Assert.AreEqual(true, txt.ReadOnly);
            }
            foreach (ComboBox cbx in _comboBoxes)
            {
                Assert.AreEqual(false, cbx.Enabled);
            }
        }



        [TestMethod]
        public void FormStyleEdit()
        {
            _graphics.FormStyleEdit();
            Assert.IsTrue(_form.Object.GetLogic().IsEditReg);
            Assert.IsFalse(_form.Object.GetLogic().IsReadReg);
            Assert.IsTrue(_form.Object.GetLogic().IsNewReg);

            Assert.AreEqual(_activeLinkColor, _lnkEdit.BackColor);
            Assert.AreEqual(_backgroundColor, _lnkRead.BackColor);
            Assert.AreEqual(_backgroundColor, _lnkAdd.BackColor);

            Assert.AreEqual("Rediger oppføring", _groupBox.Text);

            foreach (TextBox tbx in _txtBoxes)
            {
                if (tbx.Name == "txtbxId")
                {
                    Assert.AreEqual(_activeColor, tbx.BackColor);
                    Assert.AreEqual(false, tbx.ReadOnly);
                    continue;
                }
                Assert.AreEqual(_inactiveColor, tbx.BackColor);
                Assert.AreEqual(true, tbx.ReadOnly);
            }
            foreach (ComboBox cbx in _comboBoxes)
            {
                Assert.AreEqual(_inactiveColor, cbx.BackColor);
                Assert.AreEqual(false, cbx.Enabled);
            }

            Assert.AreEqual(false, _btnSave.Enabled);
        }

        
        [TestMethod]
        public void FormStyleAdd()
        {

            _graphics.FormStyleAdd();

            Assert.AreEqual(_activeLinkColor, _lnkAdd.BackColor);
            Assert.AreEqual(_backgroundColor, _lnkRead.BackColor);
            Assert.AreEqual(_backgroundColor, _lnkEdit.BackColor);

            Assert.AreEqual("Registrer nytt bilde", _groupBox.Text);
            foreach(TextBox bx in _txtBoxes)
            {
                if (bx.Name == "txtbxId")
                {
                    Assert.AreEqual(_inactiveColor, bx.BackColor);
                    Assert.AreEqual("2", bx.Text);
                    continue;
                }
                Assert.AreEqual(_activeColor, bx.BackColor);
                Assert.AreEqual("", bx.Text);
            }
            foreach(ComboBox cbx in _comboBoxes)
            {
                Assert.AreEqual(_activeColor, cbx.BackColor);
                Assert.AreEqual("", cbx.Text);
            }
            Assert.AreEqual(_inactiveColor, _txtbxId.BackColor);
            Assert.AreEqual(true, _txtbxId.ReadOnly);
            Assert.AreEqual(true, _btnSave.Enabled);
        }

        [TestMethod]
        public void FormStyleRead()
        {
            _graphics.FormStyleRead();

            Assert.AreEqual(true, _form.Object.GetLogic().IsReadReg);
            Assert.AreEqual(false, _form.Object.GetLogic().IsEditReg);
            Assert.AreEqual(false, _form.Object.GetLogic().IsNewReg);
            Assert.AreEqual(_activeLinkColor, _lnkRead.BackColor);
            Assert.AreEqual(_backgroundColor, _lnkEdit.BackColor);
            Assert.AreEqual(_backgroundColor, _lnkAdd.BackColor);
            Assert.AreEqual("Se oppføring", _groupBox.Text);
            foreach (TextBox tbx in _txtBoxes)
            {
                if (tbx.Name == "txtbxId")
                {
                    Assert.AreEqual(_activeColor, tbx.BackColor);
                    Assert.AreEqual(false, tbx.ReadOnly);
                    continue;
                }
                Assert.AreEqual(_inactiveColor, tbx.BackColor);
                Assert.AreEqual(true, tbx.ReadOnly);
            }
            foreach(ComboBox cbx in _comboBoxes)
            {
                Assert.AreEqual(_inactiveColor, cbx.BackColor);
                Assert.AreEqual(false, cbx.Enabled);
            }

            Assert.AreEqual(false, _btnSave.Enabled);
        }

        [TestMethod]
        public void FillFields()
        {
            int id = 1;
            _graphics.FillFields(id);

            Assert.AreEqual("1", _txtbxId.Text);
            Assert.AreEqual("Title1", _txtbxTitle.Text);
            Assert.AreEqual("1993", _txtbxYear.Text);
            Assert.AreEqual("30x50", _cmbxDimensions.Text);
            Assert.AreEqual("Exhibition1", _cmbxExhibition.Text);
            Assert.AreEqual("Collage", _cmbxArtForm.Text);

        }
    }
}
