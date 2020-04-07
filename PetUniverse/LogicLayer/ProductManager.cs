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
        /// Created: 2020/03/17
        /// Approver: Jaeho Kim
        /// 
        /// Add a new product to the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="product">Product to add</param>
        /// <returns></returns>
        public bool AddProduct(Product product)
        {
            bool success = false;

            try
            {
                success = (1 == _productAccessor.InsertProduct(product));
            }
            catch (Exception)
            {
                throw;
            }
            return success;
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
            List<Product> products = new List<Product>();
            try
            {
                products = _productAccessor.SelectProductByType(type);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
            return products;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Retrieves a list of all the Product Type IDs from the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public List<string> RetrieveAllProductTypeIDs()
        {
            List<string> types = new List<string>();
            try
            {
                types = _productAccessor.SelectAllProductTypeIDs();
            }
            catch (Exception)
            {
                throw;
            }
            return types;
        }
    }
}
