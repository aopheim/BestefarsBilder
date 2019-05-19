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
        private Mock<Logic> _logic;
        private Graphics _graphics;

        private List<Art> _arts;
        private List<TextBox> _txtBoxes;
        private List<ComboBox> _comboBoxes;
        private TextBox _txtbxId, _txtbxTitle, _txtbxYear, _txtbxComment;
        private ComboBox _comboBox1, _comboBox2, _comboBox3;
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
                new Art(){ id = 1 }
            };
            _form = new Mock<IArtForm>(MockBehavior.Strict);
            _storage = new Mock<IStorage>(MockBehavior.Strict);
            _logic = new Mock<Logic>(MockBehavior.Strict);

            _txtbxId = new TextBox() { Name = "txtbxId" };
            _txtbxTitle = new TextBox() { Name = "txtbxTitle" };
            _txtbxYear = new TextBox();
            _txtbxComment = new TextBox();
            _comboBox1 = new ComboBox();
            _comboBox2 = new ComboBox();
            _comboBox3 = new ComboBox();
            _lnkAdd = new LinkLabel() { Name = "lnkRegister" };
            _lnkRead = new LinkLabel() { Name = "lnkRead" };
            _lnkEdit = new LinkLabel() { Name = "lnkEdit" };
            _lnkLabels = new List<LinkLabel>() { _lnkAdd, _lnkEdit, _lnkRead };

            _txtBoxes = new List<TextBox> { _txtbxId, _txtbxTitle, _txtbxYear, _txtbxComment };
            _comboBoxes = new List<ComboBox> { _comboBox1, _comboBox2, _comboBox3 };
            _btnSave = new Button();

            _storage.Setup(x => x.GetFromStorage()).Returns(_arts);

            _form.Setup(x => x.GetTextBoxes()).Returns(_txtBoxes);
            _form.Setup(x => x.GetComboBoxes()).Returns(_comboBoxes);
            _form.Setup(x => x.GetTxtBxId()).Returns(_txtbxId);
            _form.Setup(x => x.GetButtonSave()).Returns(_btnSave);
            _form.Setup(x => x.GetLinkLabels()).Returns(_lnkLabels);
            
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

            _form.VerifyAll();
        }

        
        [TestMethod]
        public void FormStyleAdd()
        {
            _form.Setup(x => x.GetLogic()).Returns(_logic.Object);
            _logic.Setup(x => x.GetUniqueId()).Returns(2);

            _graphics.FormStyleAdd();

            Assert.AreEqual(_activeLinkColor, _lnkAdd.BackColor);
            Assert.AreEqual(_backgroundColor, _lnkRead.BackColor);
            Assert.AreEqual(_backgroundColor, _lnkEdit.BackColor);

            foreach(TextBox bx in _txtBoxes)
            {
                if (bx.Name == "txtbxId")
                {
                    Assert.AreEqual(_inactiveColor, bx.BackColor);
                    continue;
                }
                Assert.AreEqual(_activeColor, bx.BackColor);
            }
            foreach(ComboBox cbx in _comboBoxes)
            {
                Assert.AreEqual(_activeColor, cbx.BackColor);
            }
            Assert.AreEqual(_inactiveColor, _txtbxId.BackColor);
            Assert.AreEqual(true, _txtbxId.ReadOnly);
            Assert.AreEqual(true, _btnSave.Enabled);

            foreach(TextBox tbx in _txtBoxes)
            {
                if (tbx.Name == "txtbxId")
                {
                    Assert.AreEqual("2", tbx.Text);
                    continue;
                }
                Assert.AreEqual("", tbx.Text);
            }
            foreach(ComboBox cbx in _comboBoxes)
            {
                Assert.AreEqual("", cbx.Text);
            }
        }
    }
}
