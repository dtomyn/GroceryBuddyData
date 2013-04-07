using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDataServices.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Telephone { get; set; }
        public Decimal Latitude { get; set; }
        public Decimal Longitude { get; set; }
    }

    public static class StoreConstants
    {
        public static Store Safeway
        {
            get
            {
                return
                    new Store
                    {
                        Id = 0,
                        Name = "Safeway",
                        City = "Regina",
                        Province = "Saskatchewan",
                        Latitude = 50.445631M,
                        Longitude = -104.622935M
                    };
            }
        }

        public static Store WalMart
        {
            get
            {
                return
                    new Store
                    {
                        Id = 1,
                        Name = "WalMart",
                        City = "Regina",
                        Province = "Saskatchewan",
                        Latitude = 50.444538M,
                        Longitude = -104.53483M
                    };
            }
        }

        public static Store Seven11
        {
            get
            {
                return
                    new Store
                    {
                        Id = 2,
                        Name = "7-11",
                        City = "Regina",
                        Province = "Saskatchewan",
                        Latitude = 50.444251M,
                        Longitude = -104.605876M
                    };
            }
        }

        public static Store Superstore
        {
            get
            {
                return
                    new Store
                    {
                        Id = 3,
                        Name = "Superstore",
                        City = "Regina",
                        Province = "Saskatchewan",
                        Latitude = 50.446355M,
                        Longitude = -104.528746M
                    };
            }
        }
    }
}