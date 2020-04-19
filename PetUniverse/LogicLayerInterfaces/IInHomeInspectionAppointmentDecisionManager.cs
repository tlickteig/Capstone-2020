using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Awaab Elamin, 2020/02/21
    ///
    /// This Class for creating  the properties of Home Inspector Adoption Appointment Decision.
    /// </summary>

    public interface IInHomeInspectionAppointmentDecisionManager
    {
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This method used to get Adoption Applications Aappointments By Appointmen
        ///  type.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        List<HomeInspectorAdoptionAppointmentDecision> SelectAdoptionApplicationsAappointmentsByAppointmentType();

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This method used to updates the Applications Aappointment Decision and
        ///  the in-home Inspector's notes.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        bool EditAppointment(HomeInspectorAdoptionAppointmentDecision
            oldHomeInspectorAdoptionAppointmentDecision, HomeInspectorAdoptionAppointmentDecision
            newHomeInspectorAdoptionAppointmentDecision);


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 02/19/2020
        /// Approved: Awaab Elamin, 02/21/2020
        /// 
        /// This method gets the Customer email by Adoption Application ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        string GetCustomerEmailByAdoptionApplicationID(int adoptionApplicationID);



        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/03/10
        /// Approved By: Awaab Elamin 03/13/2020
        /// 
        /// This method gets the Customer email by Adoption Application ID
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <param name="decision"></param>
        bool UpdateHomeInspectorDecision(int adoptionApplicationID, string decision);

    }
}
