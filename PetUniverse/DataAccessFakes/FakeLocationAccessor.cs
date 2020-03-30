using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessInterfaces;
using DataTransferObjects;

namespace DataAccessFakes
{
    /// <summary>
    /// NAME: Austin Gee
    /// DATE: 3/19/2020
    /// CHECKED BY: 
    /// 
    /// Location Data access Fake
    /// </summary>
    /// <remarks>
    /// UPDATED BY: NA
    /// UPDATE DATE: NA
    /// WHAT WAS CHANGED: NA
    /// 
    /// </remarks>
    public class FakeLocationAccessor : ILocationAccessor
    {
        private List<Location> _locations;


        public FakeLocationAccessor()
        {
            _locations = new List<Location>()
            {
                new Location()
                {
                    LocationID = 000,
                    Name = "Fake",
                    Address1 = "Fake",
                    Address2 = "Fake",
                    City = "Fake",
                    State = "Fake",
                    Zip = "Fake"
                },

                new Location()
                {
                    LocationID = 001,
                    Name = "Fake",
                    Address1 = "Fake",
                    Address2 = "Fake",
                    City = "Fake",
                    State = "Fake",
                    Zip = "Fake"
                },

                new Location()
                {
                    LocationID = 002,
                    Name = "Fake",
                    Address1 = "Fake",
                    Address2 = "Fake",
                    City = "Fake",
                    State = "Fake",
                    Zip = "Fake"
                },
            };
        }
        public int DeleteLocation(Location location)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// NAME: Austin Gee
        /// DATE: 3/19/2020
        /// CHECKED BY: 
        /// 
        /// Inserts a location in the fakes
        /// </summary>
        /// <remarks>
        /// UPDATED BY: NA
        /// UPDATE DATE: NA
        /// WHAT WAS CHANGED: NA
        /// 
        /// </remarks>
        public int InsertLocation(Location location)
        {
            try
            {
                _locations.Add(location);
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Location> SelectAllLocations()
        {
            return _locations;
        }

        public Location SelectLocationByLocationID()
        {
            throw new NotImplementedException();
        }

        public int UpdateLocation(Location oldLocation, Location newLocation)
        {
            throw new NotImplementedException();
        }
    }
}
