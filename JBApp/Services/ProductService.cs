using JBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JBApp.Services
{
    /// <summary>
    /// Handle product request
    /// </summary>
    public class ProductService
    {
        private JBAppContext _context;

        public ProductService()
        {
            _context = new JBAppContext();
        }

        public Product Get(string id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public bool Update(Product p)
        {
            var prod = _context.Products.FirstOrDefault(x => x.Id == p.Id);

            if (prod != null)
            {
                prod.Model = p.Model;
                prod.Brand = p.Brand;
                prod.Description = p.Description;
                _context.SaveChanges();

                return true;
            }

            return false;
        }

        public Product Add(Product p)
        {
            var prod = Get(p.Id);
            if (prod != null)
                return null;

            _context.Products.Add(p);
            _context.SaveChanges();

            return p;
        }

        public bool Delete(string id)
        {
            var prod = Get(id);
            if (prod == null)
                return false;
            else
            {
                _context.Products.Remove(prod);
                _context.SaveChanges();

                return true;
            }
        }
    }
}