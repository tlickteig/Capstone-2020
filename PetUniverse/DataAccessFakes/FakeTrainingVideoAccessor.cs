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
                    Description = "A",
                    Active = true
                },
                new TrainingVideo()
                {
                    TrainingVideoID  = "B",
                    RunTimeMinutes = 1,
                    RunTimeSeconds = 1,
                    Description = "A",
                    Active = false
                }
            };
        }

        public int ActivateTrainingVideo(TrainingVideo videoID)
        {
            TrainingVideo trainingVideo = null;

            //Fail immediatly if null
            if (videoID == null)
            {
                throw new Exception();
            }

            //Check that video is in list, if so assign it, else fail
            foreach (var v in trainingVideos)
            {
                if (videoID.TrainingVideoID == v.TrainingVideoID)
                {
                    trainingVideo = v;
                }
            }

            //Throw exception if video isn't in list
            if (trainingVideo == null || videoID.TrainingVideoID != trainingVideo.TrainingVideoID)
            {
                throw new Exception();
            }

            //Activate it
            trainingVideo.Active = true;

            if (trainingVideo.Active == true)
            {
                return 1;
            }
            return 0;
        }

        public int DeactivateTrainingVideo(TrainingVideo videoID)
        {
            TrainingVideo trainingVideo = null;

            //Fail immediatly if null
            if (videoID == null)
            {
                throw new Exception();
            }

            //Check that video is in list, if so assign it, else fail
            foreach (var v in trainingVideos)
            {
                if (videoID.TrainingVideoID == v.TrainingVideoID)
                {
                    trainingVideo = v;
                }
            }

            //Throw exception if video isn't in list
            if (trainingVideo == null || videoID.TrainingVideoID != trainingVideo.TrainingVideoID)
            {
                throw new Exception();
            }

            //Deactivate it
            trainingVideo.Active = false;

            if (trainingVideo.Active == false)
            {
                return 1;
            }
            return 0;
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
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: 
        /// 
        /// Test finding videos based on active state
        /// </summary>
        ///
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<TrainingVideo> SelectTrainingVideosByActive(bool active = true)
        {
            List<TrainingVideo> newVideos = new List<TrainingVideo>();
            foreach (var video in trainingVideos)
            {
                if (video.Active == active)
                {
                    newVideos.Add(video);
                }
            }
            return newVideos;
        }

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Method tests viewing TrainingVideo objects by Employee
        /// </summary>
        /// <remarks>
        /// UPDATED BY: Chase Schulte
        /// UPDATED DATE: 03/01/2020
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        public List<TrainingVideo> SelectTrainingVideosByEmployee()
        {
            return (from t in trainingVideos
                    select t).ToList();
        }


        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: 
        /// 
        /// Method tests viewing TrainingVideo objects by Employee
        /// </summary>
        ///
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update: 
        /// </remarks>
        public int UpdateTrainingVideo(TrainingVideo oldVideo, TrainingVideo newVideo)
        {
            bool videoTrue
                = false;


            //Fail immediatly if null
            if (oldVideo == null)
            {
                throw new Exception();
            }

            //Check that eRole is in list, if so assign it, else fail
            foreach (var trainingVideo
                in trainingVideos)
            {
                if (oldVideo.TrainingVideoID == trainingVideo.TrainingVideoID && oldVideo.RunTimeSeconds == trainingVideo.RunTimeSeconds && oldVideo.RunTimeMinutes == trainingVideo.RunTimeMinutes && oldVideo.Description == trainingVideo.Description && trainingVideo != null)
                {
                    videoTrue = true;
                }

            }

            //Throw exception if eRole isn't in list
            if (videoTrue == false)
            {
                throw new Exception();
            }

            //Make sure PK remains the same
            if (oldVideo.TrainingVideoID != newVideo.TrainingVideoID)
            {
                throw new Exception();
            }

            //Make sure description isn't too long
            if (newVideo.Description != null && newVideo.Description.Length > 1000)
            {
                throw new Exception();
            }

            //Update old ERole to newVideo
            oldVideo = newVideo;

            //Make sure old eRole is updated
            if (oldVideo == newVideo)
            {
                return 1;
            }
            return 0;
        }
    }
}

