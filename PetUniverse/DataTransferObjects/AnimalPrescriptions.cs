using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Ethan Murphy
    /// Created: 2/16/2020
    /// Approver: Carl Davis 2/21/2020
    /// Approver:
    /// 
    /// A data object for animal prescription records
    /// </summary>
    public class AnimalPrescription
    {
        public int AnimalPrescriptionID { get; set; }
        public int AnimalID { get; set; }
        public int AnimalVetAppointmentID { get; set; }
    }
}
