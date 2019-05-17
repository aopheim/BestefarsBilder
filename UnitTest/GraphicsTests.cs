using System;
using System.Collections.Generic;
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
        private TextBox _txtbx1, _txtbx2, _txtbx3;
        private ComboBox _comboBox1, _comboBox2, _comboBox3;

        [TestInitialize]
        public void SetUp()
        {
            _form = new Mock<IArtForm>(MockBehavior.Strict);
            _txtBoxes = new List<TextBox> { _txtbx1, _txtbx2, _txtbx3 };
            _comboBoxes = new List<ComboBox> { _comboBox1, _comboBox2, _comboBox3 };
            _graphics = new Graphics(_form.Object);
            _form.Setup(x => x.GetTextBoxes()).Returns(_txtBoxes);
        }

        [TestMethod]
        public void DisableFields()
        {
            throw new NotImplementedException();
        }
    }
}
