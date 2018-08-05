using System;
using JBApp.Controllers;
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
        }

        [TestMethod]
        public void TestGetAll()
        {
            var prod = _prodController.Get();
        }
    }
}
