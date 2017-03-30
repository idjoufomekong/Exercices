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
            //Boite b1 = new Boite(2, 3, 2);
            //Assert.AreEqual(1, Boite.Compteur);

            //Ou créer un compteur de boîtes par un tableau
            Boite[] b = new Boite[4];

            for (int i = 0; i< b.Length; i++)
            {
                b[i] = new Boite();
            }
            Assert.AreEqual(4, Boite.Compteur);

        }
        [TestMethod]
        public void TesterVolume()
        {
            Boite b1 = new Boite(2, 3, 2);
            Assert.AreEqual(12, b1.Volume);

            //Problème de comparaison sur les double: il faut prévoir une marge d'erreur sinon faire la différence et comparer avec un petit delta
            Boite b2 = new Boite(2.0, 3.0, 2.0);
            Assert.AreEqual(12.0, b2.Volume,0.01);

        }
    }
}
