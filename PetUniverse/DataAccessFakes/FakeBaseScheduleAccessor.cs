using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    public class FakeBaseScheduleAccessor : IBaseScheduleAccessor
    {

        private static BaseScheduleVM _baseScheduleVM = new BaseScheduleVM()
        {
            Active = true,
            BaseScheduleID = 1000000,
            CreatingUserID = 100000,
            CreationDate = DateTime.Parse("2020-01-03"),
            BaseScheduleLines = _lines
        };

        private static List<BaseScheduleLine> _lines = new List<BaseScheduleLine>()
            {
                new BaseScheduleLine()
                {
                    BaseScheduleID = 1000000,
                    DepartmentID = "Management",
                    ERoleID = "Manager",
                    ShiftTimeID = 1000000,
                    Count = 1
                },
                new BaseScheduleLine()
                {
                    BaseScheduleID = 1000000,
                    DepartmentID = "Sales",
                    ERoleID = "Cashier",
                    ShiftTimeID = 1000004,
                    Count = 6
                }
            };

        private List<BaseSchedule> _baseSchedules = new List<BaseSchedule>()
        {
            _baseScheduleVM
        };

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver: Chase Schulte
        /// 
        /// Fake insert
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        /// <param name="baseScheduleVM"></param>
        /// <returns></returns>
        public int InsertBaseScheduleVM(BaseScheduleVM baseScheduleVM)
        {
            _baseSchedules.Add(baseScheduleVM);
            return 1;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver:
        /// 
        /// Fake Retrieve one
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        public BaseScheduleVM RetrieveActiveBaseSchedule()
        {
            return _baseScheduleVM;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver:
        /// 
        /// fake retrieve all
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        public List<BaseSchedule> RetrieveAllBaseSchedules()
        {
            return _baseSchedules;
        }

        /// <summary>
        /// Creator: Jordan Lindo
        /// Created: 3/17/2020
        /// Approver: 
        /// 
        /// fake retrieve lines by id
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Approver: NA
        /// 
        /// </remarks>
        public List<BaseScheduleLine> RetrieveBaseScheduleLinesByBaseScheduleID(int baseScheduleID)
        {
            return _lines;
        }
    }
}
