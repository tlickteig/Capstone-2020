using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;


namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Zoey McDonald
    /// DATE: 2/7/2020
    /// CHECKED BY: Ethan Holmes
    /// 
    /// This interface is used for the Volunteer Manager to work with volunteer events.
    /// 
    /// </summary>
    /// <remarks>
    /// UPDATED BY: N/A
    /// UPDATED DATE: N/A
    /// WHAT WAS CHANGED: N/A
    /// </remarks>
    public interface IVolunteerEventManager
    {
        int InsertVolunteerEvent(VolunteerEventVM volunteerEvent);

        int RemoveVolunteerEvent(int volunteerEventID);

        int UpdateVolunteerEvent(VolunteerEvent oldVolunteerEvent, VolunteerEvent newVolunteerEvent);

        List<VolunteerEvent> ReturnAllVolunteerEvents();
    }
}
