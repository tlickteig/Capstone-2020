using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// CREATOR: Steven Cardona
    /// DATE: 02/10/2020
    /// APPROVER: Zach Behrensmeyer
    ///
    /// Interface that defines method for user manager
    /// </summary>
    public interface IUserManager
    {
        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/10/2020
        /// APPROVER: Zach Behrensmeyer
        ///
        /// Creates a new user
        /// </summary>
        ///<remarks>
        ///UPDATED BY:
        /// UPDATED
        ///     UPDATE:
        /// APPROVER:
        /// </remarks>
        /// <param name="petUniverseUser"></param>
        /// <returns>Boolean value to tell if new user was created</returns>
        bool CreateNewUser(PetUniverseUser petUniverseUser);

        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/10/2020
        /// APPROVER: Zach Behrensmeyer
        ///
        /// Retrieves a list of all active users
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATED
        ///     UPDATE:
        /// APPROVER:
        /// </remarks>
        ///
        /// <returns>List of all active users</returns>
        List<PetUniverseUser> RetrieveAllActivePetUniverseUsers();

        /// <summary>
        /// NAME : Zach Behrensmeyer
        /// DATE: 2/3/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This calls the User Authentication Data Accessor Method
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Returns Valid User Info</returns>
        PetUniverseUser AuthenticateUser(string email, string password);

    }
}
