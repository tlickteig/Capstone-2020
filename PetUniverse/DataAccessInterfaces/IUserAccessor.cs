using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    /// CREATOR: Steven Cardona
    /// Date: 02/07/2020
    /// APPROVER: N/A
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
        /// UPDATED BY: N/A
        /// UPDATED N/A
        ///     UPDATE: N/A
        /// APPROVER: N/A
        /// </remarks>
        /// <param name="petUniverseUser">The user the will be inserted</param>
        /// <returns>returns true if insertion of user was successful else returns false</returns>
        bool InsertNewUser(PetUniverseUser petUniverseUser);

        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/10/2020
        /// APPROVER: Zach Behrensmeyer
        ///
        /// Interface method signature for selecting all active users
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        ///     UPDATE: N/A
        /// APPROVER: N/A
        /// </remarks>
        /// <returns>Returns a list of active users</returns>
        List<PetUniverseUser> SelectAllActivePetUniverseUsers();

        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/4/2020
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
        PetUniverseUser AuthenticateUser(string username, string passwordHash);
    }
}
