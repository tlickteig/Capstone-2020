using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Alex Diers
    /// DATE: 2/6/2020
    /// CHECKED BY: Lane Sandburg
    /// 
    /// Interface for the Manager class
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATED DATE: NA
    /// WHAT WAS CHANGED: NA
    /// </remarks>
    public interface ITrainingVideoManager
    {
        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Jordan Lindo
        /// 
        /// Method for managing the creation of a TrainingVideo object
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        /// <param name="video"></param>
        /// <returns></returns>
        bool InsertTrainingVideo(TrainingVideo video);


        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Method for the retrieval of the TrainingVideos an Employee needs to view
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        List<TrainingVideo> RetrieveTrainingVideosByEmployee();

        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/13/2020
        /// CHECKED BY: Lane Sandburg
        /// 
        /// Method for the retrieval of the TrainingVideos an Employee needs to view
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        bool UpdateTrainingVideo(TrainingVideo oldVideo, TrainingVideo newVideo);
    }
}
