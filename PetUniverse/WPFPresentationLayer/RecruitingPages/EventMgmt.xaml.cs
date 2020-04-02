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

namespace WPFPresentationLayer.RecruitingPages
{
    /// <summary>
    /// 
    /// Name: Steve Coonrod
    /// Date: 2\08\2020
    /// Checked By:
    /// 
    /// This is the page which contains all Event Management operations.
    /// It is set up as a tab control which hold seperate frames each containing a datagrid
    /// which is set to retrieve a list of events with a specific status
    /// 
    /// There is a public event attribute to track which event is currently selected
    ///     Each page sets this value in its datagrid's selection_changed event handler
    ///     so that it can be referred to by the buttons on this page
    ///
    /// Updated By:     
    /// Date Updated:   
    /// 
    /// </summary>
    public partial class EventMgmt : Page
    {

        private IPUEventManager _eventManager = null;//For using event manager methods
        private PetUniverseUser _user = null;//for tracking the current user
        public PUEvent _selectedEvent;//To track the currently selected Event on the datagrids


        /// <summary>
        /// Name: Steve Coonrod
        /// Date: 2\08\2020
        /// Checked By:
        /// 
        /// This is the no-argument constructor.
        /// It is never referenced, but is necessary for the PUHome window to initialize.
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        public EventMgmt()
        {
            InitializeComponent();
            _eventManager = new PUEventManager();
        }

        /// <summary>
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// This is the constructor for this page which takes in a user object.
        /// This is necessary for basing functionality on the users role.
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        /// <param name="user"></param>
        public EventMgmt(PetUniverseUser user)
        {
            InitializeComponent();
            _eventManager = new PUEventManager();
            _user = user;
        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// A helper method to disable and enable the buttons 
        /// which depend on an Event being selected in one of the the datagrids
        /// 
        /// Public so the method can be used by each page connected to the EventMgmt Page
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        public void ToggleEventButtons()
        {
            if (_selectedEvent == null)
            {
                btnDeleteEvent.IsEnabled = false;
                btnViewEventDetails.IsEnabled = false;
                btnEditEvent.IsEnabled = false;
                btnReviewEvent.IsEnabled = false;
            }
            else
            {
                //Viewing the event details will always be enabled
                btnViewEventDetails.IsEnabled = true;

                bool isDCAdmin = false;
                if (_user.PURoles.Contains("Admin") || _user.PURoles.Contains("Donation Coordinator"))
                {
                    isDCAdmin = true;
                }

                if (isDCAdmin)
                {
                    if (_selectedEvent.Status == "PendingApproval")
                    {
                        btnDeleteEvent.IsEnabled = true;
                        btnEditEvent.IsEnabled = true;
                        btnReviewEvent.IsEnabled = true;
                    }
                    else if (_selectedEvent.Status == "Completed")
                    {
                        btnDeleteEvent.IsEnabled = true;
                        btnEditEvent.IsEnabled = false;
                        btnReviewEvent.IsEnabled = false;
                    }
                    else
                    {
                        btnDeleteEvent.IsEnabled = true;
                        btnEditEvent.IsEnabled = true;
                        btnReviewEvent.IsEnabled = false;
                    }
                }
                else
                {
                    //Non-DCAdmin members will only see active and approved Events...
                    if (_selectedEvent.CreatedByID == _user.PUUserID)
                    {
                        btnEditEvent.IsEnabled = true;
                    }
                    else
                    {
                        btnEditEvent.IsEnabled = false;
                    }
                }
            }//End outer-Else loop 
        }//End ToggleEventButtons()




        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// The handler for loading this page.
        /// At this point it will populate the events datagrid
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_user != null)
            {
                SetUpPageBasedOnUserRole();
            }
        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// A helper method to set up the page based on the user's roles
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        private void SetUpPageBasedOnUserRole()
        {
            //Searches through the user's role list, 
            //if it finds Admin or DC it breaks and sets the page up for full priviledges
            //otherwise it sets up basic member functionality
            foreach (string role in _user.PURoles)
            {
                if (role == "Admin" || role == "Donation Coordinator")
                {
                    frAllEvents.Content = new ListAllEvents(_eventManager, this);
                    frPendingEvents.Content = new ListPendingEvents(_eventManager, this);
                    frApprovedEvents.Content = new ListApprovedEvents(_eventManager, this);
                    tabAllEvents.IsSelected = true;
                    ToggleEventButtons();
                    break;
                }
                else
                {
                    DefaultUserSetUp();
                    ToggleEventButtons();
                }
            }
            if (_user.PURoles.Count == 0)
            {
                DefaultUserSetUp();
            }
        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// A helper method to set up the basic member functionality
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        private void DefaultUserSetUp()
        {
            frApprovedEvents.Content = new ListApprovedEvents(_eventManager, this);
            tabApprovedEvents.IsSelected = true;
            tabAllEvents.Visibility = Visibility.Hidden;
            tabPendingEvents.Visibility = Visibility.Hidden;
            btnDeleteEvent.Visibility = Visibility.Hidden;
            btnReviewEvent.Visibility = Visibility.Hidden;

            btnEditEvent.IsEnabled = false;
            btnViewEventDetails.IsEnabled = false;
        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// The click event handler for Creating an Event (UC-606 & UC-633)
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateEvent_Click(object sender, RoutedEventArgs e)
        {
            frEventApprovalForm.Visibility = Visibility.Hidden;
            frCreateEditEvent.Visibility = Visibility.Visible;
            frCreateEditEvent.Content = new CreateEventForm(_eventManager, _user, this);
            grdCreateEditEvent.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// The click event handler for Editing an Event (UC-607)
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditEvent_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEvent != null)
            {
                frEventApprovalForm.Visibility = Visibility.Hidden;
                frCreateEditEvent.Visibility = Visibility.Visible;
                frCreateEditEvent.Content = new CreateEventForm(_eventManager, _user, this, _selectedEvent);
                grdCreateEditEvent.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// The click event handler for Deleting an Event (UC-608) ADMIN/DC ONLY
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteEvent_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEvent != null)
            {
                frmDeleteEvent deleteEventWindow = new frmDeleteEvent(_eventManager, _selectedEvent);
                deleteEventWindow.ShowDialog();
                if (deleteEventWindow.DialogResult == true)
                {
                    frAllEvents.Content = new ListAllEvents(_eventManager, this);
                    frPendingEvents.Content = new ListPendingEvents(_eventManager, this);
                    frApprovedEvents.Content = new ListApprovedEvents(_eventManager, this);
                }
            }
        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// The click event handler for Viewing an Event's details (partially UC-619)
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewEventDetails_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEvent != null)
            {
                frCreateEditEvent.Visibility = Visibility.Hidden;
                frEventApprovalForm.Visibility = Visibility.Visible;
                frEventApprovalForm.Content = new EventApprovalForm(_eventManager, _user, _selectedEvent, this);
                tabEventApprovalForm.IsSelected = true;
            }
        }

        /// <summary>
        /// 
        /// Name: Steve Coonrod
        /// Date: 3\08\2020
        /// Checked By:
        /// 
        /// The click event handler for Reviewing an Event (UC-619)
        /// 
        /// Updated By:     
        /// Date Updated: 
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReviewEvent_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedEvent != null)
            {
                frCreateEditEvent.Visibility = Visibility.Hidden;
                frEventApprovalForm.Visibility = Visibility.Visible;
                frEventApprovalForm.Content = new EventApprovalForm(_eventManager, _user, _selectedEvent, this, true);
                tabEventApprovalForm.IsSelected = true;
            }
        }
    }
}
