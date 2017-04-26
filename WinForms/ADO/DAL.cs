using System;
using System.Collections.Generic;
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
    }
}
