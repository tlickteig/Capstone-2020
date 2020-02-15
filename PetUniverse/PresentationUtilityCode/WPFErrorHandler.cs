using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PresentationUtilityCode
{
    /// <summary>
    /// CREATOR: Steven Cardona
    /// DATE: 02/11/2020
    /// APPROVER: Zach Behrensmeyer
    /// 
    /// Class to handle error messaging that are 
    /// coming directly from the WPF Presentaion Layer
    /// </summary>
    public static class WPFErrorHandler
    {
        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/11/2020
        /// APPROVER: Zach Behrensmeyer
        /// 
        /// Method of general Error handling.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        ///     UPDATE: N/A
        /// APPROVER: N/A
        /// </remarks>
        /// <param name="message"></param>
        /// <param name="typeOfError"></param>
        public static void ErrorMessage(this string message, string typeOfError = null)
        {
            string caption = null;
            if (!string.IsNullOrEmpty(typeOfError))
            {
                caption = typeOfError + " Error";
            }
            else
            {
                caption = "Error";
            }
            MessageBox.Show(message, caption, MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        public static void SuccessMessage(this string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButton.OK);
        }
    }
}
