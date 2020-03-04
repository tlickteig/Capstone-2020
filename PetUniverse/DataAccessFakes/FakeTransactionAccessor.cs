using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    /// <summary>
    /// CREATOR: Jaeho Kim
    /// CREATED: 02/27/2020
    /// APPROVER: Ethan Holmes
    /// 
    /// Fake Transaction Accessor Class for Unit Testing
    /// </summary>
    public class FakeTransactionAccessor : ITransactionAccessor
    {
        private List<TransactionVM> _transactions;

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Hassan Karar
        /// 
        /// This fake method is called to get a fake Transaction Accessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns>Fake TransactionAccessor</returns>
        public FakeTransactionAccessor()
        {
            _transactions = new List<TransactionVM>()
            {
                new TransactionVM()
                {
                    TransactionID = 1000,
                    Quantity = 5,
                    ProductName = "CatNips",
                    Brand = "GreatFoods",
                    Price = 40.20M,
                    TransactionDate = DateTime.Now,
                    TransactionTypeID = "tranTYPE100",
                    Notes = "FAKETRANSACTIONNOTES"
                },
                new TransactionVM()
                {
                    TransactionID = 1001,
                    Quantity = 3,
                    ProductName = "BigChews",
                    Brand = "LoneFood",
                    Price = 40.20M,
                    TransactionDate = DateTime.Now,
                    TransactionTypeID = "tranTYPE200",
                    Notes = "FAKETRANSACTIONNOTES2"
                }
            };
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// CREATED: 2/27/2020
        /// APPROVER: Hassan Karar
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<TransactionVM> SelectAllTransactions()
        {
            return _transactions;
        }
    }
}
