using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{ /// <summary>
  /// Creator: Tener karar
  /// Created: 2020/02/7
  /// Approver : Steven Cardona
  ///
  /// The fake data accsess class 
  /// Contains all methods for  making  the real  data
  /// </summary>

    public class BackRecordAccessorFakes : IbackstockAccessor
    {
        private List<Item> items = null;
        private List<ItemLocation> itemlocations = null;
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this method for making back record accesser 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>

        public BackRecordAccessorFakes()
        {
            items = new List<Item>()
            {
                new Item()
                {
                    ItemID= 10001,
                    ItemName="gggggg",
                    ItemQuantity = 4,
                    ItemCategoryID="ggg"

                },
            };
            itemlocations = new List<ItemLocation>()
            {
                new ItemLocation(){
                itemID = 1000,
                itemLocation=1000,
                },
                new ItemLocation(){
                itemID = 1001,
                itemLocation=1002,
                },
                new ItemLocation(){
                itemID = 1000,
                itemLocation=1004,
                },
                new ItemLocation(){
                itemID = 1003,
                itemLocation=1005,
                },

            };



        }
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this method making get all item in back room  Edite 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>

        public List<Item> getAllItemInBackRoomm()
        {
            return items;

        }
        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this method making get all item in back room  Edite 
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="itemID"></param>

        public List<int> getItemLocationsByItemID(int itemID)
        {
            List<int> item = new List<int>();
            foreach (ItemLocation itemlocationFake in itemlocations)
            {
                if (itemID == itemlocationFake.itemID)
                {
                    item.Add(itemlocationFake.itemLocation);


                }
            }
            return item;
        }

        /// <summary>
        /// Creator: Tener Karar
        /// Created: 2020/02/7
        /// Approver: Steven Cardona
        /// 
        /// this method making Edite and  update item location
        /// </summary>
        ///
        /// <remarks>
        /// Updater Name
        /// Updated: yyyy/mm/dd 
        /// Update: 
        /// </remarks>
        /// <param name="item"></param>
        /// <param name="itemLocationID"></param>
        /// <param name="NewItemLocation"></param>
        public bool UpdatItemLocation(int itemID, int itemLocationID, int NewItemLocation)
        {
            bool locationupdat = false;

            foreach (ItemLocation itemlocationFake in itemlocations)
            {
                if (itemID == itemlocationFake.itemID && itemLocationID == itemlocationFake.itemLocation)
                {
                    itemlocationFake.itemLocation = NewItemLocation;
                    // if the item location updated  locationupdat = true
                    locationupdat = true;
                    break;
                }

            }


            return locationupdat;
        }
    }
}
