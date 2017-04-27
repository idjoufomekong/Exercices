using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO
{
    public class DAL
    {
        public static void GetRegion()
        {
            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = "select RegionID, RegionDescription from Region ";
                using(var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("{0}, {1}", reader[0], reader[1]);
                    }
                }
            }

        }

        public static List<Fournisseur> GetFournisseurs(string pays)
        {
            var listFournisseur = new List<Fournisseur>();

            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"select SupplierID, CompanyName, ContactName, ContactTitle, Address, City, Region,
            PostalCode, Country from Suppliers where Country = @Pays";

            var param = new SqlParameter("@Pays", DbType.String);
            param.Value = pays;
            
            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                command.Parameters.Add(param);
                connect.Open();
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetFournisseursFromDataReader(listFournisseur, reader);
                    }
                }
            }
            
            return listFournisseur;
        }

        private static void GetFournisseursFromDataReader(List<Fournisseur> lstFournisseur, SqlDataReader reader)
        {
            var frs = new Fournisseur();
            frs.Identifiant = reader.GetInt32(0); //(int) reader["SupplierID"];
            frs.CompanyName = (string)reader["CompanyName"];
            if(!reader.IsDBNull(2))
                frs.ContactName = (string)reader["ContactName"];
            if (!reader.IsDBNull(3))
                frs.ContactTitle = (string)reader["ContactTitle"];
            if (!reader.IsDBNull(4))
                frs.Address = (string)reader["Address"];
            if (!reader.IsDBNull(5))
                frs.City = (string)reader["City"];
            if (reader["Region"] != DBNull.Value)
                frs.Region = (string)reader["Region"];
            if (!reader.IsDBNull(8))
                frs.PostalCode = (string)reader["PostalCode"];
            if (!reader.IsDBNull(8))
                frs.Country = (string)reader["Country"];
            
            lstFournisseur.Add(frs);
        }

        public static List<string> GetPaysFournisseurs()
        {
            var listPaysFournisseur = new List<string>();

            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"select distinct Country from Suppliers order by 1";
            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                   while (reader.Read())
                    {
                        GetPaysFournisseursFromDataReader(listPaysFournisseur, reader);
                    }
                }
            }
            return listPaysFournisseur;
        }

        private static void GetPaysFournisseursFromDataReader(List<string> lstFournisseur, SqlDataReader reader)
        {
            string pays;
            if (reader["Country"] != DBNull.Value)
            {
                pays = (string)reader["Country"];
                lstFournisseur.Add(pays);
            }

        }

        public static int GetNbProduitParPays(string pays)
        {
            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            var param = new SqlParameter("@Pays", DbType.String);
            param.Value = pays;

            using (var connect = new SqlConnection(connectString))
            {
                string queryString = @"select COUNT(*) from Products P inner join Suppliers S on S.SupplierID = P.SupplierID 
            where S.Country = @Pays";
                var command = new SqlCommand(queryString, connect);
                command.Parameters.Add(param);
                connect.Open();

                int nbProduits = (int)command.ExecuteScalar();
            return nbProduits;
            }
        }

        public static List<InfosCommande> GetInfosCommandes(string codeClient)
        {
            var listInfosCommande = new List<InfosCommande>();

            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"select * from ufn_ListeCommandeClient(@codeClient)";

            var param = new SqlParameter("@codeClient", DbType.String);
            param.Value = codeClient;

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                command.Parameters.Add(param);
                connect.Open(); 

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetInfosCommandesFromDataReader(listInfosCommande, reader);
                    }
                }
            }

            return listInfosCommande;
        }
        //La méthode GetInfosCommandesFromDataReader crée les instances de la collection envoyée en paramètre
        private static void GetInfosCommandesFromDataReader(List<InfosCommande> lstinfoCom, SqlDataReader reader)
        {
            var ifc = new InfosCommande();
            ifc.Id = reader.GetInt32(0); //(int) reader["SupplierID"];
            ifc.DateCom = (string)reader["DateCom"];
            ifc.DateLiv = (string)reader["DateLiv"];
            ifc.NbArticle = (int)reader["NbArticle"];
            ifc.MontantCom = (int)reader["MontantCom"];
            ifc.FraisEnvoi = (int)reader["FraisEnvoi"];

            lstinfoCom.Add(ifc);
        }

        //TODO: tester le todo
        public static List<Client> GetListeClients()
        {
            var listClients = new List<Client>();

            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"select CustomerID, ContactName from Customers";
            
            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetInfosClientsFromDataReader(listClients, reader);
                    }
                }
            }

            return listClients;
        }

        private static void GetInfosClientsFromDataReader(List<Client> listClients, SqlDataReader reader)
        {
            var cli = new Client();
            cli.Code = (string)reader["CustomerID"];
            cli.Nom = (string)reader["ContactName"];

            listClients.Add(cli);
        }

        public static BindingList<Produit> GetListeProduits()
        {
            var listProduits = new BindingList<Produit>();

            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"select ProductID, ProductName, CategoryID, QuantityPerUnit, UnitPrice,
                UnitsInStock, SupplierID from Products ";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetInfosClientsFromDataReader(listProduits, reader);
                    }
                }
            }

            return listProduits;
        }

        private static void GetInfosClientsFromDataReader(BindingList<Produit> listProduits, SqlDataReader reader)
        {
            var prod = new Produit();
            prod.IdProduit = (int)reader["ProductID"];
            prod.Nom = (string)reader["ProductName"];
            if(reader["CategoryID"] != DBNull.Value)
            prod.Categorie = (int)reader["CategoryID"];
            if (reader["QuantityPerUnit"] != DBNull.Value)
                prod.QuantityPerUnit = (string)reader["QuantityPerUnit"];
            if (reader["UnitPrice"] != DBNull.Value)
                prod.UnitPrice = (decimal)reader["UnitPrice"];
            if (reader["UnitsInStock"] != DBNull.Value)
                prod.UnitPrice = (Int16)reader["UnitsInStock"];
            if (reader["SupplierID"] != DBNull.Value)
                prod.Fournisseur = (int)reader["SupplierID"];

            listProduits.Add(prod);
        }

        public static void AjouterProduitBD(Produit produit)
        {
            List<int> ListeCategoryId = new List<int>();
            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"insert Products(ProductName,CategoryID,QuantityPerUnit,UnitPrice,
                UnitsInStock,SupplierID)values (@nom,@categorieId,@qte,@prix,@stock,@fournisseur)";
            //string queryString2 = @"select CategoryID from Categories";
            //string queryString3 = @"insert Categories(CategoryID, CategoryName) values ()";

            var param1 = new SqlParameter("@nom", DbType.String);
            var param2 = new SqlParameter("@categorieId", DbType.Int16);
            var param3 = new SqlParameter("@qte", DbType.String);
            var param4 = new SqlParameter("@prix", DbType.Decimal);
            var param5 = new SqlParameter("@stock", DbType.Int16);
            var param6 = new SqlParameter("@fournisseur", DbType.Int32);
            param1.Value = produit.Nom;
            param2.Value = produit.Categorie;
            param3.Value = produit.QuantityPerUnit;
            param4.Value = produit.UnitPrice;
            param5.Value = produit.UnitsInStock;
            param6.Value = produit.Fournisseur;

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.Parameters.Add(param5);
                command.Parameters.Add(param6);

                //var command2 = new SqlCommand(queryString2, connect);

                connect.Open();
                command.ExecuteNonQuery();
            }
        }

        public static int GetIdProduit(Produit produit)
        {
            int id = 0;
            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"select ProductID from Products where ProductName =@nom and CategoryID =@categorieId and 
    QuantityPerUnit =@qte and UnitPrice =@prix and UnitsInStock = @stock and SupplierID =@fournisseur";

            var nom = new SqlParameter("@nom", DbType.String);
            var categorieId = new SqlParameter("@categorieId", DbType.Int16);
            var qte = new SqlParameter("@qte", DbType.String);
            var prix = new SqlParameter("@prix", DbType.Decimal);
            var stock = new SqlParameter("@stock", DbType.Int16);
            var fournisseur = new SqlParameter("@fournisseur", DbType.Int32);
            nom.Value = produit.Nom;
            categorieId.Value = produit.Categorie;
            qte.Value = produit.QuantityPerUnit;
            prix.Value = produit.UnitPrice;
            stock.Value = produit.UnitsInStock;
            fournisseur.Value = produit.Fournisseur;

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                command.Parameters.Add(nom);
                command.Parameters.Add(categorieId);
                command.Parameters.Add(qte);
                command.Parameters.Add(prix);
                command.Parameters.Add(stock);
                command.Parameters.Add(fournisseur);

                connect.Open();
                id = (int)command.ExecuteScalar();
            }
            return id;
        }

        public static void RemoveProduitBD(Produit produit)
        {
            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"delete from Products where ProductID =@id ";

            var param = new SqlParameter("@id", DbType.Int16);
            param.Value = produit.IdProduit;

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                command.Parameters.Add(param);
                
               connect.Open();
               command.ExecuteNonQuery();           
            }
        }
    }
}
