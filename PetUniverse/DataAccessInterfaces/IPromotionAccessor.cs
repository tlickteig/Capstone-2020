using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/10
    /// Approver: Cash Carlson
    /// 
    /// Interface for promotion accessor.
    /// </summary>
    public interface IPromotionAccessor
    {
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Method to add a new promotion to the database.
        /// </summary>
        /// <param name="promotion">The promotion to be added.</param>
        /// <returns>Int number of rows affected (should be 1)</returns>
        int InsertNewPromotion(Promotion promotion);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Method to get all of the IDs of all PromotionTypes from the database.
        /// </summary>
        /// <returns>List of promotion types</returns>
        List<string> SelectAllPromotionTypes();
    }
}
