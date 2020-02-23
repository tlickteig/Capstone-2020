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
    /// Creator: Chase Schutle
    /// Created: 2/7/2020
    /// Approver: Kaleb Bachert
    /// 
    /// Interface for ERoleManager
    /// </summary>
    /// <remarks>
    /// Updater: Chase Schulte
    /// Updated: 2/7/2020
    /// UPdate: Removed RetrieveByERoleID
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
