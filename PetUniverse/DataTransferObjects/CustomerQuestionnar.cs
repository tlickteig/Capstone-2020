using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    /// <summary>
    ///   matchin the customer Qestionnair
    /// </summary>
    /// <remarks>
    /// by Awaab Elamin 2/5/2020
    /// Mohamed Elamin , 2/21/2020
    /// </remarks>
    public class CustomerQuestionnar
    {
        public int QuestionID { get; set; }
        public int CustomerID { get; set; }
        public int AdoptionApplication { get; set; }
        public string Answer { get; set; }
    }
}
