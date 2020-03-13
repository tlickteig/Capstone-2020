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

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/04
        /// Approver: Dalton Reireson
        /// Approver:   Jesse Tomash
        ///
        /// Method that updates an item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="newDesc"></param>
        /// <param name="newName"></param>
        /// <param name="newQuantity"></param>
        /// <param name="oldDesc"></param>
        /// <param name="oldName"></param>
        /// <param name="oldQuantity"></param>
        public int updateItemDetail(string oldName, string oldDesc, int oldQuantity, string newName, string newDesc, int newQuantity)
        {
            int result = 0;
            oldName = newName;
            oldDesc = newDesc;
            oldQuantity = newQuantity;

            if (oldName == newName && oldDesc == newDesc && oldQuantity == newQuantity)
            {
                result = 1;
            }

            return result;
        }


        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/10
        /// Approver: Brandyn T. Coverdill
        /// Approver: 
        ///
        /// Method that deactivates an item
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public int deactivateItem(Item item)
        {
            int rowsAffected = 0;

            Item testItem = new Item();
            testItem.ItemID = 100000;
            testItem.ItemName = "Dog Food";
            testItem.ItemCategoryID = "Dog Food";
            testItem.Description = "Dog Food Description";
            testItem.ItemQuantity = 10;
            testItem.Active = true;

            if (item.ItemID == testItem.ItemID &&
               item.ItemName == testItem.ItemName &&
               item.ItemCategoryID == testItem.ItemCategoryID &&
               item.Description == testItem.Description &&
               item.ItemQuantity == testItem.ItemQuantity &&
               item.Active == item.Active)
            {
                item.Active = false;
                rowsAffected = 1;
            }

            return rowsAffected;
        }

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/10
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesse Tomash
        ///
        /// Method that returns all items with desired active state
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="active"></param>
        public List<Item> getAllItemsByActive(bool active)
        {
            List<Item> itemList = new List<Item>();
            List<Item> filterItemList = new List<Item>();

            for (int i = 0; i < 5; i++)
            {
                Item item = new Item();
                item.ItemID = 100000;
                item.ItemName = "Name";
                item.ItemQuantity = 10;
                item.ItemCategoryID = "100000";
                item.Description = "Test";
                item.Active = true;
                itemList.Add(item);
            }

            for (int i = 0; i < 4; i++)
            {
                Item item = new Item();
                item.ItemID = 100000;
                item.ItemName = "Name";
                item.ItemQuantity = 10;
                item.ItemCategoryID = "100000";
                item.Description = "Test";
                item.Active = false;
                itemList.Add(item);
            }

            var results = from item in itemList
                          where item.Active == true
                          select item;

            foreach (Item i in results)
            {
                filterItemList.Add(i);
            }

            return filterItemList;
        }
    }
}
