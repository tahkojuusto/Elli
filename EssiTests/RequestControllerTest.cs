using Microsoft.VisualStudio.TestTools.UnitTesting;
using Essi.Controllers;
using Essi.Models;
using System.Web.Mvc;

namespace EssiTests
{
    [TestClass]
    public class RequestControllerTest
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [TestMethod]
        public async void TestEmptyRequestIndexView()
        {
            var controller = new RequestController();
            ViewResult result = await controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
