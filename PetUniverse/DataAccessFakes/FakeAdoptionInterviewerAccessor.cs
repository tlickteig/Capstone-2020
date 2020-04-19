using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 02/29/2020
    /// Approver: Awaab Elamin 03/03/2020
    ///
    /// This Class is for creation of fake Adoption Applications which will be used 
    /// for testing Logic layer methods.
    /// </summary>
    public class FakeAdoptionInterviewerAccessor : IAdoptionInterviewerAccessor
    {

        private List<AdoptionAppointment> adoptionAppointments = null;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/19/2020
        /// Approver:  Awaab Elamin, 03/03/2020
        /// 
        /// This method will get a fake Adoption Application when whenever it called. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/9/2020
        /// Update: Fixed Comments and spelling errors
        /// </remarks>
        /// <param name=""></param>
        /// <returns>Fake Adoption Applications</returns>

        public FakeAdoptionInterviewerAccessor()
        {
            adoptionAppointments = new List<AdoptionAppointment>()
            {
                new AdoptionAppointment()
                {
                    AppointmentID = 100001,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "facilitator",
                    AppointmentDateTime =  DateTime.Now,
                    Notes = "These are my notes",
                    Decision = "facilitator",
                    LocationID =12033
                },

                new AdoptionAppointment()
                {
                    AppointmentID = 100002,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "Interviewer",
                    AppointmentDateTime = DateTime.Now,
                    Notes = "These are my notes",
                    Decision = "Interviewer",
                    LocationID = 12033
                },

                new AdoptionAppointment()
                {
                    AppointmentID = 100003,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "facilitator",
                    AppointmentDateTime = DateTime.Now,
                    Notes = "These are my notes",
                    Decision = "facilitator",
                    LocationID = 12033
                },
            };
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/29/2020
        /// Approver: Awaab Elamin, 03/03/2020
        /// 
        /// This fake method is called to get a fake list of Adoption Applications. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/9/2020
        /// Update: Fixed Comments and spelling errors
        /// </remarks>
        /// <param name=""></param>
        /// <returns>fake list of Adoption Applications</returns>
        public List<AdoptionAppointment> SelectAdoptionAappointmentsByAppointmentType()
        {
            List<AdoptionAppointment> _adoptionAppointments;
            _adoptionAppointments = (from b in adoptionAppointments
                                     where b.AppointmentTypeID == "Interviewer"
                                     select b).ToList();
            return _adoptionAppointments;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/29/2020
        /// Approver:  Awaab Elamin, 03/03/2020
        /// 
        /// This fake method is called to get a fake list of Adoption Applications. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater: Zach Behrensmeyer
        /// Updated: 4/9/2020
        /// Update: Fixed Comments, spelling errors, and formatting
        /// </remarks>
        /// <param name="AdoptionAppointment"></param>
        /// <param name="AdoptionAppointment"></param>
        /// <returns>result</returns>
        public int UpdateAppoinment(AdoptionAppointment oldAdoptionAppointment, AdoptionAppointment newAdoptionAppointment)
        {
            int result = 0;
            foreach (AdoptionAppointment adoption in adoptionAppointments)
            {
                if ((adoption.AppointmentID == oldAdoptionAppointment.AppointmentID)
                    && (adoption.Notes == oldAdoptionAppointment.Notes))
                {
                    adoption.Notes = newAdoptionAppointment.Notes;
                    result++;
                }
            }
            return result;
        }
    }
}
