using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/29
    /// Approver:  Awaab Elamin, 2020/03/03
    ///
    /// This Class for creation a fake Adoption Applictions which will used 
    /// for testing Logic layer methodes.
    /// </summary>
    public class FakeAdoptionInterviewerAccessor : IAdoptionInterviewerAccessor
    {
        private List<AdoptionAppointment> adoptionAppointments = null;


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/03/03
        /// 
        /// This method will get fake Adoption Appliction when whenever it called. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <returns>fake Adoption Applications</returns>

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
                    Notes = "This is a my notes",
                    Decision = "facilitator",
                    LocationID =12033
                },

                new AdoptionAppointment()
                {
                    AppointmentID = 100002,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "Interviewer",
                    AppointmentDateTime = DateTime.Now,
                    Notes = "This is a my notes",
                    Decision = "Interviewer",
                    LocationID = 12033
                },
                new AdoptionAppointment()
                {
                    AppointmentID = 100003,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "facilitator",
                    AppointmentDateTime = DateTime.Now,
                    Notes = "This is a my notes",
                    Decision = "facilitator",
                    LocationID = 12033
                },
            };

        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/03/03
        /// 
        /// This fake method is called to get a fake list of Adoption Applictions. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
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
        /// Created: 2020/02/29
        /// Approver:  Awaab Elamin, 2020/03/03
        /// 
        /// This fake method is called to get a fake list of Adoption Applictions. 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="AdoptionAppointment"></param>
        /// <param name="AdoptionAppointment"></param>
        /// <returns>result</returns>
        public int UpdateAppoinment(AdoptionAppointment oldAdoptionAppointment, AdoptionAppointment newAdoptionAppointment)
        {
            int result = 0;
            foreach (AdoptionAppointment adoption in adoptionAppointments)
            {
                if(
                    (adoption.AppointmentID == oldAdoptionAppointment.AppointmentID)
                    && 
                    (adoption.Notes == oldAdoptionAppointment.Notes)
                   )

                {
                    adoption.Notes = newAdoptionAppointment.Notes;
                    result++;

                }
            }
            return result;
        }
    }
}
