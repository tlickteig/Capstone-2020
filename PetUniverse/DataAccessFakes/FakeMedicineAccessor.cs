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
    ///     AUTHOR: Timothy Lickteig    
    ///     DATE: 2020-02-09
    ///     CHECKED BY: Zoey McDonald
    ///     Class for emulating an actual data access class for viewing medicine
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    public class FakeMedicineAccessor : IMedicineAccessor
    {
        private List<Medicine> _medicineList = new List<Medicine>()
        {
            new Medicine()
            {
                MedicineID = 0,
                MedicineDescription = "This is the description",
                MedicineDosage = "This is the dosage",
                MedicineName = "This is the name"
            }
        };

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="medicineID">The ID of the Medicine to delete</param>
        /// <returns>The number of rows affected</returns>
        public int DeleteMedicine(int medicineID)
        {
            int rows = 0;
            Medicine tempMed = new Medicine();

            foreach (Medicine medicine in _medicineList)
            {
                if (medicine.MedicineID == medicineID)
                {
                    tempMed = medicine;
                    rows++;
                }
            }

            _medicineList.Remove(tempMed);

            return rows;
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        /// </summary>
        /// <param name="medicine">The medicine to enter</param>
        /// <returns>The number of rows affected</returns>
        public int InsertMedicine(Medicine medicine)
        {
            _medicineList.Add(medicine);
            return 1;
        }

        public List<Medicine> SelectAllMedicines()
        {
            return _medicineList;
        }
    }
}
