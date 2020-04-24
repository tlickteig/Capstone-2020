using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// Creator: Rasha Mohammed
    /// Created: 4/1/2020
    /// Approver: Ethan Holmes
    /// 
    /// Retrieves records from permanent storage for picture.
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public class PictureAccessor : IPictureAccessor
    {
        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/1/2020
        /// Approver: Ethan Holmes
        /// 
        /// This method using queries to select all pictures form database.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public List<Picture> SelectAllPicture()
        {
            List<Picture> pictures = new List<Picture>();

            var conn = DBConnection.GetConnection();
            var cmd = new SqlCommand("sp_select__all_image", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var picture = new Picture();

                        picture.PictureID = reader.GetInt32(0);
                        picture.ProductID = reader.GetString(1);
                        picture.ImagePath = reader.GetString(2);

                        pictures.Add(picture);
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

            return pictures;
        }

    }
}
