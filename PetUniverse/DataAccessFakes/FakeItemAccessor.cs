using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using DataAccessInterfaces;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: Dalton Reierson
    /// Approver: Jesse Tomash
    ///
    /// The fake data accessor for Item.
    /// </summary>
    public class FakeItemAccessor : IItemAccessor
    {

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// The method for adding a new item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public bool addNewItem(Item item)
        {
            bool itemID = item.ItemID.Equals(1);
            bool itemCategoryID = item.ItemCategoryID.Equals("Cat Toys");
            bool itemQuantity = item.ItemQuantity.Equals(100);
            bool itemName = item.ItemName.Equals("Item");
            if (itemID && itemCategoryID && itemQuantity && itemName)
            {
                return true;
            }
            else
            {
                throw new ApplicationException("Cannot add new Item.");
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/23
        /// Approver: Dalton Reierson
        /// Approver: Jesse Tomash
        ///
        /// Method that gets all items from inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<Item> getAllItems()
        {
            List<Item> items = new List<Item>()
            {
                new Item
                {
                    ItemID = 1,
                    ItemName = "Item1",
                    ItemQuantity = 10,
                    ItemCategoryID = "Dog Food"
                },
                new Item
                {
                    ItemID = 2,
                    ItemName = "Item2",
                    ItemQuantity = 20,
                    ItemCategoryID = "Dog Food"
                },
                new Item
                {
                    ItemID = 3,
                    ItemName = "Item3",
                    ItemQuantity = 30,
                    ItemCategoryID = "Cat Toys"
                }
            };

            return items;
        }
    }
}
