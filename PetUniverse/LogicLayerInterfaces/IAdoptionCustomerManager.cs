using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;


namespace LogicLayerInterfaces
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/6/2020
    /// CHECKED BY: Mohamed Elamin, 02/07/2020
    /// 
    /// This is a simple interface that is used when dealing with aspects of Adoption Customer data.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public interface IAdoptionCustomerManager
    {
        List<AdoptionCustomerVM> RetrieveAdoptionCustomersByActive(bool active);
        AdoptionCustomerVM RetrieveAdoptionCustomerByEmail(string email);
    }
}
