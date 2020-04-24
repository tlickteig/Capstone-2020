using DataAccessLayer;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/13/2020
    /// Approver: Chuck Baxter, 2/13/2020
    /// 
    /// Fake medication accessor class
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public class FakeMedicationAccessor : IMedicationAccessor
    {
        private List<Medication> Meds;

        public List<OutgoingOrders> MedOrder_ = new List<OutgoingOrders>();


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Fake medication inventory records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public FakeMedicationAccessor()
        {
            Meds = new List<Medication>()
            {
               new Medication()
               {
                   ItemID = 1,

                   ItemName = "Med_A",

                   ItemQuantity = 7

               },

               new Medication()
               {
                   ItemID = 2,

                   ItemName = "Med_B",

                   ItemQuantity = 3

               },

               new Medication()
               {
                   ItemID = 3,

                   ItemName = "Med_C",

                   ItemQuantity = 9

               },





            };

            new OutgoingOrders()
            {
                ItemID = 1,

                UserID = 1,

                ItemCategoryID = "Medication",

                OrderDate = DateTime.Today,

                ItemQuantity = 2

            };










        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Gets fake medication inventory records
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<Medication> GetCompleteMedicationInventory()
        {
            return Meds.ToList();


        }




        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/5/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Gets fake medication inventory records where quantity is less than a specified number
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<Medication> GetMedicationByLowQauntity()
        {
            try
            {
                Meds = new List<Medication>();
                foreach (Medication meds in Meds)
                {
                    if (meds.ItemQuantity < 5)
                    {
                        Meds.Add(meds);
                    }
                }
                return Meds;
            }
            catch
            {

                Meds = null;
                return Meds;
            }

        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 3/5/2020
        /// Approver: Carl Davis, 3/6/2020
        /// Approver: 
        /// 
        /// Gets fake medication inventory records where quantity is equal to zero
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public List<Medication> GetMedicationByEmptyQauntity()
        {
            try
            {
                Meds = new List<Medication>();
                foreach (Medication meds in Meds)
                {
                    if (meds.ItemQuantity == 0)
                    {
                        Meds.Add(meds);
                    }
                }
                return Meds;
            }
            catch
            {

                Meds = null;
                return Meds;
            }
        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Chuck Baxter, 2/21/2020
        /// Approver: Ethan Murphy 2/21/2020
        /// 
        /// inserts a fake medication order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>

        public int InsertMedicationOrder(OutgoingOrders order_)
        {
            try
            {
                MedOrder_.Add(order_);
                return 1;
            }
            catch
            {
                throw new Exception("Yeet");
            }
        }
    }





}

