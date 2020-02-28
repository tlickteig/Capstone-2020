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
    /// NAME: Alex Diers
    /// DATE: 2/6/2020
    /// CHECKED BY: Lane Sandburg
    /// 
    /// This class manages the usage of the CRUD functions
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATED DATE: NA
    /// WHAT WAS CHANGED: NA
    /// </remarks>
    public class TrainingVideoManager : ITrainingVideoManager
    {
        private ITrainingVideoAccessor _trainingVideoAccessor;

        /// <summary>
        /// NAME : Alex Diers
        /// DATE: 2/20/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// No argument constructor
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// CHANGE: NA
        /// 
        /// </remarks>
        public TrainingVideoManager()
        {
            _trainingVideoAccessor = new TrainingVideoAccessor();
        }


        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Constructor for the TrainingVideoManager
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <param name="trainingVideoAccessor"></param>
        public TrainingVideoManager(ITrainingVideoAccessor trainingVideoAccessor)
        {
            _trainingVideoAccessor = trainingVideoAccessor;
        }



        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Jordan Lindo
        /// 
        /// Implementation of the InsertTrainingVideo method from the ITrainingVideoManager
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        public bool InsertTrainingVideo(TrainingVideo video)
        {
            bool result = true;
            try
            {
                result = _trainingVideoAccessor.InsertTrainingVideo(video) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Video not added", ex);
            }
            return result;
        }


        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Implementation of the RetrieveTrainingVideoManager method from the ITrainingVideoManager interface
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <returns></returns>
        public List<TrainingVideo> RetrieveTrainingVideosByEmployee()
        {
            try
            {
                return _trainingVideoAccessor.SelectTrainingVideosByEmployee();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Implementation of the RetrieveTrainingVideoManager method from the ITrainingVideoManager interface
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <returns></returns>
        public bool UpdateTrainingVideo(TrainingVideo oldVideo, TrainingVideo newVideo)
        {
            bool result = true;
            try
            {
                result = _trainingVideoAccessor.UpdateTrainingVideo(oldVideo, newVideo) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Update failed", ex);
            }
            return result;
        }
    }
}
