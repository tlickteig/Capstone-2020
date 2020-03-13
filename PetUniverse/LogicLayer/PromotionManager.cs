using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/10
    /// Approver:
    /// 
    /// Concrete implementation of a class for transfer of promotion data from the database to the presentation layer and vice versa.
    /// </summary>
    public class PromotionManager : IPromotionManager
    {
        private IPromotionAccessor _promotionAccessor;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver: Cash Carlson
        /// 
        /// Initializes object with real data.
        /// </summary>
        public PromotionManager()
        {
            _promotionAccessor = new PromotionAccessor();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/12
        /// Approver:
        /// 
        /// Initializes object with alternative data source for testing.
        /// </summary>
        /// <param name="promotionAccessor"></param>
        public PromotionManager(IPromotionAccessor promotionAccessor)
        {
            _promotionAccessor = promotionAccessor;
        }
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Method to add a new promotion to the database.
        /// </summary>
        /// <param name="promotion">The promotion to add to the database</param>
        /// <returns>true if the accessor method returns 1 for rows affected</returns>
        public bool AddPromotion(Promotion promotion)
        {
            bool success = false;

            try
            {
                success = (1 == _promotionAccessor.InsertNewPromotion(promotion));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return success;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: Cash Carlson
        /// 
        /// Retrieves all promotions types.
        /// </summary>
        /// <returns>List of promotion types</returns>
        public List<string> GetAllPromotionTypes()
        {
            return _promotionAccessor.SelectAllPromotionTypes();
        }
    }
}
