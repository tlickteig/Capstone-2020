using LogicLayer;
using LogicLayerInterfaces;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Cash Carlson
    /// Created: 03/19/2020
    /// Approver: Rob Holmes
    ///
    /// 
    /// Interaction logic for pgViewSalesData.xaml
    /// </summary>
    public partial class pgViewSalesData : Page
    {
        private ISalesDataManager _salesDataManager;

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 03/19/2020
        /// Approver: Rob Holmes
        ///
        /// Default Constructor for InventoryItems Page
        /// </summary>
        public pgViewSalesData()
        {
            _salesDataManager = new SalesDataManager();
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 03/19/2020
        /// Approver: Rob Holmes
        ///
        /// Event Handler when the page loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 03/19/2020
        /// Approver: Rob Holmes
        ///
        /// Refresh method to be called on when is needed.
        /// 
        /// </summary>
        private void RefreshData()
        {
            dgSalesData.ItemsSource = _salesDataManager.RetrieveAllTotalSalesData();
            dgSalesData.Columns.Remove(dgSalesData.Columns[0]);

            //Columns reset at 0 after being removed
            dgSalesData.Columns[0].Header = "Product Name";
            dgSalesData.Columns[2].Header = "Product Category";
            dgSalesData.Columns[3].Header = "Product Type";
            dgSalesData.Columns[4].Header = "Total Sold";
        }
    }
}
