using DataTransferObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME : Zach Behrensmeyer
    /// DATE: 2/11/2020
    /// CHECKED BY: Steven Cardona
    /// 
    /// This is the interface for LogManager
    /// </summary>
    public interface ILogManager
    {
        /// <summary>
        /// NAME : Zach Behrensmeyer
        /// DATE: 2/3/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This calls the LogItem Authentication Data Accessor Method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <returns>List of Logs</returns>
        List<LogItem> RetrieveLoginandOutLogs();
    }
}
