using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WPFPresentation.Models
{
    public class UserWithShiftList
    {
        public List<ShiftVM> UserShiftList { get; set; }

        public int UserID { get; set; }
    }
}