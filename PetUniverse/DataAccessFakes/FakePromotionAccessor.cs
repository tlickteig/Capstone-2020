using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/03/13
    /// Approver: Cash Carlson
    /// 
    /// Fakes information for testing PromotionManager.
    /// </summary>
    public class FakePromotionAccessor : IPromotionAccessor
    {
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/13
        /// Approver: Cash Carlson
        /// 
        /// Fake inserts a new promotion.
        /// </summary>
        /// <param name="promotion"></param>
        /// <returns></returns>
        public int InsertNewPromotion(Promotion promotion)
        {
            int rows = 0;
            List<Promotion> promotions = new List<Promotion>();
            promotions.Add(promotion);
            if (promotions.Contains(promotion))
            {
                rows++;
            }
            return rows;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/13
        /// Approver: Cash Carlson
        /// 
        /// Returns a list of fake promotion types.
        /// </summary>
        /// <returns></returns>
        public List<string> SelectAllPromotionTypes()
        {
            List<string> list = new List<string>();
            list.Add("Test Type");
            return list;
        }
    }
}
