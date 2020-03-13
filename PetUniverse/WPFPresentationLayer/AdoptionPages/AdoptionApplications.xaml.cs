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
using LogicLayer;
using LogicLayerInterfaces;
using DataTransferObjects;

namespace WPFPresentationLayer.AdoptionPages
{
    /// <summary>
    /// Creator: Awaab Elamin
    /// Created: 2020/02/04
    /// Approver : Mohamed Elamin , 2/21/2020
    ///
    /// This class represent the tracking methode for the Adoption Application Xaml
    /// </summary>
    public partial class AdoptionApplications : Page
    {
        private IAdoptionManager adoptionManager;
        private AdoptionApplication adoptionApplication;
        private string customerLastName;
        private ReviewerManager reviewerManager;
        private Customer customer;
        private List<Customer> customers;

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver : Mohamed Elamin , 2/21/2020
        ///
        /// default construct create an object for reviewer manager(Logic Layer)
        /// </summary>
        public AdoptionApplications()
        {
            InitializeComponent();
            adoptionManager = new ReviewerManager();
            customers = new List<Customer>();
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver : Mohamed Elamin , 2/21/2020
        ///
        /// when load the page, data grid view must show all the adoption applications for customers that
        /// filled the questionnair
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
        /// Approver : Mohamed Elamin , 2/21/2020
        ///
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

                    this.customerLastName = adoptionApplication.CustomerName;
                    reviewerManager = new ReviewerManager();
                    customer = reviewerManager.retrieveCustomerByCustomerName(customerLastName);
                    
                    List<CustomerQuestionnarVM> customerQuestionnar= reviewerManager.retrieveCustomerQuestionnar(customer.CustomerID);
                    lblCustomerName.Content = customerQuestionnar[0].CustomerLastName;
                    foreach (CustomerQuestionnarVM customerQuestionnarVM in customerQuestionnar)
                    {
                        Questionnair questionnair = new Questionnair()
                        {
                            question = customerQuestionnarVM.QuestionDescription,
                            answer = customerQuestionnarVM.CustomerAnswer,
                        };
                        questionnairs.Add(questionnair);
                    }
                    DGViewQuestionnair.ItemsSource = questionnairs;
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
        /// Approver : Mohamed Elamin , 2/21/2020
        ///
        /// open (Hidden/visible) the reviewer decssion page
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnReviewerDecisionView_Click(object sender, RoutedEventArgs e)
        {
            if (customer != null)
            {
                adoptionApplication = reviewerManager.retrieveCustomerAdoptionApplicaionByCustomerID(customer.CustomerID);
                txtAdoptionApplicationID.IsReadOnly = true;
                txtCustomerLastName.IsReadOnly = true;
                txtAnimalName.IsReadOnly = true;
                txtAdoptionApplicationID.Text = adoptionApplication.AdoptionApplicationID.ToString();
                txtCustomerLastName.Text = adoptionApplication.CustomerName;
                txtAnimalName.Text = adoptionApplication.AnimalName;
                

                ReviewerDecission.Visibility = Visibility.Visible;
                ViewAdoptionApplications.Visibility = Visibility.Hidden;
                CustomerQustionnair.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Creator: Awaab Elamin
        /// Created: 2020/02/04
        /// Approver : Mohamed Elamin , 2/21/2020
        ///
        ///submit the reviewer decission (Approve/Deny)
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnSubmitDecision_Click(object sender, RoutedEventArgs e)
        {
            
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

        private void DGViewData_Loaded(object sender, RoutedEventArgs e)
        {
            DGViewData.ItemsSource = adoptionManager.retrieveCustomersFilledQuestionnair();
        }

        private void btnBackToQuestionnair_Click(object sender, RoutedEventArgs e)
        {
            ReviewerDecission.Visibility = Visibility.Hidden;
            ViewAdoptionApplications.Visibility = Visibility.Hidden;
            CustomerQustionnair.Visibility = Visibility.Visible;
        }

        private void btnBackFromDecisiion_Click(object sender, RoutedEventArgs e)
        {
            ReviewerDecission.Visibility = Visibility.Hidden;
            ViewAdoptionApplications.Visibility = Visibility.Visible;
            CustomerQustionnair.Visibility = Visibility.Hidden;
        }
    }
}
