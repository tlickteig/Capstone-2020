using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;


namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver:  Awaab Elamin, 2020/02/21
    ///
    /// This interface for accessing Adoption Applications data.
    /// </summary>
    public interface IInHomeInspectionAppointmentDecisionAccessor
    {
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:  Awaab Elamin, 2020/02/21
        /// 
        /// This method used to get Adoption Applications Aappointments ByAppointmen
        ///  tType
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
        /// Approver:  Awaab Elamin, 2020/02/21
        /// 
        /// This method used to update an Adoptin Appliction decision.
        /// ID.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        int UpdateAppoinment(HomeInspectorAdoptionAppointmentDecision 
            oldHomeInspectorAdoptionAppointmentDecision, 
            HomeInspectorAdoptionAppointmentDecision newHomeInspectorAdoptionAppointmentDecision);


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/02/19
        /// Approved By:  Awaab Elamin, 2020/02/21
        /// 
        /// This method gets the Customer email from the user table by Adoption
        /// Application ID.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationID"></param>
        /// <param name="decision"></param>
        int UpdateHomeInspectorDecision(int adoptionApplicationID, string decision);



        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created On: 2020/02/19
        /// Approved By:  Awaab Elamin, 2020/02/21
        /// 
        /// This method gets the Customer email from the user table by Adoption
        /// Application ID.
        /// 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name="adoptionApplicationId"></param>
        string GetCustomerEmailByAdoptionApplicationID(int adoptionApplicationId);
    }
}
