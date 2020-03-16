using LogicLayer;
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
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-03-11
    ///     CHECKED BY: Zoey McDonald
    ///     Class for printing volunteer shifts to the screen
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public partial class PrintVolunteerShifts : Page
    {
        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-11
        ///     CHECKED BY: Zoey McDonald
        ///     Main constructor for the class
        /// </summary>
        public PrintVolunteerShifts()
        {
            InitializeComponent();

            VolunteerShiftManager manager = new VolunteerShiftManager();

            try
            {
                dgShiftList.ItemsSource = manager.ReturnAllVolunteerShifts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error loading the shift: " + ex.Message);
            }
        }
    }
}
