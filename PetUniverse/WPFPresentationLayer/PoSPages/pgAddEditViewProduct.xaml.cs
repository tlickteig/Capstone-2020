using DataTransferObjects;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Interaction logic for pgAddEditViewProduct.xaml
    /// </summary>
    public partial class pgAddEditViewProduct : Page
    {
        private Frame _frame;
        private IProductManager _productManager;
        private List<Product> _products;
        private Product _product;

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: 
        /// 
        /// Constructor used for adding a new product.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="frame">Frame used for navigation.</param>
        /// <param name="productManager">ProductManager passed from previous screen to avoid having to instantiate a new one.</param>
        /// <param name="item">Item selected from previous screen.</param>
        public pgAddEditViewProduct(Frame frame, IProductManager productManager, Item item)
        {
            _frame = frame;
            _productManager = productManager;
            _product = new Product();
            InitializeComponent();
            setItemFields(item);
            initializeComboBoxes();
            lblHeading.Content = "Add a New Product";
            btnAction.Content = "Save";
            try
            {
                _products = _productManager.RetrieveAllProductsByType();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Failed to load product list.");
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: 
        /// 
        /// Method to set the data contained in the item passed in.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="item">Item data to use.</param>
        private void setItemFields(Item item)
        {
            txtItemID.Text = item.ItemID.ToString();
            txtName.Text = item.ItemName;
            txtCategory.Text = item.ItemCategoryID;
            txtDescription.Text = item.Description;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: 
        /// 
        /// Method to set the data sources for the combo boxes on the page.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        private void initializeComboBoxes()
        {
            cboTaxable.ItemsSource = new List<string> { "Yes", "No" };
            if (_product != null)
            {
                if (_product.ProductID == null)
                {
                    cboTaxable.SelectedItem = "Yes";
                }
                else if (!_product.Taxable)
                {
                    cboTaxable.SelectedItem = "No";
                }
                else
                {
                    cboTaxable.SelectedItem = "Yes";
                }
            }

            cboType.ItemsSource = _productManager.RetrieveAllProductTypeIDs();
            if (_product != null)
            {
                cboType.SelectedItem = _product.Type;
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: 
        /// 
        /// Handles navigation without saving any changes made.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBoxResult.Yes == MessageBox.Show("You will lose any entered data. Continue?", "Abandon Product", MessageBoxButton.YesNo, MessageBoxImage.Warning))
            {
                _frame.Navigate(new pgInventoryItems(_frame));
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: 
        /// 
        /// Handles saving product data to the database.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            switch (btnAction.Content)
            {
                case ("Save"):
                    {
                        if (validateFields())
                        {
                            try
                            {
                                _product.ProductID = txtProductID.Text;
                                _product.ItemID = Convert.ToInt32(txtItemID.Text);
                                _product.Name = txtName.Text;
                                _product.Category = txtCategory.Text;
                                _product.Brand = txtBrand.Text;
                                _product.Type = (string)cboType.SelectedItem;
                                _product.Price = (decimal)numPrice.Value;
                                _product.Description = txtDescription.Text;
                                if ((string)cboTaxable.SelectedItem == "No")
                                {
                                    _product.Taxable = false;
                                }
                                else
                                {
                                    _product.Taxable = true;
                                }
                                _productManager.AddProduct(_product);
                            }
                            catch (Exception ex)
                            {
                                WPFErrorHandler.ErrorMessage("Failed to save product to database.\n\n" + ex.Message, ex.GetType().ToString());
                            }
                            _frame.Navigate(new pgInventoryItems(_frame));
                        }

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/18
        /// Approver: 
        /// 
        /// Validates product information.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <returns>Returns true if field contents are acceptable.</returns>
        private bool validateFields()
        {
            bool isValid = false;
            while (!isValid)
            {
                //ProductID
                if (txtProductID.Text.Equals(""))
                {
                    WPFErrorHandler.ErrorMessage("You must enter a Product ID.");
                    txtProductID.Focus();
                    break;
                }
                if (txtProductID.Text.Contains(" "))
                {
                    WPFErrorHandler.ErrorMessage("Product ID may not contain spaces.");
                    txtProductID.Focus();
                    break;
                }
                bool duplicate = false;
                foreach (Product p in _products)
                {
                    if (p.ProductID.Equals(txtProductID.Text))
                    {
                        duplicate = true;
                    }
                }
                if (duplicate)
                {
                    WPFErrorHandler.ErrorMessage("There is already a product with that Product ID, you must enter a new one.");
                    txtProductID.Focus();
                    break;
                }
                //Type
                if (cboType.SelectedItem == null)
                {
                    WPFErrorHandler.ErrorMessage("You must select a product type.");
                    cboType.Focus();
                    break;
                }
                //Brand
                if (txtBrand.Text.Equals(""))
                {
                    WPFErrorHandler.ErrorMessage("You must enter a product brand.");
                    txtBrand.Focus();
                    break;
                }
                //Price
                if (numPrice.Value == null)
                {
                    WPFErrorHandler.ErrorMessage("You must enter a valid price.");
                    numPrice.Focus();
                    break;
                }
                //Taxable
                if (cboTaxable.SelectedItem == null)
                {
                    WPFErrorHandler.ErrorMessage("You must indicate whether this product is subject to sales tax.");
                    cboTaxable.Focus();
                    break;
                }
                //Description
                //None
                isValid = true;
            }
            return isValid;
        }
    }
}
