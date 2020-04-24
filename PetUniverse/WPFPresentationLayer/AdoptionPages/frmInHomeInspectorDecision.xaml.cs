using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;



namespace WPFPresentationLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Awaab Elamin, 2020/02/21
    ///
    ///  This class has interaction logic for the In=Home InspectorDecision
    ///  window.
    public partial class frmInHomeInspectorDecision : Page
    {

        private IInHomeInspectionAppointmentDecisionManager _inHomeInspectionAppointmentDecisionManager;


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This This constructor method for In-Home InspectorDecision Window.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <returns></returns>
        public frmInHomeInspectorDecision()
        {
            InitializeComponent();
            _inHomeInspectionAppointmentDecisionManager = new InHomeInspectionAppointmentDecisionManager();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This method fills in data for In-Home Inspector Decision Data Gird.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        private void populateAdoptionApplicationsAappointmentsList()
        {
            dgAdoptionApplicationsAappointmentsList.ItemsSource =
                    _inHomeInspectionAppointmentDecisionManager.SelectAdoptionApplicationsAappointmentsByAppointmentType();
            dgAdoptionApplicationsAappointmentsList.Columns[0].Visibility = Visibility.Hidden;
            dgAdoptionApplicationsAappointmentsList.Columns[7].Visibility = Visibility.Hidden;
            dgAdoptionApplicationsAappointmentsList.Columns[8].Visibility = Visibility.Hidden;

        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This is an Event on the window first loads.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param>
        /// <returns></returns>   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            populateAdoptionApplicationsAappointmentsList();

        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This is an Event on btnOpen is clicked.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" sender"></param>
        /// <param name=" e"></param>
        /// <returns></returns>   
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {

            HomeInspectorAdoptionAppointmentDecision selectedUser =
                (HomeInspectorAdoptionAppointmentDecision)dgAdoptionApplicationsAappointmentsList.SelectedItem;
            if (selectedUser == null)
            {
                MessageBox.Show("Please select an appliction to see the details");
                return;

            }


            this.NavigationService?.Navigate(new frmAdoptionApplictionDetails
                (selectedUser, _inHomeInspectionAppointmentDecisionManager));


        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 03/10/2020
        /// Approved By: Awaab Elamin , 03/13/2020 
        /// 
        /// This click event when send email button is clicked. It will send an email
        /// to the adoption application customer's email.
        /// Application ID.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HomeInspectorAdoptionAppointmentDecision selectedApplication =
                    (HomeInspectorAdoptionAppointmentDecision)dgAdoptionApplicationsAappointmentsList.SelectedItem;
                if (selectedApplication == null)
                {
                    MessageBox.Show("Please select an application to notify the customer by email");
                    return;
                }

                var customerEmail =
                    _inHomeInspectionAppointmentDecisionManager.GetCustomerEmailByAdoptionApplicationID(
                        selectedApplication.AdoptionApplicationID);

                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("pet@gmail.com");
                mail.To.Add(customerEmail); // getting the Customer's email from database
                mail.Subject = "Adoption Application Status";
                mail.Body = "Hello, your Application has been approved ";
                smtpServer.Port = 80;
                smtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                smtpServer.EnableSsl = true;
                //smtpServer.Send(mail);
                MessageBox.Show("Email has been sent Successfully to " + customerEmail);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Can't Send the Email", ex.Message + "\n\n"
                                                                  + ex.InnerException.Message);
            }

        }
    }
}
