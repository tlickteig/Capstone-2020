using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTransferObjects;
using DataAccessInterfaces;
using DataAccessFakes;
using LogicLayer;
using LogicLayerInterfaces;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Thomas Dupuy
    /// Created: 02/06/2020
    /// Approver: Awaab Elamin
    /// 
    /// This test class is used to test the data layer
    /// </summary>
    [TestClass]
    public class AppointmentManagerTest
    {
        private IAppointmentAccessor _appointmentAccessor;

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 02/06/2020
        /// Approver: Awaab Elamin
        /// 
        /// This method is a no-argument constructor
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        public AppointmentManagerTest()
        {
            _appointmentAccessor = new FakeAppointmentAccessor();
        }

        /// <summary>
        /// Creator: Thomas Dupuy
        /// Created: 02/06/2020
        /// Approver: Awaab Elamin
        /// 
        /// This test method is used to test the data layer
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:  
        /// Update: 
        /// </remarks>
        [TestMethod]
        public void TestAppointmentRetrieves()
        {
            // arrange
            List<Appointment> appointments;
            IAppointmentManager appointmentManager = new AppointmentManager(_appointmentAccessor);

            // act
            appointments = appointmentManager.RetrieveAllAppointments();

            // assert
            Assert.AreEqual(2, appointments.Count);
        }
    }
}
