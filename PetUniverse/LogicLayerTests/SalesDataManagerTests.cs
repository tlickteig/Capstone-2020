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
	[TestClass]
	public class SalesDataManagerTests
	{
		private ISalesDataAccessor _salesDataAccessor;

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 2020/03/19
		/// Approver: 
		///
		/// Passing in SalesDataFakes at the start of every test
		/// </summary>
		/// <remarks>
		/// Updater: Name
		/// Updated: yyyy/mm/dd 
		/// Update: ()
		/// </remarks>
		[TestInitialize]
		public void InventoryItemsTestSetup()
		{
			_salesDataAccessor = new SalesDataFakes();
		}

		[TestMethod]
		public void TestSalesDataManagerRetrieveAllTotalSalesData()
		{
			// arrange
			List<SalesDataVM> salesData;
			ISalesDataManager salesDataManager = new SalesDataManager(_salesDataAccessor);

			// act
			salesData = salesDataManager.RetrieveAllTotalSalesData();

			//assert
			Assert.AreEqual(1, salesData.Count);
		}

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 2020/03/19
		/// Approver: 
		///
		/// Tear down method that resets the accessor class
		/// </summary>
		/// <remarks>
		/// Updater: Name
		/// Updated: yyyy/mm/dd 
		/// Update: ()
		/// </remarks>
		[TestCleanup]
		public void TestTearDown()
		{
			_salesDataAccessor = null;
		}
	}
}
