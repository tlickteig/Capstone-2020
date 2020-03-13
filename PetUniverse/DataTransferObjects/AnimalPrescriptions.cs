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
    public class AnimalPrescriptions
    {
        public int AnimalPrescriptionID { get; set; }
        public int AnimalID { get; set; }
        public string AnimalName { get; set; }
        public int AnimalVetAppointmentID { get; set; }
        public string PrescriptionName { get; set; }
        public decimal Dosage { get; set; }
        public string Interval { get; set; }
        public string AdministrationMethod { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
