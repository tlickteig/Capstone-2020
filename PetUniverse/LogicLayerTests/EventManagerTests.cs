using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;
using DataAccessFakes;
using LogicLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Derek Taylor
    /// DATE: 2020-02-06
    /// CHECKED BY: Ryan Morganti 
    ///
    /// The EventManagerTests class that allows testing of the 
    /// classes and methods used for event handling.
    /// 
    /// </summary>
    [TestClass]
    public class EventManagerTests
    {
        private IEventAccessor _fakeEventAccessor;
        private PUEventManager _eventManager;

        [TestInitialize]
        public void TestSetup()
        {
            _fakeEventAccessor = new FakeEventAccessor();
            _eventManager = new PUEventManager(_fakeEventAccessor);
        }


        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for all GOOD values
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        public void TestAddEventGood()
        {
            // Arrange
            bool successful = false;

            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "3873 M Ave",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            int eventID = _eventManager.AddEvent(mockEvent);
            // Act
            if (eventID == 1)
            {
                successful = true;
            }

            // Assert
            Assert.IsTrue(successful);
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Name value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Name must be at least 8 characters.")]
        public void TestAddEventNameTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "",//This is what will throw an exception
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(3),
                Address = "3873 M Ave",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Name value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Name is too long.")]
        public void TestAddEventNameTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "This is the name of the event, it is not going to make sense. It's only" +
                " purpose is to be far too long to be a name for an event, and therefore not allowed in the system." +
                "Im not going to count but I think that should be long enough.",//This is what will throw an exception
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(3),
                Address = "3873 M Ave",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Date value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Date is too close. Must be 14 days or more.")]
        public void TestAddEventDateTooClose()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(3),//This is what will throw an exception
                Address = "3873 M Ave",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Address value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Address is too short")]
        public void TestAddEventAddressTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "",//This is what will throw an exception
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Address value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event Address is too long.")]
        public void TestAddEventAddressTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "This is the name of the event, it is not going to make sense. It's only" +
                " purpose is to be far too long to be a name for an event, and therefore not allowed in the system." +
                "Im not going to count but I think that should be long enough.",//This is what will throw an exception
                City = "Arnsdale",
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event City value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event City is too short.")]
        public void TestAddEventCityTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "242 A Street",
                City = "",//This is what will throw an exception
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event City value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event City is too long.")]
        public void TestAddEventCityTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "sdkljfksdlafkldsflksdagflksdgflksdagfklgsdfklgsdlkfgsdlkfglksadgflksdgflksdagflksdg",//This is what will throw an exception
                State = "IA",
                Zipcode = "52339",
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Zipcode value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event zipcode is too short.")]
        public void TestAddEventZipcodeTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "",//This is what will throw an exception
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Zipcode value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event zipcode is too long.")]
        public void TestAddEventZipcodeTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363636334353",//This is what will throw an exception
                BannerPath = "default.jpg",
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Picture File Name value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event picture file name is too short.")]
        public void TestAddEventPictureFileNameTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363",
                BannerPath = ".jpg",//This is what will throw an exception
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Picture File Name value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event picture file name is too long.")]
        public void TestAddEventPictureFileNameTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363",
                BannerPath = "welrjkhwelkjhrlkwehrkljwehrklwehrklewhkrlhweklrhweklrhweklhrwekljhrklj" +
                "wehrkljwehrkljwehrkjwehrkhweklrhwklehrklwehrklwehrkljhwekrlhweklrhweklhrklwe" +
                "hrklewjhrkljwehrkwehrklwehrkewhrkjewhrklwehrkwehrklhwekrhweklrhwek" +
                "lhrkwejhrkwehrkwehrkwekfbekfewklbvkwebivcubegfbrelkbgferbgfidsgiddefault.jpg",//This is what will throw an exception
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Picture File Name value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event picture file name is missing its extension.")]
        public void TestAddEventPictureFileNameMissingExtension()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363",
                BannerPath = "billy",//This is what will throw an exception
                Status = "PendingApproval",
                Description = "Super awesome fun with animals"
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Description value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event description is too short.")]
        public void TestAddEventDescriptionTooShort()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363",
                BannerPath = "billy.jpg",
                Status = "PendingApproval",
                Description = ""//This is what will throw an exception
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the AddEvent methods
        /// 
        /// This is the test for a BAD Event Description value
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ApplicationException),
            "The Event description is too long.")]
        public void TestAddEventDescriptionTooLong()
        {
            // Arrange
            PUEvent mockEvent = new PUEvent
            {
                CreatedByID = 1000000,
                DateCreated = DateTime.Now,
                EventName = "Billys Playpen",
                EventTypeID = "Fundraiser",
                EventDateTime = DateTime.Now.AddDays(32),
                Address = "343 A Street",
                City = "Arnsdale",
                State = "IA",
                Zipcode = "36363",
                BannerPath = "billy.jpg",
                Status = "PendingApproval",
                Description = "ksadjlfhlksdjhfklsdhflksdhklfjhsdlkjfhdsklfhlksdhfkljdshfksdhfksdhfklhsdlkfjhsdkfhsdf" +
                "sdlkfhsdlkfhklsdjhfkljsdhfkljsdhfkjhsdkfhsdkjfhklsjdhfkjdlshfkjsdhfkjsdhfkljdshfkjldshfklhsdkfhkdlsjhfkljdshfkljhsdkfjhdsklfhds'sd" +
                "sdkjalfhsdaklfhsdkljfhsdjfhksdlhfkljsdajhfkljsdhfkjlsdhfksdhfklhsdkljfhklsdhfkljsdhfklsdhfkljsdhfklhsdklfhdskhfkdsjfhksdjhflkdsjfhsd" +
                "sdlkjfhkljdshfksdjhfksdjhfkjsdhfjlkefbelauafbrliusbfaursbfcireusbgfidsbfciurvbfiudsbgkljsdbfkjldsbflkjsdbfkjlsdbfkjldsbfkbsdklbfkdsjbf" +
                "sdkljbfkljsdbgfgbdskbgsdkbfkjsdbfkjsdbkfjbdskljfbksjldbfkdsjbfkjdsbfkjsdbfkjbdskfbdskbfkljdsbffdsakjfblksdajbfkljsdbfkjsdbfkjlbsdklfjbdas" +
                "sdjkjfbdlsakjbfkjsdfvkjcwre laubfdskjbfwerbfvdskjfberfn owjdsfnsdjfbnsd jkacsbdfnjdsbgfksdjgbkjsdbgkjsdbkgjbsdksdjlkfhsdkhfklsdaf" +
                "kjgjjgjhghghgjhghsdgfkjsdgfvbsdbfhsdbf hsdkfb kjsd bfksdlj fdsjkfh sdlkjfhkjldsh flksjd hfkjldsh fkjlsdh hflkjsdaghflivurfvbdslvkjds f" +
                "osjdfh lkjsdhf ojsdhfoiu5h6asd4h 98aohfvo9werusda8fh4v65dsh45" +
                "9298uhjfhjgdfhyukdulkgf2"//This is what will throw an exception
            };

            //Act
            int eventID = _eventManager.AddEvent(mockEvent);
            //Assert
            //Should throw an exception
        }

        //====================================== End of Insert Event Tests ===========================================\\


        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the SelectAllEvents method
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        public void TestSelectAllEvents()
        {
            //Arrange
            List<PUEvent> selectedEvents;
            //Act
            selectedEvents = _eventManager.GetAllEvents();
            //Assert
            Assert.AreEqual(4, selectedEvents.Count);

        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-28
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the SelectAllEventTypes method
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        public void TestSelectAllEventTypes()
        {
            //Arrange
            List<EventType> eventTypes;
            //Act
            eventTypes = _eventManager.GetAllEventTypes();
            //Assert
            Assert.AreEqual(4, eventTypes.Count);
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-28
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the InsertRequest method
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        public void TestInsertRequest()
        {
            //Arrange
            Request newRequest = new Request()
            {
                DateCreated = DateTime.Now,
                RequestTypeID = "Event",
                RequestingUserID = 1000000
            };
            //Act
            int requestID = _eventManager.AddRequest(newRequest);
            //Assert
            Assert.AreEqual(1, requestID);
        }

        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-28
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the InsertEventRequest method
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        public void TestInsertEventRequest()
        {
            //Arrange
            EventRequest newEventRequest = new EventRequest()
            {
                EventID = 1000006,
                RequestID = 1000006,
                ReviewerID = 1000027,
                DisapprovalReason = null,
                DesiredVolunteers = 5,
                Active = true
            };
            //Act
            int rowsEffected = _eventManager.AddEventRequest(newEventRequest);
            //Assert
            Assert.AreEqual(1, rowsEffected);
        }



        /// <summary>
        /// 
        /// NAME: Steve Coonrod
        /// DATE: 2020-02-06
        /// CHECKED BY: Ryan Morganti
        /// 
        /// A test method for testing the GetEventByID method
        /// 
        /// Updated By:
        /// Updated On:
        /// 
        /// </summary>
        [TestMethod]
        public void TestGetEventByID()
        {
            int _eventID = 1000000;
            //Arrange
            PUEvent selectedEvent;
            //Action
            selectedEvent = _eventManager.GetEventByID(_eventID);
            //Assert
            Assert.IsNotNull(selectedEvent);
        }


        [TestCleanup]
        public void TestTearDown()
        {
            _fakeEventAccessor = null;
            _eventManager = null;
        }
    }

}
