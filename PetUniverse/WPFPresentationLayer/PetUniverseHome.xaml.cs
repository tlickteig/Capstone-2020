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
        private PetUniverseUser _user;
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
            this.ShowDialog();
            _userManager = new UserManager();            

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
        /// UPDATED BY: Carl Davis
        /// UPDATED 02/21/2020
        /// CHANGE: Added facility maintenance switch case
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
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Animal Management":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Visible;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Facility Management":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Visible;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Point of Sale":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Visible;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Volunteer Hub":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Visible;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "System Admin":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Visible;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Requests":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Visible;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Adoptions":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Visible;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Donations":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Visible;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                case "Personnel":
                    canInventory.Visibility = Visibility.Hidden;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Visible;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
                default:
                    canInventory.Visibility = Visibility.Visible;
                    canAM.Visibility = Visibility.Hidden;
                    canFM.Visibility = Visibility.Hidden;
                    canPoS.Visibility = Visibility.Hidden;
                    canVolHub.Visibility = Visibility.Hidden;
                    canRequests.Visibility = Visibility.Hidden;
                    canSysAd.Visibility = Visibility.Hidden;
                    canAdoptions.Visibility = Visibility.Hidden;
                    canDonRec.Visibility = Visibility.Hidden;
                    canPersonnel.Visibility = Visibility.Hidden;
                    txtWelcome.Visibility = Visibility.Hidden;
                    break;
            }
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
        /// NAME : Zach Behrensmeyer
        /// DATE: 2/11/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This method is called when the window loads
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
            lblStatusBar.Content = "Welcome " + _user.LastName + ", " + _user.FirstName;
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/20/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// This is a method to show the adoptions canvas
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
        /// <param name="screenName"></param>
        private void BtnAdoptions_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Adoptions";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// NAME : Steven Coonrod
        /// DATE: 2/20/2020
        /// CHECKED BY: Zach Behrensmeyer
        /// 
        /// This method is called when the donations button is clicked
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDonRec_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Donations";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// NAME : Lane Sandburg
        /// DATE: 2/20/2020
        /// CHECKED BY: Zach Behrensmeyer
        /// 
        /// This method is called when the Personnel button is clicked
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPersonnelManagement_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Personnel";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// NAME : Carl Davis
        /// DATE: 2/21/2020
        /// CHECKED BY: Chuck Baxter
        /// 
        /// This method is called when the Facility Management button is clicked
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFm_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Facility Management";
            switchScreen(desiredScreen);
        }
    }
}
