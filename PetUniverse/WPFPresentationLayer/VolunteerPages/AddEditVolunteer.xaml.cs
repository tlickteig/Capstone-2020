using DataTransferObjects;
using LogicLayerInterfaces;
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

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
	/// Creator: Josh J
	/// Created: 2020/02/28
	/// Approver
	///
	/// Page for adding and editing volunteer records
	/// </summary>
    public partial class AddEditVolunteer : Page
    {
        private IVolunteerManager _volunteerManager = null;
        private bool _addMode = false;

        public AddEditVolunteer()
        {
            InitializeComponent();
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: 
        /// This is the constructor which accepts an IVolunteerManager object, this should open the window in add mode
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        public AddEditVolunteer(IVolunteerManager volunteerManager)
        {
            InitializeComponent();
            _volunteerManager = volunteerManager;
            _addMode = true;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: 
        /// Some simple logic that changes input permissions based on whether the window was opened in add/edit mode
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        private void ViewVolunteer_Loaded(object sender, RoutedEventArgs e)
        {
            if (_addMode == false)
            {
                // edit code here
            }
            else
            {
                SetEditMode();
                chkActive.IsChecked = true;
                chkActive.IsEnabled = false;
                lstUnassignedSkills.IsEnabled = false;
                lstAssignedSkills.IsEnabled = false;
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: 
        /// This method makes the Volunteer Record fields editable
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        private void SetEditMode()
        {
            txtFirstName.IsReadOnly = false;
            txtLastName.IsReadOnly = false;
            txtEmailAddress.IsReadOnly = false;
            txtPhoneNumber.IsReadOnly = false;
            txtNotes.IsReadOnly = false;
            chkActive.IsEnabled = true;
            lstUnassignedSkills.IsEnabled = true;
            lstAssignedSkills.IsEnabled = true;
            btnEdit.Visibility = Visibility.Hidden;
            btnSave.Visibility = Visibility.Visible;
            txtFirstName.Focus();
            populateSkills();
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: 
        /// This method populates the lstUnassignedSKills with the skills that a volunteer could have
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        private void populateSkills()
        {
            try
            {
                var skills = _volunteerManager.GetAllSkills();
                lstUnassignedSkills.ItemsSource = skills;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.InnerException.Message);
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: 
        /// This validates the data entered into the Volunteer Record fields and passes the values to be added to the database upon pressing
        /// the save button
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Josh J
        /// UPDATE DATE: 2020/02/28
        /// WHAT WAS CHANGED: Changed how the save button interacts with the Pages.
        /// </remarks>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                MessageBox.Show("You must enter a first name.");
                txtFirstName.Focus();
                return;
            }
            if (txtLastName.Text == "")
            {
                MessageBox.Show("You must enter a last name.");
                txtLastName.Focus();
                return;
            }
            if (txtPhoneNumber.Text.ToString().Length > 12)
            {
                MessageBox.Show("You must enter a valid phone number.");
                txtPhoneNumber.Focus();
                return;
            }
            if (!(txtEmailAddress.Text.ToString().Length > 6
                  && txtEmailAddress.Text.ToString().Contains("@")
                  && txtEmailAddress.Text.ToString().Contains(".")))
            {
                MessageBox.Show("You must enter a valid email address.");
                txtEmailAddress.Focus();
                return;
            }
            if ((txtNotes.Text.Length >= 2000))
            {
                MessageBox.Show("Character limit reached for field: Notes - Try again");
                txtNotes.Focus();
                return;
            }

            Volunteer newVolunteer = new Volunteer()
            {
                FirstName = txtFirstName.Text.ToString(),
                LastName = txtLastName.Text.ToString(),
                PhoneNumber = txtPhoneNumber.Text.ToString(),
                Email = txtEmailAddress.Text.ToString(),
                OtherNotes = txtNotes.Text.ToString(),
                Active = (bool)chkActive.IsChecked
            };

            if (_addMode)
            {
                try
                {
                    if (_volunteerManager.AddVolunteer(newVolunteer))
                    {
                        this.NavigationService?.Navigate(new ViewVolunteers());
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
                // edit code here
            }
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: 
        /// This method closes the AddEditVolunteerRecord window without passing any values upon pressing the cancel button
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Josh Jackson
        /// UPDATE DATE: 2020/02/28
        /// WHAT WAS CHANGED: Changed the cancel implementation to work with the pages
        /// </remarks>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string warning = "You have unsaved changes that will be lost";
                if (MessageBox.Show("Are you sure?", warning,
                    MessageBoxButton.YesNo, MessageBoxImage.Warning)
                    == MessageBoxResult.No)
                {
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtEmailAddress.Text = "";
                    txtPhoneNumber.Text = "";
                    txtNotes.Text = "";
                    return;
                }
                this.NavigationService?.Navigate(new ViewVolunteers());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n"
                    + ex.InnerException.Message);
            }
        }
    }
}
