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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFPresentationLayer.VolunteerPages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class VolunteerSchedule : Page
    {
        IVolunteerShiftManager _manager = new VolunteerShiftManager();

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-06
        ///     CHECKED BY: Zoey McDonald        
        /// </summary>    
        public VolunteerSchedule()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-06
        ///     CHECKED BY: Zoey McDonald        
        /// </summary>                
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtVolunteerID.Text);
                List<VolunteerShift> shifts = _manager.ReturnAllVolunteerShiftsForAVolunteer(id);
                dteShiftList.ItemsSource = shifts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-31
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        private void BtnAddShift_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frmSignUpForShift window = new frmSignUpForShift(Convert.ToInt32(txtVolunteerID.Text));
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
