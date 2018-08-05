using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using JBApp.Controllers;
using JBApp.Models;
using JBApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JBApp.UnitTest
{
    [TestClass]
    public class TestProductApi
    {
        private ProductService _prodService;
        private ProductsController _prodController;

        [TestInitialize]
        public void Setup()
        {
            _prodService = new ProductService();
            _prodController = new ProductsController(_prodService);

            //ignite
            //Environment.SetEnvironmentVariable("IGNITE_HOME", string.Format("{0}", Environment.CurrentDirectory));
        }

        [TestMethod]
        public void TestGetAll()
        {
            var prods = _prodController.Get(null, null, null) as List<Product>;

            Assert.IsTrue( prods.Count > 0);
        }

        [TestMethod]
        public void TestGetSingle()
        {
            var prod = _prodController.Get(id: "1") as OkNegotiatedContentResult<Product>;
            Assert.AreEqual(prod.Content.Brand, "Samsung");
        }

        [TestMethod]
        public void TestAddProductOk()
        {
            var prod = new Product() { Id = "4", Brand = "Nokia", Description = "Cheap phone", Model = "Nokia 1" };
            var result = _prodController.Post(prod) as OkNegotiatedContentResult<Product>;

            var actual = _prodService.Get(prod.Id);//in the database

            Assert.AreEqual(result.Content.Id, actual.Id);
        }

        [TestMethod]
        public void TestAddProductFailed()
        {
            var prod = new Product() { Id = "1", Brand = "Nokia", Description = "Cheap phone", Model = "Nokia 1" };
            var result = _prodController.Post(prod) as BadRequestResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestUpdateProduct()
        {
            var desc = string.Format("Updated " + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            var prod = new Product() { Id = "3", Brand = "Sony", Description = desc, Model = "Sony" };

            var result = _prodController.Put(prod.Id, prod) as OkNegotiatedContentResult<object>;

            var actual = _prodService.Get(prod.Id);

            Assert.AreEqual(desc, actual.Description);
        }

        [TestMethod]
        public void TestDeleteProductOk()
        {
            var result = _prodController.Delete("4");

            Assert.IsTrue(result is OkResult);
        }

    }
}
