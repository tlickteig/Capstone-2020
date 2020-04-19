using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Jaeho Kim
    /// Created: 2020-04-14
    /// Approver: Ethan Holmes
    ///
    /// Interaction logic for pgTransactionAdmin.xaml
    /// </summary>
    public partial class pgTransactionAdmin : Page
    {

        private ITransactionAdminManager _transactionAdminManager = null;

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020-04-14
        /// Approver: Ethan Holmes
        /// 
        /// Default Constructor.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public pgTransactionAdmin()
        {
            InitializeComponent();

            _transactionAdminManager = new TransactionAdminManager();
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Add transaction type Entry. Displays the transaction type details entry page.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTransactionType_Click(object sender, RoutedEventArgs e)
        {
            canTransactionAdmin.Visibility = Visibility.Hidden;
            canTransactionTypeDetails.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Cancel transaction type entry.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelTransactionType_Click(object sender, RoutedEventArgs e)
        {
            canTransactionAdmin.Visibility = Visibility.Visible;
            canTransactionTypeDetails.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Clears the details page and returns to the original tab.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearTransactionType()
        {
            canTransactionAdmin.Visibility = Visibility.Visible;

            canTransactionTypeDetails.Visibility = Visibility.Hidden;

            txtTransactionTypeID.Clear();
            txtTransactionTypeDescription.Clear();
            chkTransactionTypeDefaultInStore.IsChecked = false;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Save transaction type entry.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveTransactionType_Click(object sender, RoutedEventArgs e)
        {
            if (txtTransactionTypeID.Text == "")
            {
                txtTransactionTypeID.Text = null;
                MessageBox.Show("Please enter TransactionType ID");
                return;
            }

            if (txtTransactionTypeDescription.Text == "")
            {
                txtTransactionTypeDescription.Text = null;
                MessageBox.Show("Please enter the Transaction Type Description");
                return;
            }

            try
            {
                var transactionType = new TransactionType()
                {
                    TransactionTypeID = txtTransactionTypeID.Text,
                    Description = txtTransactionTypeDescription.Text,
                    DefaultInStore = (bool)chkTransactionTypeDefaultInStore.IsChecked
                };

                _transactionAdminManager.AddTransactionType(transactionType);
                MessageBox.Show("Transaction Type Added");
                clearTransactionType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Save transaction status entry.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveTransactionStatus_Click(object sender, RoutedEventArgs e)
        {
            if (txtTransactionStatusID.Text == "")
            {
                txtTransactionStatusID.Text = null;
                MessageBox.Show("Please enter TransactionStatus ID");
                return;
            }

            if (txtTransactionStatusDescription.Text == "")
            {
                txtTransactionStatusDescription.Text = null;
                MessageBox.Show("Please enter the Transaction Status Description");
                return;
            }

            try
            {
                var transactionStatus = new TransactionStatus()
                {
                    TransactionStatusID = txtTransactionStatusID.Text,
                    Description = txtTransactionStatusDescription.Text,
                    DefaultInStore = (bool)chkTransactionStatusDefaultInStore.IsChecked
                };

                _transactionAdminManager.AddTransactionStatus(transactionStatus);
                MessageBox.Show("Transaction Status Added");
                clearTransactionStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Cancel transaction status entry.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelTransactionStatus_Click(object sender, RoutedEventArgs e)
        {
            canTransactionAdmin.Visibility = Visibility.Visible;
            canTransactionStatusDetails.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Add transaction status Entry. Displays the transaction status details entry page.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTransactionStatus_Click(object sender, RoutedEventArgs e)
        {
            canTransactionAdmin.Visibility = Visibility.Hidden;
            canTransactionStatusDetails.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Jaeho Kim
        /// Created: 2020/04/14
        /// Approver: Ethan Holmes
        /// 
        /// Clears the details page and returns to the original tab.
        /// </summary>
        ///
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearTransactionStatus()
        {
            canTransactionAdmin.Visibility = Visibility.Visible;

            canTransactionStatusDetails.Visibility = Visibility.Hidden;

            txtTransactionStatusID.Clear();
            txtTransactionStatusDescription.Clear();
            chkTransactionStatusDefaultInStore.IsChecked = false;
        }
    }
}
