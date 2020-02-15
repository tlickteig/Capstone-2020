using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// CODED BY: Steven Cardona and Zach Behrensmeyer
    /// DATE: 02/07/2020
    /// APPROVER: Zach Behrensmeyer
    ///
    /// Class to manage uses implements the IUserManager Interface
    /// </summary>
    public class UserManager : IUserManager
    {

        private IUserAccessor _userAccessor;

        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/ 07/2020
        /// APPROVER: Zach Behrensmeyer
        /// Default constructor for the User Manager
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// UPDATE: N/A
        /// </remarks>
        public UserManager()
        {
            _userAccessor = new UserAccessor();
        }

        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/ 07/2020
        /// APPROVER: Zach Behrensmeyer
        /// Constructor for the User Manager that takes an userAccessor
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED DATE: N/A
        /// UPDATE: N/A
        /// </remarks>
        /// <param name="userAccessor">User Accessor that is being used</param>
        public UserManager(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/07/2020/
        /// APPROVER: Zach Behrensmeyer
        ///
        /// Manager method to create new user
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        ///     UPDATE: N/A
        /// </remarks>
        /// <param name="petUniverseUser">User being created</param>
        /// <returns>Returns true if successful user creation</returns>
        public bool CreateNewUser(PetUniverseUser petUniverseUser)
        {
            try
            {
                return _userAccessor.InsertNewUser(petUniverseUser);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to create new user", ex) ;
            }
        }

        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/10/2020/
        /// APPROVER: Zach Behrensmeyer
        ///
        /// Manager method to get all active users
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        ///     UPDATE: N/A
        /// </remarks>
        /// <returns>Returns a list of active PetUniverseUsers</returns>
        public List<PetUniverseUser> RetrieveAllActivePetUniverseUsers()
        {
            List<PetUniverseUser> users = new List<PetUniverseUser>();

            try
            {
                users = _userAccessor.SelectAllActivePetUniverseUsers();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Users Found", ex);
            }

            return users;
        }

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
        /// UPDATE: NA
        /// 
        /// </remarks>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns>Returns Valid User Info</returns>
        public PetUniverseUser AuthenticateUser(string email, string password)
        {
            PetUniverseUser result = null;
            var passwordHash = hashPassword(password);
            password = null;

            try
            {
                result = _userAccessor.AuthenticateUser(email, passwordHash);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Login failed!", ex);
            }
            return result;
        }

        /// <summary>
        /// NAME : Zach Behrensmeyer
        /// DATE: 2/3/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method hashes the given password
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        /// <param name="source"></param>
        /// <returns>Hashed Password</returns>
        private string hashPassword(string source)
        {
            string result = null;

            // we need a byte array because cryptography is bits and bytes
            byte[] data;

            using (SHA256 sha256hash = SHA256.Create())
            {
                // This part hashes the input
                data = sha256hash.ComputeHash(Encoding.UTF8.GetBytes(source));
            }
            // builds a new string from the result
            var s = new StringBuilder();

            // loops through bytes to build the string
            for (int i = 0; i < data.Length; i++)
            {
                s.Append(data[i].ToString("x2"));
            }

            result = s.ToString().ToUpper();

            return result;
        }
    }
}
