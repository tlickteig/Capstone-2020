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
        @"Data Source=localhost\SQLServer;Initial Catalog=PetUniverseDB; Integrated Security = True";

        //Connection string for school
        //@"Data Source=localhost;Initial Catalog=PetUniverseDB;Integrated Security=True"; // Connection string for school

        // Presentation Connect String **DO NOT REMOVE**
        //@"Data Source=tcp:dbpetuniverse.database.windows.net,1433;Initial Catalog = PetUniverseDB; Persist Security Info=False;User ID = csdadmin; Password=Kirkwood01; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout = 30;";

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
