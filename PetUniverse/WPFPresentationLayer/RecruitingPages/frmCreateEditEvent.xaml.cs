using DataTransferObjects;
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
using System.Windows.Shapes;

namespace WPFPresentationLayer.RecruitingPages
{
    /// <summary>
    /// Created By: Steve Coonrod, Matt Deaton
    /// Date: 2/10/2020
    /// Checked By:
    /// 
    /// Interaction logic for frmCreateEditEvent.xaml
    /// This holds the logic for the form frmCreateEditEvent
    /// This form is the presentation layer implementation for UC-606, UC-633, and UC-608
    /// 
    /// Updated By:
    /// Updated On:
    /// 
    /// </summary>
    public partial class frmCreateEditEvent : Window
    {
        private PetUniverseUser _user = null;//For implementing based on the User's Role
        private IPUEventManager _eventManager = null;//For accessing Event Manager operations
        private PUEvent _event = null;//For implementing Edit vs Create Event
        private bool _editMode = false;//For tracking the mode of implementation
        private enum statusOptions
        {
            PendingApproval,
            Approved,
            Unapproved,
            Active,
            Completed,
            Upcoming
        }

        /// <summary>
        /// Created By: Steve Coonrod, Matt Deaton
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// Constructor for Editing Events. (UC-607)
        /// Must base functionality on user's role
        /// Takes in an existing Event, as well as the eventManager interface and user object involved
        /// Sets the Edit Mode to true
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        public frmCreateEditEvent(IPUEventManager eventManager, PetUniverseUser user, PUEvent puEvent)
        {
            InitializeComponent();
            _eventManager = eventManager;
            _user = user;
            _event = puEvent;
            _editMode = true;
        }

        /// <summary>
        /// Created By: Steve Coonrod, Matt Deaton
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// Constructor for Creating New Events. (UC-606 and UC-633)
        /// Must base functionality on user's role. Donation Coordinator(DC) vs all other roles
        /// Takes in the eventManager interface and user object involved.
        /// Keeps Edit Mode false
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        public frmCreateEditEvent(IPUEventManager eventManager, PetUniverseUser user)
        {
            InitializeComponent();
            _eventManager = eventManager;
            _user = user;
        }

        /// <summary>
        /// Created By: Steve Coonrod, Matt Deaton
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// Main Click Event. Submits Form Data for processing.
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        private void BtnSubmitCreate_Click(object sender, RoutedEventArgs e)
        {
            int eventID;//Will be returned with the Event
            int requestID;//Will be returned with the Request


            //This method will validate the field data and return the values in a string array
            //The validated field data strings will be assigned to a new Event Object
            //To be passed to the DB through the eventManager interface
            string[] validatedFieldData = validateFormData();
            if (validatedFieldData != null)
            {
                try
                {
                    //Create an Event object from the validated fields
                    PUEvent newEvent = new PUEvent()
                    {
                        CreatedByID = Int32.Parse(validatedFieldData[0]),
                        DateCreated = DateTime.Parse(validatedFieldData[1]),
                        EventName = validatedFieldData[2],
                        EventTypeID = validatedFieldData[3],
                        EventDateTime = DateTime.Parse(validatedFieldData[4]),
                        Address = validatedFieldData[5],
                        City = validatedFieldData[6],
                        State = validatedFieldData[7],
                        Zipcode = validatedFieldData[8],
                        BannerPath = validatedFieldData[9],
                        Status = validatedFieldData[10],
                        Description = validatedFieldData[11]
                    };

                    //Check the User's Role

                    //In any case, the event is created... 
                    //But a DC will create one with the status Approved, and will not need to create a request
                    if (_user.PURoles.Contains("Donation Coordinator"))
                    {
                        newEvent.Status = (statusOptions.Approved.ToString());
                        eventID = _eventManager.AddEvent(newEvent);
                        if (eventID != 0)
                        {
                            MessageBox.Show("Event: " + newEvent.EventName + "\n"
                                + "has been created.");
                            this.DialogResult = true;
                            this.Close();
                        }
                    }
                    else // If the user does not have the Donation Coordinator Role...
                    {
                        newEvent.Status = (statusOptions.PendingApproval.ToString());
                        eventID = _eventManager.AddEvent(newEvent);
                        if (eventID != 0)
                        {
                            //Create A Request
                            Request newRequest = new Request()
                            {
                                DateCreated = DateTime.Now,
                                RequestTypeID = "Event"
                            };
                            requestID = _eventManager.AddRequest(newRequest);
                            if (requestID != 0)
                            {
                                //Will need to create an eventRequest
                                EventRequest newEventRequest = new EventRequest()
                                {
                                    EventID = eventID,
                                    RequestID = requestID,
                                    DisapprovalReason = "",
                                    DesiredVolunteers = 0,
                                    ReviewerID = 0,
                                    Active = true
                                };

                                //Verify that all tables were updated
                                int rowsEffectedByAddRequestEvent =
                                    _eventManager.AddEventRequest(newEventRequest);
                                if (rowsEffectedByAddRequestEvent == 1
                                    && eventID != 0
                                    && requestID != 0)
                                {
                                    MessageBox.Show("Event: " + newEvent.EventName
                                        + " has been created. \nA request has been made to review this event.");
                                    this.DialogResult = true;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("An unknown error has occurred.\nPlease try again later.");
                                    this.DialogResult = false;
                                    this.Close();
                                }
                            }
                        } //End if for non-DC member Event creation
                    }//End if-else for role-based implementation
                }//End try
                catch (Exception ex)
                {
                    MessageBox.Show("We're Sorry.\n" +
                        "There was an error with the process.\n" +
                        "Please try again later.\n" + ex.Message);
                    this.DialogResult = false;
                    this.Close();
                }
            }//End if(validatedFieldData[] != null)
        }//End Submit click event


        /// <summary>
        /// Created By: Steve Coonrod
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// Validation Method to validate all form data
        /// If all fields are valid, returns a string array with the validated field values
        /// else, it returns a null array which needs to be checked at its point of return
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        private string[] validateFormData()
        {
            string[] fieldEntries = new string[12];//To be passed back to the submission method
            bool errorFlag = false;//To track if theres an error with a field submission
            string errorMessageString = "";
            DateTime validatedDateTime = new DateTime();

            //Validate fields and assign to variables
            string createdBy = _user.PUUserID.ToString();//Based on userID. No validation needed
            string dateCreated = DateTime.Now.ToString();//Based on dateTime.Now. No validation needed

            string eventName = txtEventName.Text;
            if (eventName.Length > 150)
            {
                errorMessageString += "The event name has exceeded the max characters allowed (150).\n";
                txtEventName.Text = "";
                errorFlag = true;
            }
            if (eventName.Length < 8)
            {
                errorMessageString += "The event name must be greater than 8 characters.\n";
                txtEventName.Text = "";
                errorFlag = true;
            }

            //cbo values based on sp_select_all_event_types. No validation needed
            string eventType = cboEventType.Text;

            //calendar date picker and cbo's should not allow invalid entries.
            //Just need to compile the datetime string from the date textbox and the time cbo's
            string eventDateTime = txtDate.Text + " " + cboHour.Text + ":" + cboMinute.Text + " " + cboAMPM.Text;
            string format = "dd/MM/yyyy h:mm tt";
            try
            {
                DateTime.TryParseExact(eventDateTime, format,
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None,
                    out validatedDateTime);
                if (!_editMode && validatedDateTime.Date < DateTime.Now.AddDays(14))
                {
                    errorMessageString += "We must have at least 2 weeks notice to assess the event.\n";
                    txtDate.Text = "";
                    errorFlag = true;
                }
            }
            catch (Exception ex)
            {
                errorFlag = true;
                throw new ApplicationException("There was an error parsing the date.\n" + ex.Message);
            }

            string eventAddress = txtAddress.Text;
            if (eventAddress.Length < 6)
            {
                errorMessageString += "Please enter a valid address.\n";
                txtAddress.Text = "";
                errorFlag = true;
            }
            if (eventAddress.Length > 200)
            {
                errorMessageString += "Address is too long.\n";
                txtAddress.Text = "";
                errorFlag = true;
            }

            string eventCity = txtCity.Text;
            if (eventCity.Length < 2)
            {
                errorMessageString += "Please enter a valid city.\n";
                txtCity.Text = "";
                errorFlag = true;
            }
            if (eventCity.Length > 50)
            {
                errorMessageString += "Address is too long.\n";
                txtCity.Text = "";
                errorFlag = true;
            }

            //Cbo should not allow an invalid option. No validation required.
            string eventState = cboState.Text;

            string eventZipcode = txtZip.Text;
            if (eventZipcode.Length < 5 || eventZipcode.Length > 11)
            {
                errorMessageString += "Please enter a valid zipcode.\n";
                txtZip.Text = "";
                errorFlag = true;
            }

            string eventPictureFileName = txtPictureFileName.Text;
            if (eventPictureFileName.Length < 5)
            {
                errorMessageString += "Please enter a valid picture file name.\n";
                txtPictureFileName.Focus();
                errorFlag = true;
            }
            if (eventPictureFileName.Length > 250)
            {
                errorMessageString += "Picture file name is too long.\n";
                txtPictureFileName.Focus();
                errorFlag = true;
            }
            if (!eventPictureFileName.ToLower().Contains(".jpg") && !eventPictureFileName.ToLower().Contains(".png"))
            {
                errorMessageString += "The Picture's File Name requires the file extension.\n" +
                    "Please specify a valid file extension type (.jpg or .png)";
                txtPictureFileName.Focus();
                errorFlag = true;
            }

            //Assigning from a enumeration of status'. Should not need validation.
            string status = (statusOptions.PendingApproval.ToString());

            string description = txtDescription.Text;
            if (description.Length < 2)
            {
                errorMessageString += "Please enter a simple description for the event.\n";
                txtDescription.Text = "";
                errorFlag = true;
            }
            if (description.Length > 500)
            {
                errorMessageString += "The event description is too long.\n Please shorten the description.\n";
                errorFlag = true;
            }

            //This is where, if there are errors it will show a message box with all the error messages
            //It returns the null array, which must be checked where this method returns
            if (errorFlag == true)
            {
                MessageBox.Show(errorMessageString);
                return null;
            }
            else //If there are no errors, the values will be committed to the array that is returned
            {
                fieldEntries[0] = createdBy;
                fieldEntries[1] = dateCreated;
                fieldEntries[2] = eventName;
                fieldEntries[3] = eventType;
                fieldEntries[4] = validatedDateTime.ToString();
                fieldEntries[5] = eventAddress;
                fieldEntries[6] = eventCity;
                fieldEntries[7] = eventState;
                fieldEntries[8] = eventZipcode;
                fieldEntries[9] = eventPictureFileName;
                fieldEntries[10] = status;
                fieldEntries[11] = description;
                //All values should now be validated
                return fieldEntries;
            }
        }//End validateFormData() helper method


        /// <summary>
        /// Created By: Steve Coonrod, Matt Deaton
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// Cancel form event handler. Prompts the user to confirm cancellation. 
        /// If yes, sets the dialog result for the form to false
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult cancel = MessageBox.Show
                ("Are you sure you want to cancel?", "Cancel", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (cancel == MessageBoxResult.Yes)
            {
                this.DialogResult = false;
                this.Close();
            }

        }


        /// <summary>
        /// Created By: Steve Coonrod, Matt Deaton
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// Main window loaded event. 
        /// If event mode is set it populates the fields with the event's values.
        /// Else sets default values
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblUserID.Content = _user.PUUserID;
            setFormCboItems();

            //For editing an event
            if (_editMode == true)
            {
                btnSubmitCreate.Visibility = Visibility.Hidden;
                btnSubmitEdit.Visibility = Visibility.Visible;
                lblHeader.Content = "Edit Event";
                this.Title = "Edit Event";

                calendar.SelectedDate = _event.EventDateTime;
                txtDate.Text = calendar.SelectedDate.Value.ToString("dd/MM/yyyy");

                txtEventName.Text = _event.EventName;
                cboEventType.Text = _event.EventTypeID;

                //For use with the hour cbo
                int eventHour = _event.EventDateTime.Hour;
                if (eventHour > 12)
                {
                    eventHour -= 12;
                }


                //Loops to match combo boxes
                for (int i = 0; i < cboEventType.Items.Count; i++)
                {
                    if (cboEventType.Items[i].ToString() == _event.EventTypeID)
                    {
                        cboEventType.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < cboHour.Items.Count; i++)
                {
                    if (cboHour.Items[i].ToString() == eventHour.ToString())
                    {
                        cboHour.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < cboMinute.Items.Count; i++)
                {
                    if (cboMinute.Items[i].ToString() == _event.EventDateTime.Minute.ToString())
                    {
                        cboMinute.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < cboAMPM.Items.Count; i++)
                {
                    if (cboAMPM.Items[i].ToString() ==
                        _event.EventDateTime.ToString("tt", System.Globalization.CultureInfo.InvariantCulture))
                    {
                        cboAMPM.SelectedIndex = i;
                    }
                }
                for (int i = 0; i < cboState.Items.Count; i++)
                {
                    if (cboState.Items[i].ToString() == _event.State)
                    {
                        cboState.SelectedIndex = i;
                    }
                }


                txtAddress.Text = _event.Address;
                txtCity.Text = _event.City;
                txtZip.Text = _event.Zipcode;
                txtPictureFileName.Text = _event.BannerPath;
                picEventPicture.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory
                    + "\\Images\\" + _event.BannerPath, UriKind.RelativeOrAbsolute));
                txtDescription.Text = _event.Description;

            }
            else //For adding a new Event
            {
                btnSubmitCreate.Visibility = Visibility.Visible;
                btnSubmitEdit.Visibility = Visibility.Hidden;

                calendar.SelectedDate = DateTime.Now.AddDays(14);
                txtDate.Text = calendar.SelectedDate.Value.ToString("dd/MM/yyyy");

                cboHour.SelectedIndex = 6;
                cboMinute.SelectedIndex = 0;
                cboAMPM.SelectedIndex = 0;
                cboState.SelectedIndex = 0;
                cboEventType.SelectedIndex = 0;

                txtEventName.Text = "";
                txtAddress.Text = "";
                txtCity.Text = "";
                txtZip.Text = "";
                txtPictureFileName.Text = "default.png";
                picEventPicture.Source = new BitmapImage(new Uri(System.AppDomain.CurrentDomain.BaseDirectory
                    + "\\Images\\default.png", UriKind.RelativeOrAbsolute));
                txtDescription.Text = "";
            }
        }

        /// <summary>
        /// Created By: Steve Coonrod, Matt Deaton
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// This is a helper method to set the form combo box values
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        private void setFormCboItems()
        {
            //Set cboEventType Items
            List<EventType> eventTypes = _eventManager.GetAllEventTypes();
            foreach (EventType eventType in eventTypes)
            {
                cboEventType.Items.Add(eventType.EventTypeID);
            }

            //Set cboAMPM items
            string[] AMPM = new string[2]
            {
                "AM",
                "PM"
            };
            cboAMPM.ItemsSource = AMPM;

            //cboHour
            for (int i = 1; i <= 12; i++)
            {
                cboHour.Items.Add(i.ToString());
            }

            //cboMinute
            string[] minutes = new string[4]
            {
                "00",
                "15",
                "30",
                "45"
            };

            cboMinute.ItemsSource = minutes;


            //Get the Enumeration for the list of states from the UtilityCode.Enumerations class
            var stateList = (States.StatesAb[])Enum.GetValues(typeof(States.StatesAb));
            cboState.ItemsSource = stateList;
        }

        /// <summary>
        /// Created By: Steve Coonrod, Matt Deaton
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// simple event handler for the calendar
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = calendar.SelectedDate.Value;

            txtDate.Text = selectedDate.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Created By: Steve Coonrod, Matt Deaton
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// The event handler for the choose picture file name button
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        private void btnChoosePicture_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                string usersFilePath = openFileDlg.FileName;
                string shortFilePath = usersFilePath.Substring(usersFilePath.LastIndexOf('\\'));
                // Get the selected file name and display in a TextBox.
                txtPictureFileName.Text = shortFilePath;
                //Need to get the file from the users source 
                //and copy it to the application image source folder

                //Set the event picture to the new image source


            }
        }

        private void BtnSubmitEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

