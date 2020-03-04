using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Alex Diers
    /// DATE: 2/6/2020
    /// CHECKED BY: NA
    /// 
    /// This class is used for testing of the TrainingVideo object
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATED DATE: NA
    /// WHAT WAS CHANGED: NA
    /// </remarks>
    public class FakeTrainingVideoAccessor : ITrainingVideoAccessor
    {
        private List<TrainingVideo> trainingVideos;

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Creates a TrainingVideo object and adds it to the List for testing purposes
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        public FakeTrainingVideoAccessor()
        {
            trainingVideos = new List<TrainingVideo>
            {
                new TrainingVideo()
                {
                    TrainingVideoID  = "A",
                    RunTimeMinutes = 1,
                    RunTimeSeconds = 1,
                    Description = "A"
                }
            };
        }


        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Method to test the insertion of a TrainingVideo object
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        public int InsertTrainingVideo(TrainingVideo video)
        {
            TrainingVideo newVideo = new TrainingVideo();

            newVideo = video;

            try
            {
                trainingVideos.Add(newVideo);
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Method tests viewing TrainingVideo objects by Employee
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        public List<TrainingVideo> SelectTrainingVideosByEmployee()
        {
            return (from t in trainingVideos
                    select t).ToList();
        }

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Method tests viewing TrainingVideo objects by Employee
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        public int UpdateTrainingVideo(TrainingVideo oldVideo, TrainingVideo newVideo)
        {
            

            try
            {
                oldVideo = newVideo;
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }
    }
}
