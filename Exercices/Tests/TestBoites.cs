using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boites;

namespace Tests
{
    [TestClass]
    public class TestBoites
    {
        [TestMethod]
        public void TesterNombredeCompteurs()
        {
            Boite b1 = new Boite(2, 3, 2);
            Assert.AreEqual(1, Boite.Compteur);
            
        }
        [TestMethod]
        public void TesterVolume()
        {
            Boite b1 = new Boite(2, 3, 2);
            Assert.AreEqual(12, b1.Volume);
        }
    }
}
