using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Jaeho Kim
    /// DATE: 2/27/20
    /// APROVER: Rasha Mohammed
    /// This is the TransactionVM object in which the End User 
    /// will see. It contains data that the end user can understand.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATE DATE: N/A
    /// CHANGE DESCRIPTION: N/A
    /// </remarks>
    public class TransactionVM
    {

        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TransactionTypeID { get; set; }
        public string TransactionStatusID { get; set; }

        //View Model Details:
        public int Quantity { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCategoryID { get; set; }
        public string ProductTypeID { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public decimal SubTotalTaxable { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }

    }
}
