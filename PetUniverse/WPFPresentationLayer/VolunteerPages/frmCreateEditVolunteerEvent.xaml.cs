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
    /// Interaction logic for frmCreateEditVolunteerEvent.xaml
    /// </summary>
    /// <summary>
    /// NAME: Zoey McDonald
    /// DATE: 2/7/2020
    /// CHECKED BY: Ethan Holmes
    /// 
    /// Interaction logic for frmCreateEditVolunteerEvent.xaml
    /// 
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATED DATE: N/A
    /// WHAT WAS CHANGED: N/A
    /// </remarks>
    public partial class frmCreateEditVolunteerEvent : Page
    {
        private IVolunteerEventManager _volunteerEventManager = new VolunteerEventManager();
        //private VolunteerEvent _volunteerEvent = new VolunteerEvent();

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This method is to create the window. 
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        public frmCreateEditVolunteerEvent()
        {
            InitializeComponent();
            _volunteerEventManager = new VolunteerEventManager();

        }

        /// <summary>
        /// NAME: Zoey McDonald
        /// DATE: 2/7/2020
        /// CHECKED BY: Ethan Holmes
        /// 
        /// This is a method for submiting a volunteer event when the 'Submit' button has been clicked.
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// WHAT WAS CHANGED: N/A
        /// </remarks>
        private void btnSubmitVolunteerEvent_Click(object sender, RoutedEventArgs e)
        {

            string volunteerName = txtVolunteerEventTitle.Text.ToString();
            string eventDescription = txtVolunteerEventDescription.Text.ToString();
            bool volActive = (bool)chkVolunteerEventActive.IsChecked;

            VolunteerEventVM insertEvent = new VolunteerEventVM()
            {
                //VolunteerEventID = 1,
                EventName = volunteerName,
                EventDescription = eventDescription,
                Active = volActive
            };

            int create = _volunteerEventManager.InsertVolunteerEvent(insertEvent);
        }
    }
}
