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
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/3/2020
    /// 
    /// A window class for displaying, creating, and updating
    /// animal activity records
    /// </summary>
    public partial class AnimalActivityRecords : Page
    {
        private IAnimalActivityManager _activityManager;
        private PetUniverseUser _user;
        private bool addMode = false;
        private Animal selectedAnimal;

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Default constructor that requires a user object
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalActivityRecords(PetUniverseUser user)
        {
            InitializeComponent();
            _activityManager = new AnimalActivityManager();
            _user = user;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Opens the selected activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            if (dgActivities.SelectedItem == null)
            {
                return;
            }
            cmbActivityType2.ItemsSource = cmbActivityType.ItemsSource;
            canViewActivityRecord.Visibility = Visibility.Visible;
            PopulateFields((AnimalActivity)dgActivities.SelectedItem);
            canView.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Opens the window for creating a new activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            EnableAddMode();
            canViewActivityRecord.Visibility = Visibility.Visible;
            canView.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Prepares the form for adding a new record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableAddMode()
        {
            addMode = true;
            cmbActivityType2.ItemsSource = cmbActivityType.ItemsSource;
            cmbAmPm.Visibility = Visibility.Visible;
            cmbActivityType2.IsEnabled = true;
            dateActivityDate.IsEnabled = true;
            txtTime.IsEnabled = true;
            txtDescription.IsEnabled = true;
            btnSaveEdit.Content = "Save";
            dateActivityDate.DisplayDateStart = DateTime.Now;
            lblAnimal.Visibility = Visibility.Visible;
            dgAnimalList.Visibility = Visibility.Visible;

            try
            {
                dgAnimalList.ItemsSource = new AnimalManager().RetrieveAnimalsByActive();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Takes form out of record adding state
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableAddMode()
        {
            addMode = false;
            cmbAmPm.Visibility = Visibility.Hidden;
            cmbActivityType2.ItemsSource = null;
            dgAnimalList.ItemsSource = null;
            cmbActivityType2.IsEnabled = false;
            dateActivityDate.IsEnabled = false;
            txtTime.IsEnabled = false;
            txtDescription.IsEnabled = false;
            btnSaveEdit.Content = "Edit";
            selectedAnimal = null;
            lblAnimal.Visibility = Visibility.Hidden;
            dgAnimalList.Visibility = Visibility.Hidden;
            ClearFields();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter 4/7/2020
        /// 
        /// Prepares form for editing
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void EnableEditMode()
        {
            cmbActivityType2.ItemsSource = cmbActivityType.ItemsSource;
            cmbAmPm.Visibility = Visibility.Visible;
            cmbActivityType2.IsEnabled = true;
            dateActivityDate.IsEnabled = true;
            txtTime.IsEnabled = true;
            txtDescription.IsEnabled = true;
            btnSaveEdit.Content = "Save";
            dateActivityDate.DisplayDateStart = DateTime.Now;
            lblAnimal.Visibility = Visibility.Visible;
            dgAnimalList.Visibility = Visibility.Visible;
            selectedAnimal = new Animal()
            {
                AnimalID = ((AnimalActivity)dgActivities.SelectedItem).AnimalID
            };
            if (txtTime.Text.Contains(" AM"))
            {
                txtTime.Text = txtTime.Text.Replace(" AM", "");
                cmbAmPm.SelectedIndex = 0;
            }
            else if (txtTime.Text.Contains(" PM"))
            {
                txtTime.Text = txtTime.Text.Replace(" PM", "");
                cmbAmPm.SelectedIndex = 1;
            }

            try
            {
                dgAnimalList.ItemsSource = new AnimalManager().RetrieveAnimalsByActive();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/6/2020
        /// Approver: Chuck Baxter 4/7/2020
        /// 
        /// Helper method to disable edit mode
        /// Only calls DisableAddMode() as
        /// they work exactly the same
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void DisableEditMode()
        {
            DisableAddMode();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Removes unncessary data grid colums when it is
        /// populated with data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void dgActivities_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgActivities.Columns.Remove(dgActivities.Columns[0]);
            dgActivities.Columns.Remove(dgActivities.Columns[0]);
            dgActivities.Columns.Remove(dgActivities.Columns[0]);
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Populates the data grid when it is loaded
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void dgActivities_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshActivitiesList();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Refreshes the list of activity records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void RefreshActivitiesList()
        {
            dgActivities.ItemsSource = null;
            try
            {
                dgActivities.ItemsSource = _activityManager
                    .RetrieveAnimalActivitiesByActivityType(
                    cmbActivityType.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Searches for activity records by a partial animal name.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="animalName">The animal name to search</param>
        private void SearchActivitiesListByAnimalName(string animalName)
        {
            dgActivities.ItemsSource = null;
            try
            {
                dgActivities.ItemsSource = _activityManager
                    .RetrieveAnimalActivitiesByPartialAnimalName(animalName,
                    cmbActivityType.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Clears the search field when it gets focus
        /// for the first time
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Equals("Search Animal Name"))
            {
                txtSearch.Text = "";
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Searches records for the entered animal name.
        /// This is for querys shorter than the three character
        /// requirement to trigger auto-searching
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if ((string)btnSearch.Content == "Search")
            {
                SearchActivitiesListByAnimalName(txtSearch.Text);
                btnSearch.Content = "Clear";
            }
            else
            {
                txtSearch.Text = "";
                btnSearch.Content = "Search";
            }

        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Populates the activity type combo box with all
        /// valid activity type options.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void cmbActivityType_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                cmbActivityType.ItemsSource = _activityManager
                    .RetrieveAllAnimalActivityTypes()
                    .Select(a => a.ActivityTypeId);
                cmbActivityType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Triggered when the activity type is changed
        /// Refreshes the datagrid for the corresponding activity type
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void cmbActivityType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtSearch.Text = "Search Animal Name";
            btnSearch.Content = "Search";
            RefreshActivitiesList();
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Begins to auto-search the activity records when
        /// the user has entered three or more characters into
        /// the seach field. Resets results when the field is empty
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.Length < 3 &&
                txtSearch.Text.Length > 0 ||
                txtSearch.Text == "Search Animal Name")
            {
                return;
            }
            if (txtSearch.Text.Length == 0)
            {
                RefreshActivitiesList();
            }
            else
            {
                SearchActivitiesListByAnimalName(txtSearch.Text);
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Closes the details canvas and sets the form
        /// to its original state
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            canViewActivityRecord.Visibility = Visibility.Hidden;
            if (addMode)
            {
                DisableAddMode();
            }
            else
            {
                ClearFields();
                DisableEditMode();
            }
            canView.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Helper method to populate form controls
        /// when a record is opened
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void PopulateFields(AnimalActivity activity)
        {
            txtActivityId.Text = activity.AnimalActivityId.ToString();
            txtAnimalName.Text = activity.AnimalName;
            cmbActivityType2.Text = activity.AnimalActivityTypeID;
            dateActivityDate.SelectedDate = activity.ActivityDateTime;
            txtTime.Text = activity.ActivityDateTime.ToShortTimeString();
            txtDescription.Text = activity.Description;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Sets form controls back to default values
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void ClearFields()
        {
            txtActivityId.Text = "";
            txtAnimalName.Text = "";
            cmbActivityType2.ItemsSource = null;
            dateActivityDate.SelectedDate = null;
            txtTime.Text = "";
            txtDescription.Text = "";
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Handles saving and edititing functions
        /// </summary>
        /// <remarks>
        /// Updater: Ethan Murphy
        /// Updated: 4/6/2020
        /// Update: Added edit functionality
        /// Approver: Chuck Baxter 4/7/2020
        /// </remarks>
        private void btnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (btnSaveEdit.Content.Equals("Edit"))
            {
                EnableEditMode();
                return;
            }
            if (selectedAnimal == null)
            {
                MessageBox.Show("You must select an animal first!");
                return;
            }
            if (cmbActivityType2.SelectedItem == null)
            {
                MessageBox.Show("You must select an activity type!");
                return;
            }
            if (dateActivityDate.SelectedDate == null)
            {
                MessageBox.Show("You must select the activity date");
                return;
            }
            if (txtTime.Text == "" ||
                !TimeSpan.TryParse(txtTime.Text, out TimeSpan t))
            {
                MessageBox.Show("Invalid time entered");
                return;
            }
            DateTime activityDate;
            if (!DateTime.TryParse(
                dateActivityDate.SelectedDate.Value.ToShortDateString()
                + " " + txtTime.Text + cmbAmPm.Text, out activityDate))
            {
                MessageBox.Show("Invalid date or time entered");
                return;
            }
            AnimalActivity animalActivity = new AnimalActivity()
            {
                AnimalID = selectedAnimal.AnimalID,
                AnimalActivityTypeID = cmbActivityType2.SelectedItem.ToString(),
                ActivityDateTime = activityDate,
                UserID = _user.PUUserID,
                Description = txtDescription.Text
            };

            if (addMode)
            {
                try
                {
                    if (_activityManager.AddAnimalActivityRecord(animalActivity))
                    {
                        MessageBox.Show("Record added!");
                        DisableAddMode();
                        canViewActivityRecord.Visibility = Visibility.Hidden;
                        canView.Visibility = Visibility.Visible;
                        RefreshActivitiesList();
                    }
                    else
                    {
                        throw new ApplicationException();
                    }
                }
                catch (Exception ex)
                {
                    string message = ex == null ? "Failed to add record" :
                        ex.Message + " " + ex.InnerException.Message;
                    MessageBox.Show(message);
                }
            }
            else
            {
                // Perform update
                try
                {
                    if (_activityManager.EditExistingAnimalActivityRecord(
                        (AnimalActivity)dgActivities.SelectedItem, animalActivity))
                    {
                        MessageBox.Show("Record updated");
                        DisableEditMode();
                        canViewActivityRecord.Visibility = Visibility.Hidden;
                        canView.Visibility = Visibility.Visible;
                        RefreshActivitiesList();
                    }
                    else
                    {
                        throw new ApplicationException("Record not found");
                    }
                }
                catch (Exception ex)
                {
                    string message = ex == null ? "Failed to add record" :
                        ex.Message + " " + ex.InnerException.Message;
                    MessageBox.Show(message);
                }
            }
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Sets the selected animal when creating
        /// an activity record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void dgAnimalList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dgAnimalList.SelectedItem == null)
            {
                return;
            }
            selectedAnimal = (Animal)dgAnimalList.SelectedItem;
            txtAnimalName.Text = selectedAnimal.AnimalName;
        }

        /// <summary>
        /// Creator: Ethan Murphy
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/3/2020
        /// 
        /// Removes unncessary columns in animal data grid
        /// when grid is populated with data
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void dgAnimalList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[0]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
            dgAnimalList.Columns.Remove(dgAnimalList.Columns[4]);
        }
    }
}
