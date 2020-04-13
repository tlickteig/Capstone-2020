using DataAccessInterfaces;
using DataAccessLayer;
using DataTransferObjects;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    /// <summary>
    ///  Creator: Rasha Mohammed
    ///  Created: 4/1/2020
    ///  Approver: Ethan Holmes
    ///  
    ///  Manager Class for picture
    /// </summary>
    /// <remarks>
    /// Updater: NA
    /// Updated: NA
    /// Update: NA
    /// 
    /// </remarks>
    public class PictureManager : IPictureManager
    {
        private IPictureAccessor _pictureAccessor;

        /// <summary>
		///  Creator: Rasha Nohammed
		///  Created: 4/1/2020
		///  Approver: Ethan Holmes
		///  
		///  Default Constructor for instantiating Accessor
        ///  
		/// </summary>
		/// <remarks>
		/// Updater: NA
		/// Updated: NA
		/// Update: NA
		/// 
		/// </remarks>
		public PictureManager()
        {
            _pictureAccessor = new PictureAccessor();
        }

        /// <summary>
        ///  Creator: Rasha Mohammed
        ///  Created: 4/1/2020
        ///  Approver: Ethan Holmes
        ///  
        ///  Constructor for passing specific Accessor class
        ///  
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="pictureAccessor"></param>
        public PictureManager(IPictureAccessor pictureAccessor)
        {
            _pictureAccessor = pictureAccessor;
        }

        /// <summary>
        ///  Creator: Rasha Mohammed
        ///  Created: 4/1/2020
        ///  Approver: Ethan Holmes
        ///  
        ///  Method that retrieve all picture 
        ///  
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// 
        /// </remarks>
        /// <param name="pictureAccessor"></param>
        public List<Picture> RetrieveAllPictures()
        {
            List<Picture> result = null;
            try
            {

                result = _pictureAccessor.SelectAllPicture();


            }
            catch (Exception ex)
            {
                throw new ApplicationException("Data not found.", ex);

            }
            return result;
        }
    }
}
