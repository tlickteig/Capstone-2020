using System;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicLayerTests
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig
    ///     DATE: 2020-02-05
    ///     CHECKED BY: Zoey McDonald
    ///     Test class for the VolunteerShiftManager class
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    [TestClass]
    public class VolunteerShiftTests
    {
        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-05
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager AddVolunteerShift method
        /// </summary>        
        [TestMethod]
        public void TestVolunteerShiftManagerAddsNewShift()
        {
            //Arrange
            IVolunteerShiftManager manager = new VolunteerShiftManager();

            //Act
            int rows = manager.AddVolunteerShift(new VolunteerShift()
            {
                VolunteerShiftID = 100,
                VolunteerID = 1,
                ShiftTitle = "The Shift",
                IsSpecialEvent = false,
                VolunteerShiftDate = DateTime.Now,
                ScheduleID = 100,
                ShiftNotes = "This shift is cool",
                VolunteerTaskID = 100,
                Recurrance = "None",
                ShiftDescription = "This is a cool shift",
                ShiftStartTime = TimeSpan.Zero,
                ShiftEndTime = TimeSpan.Zero + TimeSpan.Parse("00:06:00:00")
            });

            //Assert
            Assert.AreEqual(1, rows);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-08
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager RemoveVolunteerShift method
        /// </summary>
        [TestMethod]
        public void TestVolunteerShiftManagerRemoveAnExistingShift()
        {
            //Arrange
            IVolunteerShiftManager manager = new VolunteerShiftManager();

            //Act            
            int rows = manager.RemoveVolunteerShift(2);

            //Assert
            Assert.AreEqual(1, rows);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-08
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager RemoveVolunteerShift method
        /// </summary>
        [TestMethod]
        public void TestVolunteerShiftManagerRemoveNonExistingShift()
        {
            //Arrange
            IVolunteerShiftManager manager = new VolunteerShiftManager();

            //Act            
            int rows = manager.RemoveVolunteerShift(1000);

            //Assert
            Assert.AreEqual(0, rows);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-10
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager EditVolunteerShift method
        /// </summary>
        [TestMethod]
        public void TestVolunteerShiftManagerEditAShiftRecord()
        {
            //Arrange
            IVolunteerShiftManager manager = new VolunteerShiftManager();

            //Act            
            int rows = manager.EditVolunteerShift(
                new VolunteerShift()
                {
                    VolunteerShiftID = 1
                },
                new VolunteerShift()
                {
                    VolunteerShiftID = 1,
                    ShiftDescription = "Hello World!",
                    VolunteerShiftDate = DateTime.Now,
                    ShiftTitle = "This is the title",
                    ShiftStartTime = TimeSpan.Zero,
                    ShiftEndTime = TimeSpan.Zero,
                    Recurrance = "None",
                    IsSpecialEvent = true,
                    ShiftNotes = "These are the notes2",
                    ScheduleID = 0
                }
                );

            //Assert
            Assert.AreEqual(1, rows);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-02-17
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for the VolunteerShiftManager ReturnAllVolunteerShifts method
        /// </summary>
        [TestMethod]
        public void TestVolunteerShiftManagerReturnAllVolunteerShifts()
        {
            IVolunteerShiftManager manager = new VolunteerShiftManager();

            manager.AddVolunteerShift(new VolunteerShift()
            {
                VolunteerID = 0,
                VolunteerShiftID = 0,
                ShiftTitle = "Pretty dope shift",
                IsSpecialEvent = true,
                VolunteerShiftDate = DateTime.Now,
                ScheduleID = 0,
                ShiftNotes = "Some things to note",
                VolunteerTaskID = 0,
                Recurrance = "Weekly",
                ShiftDescription = "Something descriptive",
                ShiftStartTime = TimeSpan.Zero,
                ShiftEndTime = TimeSpan.Zero
            });
            manager.AddVolunteerShift(new VolunteerShift()
            {
                VolunteerID = 0,
                VolunteerShiftID = 0,
                ShiftTitle = "Even cooler shift",
                IsSpecialEvent = false,
                VolunteerShiftDate = DateTime.Now,
                ScheduleID = 0,
                ShiftNotes = "Some other things to note",
                VolunteerTaskID = 0,
                Recurrance = "Daily",
                ShiftDescription = "Something more descriptive",
                ShiftStartTime = TimeSpan.Zero,
                ShiftEndTime = TimeSpan.Zero
            });

            int count = manager.ReturnAllVolunteerShifts().Count;

            Assert.AreEqual(true, count > 1);
        }
    }
}
