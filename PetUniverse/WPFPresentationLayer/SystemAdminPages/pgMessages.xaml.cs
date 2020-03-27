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

namespace WPFPresentationLayer.SystemAdminPages
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 3/16/2020
    /// Appover: Steven Cardona
    /// 
    /// This class controls pgMessages
    /// 
    /// </summary>
    public partial class pgMessages : Page
    {

        private IMessagesManager _messagesManager = new MessagesManager();
        private IUserManager _userManager = new UserManager();
        private PetUniverseUser _user;

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// This is a no arg constructor for the pgMessage Page
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        public pgMessages()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// This is a constructor for the pgMessage View to pass a user 
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// </summary>
        public pgMessages(PetUniverseUser user)
        {
            this._user = user;
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover:Steven Cardona
        /// 
        /// When btnCompose is clicked. Changes visible canvas
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCompose_Click(object sender, RoutedEventArgs e)
        {
            canViewMessages.Visibility = Visibility.Hidden;
            canSendMessage.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// When btnSend is clicked. It sends a message and goes back to view emails page
        /// </summary>
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 3/27/2020
        /// Update: Added Send to All logic
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            List<PetUniverseUser> users = new List<PetUniverseUser>();

            if (txtRecipient.Text == "")
            {
                WPFErrorHandler.ErrorMessage("Must have a recipient");
            }
            else if (txtSubject.Text == "" && txtMessage.Text == "")
            {
                WPFErrorHandler.ErrorMessage("Please enter subject and message");
            }
            else if (txtSubject.Text == "")
            {
                WPFErrorHandler.ErrorMessage("Please enter subject");
            }
            else if (txtMessage.Text == "")
            {
                WPFErrorHandler.ErrorMessage("Please enter message");
            }
            else
            {
                if (txtRecipient.Text == "All" || txtRecipient.Text == "all")
                {
                    users = _userManager.RetrieveAllActivePetUniverseUsers();

                    foreach (PetUniverseUser newuser in users)
                    {
                        try
                        {
                            _messagesManager.sendEmail(txtMessage.Text, txtSubject.Text, _user.PUUserID, newuser.PUUserID);
                        }
                        catch (Exception ex)
                        {
                            WPFErrorHandler.ErrorMessage(ex.InnerException.Message, ex.Message);
                        }
                    }
                    users = null;
                    canSendMessage.Visibility = Visibility.Hidden;
                    canViewMessages.Visibility = Visibility.Visible;
                    txtMessage.Text = "";
                    txtRecipient.Text = "";
                    txtSubject.Text = "";
                }
                else if (!txtRecipient.Text.Contains("@"))
                {

                    users = _userManager.GetDepartmentUsers(txtRecipient.Text);

                    foreach (PetUniverseUser newuser in users)
                    {
                        try
                        {
                            _messagesManager.sendEmail(txtMessage.Text, txtSubject.Text, _user.PUUserID, newuser.PUUserID);
                        }
                        catch (Exception ex)
                        {
                            WPFErrorHandler.ErrorMessage(ex.InnerException.Message, ex.Message);
                        }
                    }
                    users = null;
                    canSendMessage.Visibility = Visibility.Hidden;
                    canViewMessages.Visibility = Visibility.Visible;
                    txtMessage.Text = "";
                    txtRecipient.Text = "";
                    txtSubject.Text = "";
                }

                else
                {
                    sendEmail();
                    canSendMessage.Visibility = Visibility.Hidden;
                    canViewMessages.Visibility = Visibility.Visible;
                    txtMessage.Text = "";
                    txtRecipient.Text = "";
                    txtSubject.Text = "";
                }
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// Logic for smart search on emails and departments
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRecipient_KeyUp(object sender, KeyEventArgs e)
        {
            string query = (sender as TextBox)?.Text;
            List<string> departments = new List<string>();
            List<string> users = new List<string>();
            List<string> results = new List<string>();

            string value = txtRecipient.Text;

            if (query != null && query.Length == 0)
            {
                dgAutoComplete.Visibility = Visibility.Collapsed;
            }
            else
            {
                try
                {
                    departments = _messagesManager.RetrieveDepartmentsLikeInput(value);
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message);
                }
                try
                {
                    users = _messagesManager.GetUsersLikeInput(value);
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage(ex.Message);
                }

                if (txtRecipient.Text == "a" || txtRecipient.Text == "A" || txtRecipient.Text == "Al" || txtRecipient.Text == "al" || txtRecipient.Text == "All" || txtRecipient.Text == "all")
                {
                    results.Add("All");
                }

                if (departments.Count > 0)
                {
                    foreach (string dep in departments)
                    {
                        results.Add(dep);
                    }
                }

                if (users.Count > 0)
                {
                    foreach (string user in users)
                    {
                        results.Add(user);
                    }
                }

                if (users.Count == 0 && departments.Count == 0)
                {
                    dgAutoComplete.Visibility = Visibility.Collapsed;
                }

                if (results.Count > 0)
                {
                    dgAutoComplete.Visibility = Visibility.Visible;
                    dgAutoComplete.ItemsSource = results;
                }
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// Allows user to select search item from list
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAutoComplete_MouseUp(object sender, MouseButtonEventArgs e)
        {
            txtRecipient.Text = dgAutoComplete.SelectedItem.ToString();
            dgAutoComplete.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// Logic to hide list search when it loses focus
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgAutoComplete_LostFocus(object sender, RoutedEventArgs e)
        {
            dgAutoComplete.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// DataAccessor for get user by Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private int getUserIDByEmail(string recipient)
        {

            PetUniverseUser _recipient = new PetUniverseUser();
            try
            {
                _recipient = _userManager.getUserByEmail(recipient);
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.InnerException.Message, ex.Message);
            }
            return _recipient.PUUserID;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Appover: Steven Cardona
        /// 
        /// Logic to send message
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sendEmail()
        {
            int recipient = getUserIDByEmail(txtRecipient.Text);
            try
            {
                _messagesManager.sendEmail(txtMessage.Text, txtSubject.Text, _user.PUUserID, recipient);
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage(ex.InnerException.Message, ex.Message);
            }
        }
    }
}
