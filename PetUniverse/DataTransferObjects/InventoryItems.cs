using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Cash Carlson
    /// Created: 02/21/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// This class creates the properties for Inventory Items
    /// </summary>
	public class InventoryItems
	{
		public string ProductID { get; set; }
		public string Name { get; set; }
		public string Brand { get; set; }
		public string Category { get; set; }
		public string Type { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
