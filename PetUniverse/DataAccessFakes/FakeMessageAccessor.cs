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
    /// Creator: Zach
    /// Created: 03/16/2020
    /// Approver: Steven Cardona
    /// 
    /// Data Access Fake for Accessing Messages
    /// </summary>
    public class FakeMessageAccessor : IMessagesAccessor
    {
        private List<string> _departments = new List<string>();
        private List<string> _users = new List<string>();

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Constructor for FakeMessageAccessor
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>                 
        public FakeMessageAccessor()
        {
            _departments.Add("Test1");
            _users.Add("Test1");
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Fake logic to get departments like provided text
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>   
        public List<string> GetDepartmentsLikeInput(string Input)
        {
            List<string> emptyList = new List<string>(); 
            if (Input != null)
            {
                
                return _departments;
            }
            else
            {
                return emptyList;
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Fake logic to get users like provided text
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks>  
        public List<string> GetUsersLikeInput(string Input)
        {
            List<string> emptyList = new List<string>();
            if (Input != null)
            {
                return _users;
            }
            else
            {
                return emptyList;
            }
        }

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        /// 
        /// Fake logic to Send Email
        /// </summary>
        /// <remarks>
        /// Updater: NA
        /// Updated: NA
        /// Update: NA
        /// </remarks> 
        public bool sendEmail(string content, string subject, int senderID, int recieverID)
        {
            if (content != "" && subject != "" && senderID != 0 && recieverID != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
