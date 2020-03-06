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
    /// Creator : Jaeho Kim
    /// Created: 2/27/2020
    /// Approver: Rasha Mohammed
    /// 
    /// Interaction logic for ViewAllTransactions.xaml
    /// </summary>
    public partial class ViewAllTransactions : Page
    {
        ITransactionManager _transactionManager;
        //private ITransactionLineManager _transactionLineManager;
        TransactionVM _transactionVM;

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This is the default constructor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public ViewAllTransactions()
        {
            _transactionManager = new TransactionManager();
            //_transactionLineManager = new TransactionLineManager();
            InitializeComponent();
        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This loads all of the transactions using a loaded event.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void dgTransactionsList_Loaded(object sender, RoutedEventArgs e)
        {
            populateTransactionList();
            dgTransactionsList.Columns.RemoveAt(15);
            dgTransactionsList.Columns.RemoveAt(14);
            dgTransactionsList.Columns.RemoveAt(13);
            dgTransactionsList.Columns.RemoveAt(12);
            dgTransactionsList.Columns.RemoveAt(11);
            dgTransactionsList.Columns.RemoveAt(10);
            dgTransactionsList.Columns.RemoveAt(9);
            dgTransactionsList.Columns.RemoveAt(8);

            dgTransactionsList.Columns[2].Header = "Employee ID";
            dgTransactionsList.Columns[3].Header = "Employee First Name";
            dgTransactionsList.Columns[4].Header = "Employee Last Name";
            dgTransactionsList.Columns[7].Header = "Transaction Notes";


        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This method is called to populate the datagrid.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void populateTransactionList()
        {
            dgTransactionsList.ItemsSource = _transactionManager.RetrieveAllTransactions();
        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This method populates all of the products to the data grid.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void populateProductList()
        {
            _transactionVM = (TransactionVM)dgTransactionsList.SelectedItem;
            int transactionID = _transactionVM.TransactionID;
            dgProductList.ItemsSource = _transactionManager.RetrieveAllProductsByTransactionID(transactionID);
            dgProductList.Columns.RemoveAt(7);
            dgProductList.Columns.RemoveAt(6);
            dgProductList.Columns.RemoveAt(5);
            dgProductList.Columns.RemoveAt(4);
            dgProductList.Columns.RemoveAt(3);
            dgProductList.Columns.RemoveAt(2);
            dgProductList.Columns.RemoveAt(1);
            dgProductList.Columns.RemoveAt(0);
        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This method displays a single transaction details with double click.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void DgTransactionsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            canViewTransactions.Visibility = Visibility.Hidden;
            xTransactionDetails.Visibility = Visibility.Visible;
            _transactionVM = (TransactionVM)dgTransactionsList.SelectedItem;
            txtTransactionID.Text = _transactionVM.TransactionID.ToString();
            txtTransactionDate.Text = _transactionVM.TransactionDate.ToString();
            txtEmployeeID.Text = _transactionVM.UserID.ToString();
            txtFirstName.Text = _transactionVM.FirstName.ToString();
            txtLastName.Text = _transactionVM.LastName.ToString();
            txtTransactionTypeID.Text = _transactionVM.TransactionTypeID.ToString();
            txtTransactionStatusID.Text = _transactionVM.TransactionStatusID.ToString();
            txtNotes.Text = _transactionVM.Notes.ToString();

            populateProductList();

        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 3/05/2020
        /// Approver: Rasha Mohammed
        /// 
        /// This simply takes the end user back to the View all transactions tab.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            canViewTransactions.Visibility = Visibility.Visible;
            xTransactionDetails.Visibility = Visibility.Hidden;
        }

        private void BtnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            TransactionVM transaction = (TransactionVM)dgProductList.SelectedItem;

            _transactionManager.DeleteItem(transaction.ProductID);

            if (true)
            {
                MessageBox.Show("Are You Sure? The item will be remove");
                TransactionVM _transaction = (TransactionVM)dgProductList.SelectedItem;
                populateProductList();

            }
        }
    }
}
