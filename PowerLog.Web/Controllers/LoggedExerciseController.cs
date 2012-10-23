using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PowerLog.Data;
using PowerLog.Model;
using WebMatrix.WebData;

namespace PowerLog.Web.Controllers
{
    public class LoggedExerciseController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /LoggedExercise/

        public ActionResult Index()
        {
            if (Session["clearLocalStorage"] != null && (bool)Session["clearLocalStorage"])
            {
                ViewBag.ClearLocalStorage = true;
                Session["clearLocalStorage"] = null;
            }
            var loggedexercises = db.LoggedExercises.Include(l => l.Exercise);
            return View(loggedexercises.ToList());
        }

        //
        // GET: /LoggedExercise/Details/5

        public ActionResult Details(int id = 0)
        {
            LoggedExercise loggedexercise = db.LoggedExercises.Find(id);
            if (loggedexercise == null)
            {
                return HttpNotFound();
            }
            return View(loggedexercise);
        }

        //
        // GET: /LoggedExercise/Create

        public ActionResult Create()
        {
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name");
            return View();
        }

        //
        // POST: /LoggedExercise/Create

        private int GetUserId()
        {
            var userId = WebSecurity.GetUserId(User.Identity.Name);
            return userId;
        }
        [HttpPost]
        public ActionResult Create(LoggedExercise loggedexercise, string expression)
        {
            if (!string.IsNullOrWhiteSpace(expression))
            {
                var userId = GetUserId();
                foreach (var log in ParserHelper.ParseLog(db, loggedexercise.Date, expression))
                {
                    log.UserId = userId;
                    db.LoggedExercises.Add(log);
                }
                db.SaveChanges();
                Session["clearLocalStorage"] = true;
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

        public ActionResult Log()
        {
            return View();
        }

        // [HttpPost]
        public ActionResult PreviewLog(DateTime date, string expression)
        {
            var res = new Dictionary<string, IEnumerable<LoggedExercise>>();
            foreach (var e in expression.Split(';'))
            {
                try
                {
                    var le = ParserHelper.ParseLog(db, date, e);
                    var exercise = le.FirstOrDefault().Exercise.Name;
                    res.Add(exercise, le);
                }
                catch (Exception ex)
                {
                    Response.StatusCode = 404;
                    Response.StatusDescription = ex.Message;
                }
            }
            return Json(res.Select(x => new { Exercise = x.Key, Sets = x.Value }), JsonRequestBehavior.AllowGet);
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