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
                MessageBox.Show("Please enter the inspector name");
                return;
            }
            if (string.IsNullOrEmpty(cndInspectionDate.SelectedDate.ToString()))
            {
                MessageBox.Show("Please enter the inspection date");
                return;
            }
            if (string.IsNullOrEmpty(txtInspectionDescription.Text))
            {
                MessageBox.Show("Please enter the inspection description");
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
                    RefreshViewAllList();
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

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/12/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// 
        /// method to load facility maintenance data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgFacilityInspection_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgFacilityInspection.ItemsSource == null)
                {
                    dgFacilityInspection.ItemsSource = _facilityInspectionManager.RetrieveAllFacilityInspection((bool)chkInspected.IsChecked);
                    dgFacilityInspection.Columns[0].Header = "Facility Inspection ID";
                    dgFacilityInspection.Columns[1].Header = "User ID";
                    dgFacilityInspection.Columns[2].Header = "Inspector Name";
                    dgFacilityInspection.Columns[3].Header = "Inspection Date";
                    dgFacilityInspection.Columns[4].Header = "Inspection Description";
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Retrive");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/12/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// 
        /// method to refresh the data grid items
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshViewAllList()
        {
            try
            {
                dgFacilityInspection.ItemsSource = _facilityInspectionManager.RetrieveAllFacilityInspection((bool)chkInspected.IsChecked);
                dgFacilityInspection.Columns[0].Header = "Facility Inspection ID";
                dgFacilityInspection.Columns[1].Header = "User ID";
                dgFacilityInspection.Columns[2].Header = "Inspector Name";
                dgFacilityInspection.Columns[3].Header = "Inspection Date";
                dgFacilityInspection.Columns[4].Header = "Inspection Description";

            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/12/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// 
        /// Refeshes the view all list when chkActive is clicked
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkInspected_Click(object sender, RoutedEventArgs e)
        {
            RefreshViewAllList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/12/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// 
        /// Refeshes the view all list
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshViewAllList();
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 3/12/2020
        /// Approver: Ethan Murphy 3/13/2020
        /// 
        /// searches the item inputed by the user and displays it on the screen
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (cmbFacilityInspectionFields.Text == inspectionItems[0])
            {
                try
                {
                    int inspectionID = Int32.Parse(txtSearchItem.Text);
                    dgFacilityInspection.ItemsSource = _facilityInspectionManager.RetrieveFacilityInspectionByID(inspectionID, (bool)chkInspected.IsChecked);
                    dgFacilityInspection.Columns[0].Header = "Facility Inspection ID";
                    dgFacilityInspection.Columns[1].Header = "User ID";
                    dgFacilityInspection.Columns[2].Header = "Inspector Name";
                    dgFacilityInspection.Columns[3].Header = "Inspection Date";
                    dgFacilityInspection.Columns[4].Header = "Inspection Description";
                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
            else if (cmbFacilityInspectionFields.Text == inspectionItems[1])
            {
                try
                {
                    int userID = Int32.Parse(txtSearchItem.Text);
                    dgFacilityInspection.ItemsSource = _facilityInspectionManager.RetrieveFacilityInspectionByUserID(userID, (bool)chkInspected.IsChecked);
                    dgFacilityInspection.Columns[0].Header = "Facility Inspection ID";
                    dgFacilityInspection.Columns[1].Header = "User ID";
                    dgFacilityInspection.Columns[2].Header = "Inspector Name";
                    dgFacilityInspection.Columns[3].Header = "Inspection Date";
                    dgFacilityInspection.Columns[4].Header = "Inspection Description";
                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
            else if (cmbFacilityInspectionFields.Text == inspectionItems[2])
            {
                try
                {
                    string inspectorName = txtSearchItem.Text;
                    dgFacilityInspection.ItemsSource = _facilityInspectionManager.RetrieveFacilityInspectionByInspectorName(inspectorName, (bool)chkInspected.IsChecked);
                    dgFacilityInspection.Columns[0].Header = "Facility Inspection ID";
                    dgFacilityInspection.Columns[1].Header = "User ID";
                    dgFacilityInspection.Columns[2].Header = "Inspector Name";
                    dgFacilityInspection.Columns[3].Header = "Inspection Date";
                    dgFacilityInspection.Columns[4].Header = "Inspection Description";
                }
                catch (Exception ex)
                {

                    WPFErrorHandler.ErrorMessage(ex.Message, "Retrieve");
                }
            }
        }
    }
}
