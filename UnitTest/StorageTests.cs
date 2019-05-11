using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BestefarsBilder.Test
{
    [TestClass]
    public class StorageTests
    {
        [TestMethod]
        public void GetFromStorage()
        {
            var storage = new Storage("TestStorage.json");

            var arts = storage.GetFromStorage().OrderBy(x => x.id).ToArray();

            Assert.AreEqual(3, arts.Count());

            var first = arts[0];
            Assert.AreEqual(1, first.id);
            Assert.AreEqual("Fyra fina flickor", first.title);
            Assert.AreEqual("Collage", first.artform);
            Assert.AreEqual("Oslos Art Exhibition", first.exhibition);
            Assert.AreEqual("300x100", first.dimensions);
            Assert.AreEqual("1981", first.year);
            Assert.AreEqual("Litt saann", first.comment);

            var second = arts[1];
            Assert.AreEqual(2, second.id);
            Assert.AreEqual("Mona Lisa", second.title);
            Assert.AreEqual("Portrett", second.artform);
            Assert.AreEqual("Hamar Art Show", second.exhibition);
            Assert.AreEqual("20x50", second.dimensions);
            Assert.AreEqual("1995", second.year);
            Assert.AreEqual("Hei hei", second.comment);

            var third = arts[2];
            Assert.AreEqual(3, third.id);
            Assert.AreEqual("Sommerfuglbilde", third.title);
            Assert.AreEqual("Collage", third.artform);
            Assert.AreEqual("Hamar Art Show", third.exhibition);
            Assert.AreEqual("30x50", third.dimensions);
            Assert.AreEqual("1993", third.year);
            Assert.AreEqual("Tittei", third.comment);
        }
    }
}
