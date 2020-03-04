using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Josh Jackson
    /// DATE: 02/07/2020
    /// Checked By: Ethan Holmes, Gabi Legrand
    /// This is a data access class used for testing, uses fake data does not communicate with a DB
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Josh Jackson
    /// UPDATE DATE: 02/13/2020
    /// WHAT WAS CHANGED: Added GetVolunteerByName() method
    /// </remarks>
    public class FakeVolunteerAccessor : IVolunteerAccessor
    {
        private List<Volunteer> volunteers = new List<Volunteer>();

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// This is a constructor containing a list of volunteers to be used for testing purposes
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Josh Jackson
        /// UPDATE DATE: 02/13/2020
        /// WHAT WAS CHANGED: Added Fake Volunteer data to list of volunteers
        /// </remarks>
        public FakeVolunteerAccessor()
        {
            volunteers = new List<Volunteer>()
            {
                new Volunteer()
                {
                    VolunteerID = 1,
                    FirstName = "Tony",
                    LastName = "Stark",
                    Email = "ironman@gmail.com",
                    PhoneNumber = "15554443322",
                    OtherNotes = "test",
                    Active = true,
                    Skills = new List<string>() { "Dogwalker", "Groomer" }
                },
                 new Volunteer()
                 {
                     VolunteerID = 2,
                     FirstName = "Ronnie",
                     LastName = "Radke",
                     Email = "fir@gmail.com",
                     PhoneNumber = "16664206969",
                     OtherNotes = "test",
                     Active = true,
                     Skills = new List<string>() { "Dogwalker", "Groomer" }
                 }
            };
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/13/2020
        /// Checked By: Gabi L
        /// This is a data access method used for testing searching for a Volunteer by their first and last name
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public List<Volunteer> GetVolunteerByName(string firstName, string lastName)
        {
            return (from v in volunteers
                    where v.FirstName == "Tony" where v.LastName == "Stark"
                    select v).ToList();
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// This is a data access method used for testing inserting a volunteer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <param name="volunteer"></param>
        /// <returns></returns>
        public int InsertVolunteer(Volunteer volunteer)
        {
            volunteers.Add(volunteer);
            return 1;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// This is a data access method used for testing selecting a list of skills
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        /// <returns></returns>
        public List<string> SelectAllSkills()
        {
            List<string> skills = new List<string>() { "Dogwalker", "Groomer"};
            return skills;
        }

        /// <summary>
        /// NAME: Gabrielle LeGrand
        /// DATE: 2/6/2020
        /// Checked by: Josh J
        /// This Test method selects the fake volunteers that are listed as active in the Fake Volunteer Accessor class.
        /// </summary>
        /// <param name="active"></param>
        /// <returns> SelectedVolunteers </returns>
        /// <remarks>
        /// UPDATED BY: 
        /// UPDATE DATE: 
        /// CHANGE DESCRIPTION:
        /// </remarks>

        public List<Volunteer> SelectVolunteersByActive(bool active = true)
        {
            var selectedVolunteers = (from v in volunteers
                                      where v.Active == true
                                      select v).ToList();
            return selectedVolunteers;
        }
    }
}

