using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 2/18/2020
    /// 
    /// Data Access class for orders
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    public class OrderAccessor : IOrderAccessor
    {
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/18/2020
        /// 
        /// Selects all order Invoices
        /// </summary>
        /// <returns>List of invoices</returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public IEnumerable<Order> SelectOrders()
        {
            List<Order> orderList = new List<Order>();

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_retrieve_all_orders";
            string cmdText2 = @"sp_retrieve_order_by_id";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            SqlCommand cmd2 = new SqlCommand(cmdText2, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    orderList.Add(new Order()
                    {
                        OrderID = reader.GetInt32(0),
                        EmployeeID = reader.GetInt32(1)
                    });
                }

                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return (IEnumerable<Order>)orderList;
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/18/2020
        /// 
        /// Updates an Order Invoice
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <param name="oldOrderInvoice"></param>
        /// <param name="newOrderInvoice"></param>
        /// <returns>1 if successful, 0 if not</returns>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        public int UpdateOrder(Order oldOrder, Order newOrder)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_update_order_by_id";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", oldOrder.OrderID);
            cmd.Parameters.AddWithValue("@EmployeeID", newOrder.EmployeeID);
            cmd.Parameters.AddWithValue("@Active", newOrder.Active);

            cmd.Parameters.AddWithValue("@OldEmployeeID", oldOrder.EmployeeID);
            cmd.Parameters.AddWithValue("@OldActive", oldOrder.Active);
            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/18/2020
        /// 
        /// Inserts a new Order Invoice
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="newOrder"></param>
        /// <returns>1 if successful, 0 if not</returns>
        public int InsertOrder(Order newOrder)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_insert_order";
            var cmd = new SqlCommand(cmdText, conn);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EmployeeID", newOrder.EmployeeID);
            cmd.Parameters.AddWithValue("@Active", newOrder.Active);

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }
        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 2/18/2020
        /// 
        /// Delets an Order Invoice according to its ID
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// <param name="orderInvoiceID">ID of order to be deleted</param>
        /// <returns>1 if successful, 0 if not</returns>
        public int DeleteOrder(int orderID)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();

            var cmdText = @"sp_delete_order_by_id";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@OrderID", orderID);

            try
            {
                cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return rows;
        }
    }
}
