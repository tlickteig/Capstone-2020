using DataTransferObjects;
using LogicLayer;
using PresentationUtilityCode;
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

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// NAME: Jesse Tomash
    /// DATE: 3/30/2020
    ///
    /// Approver: Brandyn T. Coverdill
    /// Approver: 
    /// 
    /// Interaction logic  for ViewAddSpecialOrder.xaml
    /// </summary>
    /// /// <remarks>
    /// UPDATED BY:
    /// UPDATE DATE:
    /// WHAT WAS CHANGED:
    /// </remarks>
    /// <returns></returns>
    public partial class ViewAddSpecialOrder : Page
    {
        SpecialOrderManager _orderManager;
        SpecialOrder _order;

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Iconstructor  for ViewSpecialOrders.xaml
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        public ViewAddSpecialOrder()
        {
            InitializeComponent();
            _orderManager = new SpecialOrderManager();
            _order = new SpecialOrder();
            btnSpBack.Visibility = Visibility.Visible;
            btnSaveSpecialOrder.Visibility = Visibility.Visible;
            txtEmployeeID.Visibility = Visibility.Visible;
            txtOrderID.Visibility = Visibility.Visible;
            txtOrderID.IsReadOnly = true;
            txtOrderID.Text = "(Automatically Generated)";
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Goes back to view all orders
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY: Brandyn T. Coverdill
        /// UPDATE DATE: 4/8/2020
        /// WHAT WAS CHANGED: Made it so that instead of throwing an error, it popped up an error message to have the user
        /// enter a valid employee ID.
        /// </remarks>
        /// <returns></returns>
        private void btnSpBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ViewSpecialOrders());
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// Saves the special order
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY: Brandyn T. Coverdill
        /// UPDATE DATE: 4/8/2020
        /// WHAT WAS CHANGED: Made it so that instead of throwing an error, it popped up an error message to have the user
        /// enter a valid employee ID.
        /// </remarks>
        /// <returns></returns>
        private void btnSaveSpecialOrder_Click(object sender, RoutedEventArgs e)
        {
            SpecialOrderManager _orderManager = new SpecialOrderManager();
            try
            {
                if (txtEmployeeID.Text == "")
                {
                    "You must fill out all the Fields.".ErrorMessage();
                    return;
                }

                SpecialOrder _newOrder = new SpecialOrder()
                {
                    SpecialOrderEmployeeID = Int32.Parse(txtEmployeeID.Text)
                };
                try
                {
                    var result = _orderManager.AddSpecialOrder(_newOrder);
                    "Add Succesful".SuccessMessage();
                }
                catch (Exception)
                {
                    "Add Failed.".ErrorMessage();
                }
                this.NavigationService?.Navigate(new ViewSpecialOrders());
            }
            catch
            {
                "You must enter a valid Employee ID.".ErrorMessage();
            }
        }
    }
}
