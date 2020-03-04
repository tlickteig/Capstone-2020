using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
	/// Creator: Chase Schulte
	/// Created: 2020/02/05
	/// Approver: Kaleb Bachert
	///
	/// properties for a Role
	/// </summary>
    public class ERole
    {
        public string ERoleID { get; set; }
        public string EDepartmentID { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
