using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trello.Web.Controllers;
using Trello.Web.Models;
using Trello.Web.Tests.TestDoubles;

namespace Trello.Web.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        [TestMethod]
        public void IndexAction_ReturnsViewNamedIndex()
        {
            // Arrange
            var bodyDouble = new TrelloListDoubleDAL();
            var controller = new HomeController(bodyDouble); //<-- passing in the test double

            // Act
            var result = controller.Index() as ViewResult; //Act

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
        }
    }
}
