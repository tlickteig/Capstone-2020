using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// <summary>
    /// NAME: Chase Schutle
    /// DATE: 2/7/2020
    /// CHECKED BY: N/A
    /// 
    /// Interface for ERoleManager
    /// </summary>
    /// <remarks>
    /// UPDATED BY: Chase Schulte
    /// UPDATE DATE: 2/7/2020
    /// WHAT WAS CHAGED: Removed RetrieveByERoleID
    /// 
    /// </remarks>
    /// </summary>
    public interface IERoleManager
    {
        bool AddERole(ERole eRole);
        List<ERole> RetrieveAllERoles();
        bool EditERole(ERole oldERole, ERole newERole);
        bool DeleteERole(string eRoleID);
        bool DeactivateERole(string eRoleID);
        bool ActivateERole(string eRoleID);
        List<ERole> RetrieveERolesByActive(bool active = true);
    }
}
