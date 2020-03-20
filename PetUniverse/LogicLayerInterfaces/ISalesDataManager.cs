using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
	/// <summary>
	/// Creator: Cash Carlson
	/// Created: 03/19/2020
	/// Approver: Rob Holmes
	///
	/// An interface for Sales Data Logic Manager
	/// </summary>
	public interface ISalesDataManager
	{
		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 03/19/2020
		/// Approver: Rob Holmes
		///
		/// Interface for a method that gets a list of all Total Sales Data from an accessor
		/// </summary>
		/// <returns>List of Sales Data View Model Objects</returns>
		List<SalesDataVM> RetrieveAllTotalSalesData();
	}
}
