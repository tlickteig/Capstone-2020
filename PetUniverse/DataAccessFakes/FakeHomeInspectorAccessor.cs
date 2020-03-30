using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using DataAccessFakes;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2/5/2020
    /// Approver: Austin Gee, 2/7/2020
    ///
    /// This Class for creation a fake Adoption Applictions which will used 
    /// for testing Logic layer methodes.
    /// </summary>
    public class FakeAdoptionApplicationAccessor : IHomeInspectorAccessor
    {
        private List<AdoptionApplication> adoptionApplications = null;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
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
        public FakeAdoptionApplicationAccessor()
        {
            adoptionApplications = new List<AdoptionApplication>()
            {
                new AdoptionApplication()
                {
                AdoptionApplicationID = 10001,
                CustomerEmail = "Romaine",
                AnimalName = "Pepe",
                Status = "inHomeInspection",
                RecievedDate = DateTime.Now,
                
                },
                  new AdoptionApplication()
                  {
                  AdoptionApplicationID = 10002,
                  CustomerEmail = "Jarvis",
                  AnimalName = "Pete",
                  Status = "facilitator",
                  RecievedDate = DateTime.Now
                  },
                    new AdoptionApplication()
                    {
                    AdoptionApplicationID = 10007,
                    CustomerEmail = "Jane",
                    AnimalName = "Kadeeesa",
                    Status = "inHomeInspection",
                    RecievedDate = DateTime.Now
                    },
            };
        }
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
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
        List<AdoptionApplication> IHomeInspectorAccessor.SelectAdoptionApplicationsByStatus()
        {
            List<AdoptionApplication> _adoptionApplications;
            _adoptionApplications = (from AdoptionApplication in adoptionApplications
                                     where AdoptionApplication.Status == "inHomeInspection"
                                     select AdoptionApplication).ToList();
            return _adoptionApplications;
        }
    }
}
