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
    }
}
