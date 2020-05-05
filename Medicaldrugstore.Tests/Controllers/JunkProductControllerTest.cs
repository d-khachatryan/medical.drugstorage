using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medicaldrugstore.Controllers;
using System.Web.Mvc;

namespace Medicaldrugstore.Tests.Controllers
{
    [TestClass]
    public class JunkProductControllerTest
    {
        [TestMethod]
        public void ReadJunkProductsTest()
        {
            var controller = new JunkProductsController("2b9ec1ab-1179-45e2-92ed-67fe950d5218");


            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
