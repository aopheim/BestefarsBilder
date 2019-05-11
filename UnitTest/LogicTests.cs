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
        Mock<IStorage> storage;
        Logic logic;
        List<Art> arts;

        [TestInitialize]
        public void SetUp()
        {
            storage = new Mock<IStorage>(MockBehavior.Strict);
            logic = new Logic(storage.Object);
            arts = new List<Art>()
                {
                    new Art(){ id = 1},
                    new Art(){ id = 2},
                    new Art(){ id = 3}
                };
            storage.Setup(x => x.GetFromStorage()).Returns(arts);
              
        }

        [TestMethod]
        public void GetArtPostById()
        {
            var a = logic.GetArtPostById(1);

            Assert.AreEqual(1, a.id);
        }

        [TestMethod]
        public void GetArtPostById_BadId()
        {
            var a = logic.GetArtPostById(4);
            Assert.IsNull(a);
        }


        [TestMethod]
        public void AddArt()
        {
            var a = new Art();

            storage.Setup(x => x.PutInStorage(It.Is<List<Art>>(y => y.Count() == 4)));
            logic.AddArt(a);

            storage.VerifyAll();
        }
    }
}
