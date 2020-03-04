using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 2/11/2020
    /// Approved: Steven Cardona
    /// 
    /// Interface for accessing Log Data
    /// </summary>
    public interface ILogAccessor
    {
        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/11/2020
        /// Approved: Steven Cardona
        /// 
        /// This method is used to authenticate the user and make sure they exist for login
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Updated: NA
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns>Valid User</returns>
        List<LogItem> GetLoginLogout();

    }
}
