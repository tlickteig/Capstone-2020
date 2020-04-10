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
    /// APPROVER: Rasha Mohammed
    /// 
    /// Fake Transaction Accessor Class for Unit Testing
    /// </summary>
    public class FakeTransactionAccessor : ITransactionAccessor
    {
        // initializing list of transaction VMs for testing
        private List<TransactionVM> _transactionsVMs;

        // initializing list of transaction VMs for testing items related to transaction
        private List<TransactionVM> items;

        // initializing list of transactions for testing
        private List<Transaction> _transactions;

        // initializing lists of products related to transaction for testing
        private List<ProductVM> _productVMs1;
        private List<ProductVM> _productVMs2;
        private List<TransactionLineProducts> _transactionLineProducts;

        // initializing list of sales taxes for testing
        private List<SalesTax> salesTaxes;

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This fake method is called to get a fake Transaction Accessor
        /// </summary>
        /// <remarks>
        /// Updater: Jaeho Kim
        /// Updated: 2020/03/05
        /// Update: Implemented the Select All Products by Transaction ID.
        /// 
        /// </remarks>
        /// <returns>Fake TransactionAccessor</returns>
        public FakeTransactionAccessor()
        {

            DateTime transactionDate1 = new DateTime(2010, 10, 18);
            DateTime transactionDate2 = new DateTime(2011, 11, 19);

            _transactionsVMs = new List<TransactionVM>()
            {
                new TransactionVM()
                {
                    TransactionID = 1000,
                    TransactionDate = transactionDate1,
                    UserID = 100000,
                    FirstName = "Bob",
                    LastName = "Jones",
                    TransactionTypeID = "FAKE_TYPE_1",
                    TransactionStatusID = "FAKE_STATUS_1"
                },
                new TransactionVM()
                {
                    TransactionID = 1001,
                    TransactionDate = transactionDate2,
                    UserID = 100001,
                    FirstName = "Shawn",
                    LastName = "Gunner",
                    TransactionTypeID = "FAKE_TYPE_2",
                    TransactionStatusID = "FAKE_STATUS_2"
                }
            };

            
            _transactions = new List<Transaction>()
            {
                new Transaction()
                {
                    TransactionID = 1000,
                    TransactionDateTime = transactionDate1,
                    TaxRate = 0.025M,
                    SubTotalTaxable = 20.22M,
                    SubTotal = 21.22M,
                    Total = 23.11M,
                    TransactionTypeID = "FAKE_TYPE_1",
                    EmployeeID = 100000,
                    TransactionStatusID = "FAKE_STATUS_1"
                },
                new Transaction()
                {
                    TransactionID = 1001,
                    TransactionDateTime = transactionDate2,
                    TaxRate = 0.031M,
                    SubTotalTaxable = 43.22M,
                    SubTotal = 42.22M,
                    Total = 44.11M,
                    TransactionTypeID = "FAKE_TYPE_1",
                    EmployeeID = 100001,
                    TransactionStatusID = "FAKE_STATUS_1"
                }
            };



            _productVMs1 = new List<ProductVM>
            {
                new ProductVM()
                {
                    Name = "CatFood",
                    ProductID = "ProductID100",
                },
                new ProductVM()
                {
                    Name = "SnakeFood",
                    ProductID = "ProductID400",
                }
            };

            _productVMs2 = new List<ProductVM>
            {
                new ProductVM()
                {
                    Name = "DogFood",
                    ProductID = "ProductID200",
                },
                new ProductVM()
                {
                    Name = "FishFood",
                    ProductID = "ProductID300",
                }
            };

            _transactionLineProducts = new List<TransactionLineProducts>()
            {
                new TransactionLineProducts()
                {
                    TransactionID = 1000,
                    ProductsSold = _productVMs1

                },
                new TransactionLineProducts()
                {
                    TransactionID = 1001,
                    ProductsSold = _productVMs2
                }
            };

            items = new List<TransactionVM>()
            {
                new TransactionVM()
                {
                    TransactionID = 10000,
                    ProductID = "tx123hyg",
                    Quantity = 2,

                },
                new TransactionVM()
                {
                    TransactionID = 10001,
                    ProductID = "123lok569",
                    Quantity = 1,

                },
                new TransactionVM()
                {
                    TransactionID = 10001,
                    ProductID = "123abc456",
                    Quantity = 3,

                }

            };


            DateTime salesTaxDate1 = new DateTime(2002, 10, 18);
            DateTime salesTaxDate2 = new DateTime(2003, 11, 19);
            salesTaxes = new List<SalesTax>()
            {
                new SalesTax()
                {
                    ZipCode = "1111",
                    TaxRate = 0.0025M,
                    TaxDate = salesTaxDate1
                },
                new SalesTax()
                {
                    ZipCode = "2222",
                    TaxRate = 0.0045M,
                    TaxDate = salesTaxDate2
                }
            };
        }

        /// <summary>
        /// NAME: Rasha Mohammed
        /// DATE: 2/28/2020
        /// CHECKED BY:  Jaeho Kim
        /// 
        /// Method to test delete item from the transactionLine 
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public int DeleteItemFromTransaction(string productID)
        {
            int result = 0;
            foreach (var item in items)
            {
                if (item.ProductID == productID)
                {
                    items.Remove(item);
                    result++;
                    break;
                }

            }
            return result;
        }

        /// <summary>
        /// NAME: Jaeho Kim
        /// DATE: 4/04/2020
        /// CHECKED BY:  Jaeho Kim
        /// 
        /// Method to test insert transaction
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public int InsertTransaction(Transaction transaction)
        {
            int result = 0;
            FakeTransactionAccessor fakeTransactionAccessor = new FakeTransactionAccessor();
            List<Transaction> transactions = fakeTransactionAccessor.SelectAllTransactions();

            if (!transactions.Contains(transaction))
            {
                transactions.Add(transaction);
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// NAME: Jaeho Kim
        /// DATE: 4/04/2020
        /// CHECKED BY:  Jaeho Kim
        /// 
        /// Method to test insert products related to transaction
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public int InsertTransactionLineProducts(TransactionLineProducts transactionLineProducts)
        {
            int result = 0;
            FakeTransactionAccessor fakeTransactionAccessor = new FakeTransactionAccessor();
            List<TransactionLineProducts> transactionLineProductsList = 
                fakeTransactionAccessor.SelectAllTransactionLineProducts();

            if (!transactionLineProductsList.Contains(transactionLineProducts))
            {
                transactionLineProductsList.Add(transactionLineProducts);
                result = 1;
            }
            return result;
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// CREATED: 3/05/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<TransactionVM> SelectAllProductsByTransactionID(int transactionID)
        {
            return (from v in _transactionsVMs
                    where v.TransactionID == 1000
                    select v).ToList();
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// CREATED: 2/27/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: Jaeho Kim
        /// UPDATED: 2020/03/03
        /// UPDATE: Added missing properties from the data transfer object.
        /// 
        /// </remarks>
        public List<TransactionVM> SelectAllTransactionVMs()
        {
            return _transactionsVMs;
        }

        /// <summary>
        /// NAME: Jaeho Kim
        /// DATE: 4/04/2020
        /// CHECKED BY:  Jaeho Kim
        /// 
        /// Method to test select all transactions
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public List<Transaction> SelectAllTransactions()
        {
            return _transactions;
        }

        /// <summary>
        /// NAME: Jaeho Kim
        /// DATE: 4/04/2020
        /// CHECKED BY:  Jaeho Kim
        /// 
        /// Method to test transaction line products
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public List<TransactionLineProducts> SelectAllTransactionLineProducts()
        {
            return _transactionLineProducts;
        }

        /// <summary>
        /// NAME: Jaeho Kim
        /// DATE: 4/04/2020
        /// CHECKED BY:  Jaeho Kim
        /// 
        /// Method to test select latest sales tax date
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public DateTime SelectLatestSalesTaxDateByZipCode(string zipCode)
        {
            SalesTax salesTax = null;
            foreach (var aSalesTax in salesTaxes)
            {
                if (aSalesTax.ZipCode.Equals(zipCode))
                {
                    salesTax = aSalesTax;
                }
            }
            return salesTax.TaxDate;
        }

        /// <summary>
        /// NAME: Jaeho Kim
        /// DATE: 4/04/2020
        /// CHECKED BY:  Jaeho Kim
        /// 
        /// Method to test select product by id.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public ProductVM SelectProductByProductID(string productID)
        {
            ProductVM productVM = null;
            foreach (var product in _productVMs1)
            {
                if (product.ProductID.Equals(productID))
                {
                    productVM = product;
                }
            }
            return productVM;
        }

        /// <summary>
        /// NAME: Jaeho Kim
        /// DATE: 4/04/2020
        /// CHECKED BY:  Jaeho Kim
        /// 
        /// Method to test select tax rate by zip code and latest date retrieved.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public decimal SelectTaxRateBySalesTaxDateAndZipCode(string zipCode, DateTime salesTaxDate)
        {
            SalesTax salesTax = null;
            foreach (var aSalesTax in salesTaxes)
            {
                if (aSalesTax.ZipCode.Equals(zipCode) && aSalesTax.TaxDate.Equals(salesTaxDate))
                {
                    salesTax = aSalesTax;
                }
            }
            return salesTax.TaxRate;
        }

        /// <summary>
        /// NAME: Jaeho Kim
        /// DATE: 4/04/2020
        /// CHECKED BY:  Jaeho Kim
        /// 
        /// Method to test select transactions by date.
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED DATE: 
        /// CHANGES: 
        /// 
        /// </remarks>
        public List<TransactionVM> SelectTransactionsByTransactionDate(DateTime transactionDate)
        {
            DateTime transactionDate1 = new DateTime(2010, 10, 18);
            return (from v in _transactionsVMs
                    where v.TransactionDate == transactionDate1
                    select v).ToList();
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// CREATED: 3/08/2020
        /// APPROVER: NA
        /// 
        /// Fake Transaction Accessor Method, uses dummy data for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<TransactionVM> SelectTransactionsByEmployeeName(string firstName, string lastName)
        {
            return (from v in _transactionsVMs
                    where v.FirstName == "Bob" && v.LastName == "Jones"
                    select v).ToList();
        }
    }
}
