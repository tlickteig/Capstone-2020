using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationUtilityCode
{
    /// <summary>
    /// Creator: Steven  Cardona
    /// Created: 02/13/2020
    /// Approver: Zach Behrensmeyer
    /// 
    /// Class to handle error message passed up 
    /// from Logic Layer
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// </remarks>
    public static class LogicLayerErrorHandler
    {
        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/13/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Method to handle Data loading errors that are thrown from Logic layer
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="exMessage">Exception Message</param>
        /// <param name="exInnerMessage">Exception's inner message</param>
        public static void DataLoadErrorMessage(this string exMessage, string exInnerMessage = null)
        {
            string message = null;
            if (!string.IsNullOrEmpty(exInnerMessage))
            {
                message = exMessage + "\n\n" + exInnerMessage;
            }
            else
            {
                message = exMessage;
            }
            MessageBox.Show(message, "Data Loading Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Creator: Steven  Cardona
        /// Created: 02/13/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Method to handle Data loading errors that are thrown from Logic layer
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="exMessage">Exception Message</param>
        /// <param name="exInnerMessage">Exception's inner message</param>
        public static void LoginErrorMessage(this string exMessage, string exInnerMessage = null)
        {
            string message = null;
            if (!string.IsNullOrEmpty(exInnerMessage))
            {
                message = exMessage + "\n\n" + exInnerMessage;
            }
            else
            {
                message = exMessage;
            }
            MessageBox.Show(message, "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Creator: Steven  Cardona
        /// Created: 02/15/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Method to handle User Creation errors that are thrown from Logic layer
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="exMessage">Exception Message</param>
        /// <param name="exInnerMessage">Exception's inner message</param>
        public static void UserCreationErrorMessage(this string exMessage, string exInnerMessage = null)
        {
            string message = null;
            if (!string.IsNullOrEmpty(exInnerMessage))
            {
                message = exInnerMessage + "\n\n" + exInnerMessage;
            }
            else
            {
                message = exMessage;
            }
            MessageBox.Show(message, "Create User Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        public static void ActivateDeactivateErrorMessage(this string exMessage, string exInnerMessage = null)
        {
            string message = null;
            if (!string.IsNullOrEmpty(exInnerMessage))
            {
                message = exInnerMessage + "\n\n" + exInnerMessage;
            }
            else
            {
                message = exMessage;
            }
            MessageBox.Show(message, "Update Error: Activate/Deactivate", MessageBoxButton.OK, MessageBoxImage.Error);
        } 
    }
}
