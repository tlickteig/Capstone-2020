using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayer;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// The test class for ItemManager.
    /// </summary>
    [TestClass]
    public class ItemManagerTests
    {

        private Item _item;
        private ItemManager _itemManager;
        private FakeItemAccessor _fakeItemAccessor;

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:   Jesse Tomash
        ///
        /// Method to set up the tests.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeItemAccessor = new FakeItemAccessor();
            _itemManager = new ItemManager(_fakeItemAccessor);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:   Jesse Tomash
        ///
        /// Test method to test creating a new item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestCreateNewItem()
        {
            // arrange
            Item item = new Item()
            {
                ItemCategoryID = "Cat Toys",
                ItemID = 1,
                ItemName = "Item",
                ItemQuantity = 100
            };
            bool created = false;
            bool expectedResult = true;

            // act
            created = _itemManager.createNewItem(item);

            // assert
            Assert.AreEqual(expectedResult, created);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/23
        /// Approver: Dalton Reierson
        /// Approver:   Jesse Tomash
        ///
        /// Test method for getting a list of items.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        [TestMethod]
        public void TestListItem()
        {
            // Arrange
            int expectedResult = 3;
            List<Item> items = new List<Item>();

            // Act
            items = _itemManager.retrieveItems();

            // Assert
            Assert.AreEqual(expectedResult, items.Count);
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:   Jesse Tomash
        ///
        /// Method to clean up for the next test run.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        [TestCleanup]
        public void TestTearDown()
        {
            _item = null;
            _fakeItemAccessor = null;
            _itemManager = null;
        }
    }
}
