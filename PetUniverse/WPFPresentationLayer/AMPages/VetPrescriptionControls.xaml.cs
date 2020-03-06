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
    /// Approver: 
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
        private void BtnCreatePrescription_Click(object sender, RoutedEventArgs e)
        {
            canViewCreatePrescription.Visibility = Visibility.Visible;
            try
            {
                dgAppointmentList.ItemsSource = new VetAppointmentManager().RetrieveAllVetAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex + " " + ex.InnerException.Message);
            }
            dateStartDate.DisplayDateStart = DateTime.Now;
            dateEndDate.DisplayDateStart = DateTime.Now.AddDays(1);
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
            canViewCreatePrescription.Visibility = Visibility.Hidden;
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
        private void BtnSave_Click(object sender, RoutedEventArgs e)
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
                Double.Parse(txtDosage.Text);
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
                Dosage = Double.Parse(txtDosage.Text),
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
            canViewCreatePrescription.Visibility = Visibility.Hidden;
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
    }
}
