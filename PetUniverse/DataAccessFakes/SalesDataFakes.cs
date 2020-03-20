using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{

	/// <summary>
	/// Creator: Cash Carlson
	/// Date: 03/19/2020
	/// Approver: 
	/// 
	/// This class is used to create fake sales data for testing.
	/// </summary>
	public class SalesDataFakes : ISalesDataAccessor
	{
		private List<SalesDataVM> salesDataVMs;

		public SalesDataFakes()
		{
			salesDataVMs = new List<SalesDataVM>() 
			{ 
				new SalesDataVM()
				{
					ProductID = "Fake",
					ProductName = "Fake Name",
					Brand = "Fake Brand",
					ProductCategory = "Fake Category",
					ProductType = "Fake Type",
					TotalSold = 50
				}
			};
		}

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 03/19/2020
		/// Approver: 
		/// 
		/// Return all total sales data accessor.
		/// </summary>
		/// <returns></returns>
		public List<SalesDataVM> RetrieveAllTotalSalesData()
		{
			return salesDataVMs;
		}
	}
}
