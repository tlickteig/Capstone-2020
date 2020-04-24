using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    /// <summary>
    /// NAME: Steve Coonrod, Derek Taylor
    /// DATE: 2020-02-06
    /// CHECKED BY: Ryan Morganti
    ///  
    /// The PUEventmanager class that implements the IPUEventManager interface
    /// 
    /// Updated By:
    /// Updated On:
    /// 
    /// </summary>
    public class PUEventManager : IPUEventManager
    {
        private IEventAccessor _eventAccessor;

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The default constructor for an EventRequest
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        public PUEventManager()
        {
            _eventAccessor = new EventAccessor();
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The constructor for the EventManager
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventAccessor"></param>
        public PUEventManager(IEventAccessor eventAccessor)
        {
            _eventAccessor = eventAccessor;
        }

        /// <summary>
        /// NAME: Steve Coonrod, Derek Taylor
        /// DATE 2020-02-06
        /// CHECKED BY: Ryan Morganti 
        /// 
        /// The AddEvent method that attempt to add a new event.
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="puEvent"></param>
        /// <returns> bool result true if successful </returns>
        public int AddEvent(PUEvent puEvent)
        {
            int eventID = 0;
            try
            {
                eventID = _eventAccessor.InsertEvent(puEvent);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data Unavailable", ex);
            }
            return eventID;
        }


        /// <summary>
        /// 
        /// NAME: Steve Coonrod, Derek Taylor
        /// DATE 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The EditEvent method that attempts to edit an existing event.
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="oldEvent"></param>
        /// <param name="newEvent"></param>
        /// <returns></returns>
        public bool EditEvent(PUEvent oldEvent, PUEvent newEvent)
        {

            try
            {
                return _eventAccessor.UpdateEventDetails(oldEvent, newEvent);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data Unavailable", ex);
            }
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod, Derek Taylor
        /// DATE 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The DeleteEvent method that attempts to delete an existing event.
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public bool DeleteEvent(int eventID)
        {
            try
            {
                return _eventAccessor.DeleteEvent(eventID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Delete was unsucessful. \n", ex);
            }
        }


        /// <summary>
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// The AddEventRequest method that creates a request for 
        /// an event to be created
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventRequest"></param>
        /// <returns> int </returns>
        public int AddEventRequest(EventRequest eventRequest)
        {
            try
            {
                return _eventAccessor.InsertEventRequest(eventRequest);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data Unavailable", ex);
            }
        }

        /// <summary>
        /// NAME: Steve Coonrod, Derek Taylor
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti 
        /// 
        /// The AddRequest method that creates a request to be
        /// approved by a manager.
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns> int </returns>
        public int AddRequest(Request request)
        {
            try
            {
                return _eventAccessor.InsertRequest(request);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data Unavailable", ex);
            }
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method returns a List of all Events in the DB
        /// through the EventAccessor
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PUEvent> GetAllEvents()
        {
            try
            {
                return _eventAccessor.SelectEventsAll();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Event Type Data Unavailable", ex);
            }
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method returns a List of all Event Types in the DB
        /// through the EventAccessor
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <returns></returns>
        public List<EventType> GetAllEventTypes()
        {
            try
            {
                return _eventAccessor.SelectAllEventTypes();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Event Type Data Unavailable", ex);
            }

        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method returns the Event associated with the given eventID
        /// through the EventAccessor
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public PUEvent GetEventByID(int eventID)
        {
            try
            {
                return _eventAccessor.SelectEventByID(eventID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data Unavailable", ex);
            }
        }


        //===============================================================================\\


        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-03-01
        /// CHECKED BY:
        /// 
        /// This method returns a List of all Events pending approval
        /// from the DB through the EventAccessor
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PUEvent> GetEventsByStatus(string status)
        {
            try
            {
                return _eventAccessor.SelectEventsByStatus(status);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Event Data Unavailable", ex);
            }
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-03-04
        /// CHECKED BY: 
        /// 
        /// This method returns the Event associated with the given eventID
        /// through the EventAccessor
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="EventID"></param>
        /// <param name="CreatedByID"></param>
        /// <returns></returns>
        public EventApprovalVM GetEventApprovalVM(int EventID, int CreatedByID)
        {
            EventApprovalVM retrievedEventVM;
            try
            {
                retrievedEventVM = _eventAccessor.SelectEventApprovalVM(EventID, CreatedByID);
                return retrievedEventVM;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Event View Model Unavailable", ex);
            }
        }

        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 3/15/2020
        /// Checked By:
        /// 
        /// The method used to retrieve an Event's Request by the EventID
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public EventRequest GetEventRequestByEventID(int eventID)
        {
            try
            {
                return _eventAccessor.SelectEventRequestByEventID(eventID);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Event Request Data Unavailable", ex);
            }
        }

        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 3/15/2020
        /// Checked By:
        /// 
        /// The method used to update an Event Request
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="oldEventRequest"></param>
        /// <param name="newEventRequest"></param>
        /// <returns></returns>
        public bool UpdateEventRequest(EventRequest oldEventRequest, EventRequest newEventRequest)
        {
            try
            {
                return _eventAccessor.UpdateEventRequest(oldEventRequest, newEventRequest);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update the event Request.\n" + ex.Message);
            }
        }

        /// <summary>
        /// 
        /// Created By: Steve Coonrod
        /// Date: 3/15/2020
        /// Checked By:
        /// 
        /// The method used to Update the Status of an Event
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool UpdateEventStatus(int eventID, string status)
        {
            try
            {
                return _eventAccessor.UpdateEventStatus(eventID, status);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to update the event status.\n" + ex.Message);
            }
        }


    }
}
