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
    }
}
