using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Steven Cardona
    /// Created: 02/07/2020
    /// Approver: Zach Behrensmeyer
    /// </summary>
    public interface IUserAccessor
    {

        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/07/2020
        /// APPROVER: Zach Behrensmeyer
        ///
        /// Interface method signature for inserting a New User
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="petUniverseUser">The user the will be inserted</param>
        /// <returns>returns true if insertion of user was successful else returns false</returns>
        bool InsertNewUser(PetUniverseUser petUniverseUser);

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Interface method signature for selecting all active users
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>Returns a list of active users</returns>
        List<PetUniverseUser> SelectAllActivePetUniverseUsers();

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/4/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to authenticate the user and make sure they exist for login
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns>Valid User</returns>
        PetUniverseUser AuthenticateUser(string username, string passwordHash);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to check if provided email exists
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns>bool if user exists</returns>
        bool CheckIfUserExists(string userName);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to lock out the user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns>bool if user exists</returns>
        /// <param name="userName"></param>
        /// <param name="currentDate"></param>
        /// <param name="unlockDate"></param>
        /// <returns>bool if locked</returns>
        bool LockoutUser(string userName, DateTime currentDate, DateTime unlockDate);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to unlock the user based on time
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns></returns>
        bool TimeoutUserUnlock(string userName);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// This method is used to unlock the user based on time
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userName"></param>
        /// <returns>bool if user is unlocked</returns>
        DateTime getUnlockDate(string userName);
    }
}
