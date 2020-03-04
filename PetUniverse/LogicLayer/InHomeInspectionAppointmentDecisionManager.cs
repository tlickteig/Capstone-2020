using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver:  Awaab Elamin, 2020/02/21
    ///
    /// This Class for creating  the properties of Home Inspector Adoption Appointment Decision.
    /// </summary>
    public class InHomeInspectionAppointmentDecisionManager : IInHomeInspectionAppointmentDecisionManager
    {
        private IInHomeInspectionAppointmentDecisionAccessor _inHomeInspectionAppointmentDecisionAccessor;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
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
        public InHomeInspectionAppointmentDecisionManager()
        {
            _inHomeInspectionAppointmentDecisionAccessor = new InHomeInspectionAppointmentDecisionAccessor();
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
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
        public InHomeInspectionAppointmentDecisionManager(IInHomeInspectionAppointmentDecisionAccessor inHomeInspectionAppointmentDecisionAccessor)
        {
            _inHomeInspectionAppointmentDecisionAccessor = inHomeInspectionAppointmentDecisionAccessor;

        }

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
        public bool EditAppointment(HomeInspectorAdoptionAppointmentDecision oldHomeInspectorAdoptionAppointmentDecision,
            HomeInspectorAdoptionAppointmentDecision newHomeInspectorAdoptionAppointmentDecision)
        {
            bool result = false;
            try
            {
                result = (1 == _inHomeInspectionAppointmentDecisionAccessor.UpdateAppoinment
                    (oldHomeInspectorAdoptionAppointmentDecision, newHomeInspectorAdoptionAppointmentDecision));
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Update failed.", ex);
            }
            return result;
           
        }

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

        public List<HomeInspectorAdoptionAppointmentDecision> SelectAdoptionApplicationsAappointmentsByAppointmentType()
        {
            List<HomeInspectorAdoptionAppointmentDecision> inHomeInspectionAppointmentDecision = null;
            try
            {
                inHomeInspectionAppointmentDecision = _inHomeInspectionAppointmentDecisionAccessor.
                    SelectAdoptionApplicationsAappointmentsByAppointmentType();
            }
            catch (Exception ex)
            {

                throw new ApplicationException("List not found",ex);
            }

            return inHomeInspectionAppointmentDecision;
        }

     
    }
}
