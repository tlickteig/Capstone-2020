using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Rasha Mohammed
    /// Created: 4/1/2020
    /// Approver: Ethan Holmes
    /// 
    /// Holds data relevant to a Picture.
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public class Picture
    {

        public int PictureID { get; set; }

        public string ProductID { get; set; }

        public string ImagePath { get; set; }
    }
}
