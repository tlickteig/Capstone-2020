using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 3/19/2020
    /// Approver: Rob Holmes
    /// 
    /// Holds data relevant to a SalesTax.
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    public class SalesTax
    {
        public string ZipCode { get; set; }
        public decimal TaxRate { get; set; }
        public DateTime TaxDate { get; set; }
    }
}
