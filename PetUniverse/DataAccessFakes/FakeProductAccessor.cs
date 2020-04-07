using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Robert Holmes
    /// Created: 2020/02/14
    /// Approver: Cash Carlson
    /// 
    /// Fake product accessor for testing purposes.
    /// </summary>
    public class FakeProductAccessor : IProductAccessor
    {
        private List<Product> products;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson
        /// 
        /// Sets up fake data for testing purposes.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public FakeProductAccessor()
        {
            products = new List<Product>()
            {
                new Product()
                {
                    ProductID = "1234567890120",
                    ItemID = 0,
                    Name = "Test",
                    Category = "Test Category",
                    Type = "Test Type",
                    Description = "A test product description.",
                    Price = 0.50M,
                    Brand = "Test Brand",
                    Taxable = true
                },
                new Product()
                {
                    ProductID = "1234567890120",
                    ItemID = 0,
                    Name = "Test",
                    Category = "Test Category",
                    Type = "Test Type 2",
                    Description = "A test product description.",
                    Price = 0.50M,
                    Brand = "Test Brand",
                    Taxable = true
                }
            };
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: Jaeho Kim
        /// 
        /// Tests whether the manager correctly calls the add method.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="product"></param>
        /// <returns></returns>
        public int InsertProduct(Product product)
        {
            int rows = 0;
            bool duplicate = false;
            foreach (Product p in products)
            {
                if (p.ProductID == product.ProductID)
                {
                    duplicate = true;
                    break;
                }
            }

            if (duplicate)
            {
                throw new ApplicationException("Duplicate Item Detected.");
            }
            else
            {
                products.Add(product);
                rows++;
            }
            return rows;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: Jaeho Kim
        /// 
        /// Method that returns a fake collection of product type ids.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public List<string> SelectAllProductTypeIDs()
        {
            return new List<string> { "Test Type ID" };
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/02/14
        /// Approver: Cash Carlson
        /// 
        /// Returns dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        /// <param name="type">The type of item to filter by.</param>
        public List<Product> SelectProductByType(string type)
        {
            if (!type.Equals("Fail Type"))
            {
                if (type.Equals("All"))
                {
                    return (from p in products
                            select p).ToList();
                }
                else
                {
                    return (from p in products
                            where p.Type == type
                            select p).ToList();
                }

            }
            else
            {
                throw new ApplicationException("Failed to Load Products");
            }
        }
    }
}
