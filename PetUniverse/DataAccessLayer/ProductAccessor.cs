using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Robert Holmes
    /// DATE: 2/14/2020
    /// CHECKED BY: Cash Carlson
    /// 
    /// Retrieves records from permanent storage for products.
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATED DATE: 
    /// CHANGES: 
    /// 
    /// </remarks>
    public class ProductAccessor : IProductAccessor
    {
        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Queries the SQL database for a list of products that match the supplied type (or all if no type is supplied).
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public List<Product> SelectProductByType(string type = "All")
        {
            List<Product> products = new List<Product>();

            var conn = DBConnection.GetConnection();
            SqlCommand cmd; 
            if (type.Equals("All"))
            {
                cmd = new SqlCommand("sp_select_all_products", conn);
                cmd.CommandType = CommandType.StoredProcedure;
            }
            else
            {
                cmd = new SqlCommand("sp_select_products_by_type", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ProductTypeID", type);
            }
            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product p = new Product();
                        p.ProductID = reader.GetString(0);
                        p.ItemID = reader.GetInt32(1);
                        p.Name = reader.GetString(2);
                        p.Category = reader.GetString(3);
                        p.Type = reader.GetString(4);
                        p.Description = reader.GetString(5);
                        p.Price = reader.GetDecimal(6);
                        p.Brand = reader.GetString(7);
                        p.Taxable = reader.GetBoolean(8);

                        products.Add(p);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return products;
        }
    }
}
