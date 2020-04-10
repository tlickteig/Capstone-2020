using DataAccessInterfaces;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Rasha Mohammed
    /// Created: 4/8/2020
    /// Approver: Ethan Holmes
    /// 
    /// Fake picture accessor for testing purposes.
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public class FakePictureAccessor : IPictureAccessor
    {
        private List<Picture> pictures;

        /// <summary>
        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/8/2020
        /// Approver: Ethan Holmes
        /// 
        /// Sets up fake data for testing purposes.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public FakePictureAccessor()
        {
            pictures = new List<Picture>()
            {
                new Picture()
                {
                    PictureID = 1,
                    ProductID = "1234567890120",
                    ImagePath = "pic1",
                },
                new Picture()
                {
                    PictureID = 2,
                    ProductID = "1234567890120",
                    ImagePath = "pic2",
                }
            };
        }

        /// <summary>
        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/8/2020
        /// Approver: Ethan Holmes
        /// 
        /// Fake Pictures Accessor Method, return list of pictures for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<Picture> SelectAllPicture()
        {
            return pictures;
        }


    }
}
