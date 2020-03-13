using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/10
    /// Approver: Cash Carlson
    /// 
    /// Interface for transfer of promotion data from the database to the presentation layer and vice versa.
    /// </summary>
    public interface IPromotionManager
    {
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Method to add a new promotion to the database.
        /// </summary>
        /// <param name="promotion">The promotion to add to the database</param>
        /// <returns></returns>
        bool AddPromotion(Promotion promotion);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Retrieves all promotions types.
        /// </summary>
        /// <returns>List of promotion types</returns>
        List<string> GetAllPromotionTypes();
    }
}
