using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: Dalton Reierson
    /// Approver: Jesse Tomash
    ///
    /// The Accessor class for Item.
    /// </summary>
    public class ItemAccessor : IItemAccessor
    {

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method to create a new item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public bool addNewItem(Item item)
        {
            bool result = false;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_add_items", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@ItemName", item.ItemName);
            cmd.Parameters.AddWithValue("@ItemQuantity", item.ItemQuantity);
            cmd.Parameters.AddWithValue("@ItemCategoryID", item.ItemCategoryID);
            cmd.Parameters.AddWithValue("@ItemDescription", item.Description);

            try
            {
                conn.Open();
                result = 1 == cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/23
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method that gets a list of all items for inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<Item> getAllItems()
        {
            List<Item> items = new List<Item>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_retrieve_items", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    items.Add(new Item()
                    {
                        ItemID = reader.GetInt32(0),
                        ItemName = reader.GetString(1),
                        ItemQuantity = reader.GetInt32(2),
                        ItemCategoryID = reader.GetString(3)
                    });
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return items;
        }
    }
}
