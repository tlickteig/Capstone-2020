using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class TrainingVideo
    {
        /// <summary>
        /// NAME: Alex Diers
        /// DATE: 2/6/2020
        /// CHECKED BY: Jordan Lindo
        /// 
        /// This class defines the Transfer Objects for TrainingVideo
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATED DATE: NA
        /// WHAT WAS CHANGED: NA
        /// </remarks>
        public string TrainingVideoID { get; set; }
        public int RunTimeMinutes { get; set; }
        public int RunTimeSeconds { get; set; }
        public string Description { get; set; }
    }
}
