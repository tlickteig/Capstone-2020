using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTransferObjects;

namespace DataAccessInterfaces
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 2/6/202
    /// CHECKED BY: Mohamed Elamin, 02/07/2020
    /// 
    /// This is a simple interface for methods that have to do with Adoption Customer
    /// data access.
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public interface IAdoptionCustomerAccessor
    {
        List<AdoptionCustomerVM> SelectAdoptionCustomersByActive(bool active);
    }
}
