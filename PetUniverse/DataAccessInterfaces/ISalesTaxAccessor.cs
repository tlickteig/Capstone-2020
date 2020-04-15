using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/13
    /// Approver: Rob Holmes
    /// 
    /// Interfaces for Sales Tax.
    /// </summary>
    public interface ISalesTaxAccessor
    {
        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/13
        /// APPROVER: Rob Holmes
        ///
        /// Interface method signature for Inserting Sales Tax Data.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="salesTax"></param>
        /// <returns>rows effected.</returns>
        int InsertSalesTax(SalesTax salesTax);
    }
}
