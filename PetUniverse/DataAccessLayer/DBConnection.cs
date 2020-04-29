using System.Data.SqlClient;

namespace DataTransferObjects
{
    /// <summary>
    /// CREATED BY: Zach Behrensmeyer
    /// DATE: 2/3/2020
    /// CHECKED BY: Steven Cardona
    /// 
    /// This class creates the connection to the database
    /// </summary>
    internal static class DBConnection
    {
        private static string connectionString =



        // Connection String for home
        @"Data Source=localhost\sqlexpress;Initial Catalog=PetUniverseDB; Integrated Security = True";

        @"Server = tcp:dbpetuniverse.database.windows.net,1433;Initial Catalog = PetUniverseDB; Persist Security Info=False;User ID = csdadmin; Password=Kirkwood01; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

<<<<<<< HEAD
    //Connection string for school
    //@"Data Source=localhost;Initial Catalog=PetUniverseDB;Integrated Security=True"; // Connection string for school
=======
        //Connection string for school
        //@"Data Source=localhost;Initial Catalog=PetUniverseDB;Integrated Security=True"; // Connection string for school
>>>>>>> 8b8ce52839d20b743adf3af79fbbbb7d67bb015f


    //@"Data Source=LAPTOP-T3PUJGNB\SQLEXPRESS;Initial Catalog=PetUniverseDB;Integrated Security=True";

    private static string createConnectionString()
        {
            var sqlConnectionSB = new SqlConnectionStringBuilder();

            // Change these values to your values.  
            sqlConnectionSB.DataSource = "tcp:dbpetuniverse.database.windows.net"; //["Server"]  
            sqlConnectionSB.InitialCatalog = "PetUniverseDB"; //["Database"]  

            sqlConnectionSB.UserID = "csdadmin"; // "@yourservername"  as suffix sometimes.  
            sqlConnectionSB.Password = "Kirkwood01";
            sqlConnectionSB.IntegratedSecurity = false;

            // Adjust these values if you like. (ADO.NET 4.5.1 or later.)  
            sqlConnectionSB.ConnectRetryCount = 3;
            sqlConnectionSB.ConnectRetryInterval = 10; // Seconds.  

            // Leave these values as they are.  
            sqlConnectionSB.IntegratedSecurity = false;
            sqlConnectionSB.Encrypt = true;
            sqlConnectionSB.ConnectTimeout = 30;

            return sqlConnectionSB.ToString();

        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/3/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// Method that hands back connection string when called
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <returns>SQL Connection String</returns>
        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(connectionString);
            return conn;
        }
    }
}
