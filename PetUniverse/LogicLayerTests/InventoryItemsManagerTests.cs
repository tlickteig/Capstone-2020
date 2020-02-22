using System;
using System.Collections.Generic;
using DataAccessFakes;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
	/// <summary>
	/// Creator: Cash Carlson
	/// Created: 2020/02/21
	/// Approver: Zach Behrensmeyer
	///
	/// Tests for InventoryItemsManager in the logic layer
	/// </summary>
	[TestClass]
	public class InventoryItemsManagerTests
	{
		private IInventoryItemsAccessor _inventoryAccessor;

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 2020/02/21
		/// Approver: Zach Behrensmeyer
		///
		/// Passing in FakeInventoryItemsAccessor at the start of every test
		/// </summary>
		[TestInitialize]
		public void InventoryItemsTestSetup()
		{
			_inventoryAccessor = new FakeInventoryItemsAccessor();
		}

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 2020/02/21
		/// Approver: Zach Behrensmeyer
		///
		/// Test method for retrieving all of Inventory Items from the accessor
		/// </summary>
		[TestMethod]
		public void TestInventoryItemsManagerRetrieveInventoryItems()
		{
			// arrange
			List<InventoryItems> inventoryItems;
			IInventoryItemsManager inventoryItemsManager = new InventoryItemsManager(_inventoryAccessor);

			// act
			inventoryItems = inventoryItemsManager.RetrieveInventoryItems();

			//assert
			Assert.AreEqual(1, inventoryItems.Count);
		}

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 2020/02/21
		/// Approver: Zach Behrensmeyer
		///
		/// Tear down method that resets the accessor class
		/// </summary>
		[TestCleanup]
		public void TestTearDown()
		{
			_inventoryAccessor = null;
		}
	}
}
