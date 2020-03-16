using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig    
    ///     DATE: 2020-02-09
    ///     CHECKED BY: 
    ///     Interface for medicine accessor classes
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public interface IMedicineAccessor
    {
        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="medicine">The medicine to enter</param>
        /// <returns>The number of rows affected</returns>
        int InsertMedicine(Medicine medicine);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="medicineID">The ID of the Medicine to delete</param>
        /// <returns>The number of rows affected</returns>
        int DeleteMedicine(int medicineID);

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-12
        ///     CHECKED BY: 
        /// </summary>        
        /// <returns>All Medicine records in the database</returns>
        List<Medicine> SelectAllMedicines();
    }
}
