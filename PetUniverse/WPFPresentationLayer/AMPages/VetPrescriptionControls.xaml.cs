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
using DataTransferObjects;
using LogicLayerInterfaces;
using LogicLayer;

namespace WPFPresentationLayer.AMPages
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/21/2020
    /// Approver: Zach Behrensmeyer
    /// Approver: 
    /// 
    /// A page to perform animal prescription CRUD functions
    /// </summary>
    public partial class VetPrescriptionControls : Page
    {
        private IAnimalPrescriptionManager _animalPrescriptionManager;
        private AnimalVetAppointment _selectedAppointment;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/22/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Default constructor. Initializes the prescription manager
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public VetPrescriptionControls()
        {
            InitializeComponent();
            _animalPrescriptionManager = new AnimalPrescriptionsManager();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Closes the prescription creation page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            canViewPrescription.Visibility = Visibility.Hidden;
            ResetFields();
            DisableAddMode();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/16/2020
        /// Approver: Carl Davis 2/21/2020
        /// Approver: Daulton Schilling 2/21/2020
        /// 
        /// Save button click event. Saves a new animal 
        /// prescription record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (btnSaveEdit.Content.Equals("Save"))
            {
                if (_selectedAppointment == null)
                {
                    MessageBox.Show("Please select a corresponding vet appointment " +
                        "by double clicking a record on the right");
                    return;
                }
                if (txtPrescriptionName.Text == "")
                {
                    MessageBox.Show("Prescription name can't be blank!");
                    return;
                }
                if (txtDosage.Text == "")
                {
                    MessageBox.Show("Dosage can't be blank");
                    return;
                }
                try
                {
                    Decimal.Parse(txtDosage.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid dosage entered. Please enter a number");
                    return;
                }
                if (txtInterval.Text == "")
                {
                    MessageBox.Show("Interval can't be blank");
                    return;
                }
                if (txtAdministrationMethod.Text == "")
                {
                    MessageBox.Show("Administration method can't be blank");
                    return;
                }

                AnimalPrescriptions animalPrescription = new AnimalPrescriptions()
                {
                    AnimalID = _selectedAppointment.AnimalID,
                    AnimalVetAppointmentID = _selectedAppointment.VetAppointmentID,
                    PrescriptionName = txtPrescriptionName.Text,
                    Dosage = Decimal.Parse(txtDosage.Text),
                    Interval = txtInterval.Text,
                    AdministrationMethod = txtAdministrationMethod.Text,
                    StartDate = (DateTime)dateStartDate.SelectedDate,
                    EndDate = (DateTime)dateEndDate.SelectedDate,
                    Description = txtDescription.Text
                };
                try
                {
                    if (_animalPrescriptionManager.AddAnimalPrescriptionRecord(animalPrescription))
                    {
                        MessageBox.Show("Record added!");
                        DisableAddMode();
                        RefreshPrescriptionsList();
                    }
                    else
                    {
                        throw new ApplicationException();
                    }
                }
                catch (Exception ex)
                {
                    string message = ex == null ? "Record not added" : ex.Message + " " + ex.InnerException;
                    MessageBox.Show(message);
                }
                canViewPrescription.Visibility = Visibility.Hidden;
            }
            else
            {
                // TODO Enable Edit Mode
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/22/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Sets the _selectedAppointment to the selected record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgAppointmentList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgAppointmentList.SelectedItem != null)
            {
                _selectedAppointment = (AnimalVetAppointment)dgAppointmentList.SelectedItem;
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/22/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Opens the prescription creation page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            canViewPrescription.Visibility = Visibility.Visible;
            try
            {
                dgAppointmentList.ItemsSource = new VetAppointmentManager().RetrieveAllVetAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + " " + ex.InnerException.Message);
            }
            EnableAddMode();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: 
        /// 
        /// Opens the prescription detail page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (dgPrescriptions.SelectedItem == null)
            {
                return;
            }
            PopulateFields((AnimalPrescriptions)dgPrescriptions.SelectedItem);
            canViewPrescription.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: 
        /// 
        /// Event to retrieve the prescription list when
        /// the data grid is loaded
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgPrescriptions_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshPrescriptionsList();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Refreshes the list
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void RefreshPrescriptionsList()
        {
            dgPrescriptions.ItemsSource = null;
            try
            {
                dgPrescriptions.ItemsSource =
                    _animalPrescriptionManager.RetrieveAllAnimalPrescriptions();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Prepares the form controls for
        /// adding a new record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableAddMode()
        {
            txtPrescriptionName.IsEnabled = true;
            txtDosage.IsEnabled = true;
            txtInterval.IsEnabled = true;
            dateStartDate.IsEnabled = true;
            dateEndDate.IsEnabled = true;
            txtAdministrationMethod.IsEnabled = true;
            txtDescription.IsEnabled = true;
            dgAppointmentList.Visibility = Visibility.Visible;
            lblAppointmentList.Visibility = Visibility.Visible;
            btnSaveEdit.Content = "Save";
            dateStartDate.DisplayDateStart = DateTime.Now;
            dateEndDate.DisplayDateStart = DateTime.Now.AddDays(1);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Sets the form controls to their default state
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableAddMode()
        {
            txtPrescriptionName.IsEnabled = false;
            txtDosage.IsEnabled = false;
            txtInterval.IsEnabled = false;
            dateStartDate.IsEnabled = false;
            dateEndDate.IsEnabled = false;
            txtAdministrationMethod.IsEnabled = false;
            txtDescription.IsEnabled = false;
            dgAppointmentList.Visibility = Visibility.Hidden;
            lblAppointmentList.Visibility = Visibility.Hidden;
            btnSaveEdit.Content = "Edit";
            dgAppointmentList.ItemsSource = null;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Populates the form controls when
        /// a record is opened
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void PopulateFields(AnimalPrescriptions animalPrescription)
        {
            txtPrescriptionName.Text = animalPrescription.PrescriptionName;
            txtDosage.Text = animalPrescription.Dosage.ToString();
            txtInterval.Text = animalPrescription.Interval;
            dateStartDate.SelectedDate = animalPrescription.StartDate;
            dateEndDate.SelectedDate = animalPrescription.EndDate;
            txtAdministrationMethod.Text = animalPrescription.AdministrationMethod;
            txtDescription.Text = animalPrescription.Description;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Resets form controls to default values
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ResetFields()
        {
            txtPrescriptionName.Text = "";
            txtDosage.Text = "";
            txtInterval.Text = "";
            dateStartDate.SelectedDate = null;
            dateEndDate.SelectedDate = null;
            txtAdministrationMethod.Text = "";
            txtDescription.Text = "";
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Event that triggers when the StartDate is changed
        /// Updates the EndDate date picker to only allow for dates
        /// after the StartDate value
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DateStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (btnSaveEdit.Content.ToString() == "Save" &&
                dateStartDate.SelectedDate != null)
            {
                dateEndDate.SelectedDate = null;
                dateEndDate.DisplayDateStart = dateStartDate.SelectedDate.Value.AddDays(1);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Button click event to search for records
        /// by animal name
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (btnSearch.Content.Equals("Search"))
            {
                if (txtSearch.Text == "")
                {
                    MessageBox.Show("Search field is blank!");
                    return;
                }
                try
                {
                    dgPrescriptions.ItemsSource = null;
                    dgPrescriptions.ItemsSource =
                        _animalPrescriptionManager.RetrievePrescriptionsByAnimalName(txtSearch.Text);
                    btnSearch.Content = "Reset";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
                }
            }
            else
            {
                RefreshPrescriptionsList();
                btnSearch.Content = "Search";
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/9/2020
        /// Approver: Carl Davis 3/13/2020
        /// 
        /// Clear the search field when selected
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void TxtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }
    }
}
