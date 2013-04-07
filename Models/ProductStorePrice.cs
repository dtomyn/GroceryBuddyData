using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyDataServices.Models
{
    public class ProductStorePrice
    {
        //public Product TheProduct { get; set; }
        public Store TheStore { get; set; }
        public DateTime PriceDate { get; set; }
        public Decimal Price { get; set; }
    }
}