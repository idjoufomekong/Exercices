using System;
using System.Collections.Generic;
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
        public static List<ImageSource> GetPictures()
        {
            var listPhotos = new List<ImageSource>();

            var connectString = Properties.Settings.Default.NorthwindConnectionString1;
            string queryString = @"select Photo from Employees";

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                connect.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["Photo"] != DBNull.Value)
                            listPhotos.Add(ConvertBytesToImageSource((byte[])reader["Photo"]));
                    }
                }
            }

            return listPhotos;
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
        public static List<Employe> GetEmployees()
        {
            var listEmpl = new List<Employe>();

            var connectString = Properties.Settings.Default.NorthwindConnectionString1;
            string queryString = @"select E.EmployeeID,E.LastName,E.FirstName,T.TerritoryID,T.TerritoryDescription
from Territories T
inner join EmployeeTerritories ET on ET.TerritoryID=T.TerritoryID
right outer join Employees E on E.EmployeeID=ET.EmployeeID
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
            if ((lstEmpl.Count == 0) || (lstEmpl[lstEmpl.Count - 1].Id != Id))
            {
                var emp = new Employe();
                emp.Id = (int)reader["EmployeeID"];
                emp.Nom = (string)reader["LastName"];
                emp.Prenom = (string)reader["FirstName"];

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
    }
}
