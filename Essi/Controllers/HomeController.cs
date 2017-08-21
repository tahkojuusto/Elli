using Essi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Essi.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            // Show all requests made by all students in creation time order.
            return View(db.Requests.ToList().OrderBy(c => c.RequestCreatedTime));
        }
    }
}