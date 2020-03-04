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

    }
}
