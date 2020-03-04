using DataAccessFakes;
using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Josh Jackson
    /// DATE: 02/07/2020
    /// Checked By: Ethan H, Gabi L
    /// This is a class file that holds the logic that passes volunteer record information from the Presentation layer to the Data Access layer
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Josh Jackson
    /// UPDATE DATE: 02/14/2020
    /// WHAT WAS CHANGED: Added GetVolunteerByName() method
    /// </remarks>
    public class VolunteerManager : IVolunteerManager
    {
        private IVolunteerAccessor _volunteerAccessor;

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H, Gabi L
        /// this is the default constructor
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        public VolunteerManager()
        {
            _volunteerAccessor = new VolunteerAccessor();
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H, Gabi L
        /// this contructor takes an IVolunteerObject object as an argument
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="volunteerAccessor"></param>
        /// </remarks>
        public VolunteerManager(IVolunteerAccessor volunteerAccessor)
        {
            _volunteerAccessor = volunteerAccessor;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// this method passes the volunteer record data to be added to the db from the presentation layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="volunteer"></param>
        /// </remarks>
        public bool AddVolunteer(Volunteer volunteer)
        {
            bool result = true;
            try
            {
                result = _volunteerAccessor.InsertVolunteer(volunteer) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Volunteer not added", ex);
            }
            return result;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/07/2020
        /// Checked By: Ethan H
        /// this method passes the skill data to the presentation layer from the data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// </remarks>
        public List<string> GetAllSkills()
        {
            List<string> roles = null;

            try
            {
                roles = _volunteerAccessor.SelectAllSkills();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Roles not found", ex);
            }

            return roles;
        }

        /// <summary>
        /// NAME: Josh Jackson
        /// DATE: 02/14/2020
        /// Checked By: Gabi L
        /// This method passes the first and last name of the searched for volunteer between presentation layer and data access layer
        /// </summary>
        /// <remarks>
        /// UPDATED BY:
        /// UPDATE DATE:
        /// WHAT WAS CHANGED: 
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// </remarks>
        public List<Volunteer> GetVolunteerByName(string firstName, string lastName)
        {
            try
            {
                return _volunteerAccessor.GetVolunteerByName(firstName, lastName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found", ex);
            }
        }

        /// <summary>
        /// Coded by Gabrielle Legrand
        /// 
        /// Checked By: Josh Jackson
        /// This is the Volunteer Manager method with logic for Retrieving the list of Volunteers by Active status
        /// 
        /// </summary>
        /// <param name="active"></param>
        /// <returns></returns>
        ///<remarks>
        /// UPDATED BY: 
        /// UPDATE DATE: 
        /// CHANGE DESCRIPTION:
        /// </remarks>

        public List<Volunteer> RetrieveVolunteerListByActive(bool active = true)
        {
            try
            {
                return _volunteerAccessor.SelectVolunteersByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }

        }
    }
}
