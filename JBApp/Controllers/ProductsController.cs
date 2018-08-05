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
        private JBAppContext _dbContext;


        public ProductsController()
        {
            _dbContext = new JBAppContext();
        }

        public ProductsController(JBAppContext context)
        {
            _dbContext = context;
        }

        //GET products
        //GET products/{id}
        //POST products
        //PUT products/{id}
        //DELETE products/{id}
        // GET api/<controller>
        public IEnumerable<Product> Get()
        {
            var products = _dbContext.Products.ToList();
            return products;
        }

        public IHttpActionResult Get(string id)
        {
            var prod = ProductService.Products.FirstOrDefault(x => x.Id == id);
            if (prod == null)
                return NotFound();
            else
                return Ok(prod);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}