using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/02/14
    /// Approver: Cash Carlson
    /// 
    /// Handles data requests from the presentation layer by requesting data from the data access layer.
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public class ProductManager : IProductManager
    {
        private IProductAccessor _productAccessor;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Instanciates product accessor with real data.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public ProductManager()
        {
            _productAccessor = new ProductAccessor();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Instanciates product accessor with custom defined data for testing.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="productAccessor">Product accessor class to use</param>
        public ProductManager(IProductAccessor productAccessor)
        {
            _productAccessor = productAccessor;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Retrieves a list of all the products that match a certain type (or all if no type is provided)
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// /// <param name="type">Product type to search by</param>
        public List<Product> RetrieveAllProductsByType(string type = "All")
        {
            try
            {
                return _productAccessor.SelectProductByType(type);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/1/2020
        /// APPROVER: Robert Holmes
        /// 
        /// Update a field of the product .
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public bool EditProduct(Product oldProduct, Product newProduct)
        {
            bool result = false;

            try
            {
                result = _productAccessor.UpdateProduct(oldProduct, newProduct) == 1;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed", ex);
            }

            return result;
        }

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// CREATED: 3/3/2020
        /// APPROVER: Robert Holmes
        /// 
        /// Retrieves a list of all the products .
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        /// 
        public List<Product> RetrieveAllProducts()
        {
            List<Product> result = null;
            try
            {

                result = _productAccessor.SelectAllProducts();

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);

            }

        }

    }
}
