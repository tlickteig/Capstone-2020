using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Zach Behrensmeyer
    /// CREATED: 2/11/2020
    /// CHECKED BY: Steven Cardona
    /// 
    /// This class is where we can pull fake LogItems from from
    /// </summary>
    public class FakeLogAccessor : ILogAccessor
    {
        private List<LogItem> logs;

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// CREATED: 2/11/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This fake method is called to get a fake LogItem
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED BY: NA
        /// CHANGE:
        /// 
        /// </remarks>
        /// <returns>fake LogItem</returns>
        public FakeLogAccessor()
        {
            logs = new List<LogItem>()

            {
                new LogItem(){
                LogID = 1,
                LogDate = DateTime.Now,
                LogThread = "",
                LogLevel = "Info",
                Logger = "",
                Message = "Joe logged in",
                Exception = ""
                }
            };
        }

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/11/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This fake method is called to get a fake list of logitems
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED BY: NA
        /// CHANGE:
        /// 
        /// </remarks>
        /// <returns>Fake list of logs</returns>
        public List<LogItem> GetLoginLogout()
        {
            return (from l in logs select l).ToList();
        }
    }
}
