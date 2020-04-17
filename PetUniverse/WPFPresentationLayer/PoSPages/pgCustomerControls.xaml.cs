using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// CREATOR: Ethan Holmes
    /// DATE: 4/14/2020
    /// APPROVER: Rasha Mohammed
    /// 
    /// Interaction logic for pgCustomerControls.xaml
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    public partial class pgCustomerControls : Page
    {

        private IPoSCustomerPortalManager _poSCustomerPortalManager;

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Define the error type dropdown menu here.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public pgCustomerControls()
        {
            InitializeComponent();

            _poSCustomerPortalManager = new CustomerPortalManager();

            cbErrorType.Items.Add("ErrorType1");
            cbErrorType.Items.Add("ErrorType2");
            cbErrorType.Items.Add("ErrorType3");
            cbErrorType.Items.Add("ErrorType4");
            cbErrorType.Items.Add("ErrorType5");

            cbCardType.Items.Add("Visa");
            cbCardType.Items.Add("MasterCard");
            cbCardType.Items.Add("American Express");


        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed
        /// 
        /// Button to report an error.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void btnReportError_Click(object sender, RoutedEventArgs e)
        {
            canReportError.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Back button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            canReportError.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Button to submit an error to the db.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void btnErrorSubmit_Click(object sender, RoutedEventArgs e)
        {
            string errorType = cbErrorType.Text.ToString();
            string errorDesc = txtErrorDesc.Text.ToString();


            int update = _poSCustomerPortalManager.ReportShippingError(errorType, errorDesc);

            //this.Close();

            canReportError.Visibility = Visibility.Hidden;

            //canViewTasks.Visibility = Visibility.Visible;
        }

        private void btnAddCreditCard_Click(object sender, RoutedEventArgs e)
        {
            canAddCard.Visibility = Visibility.Visible;
        }

        private void btnBack2_Click(object sender, RoutedEventArgs e)
        {
            canAddCard.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Saves the card to database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void btnErrorSave_Click(object sender, RoutedEventArgs e)
        {
            string cardType;
            string cardNumber;
            string securityCode;

            if (cbCardType.Text.ToString() == "" || cbCardType is null)
            {
                System.Windows.MessageBox.Show("Card Type cannot be empty.");
                return;
            }
            else
            {
                cardType = cbCardType.Text.ToString();

            }

            if (txtCVV.Text.ToString().Length > 3 || txtCVV.Text.ToString() == "")
            {
                System.Windows.MessageBox.Show("Length of code must not be greater than 3 or empty.");
                return;
            }
            else
            {
                securityCode = txtCVV.Text.ToString();
            }

            if (txtCardNumber.Text.ToString() == "" || txtCardNumber.Text.ToString() is null)
            {
                System.Windows.MessageBox.Show("Card Number must not be blank.");
                return;
            }
            else
            {
                cardNumber = txtCardNumber.Text.ToString();
            }

            int add = _poSCustomerPortalManager.AddCreditCard(cardType, cardNumber, securityCode);
            txtCardNumber.Text = "";
            cbCardType.Text = "";
            canAddCard.Visibility = Visibility.Hidden;
        }

        private void dgCreditCardList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgCreditCardList.Columns[0].Header = "Card Type";
            dgCreditCardList.Columns[1].Header = "Card Number";


        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Load event for remove cards. This will display the available credit cards for
        /// removal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void canRemoveCard_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = new DataTable();

            List<CreditCardVM2> creditCards = _poSCustomerPortalManager.GetAllCreditCards();
            try
            {
                if (creditCards.Count != 0)
                {

                    foreach (CreditCardVM2 creditCard in creditCards)
                    {
                        dgCreditCardList.ItemsSource = _poSCustomerPortalManager.GetAllCreditCards();
                    }
                }
                else
                {

                    System.Windows.MessageBox.Show("No data retrieved", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    //MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
                return;
            }
        }

        private void btnRemoveCreditCard_Click(object sender, RoutedEventArgs e)
        {
            canRemoveCard.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// CREATOR: Ethan Holmes
        /// DATE: 4/14/2020
        /// APPROVER: Rasha Mohammed 
        /// 
        /// Remove card click event. Actually removes a credit card record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        private void btnRemoveCard_Click(object sender, RoutedEventArgs e)
        {
            CreditCardVM2 selectedCreditCardVM2 = (CreditCardVM2)dgCreditCardList.SelectedItem;



            DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Deleting this record is permenant, are you sure?", "WARNING", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int result = _poSCustomerPortalManager.DeleteCreditCard(selectedCreditCardVM2.CardNumber.ToString());
                dgCreditCardList.ItemsSource = null;
                dgCreditCardList.ItemsSource = _poSCustomerPortalManager.GetAllCreditCards();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            dgCreditCardList.ItemsSource = null;
            dgCreditCardList.ItemsSource = _poSCustomerPortalManager.GetAllCreditCards();
        }

        private void btnBack3_Click(object sender, RoutedEventArgs e)
        {
            canRemoveCard.Visibility = Visibility.Hidden;
        }
    }
}

