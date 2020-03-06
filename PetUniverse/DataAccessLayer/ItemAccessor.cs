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
        /// Updated By: Brandyn T. Coverdill
        /// Updated: 2020/03/03
        /// Update: The Item Description was not getting fetched into the datagrid, so I added that field.
        /// Approver:  Jesse Tomash
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
                        ItemCategoryID = reader.GetString(3),
                        Description = reader.GetString(4)
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

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/04
        /// Approver: 
        /// Approver:  
        ///
        /// Method that updates an item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="newDesc"></param>
        /// <param name="newName"></param>
        /// <param name="newQuantity"></param>
        /// <param name="oldDesc"></param>
        /// <param name="oldName"></param>
        /// <param name="oldQuantity"></param>
        public int updateItemDetail(string oldName, string oldDesc, int oldQuantity, string newName, string newDesc, int newQuantity)
        {
            int result = 0;

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_update_specific_item", conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OldItemName", oldName);
            cmd.Parameters.AddWithValue("@OldItemDescription", oldDesc);
            cmd.Parameters.AddWithValue("@OldItemQuantity", oldQuantity);
            cmd.Parameters.AddWithValue("@NewItemName", newName);
            cmd.Parameters.AddWithValue("@NewItemDescription", newDesc);
            cmd.Parameters.AddWithValue("@NewItemQuantity", newQuantity);

            try
            {
                conn.Open();

                result = cmd.ExecuteNonQuery();
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
    }
}
