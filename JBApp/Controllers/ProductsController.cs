using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using JBApp.Models;
using JBApp.Services;

namespace JBApp.Controllers
{
	[CustomAuthenticationFilterAttribute]
	[Authorize]
    public class ProductsController : ApiController
    {
        private ProductService _prodService;


        public ProductsController()
        {
            _prodService = new ProductService();
        }

        public ProductsController(ProductService service)
        {
            _prodService = service;
        }

        //GET products
        [Route("api/products/filters/{description?}/{model?}/{brand?}")]
        public IEnumerable<Product> Get(string description = null, string model = null, string brand = null)
        {
            var products = _prodService.Get(description, model, brand);
            return products;
        }

 //       attempt to use ignite to cache data
 //       //GET products/{id}
 //       public IHttpActionResult Get(string id)
 //       {
 //           //use ignite to cache data
 //           using (var ignite = Ignition.Start())
 //           {
 //               ICache<string, Product> cache = ignite.GetOrCreateCache<string, Product>("products");
 //               var data = cache.FirstOrDefault(x => x.Key == "id");

 //               if (data != null)
 //                   return Ok(data);
 //               else
 //               {
 //                   var prod = _prodService.Get(id);

 //                   if (prod == null)
 //                       return NotFound();
 //                   else
 //                   {
 //                       cache.Put(prod.Id, prod);
 //                       return Ok(prod);
 //                   }
 //               }
 //           }
 //       }

        //GET products/{id}
        public IHttpActionResult Get(string id)
        {
            var prod = _prodService.Get(id);

            if (prod == null)
                return NotFound();
            else
            {
                return Ok(prod);
            }
        }

        //POST products
        public IHttpActionResult Post(Product p)
        {
            var result = _prodService.Add(p);
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }

        //PUT products/{id}
        public IHttpActionResult Put(string id, Product p)
        {
            if (id != p.Id)
                return BadRequest();

            var result = _prodService.Update(p);

            if (result)
                return Ok();
            else
                return BadRequest();
        }

        // DELETE products/{id}
        public IHttpActionResult Delete(string id)
        {
            var result = _prodService.Delete(id);

            if (result)
                return Ok();
            else
                return BadRequest();
        }
    }
}