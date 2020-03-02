using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{ /// <summary>
  /// Creator: Tener karar
  /// Created: 2020/02/7
  /// Approver: Steven Cardona
  ///
  /// The datat transfer object for item class
  /// Contains all getter and setter methods for item functions
  /// </summary>
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int ItemQuantity { get; set; }
        public string ItemCategoryID { get; set; }
        public string Description { get; set; }

    }
}