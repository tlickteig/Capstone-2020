using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/18/2020
    /// CHECKED BY: 
    /// 
    /// Data transfer object that represents ApplicationVMs
    /// data access methods
    /// </summary>
    public class ApplicationVM : Application
    {
        public string AnimalName { get; set; }
        public string AnimalSpeciesID { get; set; }
        public string AnimalBreed { get; set; }
        public bool AnimalActive { get; set; }
    }
}
