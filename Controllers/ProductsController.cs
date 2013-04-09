using MyDataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace MyDataServices.Controllers
{
    public class ProductsController : ApiController
    {
        List<Product> ProductContext;

        public ProductsController()
        {
            if (HttpContext.Current.Application["productContext"] == null)
            {
                HttpContext.Current.Application["productContext"] = new List<Product>();
                ((List<Product>)HttpContext.Current.Application["productContext"]).Add(ProductConstants.CanOfCoke);
                ((List<Product>)HttpContext.Current.Application["productContext"]).Add(ProductConstants.CanOfPepsi);
                ((List<Product>)HttpContext.Current.Application["productContext"]).Add(ProductConstants.BoxOfKraftDinner);
            }
            ProductContext = (List<Product>)(HttpContext.Current.Application["productContext"]);
        }

        public IEnumerable<Product> Get()
        {
            return ProductContext;
        }

        public Product Get(string sku)
        {
            Product current = ProductContext.FirstOrDefault(b => b.Sku.Equals(sku, StringComparison.OrdinalIgnoreCase) && !b.IsDeleted);
            if (current == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return current;
            }
        }

        public void Post([FromBody]Product value)
        {
            //add only if does not exist already... otherwise update
            Product current = ProductContext.FirstOrDefault(b => b.Id.Equals(value.Id));
            if (current == null)
            {
                ProductContext.Add(value);
            }
            else
            {
                current.Id = value.Id;
                current.Name = value.Name;
                current.Description = value.Description;
                current.IsDeleted = value.IsDeleted;
            }
        }

        public void Put(int id, [FromBody]Product value)
        {
            Product current = ProductContext.FirstOrDefault(b => b.Id.Equals(id));
            if (current == null || current.IsDeleted)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                if (value.IsDeleted)
                {
                    Delete(id);
                }
                else
                {
                    current.Id = value.Id;
                    current.Name = value.Name;
                    current.Description = value.Description;
                    current.IsDeleted = value.IsDeleted;
                }
            }
        }

        public void Delete(int id)
        {
            Product current = ProductContext.FirstOrDefault(b => b.Id.Equals(id));
            if (current == null || current.IsDeleted)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                current.IsDeleted = true;
            }
        }
    }
}