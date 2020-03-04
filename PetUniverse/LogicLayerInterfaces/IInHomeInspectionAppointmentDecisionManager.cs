using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayerInterfaces;

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

    }
}
