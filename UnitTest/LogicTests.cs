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

        private Graphics _graphics;
        private Logic _logic;
        private List<Art> _arts;
        private TextBox _txtbxId, _txtbxTitle, _txtbxYear, _txtbxComment, _txtbxWarning;
        private ComboBox _cmbxArtForm, _cmbxExhibition, _cmbxDimensions;
        private GroupBox _groupBox;

        private List<LinkLabel> _linkLabels;
        private List<TextBox> _txtBoxes;
        private List<ComboBox> _comboBoxes;
        private Button _btnSave;

        [TestInitialize]
        public void SetUp()
        {
            _storage = new Mock<IStorage>(MockBehavior.Strict);
            _arts = new List<Art>()
            {
                new Art(){ id = 1, title = "OriginalTitle" },
                new Art(){ id = 2},
                new Art(){ id = 3}
            };
            _txtbxId = new TextBox() { Text = "4", Name = "txtbxId"};
            _txtbxTitle = new TextBox() { Text = "Title", Name="txtbxTitle"};
            _txtbxYear = new TextBox() { Text = "1993", Name = "txtbxYear" };
            _txtbxComment = new TextBox() { Text = "Comment", Name = "txtbxComment" };
            _txtbxWarning = new TextBox();
            _cmbxArtForm = new ComboBox() { Text = "Collage", Name = "cmbxArtForm" };
            _cmbxExhibition = new ComboBox() { Text = "Utstilling 1", Name = "cmbxExhibition"};
            _cmbxDimensions = new ComboBox() { Text = "30x50", Name = "cmbxDimensions" };
            _groupBox = new GroupBox();
            _txtBoxes = new List<TextBox> { _txtbxId, _txtbxTitle, _txtbxYear, _txtbxComment };
            _comboBoxes = new List<ComboBox> { _cmbxArtForm, _cmbxExhibition, _cmbxDimensions };
            _linkLabels = new List<LinkLabel> { new LinkLabel(), new LinkLabel() };
            _btnSave = new Button();

            _storage.Setup(x => x.GetFromStorage()).Returns(_arts);

            _form = new Mock<IArtForm>(MockBehavior.Strict);
            _form.Setup(x => x.GetTextBoxes()).Returns(_txtBoxes);
            _form.Setup(x => x.GetComboBoxes()).Returns(_comboBoxes);
            _form.Setup(x => x.GetGroupBox()).Returns(_groupBox);
            _form.Setup(x => x.GetTxtBxId()).Returns(_txtbxId);
            _form.Setup(x => x.GetTxtBxWarning()).Returns(_txtbxWarning);
            _form.Setup(x => x.GetButtonSave()).Returns(_btnSave);
            _form.Setup(x => x.GetLinkLabels()).Returns(_linkLabels);

            _graphics = new Graphics(_form.Object);
            _form.Setup(x => x.GetGraphics()).Returns(_graphics);

            _logic = new Logic(_storage.Object, _form.Object);
            _logic.IsNewReg = false;
            _logic.IsEditReg = false;
            _logic.IsReadReg = false;
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
            Assert.AreEqual(4, a.id);
            Assert.AreEqual("Title", a.title);
            Assert.AreEqual("1993", a.year);
            Assert.AreEqual("Comment", a.comment);
            Assert.AreEqual("Collage", a.artform);
            Assert.AreEqual("Utstilling 1", a.exhibition);
            Assert.AreEqual("30x50", a.dimensions);
        }


        [TestMethod]
        public void OnSave_AddArt()
        {
            _logic.IsNewReg = true;
            _logic.IsEditReg = false;
            _logic.IsReadReg = false;
            _storage.Setup(x => x.PutInStorage(It.Is<List<Art>>(y => y.Exists(z => z.title == "Title"))));
            _storage.Setup(x => x.PutInStorage(It.Is<List<Art>>(y => y.Count() == 4)));

            _logic.OnSave();
            Assert.AreEqual("Kunst lagret", _form.Object.GetTxtBxWarning().Text);

            _storage.VerifyAll();       // Not possible to verify two setups? Commenting out one passes the test
        }
            
        [TestMethod]
        public void OnSave_EditArt()
        {
            _logic.IsNewReg = false;
            _logic.IsEditReg = true;
            _logic.IsReadReg = false;

            _storage.Setup(x => x.PutInStorage(It.Is<List<Art>>(y => y.Count() == 3)));
            _storage.Setup(x => x.PutInStorage(It.Is<List<Art>>(y => y.Exists(z => z.title == "Title"))));
            _txtbxId.Text = "1";        // Edit entry nr 1
            _logic.OnSave();

            Assert.AreEqual("Kunst lagret", _form.Object.GetTxtBxWarning().Text);
        }

        [TestMethod]
        public void OnSave_EditArt_BadId()
        {
            _logic.IsNewReg = false;
            _logic.IsEditReg = true;
            _logic.IsReadReg = false;

            _logic.OnSave();
            Assert.AreEqual(3, _storage.Object.GetFromStorage().Count());
            Assert.AreEqual("Redigerer en ugyldig ID", _form.Object.GetTxtBxWarning().Text);
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
            _storage.Setup(x => x.PutInStorage(It.Is<List<Art>>(y => y.Exists(z => z.title == "EditedTitle"))));
            _storage.Setup(x => x.PutInStorage(It.Is<List<Art>>(y => y.Count() == 3)));
            Art editedArt = new Art() { id = 1, title = "EditedTitle" };
            int res = _logic.EditArt(1, editedArt);
            Assert.AreEqual(1, res);
            
            // Not possible with two setups? Passes test if one of them are commented out. 
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
