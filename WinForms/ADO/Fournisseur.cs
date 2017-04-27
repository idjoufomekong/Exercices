using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class Fournisseur
    {
        #region Propriétés
        //[DisplayName("Id du fournisseur")]
        //public int SupplierID { get; set; }
        public int Identifiant { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        #endregion
    }

    public class InfosCommande
    {
        #region propriétés
        [DisplayName("Id Commande")]
        public int Id { get; set; }
        [DisplayName("Date Commande")]
        public string DateCom { get; set; }
        [DisplayName("Date Livraison")]
        public string DateLiv { get; set; }
        [DisplayName("Nombre d'articles")]
        public int NbArticle { get; set; }
        [DisplayName("Montant Commande")]
        public int MontantCom { get; set; }
        [DisplayName("Frais d'envoi")]
        public int FraisEnvoi { get; set; }
        #endregion
    }

    public class Client
    {
        public string Code { get; set; }
        public string Nom { get; set; }
        //public string Prénom { get; set; }
    }

    public class Produit
    {
        [DisplayName("Identifiant produit")]
        public int IdProduit { get; set; }
        public string Nom { get; set; }
        public int Categorie { get; set; }
        [DisplayName("Quantité unitaire")]
        public string QuantityPerUnit { get; set; }
        [DisplayName("Prix unitaire")]
        public decimal UnitPrice { get; set; }
        [DisplayName("Quantité en stock")]
        public int UnitsInStock { get; set; }
        public int Fournisseur { get; set; }
    }
}
