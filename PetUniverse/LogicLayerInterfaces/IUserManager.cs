using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Steven Cardona
    /// Created: 02/10/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// Interface that defines method for user manager
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Creates a new user
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <param name="petUniverseUser"></param>
        /// <returns>Boolean value to tell if new user was created</returns>
        bool CreateNewUser(PetUniverseUser petUniverseUser);

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Retrieves a list of all active users
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        ///
        /// <returns>List of all active users</returns>
        List<PetUniverseUser> RetrieveAllActivePetUniverseUsers();

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This calls the User Authentication Data Accessor Method
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// 
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Returns Valid User Info</returns>
        PetUniverseUser AuthenticateUser(string email, string password);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to get users by email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <returns></returns>
        PetUniverseUser getUserByEmail(string email);

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 3/3/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to confirm user exists
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>        
        /// <returns>Returns Valid User Info</returns>
        bool CheckIfUserExists(string Email);

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 3/3/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to Lockout a user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>        
        /// <returns>Returns Valid User Info</returns>
        bool LockoutUser(string Email, DateTime currentDate, DateTime unlockDate);

        /// <summary>
        /// Creator : Zach Behrensmeyer
        /// Created: 3/3/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to unlock user if they haven't been
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>        
        /// <returns>Returns Valid User Info</returns>
        bool UnlockUserByTime(string Email);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/5/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to unlock user if they haven't been
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>        
        /// <returns>Returns Valid User Info</returns>
        DateTime fetchUnlockDate(string userName);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 3/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Manager method to get users from a department
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>        
        /// <returns>Returns Valid User Info</returns>
        List<PetUniverseUser> GetDepartmentUsers(string DepartmentID);
    }
}
