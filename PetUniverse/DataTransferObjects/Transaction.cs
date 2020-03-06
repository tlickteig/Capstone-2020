using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{

    /// <summary>
    ///  Creator: Jaeho Kim
    ///  Created: 2020/02/27
    ///  Approver: Rasha Mohammed
    ///  
    ///  Transaction Data Transfer Object
    /// </summary>
    public class Transaction
    {
        public int TransactionID { get; set; }
        public int EmployeeID { get; set; }
        public string Notes { get; set; }
    }
}
