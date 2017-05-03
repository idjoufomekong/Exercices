using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FormXML
{
    public class DAL
    {
        public static List<string> GetTitreAlbumsAn60(XDocument doc)
        {
            var titre = doc.Descendants("Album").Where(x => int.Parse(x.Attribute("Année").Value) < 1970 && 
            int.Parse(x.Attribute("Année").Value) >= 1960).Attributes("Titre").Select(t => t.Value).ToList();

            //Meilleure possibilité
            var titre1 = doc.Descendants("Album").Where(x => x.Attribute("Année").Value.StartsWith("196")).Attributes("Titre").Select(t => t.Value).ToList();
            return titre;
        }
        public static void AjouterAuteurDabere(XDocument doc)
        {
            var p = doc.Descendants("CollectionBD").Where(x => x.Attribute("Nom").Value == "Lucky Luke").Elements("Auteurs");//.First(); 
            if(!p.Elements("Auteur").Where(x => x.Value == "Pascal Dabère").Any())
            p.First().Add(new XElement("Auteur", "Pascal Dabère"));
            doc.Save(@"..\..\CollectionsBD.xml");
        }

        public static void AjouterAlbum(XDocument doc)
        {
            var p = doc.Descendants("CollectionBD").Where(x => x.Attribute("Nom").Value == "Lucky Luke").Elements("Albums");//.First();
            int id = p.Descendants("Album").Max(x => (int) x.Attribute("Id"));
            //OU
            int z = p.Descendants("Album").Attributes("Id").Max(x => int.Parse(x.Value));
            XElement album = new XElement("Album",
                                new XAttribute("Id", ++id),
                                new XAttribute("Titre", "Le pont sur le Mississippi"),
                                new XAttribute("Année", "1994"));
            p.First().Add(album);
            doc.Save(@"..\..\CollectionsBD.xml");
        }

        public static void MajAlbum15(XDocument doc)
        {
            var col = doc.Descendants("CollectionBD").Where(x => x.Attribute("Nom").Value == "Astérix");
            var titre = col.Descendants("Album").Where(x => int.Parse(x.Attribute("Id").Value) == 15).First();
            //Mieux
            var titre1 = doc.Descendants("CollectionBD").Where(x => x.Attribute("Nom").Value == "Astérix").
                Descendants("Album").Where(x => int.Parse(x.Attribute("Id").Value) == 15).Attributes("Titre").First();
            titre1.Value = titre1.Value.ToUpper();
            titre.Attribute("Titre").Value = titre.Attribute("Titre").Value.ToUpper();
            doc.Save(@"..\..\CollectionsBD.xml");
        }

        public static List<Commande> DeserialiserLinq()
        {
            XDocument doc = XDocument.Load(@"..\..\Commande.xml");
            List<Commande> listeCommande = new List<Commande>();

            //Je récupère la liste des commandes
            var listCom = doc.Descendants("Commande").ToList();
            foreach(var a in listCom)
            {
                Commande com = new Commande();
                com.DateCom = (DateTime) a.Element("DateCom");
                com.IdCommande = (int) a.Attribute("IdCommande");
                com.IdClient = (string) a.Attribute("IdClient");
                com.DateCommande = (string)a.Element("DateCom");

                com.ListeDetails = new List<DetailsCommande>();
                var detail = a.Descendants("DetailsCommande").ToList();
                foreach(var b in detail)
                {
                    DetailsCommande det = new DetailsCommande();
                    det.IdProduit = (int) b.Attribute("IdProduit");
                    det.Discount = (float)b.Attribute("Discount");
                    det.Quantité = (int)b.Attribute("Quantité");
                    det.UnitPrice = (decimal)b.Attribute("UnitPrice");
                    com.ListeDetails.Add(det);
                }
                listeCommande.Add(com);
            }
            return listeCommande;
        }
    }
}
