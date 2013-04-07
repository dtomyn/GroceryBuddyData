using MyDataServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MyDataServices.Controllers
{
    public class StoresController : ApiController
    {
        List<Store> StoreContext;

        public StoresController()
        {
            if (HttpContext.Current.Application["storeContext"] == null)
            {
                HttpContext.Current.Application["storeContext"] = new List<Store>();
                ((List<Store>)HttpContext.Current.Application["storeContext"]).Add(StoreConstants.Safeway);
                ((List<Store>)HttpContext.Current.Application["storeContext"]).Add(StoreConstants.WalMart);
                ((List<Store>)HttpContext.Current.Application["storeContext"]).Add(StoreConstants.Seven11);
                ((List<Store>)HttpContext.Current.Application["storeContext"]).Add(StoreConstants.Superstore);
            }
            StoreContext = (List<Store>)(HttpContext.Current.Application["storeContext"]);
        }

        // GET api/values
        public IEnumerable<Store> Get()
        {
            return StoreContext;
        }

        // GET api/values/5
        public Store Get(int id)
        {
            Store current = StoreContext.FirstOrDefault(b => b.Id.Equals(id));
            if (current == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                return current;
            }
        }

        // POST api/values
        public void Post([FromBody]Store value)
        {
            //add only if does not exist already... otherwise update
            Store current = StoreContext.FirstOrDefault(b => b.Id.Equals(value.Id));
            if (current == null)
            {
                StoreContext.Add(value);
            }
            else
            {
                current.Id = value.Id;
                current.Name = value.Name;
                current.City = value.City;
                current.Latitude = value.Latitude;
                current.Longitude = value.Longitude;
                current.PostalCode = value.PostalCode;
                current.Province = value.Province;
                current.StreetAddress = value.StreetAddress;
                current.Telephone = value.Telephone;
            }
        }

        // PUT api/values/5
        //public void Put(string sku, [FromBody]Store value)
        public void Put(int id, [FromBody]Store value)
        {
            Store current = StoreContext.FirstOrDefault(b => b.Id.Equals(id));
            if (current == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            else
            {
                current.Id = value.Id;
                current.Name = value.Name;
                current.City = value.City;
                current.Latitude = value.Latitude;
                current.Longitude = value.Longitude;
                current.PostalCode = value.PostalCode;
                current.Province = value.Province;
                current.StreetAddress = value.StreetAddress;
                current.Telephone = value.Telephone;
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            throw new NotImplementedException();
            //Store current = StoreContext.FirstOrDefault(b => b.Id.Equals(id));
            //if (current == null || current.IsDeleted)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            //else
            //{
            //    current.IsDeleted = true;
            //}
        }

    }
}