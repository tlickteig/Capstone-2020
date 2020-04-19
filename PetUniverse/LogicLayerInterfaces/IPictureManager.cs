using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// CREATOR: Rasha Mohammed
    /// DATE: 04/1/2020
    /// APPROVER: Ethan Holmes
    /// 
    /// Interface outlines the requirements for the Picture Manager class.
    /// </summary>
    /// <remarks>
    public interface IPictureManager
    {
        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// DATE: 04/1/2020
        /// APPROVER: Ethan Holmes
        /// 
        /// Interface to retrieve all pictures.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        List<Picture> RetrieveAllPictures();
    }
}
