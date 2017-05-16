using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Trombinoscope
{
    public class DAL
    {
        public static List<Employe> GetEmployees()
        {
            var listEmp = new List<Employe>();

            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"select EmployeeID,LastName,FirstName,Photo from Employees";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var emp = new Employe();
                        emp.Id = (int)reader["EmployeeID"];
                        emp.Nom = (string)reader["LastName"];
                        emp.Prenom = (string)reader["FirstName"];
                        if (reader["Photo"] != DBNull.Value)
                            emp.Photo=ConvertBytesToImageSource((byte[])reader["Photo"]);
                        listEmp.Add(emp);
                    }
                }
            }

            return listEmp;
        }

        private static ImageSource ConvertBytesToImageSource(Byte[] tab)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // Les images stockées dans la base Northwind ont un en-tête de 78 octets 
                // qu'il faut enlever pour pouvoir les charger correctement
                ms.Write(tab, 78, tab.Length - 78);
                ImageSource image = BitmapFrame.Create(ms, BitmapCreateOptions.None,
                                      BitmapCacheOption.OnLoad);
                return image;
            }
        }

        //Récupération de la liste des employés avec les territoires associés
        public static List<Employe> GetEmployeesTerritories()
        {
            var listEmpl = new List<Employe>();

            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = @"select E.EmployeeID,E.LastName,E.FirstName,T.TerritoryID,T.TerritoryDescription,E.ReportsTo,
EM.LastName MLastName, EM.FirstName MFirstName
from Territories T
inner join EmployeeTerritories ET on ET.TerritoryID=T.TerritoryID
right outer join Employees E on E.EmployeeID=ET.EmployeeID
left outer join Employees EM on E.ReportsTo=EM.EmployeeID
order by EmployeeID";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        GetEmployesFromDataReader(listEmpl, reader);
                    }
                }
            }

            return listEmpl;
        }

        //Lecture du reader retourné par la requête SQL et construction de l'objet Employé
        private static void GetEmployesFromDataReader(List<Employe> lstEmpl, SqlDataReader reader)
        {
            int Id = (int)reader["EmployeeID"];
            if ((lstEmpl.Count == 0) || lstEmpl.Last().Id!= Id) // (lstEmpl[lstEmpl.Count - 1].Id != Id))
            {
                var emp = new Employe();
                emp.Id = (int)reader["EmployeeID"];
                emp.Nom = (string)reader["LastName"];
                emp.Prenom = (string)reader["FirstName"];
                if (reader["ReportsTo"] != DBNull.Value)
                {
                    emp.IdManager=(int)reader["ReportsTo"];
                    emp.NomManager= (string)reader["MLastName"];
                    emp.PrenomManager= (string)reader["MFirstName"];
                }

                lstEmpl.Add(emp);
                emp.Territoires = new List<Territoire>();
                Id = emp.Id;
            }
            if (reader["TerritoryID"] != DBNull.Value)
            {

            var ter = new Territoire();
                ter.IdTerritoire = (string)reader["TerritoryID"];
            if (reader["TerritoryDescription"] != DBNull.Value)
                ter.NomTerritoire = (string)reader["TerritoryDescription"];

            lstEmpl[lstEmpl.Count - 1].Territoires.Add(ter);
            }
        }

        //Ajout d'un employé en BDD
        public static void AjouterEmploye(Employe emp)
        {
            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString = "insert Employees (LastName,FirstName) values(@prenom,@nom)";

            SqlParameter nom = new SqlParameter("@nom",DbType.String);
            nom.Value = emp.Nom;
            SqlParameter prenom = new SqlParameter("@prenom",DbType.String);
            prenom.Value = emp.Prenom;

            using (var connect = new SqlConnection(connectString))
            {
                    connect.Open();
                SqlTransaction tran = connect.BeginTransaction();

                try
                {
                    var command = new SqlCommand(queryString, connect,tran);
                    command.Parameters.Add(nom);
                    command.Parameters.Add(prenom);

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

        //Suppression d'un employé en BDD
        public static void SupprimerEmploye(Employe emp)
        {
            var connectString = Properties.Settings.Default.NorthwindConnectionString;
            string queryString= "delete from Employees where EmployeeID=@id";

            SqlParameter id = new SqlParameter("@id", DbType.Int16);
            id.Value = emp.Id;

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                command.Parameters.Add(id);
                connect.Open();
                try
                {
                command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
