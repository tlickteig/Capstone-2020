using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessInterfaces
{/// <summary>
 /// Creator: Rasha Mohammed
 /// Created: 4/1/2020
 /// Approver: Ethan Holmes
 /// 
 /// Interface for picture data accessor to facilitate loose coupling.
 /// </summary>
 /// <remarks>
 /// Updater:
 /// Updated: 
 /// Update: 
 /// 
 /// </remarks>
    public interface IPictureAccessor
    {
        /// <summary>
        /// CREATOR: Rasha Mohammed
        /// DATE: 4/1/2020
        /// APPROVER: Ethan Holmes
        ///
        /// Interface method signature for Selecting all picyures by ProductCategoryID
        ///
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>
        /// <returns>returns List of Picture</returns>
        //List<Picture> SelectAllPictureByProductCategoryID(string productCategoryID);

        List<Picture> SelectAllPicture();
    }
}
