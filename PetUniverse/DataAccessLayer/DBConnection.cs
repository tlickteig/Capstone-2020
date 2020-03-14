using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PetUniverseDB; Integrated Security = True";


        //Connection string for school
        //@"Data Source=localhost;Initial Catalog=PetUniverseDB;Integrated Security=True"; // Connection string for school


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
