using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessInterfaces
{
    public interface IbackstockAccessor
    {

        List<Item> getAllItemInBackRoomm();
        List<int> getItemLocationsByItemID(int itemID);
        bool UpdatItemLocation(int itemID, int itemLocationID, int NewItemLocation);
    }
}
