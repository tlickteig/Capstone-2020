using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
	/// Creator: Chase Schulte
	/// Created: 2020/02/05
	/// Approver
	///
	/// Interface for eRoleDataAccessor
	/// </summary>
    public interface IERoleAccessor
    {
        int InsertERole(ERole eRole);
        List<ERole> SelectAllERoles();
        int UpdateERole(ERole oldERole, ERole newERole);
        int DeleteERole(string eRoleID);
        int DeactivateERole(string eRoleID);
        int ActivateERole(string eRoleID);
        List<ERole> SelectAllERolesByActive(bool active = true);
    }
}
