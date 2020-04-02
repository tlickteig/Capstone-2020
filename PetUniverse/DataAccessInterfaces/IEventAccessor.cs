using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// 
    /// NAME: Steve Coonrod, Derek Taylor
    /// DATE: 2020-02-06
    /// CHECKED BY: Ryan Morganti
    /// 
    /// The interface to access data from the DTOs
    /// for the Events
    /// 
    /// </summary>
    public interface IEventAccessor
    {

        /// <summary>
        /// 
        /// Created By: Steve Coonrod, Matt Deaton
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// The interface method for Adding an Event
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="puEvent"></param>
        /// <returns></returns>
        int InsertEvent(PUEvent puEvent);//Took out createdByID parameter...

        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// The interface method for Editing an Event
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="oldEvent"></param>
        /// <param name="newEvent"></param>
        /// <returns></returns>
        bool UpdateEventDetails(PUEvent oldEvent, PUEvent newEvent);

        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// The interface method for Deleting an Event
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
        /// /// Created By: Steve Coonrod
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// The interface method for Inserting A Request
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        int InsertRequest(Request request);

        /// <summary>
        /// 
        /// /// Created By: Steve Coonrod
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// The interface method for Inserting an eventRequest
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventRequest"></param>
        /// <returns></returns>
        int InsertEventRequest(EventRequest eventRequest);

        /// <summary>
        /// 
        /// /// Created By: Steve Coonrod
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// The interface method for Selecting an event by its EventID
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        PUEvent SelectEventByID(int eventID);

        /// <summary>
        /// Created By: Steve Coonrod
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// The interface method for Selecting all events
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <returns></returns>
        List<PUEvent> SelectEventsAll();

        /// <summary>
        /// Created By: Steve Coonrod
        /// Date: 2/10/2020
        /// Checked By:
        /// 
        /// The interface method for Selecting all event types
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <returns></returns>
        List<EventType> SelectAllEventTypes();

        //=============================================================================\\


        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 3/08/2020
        /// Checked By:
        /// 
        /// The interface method for Selecting an Event Approval View Model
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="createdByID"></param>
        /// <returns></returns>
        EventApprovalVM SelectEventApprovalVM(int eventID, int createdByID);

        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 3/10/2020
        /// Checked By:
        /// 
        /// The interface method for Selecting an Event Request by the Event's ID
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        EventRequest SelectEventRequestByEventID(int eventID);

        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 3/10/2020
        /// Checked By:
        /// 
        /// The interface method for Updating an Event Request
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
        /// The interface method for Selecting a List of Events by the Status
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        List<PUEvent> SelectEventsByStatus(string status);

        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 3/15/2020
        /// Checked By:
        /// 
        /// The interface method for Updating an Event's Status
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
