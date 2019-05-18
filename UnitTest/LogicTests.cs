using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BestefarsBilder.Test
{
    [TestClass]
    public class LogicTests
    {
        private Mock<IStorage> _storage;
        private Mock<IArtForm> _form;
        private Logic _logic;
        private List<Art> _arts;
        private TextBox _txtbxId, _txtbxTitle, _txtbxYear, _txtbxComment;
        private ComboBox _cmbxArtForm, _cmbxExhibition, _cmbxDimensions;
        private List<TextBox> _txtBoxes;
        private List<ComboBox> _comboBoxes;
        private Button _btnSave;

        [TestInitialize]
        public void SetUp()
        {
            _storage = new Mock<IStorage>(MockBehavior.Strict);
            _logic = new Logic(_storage.Object);
            _arts = new List<Art>()
                {
                    new Art(){ id = 1, title = "Title" },
                    new Art(){ id = 2},
                    new Art(){ id = 3}
                };
            _txtbxId = new TextBox() { Text = "1", Name = "txtbxID"};
            _txtbxTitle = new TextBox() { Text = "Title", Name="txtbxTitle"};
            _txtbxYear = new TextBox() { Text = "1993", Name = "txtbxYear" };
            _txtbxComment = new TextBox() { Text = "Comment", Name = "txtbxComment" };
            _cmbxArtForm = new ComboBox() { Text = "Collage", Name = "cmbxArtForm" };
            _cmbxExhibition = new ComboBox() { Text = "Utstilling 1", Name = "cmbxExhibition"};
            _cmbxDimensions = new ComboBox() { Text = "30x50", Name = "cmbxDimensions" };
            _txtBoxes = new List<TextBox> { _txtbxId, _txtbxTitle, _txtbxYear, _txtbxComment };
            _comboBoxes = new List<ComboBox> { _cmbxArtForm, _cmbxExhibition, _cmbxDimensions };

            _btnSave = new Button();
            _storage.Setup(x => x.GetFromStorage()).Returns(_arts);
            _form = new Mock<IArtForm>(MockBehavior.Strict);
            _form.Setup(x => x.GetTextBoxes()).Returns(_txtBoxes);
            _form.Setup(x => x.GetComboBoxes()).Returns(_comboBoxes);
            
        }

        [TestMethod]
        public void GetArtPostById()
        {
            var a = _logic.GetArtPostById(1);

            Assert.AreEqual(1, a.id);
        }

        [TestMethod]
        public void GetArtPostById_BadId()
        {
            var a = _logic.GetArtPostById(4);
            Assert.IsNull(a);
        }

        [TestMethod]
        public void GetArtFromForm()
        {
            Art a = _logic.GetArtFromForm(_form.Object);
            Assert.AreEqual(1, a.id);
            Assert.AreEqual("Title", a.title);
            Assert.AreEqual("1993", a.year);
            Assert.AreEqual("Comment", a.comment);
            Assert.AreEqual("Collage", a.artform);
            Assert.AreEqual("Utstilling 1", a.exhibition);
            Assert.AreEqual("30x50", a.dimensions);
        }


        [TestMethod]
        public void AddArt()
        {
            var a = new Art();

            _storage.Setup(x => x.PutInStorage(It.Is<List<Art>>(y => y.Count() == 4)));
            _logic.AddArt(a);

            _storage.VerifyAll();
        }

        [TestMethod]
        public void EditArt()
        {
            Art editedArt = new Art() { id = 1, title = "EditedTitle" };
            _storage.Setup(x => x.PutInStorage(It.Is<List<Art>>(y => y[0].title == "EditedTitle")));
            _storage.Setup(x => x.PutInStorage(It.Is<List<Art>>(y => y.Count() == 3)));
            int res = _logic.EditArt(1, editedArt);
            Assert.AreEqual(1, res);
            
            _storage.VerifyAll();
        }

        [TestMethod]
        public void EditArt_BadId()
        {
            Art editedArt = new Art() { id = 4, title = "BadID" };
            int res = _logic.EditArt(editedArt.id, editedArt);
            Assert.AreEqual(res, 0);
        }

        [TestMethod]
        public void GetUniqueId()
        {
            int id = _logic.GetUniqueId();
            Assert.AreEqual(4, id);
        }
    }
}
