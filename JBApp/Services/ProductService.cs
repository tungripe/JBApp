using JBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JBApp.Services
{
    /// <summary>
    /// This class mimics a storage for products
    /// </summary>
    public static class ProductService
    {
        private static List<Product> _products;
        public static List<Product> Products {
            get {
                if (_products == null)
                {
                    _products = new List<Product>();
                    _products.Add(new Product() { Id = "1", Brand = "Samsung", Description = "Samsung Phone", Model = "Samsung galaxy"});
                    _products.Add(new Product() { Id = "2", Brand = "Apple", Description = "Iphone", Model = "Iphone 7" });
                    _products.Add(new Product() { Id = "3", Brand = "Sony", Description = "Sony Phone", Model = "TV" });
                }
                return _products;
            }
        }

        private static void Init()
        {

        }
    }
}