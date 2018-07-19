using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExamenVueling.Facade.WebApi;
using ExamenVueling.Facade.WebApi.Controllers;

namespace ExamenVueling.Facade.WebApi.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disponer
            HomeController controller = new HomeController();

            // Actuar
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
