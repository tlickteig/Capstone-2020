using DataTransferObjects;
using LogicLayer;
using PresentationUtilityCode;
using System;
using System.Windows;
using System.Windows.Controls;

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
        UserManager _userManager;
        SpecialOrder _order;
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
        public ViewAddSpecialOrder()
        {
            InitializeComponent();
            _orderManager = new SpecialOrderManager();
            _order = new SpecialOrder();
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
        public ViewAddSpecialOrder(SpecialOrder order)
        {
            InitializeComponent();
            _orderManager = new SpecialOrderManager();
            _order = order;
            btnBack.Visibility = Visibility.Visible;
            btnSaveOrder.Visibility = Visibility.Hidden;
            txtUserID.Visibility = Visibility.Visible;
            txtOrderID.Visibility = Visibility.Visible;
            txtOrderID.IsReadOnly = true;
            txtUserID.IsReadOnly = true;
            txtOrderID.Text = order.SpecialOrderID.ToString();
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
        /// UPDATED BY: Brandyn T. Coverdill
        /// UPDATE DATE: 4/8/2020
        /// WHAT WAS CHANGED: Made it so that instead of throwing an error, it popped up an error message to have the user
        /// enter a valid employee ID.
        /// </remarks>
        /// <returns></returns>
        private void btnBack_Click(object sender, RoutedEventArgs e)
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
        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            SpecialOrderManager _orderManager = new SpecialOrderManager();
            try
            {
                if (txtUserID.Text == "")
                {
                    "You must fill out all the Fields.".ErrorMessage();
                    return;
                }

                SpecialOrder _newOrder = new SpecialOrder()
                {
                    UserID = Int32.Parse(txtUserID.Text)
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
