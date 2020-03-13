using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;


namespace LogicLayer
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/10/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class contains the methods that will bring data from the database and present
    /// it to the presentation layer.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class AdoptionAppointmentManager : IAdoptionAppointmentManager
    {
        
        
        IAdoptionAppointmentAccessor _adoptionAppointmentAccessor;

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/10/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This is the no-argument constructor for this class. This will be the constructor
        /// that will typically be used.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public AdoptionAppointmentManager()
        {
            _adoptionAppointmentAccessor = new AdoptionAppointmentAccessor();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/10/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This is the full constructor. It will be used for unit testing purposes
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="adoptionAppointmentAccessor"></param>
        public AdoptionAppointmentManager(IAdoptionAppointmentAccessor adoptionAppointmentAccessor)
        {
            _adoptionAppointmentAccessor = adoptionAppointmentAccessor;
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/4/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// Gets an Adoption AppointmentVM by AppointmentID
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        public AdoptionAppointmentVM RetrieveAdoptionAppointmentByAppointmentID(int appointmentID)
        {
            
            try
            {
                return _adoptionAppointmentAccessor.SelectAdoptionAppointmentByAppointmentID(appointmentID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 2/10/2020
        /// CHECKED BY: Thomas Dupuy
        /// 
        /// This method will get a list of AdoptionAppointmentVM's from the data access layer and send
        /// them up to the presentation layer.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <returns>adoptionAppointmentVMs</returns>
        public List<AdoptionAppointmentVM> RetrieveAdoptionAppointmentsByActiveAndType(bool active, String typeID)
        {
            List<AdoptionAppointmentVM> adoptionAppointmentVMs = new List<AdoptionAppointmentVM>();
            try
            {
                adoptionAppointmentVMs = _adoptionAppointmentAccessor.SelectAdoptionAppointmentsByActiveAndType(active = true, typeID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return adoptionAppointmentVMs;
        }
    }
}
