using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Zach Behrensmeyer
    /// Created: 03/16/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// Interface that defines method for user manager
    /// </summary>
    public interface IMessagesManager
    {

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona 
        ///
        /// Retrieves Departments like provided text
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <param name="Input"></param>
        /// <returns></returns>
        List<string> RetrieveDepartmentsLikeInput(string Input);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        ///
        /// Retrieves users like provided text
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <param name="Input"></param>
        /// <returns></returns>
        List<string> GetUsersLikeInput(string Input);

        /// <summary>
        /// Creator: Zach Behrensmeyer
        /// Created: 03/16/2020
        /// Approver: Steven Cardona
        ///
        /// Inserts messages
        /// </summary>
        /// <remarks>        
        /// Updater: NA
        /// Update: NA
        /// Approver: NA
        /// </remarks>
        /// <param name="content"></param>
        /// <param name="subject"></param>
        /// <param name="senderID"></param>
        /// <param name="recieverID"></param>
        /// <returns></returns>
        bool sendEmail(string content, string subject, int senderID, int recieverID);        
    }
}
