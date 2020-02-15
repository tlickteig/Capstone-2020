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
    /// CREATOR: Steven Cardona
    /// DATE: 02/10/2020
    /// APPROVER: Zach Behrensmeyer
    /// 
    /// Data Access Fake for Accessing Users
    /// </summary>
    public class FakeUserAccessor : IUserAccessor
    {
        private PetUniverseUser _user;

        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/10/2020
        /// APPROVER: Zach Behrensmeyer
        /// 
        /// Data Access Fake for Inserting a new user
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        /// UPDATE: N/A
        /// APPROVER: N/A
        /// </remarks>
        /// <param name="petUniverseUser">Test user being created</param>
        /// <returns>True if fakePetUniverseUser and petUniverseUser are equal</returns>
        public bool InsertNewUser(PetUniverseUser petUniverseUser)
        {
            PetUniverseUser fakePetUniverseUser = new PetUniverseUser()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "jdoe@PetUniverse.com",
                City = "Cedar Rapids",
                PhoneNumber = "2255448796",
                State = "IA",
                ZipCode = "52404",
            };

            bool equals = fakePetUniverseUser.ToString().Equals(petUniverseUser.ToString());

            return equals;
        }

        /// <summary>
        /// CREATOR: Steven Cardona
        /// DATE: 02/11/2020
        /// APPROVER: Zach Behrensmeyer
        ///
        /// Data Access Face for selecting all active users.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        /// UPDATE: N/A
        /// APPROVER: N/A
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
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/3/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This fake method is called to get a fake user
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED BY: NA
        /// CHANGE:
        /// 
        /// </remarks>
        /// <param name="username"></param>
        /// <param name="passwordHash"></param>
        /// <returns>fake user</returns>
        public PetUniverseUser AuthenticateUser(string username, string passwordHash)
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
    }
}
