using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAM Austin Gee
    /// DATE: 2/17/2020
    /// CHECKED BY: Thomas Dupuy
    /// 
    /// This class contains the inteface methods for Adoption appointments
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public interface IAdoptionAppointmentManager
    {
        List<AdoptionAppointmentVM> RetrieveAdoptionApplicationsByActiveAndType(bool active, string appointmentTypeID);
    }
}



