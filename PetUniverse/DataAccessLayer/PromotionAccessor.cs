using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/10
    /// Approver:
    /// 
    /// Concrete implementation of the IPromotionAccessor interface for SQLEXPRESS technology.
    /// </summary>
    public class PromotionAccessor : IPromotionAccessor
    {
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// SQLEXPRESS implementation of adding a new promotion to the database.
        /// </summary>
        /// <returns></returns>
        public int InsertNewPromotion(Promotion promotion)
        {
            int rows = 0;

            var conn = DBConnection.GetConnection();
            string cmdText = @"sp_insert_promotion";
            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);
            cmd.Parameters.AddWithValue("@PromotionTypeID", promotion.PromotionTypeID);
            cmd.Parameters.AddWithValue("@StartDate", promotion.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", promotion.EndDate);
            cmd.Parameters.AddWithValue("@Discount", promotion.Discount);
            cmd.Parameters.AddWithValue("@Description", promotion.Description);

            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            if (rows == 1)
            {
                insertPromoProducts(promotion);
            }
            return rows;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Retrieves all promotion types from the data base.
        /// </summary>
        /// <returns></returns>
        public List<string> SelectAllPromotionTypes()
        {
            List<string> types = new List<string>();

            var cmdText = @"sp_retrieve_promotiontypes";
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand(cmdText, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        types.Add(reader.GetString(0));
                    }
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

            return types;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson
        /// 
        /// Saves products to database with related promotion id.
        /// </summary>
        /// <param name="promotion"></param>
        private void insertPromoProducts(Promotion promotion)
        {
            foreach (Product p in promotion.Products)
            {
                var cmdText = "sp_insert_promo_product";
                var conn = DBConnection.GetConnection();

                var cmd = new SqlCommand(cmdText, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PromotionID", promotion.PromotionID);
                cmd.Parameters.AddWithValue("@ProductID", p.ProductID);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
