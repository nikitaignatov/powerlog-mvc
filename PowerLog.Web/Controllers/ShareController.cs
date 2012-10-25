using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PowerLog.Data;
using PowerLog.Model;
using PowerLog.Parser;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using PowerLog.Web.Filters;
using WebMatrix.WebData;

namespace PowerLog.Web.Controllers
{
    public class ShareController : Controller
    {
        private UsersContext db = new UsersContext();

        public ActionResult Index()
        {
            var shared = db.TrainingSessions.Where(x => x.IsPublic && x.IsShared).Include(x => x.UserProfile).ToList();
            return View(shared);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(LoggedExercise loggedexercise, string expression, string title)
        {
            if (!string.IsNullOrWhiteSpace(expression))
            {
                var userId = WebSecurity.GetUserId(User.Identity.Name);
                var session = new TrainingSession
                {
                    Date = loggedexercise.Date,
                    Key = string.Empty.RandomString(10),
                    UserId = userId,
                    Title = title,
                    IsPublic = true,
                    IsShared = true,
                    LoggedExercises = new List<LoggedExercise>()
                };
                SaveSession(session, expression);
                Session["clearLocalStorage"] = true;
                return RedirectToAction("Shared", new { key = session.Key });
            }
            else if (ModelState.IsValid)
            {
                db.LoggedExercises.Add(loggedexercise);
                db.SaveChanges();
                return RedirectToAction("Shared");
            }

            return View();
        }

        public ActionResult Shared(string key = null)
        {
            var loggedexercise = db.TrainingSessions.Where(x => x.IsShared).SingleOrDefault(x => x.Key == key);
            if (loggedexercise == null)
            {
                return HttpNotFound();
            }

            var download = (from e in loggedexercise.LoggedExercises
                            select new
                            {
                                e.Date,
                                e.Exercise.Name,
                                e.Reps,
                                e.Weight,
                                e.OneRepMax,
                                e.Load,
                                e.Comment
                            }).ToList();

            SetJson(download);
            SetCsv(download);
            if (Session["clearLocalStorage"] != null && (bool)Session["clearLocalStorage"])
            {
                ViewBag.ClearLocalStorage = true;
                Session["clearLocalStorage"] = null;
            }
            return View(loggedexercise);
        }

        // [HttpPost]
        public ActionResult PreviewLog(DateTime date, string expression, string comment)
        {
            var data = new Dictionary<DateTime, List<string>> { { date, new List<string>() } };
            foreach (var e in expression.Split(';'))
            {
                if (data.ContainsKey(date))
                    data[date].Add(e);
            }
            return Json(ParserHelper.ParseLog(db, GetUserId(), comment, data).ToList(), JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private void SetJson<T>(List<T> list)
        {
            var options = new JsonSerializerSettings();
            options.Formatting = Formatting.Indented;
            var serializer = JsonSerializer.Create(options);
            var sb = new StringWriter();
            serializer.Serialize(sb, list);
            ViewBag.json = sb.ToString();
        }

        private void SetCsv<T>(List<T> list)
        {
            ViewBag.csv = ServiceStack.Text.CsvSerializer.SerializeToCsv(list);
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
    }

    public static class GenStringExt
    {
        private static readonly Random _rng = new Random();
        private const string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomString(this string val, int size)
        {
            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }
    }
}