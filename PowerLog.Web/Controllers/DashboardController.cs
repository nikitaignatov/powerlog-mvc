using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PowerLog.Data;
using PowerLog.Model;
using PowerLog.Parser;
using PowerLog.Web.Filters;
using WebMatrix.WebData;

namespace PowerLog.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private UsersContext db = new UsersContext();

        public ActionResult Index()
        {
            var userId = GetUserId();

            var loggedexercises = db.LoggedExercises.Include(l => l.Exercise).Where(x => x.UserId == userId).ToList();
            return View(loggedexercises);
        }

        public ActionResult Details(int year, int month, int day, string title)
        {
            var userId = GetUserId();
            var date = new DateTime(year, month, day);
            var loggedexercises = db.LoggedExercises.Where(x => x.UserId == userId && x.Date == date).Include(x => x.UserProfile).ToList();
            if (!loggedexercises.Any())
            {
                throw new Exception("lol");
                return HttpNotFound();
            }
            return View(loggedexercises);
        }

        public ActionResult Progress(int id, int year, int month, int day)
        {
            var userId = GetUserId();
            var date = new DateTime(year, month, day);
            var loggedexercises = db.LoggedExercises.Where(x => x.UserId == userId && x.ExerciseId == id).ToList();
            if (!loggedexercises.Any())
            {
                throw new Exception("lol");
                return HttpNotFound();
            }
            return View(loggedexercises);
        }

        public ActionResult Compare(int id, DateTime[] dates)
        {
            var userId = GetUserId();
            var loggedexercises = db.LoggedExercises.Where(x => x.UserId == userId && dates.Contains(x.Date)).ToList();
            if (!loggedexercises.Any())
            {
                throw new Exception("lol");
                return HttpNotFound();
            }
            return View(loggedexercises);
        }

        private int GetUserId()
        {
            var userId = WebSecurity.GetUserId(User.Identity.Name);
            return userId;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}