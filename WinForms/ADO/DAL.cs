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
            using (var connect = new SqlConnection(connectString))
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
            if (!reader.IsDBNull(2))
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
                UnitsInStock, SupplierID from Products where Discontinued = 0 ";
            //string queryString = @"select P.ProductID, P.ProductName, C.CategoryID, P.QuantityPerUnit, 
            //P.UnitPrice, P.UnitsInStock, S.SupplierID,C.CategoryName, S.SupplierID
            //from Products P
            //inner join Categories C on C.CategoryID = P.CategoryID
            //inner join Suppliers S on S.SupplierID = P.SupplierID ";

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
            if (reader["CategoryID"] != DBNull.Value)
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
            string queryString2 = @"select CategoryID from Categories";
            string queryString3 = @"insert Categories(CategoryName) values (@categoryName)";

            var param1 = new SqlParameter("@nom", DbType.String);
            var categorieId = new SqlParameter("@categorieId", DbType.Int16);
            var param3 = new SqlParameter("@qte", DbType.String);
            var param4 = new SqlParameter("@prix", DbType.Decimal);
            var param5 = new SqlParameter("@stock", DbType.Int16);
            var param6 = new SqlParameter("@fournisseur", DbType.Int32);
            var categoryName = new SqlParameter("@categoryName", DbType.String);
            param1.Value = produit.Nom;
            categorieId.Value = produit.Categorie;
            param3.Value = produit.QuantityPerUnit;
            param4.Value = produit.UnitPrice;
            param5.Value = produit.UnitsInStock;
            param6.Value = produit.Fournisseur;
            categoryName.Value = "Autres produits";

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();

                SqlTransaction tran = connect.BeginTransaction();

                try
                {
                    //Je mets à jour la liste de catégorie
                    var command2 = new SqlCommand(queryString2, connect, tran);

                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GetIdCategorieFormDataReader(ListeCategoryId, reader);
                        }
                    }
                    //La catégorie entrée existe -t elle?
                    if (!ListeCategoryId.Contains(produit.Categorie))
                    {
                        var command3 = new SqlCommand(queryString3, connect, tran);
                        //command3.Parameters.Add(categorieId);
                        command3.Parameters.Add(categoryName);
                        command3.ExecuteNonQuery();
                    }
                    //Mettre var command et ajout des paramètres hors des try. On peut mettre dans une région paramètres
                    var command = new SqlCommand(queryString, connect, tran);
                    command.Parameters.Add(param1);
                    command.Parameters.Add(categorieId);
                    command.Parameters.Add(param3);
                    command.Parameters.Add(param4);
                    command.Parameters.Add(param5);
                    command.Parameters.Add(param6);


                    command.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }

            }
        }

        private static void GetIdCategorieFormDataReader(List<int> CatIdList, SqlDataReader reader)
        {
            int id = (int)reader["CategoryID"];
            CatIdList.Add(id);
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

        //Insertion d'un liste de produits en base avec requête de de masse
        public static void AjoutMasseProduitsBD(BindingList<Produit> listprod)
        {
            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"insert Products(ProductName,CategoryID,QuantityPerUnit,UnitPrice,
                UnitsInStock,SupplierID)select NomProduit,IdCategorie,QuantityPerUnit,UnitPrice,
                UnitsInStock,SupplierID from @table";

            //Création du paramètre de type table mémoire
            var param = new SqlParameter("@table", SqlDbType.Structured);
            DataTable tableProduits = GetDataTableForProduits(listprod);
            param.TypeName = "TypeTableProduit";
            param.Value = tableProduits;

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();
                SqlTransaction tran = connect.BeginTransaction();

                try
                {
                    var command = new SqlCommand(queryString, connect, tran);
                    command.Parameters.Add(param);
                    command.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        //Suppression de masse d'une liste de produits: On rend juste les produits obsolètes
        public static void RemoveMasseProduitBD(List<int> ListIdProduit)
        {
            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"update Products set Discontinued = 1 from Products P
                inner join @table t on t.IdProduit = P.ProductID
                where P.CategoryID = 1";

            var param = new SqlParameter("@table", SqlDbType.Structured);
            DataTable tableProduitsDel = GetDataTableForDelProduits(ListIdProduit);
            param.TypeName = "TypeTableProduitSuppr";
            param.Value = tableProduitsDel;

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                command.Parameters.Add(param);

                connect.Open();
                command.ExecuteNonQuery();
            }
        }

        //Création et remplissage d'une table mémoire à partir d'une liste de produits
        private static DataTable GetDataTableForProduits(BindingList<Produit> listProd)
        {
            //Création de la table mémoire
            DataTable table = new DataTable();


            //Création des colonnes et ajout à la table
            #region Colonnes table
            var colNomproduit = new DataColumn("ProductName", typeof(string));
            colNomproduit.AllowDBNull = false;
            table.Columns.Add(colNomproduit);

            var colIdCategorie = new DataColumn("IdCategorie", typeof(int));
            colIdCategorie.AllowDBNull = false;
            table.Columns.Add(colIdCategorie);

            table.Columns.Add(new DataColumn("QuantityPerUnit", typeof(string)));

            var colUnitPrice = new DataColumn("UnitPrice", typeof(decimal));
            table.Columns.Add(colUnitPrice);

            var colUnitsInStock = new DataColumn("UnitsInStock", typeof(int));
            table.Columns.Add(colUnitsInStock);

            var colSupplierID = new DataColumn("SupplierID", typeof(int));
            colSupplierID.AllowDBNull = false;
            table.Columns.Add(colSupplierID);
            #endregion

            //Chargement de la liste de produits dans la table
            foreach (var p in listProd)
            {
                DataRow ligne = table.NewRow();

                ligne["ProductName"] = p.Nom;
                ligne["IdCategorie"] = p.Categorie;
                if (p.QuantityPerUnit != null)
                    ligne["QuantityPerUnit"] = p.QuantityPerUnit;
                else
                    ligne["QuantityPerUnit"] = DBNull.Value;
                if (p.UnitPrice != null)
                    ligne["UnitPrice"] = p.UnitPrice;
                else
                    ligne["UnitPrice"] = DBNull.Value;
                if (p.UnitsInStock != null)
                    ligne["UnitsInStock"] = p.UnitsInStock;
                else
                    ligne["UnitsInStock"] = DBNull.Value;
                ligne["SupplierID"] = p.Fournisseur;

                table.Rows.Add(ligne);
            }
            return table;
        }

        //Création et remplissage d'une table mémoire à partir d'une liste d'id produits à supprimer
        private static DataTable GetDataTableForDelProduits(List<int> listIdProd)
        {
            //Création de la table mémoire
            DataTable table = new DataTable();


            //Création des colonnes et ajout à la table
            var colIdproduit = new DataColumn("IdProduit", typeof(string));
            colIdproduit.AllowDBNull = false;
            table.Columns.Add(colIdproduit);

            //Chargement de la liste de produits dans la table
            foreach (var p in listIdProd)
            {
                DataRow ligne = table.NewRow();

                ligne["IdProduit"] = p;
                table.Rows.Add(ligne);
            }
            return table;
        }

        //Récupérer une liste d'employés de la BD pour charger la liste déroulante
        public static BindingList<Personne> GetListePersonnes()
        {
            var listPersonnes = new BindingList<Personne>();

            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"select E.EmployeeID, E.LastName, E.FirstName, R.RegionID, 
                R.RegionDescription, T.TerritoryID, T.TerritoryDescription
                from Region R 
                inner join Territories T on R.RegionID = T.RegionID
                inner join EmployeeTerritories ET on ET.TerritoryID = T.TerritoryID
                right outer join Employees E on ET.EmployeeID = E.EmployeeID";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetPersonnesRegionsFromDataReader(listPersonnes, reader);
                    }
                }
            }

            return listPersonnes;
        }

        private static void GetPersonnesRegionsFromDataReader(BindingList<Personne> listPersonnes, SqlDataReader reader)
        {
            var pers = new Personne();

            pers.IdPersonne = (int)reader["E.EmployeeID"];
            //prod.IdProduit = (int)reader["ProductID"];
            //prod.Nom = (string)reader["ProductName"];
            //if (reader["CategoryID"] != DBNull.Value)
            //    prod.Categorie = (int)reader["CategoryID"];
            //if (reader["QuantityPerUnit"] != DBNull.Value)
            //    prod.QuantityPerUnit = (string)reader["QuantityPerUnit"];
            //if (reader["UnitPrice"] != DBNull.Value)
            //    prod.UnitPrice = (decimal)reader["UnitPrice"];
            //if (reader["UnitsInStock"] != DBNull.Value)
            //    prod.UnitPrice = (Int16)reader["UnitsInStock"];
            //if (reader["SupplierID"] != DBNull.Value)
            //    prod.Fournisseur = (int)reader["SupplierID"];

            listPersonnes.Add(pers);
        }
    }
}
