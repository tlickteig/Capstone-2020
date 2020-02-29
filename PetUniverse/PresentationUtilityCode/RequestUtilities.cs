using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;


namespace PresentationUtilityCode
{
    /// <summary>
    /// Creator: Ryan Morganti
    /// Created: 2020/02/13
    /// Approver: Derek Taylor
    /// 
    /// Utility Class used for filtering and aggregating collection data used within the Request system.
    /// </summary>
    public static class RequestUtilities
    {

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        /// 
        /// Method for determining whether a User is also an employee
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool IsEmployee(this PetUniverseUser user)
        {
            return (from r in user.PURoles
                    where r == "Employee"
                    select r).Any();
        }

        /// <summary>
        /// Creator: Ryan Morganti
        /// Created: 2020/02/13
        /// Approver: Derek Taylor
        /// 
        /// Extension Method for filtering out duplicate Requests when a User has two
        /// Department IDs that are associated with a single Request
        /// </summary>
        /// <remarks>
        /// Updator:
        /// Updated:
        /// Update:
        /// 
        /// </remarks>
        /// <param name="requests"></param>
        /// <returns></returns>
        public static List<DepartmentRequest> DistinctRequests(this List<DepartmentRequest> requests)
        {
            //This line of code was found when looking for a way to filter out duplicate requests
            //when multiple DepartmentIDs associated with a single user are associated to a single
            //request as well
            //https://stackoverflow.com/a/491832
            return requests.GroupBy(r => r.RequestID).Select(r => r.First()).ToList();
        }



    }
}
