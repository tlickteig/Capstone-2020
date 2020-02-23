using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Steven Cardona
    /// Created: 02/10/2020
    /// Approver: Zach Behrensmeyer
    /// 
    /// Data Access Fake for Accessing Users
    /// </summary>
    public class FakeUserAccessor : IUserAccessor
    {
        private PetUniverseUser _user;

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/10/2020
        /// Approver: Zach Behrensmeyer
        /// 
        /// Data Access Fake for Inserting a new user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <param name="petUniverseUser">Test user being created</param>
        /// <returns>True if fakePetUniverseUser and petUniverseUser are equal</returns>
        public bool InsertNewUser(PetUniverseUser petUniverseUser)
        {
            bool firstName = petUniverseUser.FirstName.Equals("John");
            bool lastName = petUniverseUser.LastName.Equals("Doe");
            bool email = petUniverseUser.Email.Equals("jdoe@PetUniverse.com");
            bool city = petUniverseUser.City.Equals("Cedar Rapids");
            bool phoneNumber = petUniverseUser.PhoneNumber.Equals("2255448796");
            bool state = petUniverseUser.State.Equals("IA");
            bool zipCode = petUniverseUser.ZipCode.Equals("52404");

            if (firstName && lastName && email && city && phoneNumber && state && zipCode)
            {
                return true;
            }
            else
            {
                throw new ApplicationException("Unable to add User");
            }
        }

        /// <summary>
        /// Creator: Steven Cardona
        /// Created: 02/11/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Data Access Face for selecting all active users.
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// <returns>Returns a list of PetUniverseUsers</returns>
        public List<PetUniverseUser> SelectAllActivePetUniverseUsers()
        {
            List<PetUniverseUser> users = new List<PetUniverseUser>()
            {
                new PetUniverseUser()
                {
                    PUUserID = 100000,
                    FirstName = "Test1",
                    LastName = "Test1",
                    City = "Cedar Rapids",
                    Email = "test1@PetUniverse.com",
                    PhoneNumber = "5632341221",
                    State = "IA",
                    ZipCode = "52406",
                    Active = true
                },
                new PetUniverseUser()
                {
                    PUUserID = 100001,
                    FirstName = "Test2",
                    LastName = "Test2",
                    City = "New York",
                    Email = "test2@PetUniverse.com",
                    PhoneNumber = "5632348893",
                    State = "NY",
                    ZipCode = "10021",
                    Active = true
                },
                new PetUniverseUser()
                {
                    PUUserID = 100002,
                    FirstName = "Test3",
                    LastName = "Test3",
                    City = "Indianapolis",
                    Email = "test3@PetUniverse.com",
                    PhoneNumber = "5632321111",
                    State = "IN",
                    ZipCode = "77821",
                    Active = false
                },
            };

            users = (from user in users
                where user.Active == true
                select user).ToList();

            return users;
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 2/3/2020
        /// Approver: Steven Cardona
        /// 
        /// This fake method is called to get a fake user
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        /// 
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns>fake user</returns>
        public PetUniverseUser AuthenticateUser(string username, string passwordHash)
        {
            bool userName = username.Equals("j.doe@RandoGuy.com");
            bool hash = passwordHash.Equals("A7574A42198B7D7EEE2C037703A0B95558F195457908D6975E681E2055FD5EB9");

            if (userName && hash)
            {
                _user = new PetUniverseUser()
                {
                    PUUserID = 100000,
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "5632102101",
                    Email = "j.doe@RandoGuy.com",
                    Active = true,
                    City = "Cedar Rapids",
                    State = "IA",
                    ZipCode = "52404"
                };
                return _user;
            }
            else
            {
                throw new ApplicationException("Invalid User");
            }
        }
    }
}
