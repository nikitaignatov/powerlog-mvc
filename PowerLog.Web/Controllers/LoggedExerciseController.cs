using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
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

            var userId = GetUserId();
            var user = db.UserProfiles.FirstOrDefault(x => x.UserId == userId);

            var loggedexercises = db.LoggedExercises.Where(x => x.UserId == userId).Include(l => l.Exercise).ToList();
            foreach (var log in loggedexercises)
            {
                log.UserProfile = user;
            }

            ViewBag.ExersiceID = new SelectList(loggedexercises.Select(x => x.Exercise).Distinct().ToList(), "ID", "Name");
            ViewBag.Force = new SelectList(loggedexercises.Select(x => x.Exercise.Force).Distinct().ToList());
            ViewBag.BodyPart = new SelectList(loggedexercises.Select(x => x.Exercise.BodyPart).Distinct().ToList());
            ViewBag.Mechanics = new SelectList(loggedexercises.Select(x => x.Exercise.Mechanics).Distinct().ToList());

            return View(loggedexercises);
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

        public FileContentResult Data(string format)
        {
            var userId = GetUserId();
            var log = db.LoggedExercises.Where(e => e.UserId == userId).ToList();

            var download = log.Select(e => new
            {
                e.Date,
                e.Exercise.Name,
                e.Reps,
                e.Weight,
                e.OneRepMax,
                e.Load,
                e.Comment,
                e.ForcedReps,
                e.FailedToLift,
                e.ToFailure,
                e.MaxEffort,
                Unit = e.WeightUnitName
            });
            if (format == "csv")
            {
                var filename = string.Format("powerlog.me.dump_{0}.csv", DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss"));
                Response.AppendHeader("content-disposition", "attachment; filename=" + filename);
                var r = Encoding.UTF8.GetBytes(ServiceStack.Text.CsvSerializer.SerializeToCsv(download));
                return File(r, "text/csv");
            }
            else if (format == "json")
            {
                var filename = string.Format("powerlog.me.dump_{0}.json", DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss"));
                Response.AppendHeader("content-disposition", "attachment; filename=" + filename);
                var options = new JsonSerializerSettings();
                options.Formatting = Formatting.Indented;
                var serializer = JsonSerializer.Create(options);
                var sb = new StringWriter();
                serializer.Serialize(sb, download);
                var r = Encoding.UTF8.GetBytes(sb.ToString());
                return File(r, "text/json");
            }
            else if (format == "pwl")
            {
                var filename = string.Format("powerlog.me.dump_{0}.pwl", DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss"));
                Response.AppendHeader("content-disposition", "attachment; filename=" + filename);

                var sb = toPwl(log);
                var r = Encoding.UTF8.GetBytes(sb.ToString());
                return File(r, "text/pwl");
            }
            return File(Encoding.UTF8.GetBytes("Error"), "text/plain");
        }

        private static StringBuilder toPwl(IEnumerable<LoggedExercise> download)
        {
            var sb = new StringBuilder();
            foreach (var date in download.GroupBy(x => x.Date))
            {
                foreach (var exercise in date.GroupBy(x => x.Exercise))
                {
                    sb.AppendLine(string.Format("{0},{1} {2}",
                        date.Key.ToString("yyyy-MM-dd"),
                        exercise.Key.Name.ToLower(),
                        string.Join(" ",
                        exercise.Select(x => x.ToPwl())
                        )));
                }
            }
            return sb;
        }

        public ActionResult Download()
        {
            return View();
        }

        // [HttpPost]
        public ActionResult PreviewLog(DateTime date, string expression, string comment = null)
        {
            var res = new Dictionary<string, IEnumerable<LoggedExercise>>();
            var data = new List<string>();
            foreach (var e in expression.Trim().Trim(';').Split(';'))
            {
                data.Add(e);
            }
            try
            {
                var le = ParserHelper.ParseLog(db, GetUserId(), comment, date, data, perssist: false).ToList();
                foreach (var loggedExercise in le.GroupBy(x => x.Exercise))
                {
                    res.Add(loggedExercise.Key.Name, loggedExercise);
                }

            }
            catch (Exception ex)
            {
                Response.StatusCode = 404;
                Response.StatusDescription = ex.Message;
            }
            return Json(res.Select(x => new { Exercise = x.Key, Sets = x.Value }), JsonRequestBehavior.AllowGet);
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
            var date = session.Date;
            var data = new List<string>();
            foreach (var e in expression.Trim().Trim(';').Split(';'))
            {
                data.Add(e);
            }
            ParserHelper.ParseLog(db, GetUserId(), session.Comment, date, data, perssist: true, session: session).ToList();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}