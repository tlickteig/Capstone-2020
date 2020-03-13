using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// Creator: Brandyn T. Coverdill
    /// Created: 2020/02/22
    /// Approver: Dalton Reierson
    /// Approver: Jesse Tomash
    ///
    /// The Data Access Interface for type Item.
    /// </summary>
    public interface IItemAccessor
    {

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/22
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface method that adds a new item to inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        bool addNewItem(Item item);

        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/02/23
        /// Approver: Dalton Reierson
        /// Approver:  Jesse Tomash
        ///
        /// Interface method that gets all items for inventory.
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        List<Item> getAllItems();


        /// <summary>
        /// Creator: Brandyn T. Coverdill
        /// Created: 2020/03/04
        /// Approver: Dalton Reireson
        /// Approver:   Jesse Tomash
        ///
        /// Interface method that updates an item.
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
        int updateItemDetail(string oldName, string oldDesc, int oldQuantity, string newName, string newDesc, int newQuantity);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/03/09
        /// Approver: Brandyn T. Coverdill
        /// Approver:   Jesse Tomash
        ///
        /// Interface method that selects all items by their active field
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="active"></param>
        List<Item> getAllItemsByActive(bool active);

        /// <summary>
        /// Creator: Dalton Reierson
        /// Created: 2020/04/09
        /// Approver: Brandyn T. Coverdill
        /// Approver: Jesse Tomash
        ///
        /// Interface method that sets the active field to 0
        /// </summary>
        ///
        /// <remarks>
        /// Updated By: 
        /// Updated: 
        /// Update:
        /// </remarks>
        /// <param name="item"></param>
        int deactivateItem(Item item);
    }
}
