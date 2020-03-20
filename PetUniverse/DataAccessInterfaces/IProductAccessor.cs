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
        List<Product> SelectProductByType(string type = "All");

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/1/2020
        /// APPROVER: Robert Holmes
        /// 
        /// 
        /// The method is used to update the product.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        int UpdateProduct(Product oldProduct, Product newProduct);

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/1/2020
        /// APPROVER: Robert Holmes
        /// 
        /// The method is used to select all the products on the product.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        List<Product> SelectAllProducts();
    }
}
