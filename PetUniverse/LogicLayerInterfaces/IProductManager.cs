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
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
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
        /// Creator: Rasha Mohammed
        /// Created: 3/1/2020
        /// Approver: Robert Holmes
        /// 
        /// Interface to update product value from product from old one to new one.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        bool EditProduct(Product oldProduct, Product newProduct);

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/1/2020
        /// APPROVER: Robert Holmes
        /// 
        /// Interface to retrieve all products.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        List<Product> RetrieveAllProducts();

    }
}
