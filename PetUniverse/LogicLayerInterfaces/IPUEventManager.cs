using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// 
    /// NAME: Steve Coonrod
    /// DATE: 2020-02-06
    /// CHECKED BY: Ryan Morganti
    /// 
    /// The interface to manage the data from 
    /// the Data Access Layer for the Events
    /// 
    /// </summary>
    public interface IPUEventManager
    {
        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method takes an event and sends it through the EventAccessor
        /// To be added to the database. 
        /// 
        /// It returns the added events EventID
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="puEvent"></param>
        /// <returns></returns>
        int AddEvent(PUEvent puEvent);

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method sends an EventRequest to the EventAccessor class
        /// To be added to the DB. Returns the count of rows effected in the DB.
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventRequest"></param>
        /// <returns></returns>
        int AddEventRequest(EventRequest eventRequest);

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method sends a Request to the Event Accessor to be added to the DB
        /// Returns the added Request's new RequestID, or 0 if unsuccessful.
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        int AddRequest(Request request);

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method retrieves a List of all events in the DB
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <returns></returns>
        List<PUEvent> GetAllEvents();

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method returns the Event associated with the supplied EventID
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        PUEvent GetEventByID(int eventID);

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method returns a List of all Event Types in the DB
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <returns></returns>
        List<EventType> GetAllEventTypes();
    }
}
