using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{

    /// <summary>
    /// Creator: Austin Gee
    /// Created: 3/18/2020
    /// Approver: Thomas Dupuy
    /// 
    /// Interface that contains methods that relate to adoption application
    /// data access methods
    /// </summary>
    public interface IAdoptionApplicationAccessor
    {

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/28/2020
        /// Approver: 
        /// 
        /// inserts an adoption application into the database
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="application"></param>
        /// <returns></returns>
        int InsertAdoptionApplication(Application application);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/18/2020
        /// Approver: Thomas Dupuy
        /// 
        /// selects a list of ApplicationVMs by on Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        List<ApplicationVM> SelectAdoptionApplicationsByEmail(string email, bool active);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 3/18/2020
        /// Approver: Michael Thompson
        /// 
        /// selects an ApplicationVM by on Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        ApplicationVM SelectAdoptionApplicationByID(int adoptionApplicationID);

        /// <summary>
        /// Creator: Austin Gee
        /// Created: 4/22/2020
        /// Approver: Michael Thompson
        /// 
        /// selects an ApplicationVM by on Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <returns></returns>
        int DeactivateAdoptionApplication(int adoptionApplicationID);
    }
}
