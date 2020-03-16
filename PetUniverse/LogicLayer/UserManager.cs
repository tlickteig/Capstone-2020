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
    /// Creator: Steven Cardona and Zach Behrensmeyer
    /// Created: 02/07/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// Class to manage uses implements the IUserManager Interface
    /// </summary>
    public class UserManager : IUserManager
    {

        private IUserAccessor _userAccessor;

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/07/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Default constructor for the User Manager
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        public UserManager()
        {
            _userAccessor = new UserAccessor();
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/07/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Constructor for the User Manager that takes an userAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <param name="userAccessor">User Accessor that is being used</param>
        public UserManager(IUserAccessor userAccessor)
        {
            _userAccessor = userAccessor;
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/07/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Manager method to create new user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
                throw new ApplicationException("Unable to create new user", ex);
            }
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020/
        /// Approver: Zach Behrensmeyer
        ///
        /// Manager method to get all active users
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
        /// Creator : Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This calls the User Authentication Data Accessor Method
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
        /// Creator : Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This Method hashes the given password
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
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
        public bool CheckIfUserExists(string Email)
        {
            bool exists;

            try
            {
                exists = _userAccessor.CheckIfUserExists(Email);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Users Found", ex);
            }
            return exists;
        }

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
        public bool LockoutUser(string Email, DateTime currentDate, DateTime unlockDate)
        {
            bool isLocked;

            try
            {
                isLocked = _userAccessor.LockoutUser(Email, currentDate, unlockDate);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Users Found", ex);
            }
            return isLocked;
        }

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
        public bool UnlockUserByTime(string Email)
        {
            bool isUnlocked;

            try
            {
                isUnlocked = _userAccessor.TimeoutUserUnlock(Email);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Users Found", ex);
            }
            return isUnlocked;
        }

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
        public DateTime fetchUnlockDate(string userName)
        {
            DateTime unlockDate;
            try
            {
                unlockDate = _userAccessor.getUnlockDate(userName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No user found", ex);
            }
            return unlockDate;
        }
    }
}