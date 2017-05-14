using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using JobOverview.Entites;

namespace JobOverview.DAL
{
    public class DALLogiciel
    {
        /// <summary>
        /// Requete de récupération des informations nécessaire au remplissage de la liste de 
        /// logiciel (incluant la liste de module)
        /// </summary>
        /// <returns>liste de logiciel</returns>
        public static List<Logiciel> GetLogiciel()
        {
            // On récupérer la chaîne de connexion stockée dans le fichier App.config
            var connectString = JobOverView.Properties.Settings.Default.JOConnectString; 

            var logic = new List<Logiciel>();

            string queryString = @"select L.CodeLogiciel, L.Nom, M.CodeModule, M.Libelle           
            from jo.Logiciel L 
            inner join jo.Module M on L.CodeLogiciel = M.CodeLogiciel   
            order by L.CodeLogiciel, L.Nom, M.CodeModule, M.Libelle";

            // On crée une connexion à partir de la chaîne de connexion
            using (var connect = new SqlConnection(connectString))
            {
                // On créé une commande à partir de la requête,
                // et en utilisant la connexion définies précédemment
                var command = new SqlCommand(queryString, connect);

                // On ouvre la connexion
                connect.Open();

                // On exécute la requête en récupérant son résultat 
                // dans un objet SqlDataRedader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // On lit et on affiche les lignes de résultat en boucle
                    while (reader.Read())
                    {
                        GetLogicielFromDataReader(logic, reader);
                    }
                }
            }
            // Le fait d'avoir créé la connexion dans une instruction using
            // permet de la fermer automatiquement à la fin du bloc using
            return logic;
        }

        /// <summary>
        /// Remplissage des listes logiciel/module/version
        /// </summary>
        /// <param name="lstLogiciel"></param>
        /// <param name="reader"></param>
        private static void GetLogicielFromDataReader(List<Logiciel> lstLogiciel, SqlDataReader reader)
        {
            Logiciel log = null;

            // Test si la liste de logiciel est vide ou contient déjà le logiciel du reader
            if (lstLogiciel.Count == 0 || lstLogiciel.Last().CodeLogiciel != (string)reader["CodeLogiciel"])
            {
                log = new Logiciel();
                log.CodeLogiciel = (string)reader["CodeLogiciel"];
                log.Nom = (string)reader["Nom"];
                log.ListeModule = new BindingList<Module>();
                log.ListeVersion = new BindingList<Entites.Version>();

                // Ajout de l'objet logiciel dans la liste
                lstLogiciel.Add(log);
            }
            else
                log = lstLogiciel.Last();

            // Test si la liste de module du logiciel courant est vide ou contient déjà le module du reader
            if (log.ListeModule.Count == 0 || log.ListeModule.Last().CodeModule != (string)reader["CodeModule"])
            {
                var mod = new Entites.Module();
                mod.CodeModule = (string)reader["CodeModule"];
                mod.Libelle = (string)reader["Libelle"];
                log.ListeModule.Add(mod);
            }

            log.ListeVersion = GetVersion(log.CodeLogiciel);
        }

        /// <summary>
        /// Requete de récupération des informations nécessaire au remplissage de la liste de 
        /// Version
        /// </summary>
        /// <param name="codeLogiciel">Code identifiant du logiciel</param>
        /// <returns>liste de version</returns>
        public static BindingList<Entites.Version> GetVersion(string codeLogiciel)
        {
            // On récupérer la chaîne de connexion stockée dans le fichier App.config
            var connectString = JobOverView.Properties.Settings.Default.JOConnectString;

            var vers = new BindingList<Entites.Version>();

            string queryString = @"select V.NumeroVersion, V.DateOuverture, V.DateSortiePrevue, V.Millesime, isnull(MAX(R.NumeroRelease),0) as Release
            from jo.Logiciel L 
            inner join jo.Version V on L.CodeLogiciel = V.CodeLogiciel
            left outer join jo.Release R on V.NumeroVersion = R.NumeroVersion and V.CodeLogiciel = R.CodeLogiciel
            where L.CodeLogiciel = @CodeLogiciel
            group by V.NumeroVersion, V.DateOuverture, V.DateSortiePrevue, V.Millesime
            order by V.NumeroVersion, V.DateOuverture, V.DateSortiePrevue, V.Millesime";

            var param1 = new SqlParameter("@CodeLogiciel" , DbType.String);
            param1.Value = codeLogiciel;

            // On crée une connexion à partir de la chaîne de connexion
            using (var connect = new SqlConnection(connectString))
            {
                // On créé une commande à partir de la requête,
                // et en utilisant la connexion définies précédemment
                var command = new SqlCommand(queryString, connect);
                command.Parameters.Add(param1);

                // On ouvre la connexion
                connect.Open();

                // On exécute la requête en récupérant son résultat 
                // dans un objet SqlDataRedader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // On lit et on affiche les lignes de résultat en boucle
                    while (reader.Read())
                    {
                        GetVersionFromDataReader(vers, reader);
                    }
                }
            }
            // Le fait d'avoir créé la connexion dans une instruction using
            // permet de la fermer automatiquement à la fin du bloc using
            return vers;
        }

        /// <summary>
        /// Remplissage de la liste version
        /// </summary>
        /// <param name="lstVersion">Liste de version</param>
        /// <param name="reader">flux de donnée</param>
        private static void GetVersionFromDataReader(BindingList<Entites.Version> lstVersion, SqlDataReader reader)
        {
            // Remplissage d'un objet Version
            var ver = new Entites.Version();
            ver.NumeroVersion = (float)reader["NumeroVersion"];
            ver.DateOuverture = (DateTime)reader["DateOuverture"];
            ver.DateSortiePrevue = (DateTime)reader["DateSortiePrevue"];
            ver.Millesime = (short)reader["Millesime"];
            ver.NumeroRelease = (short)reader["Release"];
            lstVersion.Add(ver);
        }

        /// <summary>
        /// Suppression d'une version et de toutes ses releases
        /// </summary>
        /// <param name="CodeLogiciel">Logiciel lié à la version</param>
        /// <param name="NumVersion">Numéro de version</param>
        public static void SuppressionVersion(string CodeLogiciel,float NumVersion)
        {
            var connectString = JobOverView.Properties.Settings.Default.JOConnectString;

            string queryString = @"DELETE R FROM jo.Version V 
            INNER JOIN jo.Release R ON V.NumeroVersion = R.NumeroVersion
            WHERE V.CodeLogiciel = @CodeLogiciel AND V.NumeroVersion = @NumVersion";
            var paramCodeLog = new SqlParameter("@CodeLogiciel", DbType.String);
            paramCodeLog.Value = CodeLogiciel;
            var paramNumVer = new SqlParameter("@NumVersion", DbType.Double);
            paramNumVer.Value = NumVersion;

            string queryString2 = @"DELETE B FROM (select * from jo.Version 
            WHERE CodeLogiciel = @CodeLogic AND NumeroVersion = @NumVers) as B";
            var paramCodeLogi = new SqlParameter("@CodeLogic", DbType.String);
            paramCodeLogi.Value = CodeLogiciel;
            var paramNumVers = new SqlParameter("@NumVers", DbType.Double);
            paramNumVers.Value = NumVersion;

            using (var connect = new SqlConnection(connectString))
            {
                connect.Open();
                SqlTransaction tran = connect.BeginTransaction();

                try
                {
                    var command = new SqlCommand(queryString, connect, tran);
                    command.Parameters.Add(paramCodeLog);
                    command.Parameters.Add(paramNumVer);
                    var command2 = new SqlCommand(queryString2, connect, tran);
                    command2.Parameters.Add(paramCodeLogi);
                    command2.Parameters.Add(paramNumVers);

                    command.ExecuteNonQuery();
                    command2.ExecuteNonQuery();

                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }  
            }
        }

        /// <summary>
        /// Calcul le nombre de tache associé à une version
        /// </summary>
        /// <param name="NumVersion">Numéro de la version</param>
        /// <returns>Nombre de tache</returns>
        public static int NbTacheLieVersion (float NumVersion)
        {
            var connectString = JobOverView.Properties.Settings.Default.JOConnectString;

            string queryString = @"Select Count(IdTache) from jo.TacheProd
            where NumeroVersion = @NuVers";
            var paramNuVers = new SqlParameter("@NuVers", DbType.Double);
            paramNuVers.Value = NumVersion;

            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);
                command.Parameters.Add(paramNuVers);
                connect.Open();

                return (int)command.ExecuteScalar();
            }
        }

        /// <summary>
        /// Ajout d'une version dans la base
        /// </summary>
        /// <param name="Version">Version à enregistrer</param>
        /// <param name="CodeLogiciel">Code du logiciel de référence</param>
        public static void AjoutVersion(Entites.Version Version, string CodeLogiciel)
        {
            var connectString = JobOverView.Properties.Settings.Default.JOConnectString;
            string queryString = @"Insert jo.Version 
            (NumeroVersion, CodeLogiciel, Millesime, DateOuverture, DateSortiePrevue)
                Values (@NumeroVersion,@CodeLogiciel,@Millesime,@DateOuverture,@DateSortiePrevu)";


            var prm2 = new SqlParameter("@NumeroVersion", DbType.Decimal);
            prm2.Value = Version.NumeroVersion;
            var prm3 = new SqlParameter("@CodeLogiciel", DbType.String);
            prm3.Value = CodeLogiciel;
            var prm4 = new SqlParameter("@Millesime", DbType.Int16);
            prm4.Value = Version.Millesime;
            var prm5 = new SqlParameter("@DateOuverture", DbType.DateTime);
            prm5.Value = Version.DateOuverture;
            var prm6 = new SqlParameter("@DateSortiePrevu", DbType.DateTime);
            prm6.Value = Version.DateSortiePrevue;


            using (var connect = new SqlConnection(connectString))
            {
                var command = new SqlCommand(queryString, connect);

                command.Parameters.Add(prm2);
                command.Parameters.Add(prm3);
                command.Parameters.Add(prm4);
                command.Parameters.Add(prm5);
                command.Parameters.Add(prm6);

                connect.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
