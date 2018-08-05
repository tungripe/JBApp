using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JBApp.Models;
using JBApp.Services;

namespace JBApp.Controllers
{
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
        public IEnumerable<Product> Get()
        {
            var products = _prodService.GetAll();
            return products;
        }

        //GET products/{id}
        public IHttpActionResult Get(string id)
        {
            var prod = _prodService.Get(id);

            if (prod == null)
                return NotFound();
            else
                return Ok(prod);
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