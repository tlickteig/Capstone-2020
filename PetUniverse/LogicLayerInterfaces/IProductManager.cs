using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/02/14
    /// Approver: Cash Carlson
    /// 
    /// Interface for product manager logic layer class to facilitate loose coupling.
    /// </summary>
    public interface IProductManager
    {
        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Interface to retrieve all products by type.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        List<Product> RetrieveAllProductsByType(string type = "All");

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to add a product.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="product"></param>
        /// <returns></returns>
        bool AddProduct(Product product);

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Interface for a method to retrieve all the product type IDs from the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        List<string> RetrieveAllProductTypeIDs();
    }
}
