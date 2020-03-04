using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;
using LogicLayerInterfaces;
using DataAccessLayer;
using DataAccessInterfaces;

namespace LogicLayer
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: Dalton Reierson
    /// Approver: 
    ///
    /// The Logic Layer class for Item.
    /// </summary>
    public class ItemManager : IItemManager
    {

        private IItemAccessor _itemAccessor;

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// The method that adds a new item to the database.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        public bool createNewItem(Item item)
        {
            try
            {
                return _itemAccessor.addNewItem(item);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Unable to add a new Item", ex);
            }
        }

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/23
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Method that gets a list of items for inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public List<Item> retrieveItems()
        {
            List<Item> items = new List<Item>();

            try
            {
                items = _itemAccessor.getAllItems();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No Items Found", ex);
            }

            return items;
        }


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Constructor for the Item Manager that takes an itemAccessor.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        public ItemManager(IItemAccessor itemAccessor)
        {
            _itemAccessor = itemAccessor;
        }


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Default Constructor for Item Manager.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        public ItemManager()
        {
            _itemAccessor = new ItemAccessor();
        }
    }
}
