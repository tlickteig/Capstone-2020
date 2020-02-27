using DataTransferObjects;
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

namespace WPFPresentationLayer.AdoptionPages
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Thomas Dupuy , 2020/02/21
    ///
    ///  This class has interaction logic for the frmAdoptionCustomerDetails
    ///  page.
    /// </summary>
    public partial class CustomerDetail : Page
    {
        private Customer _customer;
        private ICustomerManager _customerManager = null;

        public CustomerDetail(string customerName)
        {
            InitializeComponent();
            _customerManager = new CustomerManager();
            _customer = _customerManager.RetrieveCustomerByCustomerName(customerName);
        }


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Thomas Dupuy 2020/02/21
        /// 
        /// This is an load event for the Adoption Customer details page.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                txtUserID.Text = _customer.UserID.ToString();
                txtFirstName.Text = _customer.FirstName;
                txtLasttName.Text = _customer.LastName;
                txtPhoneNumbere.Text = _customer.PhoneNumber;
                txtEmail.Text = _customer.Email;
                txtActiv.Text = _customer.Activ.ToString();
                txtAddressLineOne.Text = _customer.AddressLineOne;
                txtAddressLineTwo.Text = _customer.AddressLineTwo;
                txtCity.Text = _customer.City;
                txtState.Text = _customer.State;
                txtZipCode.Text = _customer.ZipCode;



                txtUserID.IsReadOnly = true;
                txtFirstName.IsReadOnly = true;
                txtLasttName.IsReadOnly = true;
                txtPhoneNumbere.IsReadOnly = true;
                txtEmail.IsReadOnly = true;
                txtAddressLineOne.IsReadOnly = true;
                txtAddressLineTwo.IsReadOnly = true;
                txtZipCode.IsReadOnly = true;
                txtCity.IsReadOnly = true;
                txtState.IsReadOnly = true;
                txtActiv.IsReadOnly = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService?.Navigate(new frmHomeInspectionForm());
                           
            
        }
    }
}

