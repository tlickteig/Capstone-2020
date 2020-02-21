using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using DataAccessLayer;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2/5/2020
    /// Approver: Austin Gee, 2/7/2020
    ///
    /// This Class manage HomeInspector logic, and implements the 
    /// IHomeInspectorManager Interface
    /// </summary>
    public class HomeInspectorManager : IHomeInspectorManager
    {
        private IHomeInspectorAccessor _homeInspectorAccessor;
        public HomeInspectorManager()
        {
            _homeInspectorAccessor = new HomeInspectorAccessor();
        }
        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// 
        /// This method is a constructor for the HomeInspectorManager 
        /// Manager.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=" IHomeInspectorAccessor"></param>
        /// <param name=" homeInspectorAccessor"></param>
        /// <returns></returns>
        public HomeInspectorManager(IHomeInspectorAccessor homeInspectorAccessor)
        {
            _homeInspectorAccessor = homeInspectorAccessor;
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2/5/2020
        /// Approver: Austin Gee, 2/7/2020
        /// 
        /// This method for getting Adoption Applications by thier status, and 
        /// return a list of the Adoption Applications or throws an exception.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns>adoption Applications list</returns>

        public List<AdoptionApplication> SelectAdoptionApplicationByStatus()
        {
            List<AdoptionApplication> adoptionApplications = null;
            try
            {
                adoptionApplications = _homeInspectorAccessor.SelectAdoptionApplicationsByStatus();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("List not Found", ex);
            }

            return adoptionApplications;
        }
    }
}
