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
using LogicLayerInterfaces;
using LogicLayer;


namespace WPFPresentationLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Awaab Elamin, 2020/02/21
    ///
    ///  This class has interaction logic for the HomeInspectorAdoptionApplication
    ///  window.
    /// </summary>
    public partial class frmAdoptionApplictionDetails : Page
    {
        private HomeInspectorAdoptionAppointmentDecision _homeInspectionAppointmentDecision = null;
        private IInHomeInspectionAppointmentDecisionManager
            _inHomeInspectionAppointmentDecisionManager = null;
        private bool _addMode = false;


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This is the Constructor method for Adoption Appliction Details
        /// window.
        /// 
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <returns>Customer Name</returns>
        public frmAdoptionApplictionDetails(IInHomeInspectionAppointmentDecisionManager
            inHomeInspectionAppointmentDecisionManager)
        {
            InitializeComponent();
            _inHomeInspectionAppointmentDecisionManager = inHomeInspectionAppointmentDecisionManager;
            _addMode = true;

        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This is the Constructor method for Adoption Appliction Details
        /// window.
        /// 
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="homeInspectorAdoptionAppointmentDecision"></param>
        /// <param name="inHomeInspectionAppointmentDecisionManager"></param>
        /// <returns>Customer Name</returns>

        public frmAdoptionApplictionDetails(HomeInspectorAdoptionAppointmentDecision
            homeInspectorAdoptionAppointmentDecision, IInHomeInspectionAppointmentDecisionManager
            inHomeInspectionAppointmentDecisionManager)
        {
            InitializeComponent();
            _homeInspectionAppointmentDecision = homeInspectorAdoptionAppointmentDecision;
            _inHomeInspectionAppointmentDecisionManager = inHomeInspectionAppointmentDecisionManager;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This is an event when btnCancel is clicked.
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

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This is an event when Edit button is clicked.
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
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            SetEditMode();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This is an event on the window first loads.
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
            txtAppointmentID.IsReadOnly = true;

            if (_addMode == false)
            {
                txtAppointmentID.Text = _homeInspectionAppointmentDecision.AppointmentID.ToString();
                txtAdoptionApplicationID.Text = _homeInspectionAppointmentDecision
               .AdoptionApplicationID.ToString();
                txtAppointmentTypeID.Text = _homeInspectionAppointmentDecision.AppointmentTypeID;
                DateTime.Text = _homeInspectionAppointmentDecision.DateTime.ToString();
                txtNotes.Text = _homeInspectionAppointmentDecision.Notes;
                cmbDecision.Text = _homeInspectionAppointmentDecision.Decision;
                txtLocationID.Text = _homeInspectionAppointmentDecision.LocationID.ToString();
                txtActive.Text = _homeInspectionAppointmentDecision.Active.ToString();

                txtAdoptionApplicationID.IsReadOnly = true;
                txtAppointmentTypeID.IsReadOnly = true;
                DateTime.IsReadOnly = true;
                txtNotes.IsReadOnly = true;
                cmbDecision.IsEnabled = false;
                txtLocationID.IsReadOnly = true;
                txtActive.IsReadOnly = true;

                cmbDecision.Items.Add("Denied");
                cmbDecision.Items.Add("Approved");

            }
            else
            {
                SetEditMode();
                txtAdoptionApplicationID.IsReadOnly = true;
                txtAppointmentTypeID.IsReadOnly = true;
                DateTime.IsReadOnly = true;
                txtNotes.IsReadOnly = true;
                cmbDecision.IsEnabled = true;
                txtLocationID.IsReadOnly = true;
                txtActive.IsReadOnly = true;
            }
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This is void method will be called to set the edit mode.
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
        private void SetEditMode()
        {
            _addMode = true;
            txtAdoptionApplicationID.IsReadOnly = true;
            txtAppointmentTypeID.IsReadOnly = true;
            DateTime.IsReadOnly = true;
            txtNotes.IsReadOnly = false;
            cmbDecision.IsEnabled = true;
            txtLocationID.IsReadOnly = true;
            txtActive.IsReadOnly = true;

            btnEdit.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This is an Event on Save Button is clicked.
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
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            HomeInspectorAdoptionAppointmentDecision newHomeInspectorAdoptionAppointmentDecision =
                new HomeInspectorAdoptionAppointmentDecision()
                {
                    AppointmentID = Convert.ToInt32(txtAppointmentID.Text),
                    Notes = txtNotes.Text.ToString(),
                    Decision = cmbDecision.Text.ToString()
                };

            if (_addMode)
            {
                try
                {
                    if (_inHomeInspectionAppointmentDecisionManager.EditAppointment
                        (_homeInspectionAppointmentDecision, newHomeInspectorAdoptionAppointmentDecision))
                    {
                        this.NavigationService?.Navigate(new frmInHomeInspectorDecision());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\n\n"
                       + ex.InnerException.Message);
                }
            }
            else
            {
                throw new ApplicationException("Data not Saved.",
                    new ApplicationException("User may no longer exist.")); ;
            }
        }
    }
}
