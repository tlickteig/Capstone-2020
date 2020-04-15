using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{

    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020/04/14
    /// Approver: Ethan Holmes
    /// 
    /// Data transfer object for transaction status.
    /// </summary>
    public class TransactionStatus
    {
        public string TransactionStatusID { get; set; }
        public string Description { get; set; }
        public bool DefaultInStore { get; set; }
    }
}
