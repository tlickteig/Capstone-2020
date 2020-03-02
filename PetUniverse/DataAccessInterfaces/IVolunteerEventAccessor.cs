using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Zoey McDonald
    /// DATE: 2/7/2020
    /// CHECKED BY: Ethan Holmes
    /// 
    /// This is an interface class for the volunteer event accessor
    /// 
    /// </summary>
    public interface IVolunteerEventAccessor
    {
        List<VolunteerEvent> SelectAllEvents();

        VolunteerEvent SelectEvent(int VolunteerEventID);

        int InsertVolunteerEvent(VolunteerEventVM volunteerEvent);

        int RemoveVolunteerEvent(int volunteerEventID);

        int UpdateVolunteerEvent(VolunteerEvent oldVolunteerEvent, VolunteerEvent newVolunteerEvent);
    }
}
