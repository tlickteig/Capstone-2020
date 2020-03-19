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
using WPFPresentationLayer.PoSPages;
using WPFPresentationLayer.AMPages;
using WPFPresentationLayer.RecruitingPages;
using WPFPresentationLayer.FMPages;

namespace WPFPresentationLayer
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 2/5/2020
    /// Approver: Steven Cardona
    /// 
    /// This class has interaction logic for the PetUniverseHome window
    /// 
    /// </summary>
    public partial class PetUniverseHome : Window
    {
        private string desiredScreen;
        private string userRoles;
        private PetUniverseUser _user;
        private IUserManager _userManager;
        private ILogManager _logManager = new LogManager();

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This constructor should only be used for testing. We do not want 
        /// to create this without someone properly being logged in.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        public PetUniverseHome()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This constructor is passed a userid and roles and will control what the user can see and do
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: Steven Cardona
        /// Updated: 02/14/2020
        /// Update: Initialized new UserManger to private _userManager variable
        /// Approver: Zach Behrensmeyer
        /// 
        /// 
        /// </remarks>
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
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for showing the inventory content
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for showing the animnal management content
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: Ben Hanna
        /// Updated: 3/1/2020
        /// Update: Now calls a constructor so the user can be tracked.
        /// Approver: Chuck Baxter, 3/5/2020
        /// 
        /// Updater: Ben Hanna
        /// Updated: 3/19/2020
        /// Update Added constructor for the kennel records frame for passing the user.
        /// 
        /// </remarks>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAM_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Animal Management";
            switchScreen(desiredScreen);
            frameViewKennelRecords.Content = new KennelControls(_user);
            frameViewHandlingNotes.Content = new HandlingControls(_user);
            frameViewVetAppointments.Content = new VetAppointmentControls(_user);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for showing the point of sale content
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for showing the volunteer hub content
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for showing the system admin content
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method is used for logging the user out
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
        /// Creator: Zach Behrensmeyer
        /// Created: 2/7/2020
        /// Approver: Steven Cardona
        /// 
        /// This is a helper method to decide which canvas should be shown.
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: Steven Cardona
        /// Updated: 02/15/2020
        /// Update: Added canViewUsers.Visibility = Visibility.Visible; to SysAdmin Case
        /// 
        /// Updater: Carl Davis
        /// Updated: 02/21/2020
        /// Update: Added facility maintenance switch case
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
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is called when the request button is clicked
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRequest_Click(object sender, RoutedEventArgs e)
        {
            frNewRequestList.Content = new RecruitingPages.ListNewRequests(_user);
            frActiveRequestList.Content = new RecruitingPages.ListActiveRequests(_user);
            frCompleteRequestList.Content = new RecruitingPages.ListCompleteRequests(_user);

            desiredScreen = "Requests";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is called when the window loads
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblStatusBar.Content = "Welcome " + _user.LastName + ", " + _user.FirstName;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/20/2020
        /// Approver: Michael Thompson
        /// 
        /// This is a method to show the adoptions canvas
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
        /// Creator: Steven Coonrod
        /// Created: 2/20/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method is called when the donations button is clicked
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDonRec_Click(object sender, RoutedEventArgs e)
        {
            //Added to allow the user object to be passed to the EventMgmt page
            fEventMgmt.Content = new EventMgmt(_user);

            desiredScreen = "Donations";
            switchScreen(desiredScreen);
        }

        /// <summary>
        /// Creator: Lane Sandburg
        /// Creaed: 2/20/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method is called when the Personnel button is clicked
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
        /// Creator: Robert Holmes
        /// Created: 2020/02/21
        /// Approver: Cash Carlson 
        /// 
        /// Loads check out page into the frame.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabCheckOut_Loaded(object sender, RoutedEventArgs e)
        {
            if (frmCheckOut == null)
            {
                frmCheckOut = new Frame();
                tabCheckOut.Content = frmCheckOut;
            }
            if (frmCheckOut.Content == null)
            {
                frmCheckOut.Navigate(new pgCheckOut());
            }
        }

        /// <summary>
        /// Creator: Carl Davis
        /// Created: 2/21/2020
        /// Approver: Chuck Baxter
        /// 
        /// This method is called when the Facility Management button is clicked
        /// </summary>
        /// <remarks>
        /// Updater: Carl Davis
        /// Updated: 3/4/2020
        /// Update: Passed the logged in user through the constructor
        /// Approver: Ethan Murphy 3/6/2020
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFm_Click(object sender, RoutedEventArgs e)
        {
            desiredScreen = "Facility Management";
            switchScreen(desiredScreen);
            frameViewFacilityInspection.Content = new FacilityInspectionControls(_user);
            frameViewFacilityMaintenance.Content = new FacilityMaintenanceControls(_user);
        }


        /// <summary>
        /// Creator : Kaleb Bachert
        /// Created: 2/20/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// This method is called when the PersonnelRequests Tab is loaded
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void tabViewPersonnelRequests_Loaded(object sender, RoutedEventArgs e)
        {
            frmViewPersonnelRequests.Content = new PersonnelPages.ViewPersonnelRequests(_user);
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/10
        /// Approver: 
        /// 
        /// Method to load the promotions page into the frame.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPromotions_Loaded(object sender, RoutedEventArgs e)
        {
            if (frmPromotions == null)
            {
                frmPromotions = new Frame();
                tabPromotions.Content = frmPromotions;
            }
            if (frmPromotions.Content == null)
            {
                frmPromotions.Navigate(new pgPromotion(frmPromotions));
            }
        }
    }
}
