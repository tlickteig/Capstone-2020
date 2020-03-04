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
    /// Created: 2020/02/19
    /// Approver:  Awaab Elamin, 2020/02/21
    ///
    /// This Class for creation a fake Adoption Applictions which will used 
    /// for testing Logic layer methodes.
    /// </summary>
    public class FakeInHomeInspectionAppointmentDecisionAccessor : IInHomeInspectionAppointmentDecisionAccessor
    {
        private List<HomeInspectorAdoptionAppointmentDecision> inHomeInspectionAppointmentDecisions = null;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21
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
        public FakeInHomeInspectionAppointmentDecisionAccessor()
        {
            inHomeInspectionAppointmentDecisions =new List<HomeInspectorAdoptionAppointmentDecision>()
            {
                new HomeInspectorAdoptionAppointmentDecision()
                {
                    AppointmentID = 100001,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "facilitator",
                    DateTime = DateTime.Now,
                    Notes = "This is a my notes",
                    Decision = "facilitator",
                    LocationID =12033,
                    Active = true
                },

                new HomeInspectorAdoptionAppointmentDecision()
                {
                    AppointmentID = 100002,
                    AdoptionApplicationID = 100002,
                    AppointmentTypeID = "inHomeInspection",
                    DateTime = DateTime.Now,
                    Notes = "This is a my notes",
                    Decision = "profiler",
                    LocationID =1000029,
                    Active = true


                },
                new HomeInspectorAdoptionAppointmentDecision()
                {
                    AppointmentID = 100003,
                    AdoptionApplicationID = 100003,
                    AppointmentTypeID = "inHomeInspection",
                    DateTime = DateTime.Now,
                    Notes = "This is a my notes",
                    Decision = "profiler",
                    LocationID =1000029,
                    Active = true
                },
            };
        }


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:
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
        public List<HomeInspectorAdoptionAppointmentDecision> SelectAdoptionApplicationsAappointmentsByAppointmentType()
        {
            List<HomeInspectorAdoptionAppointmentDecision> _inHomeInspectionAppointmentDecision;
            _inHomeInspectionAppointmentDecision = (from InHomeInspectionAppointmentDecision in inHomeInspectionAppointmentDecisions
                                                    where InHomeInspectionAppointmentDecision.AppointmentTypeID == "inHomeInspection"
                                                   select InHomeInspectionAppointmentDecision).ToList();
            return _inHomeInspectionAppointmentDecision;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21
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



        int IInHomeInspectionAppointmentDecisionAccessor.UpdateAppoinment(HomeInspectorAdoptionAppointmentDecision oldHomeInspectorAdoptionAppointmentDecision,
            HomeInspectorAdoptionAppointmentDecision newHomeInspectorAdoptionAppointmentDecision)
        {
            int result = 0;
            foreach (HomeInspectorAdoptionAppointmentDecision HomeInspectorAdoptionAppointmentDecision in inHomeInspectionAppointmentDecisions)
            {
                if (
                    (HomeInspectorAdoptionAppointmentDecision.AdoptionApplicationID == oldHomeInspectorAdoptionAppointmentDecision.AdoptionApplicationID)
                    &&
                    (HomeInspectorAdoptionAppointmentDecision.AppointmentID == oldHomeInspectorAdoptionAppointmentDecision.AppointmentID)
                    &&
                    (HomeInspectorAdoptionAppointmentDecision.Decision == oldHomeInspectorAdoptionAppointmentDecision.Decision)
                    )
                {
                    HomeInspectorAdoptionAppointmentDecision.Decision = newHomeInspectorAdoptionAppointmentDecision.Decision;
                    result++;
                }
            }
            return result;
        }
    }
}
