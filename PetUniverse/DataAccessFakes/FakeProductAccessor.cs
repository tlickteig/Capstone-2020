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
    /// NAME: Robert Holmes
    /// DATE: 2/14/2020
    /// CHECKED BY: Cash Carlson
    /// 
    /// Fake product accessor for testing purposes.
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATED DATE: 
    /// CHANGES: 
    /// 
    /// </remarks>
    public class FakeProductAccessor : IProductAccessor
    {
        private List<Product> products;

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Sets up fake data for testing purposes.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
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
        /// NAME: Robert Holmes
        /// DATE: 2/14/2020
        /// CHECKED BY: Cash Carlson
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
                if (type.Equals("All")) {
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
