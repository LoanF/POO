using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DigitalFishing

{
    public class Bdd
    {
        private static MySqlConnection connection;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;



        //Initialisation des valeurs
        public static void Initialize()
        {
            server = "localhost";
            database = "digitalfishing";
            uid = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                Console.WriteLine("Erreur connexion BDD");
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public static void InsertMagazine(string dateB, string dateP, string datePt, double budget)
        {
            //Requête Insertion Magazine
            string query = "INSERT INTO Magazine (DateBouclageMagazine, DateSortieMagazine, DatePaiementMagazine, BudgetMagazine) VALUES('" + dateB + "','" + dateP + "','" + datePt + "'," + budget + ")";
            
            //open connection
            if (Bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }
        public static void InsertPigiste(string nomP, string prenomP, string adresseP, string CPP, string villeP, string mailP, string numSecuP, string ccP)
        {
            //Requête Insertion Pigiste
            string query = "INSERT INTO Pigiste (NomPigiste, PrenomPigiste, AdressePigiste, CpPigiste, VillePigiste, MailPigiste, NumSecuPigiste, ContratCadrePigiste) VALUES('" + nomP + "','" + prenomP + "','" + adresseP + "','" + CPP + "','" + villeP + "','" + mailP + "','" + numSecuP + "'," + ccP + ")";

            //open connection
            if (Bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }
        public static void InsertContrat(string la, double mttB, double mttN, int etat, bool fact, bool agessa, Pigiste lePigiste, Magazine leMagazine)
        {
            //Requête Insertion Contrat
            string query = "INSERT INTO Contrat (LettreAccordContrat, MontantBContrat, MontantNContrat, EtatContrat, FactureContrat, AgessaContrat, PigisteContrat, MagazineContrat) VALUES('" + la + "','" + mttB + "','" + mttN + "','" + etat + "','" + fact + "','" + agessa + "','" + lePigiste + "'," + leMagazine + ")";

            //open connection
            if (Bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }


        public static void UpdateMagazine(int numM, string dateB, string dateP, string datePt, double budget)
        {
            //Update Magazine
            string query = "UPDATE Magazine SET DateBouclageMagazine='" + dateB + "', DateSortieMagazine='" + dateP + "', DatePaiementMagazine='" + datePt + "', BudgetMagazine = " + budget + " WHERE NumMagazine=" + numM;
            Console.WriteLine(query);
            //Open connection
            if (Bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }
        public static void UpdatePigiste(int numP, string nomP, string prenomP, string adresseP, string CPP, string villeP, string mailP, string numSecuP, string ccP)
        {
            //Update Pigiste
            string query = "UPDATE Pigiste SET NumPigiste='" + numP + "', NomPigiste='" + nomP + "', PrenomPigiste='" + prenomP + "', AdressePigiste ='" + adresseP + "', CpPigiste ='" + CPP + "', VillePigiste ='" + villeP + "', MailPigiste ='" + mailP + "', NumSecuPigiste ='" + numSecuP + "', ContratCadrePigiste = " + ccP + " WHERE NumPigiste=" + numP;
            Console.WriteLine(query);
            //Open connection
            if (Bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }
        public static void UpdateContrat(int numC, string la, double mttB, double mttNet, int etat, bool fact, bool agessa, int NumPigiste, int NumMagazine)
        {
            //Update Contrat
            string query = "UPDATE Contrat SET NumContrat='" + numC + "', LettreAccordContrat='" + la + "', MontantBContrat='" + mttB + "', MontantNContrat ='" + mttNet + "', EtatContrat ='" + etat + "', FactureContrat ='" + fact + "', AgessaContrat ='" + agessa + "', PigisteContrat ='" + NumPigiste + "', MagazineContrat = " + NumMagazine + " WHERE NumContrat=" + numC;
            Console.WriteLine(query);
            //Open connection
            if (Bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                Bdd.CloseConnection();
            }
        }


        public static void DeleteMagazine(int numM)
        {
            //Delete Magazine
            string query = "DELETE FROM Magazine WHERE NumMagazine=" + numM;

            if (Bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Bdd.CloseConnection();
            }
        }
        public static void DeletePigiste(int numP)
        {
            //Delete Pigiste
            string query = "DELETE FROM Pigiste WHERE NumPigiste=" + numP;

            if (Bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Bdd.CloseConnection();
            }
        }
        public static void DeleteContrat(int numC)
        {
            //Delete Contrat
            string query = "DELETE FROM Contrat WHERE NumContrat=" + numC;

            if (Bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                Bdd.CloseConnection();
            }
        }


        public static List<Magazine> SelectMagazine()
        {
            //Select statement
            string query = "SELECT * FROM Magazine";

            //Create a list to store the result
            List<Magazine> dbMagazine = new List<Magazine>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Magazine leMagazine = new Magazine(Convert.ToInt16(dataReader["NumMagazine"]), Convert.ToString(dataReader["DateBouclageMagazine"]), Convert.ToString(dataReader["DateSortieMagazine"]), Convert.ToString(dataReader["DatePaiementMagazine"]), Convert.ToInt16(dataReader["BudgetMagazine"]));
                    dbMagazine.Add(leMagazine);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbMagazine;
            }
            else
            {
                return dbMagazine;
            }
        }
        public static List<Pigiste> SelectPigiste()
        {
            //Select statement
            string query = "SELECT * FROM Pigiste";

            //Create a list to store the result
            List<Pigiste> dbPigiste = new List<Pigiste>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Pigiste lePigiste = new Pigiste(Convert.ToInt16(dataReader["NumPigiste"]), Convert.ToString(dataReader["NomPigiste"]), Convert.ToString(dataReader["PrenomPigiste"]), Convert.ToString(dataReader["AdressePigiste"]), Convert.ToString(dataReader["CpPigiste"]), Convert.ToString(dataReader["VillePigiste"]), Convert.ToString(dataReader["MailPigiste"]), Convert.ToString(dataReader["NumSecuPigiste"]), Convert.ToString(dataReader["ContratCadrePigiste"]));
                    dbPigiste.Add(lePigiste);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbPigiste;
            }
            else
            {
                return dbPigiste;
            }
        }
        public static List<Contrat> SelectContrat()
        {
            //Select statement
            string query = "SELECT * FROM Contrat, Pigiste, Magazine INNER JOIN Pigiste ON Pigiste.NumPigiste = Contrat.NumPigiste INNER JOIN Magazine ON Magazine.NumPigiste = Contrat.NumPigiste";

            //Create a list to store the result
            List<Contrat> dbContrat = new List<Contrat>();

            //Ouverture connection
            if (Bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Pigiste lePigiste = new Pigiste(Convert.ToInt16(dataReader["NumPigiste"]), Convert.ToString(dataReader["NomPigiste"]), Convert.ToString(dataReader["PrenomPigiste"]), Convert.ToString(dataReader["AdressePigiste"]), Convert.ToString(dataReader["CpPigiste"]), Convert.ToString(dataReader["VillePigiste"]), Convert.ToString(dataReader["MailPigiste"]), Convert.ToString(dataReader["NumSecuPigiste"]), Convert.ToString(dataReader["ContratCadrePigiste"]));
                    Magazine leMagazine = new Magazine(Convert.ToInt16(dataReader["NumMagazine"]), Convert.ToString(dataReader["DateBouclageMagazine"]), Convert.ToString(dataReader["DateSortieMagazine"]), Convert.ToString(dataReader["DatePaiementMagazine"]), Convert.ToInt16(dataReader["BudgetMagazine"]));
                    Contrat leContrat = new Contrat(Convert.ToInt16(dataReader["NumContrat"]), Convert.ToString(dataReader["LettreAccordContrat"]), Convert.ToInt16(dataReader["MontantBContrat"]), Convert.ToInt16(dataReader["MontantNContrat"]), Convert.ToBoolean(dataReader["AgessaContrat"]), Convert.ToBoolean(dataReader["FactureContrat"]), Convert.ToInt16(dataReader["EtatContrat"]), lePigiste, leMagazine);
                    dbContrat.Add(leContrat);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                Bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbContrat;
            }
            else
            {
                return dbContrat;
            }
        }

        public static Pigiste SearchPigiste(int numP)
        {
            //Select statement
            string query = "SELECT * FROM Pigiste WHERE NumPigiste = " + numP;

            //Create a list to store the result
            List<Pigiste> dbPigiste = new List<Pigiste>();


            //Creation Command MySQL
            MySqlCommand cmdS = new MySqlCommand(query, connection);
            //Création d'un DataReader et execution de la commande
            MySqlDataReader dataReaderS = cmdS.ExecuteReader();

            //Lecture des données et stockage dans la collection
            while (dataReaderS.Read())
            {
                Pigiste lePigiste = new Pigiste(Convert.ToInt32(dataReaderS["NumPigiste"]), Convert.ToString(dataReaderS["NomPigiste"]), Convert.ToString(dataReaderS["PrenomPigiste"]), Convert.ToString(dataReaderS["AdressePigiste"]), Convert.ToString(dataReaderS["CPPigiste"]), Convert.ToString(dataReaderS["VillePigiste"]), Convert.ToString(dataReaderS["EmailPigiste"]), Convert.ToString(dataReaderS["NumSecuPigiste"]), Convert.ToString(dataReaderS["ContratCadrePigiste"]));
                dbPigiste.Add(lePigiste);
            }

            //fermeture du Data Reader
            dataReaderS.Close();

            //retour de la collection pour être affichée
            return dbPigiste[0];
        }
        public static Magazine SearchMagazine(int numM)
        {
            //Select statement
            string query = "SELECT * FROM Magazine WHERE NumMagazine = " + numM;

            //Create a list to store the result
            List<Magazine> dbMagazine = new List<Magazine>();


            //Creation Command MySQL
            MySqlCommand cmdS = new MySqlCommand(query, connection);
            //Création d'un DataReader et execution de la commande
            MySqlDataReader dataReaderS = cmdS.ExecuteReader();

            //Lecture des données et stockage dans la collection
            while (dataReaderS.Read())
            {
                Magazine leMagazine = new Magazine(Convert.ToInt16(dataReaderS["NumMagazine"]), Convert.ToString(dataReaderS["DateBouclageMagazine"]), Convert.ToString(dataReaderS["DateSortieMagazine"]), Convert.ToString(dataReaderS["DatePaiementMagazine"]), Convert.ToInt16(dataReaderS["BudgetMagazine"]));
                dbMagazine.Add(leMagazine);
            }

            //fermeture du Data Reader
            dataReaderS.Close();

            //retour de la collection pour être affichée
            return dbMagazine[0];
        }
    }
}


