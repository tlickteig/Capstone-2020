using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
	/// <summary>
	/// Creator: Cash Carlson
	/// Created: 02/21/2020
	/// Approver: Zach Behrensmeyer
	///
	/// An interface for accessing Inventory Items
	/// </summary>
	public interface IInventoryItemsAccessor
	{

		/// <summary>
		/// Creator: Cash Carlson
		/// Created: 02/21/2020
		/// Approver: Zach Behrensmeyer
		///
		/// An data access method to return all InventoryItems
		/// </summary>
		/// <remarks>
		/// Updater Name
		/// Updated: yyyy/mm/dd 
		/// Update: ()
		/// </remarks>
		/// 
		/// <returns>A list of InventoryItems</returns>
		List<InventoryItems> SelectAllInventory();
	}
}