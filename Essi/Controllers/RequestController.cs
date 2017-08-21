using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Essi.Models;
using Microsoft.AspNet.Identity;

namespace Essi.Controllers
{
    public class RequestController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Request
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            var userName = "";

            if (user is StudentUser)
            {
                var student = (StudentUser)user;
                userName = student.StudentNumber;
            }

            return View(db.Requests.Where(u => u.StudentUser.StudentNumber == userName).OrderBy(c => c.RequestCreatedTime));
        }

        // GET: Request/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Request request = await db.Requests.FindAsync(id);
            var student = db.Users.Find(User.Identity.GetUserId());

            if (request == null)
            {
                return HttpNotFound();
            }
            else if (request.StudentUser.StudentNumber != student.UserName)
            {
                return RedirectToAction("Index");
            }

            return View(request);
        }

        // GET: Request/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Request/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create([Bind(Include = "ID,ExerciseRound")] Request request)
        {
            if (ModelState.IsValid)
            {
                var student = db.Users.Find(User.Identity.GetUserId());

                if (student is StudentUser)
                {
                    request.StudentUser = (StudentUser)student;
                }

                request.RequestCreatedTime = DateTime.Now;

                db.Requests.Add(request);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(request);
        }

        // GET: Request/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Request request = await db.Requests.FindAsync(id);
            var student = db.Users.Find(User.Identity.GetUserId());

            if (request == null)
            {
                return HttpNotFound();
            }
            else if (request.StudentUser.StudentNumber != student.UserName) {
                return RedirectToAction("Index");
            }

            return View(request);
        }

        // POST: Request/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Edit([Bind(Include = "ID,StudentUserID,RequestCreatedTime,ExerciseRound")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;

                var student = db.Users.Find(User.Identity.GetUserId());

                if (request.StudentUserID != student.Id)
                {
                    return RedirectToAction("Index");
                }

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        // GET: Request/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Request request = await db.Requests.FindAsync(id);

            var student = db.Users.Find(User.Identity.GetUserId());

            if (request == null)
            {
                return HttpNotFound();
            }
            else if (request.StudentUser.StudentNumber != student.UserName)
            {
                return RedirectToAction("Index");
            }

            return View(request);
        }

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Request request = await db.Requests.FindAsync(id);

            var student = db.Users.Find(User.Identity.GetUserId());

            if (request.StudentUser.StudentNumber != student.UserName)
            {
                return RedirectToAction("Index");
            }

            db.Requests.Remove(request);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
