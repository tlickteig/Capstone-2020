using DataTransferObjects;
using LogicLayer;
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
using System.Windows.Shapes;
using PresentationUtilityCode;

namespace WPFPresentationLayer
{
    /// <summary>
    /// NAME: Zach Behrensmeyer
    /// DATE: 2/7/2020
    /// CHECKED BY: Steven Cardona
    /// 
    /// This class controls the MainWindow window
    /// 
    /// </summary>
    public partial class MainWindow : Window
    {
        private PetUniverseUser _user = null;
        private int _userID = 0;

        private IUserManager _userManager;

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/7/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This is a constructor for the main window class
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            _userManager = new UserManager();
            this.ShowDialog();
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/7/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method is used to login the user after they click the button
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
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            var userEmail = txtEmail.Text;
            var userPassword = pwdPassword.Password;

            if (!userEmail.IsValidEmail() || !userPassword.IsValidPassword())
            {
                //Display a message, always say user name or password bad 
                //so bad users aren't sure what is wrong
                WPFErrorHandler.ErrorMessage("Invalid Username or Password.", "Login");
                txtEmail.Text = "";
                pwdPassword.Password = "";
                txtEmail.Focus();
                return;
            }
            // try to login
            try
            {

                _user = _userManager.AuthenticateUser(userEmail, userPassword);
                string userRoles = "";
                for (int i = 0; i < _user.PURoles.Count; i++)
                {
                    userRoles += _user.PURoles[i];
                    if (i < _user.PURoles.Count - 1)
                    {
                        userRoles += ", ";
                    }
                }

                _userID = _user.PUUserID;

                this.Visibility = Visibility.Hidden;
                //Log successful login
                LogHelper.log.Info("Email: " + txtEmail.Text + " Successfully logged in.");
                var petUniverseHome = new PetUniverseHome(_user, userRoles);

            }
            catch (Exception ex)
            {
                //Log failed login
                LogHelper.log.Error("Someone failed to login using email: " + txtEmail.Text);
                LogicLayerErrorHandler.LoginErrorMessage(ex.Message, ex.InnerException.Message);
            }
        }
    }
}
