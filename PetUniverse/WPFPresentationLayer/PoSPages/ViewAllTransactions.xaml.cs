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
    /// Approver: Hassan Karar
    /// 
    /// Interaction logic for ViewAllTransactions.xaml
    /// </summary>
    public partial class ViewAllTransactions : Page
    {
        ITransactionManager _transactionManager;

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Hassan Karar
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
            InitializeComponent();
        }

        private void dgTransactionsList_Loaded(object sender, RoutedEventArgs e)
        {
            populateTransactionList();
        }

        /// <summary>
        /// Creator : Jaeho Kim
        /// Created: 2/27/2020
        /// Approver: Hassan Karar
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
    }
}
