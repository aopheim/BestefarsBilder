using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BestefarsBilder.Test
{
    [TestClass]
    public class LogicTests
    {
        private Mock<IStorage> _storage;
        private Logic _logic;
        private List<Art> _arts;

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
            _storage.Setup(x => x.GetFromStorage()).Returns(_arts);
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
            _logic.EditArt(1, editedArt);
            
            _storage.VerifyAll();
        }

        [TestMethod]
        public void EditArt_BadId()
        {
            throw new NotImplementedException();
        }
    }
}
