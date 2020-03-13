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
    /// DATE: 3/12/2020
    /// CHECKED BY: Michael Thompson
    /// 
    /// Interface for Locations
    /// </summary>
    public interface ILocationAccessor
    {

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Inserts a location into the database
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="location"></param>
        /// <returns></returns>
        int InsertLocation(Location location);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// selects all locations
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        List<Location> SelectAllLocations();

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Selects a location by its id
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        Location SelectLocationByLocationID();

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Updates a location
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="oldLocation"></param>
        /// <param name="newLocation"></param>
        /// <returns></returns>
        int UpdateLocation(Location oldLocation, Location newLocation);

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/12/2020
        /// CHECKED BY: Michael Thompson
        /// 
        /// Deletes a location
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        /// <param name="location"></param>
        /// <returns></returns>
        int DeleteLocation(Location location);
    }
}
