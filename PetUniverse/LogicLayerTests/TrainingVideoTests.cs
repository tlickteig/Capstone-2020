using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessFakes;
using DataTransferObjects;
using LogicLayer;
using DataAccessInterfaces;
using LogicLayerInterfaces;

namespace LogicLayerTests
{
    /// <summary>
    /// NAME: Alex Diers
    /// DATE: 2/6/2020
    /// CHECKED BY: Lane Sandburg
    /// 
    /// This class houses the actual tests for TrainingVideo
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATED DATE: NA
    /// WHAT WAS CHANGED: NA
    /// </remarks>
    [TestClass]
    public class TrainingVideoTests
    {
        private ITrainingVideoAccessor _trainingVideoAccessor;

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Constructor for the FakeTrainingVideoAccessor class
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        public TrainingVideoTests()
        {
            _trainingVideoAccessor = new FakeTrainingVideoAccessor();
        }


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Tests the creation of a TrainingVideo object
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerInsertVideoTest()
        {
            //Arrange
            TrainingVideo video = new TrainingVideo();
            video.TrainingVideoID = "A";
            video.RunTimeMinutes = 1;
            video.RunTimeSeconds = 1;
            video.Description = "A";
            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.InsertTrainingVideo(video);

            //Assert
            Assert.IsTrue(test);
        }



        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Tests the retrieval of the TrainingVideos an Employee needs to view
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerSelectVideosByEmployeeTest()
        {
            // arrange
            List<TrainingVideo> videos;
            ITrainingVideoManager videoManager = new TrainingVideoManager(_trainingVideoAccessor);

            // act
            videos = videoManager.RetrieveTrainingVideosByEmployee();

            // assert
            Assert.AreEqual(1, videos.Count);
        }

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Tests the retrieval of the TrainingVideos an Employee needs to view
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        [TestMethod]
        public void TrainingVideoManagerUpdateVideoTest()
        {
            //Arrange
            TrainingVideo oldVideo = new TrainingVideo();
            oldVideo.TrainingVideoID = "A";
            oldVideo.RunTimeMinutes = 1;
            oldVideo.RunTimeSeconds = 1;
            oldVideo.Description = "A";

            TrainingVideo newVideo = new TrainingVideo();
            newVideo.TrainingVideoID = "B";
            newVideo.RunTimeMinutes = 2;
            newVideo.RunTimeSeconds = 2;
            newVideo.Description = "B";

            bool test;
            ITrainingVideoManager trainingVideoManager = new TrainingVideoManager(_trainingVideoAccessor);

            //Act
            test = trainingVideoManager.UpdateTrainingVideo(oldVideo, newVideo);

            //Assert
            Assert.IsTrue(test);
        }
    }
}
