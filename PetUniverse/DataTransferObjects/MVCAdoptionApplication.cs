using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataTransferObjects
{
    public class MVCAdoptionApplication
    {
        [Required]
        public int AdoptionApplicationID { get; set; }
        [Required]
        public string CustomerEmail { get; set; }
        [Required]
        public int AnimalID { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public DateTime RecievedDate { get; set; }
        [Required]
        public List<CustomerQuestionnar> qusetionnair { get; set; }
    }
}
