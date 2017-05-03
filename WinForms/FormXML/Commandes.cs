using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FormXML
{
    public class Commande
    {
        [XmlAttribute]
        public int IdCommande { get; set; }
        [XmlAttribute]
        public string IdClient { get; set; }
        [XmlAttribute]
        public string DateCommande { get; set; }
        public DateTime DateCom { get; set; }
        //On  ne décore avec rien => par défaut xmlElement
        public List<DetailsCommande> ListeDetails { get; set; }
    }

    public class DetailsCommande
    {
        [XmlAttribute]
        public int IdProduit { get; set; }
        [XmlAttribute]
        public float Discount { get; set; }
        [XmlAttribute]
        public int Quantité { get; set; }
        [XmlAttribute]
        public decimal UnitPrice { get; set; }
    }
}
