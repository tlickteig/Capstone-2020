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
    /// Contains all the information needed for an adoption Application
    /// </summary>
    public class Application
    {
        public int AdoptionApplicationID { get; set; }
        public string CustomerEmail { get; set; }
        public int AnimalID { get; set; }
        public string Status { get; set; }
        public DateTime RecievedDate { get; set; }
        public bool ApplicationActive { get; set; }
    }
}
