using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
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

namespace WPFPresentationLayer.FMPages
{
    /// <summary>
    /// Creator: Carl Davis
    /// Created: 2/28/2020
    /// Approver: Ethan Murphy 3/6/2020
    /// 
    /// Interaction logic for FacilityInspectionControls.xaml
    /// </summary>
    public partial class FacilityInspectionControls : Page
    {
        private IFacilityInspectionManager _facilityInspectionManager;

        string[] inspectionItems =
        {
            "Inspection ID",
            "User ID",
            "Inspector Name"
        };
        FacilityInspection selectedFacilityInspection;

        private PetUniverseUser _user;


        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/28/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// constructor for facility inspection controls
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityInspectionControls()
        {
            InitializeComponent();
            _facilityInspectionManager = new FacilityInspectionManager();
            selectedFacilityInspection = new FacilityInspection();
            cmbFacilityInspectionFields.ItemsSource = inspectionItems;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/4/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// constructor for facility inspection controls
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FacilityInspectionControls(PetUniverseUser user)
        {
            InitializeComponent();
            _facilityInspectionManager = new FacilityInspectionManager();
            selectedFacilityInspection = new FacilityInspection();
            cmbFacilityInspectionFields.ItemsSource = inspectionItems;
            _user = user;
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/4/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// displays the add facility inspection canvas
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFacilityInspection_Click(object sender, RoutedEventArgs e)
        {
            canAddFacilityInspection.Visibility = Visibility.Visible;
            txtUserID.Text = _user.PUUserID.ToString();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/4/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// creates a new record the user has entered if validated
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitInspectionRecord_Click(object sender, RoutedEventArgs e)
        {


            if (string.IsNullOrEmpty(txtUserID.Text) || !long.TryParse(txtUserID.Text, out long num))
            {
                MessageBox.Show("Please enter a valid user id");
                return;
            }
            if (string.IsNullOrEmpty(txtInspectorName.Text))
            {
                MessageBox.Show("Please enter the maintenance name");
                return;
            }
            if (string.IsNullOrEmpty(cndInspectionDate.SelectedDate.ToString()))
            {
                MessageBox.Show("Please enter the maintenance interval");
                return;
            }
            if (string.IsNullOrEmpty(txtInspectionDescription.Text))
            {
                MessageBox.Show("Please enter the maintenance description");
                return;
            }

            try
            {
                FacilityInspection facilityInspection = new FacilityInspection
                {
                    UserID = Int32.Parse(txtUserID.Text),
                    InspectorName = txtInspectorName.Text,
                    InspectionDate = (DateTime)cndInspectionDate.SelectedDate,
                    InspectionDescription = txtInspectionDescription.Text
                };
                if (_facilityInspectionManager.AddFacilityInspectionRecord(facilityInspection))
                {
                    MessageBox.Show("Inspection record successfully added.");
                    canAddFacilityInspection.Visibility = Visibility.Hidden;
                    // RefreshViewAllList();
                    txtUserID.Text = "";
                    txtInspectorName.Text = "";
                    txtInspectionDescription.Text = "";
                }
                else
                {
                    MessageBox.Show("Inspection record was not added.");
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Save");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/4/2020
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// cancels updated a record and brings user back to display screen
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelInspectionRecord_Click(object sender, RoutedEventArgs e)
        {
            txtUserID.Text = "";
            txtInspectorName.Text = "";
            txtInspectionDescription.Text = "";
            lblFacilityMaintenance.Content = "Enter Facility Inspection Record";
            if (btnUpdateBuildingInspectionRecord.Visibility == Visibility.Visible)
            {
                btnUpdateBuildingInspectionRecord.Visibility = Visibility.Hidden;
                BtnSubmitInspectionRecord.Visibility = Visibility.Visible;
            }
            canAddFacilityInspection.Visibility = Visibility.Hidden;
        }
    }
}
