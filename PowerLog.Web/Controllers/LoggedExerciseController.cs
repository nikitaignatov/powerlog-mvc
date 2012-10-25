using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PowerLog.Data;
using PowerLog.Model;
using PowerLog.Web.Filters;
using WebMatrix.WebData;

namespace PowerLog.Web.Controllers
{
    public class LoggedExerciseController : Controller
    {
        private UsersContext db = new UsersContext();

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

        public ActionResult Details(int id = 0)
        {
            LoggedExercise loggedexercise = db.LoggedExercises.Find(id);
            if (loggedexercise == null)
            {
                return HttpNotFound();
            }
            return View(loggedexercise);
        }

        public ActionResult Create()
        {
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(TrainingSession session, string expression)
        {
            if (!string.IsNullOrWhiteSpace(expression))
            {
                SaveSession(session, expression);
                Session["clearLocalStorage"] = true;
                return RedirectToAction("Index");
            }
            else if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(session);
        }

        public ActionResult Log()
        {
            return View();
        }

        // [HttpPost]
        public ActionResult PreviewLog(DateTime date, string expression, string comment = null)
        {
            var res = new Dictionary<string, IEnumerable<LoggedExercise>>();
            var data = new Dictionary<DateTime, List<string>> { { date, new List<string>() } };
            foreach (var e in expression.Split(';'))
            {
                if (data.ContainsKey(date))
                    data[date].Add(e);
            }
            try
            {
                var le = ParserHelper.ParseLog(db, GetUserId(), comment, data, perssist: false).ToList();
                var exercise = le.FirstOrDefault().Exercise.Name;
                res.Add(exercise, le);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 404;
                Response.StatusDescription = ex.Message;
            }
            return Json(res.Select(x => new { Exercise = x.Key, Sets = x.Value }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id = 0)
        {
            LoggedExercise loggedexercise = db.LoggedExercises.Find(id);
            if (loggedexercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", loggedexercise.ExerciseId);
            return View(loggedexercise);
        }

        [HttpPost]
        public ActionResult Edit(LoggedExercise loggedexercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loggedexercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", loggedexercise.ExerciseId);
            return View(loggedexercise);
        }

        public ActionResult Delete(int id = 0)
        {
            LoggedExercise loggedexercise = db.LoggedExercises.Find(id);
            if (loggedexercise == null)
            {
                return HttpNotFound();
            }
            return View(loggedexercise);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            LoggedExercise loggedexercise = db.LoggedExercises.Find(id);
            db.LoggedExercises.Remove(loggedexercise);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private int GetUserId()
        {
            var userId = WebSecurity.GetUserId(User.Identity.Name);
            return userId;
        }

        private void SaveSession(TrainingSession session, string expression)
        {
            var userId = GetUserId();
            session.UserId = userId;
            db.TrainingSessions.Add(session);
            db.SaveChanges();
            var date = session.Date;
            var data = new Dictionary<DateTime, List<string>> { { date, new List<string>() } };
            foreach (var e in expression.Split(';'))
            {
                if (data.ContainsKey(date))
                    data[date].Add(e);
            }
            foreach (var log in data)
            {
                ParserHelper.ParseLog(db, GetUserId(), session.Comment, data);
            }
            db.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}