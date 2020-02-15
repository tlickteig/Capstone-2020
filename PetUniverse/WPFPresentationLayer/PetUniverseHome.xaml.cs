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
using PresentationUtilityCode;

namespace WPFPresentationLayer
{
    /// <summary>
    /// NAME: Zach Behrensmeyer
    /// DATE: 2/5/2020
    /// CHECKED BY: Steven Cardona
    /// 
    /// This class has interaction logic for the PetUniverseHome window
    /// 
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATED NA
    /// CHANGE: NA
    /// 
    /// </remarks>
    /// </summary>
    public partial class PetUniverseHome : Window
    {
        private string desiredScreen;
        private string userRoles;
        private PetUniverseUser _user = null;
        private IUserManager _userManager;
        private ILogManager _logManager = new LogManager();

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/7/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This constructor should only be used for testing. We do not want 
        /// to create this without someone properly being logged in.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// </summary>
        public PetUniverseHome()
        {
            InitializeComponent();
            this.ShowDialog();
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/7/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This constructor is passed a userid and roles and will control what the user can see and do
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Steven Cardona
        /// UPDATED 02/14/2020
        /// CHANGE: Initialized new UserManger to private _userManager variable
        /// CHECKED BY:
        /// </remarks>
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="userRoles"></param>
        public PetUniverseHome(PetUniverseUser user, string userRoles)
        {
            this._user = user;
            this.userRoles = userRoles;
            InitializeComponent();
            _userManager = new UserManager();
            this.ShowDialog();
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/7/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method is used for showing the inventory content
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInventory_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Inventory";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/7/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method is used for showing the animnal management content
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAM_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Animal Management";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/7/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method is used for showing the point of sale content
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPoS_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Point of Sale";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/7/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method is used for showing the volunteer hub content
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolHub_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Volunteer Hub";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/7/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method is used for showing the system admin content
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSysAdmin_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "System Admin";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/7/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method is used for logging the user out
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LogHelper.log.Info("User : " + _user.FirstName + " " + _user.LastName + " has logged out.");
            this.Visibility = Visibility.Hidden;
            var mainWindow = new MainWindow();
            this.Close();

        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/7/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This is a helper method to decide which canvas should be shown.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Steven Cardona
        /// UPDATED 02/15/2020
        /// CHANGE: Added canViewUsers.Visibility = Visibility.Visible; to SysAdmin Case
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="screenName"></param>
        private void switchScreen(string screenName)
        {
            switch (screenName)
            {
                case "Inventory":
                    canInventory.Visibility = Visibility.Visible;
                    canAM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Animal Management":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Visible;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Point of Sale":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Visible;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Volunteer Hub":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Visible;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "System Admin":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Visible;
                    canViewUsers.Visibility = Visibility.Visible;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Requests":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Visible;
                    canSysAd.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                default:
                    canInventory.Visibility = Visibility.Visible;
                    canAM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
            }
        }

        /// <summary>
        /// NAME : Zach Behrensmeyer
        /// DATE: 2/11/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This method is called when the window first loads
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblStatusBar.Content = _user.LastName + ", " + _user.FirstName;
        }

        /// <summary>
        /// NAME : Zach Behrensmeyer
        /// DATE: 2/11/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This method is called when the request button is clicked
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRequest_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Requests";
            switchScreen(desiredScreen);
        }


        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/14/2020
        /// APPROVER: Zach Behrensmeyer
        /// 
        /// Method of general Error handling.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        /// UPDATE: N/A
        /// APPROVER: N/A
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgUserList_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgUserList.Columns.RemoveAt(6);
            dgUserList.Columns.RemoveAt(5);
            dgUserList.Columns[0].Header = "ID";
            dgUserList.Columns[1].Header = "First Name";
            dgUserList.Columns[2].Header = "Last Name";
            dgUserList.Columns[3].Header = "Phone Number";
            dgUserList.Columns[4].Header = "Email";
            dgUserList.Columns[5].Header = "City";
            dgUserList.Columns[6].Header = "State";
            dgUserList.Columns[7].Header = "ZipCode";

            // this fill all availalbe space with available columns
            foreach (var column in this.dgUserList.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }

            dgUserList.Columns[6].Width = 40;

        }

        /// <summary>
        /// CODED BY: Steven Cardona
        /// DATE: 02/10/2020
        /// CHECKED BY: Zach Behrensmeyer
        /// Create a new user by clicking save
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            bool isCreated = false;

            PetUniverseUser newUser = new PetUniverseUser();

            // Validate First Name
            if (!txtFirstName.Text.IsValidFirstName())
            {
                "First Name cannot be blank".ErrorMessage("Validation");
                //WPFErrorHandler.ErrorMessage("First name cannot be blank", "Validation");
                txtFirstName.Text = "";
                txtFirstName.Focus();
                return;
            }
            else
            {
                newUser.FirstName = txtFirstName.Text;
            }

            // Validate Last Name
            if (!txtLastName.Text.IsValidLastName())
            {
                WPFErrorHandler.ErrorMessage("Last name cannot be blank", "Validation");
                txtLastName.Text = "";
                txtLastName.Focus();
                return;
            }
            else
            {
                newUser.LastName = txtLastName.Text;
            }

            // Validate Email 
            if (!txtEmail.Text.IsValidEmail())
            {
                WPFErrorHandler.ErrorMessage("Invalid email address", "Validation");
                txtEmail.Text = "";
                txtEmail.Focus();
                return;
            }
            else
            {
                newUser.Email = txtEmail.Text;
            }

            // Validate Phone Number
            try
            {
                if (!txtPhoneNumber.Text.IsValidPhoneNumber())
                {
                    WPFErrorHandler.ErrorMessage("Invalid Phone Number", "Validation");
                    txtPhoneNumber.Text = "";
                    txtPhoneNumber.Focus();
                    return;
                }
                else
                {
                    newUser.PhoneNumber = txtPhoneNumber.Text;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
                txtPhoneNumber.Text = "";
                txtPhoneNumber.Focus();
                return;
            }

            // Validate City
            if (!txtCity.Text.IsValidCity())
            {
                string message = string.IsNullOrEmpty(txtCity.Text) ? "City cannot be blank" : "City must be less than 20 characters long";
                WPFErrorHandler.ErrorMessage(message, "Validation");
                txtCity.Text = "";
                txtCity.Focus();
                return;
            }
            else
            {
                newUser.City = txtCity.Text;
            }

            // Validate State
            if (cmbState.SelectedItem == null || !cmbState.SelectedItem.ToString().IsValidState())
            {
                WPFErrorHandler.ErrorMessage("Please select a state", "Validation");
                cmbState.Focus();
                return;
            }
            else
            {
                newUser.State = cmbState.SelectedItem.ToString();
            }

            // Validate Zipcode
            try
            {
                if (!txtZipcode.Text.IsValidState())
                {
                    WPFErrorHandler.ErrorMessage("Invalid Zipcode", "Validation");
                    txtZipcode.Text = "";
                    txtZipcode.Focus();
                    return;
                }
                else
                {
                    newUser.ZipCode = txtZipcode.Text;
                }
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.Message, "Validation");
            }

            try
            {
                isCreated = _userManager.CreateNewUser(newUser);
                if (isCreated)
                {
                    WPFErrorHandler.SuccessMessage("Create new user was successful");
                }
                canNewUsers.Visibility = Visibility.Hidden;
                canViewUsers.Visibility = Visibility.Visible;
                RefreshDgUserList();
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.UserCreationErrorMessage(ex.Message, ex.InnerException.Message);
            }
        }


        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/015/2020
        /// APPROVER: Zach Behrensmeyer
        /// 
        /// Hides dgUserList and shows new canvas for creating users. Also adds enum values to cmbState items source
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED DATE:
        /// UPDATE:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateUser_Click(object sender, RoutedEventArgs e)
        {
            canViewUsers.Visibility = Visibility.Hidden;
            canNewUsers.Visibility = Visibility.Visible;

            foreach (var state in Enum.GetValues(typeof(States.StatesAb)))
            {
                cmbState.Items.Add(state);
            }
        }


        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/015/2020
        /// APPROVER: Zach Behrensmeyer
        /// 
        /// Hides canNewUsers and shows canViewUsers.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATED DATE:
        /// UPDATE:
        /// APPROVER:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            canNewUsers.Visibility = Visibility.Hidden;
            canViewUsers.Visibility = Visibility.Visible;
            RefreshDgUserList();
        }

        /// <summary>
        /// CREATOR: Steven Cardona
        /// CREATED: 02/14/2020
        /// APPROVER: Zach Behrensmeyer
        /// 
        /// When dgUserList is loaded. Adds items into dgUserList.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED: N/A
        /// UPDATE: N/A
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgUserList_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshDgUserList();
        }


        /// CREATOR: Zach Behrensmeyer
        /// CREATED: 02/15/2020
        /// APPROVER: Steven Cardona
        /// 
        /// Method that generates the columns for the log list.
        /// </summary>
        /// <remarks>
        /// UPDATER: N/A
        /// UPDATED: N/A
        /// UPDATE: N/A        
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgLogList_AutoGeneratedColumns_1(object sender, EventArgs e)
        {
            dgLogList.Columns.RemoveAt(6);
            dgLogList.Columns.RemoveAt(4);
            dgLogList.Columns.RemoveAt(2);
            dgLogList.Columns.RemoveAt(0);
            dgLogList.Columns[0].Header = "Log Date";
            dgLogList.Columns[1].Header = "Log Level";
            dgLogList.Columns[2].Header = "Log Message";

            foreach (var column in this.dgLogList.Columns)
            {
                column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        /// <summary>
        /// CREATOR: Zach Behrensmeyer
        /// CREATED: 02/15/2020
        /// APPROVER: Steven Cardona
        /// 
        /// When dgLogList is loaded. Adds items into dgLogList.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED: N/A
        /// UPDATE: N/A
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgLogList_Loaded(object sender, RoutedEventArgs e)
        {
            dgLogList.ItemsSource = _logManager.RetrieveLoginandOutLogs();
        }

        /// <summary>
        /// CREATOR: Steven Cardona
        /// CREATED: 02/14/2020
        /// APPROVER: Zach Behrensmeyer
        /// 
        /// Adds items into dgUserList.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED: N/A
        /// UPDATE: N/A
        /// </remarks>
        private void RefreshDgUserList()
        {
            try
            {
                dgUserList.ItemsSource = _userManager.RetrieveAllActivePetUniverseUsers();
            }
            catch (Exception ex)
            {
                LogicLayerErrorHandler.DataLoadErrorMessage(ex.Message, ex.InnerException.Message);
            }
        }
    }
}
