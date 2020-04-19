using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using PresentationUtilityCode;
using System;
using System.Collections;
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

namespace WPFPresentationLayer.PersonnelPages
{
    /// <summary>
    /// Interaction logic for BaseScheduleControls.xaml
    /// </summary>
    public partial class BaseScheduleControls : Page
    {
        IDepartmentManager _departmentManager;
        IShiftTimeManager _shiftTimeManager;
        IERoleManager _eRoleManager;
        IBaseScheduleManager _baseScheduleManager;
        PetUniverseUser _user;
        BaseScheduleVM _baseScheduleVM;


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This is a constructor method that takes no arguments.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        public BaseScheduleControls()
        {
            InitializeComponent();
            _departmentManager = new DepartmentManager();
            _baseScheduleManager = new BaseScheduleManager();
            _shiftTimeManager = new ShiftTimeManager();
            _eRoleManager = new ERoleManager();
            cboDepartment.ItemsSource = getDepartmentNames();
            getBaseScheduleVM();
            _user = new PetUniverseUser();

        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This is a constructor method that takes a PUUser.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="user"></param>
        public BaseScheduleControls(PetUniverseUser user)
        {
            InitializeComponent();
            _departmentManager = new DepartmentManager();
            _baseScheduleManager = new BaseScheduleManager();
            _shiftTimeManager = new ShiftTimeManager();
            _eRoleManager = new ERoleManager();
            getBaseScheduleVM();
            cboDepartment.ItemsSource = getDepartmentNames();
            _user = user;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This is a method gets the active base schedule.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        private void getBaseScheduleVM()
        {
            try
            {
                _baseScheduleVM = _baseScheduleManager.GetActiveBaseSchedule();
            }
            catch (Exception ex)
            {
                WPFErrorHandler.ErrorMessage("Data not found.", ex.Message);
            }
        }



        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This creates as list of department name strings.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        private List<string> getDepartmentNames()
        {
            List<string> names = new List<string>();
            try
            {
                foreach (Department department in _departmentManager.RetrieveAllDepartments())
                {
                    names.Add(department.DepartmentID);
                }
            }
            catch (Exception ex)
            {

                WPFErrorHandler.ErrorMessage("Data not found.", ex.Message);
            }
            if (names.Count == 0)
            {
                names.Add("None Available.");
            }

            return names;
        }
        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This fills the datagrid.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <returns></returns>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboDepartment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboDepartment.SelectedIndex != -1)
            {
                try
                {
                    List<PetUniverseShiftTime> times =
                        _shiftTimeManager.RetrieveShiftTimesByDepartment(cboDepartment.SelectedItem.ToString());
                    List<ERole> roles =
                        _eRoleManager.RetrieveERolesByDepartmentID(cboDepartment.SelectedItem.ToString());
                    List<BaseScheduleLine> oldLines = _baseScheduleVM.BaseScheduleLines;
                    List<BaseScheduleLine> lines = new List<BaseScheduleLine>();

                    foreach (PetUniverseShiftTime time in times)
                    {
                        foreach (ERole role in roles)
                        {
                            lines.Add(new BaseScheduleLine()
                            {
                                BaseScheduleID = 0,
                                Count = 0,
                                DepartmentID = cboDepartment.SelectedItem.ToString(),
                                ERoleID = role.ERoleID,
                                ShiftTimeID = time.ShiftTimeID

                            });
                        }
                    }

                    foreach (BaseScheduleLine line in lines)
                    {
                        foreach (BaseScheduleLine oldLine in oldLines)
                        {
                            if (line.ERoleID.Equals(oldLine.ERoleID)
                                && line.ShiftTimeID.Equals(oldLine.ShiftTimeID))
                            {
                                line.Count = oldLine.Count;
                            }
                        }
                    }

                    dgBaseSchedule.ItemsSource = lines;
                }
                catch (Exception ex)
                {
                    WPFErrorHandler.ErrorMessage("Data not found.", ex.Message);
                }
            }
        }


        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/18/2020
        /// Approver:  Chase Schulte
        /// 
        /// This is a method for removing unnecessary columns
        /// </summary>
        /// <remarks>
        /// Updater: Chase Schulte
        /// Updated: 3/18/2020
        /// Update: Removed foreach to modify col width and added column headers.
        /// 
        /// Updater: Jordan Lindo
        /// Updated: 3/19/2020
        /// Update: Removed hard coded headers removed unneccessary columns.
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgBaseSchedule_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgBaseSchedule.Columns.RemoveAt(1);
            dgBaseSchedule.Columns.RemoveAt(1);
            dgBaseSchedule.Columns.RemoveAt(1);
        }
    }
}
