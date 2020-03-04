using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Josh Jackson
    /// DATE: 02/07/2020
    /// Checked By: Gabi L, Ethan H
    /// This is an inteface for Volunteer logic methods
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Josh Jackson
    /// UPDATE DATE: 02/14/2020
    /// WHAT WAS CHANGED: Added GetVolunteerByName() method definition
    /// </remarks>
    public interface IVolunteerManager
    {
        bool AddVolunteer(Volunteer volunteer);
        List<string> GetAllSkills();
        List<Volunteer> GetVolunteerByName(string firstName, string lastName);
        List<Volunteer> RetrieveVolunteerListByActive(bool active = true);

    }
}
