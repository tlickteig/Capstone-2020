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
    /// Interaction logic for ViewAddOrder.xaml
    /// </summary>
    public partial class ViewAddOrder : Page
    {
        OrderManager _orderManager;
        Order _order;

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
        public ViewAddOrder()
        {
            InitializeComponent();
            _orderManager = new OrderManager();
            _order = new Order();
            btnBack.Visibility = Visibility.Visible;
            btnSaveOrder.Visibility = Visibility.Visible;
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
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new ViewOrders());
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 3/30/2020
        ///
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        /// 
        /// action to save new order
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderManager _orderManager = new OrderManager();
            try
            {
                if (txtEmployeeID.Text == "")
                {
                    "You must fill out all the Fields.".ErrorMessage();
                    return;
                }

                Order _newOrder = new Order()
                {
                    EmployeeID = Int32.Parse(txtEmployeeID.Text)
                };
                try
                {
                    var result = _orderManager.AddOrder(_newOrder);
                    "Add Succesful".SuccessMessage();
                }
                catch (Exception)
                {
                    "Add Failed.".ErrorMessage();
                }
                this.NavigationService?.Navigate(new ViewOrders());
            }
            catch
            {
                throw;
            }
        }
    }
}
