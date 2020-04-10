using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IBackStockAccessor
    {
        List<Item> getAllItemsInBackRoom();
        List<int> getItemLocationsByItemID(int itemID);
        bool UpdateItemLocation(int itemID, int itemLocationID, int NewItemLocation);
    }
}
