using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Interaction logic for pgOpenTransaction.xaml
    /// </summary>
    public partial class pgOpenTransaction : Page
    {
        public pgOpenTransaction()
        {
            InitializeComponent();

            _transactionManager = new TransactionManager();

        }

        public pgOpenTransaction(PetUniverseUser user)
        {
            employeeID = user.PUUserID;

            InitializeComponent();
            _transactionManager = new TransactionManager();

        }

        private ITransactionManager _transactionManager;

        private ProductVM productVM = null;

        private int employeeID;

        private List<ProductVM> taxableProducts = new List<ProductVM>();

        private int quantityInStock = 0;

        private decimal taxRate;
        private decimal subTotalTaxable;
        private decimal subTotal;
        private decimal total;

        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// DATE: 03/17/2020
        /// APPROVER: Jaeho Kim
        ///
        /// Interface method signature for searching a product with Product UPC.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns a Transaction</returns>
        private void btnSearchProduct_Click(object sender, RoutedEventArgs e)
        {

            string productUPC = txtSearchProduct.Text.ToString();

            productVM = _transactionManager.RetrieveProductByProductID(productUPC);



            txtItemName.Text = productVM.Name;
            chkTaxable.IsChecked = productVM.Taxable;
            txtPrice.Text = productVM.Price.ToString();
            txtQuantity.Text = "1";
            txtItemDescription.Text = productVM.ItemDescription;

            quantityInStock = productVM.QuantityInStock;

            btnAddProduct.Visibility = Visibility.Visible;


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            txtItemName.IsReadOnly = true;
            chkTaxable.IsEnabled = false;
            txtPrice.IsReadOnly = true;
            txtQuantity.IsReadOnly = false;
            txtItemDescription.IsReadOnly = true;
            txtZipCode.IsReadOnly = true;
            txtTotal.IsReadOnly = true;
            txtSubTotal.IsReadOnly = true;
            txtSubTotalTaxable.IsReadOnly = true;

            btnAddProduct.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// CREATOR: Jaeho Kim
        /// DATE: 03/25/2020
        /// APPROVER: NA
        ///
        /// Adds a product to the shopping cart.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>void</returns>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var salesTax = new SalesTax();

                // Populates the salesTax data transfer object by zipcode.
                salesTax.ZipCode = txtZipCode.Text.ToString();
                salesTax.TaxDate = _transactionManager
                    .RetrieveLatestSalesTaxDateByZipCode(txtZipCode.Text.ToString());
                salesTax.TaxRate = _transactionManager
                    .RetrieveTaxRateBySalesTaxDateAndZipCode(txtZipCode.Text.ToString(), salesTax.TaxDate);
                // SalesTax details operation now complete.

                taxRate = salesTax.TaxRate;


                // Populates the productVM data transfer object using the product UPC number that was searched.
                ProductVM productVM = new ProductVM()
                {
                    ProductID = txtSearchProduct.Text.ToString(),
                    Name = txtItemName.Text.ToString(),
                    Taxable = chkTaxable.IsChecked == true,
                    Price = decimal.Parse(txtPrice.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    ItemDescription = txtItemDescription.Text.ToString(),
                    QuantityInStock = quantityInStock,
                    Active = true
                };

                bool isValid = false;
                // The logic verifies that the product searched actually exists and is valid.
                try
                {
                    isValid = _transactionManager.isItemQuantityValid(_transactionManager.GetAllProducts(), productVM);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }


                // verify that the item quantity is valid.
                if (isValid)
                {
                    _transactionManager.AddProduct(productVM);

                    // If the product is taxable, add it to the taxable product list.
                    if (productVM.Taxable)
                    {
                        _transactionManager.AddProductTaxable(productVM);
                    }
                }

                if (isValid == false)
                {
                    // Let the user know that the item quantity did not get entered.
                    MessageBox.Show("Invalid Item Quantity");
                }

                // Displays all the products on the data grid.
                dgShoppingCart.ItemsSource = _transactionManager.GetAllProducts();


                // CalculateSubTotal, takes the master list of products.
                // The reason for storing the variable is the value obtained from the CalculateSubTotal 
                // is going to be passed to calculate the total.
                subTotal = _transactionManager.CalculateSubTotal(_transactionManager.GetAllProducts());
                txtSubTotal.Text = subTotal.ToString();


                // CalculateSubTotalTaxable, takes the taxable list of products.
                // The reason for storing the variable is the value obtained from the CalculateSubTotal 
                // is going to be passed to calculate the tax.
                subTotalTaxable = _transactionManager.CalculateSubTotalTaxable(_transactionManager.GetTaxableProducts());
                txtSubTotalTaxable.Text = subTotalTaxable.ToString();

                // Calculates the total.
                //txtTotal.Text = _transactionManager.CalculateTotal(subTotal, subTotalTaxable, salesTax).ToString();
                total = _transactionManager.CalculateTotal(subTotal, subTotalTaxable, salesTax);
                txtTotal.Text = total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }


        private void btnCompleteTransaction_Click(object sender, RoutedEventArgs e)
        {
            Transaction transaction = new Transaction()
            {
                TransactionDateTime = DateTime.Now,
                TaxRate = taxRate,
                SubTotalTaxable = subTotalTaxable,
                SubTotal = subTotal,
                Total = total,
                TransactionTypeID = "tranTYPE100",
                EmployeeID = employeeID,
                TransactionStatusID = "tranStatus100"
            };

            var transactionLineProducts = new TransactionLineProducts();
            List<ProductVM> ProductsSoldList = new List<ProductVM>();

            foreach (var item in _transactionManager.GetAllProducts())
            {
                ProductsSoldList.Add(item);
            }
            transactionLineProducts.ProductsSold = ProductsSoldList;

            // Creating the transaction in the database
            if (transaction.SubTotal > 0.00M)
            {
                _transactionManager.AddTransaction(transaction);

                _transactionManager.AddTransactionLineProducts(transactionLineProducts);

                MessageBox.Show("Success!");

                txtSearchProduct.Text = "";
                txtItemName.Text = "";
                chkTaxable.IsChecked = false;
                txtPrice.Text = "";
                txtQuantity.Text = "";
                txtItemDescription.Text = "";

                txtTotal.Text = "";
                txtSubTotal.Text = "";
                txtSubTotalTaxable.Text = "";

                dgShoppingCart.ItemsSource = null;
                subTotalTaxable = 0.0M;
                subTotal = 0.0M;
                total = 0.0M;
                _transactionManager.ClearShoppingCart();

                btnAddProduct.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Could Not Add Transaction!");
            }

        }

        private void dgShoppingCart_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgShoppingCart.Columns.RemoveAt(7);
            dgShoppingCart.Columns.RemoveAt(6);
            dgShoppingCart.Columns.RemoveAt(5);
            dgShoppingCart.Columns.RemoveAt(4);
            dgShoppingCart.Columns.RemoveAt(0);
        }

        private void btnClearShoppingCart_Click(object sender, RoutedEventArgs e)
        {
            txtSearchProduct.Text = "";
            txtItemName.Text = "";
            chkTaxable.IsChecked = false;
            txtPrice.Text = "";
            txtQuantity.Text = "";
            txtItemDescription.Text = "";

            txtTotal.Text = "";
            txtSubTotal.Text = "";
            txtSubTotalTaxable.Text = "";

            subTotalTaxable = 0.0M;
            subTotal = 0.0M;
            total = 0.0M;

            dgShoppingCart.ItemsSource = null;
            btnAddProduct.Visibility = Visibility.Hidden;
            _transactionManager.ClearShoppingCart();
        }
    }
}
