using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
	/// Creator: Jaeho Kim
	/// Created: 2020-04-12
	/// Approver: Rob Holmes
	///
	/// Interaction logic for pgSalesTax.xaml
	/// </summary>
	public partial class pgSalesTax : Page
    {

		private ISalesTaxManager _salesTaxManager = null;

		/// <summary>
		/// Creator: Jaeho Kim
		/// Created: 2020-04-12
		/// Approver: Rob Holmes
		/// 
		/// Default Constructor.
		/// </summary>
		///
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// </remarks>
		public pgSalesTax()
        {
            InitializeComponent();
			_salesTaxManager = new SalesTaxManager();
		}


		/// <summary>
		/// Creator: Jaeho Kim
		/// Created: 2020/04/12
		/// Approver: Rob Holmes
		/// 
		/// Cancel sales tax entry.
		/// </summary>
		///
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancelSalesTax_Click(object sender, RoutedEventArgs e)
        {
			canSalesTax.Visibility = Visibility.Visible;

			canSalesTaxDetails.Visibility = Visibility.Hidden;
		}

		/// <summary>
		/// Creator: Jaeho Kim
		/// Created: 2020/04/12
		/// Approver: Rob Holmes
		/// 
		/// Save sales tax entry.
		/// </summary>
		///
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSave_Click(object sender, RoutedEventArgs e)
        {
			

			try
			{
				string td = dpTaxDate.Text.ToString();
				DateTime taxDate = DateTime.Parse(td);

				var salesTax = new SalesTax()
				{
					TaxDate = taxDate,
					TaxRate = decimal.Parse(txtTaxRate.Text),
					ZipCode = txtZipCode.Text.ToString()
				};

				_salesTaxManager.AddSalesTax(salesTax);
				MessageBox.Show("Sales Tax Added");
				clearSalesTax();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message + "\n\n" + "Invalid Input");
			}
		}

		/// <summary>
		/// Creator: Jaeho Kim
		/// Created: 2020/04/12
		/// Approver: Rob Holmes
		/// 
		/// Add Sales Tax Entry. Displays the sales tax details entry page.
		/// </summary>
		///
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAddSalesTax_Click(object sender, RoutedEventArgs e)
        {
			canSalesTax.Visibility = Visibility.Hidden;

			canSalesTaxDetails.Visibility = Visibility.Visible;
		}

		/// <summary>
		/// Creator: Jaeho Kim
		/// Created: 2020/04/13
		/// Approver: Rob Holmes
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
		private void clearSalesTax()
		{
			canSalesTax.Visibility = Visibility.Visible;

			canSalesTaxDetails.Visibility = Visibility.Hidden;

			dpTaxDate = null;
			txtTaxRate.Clear();
			txtZipCode.Clear();
		}

		/// <summary>
		/// Creator: Jaeho Kim
		/// Created: 2020/04/14
		/// Approver: Rob Holmes
		/// 
		/// Checks the zip code and makes sure it is a number. 
		/// Uses regular expressions.
		/// </summary>
		///
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtZipCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			Regex regex = new Regex("[^0-9]+");
			e.Handled = regex.IsMatch(e.Text);
		}
	}
}
