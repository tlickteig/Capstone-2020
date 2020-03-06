using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: Dalton Reierson
    /// Approver:  Jesse Tomash
    ///
    /// The Logic Layer Interface for object Item.
    /// </summary>
    public interface IItemManager
    {
        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// The interface method for adding a new item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        bool createNewItem(Item item);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/23
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface method that gets a list of items from inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        List<Item> retrieveItems();


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/04
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface method that updates an item.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        bool editItemDetail(string oldName, string oldDesc, int oldQuantity, string newName, string newDesc, int newQuantity);
    }
}
