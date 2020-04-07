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
    /// Created: 2020/02/14
    /// Approver: Cash Carlson
    /// 
    /// Interface for product data accessor to facilitate loose coupling.
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public interface IProductAccessor
    {
        /// /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/14
        /// Approver: Cash Carlson
        /// 
        /// Interface for a method to get all products by product type.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="type"></param>
        /// <returns></returns>
        List<Product> SelectProductByType(string type = "All");

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to insert a new product.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        int InsertProduct(Product product);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to retrieve all ProductTypeIDs from the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <returns></returns>
        List<string> SelectAllProductTypeIDs();
    }
}
