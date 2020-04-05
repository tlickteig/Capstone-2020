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
    /// Creator: Ben Hanna
    /// Created: 4/2/2020
    /// Approver: Carl Davis 4/4/2020
    /// 
    /// Interaction logic for AnimalKennelCleaningControls.xaml
    /// </summary>
    public partial class AnimalKennelCleaningControls : Page
    {
        private IAnimalKennelCleaningManager _cleaningManager;

        private PetUniverseUser _user;

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// Initial constructor
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalKennelCleaningControls()
        {
            InitializeComponent();
            _cleaningManager = new AnimalKennelCleaningManager();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// Second constructor; Takes the currently logged in user to auto-populate the UserID field
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="user"></param>
        public AnimalKennelCleaningControls(PetUniverseUser user)
        {
            InitializeComponent();
            _cleaningManager = new AnimalKennelCleaningManager();
            _user = user;
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// Reveals the details canvas for adding a new record
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddKennelCleaning_Click(object sender, RoutedEventArgs e)
        {
            canAddKennelCleaningRecord.Visibility = Visibility.Visible;
            txtNotes.Text = "";
            txtUserID.Text = _user.PUUserID.ToString();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// The button that triggers the process for saving record data.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubmitCleaningRecord_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserID.Text) || !int.TryParse(txtUserID.Text, out int num1))
            {
                MessageBox.Show("Please enter a valid user id");
                return;
            }
            if (string.IsNullOrEmpty(txtKennelID.Text) || !int.TryParse(txtKennelID.Text, out int num2))
            {
                MessageBox.Show("Please enter a valid kennel id");
                return;
            }
            if (string.IsNullOrEmpty(cndCleaningDate.SelectedDate.ToString()))
            {
                MessageBox.Show("Please select the cleaning date");
                return;
            }
            if (txtNotes.Text.Length > 250)
            {
                MessageBox.Show("Notes field is too long. Please enter again.");
                return;
            }

            try
            {
                AnimalKennelCleaningRecord cleaningRecord = new AnimalKennelCleaningRecord
                {
                    UserID = num1,
                    AnimalKennelID = num2,
                    Date = (DateTime)cndCleaningDate.SelectedDate,
                    Notes = txtNotes.Text
                };
                if (_cleaningManager.AddKennelCleaningRecord(cleaningRecord))
                {
                    WPFErrorHandler.SuccessMessage("Cleaning Record successfully added.");
                    CloseCleaningCanvas();
                }
                else
                {
                    MessageBox.Show("Cleaning record was not added.");
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage(ex.Message, "Save");
            }
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// Approver:
        /// 
        /// Button for hiding the canvas.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            CloseCleaningCanvas();
        }

        /// <summary>
        /// Creator: Ben Hanna
        /// Created: 4/2/2020
        /// Approver: Carl Davis 4/4/2020
        /// 
        /// Extracted method for resetting each field and hiding the canvas
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void CloseCleaningCanvas()
        {
            txtUserID.Text = "";
            txtKennelID.Text = "";
            txtNotes.Text = "";
            cndCleaningDate.SelectedDate = null;

            canAddKennelCleaningRecord.Visibility = Visibility.Hidden;
        }
    }
}
