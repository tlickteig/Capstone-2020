using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/29
    /// Approver: Awaab Elamin, 2020/03/03
    ///
    /// This Class for main logic of Interviewer.
    /// </summary>
    public class AdoptionInterviewerManager : IAdoptionInterviewerManager
    {

        private IAdoptionInterviewerAccessor _adoptionInterviewerAccessor;

        public AdoptionInterviewerManager(IAdoptionInterviewerAccessor adoptionInterviewerAccessor)
        {
            _adoptionInterviewerAccessor = adoptionInterviewerAccessor;
        }


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/03/03
        /// 
        /// This is the Constructor method for InHome Inspection 
        /// Appointment Decision Manager
        /// 
        /// 
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <returns>Customer Name</returns>
        public AdoptionInterviewerManager()
        {
            _adoptionInterviewerAccessor = new AdoptionInterviewerAccessor();

        }
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/03/03
        /// 
        /// This method used to enter the Appointment notes during the interview.
        ///  
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        public bool EditAppointment(AdoptionAppointment oldAdoptionAppointment, AdoptionAppointment newAdoptionAppointment)
        {
            bool result = false;
            try
            {
                result = (1 == _adoptionInterviewerAccessor.UpdateAppoinment
                   (oldAdoptionAppointment, newAdoptionAppointment));

            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update failed.", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/29
        /// Approver: Awaab Elamin, 2020/03/03
        /// 
        /// This method select Appointments by the appointment type.
        ///  
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        public List<AdoptionAppointment> SelectAdoptionAappointmentsByAppointmentType()
        {
            List<AdoptionAppointment> adoptionApplications = null;
            try
            {
                adoptionApplications = _adoptionInterviewerAccessor.SelectAdoptionAappointmentsByAppointmentType();

            }
            catch (Exception ex)
            {

                throw new ApplicationException("List not found", ex);
            }

            return adoptionApplications;
        }
    }
}


