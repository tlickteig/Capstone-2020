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
	/// Created: 03/19/2020
	/// Approver: 
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
		/// Approver: 
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
		/// Approver: 
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
		/// Approver: 
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
