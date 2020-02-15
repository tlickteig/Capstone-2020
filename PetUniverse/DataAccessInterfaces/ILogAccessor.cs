using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Zach Behrensmeyer
    /// DATE: 2/11/2020
    /// CHECKED BY: Steven Cardona
    /// 
    /// Interface for accessing Log Data
    /// </summary>
    public interface ILogAccessor
    {
        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/11/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This method is used to authenticate the user and make sure they exist for login
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// CHANGE:
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns>Valid User</returns>
        List<LogItem> GetLoginLogout();

    }
}
