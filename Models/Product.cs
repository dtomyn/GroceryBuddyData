using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDataServices.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        //public bool IsNew { get; set; }

        //public ProductStorePrice[] Stores { get; set; }
        //public List<ProductStorePrice> StoresAndPrices { get; set; }

        public Product()
        {
            //StoresAndPrices = new List<ProductStorePrice>();
        }
    }

    public static class ProductConstants
    {
        public static Product CanOfCoke
        {
            get
            {
                var p = 
                    new Product
                    {
                        Id = 0,
                        Sku = "06782900",
                        Name = "Coke",
                        Description = "355 ml can of coke"
                    };
                //p.StoresAndPrices.Add
                //    (
                //        new ProductStorePrice()
                //        {
                //            TheStore = StoreConstants.Safeway
                //            , Price = 2.25M
                //            , PriceDate = new DateTime(2013, 4, 3)
                //        }
                //    );
                return p;
            }
        }

        public static Product CanOfPepsi
        {
            get
            {
                var p = 
                    new Product
                    {
                        Id = 1,
                        Sku = "06942508",
                        Name = "Pepsi",
                        Description = "355 ml can of Pepsi"
                    };
                //p.StoresAndPrices.Add
                //    (
                //        new ProductStorePrice()
                //        {
                //            TheStore = StoreConstants.Safeway
                //            , Price = 2.25M
                //            , PriceDate = new DateTime(2013, 4, 3)
                //        }
                //    );
                return p;
            }
        }

        public static Product BoxOfKraftDinner
        {
            get
            {
                var p =
                    new Product
                    {
                        Id = 2,
                        Sku = "068100058703",
                        Name = "Kraft Dinner",
                        Description = "200 g box of Kraft Dinner"
                    };
                //p.StoresAndPrices.Add
                //    (
                //        new ProductStorePrice()
                //        {
                //            TheStore = StoreConstants.Safeway
                //            , Price = 2.25M
                //            , PriceDate = new DateTime(2013, 4, 3)
                //        }
                //    );
                return p;
            }
        }
    }
}