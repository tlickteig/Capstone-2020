using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using DataAccessFakes;
using DataAccessLayer;
using DataAccessInterfaces;
using DataTransferObjects;
using LogicLayerInterfaces;

namespace LogicLayerTests
{
    /// <summary>
    /// Creator: Mohamed Elamin
    /// Created: 2020/02/19
    /// Approver: Awaab Elamin, 2020/02/21
    /// 
    ///
    /// This Class for testing all public methods in the In-home Inspection Appointment
    /// Decision Manager class.
    ///
    /// </summary>
    [TestClass]
    public class InHomeInspectionAppointmentDecisionManagerTests
   {
        private IInHomeInspectionAppointmentDecisionAccessor _fakeInHomeInspectionAppointmentDecisionAccessor;
        private InHomeInspectionAppointmentDecisionManager _inHomeInspectionAppointmentDecisionManager;

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver:Awaab Elamin, 2020/02/21
        /// 
        /// This is the Setup for tests.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeInHomeInspectionAppointmentDecisionAccessor = new FakeInHomeInspectionAppointmentDecisionAccessor();
            _inHomeInspectionAppointmentDecisionManager = new InHomeInspectionAppointmentDecisionManager
                (_fakeInHomeInspectionAppointmentDecisionAccessor);
        }


        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This is the test for Select Select Adoption Applications Aappointments
        /// By Appointment Type method.
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>

        [TestMethod]
        public void TestSelectAdoptionApplicationsAappointmentsByAppointmentType()
        {
            // Arrange
            List<HomeInspectorAdoptionAppointmentDecision> SelectAdoptionApplicationsAappointmentsByAppointmentType;
            //Act
            SelectAdoptionApplicationsAappointmentsByAppointmentType = _inHomeInspectionAppointmentDecisionManager.
                SelectAdoptionApplicationsAappointmentsByAppointmentType();
            // Assert
            Assert.AreEqual(2, SelectAdoptionApplicationsAappointmentsByAppointmentType.Count);
        }

        /// <summary>
        /// Creator: Mohamed Elamin
        /// Created: 2020/02/19
        /// Approver: Awaab Elamin, 2020/02/21
        /// 
        /// This is the test for Edit Appointment of Adoption Applications 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: ()
        /// </remarks>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        [TestMethod]
        public void TestEditAppointment()
        {
            bool expected = true;
            bool result;
            HomeInspectorAdoptionAppointmentDecision oldHomeInspectorAdoptionAppointmentDecision
                = new HomeInspectorAdoptionAppointmentDecision() {
                    AppointmentID = 100001,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "facilitator",
                    DateTime = DateTime.Now,
                    Notes = "This is a my notes",
                    Decision = "facilitator",
                    LocationID = 12033,
                    Active = true
                };
            HomeInspectorAdoptionAppointmentDecision newHomeInspectorAdoptionAppointmentDecision
                = new HomeInspectorAdoptionAppointmentDecision() {
                    AppointmentID = 100001,
                    AdoptionApplicationID = 100001,
                    AppointmentTypeID = "facilitator",
                    DateTime = DateTime.Now,
                    Notes = "This is a my notes",
                    Decision = "Deny",
                    LocationID = 12033,
                    Active = true
                };
            result = _inHomeInspectionAppointmentDecisionManager.EditAppointment
                    (oldHomeInspectorAdoptionAppointmentDecision,
                    newHomeInspectorAdoptionAppointmentDecision);

            Assert.AreEqual(expected,result);

        }
    }
}
