using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/04/07
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// This object is for Item Reports for items on the shelves of the store.
    /// </summary>
    public class ItemReport : Item
    {
        public int Quantity { get; set; }
        public string Report { get; set; }
    }
}
