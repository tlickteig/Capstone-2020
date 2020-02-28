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
using System.Windows.Shapes;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;



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
            dgAdoptionApplicationsAappointmentsList.Columns[0].Header = "Appointment ID";
            dgAdoptionApplicationsAappointmentsList.Columns[1].Header = "Adoption Application ID";
            dgAdoptionApplicationsAappointmentsList.Columns[2].Header = "Appointment Type ID";
            dgAdoptionApplicationsAappointmentsList.Columns[3].Header = "DateTime";
            dgAdoptionApplicationsAappointmentsList.Columns[4].Header = "Notes";
            dgAdoptionApplicationsAappointmentsList.Columns[5].Header = "Decision";
            dgAdoptionApplicationsAappointmentsList.Columns[6].Header = "Location ID";
            dgAdoptionApplicationsAappointmentsList.Columns[7].Header = "Active";

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
    }
}
