using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.AdoptionPages
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/04
    /// Approver : Mohamed Elamin
    /// This class represent the tracking methode for the AdoptionApplication Xaml
    /// </summary>
    public partial class AdoptionApplications : Page
    {
        private IAdoptionManager adoptionManager;
        private AdoptionApplication adoptionApplication;
        private string customerEmail;
        private ReviewerManager reviewerManager;
        private AdoptionCustomer customer;
        private List<AdoptionCustomer> customers;

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver : Mohamed Elamin 
        ///
        /// default construct intial attributes (adoptionManager, customers)
        /// </summary>
        ///<remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        public AdoptionApplications()
        {
            InitializeComponent();
            adoptionManager = new ReviewerManager();
            customers = new List<AdoptionCustomer>();
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver : Mohamed Elamin
        /// when load the page, data grid view must show all the adoption applications 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DGViewData.ItemsSource = adoptionManager.retrieveCustomersFilledQuestionnair();
            ReviewerDecission.Visibility = Visibility.Hidden;
            ViewAdoptionApplications.Visibility = Visibility.Visible;
            CustomerQustionnair.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver : Mohamed Elamin
        /// after reviewer select a customer record, btnOpenRecord retrireve that customer data and filled 
        /// the customer details and hidden the adoption appliaction then show the customer data
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnOpenRecord_Click(object sender, RoutedEventArgs e)
        {

            List<Questionnair> questionnairs = new List<Questionnair>();
            try
            {
                adoptionApplication = (AdoptionApplication)DGViewData.SelectedItem;
                if (adoptionApplication != null)
                {

                    this.customerEmail = adoptionApplication.CustomerEmail;
                    reviewerManager = new ReviewerManager();
                    customer = reviewerManager.retrieveCustomerByCustomerName(this.customerEmail);

                    List<CustomerQuestionnar> customerQuestionnars = reviewerManager.retrieveCustomerQuestionnar(this.customerEmail);
                    lblCustomerName.Content = adoptionApplication.CustomerEmail;

                    DGViewQuestionnair.ItemsSource = customerQuestionnars;
                    adoptionApplication = new AdoptionApplication();

                    ReviewerDecission.Visibility = Visibility.Hidden;
                    ViewAdoptionApplications.Visibility = Visibility.Hidden;
                    CustomerQustionnair.Visibility = Visibility.Visible;

                }
                else
                {
                    lblAdoptionApplicationErrorMessage.Content = "Please select a customer";
                }
            }
            catch (Exception)
            {
                lblAdoptionApplicationErrorMessage.Content = "This customer did not fill the questionnar!";

            }




        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver : Mohamed Elamin 
        /// open (Hidden/visible) the reviewer decssion page
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnReviewerDecisionView_Click(object sender, RoutedEventArgs e)
        {

            if (DGViewData.SelectedItem != null)
            {
                AdoptionApplication selectedAdoptionApplication = (AdoptionApplication)DGViewData.SelectedItem;
                //adoptionApplication = reviewerManager.retrieveCustomerAdoptionApplicaionByCustomerEmail(selectedAdoptionApplication.CustomerEmail);
                txtAdoptionApplicationID.IsReadOnly = true;
                txtCustomerLastName.IsReadOnly = true;
                txtAnimalName.IsReadOnly = true;
                txtAdoptionApplicationID.Text = selectedAdoptionApplication.AdoptionApplicationID.ToString();
                txtCustomerLastName.Text = selectedAdoptionApplication.CustomerEmail;
                txtAnimalName.Text = selectedAdoptionApplication.AnimalName;


                ReviewerDecission.Visibility = Visibility.Visible;
                ViewAdoptionApplications.Visibility = Visibility.Hidden;
                CustomerQustionnair.Visibility = Visibility.Hidden;
                lblAdoptionApplicationErrorMessage.Content = "";
            }
            else
            {
                txtAdoptionApplicationID.Text = "";
                txtCustomerLastName.Text = "";
                txtAnimalName.Text = "";

                txtAdoptionApplicationID.IsReadOnly = true;
                txtCustomerLastName.IsReadOnly = true;
                txtAnimalName.IsReadOnly = true;

                ReviewerDecission.Visibility = Visibility.Hidden;
                ViewAdoptionApplications.Visibility = Visibility.Visible;
                CustomerQustionnair.Visibility = Visibility.Hidden;
                lblAdoptionApplicationErrorMessage.Content = "Please Select Adoption Application";
            }
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver : Mohamed Elamin 
        ///submit the reviewer decission (Approve/Deny)
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnSubmitDecision_Click(object sender, RoutedEventArgs e)
        {
            adoptionApplication = (AdoptionApplication)DGViewData.SelectedItem;

            if (Interviewer.IsSelected)
            {

                if (adoptionManager.SubmitReviewerDecision(adoptionApplication.AdoptionApplicationID, Interviewer.Content.ToString()))
                {
                    lblDecisionErrorMessage.Content = Interviewer.Content.ToString();
                    lblAdoptionApplicationDecision.Content = Interviewer.Content.ToString();
                    DGViewData.ItemsSource = adoptionManager.retrieveCustomersFilledQuestionnair();
                    ReviewerDecission.Visibility = Visibility.Hidden;
                    ViewAdoptionApplications.Visibility = Visibility.Visible;
                    CustomerQustionnair.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblDecisionErrorMessage.Content = "Please choose a decision";
                    ReviewerDecission.Visibility = Visibility.Visible;
                    ViewAdoptionApplications.Visibility = Visibility.Hidden;
                    CustomerQustionnair.Visibility = Visibility.Hidden;
                }

            }
            else if (Deny.IsSelected)
            {
                if (adoptionManager.SubmitReviewerDecision(adoptionApplication.AdoptionApplicationID, Deny.Content.ToString()))
                {
                    lblDecisionErrorMessage.Content = Deny.Content.ToString();
                    lblAdoptionApplicationDecision.Content = Deny.Content.ToString();
                    DGViewData.ItemsSource = adoptionManager.retrieveCustomersFilledQuestionnair();
                    ReviewerDecission.Visibility = Visibility.Hidden;
                    ViewAdoptionApplications.Visibility = Visibility.Visible;
                    CustomerQustionnair.Visibility = Visibility.Hidden;
                }
                else
                {
                    lblDecisionErrorMessage.Content = "Please choose a decision";
                    ReviewerDecission.Visibility = Visibility.Visible;
                    ViewAdoptionApplications.Visibility = Visibility.Hidden;
                    CustomerQustionnair.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                lblDecisionErrorMessage.Content = "Please choose a decision";
                return;
            }
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver : Mohamed Elamin 
        ///on loading the page, retrieive adoption application and assgin them to the grid view
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void DGViewData_Loaded(object sender, RoutedEventArgs e)
        {
            DGViewData.ItemsSource = adoptionManager.retrieveCustomersFilledQuestionnair();
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver : Mohamed Elamin 
        ///the back button show the adoption applications page and hid others.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnBackToQuestionnair_Click(object sender, RoutedEventArgs e)
        {
            ReviewerDecission.Visibility = Visibility.Hidden;
            ViewAdoptionApplications.Visibility = Visibility.Hidden;
            CustomerQustionnair.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver : Mohamed Elamin 
        ///the back button show the adoption applications page and hid others.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnBackFromDecisiion_Click(object sender, RoutedEventArgs e)
        {
            ReviewerDecission.Visibility = Visibility.Hidden;
            ViewAdoptionApplications.Visibility = Visibility.Visible;
            CustomerQustionnair.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/03/29
        /// Approved By: Awaab Elamin 
        /// This is an event when Back To Inspector Screen button is clicked , And will open
        /// Customer Detail window.And sends the Customer Email to the Customer Detail's
        /// Constructor as an argument.
        /// </summary>
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCustomerDetails_Click(object sender, RoutedEventArgs e)
        {
            AdoptionApplication adoptionApplication = new AdoptionApplication();
            adoptionApplication = (AdoptionApplication)DGViewData.SelectedItem;

            var selectedItem = (AdoptionApplication)DGViewData.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Please select an Adoption Application to open the Customer Details.");
            }
            else
            {
                this.NavigationService?.Navigate(new CustomerDetail
                    (adoptionApplication.CustomerEmail));

            }

        }
    }
}
