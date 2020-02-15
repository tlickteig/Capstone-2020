using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataTransferObjects;
using DataAccessFakes;
using LogicLayerInterfaces;
using LogicLayer;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME : Zach Behrensmeyer
    /// DATE: 2/11/2020
    /// CHECKED BY: Steven Cardona
    /// 
    /// This class tests the LogManager Class
    /// </summary>
    [TestClass]
    public class LogManagerTests
    {  
        private FakeLogAccessor _fakeLogAccessor;
        private ILogManager _logManager;


        /// <summary>
        /// CREATOR: Zach Behrensmeyer
        /// DATE: 02/15/2020
        /// APPROVER: Steven Cardona
        /// Setup for tests to run
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        ///     UPDATE: N/A
        /// APPROVER: N/A
        /// </remarks>
        [TestInitialize]
        public void TestSetup()
        {
            _fakeLogAccessor = new FakeLogAccessor();
            _logManager = new LogManager(_fakeLogAccessor);
        }


        /// <summary>
        /// NAME: Zach Behrensmeyer
        /// DATE: 2/11/2020
        /// CHECKED BY: Steven Cardona
        /// 
        /// This Method is test for the RetrieveLoginandOutLogs() method
        /// 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>    
        [TestMethod]
        public void TestRetrieveListOfLoginandOutLogs()
        {
            //Arrange
            List<LogItem> _logs;
            //Act
            _logs = _logManager.RetrieveLoginandOutLogs();
            //Assert                                   
            Assert.AreEqual(1, _logs.Count);
        }

        /// <summary>
        /// CREATOR: Zach Behrensmeyer
        /// DATE: 02/15/2020
        /// APPROVER: Steven Cardona
        /// Method to reset all variable for next test run.
        /// </summary>
        /// <remarks>
        /// UPDATED BY: N/A
        /// UPDATED N/A
        ///     UPDATE: N/A
        /// APPROVER: N/A
        /// </remarks>
        [TestCleanup]
        public void TestTearDown()
        {
            _fakeLogAccessor = null;
            _logManager = null;            
        }
    }
}
