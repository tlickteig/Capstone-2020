using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    /// <summary>
    /// 
    /// NAME: Steve Coonrod, Derek Taylor
    /// DATE: 2020-02-06
    /// CHECKED BY: Ryan Morganti
    /// 
    /// EventAccessor class that implements IEventAccessor
    /// Manages the operations with the database
    /// 
    /// Updated By:
    /// Updated On:
    /// 
    /// </summary>
    public class EventAccessor : IEventAccessor
    {
        /// <summary>
        /// NAME: Steve Coonrod, Matt Deaton
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This InsertEvent method is used to access data through a stored 
        /// procedure sp_insert_event in the database
        /// 
        /// It returns the new Event's EventID
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="puEvent"></param>
        /// <returns> int eventID </returns>
        public int InsertEvent(PUEvent puEvent)//Got rid of userCreatedID
        {
            int eventID = 0;
            //Connection
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_event");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters
            cmd.Parameters.Add("@CreatedByID", SqlDbType.Int);
            cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime);
            cmd.Parameters.Add("@EventName", SqlDbType.NVarChar, 150);
            cmd.Parameters.Add("@EventTypeID", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@EventDateTime", SqlDbType.DateTime);
            cmd.Parameters.Add("@EventAddress", SqlDbType.NVarChar, 200);
            cmd.Parameters.Add("@EventCity", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@EventState", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@EventZipcode", SqlDbType.NVarChar, 15);
            cmd.Parameters.Add("@EventPictureFileName", SqlDbType.NVarChar, 250);
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 500);

            //Values
            cmd.Parameters["@CreatedByID"].Value = puEvent.CreatedByID;
            cmd.Parameters["@DateCreated"].Value = puEvent.DateCreated;
            cmd.Parameters["@EventName"].Value = puEvent.EventName;
            cmd.Parameters["@EventTypeID"].Value = puEvent.EventTypeID;
            cmd.Parameters["@EventDateTime"].Value = puEvent.EventDateTime;
            cmd.Parameters["@EventAddress"].Value = puEvent.Address;
            cmd.Parameters["@EventCity"].Value = puEvent.City;
            cmd.Parameters["@EventState"].Value = puEvent.State;
            cmd.Parameters["@EventZipcode"].Value = puEvent.Zipcode;
            cmd.Parameters["@EventPictureFileName"].Value = puEvent.BannerPath;
            cmd.Parameters["@Status"].Value = puEvent.Status;
            cmd.Parameters["@Description"].Value = puEvent.Description;

            try
            {
                conn.Open();
                eventID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return eventID;
        }

        /// <summary>
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This InsertEventRequest method is used to access data through a stored 
        /// procedure sp_insert_event_request in the database
        /// 
        /// It returns the rows effected
        /// 
        /// </summary>
        /// <param name="eventRequest"></param>
        /// <returns >int rowsEffected </returns>
        public int InsertEventRequest(EventRequest eventRequest)
        {
            int rowsEffected = 0;
            //Connection
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_event_request");
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters
            cmd.Parameters.Add("@EventID", SqlDbType.Int);
            cmd.Parameters.Add("@RequestID", SqlDbType.Int);
            cmd.Parameters.Add("@ReviewerID", SqlDbType.Int);
            cmd.Parameters.Add("@DisapprovalReason", SqlDbType.NVarChar, 500);
            cmd.Parameters.Add("@DesiredVolunteers", SqlDbType.Int);
            cmd.Parameters.Add("@Active", SqlDbType.Bit);

            //Values
            cmd.Parameters["@EventID"].Value = eventRequest.EventID;
            cmd.Parameters["@RequestID"].Value = eventRequest.RequestID;
            cmd.Parameters["@ReviewerID"].Value = eventRequest.ReviewerID;
            cmd.Parameters["@DisapprovalReason"].Value = eventRequest.DisapprovalReason;
            cmd.Parameters["@DesiredVolunteers"].Value = eventRequest.DesiredVolunteers;
            cmd.Parameters["@Active"].Value = eventRequest.Active;

            try
            {
                conn.Open();
                rowsEffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return rowsEffected;
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This InsertRequest method is used to access data through a stored 
        /// procedure sp_insert_event_request in the database
        /// 
        /// It returns the new Request's RequestID
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns> int requestID </returns>
        public int InsertRequest(Request request)
        {
            int requestID = 0;
            //Connection
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_insert_request", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            //Parameters
            cmd.Parameters.Add("@DateCreated", SqlDbType.DateTime);
            cmd.Parameters.Add("@RequestTypeID", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@RequestID", SqlDbType.Int).Direction = ParameterDirection.Output;

            //Values
            cmd.Parameters["@DateCreated"].Value = request.DateCreated;
            cmd.Parameters["@RequestTypeID"].Value = request.RequestTypeID;

            try
            {
                conn.Open();
                cmd.ExecuteScalar();
                requestID = (int)cmd.Parameters["@RequestID"].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return requestID;
        }

        /// <summary>
        /// 
        /// /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This is a helper method that calls the stored procedure sp_select_all_event_types
        /// 
        /// It returns the full list of all Event Types in the database
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <returns></returns>
        public List<EventType> SelectAllEventTypes()
        {
            List<EventType> eventTypes = new List<EventType>();

            //Connection
            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_all_event_types", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EventType selectedEventType = new EventType();
                        selectedEventType.EventTypeID = reader.GetString(0);
                        selectedEventType.Description = reader.GetString(1);
                        eventTypes.Add(selectedEventType);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return eventTypes;
        }


        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-09
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This SelectEventByID method is used to access data through a stored 
        /// procedure sp_select_Event_by_ID in the database
        /// 
        /// It returns the Event associated with the given EventID
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns> Event event </returns>
        public PUEvent SelectEventByID(int eventID)
        {
            PUEvent retrievedEvent = new PUEvent();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_event_by_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EventID", eventID);

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        retrievedEvent.EventID = eventID;
                        retrievedEvent.CreatedByID = reader.GetInt32(0);
                        retrievedEvent.DateCreated = reader.GetDateTime(1);
                        retrievedEvent.EventName = reader.GetString(2);
                        retrievedEvent.EventTypeID = reader.GetString(3);
                        retrievedEvent.EventDateTime = reader.GetDateTime(4);
                        retrievedEvent.Address = reader.GetString(5);
                        retrievedEvent.City = reader.GetString(6);
                        retrievedEvent.State = reader.GetString(7);
                        retrievedEvent.Zipcode = reader.GetString(8);
                        retrievedEvent.BannerPath = reader.GetString(9);
                        retrievedEvent.Status = reader.GetString(10);
                        retrievedEvent.Description = reader.GetString(11);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return retrievedEvent;
        }

        /// <summary>
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-09
        /// CHECKED BY: Ryan Morganti
        /// 
        /// This method calls the stored procedure sp_select_all_events
        /// 
        /// It returns a full list of all Events in the DB
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        /// <returns></returns>
        public List<PUEvent> SelectEventsAll()
        {
            List<PUEvent> retrievedEvents = new List<PUEvent>();

            var conn = DBConnection.GetConnection();

            var cmd = new SqlCommand("sp_select_all_events", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        PUEvent retrievedEvent = new PUEvent();

                        retrievedEvent.EventID = reader.GetInt32(0);
                        retrievedEvent.CreatedByID = reader.GetInt32(1);
                        retrievedEvent.DateCreated = reader.GetDateTime(2);
                        retrievedEvent.EventName = reader.GetString(3);
                        retrievedEvent.EventTypeID = reader.GetString(4);
                        retrievedEvent.EventDateTime = reader.GetDateTime(5);
                        retrievedEvent.Address = reader.GetString(6);
                        retrievedEvent.City = reader.GetString(7);
                        retrievedEvent.State = reader.GetString(8);
                        retrievedEvent.Zipcode = reader.GetString(9);
                        retrievedEvent.BannerPath = reader.GetString(10);
                        retrievedEvent.Status = reader.GetString(11);
                        retrievedEvent.Description = reader.GetString(12);

                        retrievedEvents.Add(retrievedEvent);
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return retrievedEvents;
        }// End SelectAllEvents()
    }
}
