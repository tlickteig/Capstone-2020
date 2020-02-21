using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace WPFPresentationLayer.PersonnelPages
{
    /// <summary>
    /// Interaction logic for frameShiftTime.xaml
    /// </summary>
    public partial class frameShiftTime : Page
    {
        private IShiftTimeManager _shiftTimeManager = null;
        private IDepartmentManager _departmentManager = null;
        private PetUniverseShiftTime _shiftTime = null;


        public frameShiftTime()
        {
            InitializeComponent();
            _shiftTimeManager = new ShiftTimeManager();
            _departmentManager = new DepartmentManager();
        }

        public frameShiftTime(IShiftTimeManager shiftTimeManager)
        {
            InitializeComponent();
            _departmentManager = new DepartmentManager();
            _shiftTimeManager = shiftTimeManager;

        }
        public frameShiftTime(PetUniverseShiftTime shiftTime, IShiftTimeManager shiftTimeManager)
        {
            _shiftTime = shiftTime;
            _shiftTimeManager = shiftTimeManager;
            _departmentManager = new DepartmentManager();
            InitializeComponent();

        }

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:NA
        /// 
        //cancels opperations in the current window
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks> 
        private void btnShiftTimeCancel_Click(object sender, RoutedEventArgs e)
        {
            ResetControls();
        }

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:NA
        /// 
        //logic or what happens when the window loads
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateShiftTimes();
            PopulateDepartments();
            cboShiftTimeDepartment.IsEnabled = false;
            TPStartTime.IsEnabled = false;
            TPEndTime.IsEnabled = false;
        }
        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:NA
        /// 
        /// Helper method for populating the Departments Drop Down
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private void PopulateDepartments()
        {
            cboShiftTimeDepartment.Items.Clear();
            List<Department> departments = new List<Department>();
            departments = _departmentManager.RetrieveAllDepartments();

            foreach (Department department in departments)
            {
                cboShiftTimeDepartment.Items.Add(department.DepartmentID);
            }
        }

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:NA
        /// 
        /// Helper method for populating the ShiftTime DG
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private void PopulateShiftTimes()
        {
            dgShiftTime.ItemsSource = _shiftTimeManager.RetrieveShiftTimes();
            dgShiftTime.Columns[0].Header = "DepartmentID";
            dgShiftTime.Columns[1].Header = "StartTime";
            dgShiftTime.Columns[2].Header = "EndTime";
        }

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:NA
        /// 
        /// Helper method for reseting the controls of the page after certain events
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private void ResetControls()
        {
            PopulateShiftTimes();
            PopulateDepartments();
            cboShiftTimeDepartment.IsEnabled = false;
            TPStartTime.Value = DateTime.Parse("00:00:00");
            TPEndTime.Value = DateTime.Parse("00:00:00");
            btnShiftTimeCancel.IsEnabled = false;
            TPStartTime.IsReadOnly = true;
            TPEndTime.IsReadOnly = true;
            btnShiftTimeAdd.IsEnabled = true;
            btnShiftTimeEdit.IsEnabled = true;
            dgShiftTime.IsReadOnly = true;
        }

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:NA
        /// 
        /// click handler for the save button
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private void btnShiftTimeSave_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult result = MessageBox.Show("Are You Sure?", "Pet Universe", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (cboShiftTimeDepartment.Text.ToString() == "" || cboShiftTimeDepartment.Text.ToString() == null)
                    {
                        MessageBox.Show("Please Select a Department.");
                        return;
                    }
                    if (TPStartTime.Text.ToString() == "" || TPStartTime.Text.ToString() == null)
                    {
                        MessageBox.Show("Please Select a Shift Start Time.");
                        TPStartTime.Focus();
                        return;
                    }
                    if (TPEndTime.Text.ToString() == "" || TPEndTime.Text.ToString() == null)
                    {
                        MessageBox.Show("Please Select a Shift Start Time.");
                        TPEndTime.Focus();
                        return;
                    }
                    if (TPStartTime.Text.ToString() == TPEndTime.Text.ToString())
                    {
                        MessageBox.Show("Shifts must be at least 1Hour.");
                        TPStartTime.Focus();
                        return;
                    }

                    PetUniverseShiftTime shiftTime = new PetUniverseShiftTime()
                    {
                        DepartmentID = cboShiftTimeDepartment.Text.ToString(),
                        StartTime = TPStartTime.Text.ToString(),
                        EndTime = TPEndTime.Text.ToString()
                    };
                    if (btnShiftTimeEdit.IsEnabled == false)
                    {
                        try
                        {
                            if (_shiftTimeManager.AddShiftTime(shiftTime))
                            {

                                PopulateShiftTimes();
                                ResetControls();
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message + "\n" + ex.InnerException.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            if (_shiftTimeManager.EditShiftTime(_shiftTime = (PetUniverseShiftTime)dgShiftTime.SelectedItem, shiftTime))
                            {
                                PopulateShiftTimes();
                                ResetControls();
                            }
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message + "\n" + ex.InnerException.Message);
                        }
                    }

                    PopulateShiftTimes();
                    ResetControls();
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Okay", "PetUniverse");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Canceled.", "PetUniverse");
                    break;
            }



        }

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:NA
        /// 
        /// click handler for the add
        /// button
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private void btnShiftTimeAdd_Click(object sender, RoutedEventArgs e)
        {


            btnShiftTimeEdit.IsEnabled = false;
            btnShiftTimeCancel.IsEnabled = true;
            TPStartTime.IsReadOnly = false;
            TPEndTime.IsReadOnly = false;
            TPStartTime.IsEnabled = true;
            TPEndTime.IsEnabled = true;
            cboShiftTimeDepartment.IsEnabled = true;

        }

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:NA
        /// 
        /// auto generated columns handler to get rid of the ShiftTimeID field on DGShiftTime
        /// button
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private void dgShiftTime_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgShiftTime.Columns.RemoveAt(0);


        }

        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:NA
        /// 
        /// click handler for the edit
        /// button
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private void btnShiftTimeEdit_Click(object sender, RoutedEventArgs e)
        {



            string time = null;

            PetUniverseShiftTime shiftTime = (PetUniverseShiftTime)dgShiftTime.SelectedItem;

            if (shiftTime != null)
            {
                btnShiftTimeAdd.IsEnabled = false;
                btnShiftTimeCancel.IsEnabled = true;
                cboShiftTimeDepartment.IsEnabled = true;
                TPStartTime.IsReadOnly = false;
                TPEndTime.IsReadOnly = false;
                TPStartTime.IsEnabled = true;
                TPEndTime.IsEnabled = true;
                var ShiftTimeForm = new frameShiftTime(shiftTime, _shiftTimeManager);

                cboShiftTimeDepartment.SelectedItem = shiftTime.DepartmentID;

                time = shiftTime.StartTime;
                DateTime dateTime = ParseDatetime(time);
                TPStartTime.Value = dateTime;

                time = shiftTime.EndTime;
                dateTime = ParseDatetime(time);
                TPEndTime.Value = dateTime;
            }
            else { MessageBox.Show("you must select a ShiftTime to edit!"); }


        }


        /// <summary>
        /// NAME:Lane Sandburg
        /// DATE: 02/07/2019
        /// CHECKED BY:NA
        /// 
        /// helper method for getting shiftTimes from string to date time to be displayed in time pickers
        /// button
        /// </summary>
        /// <remarks>
        /// UPDATED BY:NA
        /// UPDATED DATE:
        /// WHAT WAS CHANGED:
        /// </remarks>
        private static DateTime ParseDatetime(string time)
        {
            return DateTime.ParseExact(time, "HH:mm:ss",
                                        CultureInfo.InvariantCulture);
        }


    }
}
