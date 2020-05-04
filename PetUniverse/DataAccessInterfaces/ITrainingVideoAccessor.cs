using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Alex Diers
    /// Created: 2/6/2020
    /// Approver: Jordan Lindo
    /// 
    /// Interface for the video accessor
    /// </summary>
    public interface ITrainingVideoAccessor
    {

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/6/2020
        /// Approver: Jordan Lindo
        /// 
        /// used for the creation of a TrainingVideo object
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        int InsertTrainingVideo(TrainingVideo video);


        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/13/2020
        /// Approver: Lane Sangburg
        /// 
        /// Used to select a list of TrainingVideo objects by Employee that needs to view them
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        List<TrainingVideo> SelectTrainingVideosByEmployee();

        /// <summary>
        /// Creator: Alex Diers
        /// Created: 2/13/2020
        /// Approver: Lane Sangburg
        /// 
        /// Used to update a TrainingVideo object that needs to be changed
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        int UpdateTrainingVideo(TrainingVideo oldVideo, TrainingVideo newVideo);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Activate a video
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="videoID"></param>
        /// <returns></returns>
        int DeactivateTrainingVideo(TrainingVideo video);

        /// <summary>
        /// Creator: Chase Schulte
        /// Created: 03/01/2020
        /// Approver: Jordan Lindo
        /// 
        /// Activate a video
        /// </summary>
        /// <remarks>
        /// Updater 
        /// Updated:
        /// Update: 
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        int ActivateTrainingVideo(TrainingVideo video);

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
        List<TrainingVideo> SelectTrainingVideosByActive(bool active = true);
        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Used to select a list of TrainingVideo objects by Employee that needs to view them
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        List<TrainingVideoVM> SelectTrainingVideosByEmployee(bool watched = false);

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 3/15/2020
        /// CHECKED BY: Chase Schulte
        /// 
        /// Used to change the record of a video being watched 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <param name="isWatched"></param>
        /// <returns></returns>
        int UpdateIsWatched(TrainingVideoVM videoVM);

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 3/15/2020
        /// CHECKED BY: Chase Schulte
        /// 
        /// Used to change the record of a video not being watched 
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <param name="isWatched"></param>
        /// <returns></returns>
        int UpdateNotWatched(TrainingVideoVM videoVM);
    }
}