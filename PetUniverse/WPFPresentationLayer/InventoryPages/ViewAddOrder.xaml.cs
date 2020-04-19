using DataTransferObjects;
using LogicLayer;
using PresentationUtilityCode;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.InventoryPages
{
    /// <summary>
    /// Interaction logic for ViewAddOrder.xaml
    /// </summary>
    public partial class ViewAddOrder : Page
    {
        OrderManager _orderManager;
        UserManager _userManager;
        Order _order;
        PetUniverseUser _user;
        String firstName, lastName;

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
            txtUserID.Visibility = Visibility.Visible;
            txtOrderID.Visibility = Visibility.Visible;
            txtOrderID.IsReadOnly = true;
            txtOrderID.Text = "(Automatically Generated)";
            txtFirstName.Visibility = Visibility.Hidden;
            txtLastName.Visibility = Visibility.Hidden;
            lblFirstName.Visibility = Visibility.Hidden;
            lblLastName.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/15/2020
        ///
        /// Approver:
        /// Approver: 
        /// 
        /// constructor  for View Order
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        public ViewAddOrder(Order order)
        {
            InitializeComponent();
            _orderManager = new OrderManager();
            _order = order;
            btnBack.Visibility = Visibility.Visible;
            btnSaveOrder.Visibility = Visibility.Hidden;
            txtUserID.Visibility = Visibility.Visible;
            txtOrderID.Visibility = Visibility.Visible;
            txtOrderID.IsReadOnly = true;
            txtUserID.IsReadOnly = true;
            txtOrderID.Text = order.OrderID.ToString();
            txtUserID.Text = order.UserID.ToString();
            FetchUserName();
            txtFirstName.Visibility = Visibility.Visible;
            txtLastName.Visibility = Visibility.Visible;
            lblFirstName.Visibility = Visibility.Visible;
            lblLastName.Visibility = Visibility.Visible;
            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
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
            if (txtUserID.Text == "")
            {
                "You must fill out all the Fields.".ErrorMessage();
                return;
            }

            Order _newOrder = new Order()
            {
                UserID = Int32.Parse(txtUserID.Text)
            };
            try
            {
                var result = _orderManager.AddOrder(_newOrder);
                "Add Succesful".SuccessMessage();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Add Order Failed: You Must Enter a Valid Existing User ID");
            }
            this.NavigationService?.Navigate(new ViewOrders());
        }

        /// <summary>
        /// NAME: Jesse Tomash
        /// DATE: 4/15/2020
        ///
        /// Approver:
        /// Approver: 
        /// 
        /// Helper method to retrieve user name from user table
        /// </summary>
        /// /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        /// <returns></returns>
        private void FetchUserName()
        {
            _userManager = new UserManager();
            _user = _userManager.getUserByUserID(_order.UserID);
            firstName = _user.FirstName;
            lastName = _user.LastName;
        }
    }
}
