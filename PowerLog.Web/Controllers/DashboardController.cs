using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PowerLog.Data;
using PowerLog.Model;
using PowerLog.Web.Models;
using PowerLog.Parser;
using WebMatrix.WebData;

namespace PowerLog.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private DB db = new DB();

        //
        // GET: /LoggedExercise/

        public ActionResult Index()
        {
            var userId = GetUserId();

            var loggedexercises = db.LoggedExercises.Include(l => l.Exercise).Where(x => x.UserId == userId).ToList();
            var loggedexercises2 = db.LoggedExercises.Where(x => x.UserId == userId).Include(l => l.Exercise).Select(x => x.Reps).ToList();
            var loggedexercises3 = db.LoggedExercises.Include(l => l.Exercise).Where(x => x.UserId == userId).Select(x => x.Weight).ToList();
            return View(loggedexercises);
        }

        private int GetUserId()
        {
            var userId = WebSecurity.GetUserId(User.Identity.Name);
            return userId;
        }

        public ActionResult Details(int year, int month, int day, string title)
        {
            var userId = GetUserId();
            var date = new DateTime(year, month, day);
            var loggedexercises = db.LoggedExercises.Where(x => x.UserId == userId && x.Date == date).ToList();
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
            var loggedexercises = db.LoggedExercises.Where(x => x.UserId == userId && x.ExerciseID == id).ToList();
            if (!loggedexercises.Any())
            {
                throw new Exception("lol");
                return HttpNotFound();
            }
            return View(loggedexercises);
        }


        public ActionResult Create()
        {
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name");
            return View();
        }

        //
        // POST: /LoggedExercise/Create

        [HttpPost]
        public ActionResult Create(LoggedExercise loggedexercise, string expression)
        {
            if (!string.IsNullOrWhiteSpace(expression))
            {
                foreach (var log in ParserHelper.ParseLog(db, loggedexercise.Date, expression))
                    db.LoggedExercises.Add(log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                db.LoggedExercises.Add(loggedexercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loggedexercise);
        }

        // [HttpPost]
        public ActionResult PreviewLog(DateTime date, string expression)
        {
            return Json(ParserHelper.ParseLog(db, date, expression), JsonRequestBehavior.AllowGet);
        }



        //
        // GET: /LoggedExercise/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LoggedExercise loggedexercise = db.LoggedExercises.Find(id);
            if (loggedexercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", loggedexercise.ExerciseID);
            return View(loggedexercise);
        }

        //
        // POST: /LoggedExercise/Edit/5

        [HttpPost]
        public ActionResult Edit(LoggedExercise loggedexercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loggedexercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", loggedexercise.ExerciseID);
            return View(loggedexercise);
        }

        //
        // GET: /LoggedExercise/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LoggedExercise loggedexercise = db.LoggedExercises.Find(id);
            if (loggedexercise == null)
            {
                return HttpNotFound();
            }
            return View(loggedexercise);
        }

        //
        // POST: /LoggedExercise/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            LoggedExercise loggedexercise = db.LoggedExercises.Find(id);
            db.LoggedExercises.Remove(loggedexercise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}