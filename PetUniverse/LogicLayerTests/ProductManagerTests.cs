using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Robert Holmes
    /// DATE: 2/14/2020
    /// CHECKED BY: Cash Carlson
    /// 
    /// Holds tests for product manager class.
    /// </summary>
    /// <remarks>
    /// UPDATED BY:
    /// UPDATED DATE: 
    /// CHANGES: 
    /// 
    /// </remarks>
    [TestClass]
    public class ProductManagerTests
    {
        private IProductAccessor _productAccessor;

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Load fake product accessor for testing purposes
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _productAccessor = new FakeProductAccessor();
        }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/14/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Tests whether the Product Manager is able to retrieve products from the database.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestProductManagerRetrievesTestsTestType()
        {
            // Arrange
            List<Product> products;
            IProductManager productManager = new ProductManager(_productAccessor);
            string typeToSearch = "Test Type";
            int productsExpected = 1;

            // Act
            products = productManager.RetrieveAllProductsByType(typeToSearch);

            // Assert
            Assert.AreEqual(productsExpected, products.Count);
        }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Tests whether the Product Manager is able to retrieve all products from the database.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestProductManagerRetrievesAllTypes()
        {
            // Arrange
            List<Product> products;
            IProductManager productManager = new ProductManager(_productAccessor);
            int productsExpected = 2;

            // Act
            products = productManager.RetrieveAllProductsByType();

            // Assert
            Assert.AreEqual(productsExpected, products.Count);
        }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Tests whether the Product Manager is able to retrieve products with a mismatched type.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        [TestMethod]
        public void TestProductManagerMissingData()
        {
            // Arrange
            List<Product> products;
            IProductManager productManager = new ProductManager(_productAccessor);
            string typeToSearch = "Bad Type";
            int productsExpected = 0;

            //Act
            products = productManager.RetrieveAllProductsByType(typeToSearch);

            Assert.AreEqual(productsExpected, products.Count);
        }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Tests whether the Product Manager is able to catch a thrown application exception.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException))]
        public void TestDataLoadFailure()
        {
            // Arrange
            List<Product> products;
            IProductManager productManager = new ProductManager(_productAccessor);
            string typeToSearch = "Fail Type";

            //Act
            products = productManager.RetrieveAllProductsByType(typeToSearch);
            // Should fail at this point
        }

        /// <summary>
        /// NAME: Robert Holmes
        /// DATE: 2/21/2020
        /// CHECKED BY: Cash Carlson
        /// 
        /// Nullifies variables to set up for next run.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        [TestCleanup]
        public void TestCleanup()
        {
            _productAccessor = null;
        }
    }
}
