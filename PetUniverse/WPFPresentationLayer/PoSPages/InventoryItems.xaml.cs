using LogicLayer;
using LogicLayerInterfaces;
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

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Cash Carlson
    /// Created: 2020/02/21
    /// Approver: Zach Behrensmeyer
    ///
    /// Interaction logic for InventoryItems.xaml
    /// </summary>
    public partial class InventoryItems : Page
	{
		private IInventoryItemsManager _inventoryItemsManager;

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/02/21
        /// Approver: Zach Behrensmeyer
        ///
        /// Default Constructor for InventoryItems Page
        /// </summary>
        public InventoryItems()
		{
			_inventoryItemsManager = new InventoryItemsManager();
			InitializeComponent();
		}

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/02/21
        /// Approver: Zach Behrensmeyer
        ///
        /// Event Handler Method that activates on page load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_Loaded(object sender, RoutedEventArgs e) 
		{
			RefreshData();
		}

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 2020/02/21
        /// Approver: Zach Behrensmeyer
        ///
        /// Data Refresh Method to be called on every time it is needed.
        /// </summary>
        public void RefreshData()
		{
			dgInventoryItems.ItemsSource = _inventoryItemsManager.RetrieveInventoryItems();
			dgInventoryItems.Columns.Remove(dgInventoryItems.Columns[0]);
		}
	}
}
