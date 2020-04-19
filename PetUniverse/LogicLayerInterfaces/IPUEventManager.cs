using DataTransferObjects;
using System.Collections.Generic;

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
        /// CHECKED BY: 
        /// 
        /// This method takes an event and sends it through the EventAccessor
        /// To be edited in the database. 
        /// 
        /// It returns true if the edit was successful
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="oldEvent"></param>
        /// <param name="newEvent"></param>
        /// <returns></returns>
        bool EditEvent(PUEvent oldEvent, PUEvent newEvent);

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: 
        /// 
        /// This method takes an event and sends it through the EventAccessor
        /// To be deleted from the database. 
        /// 
        /// It returns true if the delete was successful
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        bool DeleteEvent(int eventID);


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

        //=========================================================================\\

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-03-01
        /// CHECKED BY:
        /// 
        /// This method retrieves a List of all events 
        /// which have the specified Status
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <returns></returns>
        List<PUEvent> GetEventsByStatus(string status);

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-03-04
        /// CHECKED BY: 
        /// 
        /// This method returns the Event View Model associated with the given eventID
        /// through the EventAccessor
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="EventID"></param>
        /// <param name="CreatedByID"></param>
        /// <returns></returns>
        EventApprovalVM GetEventApprovalVM(int EventID, int CreatedByID);

        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 3/15/2020
        /// Checked By:
        /// 
        /// The event manager method for Selecting an Event Request associated with the specified EventD
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        EventRequest GetEventRequestByEventID(int eventID);

        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 3/15/2020
        /// Checked By:
        /// 
        /// The event manager method for Updating an Event Request
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="oldEventRequest"></param>
        /// <param name="newEventRequest"></param>
        /// <returns></returns>
        bool UpdateEventRequest(EventRequest oldEventRequest, EventRequest newEventRequest);

        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 3/15/2020
        /// Checked By:
        /// 
        /// A method to Update an Event's Status to the status specified
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        bool UpdateEventStatus(int eventID, string status);


    }
}
