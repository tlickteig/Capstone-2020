using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFPresentationLayer.AMPages
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/7/2020
    /// Approver: Chuck Baxter 2/14/2020
    /// Approver: Carl Davis 2/14/2020
    /// 
    /// A window class to display a list of animal vet appointments
    /// </summary>
    public partial class VetAppointmentControls : Page
    {
        private IVetAppointmentManager _vetAppointmentManager;
        private IAnimalManager _animalManager;
        private PetUniverseUser _user;
        private Animal _selectedAnimal;
        private List<AnimalVetAppointment> _vetAppointments;
        private bool _editMode = false;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// Approver: Carl Davis 2/14/2020
        /// 
        /// No argument constructor that intializes
        /// the animal vet appointment manager
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public VetAppointmentControls(PetUniverseUser user)
        {
            InitializeComponent();
            _vetAppointmentManager = new VetAppointmentManager();
            _animalManager = new AnimalManager();
            _user = user;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// An event that is triggered when the data grid is loaded.
        /// Data grid is populated with vet appointment records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgAppointments_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _vetAppointments = _vetAppointmentManager.RetrieveAllVetAppointments();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
            dgAppointments.ItemsSource = _vetAppointments;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/9/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// Approver: Carl Davis 2/14/2020
        /// 
        /// Opens the filters window with options for filtering
        /// the animal vet appointment list
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            canViewVetAppointmentFilter.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/9/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// Approver: Carl Davis 2/14/2020
        /// 
        /// Opens window for creeating a new animal vet appointment record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnSchedule_Click(object sender, RoutedEventArgs e)
        {
            canViewVetAppointment.Visibility = Visibility.Visible;
            EnableAddMode();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/21/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Opens a vet appointment record in detail view
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (dgAppointments.SelectedItem != null)
            {
                canViewVetAppointment.Visibility = Visibility.Visible;
                PopulateFields((AnimalVetAppointment)dgAppointments.SelectedItem);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/9/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// Approver: Carl Davis 2/14/2020
        /// 
        /// Populates controls with supplied data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void PopulateFields(AnimalVetAppointment vetAppointment)
        {
            txtAnimalName.Text = vetAppointment.AnimalName;
            dateAppointmentDate.SelectedDate = vetAppointment.AppointmentDateTime;
            txtTime.Text = vetAppointment.AppointmentDateTime.ToString("h:mm tt", CultureInfo.InvariantCulture);
            txtClinicAddress.Text = vetAppointment.ClinicAddress;
            txtVetName.Text = vetAppointment.VetName;
            txtDescription.Text = vetAppointment.AppointmentDescription;
            if (vetAppointment.FollowUpDateTime != null)
            {
                dateFollowUp.SelectedDate = vetAppointment.FollowUpDateTime;
                txtFollowUpTime.Text = vetAppointment.FollowUpDateTime.Value.ToString(
                    "h:mm tt", CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/21/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Sets all controls back to default values
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ClearFields()
        {
            txtAnimalName.Text = "";
            dateAppointmentDate.SelectedDate = null;
            txtTime.Text = "";
            txtClinicAddress.Text = "";
            txtVetName.Text = "";
            txtDescription.Text = "";
            dgAnimalList.ItemsSource = null;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/9/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// Approver: Carl Davis 2/14/2020
        /// 
        /// Prepares UI controls for adding a new record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableAddMode()
        {
            dateAppointmentDate.IsEnabled = true;
            txtTime.IsEnabled = true;
            txtClinicAddress.IsEnabled = true;
            txtDescription.IsEnabled = true;
            txtVetName.IsEnabled = true;
            dateAppointmentDate.DisplayDateStart = DateTime.Now;
            btnSaveEdit.Content = "Save";
            dgAnimalList.Visibility = Visibility.Visible;
            lblAnimalList.Visibility = Visibility.Visible;
            lblFollowUp.Visibility = Visibility.Hidden;
            lblFollowUpTime.Visibility = Visibility.Hidden;
            dateFollowUp.Visibility = Visibility.Hidden;
            txtFollowUpTime.Visibility = Visibility.Hidden;
            try
            {
                dgAnimalList.ItemsSource = _animalManager.RetrieveAnimalsByActive();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/21/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Sets all controls back to read only state
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableAddMode()
        {
            dateAppointmentDate.IsEnabled = false;
            txtTime.IsEnabled = false;
            txtClinicAddress.IsEnabled = false;
            txtDescription.IsEnabled = false;
            txtVetName.IsEnabled = false;
            btnSaveEdit.Content = "Edit";
            dgAnimalList.Visibility = Visibility.Hidden;
            lblAnimalList.Visibility = Visibility.Hidden;
            lblFollowUp.Visibility = Visibility.Visible;
            lblFollowUpTime.Visibility = Visibility.Visible;
            dateFollowUp.Visibility = Visibility.Visible;
            txtFollowUpTime.Visibility = Visibility.Visible;
            ClearFields();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020 
        /// Approver:
        /// 
        /// Prepares the interface for editing the selected record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableEditMode()
        {
            _editMode = true;
            dateAppointmentDate.IsEnabled = true;
            txtTime.IsEnabled = true;
            txtClinicAddress.IsEnabled = true;
            txtDescription.IsEnabled = true;
            txtVetName.IsEnabled = true;
            dateFollowUp.IsEnabled = true;
            txtFollowUpTime.IsEnabled = true;
            btnClearFollowUp.Visibility = Visibility.Visible;
            dateAppointmentDate.DisplayDateStart = DateTime.Now;
            dateFollowUp.DisplayDateStart = DateTime.Now.AddDays(1);
            btnSaveEdit.Content = "Save";
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver:
        /// 
        /// Disables editing mode when the record has been
        /// updated or the edit window was closed
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableEditMode()
        {
            _editMode = false;
            DisableAddMode();
            dateFollowUp.IsEnabled = false;
            txtFollowUpTime.IsEnabled = false;
            btnClearFollowUp.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/21/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Sets the appointment list to null, then
        /// repopulates it with the most recent data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void RefreshList()
        {
            dgAppointments.ItemsSource = null;
            DgAppointments_Loaded(null, null);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/21/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Sets all controls back to default view, then closes 
        /// the vet appointment detail view
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            canViewVetAppointment.Visibility = Visibility.Hidden;
            DisableEditMode();
            ClearFields();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/7/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Validates all submitted information and saves a record
        /// </summary>
        /// <remarks>
        /// Updater: Ethan Murphy
        /// Updated: 3/1/2020
        /// Update: Utlilized validation utility and added edit functionality
        /// Approver: Ben Hanna, 3/6/2020
        /// </remarks>
        private void BtnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (btnSaveEdit.Content.Equals("Save"))
            {
                if (_selectedAnimal == null &&
                    _editMode == false)
                {
                    MessageBox.Show("No animal selected. Please double click on the " +
                        "desired animal in the list on the right");
                    return;
                }
                else if (_editMode)
                {
                    _selectedAnimal = new Animal();
                    _selectedAnimal.AnimalID =
                        ((AnimalVetAppointment)dgAppointments.SelectedItem).AnimalID;
                }
                if (dateAppointmentDate.SelectedDate == null)
                {
                    MessageBox.Show("Please select an appointment date");
                    return;
                }
                if (!txtTime.Text.IsValidTime(dateAppointmentDate.SelectedDate.Value))
                {
                    MessageBox.Show("Invalid time entered. Please enter in 12 hour format (ex. 2:00 PM)");
                    return;
                }
                if (!txtVetName.Text.IsValidVetName())
                {
                    MessageBox.Show("Vet name can't be blank!");
                    return;
                }
                if (!txtClinicAddress.Text.IsValidClinicAddress())
                {
                    MessageBox.Show("Clinic address is invalid");
                    return;
                }
                if (!txtDescription.Text.IsValidAppointmentDescription())
                {
                    MessageBox.Show("Please enter a more descriptive description");
                    return;
                }

                AnimalVetAppointment animalVetAppointment = new AnimalVetAppointment()
                {
                    AnimalID = _selectedAnimal.AnimalID,
                    AnimalName = _selectedAnimal.AnimalName,
                    UserID = _user.PUUserID,
                    AppointmentDateTime = DateTime.Parse(
                        dateAppointmentDate.SelectedDate.Value.ToShortDateString() +
                        " " + txtTime.Text),
                    ClinicAddress = txtClinicAddress.Text,
                    VetName = txtVetName.Text,
                    AppointmentDescription = txtDescription.Text,
                    FollowUpDateTime = null
                };

                if (_editMode)
                {
                    if (dateFollowUp.SelectedDate != null
                        && txtFollowUpTime.Text != "")
                    {
                        if (!txtFollowUpTime.Text.IsValidTime(dateFollowUp.SelectedDate.Value))
                        {
                            MessageBox.Show("Invalid follow up date entered. Leave blank" +
                                " if not applicable");
                            return;
                        }
                        else
                        {
                            animalVetAppointment.FollowUpDateTime =
                                DateTime.Parse(
                                    dateFollowUp.SelectedDate.Value.ToShortDateString() +
                                    " " + txtFollowUpTime.Text);
                        }
                    }
                    try
                    {
                        if (_vetAppointmentManager.EditAnimalVetAppointmentRecord(
                            (AnimalVetAppointment)dgAppointments.SelectedItem, animalVetAppointment))
                        {
                            MessageBox.Show("Record updated!");
                            BtnClose_Click(null, null);
                            RefreshList();
                            DisableEditMode();
                        }
                        else
                        {
                            throw new ApplicationException();
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = ex == null ? "Failed to update record" :
                            ex.Message + " " + ex.InnerException;
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    try
                    {
                        if (_vetAppointmentManager.AddAnimalVetAppointmentRecord(animalVetAppointment))
                        {
                            MessageBox.Show("Appointment has been scheduled!");
                            DisableAddMode();
                            BtnClose_Click(null, null);
                            RefreshList();
                        }
                        else
                        {
                            throw new ApplicationException();
                        }
                    }
                    catch (Exception ex)
                    {
                        string message = ex == null ? "Failed to save record" :
                            ex.Message + " " + ex.InnerException;
                        MessageBox.Show(message);
                    }
                }
            }
            else if (btnSaveEdit.Content.Equals("Edit"))
            {
                EnableEditMode();
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/9/2020
        /// Approver: Carl Davis 2/14/2020
        /// Approver: Chuck Baxter 2/14/2020
        /// 
        /// Applies a filter(s) to the appointment list
        /// then closes the filter page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnApplyFilter_Click(object sender, RoutedEventArgs e)
        {
            if (_vetAppointments == null)
            {
                MessageBox.Show("Vet appointments list is invalid");
                return;
            }
            List<AnimalVetAppointment> currentList = _vetAppointments;
            if ((bool)chkAnimalName.IsChecked)
            {
                try
                {
                    currentList =
                        _vetAppointmentManager.RetrieveAppointmentsByAnimalName(txtFilterName.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to filter by animal name: " + ex);
                    return;
                }
            }
            if ((bool)chkApptDate.IsChecked)
            {
                try
                {
                    currentList =
                        _vetAppointmentManager.RetrieveAppointmentsByDateTime(DateTime.Parse(
                            txtFilterDate.Text));
                }
                catch (Exception ex)
                {
                    string message = ex == null ? "Invalid date entered" :
                        "Data not found: " + ex;
                    MessageBox.Show(message);
                    return;
                }
            }
            if ((bool)chkFollowUp.IsChecked)
            {
                try
                {
                    currentList =
                        _vetAppointmentManager.RetrieveAppointmentsByFollowUpDate(DateTime.Parse(
                            txtFilterFollowUp.Text));
                }
                catch (Exception ex)
                {
                    string message = ex == null ? "Invalid date entered" :
                        "Data not found: " + ex;
                    MessageBox.Show(message);
                    return;
                }
            }
            if ((bool)chkClinicAddress.IsChecked)
            {
                try
                {
                    currentList =
                        _vetAppointmentManager.RetrieveAppointmentsByClinicAddress(txtFilterAddress.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to filter clinic address: " + ex);
                    return;
                }
            }
            if ((bool)chkVetname.IsChecked)
            {
                try
                {
                    currentList =
                        _vetAppointmentManager.RetrieveAppointmentsByVetName(txtFilterVetName.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to filter vet name: " + ex);
                    return;
                }
            }
            dgAppointments.ItemsSource = null;
            dgAppointments.ItemsSource = currentList;
            canViewVetAppointmentFilter.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/22/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Closes the filter page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnCloseFilters_Click(object sender, RoutedEventArgs e)
        {
            canViewVetAppointmentFilter.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 2/22/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// A double click trigger on the animal list data grid
        /// Sets the global variable _selectedAnimal to the select item
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DgAnimalList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgAnimalList.SelectedItem != null)
            {
                _selectedAnimal = (Animal)dgAnimalList.SelectedItem;
                txtAnimalName.Text = _selectedAnimal.AnimalName;
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver:
        /// 
        /// Event for when the appointment date has been changed
        /// Sets the earlier follow up date to one day after the 
        /// appointment date. Only runs when editing a record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DateAppointmentDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_editMode)
            {
                dateFollowUp.SelectedDate = null;
                txtFollowUpTime.Text = "";
                dateFollowUp.DisplayDateStart = dateAppointmentDate.SelectedDate.Value.AddDays(1);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 3/1/2020
        /// Approver: Ben Hanna, 3/6/2020
        /// Approver:
        /// 
        /// Button click event to remove a follow up
        /// date when editing a record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void BtnClearFollowUp_Click(object sender, RoutedEventArgs e)
        {
            dateFollowUp.SelectedDate = null;
            txtFollowUpTime.Text = "";
        }
    }
}
