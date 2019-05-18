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
        private Graphics _graphics;
        private List<TextBox> _txtBoxes;
        private List<ComboBox> _comboBoxes;
        private TextBox _txtbx1, _txtbx2, _txtbx3, _txtbxId;
        private ComboBox _comboBox1, _comboBox2, _comboBox3;
        private Color _inactiveColor = SystemColors.InactiveCaption;
        private Color _activeColor = SystemColors.Window;
        private Color _warningColor = Color.Red;
        private Button _btnSave;

        [TestInitialize]
        public void SetUp()
        {
            _form = new Mock<IArtForm>(MockBehavior.Strict);
            _txtbx1 = new TextBox();
            _txtbx2 = new TextBox();
            _txtbx3 = new TextBox();
            _txtbxId = new TextBox();
            _comboBox1 = new ComboBox();
            _comboBox2 = new ComboBox();
            _comboBox3 = new ComboBox();
            _txtBoxes = new List<TextBox> { _txtbx1, _txtbx2, _txtbx3 };
            _comboBoxes = new List<ComboBox> { _comboBox1, _comboBox2, _comboBox3 };
            _btnSave = new Button();

            _form.Setup(x => x.GetTextBoxes()).Returns(_txtBoxes);
            _form.Setup(x => x.GetComboBoxes()).Returns(_comboBoxes);
            _form.Setup(x => x.GetTxtBxId()).Returns(_txtbxId);
            _form.Setup(x => x.GetButtonSave()).Returns(_btnSave);
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
            _graphics.FormStyleAdd();

            Assert.AreEqual(_inactiveColor, _txtbxId.BackColor);
            Assert.AreEqual(true, _txtbxId.ReadOnly);
            foreach(TextBox bx in _txtBoxes)
            {
                Assert.AreEqual(_activeColor, bx.BackColor);
            }
            foreach(ComboBox cbx in _comboBoxes)
            {
                Assert.AreEqual(_activeColor, cbx.BackColor);
            }
            Assert.AreEqual(true, _btnSave.Enabled);
        }
    }
}
