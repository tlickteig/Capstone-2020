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
    }
}
