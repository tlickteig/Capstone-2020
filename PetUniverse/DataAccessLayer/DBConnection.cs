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
        //@"Data Source=localhost\sqlexpress;Initial Catalog=PetUniverseDB; Integrated Security = True";

        @"Data Source=tcp: dbpetuniverse.database.windows.net,1433;Initial Catalog = PetUniverseDB; Persist Security Info=False;User ID = csdadmin; Password=Kirkwood01; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";
        
        //@"Data Source=LAPTOP-T3PUJGNB\SQLEXPRESS;Initial Catalog=PetUniverseDB;Integrated Security=True";

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
