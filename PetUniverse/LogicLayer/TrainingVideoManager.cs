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

        public bool ActivateTrainingVideo(TrainingVideo video)
        {
            bool result = true;
            try
            {
                result = _trainingVideoAccessor.ActivateTrainingVideo(video) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Video not activate", ex);
            }
            return result;
        }

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 2020/02/05
        /// Approver: Jordan Lindo
        /// 
        /// Deactivate a Training Video
        /// </summary>
        ///
        /// <remarks>
        /// Updater: 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        public bool DeactivateTrainingVideo(TrainingVideo video)
        {
            bool result = true;
            try
            {
                result = _trainingVideoAccessor.DeactivateTrainingVideo(video) > 0;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Video not deactivated", ex);
            }
            return result;
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
        public bool EditTrainingVideo(TrainingVideo oldVideo, TrainingVideo newVideo)
        {
            bool result = false;
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
        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/03/2020
        /// Approver: Jordan Lindo
        /// 
        /// Find videos based on active state
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="active"></param>
        /// <returns></returns>
        public List<TrainingVideo> RetrieveTrainingVideosByActive(bool active = true)
        {
            try
            {
                return _trainingVideoAccessor.SelectTrainingVideosByActive(active);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);
            }
        }
    }
}
