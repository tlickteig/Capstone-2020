using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Zach Behrensmeyer
    /// DATE: 2/11/20
    /// CHECKED BY: Steven Cardona
    /// 
    /// This class is where we create the properties of a LogItem
    /// </summary>
    /// <remarks>
    /// UPDATE BY: NA
    /// UPDATED NA
    /// CHANGE: NA
    /// 
    /// </remarks>
    public class LogItem
    {
        public int LogID { get; set; }
        public DateTime LogDate { get; set; }
        public string LogThread { get; set; }
        public string LogLevel { get; set; }
        public string Logger { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
