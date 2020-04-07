using DataTransferObjects;
using System;
using System.Collections;
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
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="promotion">The promotion to add to the database</param>
        /// <returns></returns>
        bool AddPromotion(Promotion promotion);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/19
        /// Approver: Cash Carlson
        /// 
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <returns></returns>
        List<Promotion> GetAllPromotions(bool onlyActive = true);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Retrieves all promotions types.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <returns>List of promotion types</returns>
        List<string> GetAllPromotionTypes();

        /// <summary>
        /// Creator: Robert
        /// Created: 2020/03/19
        /// Approver: 
        /// 
        /// Interface for a method to edit a promotion.
        /// </summary>
        /// <param name="oldPromotion"></param>
        /// <param name="newPromotion"></param>
        /// <returns></returns>
        bool EditPromotion(Promotion oldPromotion, Promotion newPromotion);
    }
}
