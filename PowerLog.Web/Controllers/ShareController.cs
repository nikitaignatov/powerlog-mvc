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
using PowerLog.Web.Models;
using PowerLog.Parser;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using WebMatrix.WebData;

namespace PowerLog.Web.Controllers
{
    public class ShareController : Controller
    {
        private DB db = new DB();

        public ActionResult Index()
        {
            var shared = db.SharedExercises.Include(x => x.UserProfile).ToList();
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
                var shared = new SharedExercise
                {
                    ID = string.Empty.RandomString(10),
                    UserId = userId,
                    Title = title,
                    LoggedExercises = new List<LoggedExercise>()
                };
                foreach (var log in ParserHelper.ParseLog(db, loggedexercise.Date, expression))
                {
                    log.UserId = userId;
                    db.LoggedExercises.Add(log);
                    shared.LoggedExercises.Add(log);
                }
                db.SaveChanges();
                db.SharedExercises.Add(shared);
                db.SaveChanges();
                Session["clearLocalStorage"] = true;
                return RedirectToAction("Shared", new { id = shared.ID });
            }
            else if (ModelState.IsValid)
            {
                db.LoggedExercises.Add(loggedexercise);
                db.SaveChanges();
                return RedirectToAction("Shared");
            }

            return View();
        }

        public ActionResult Shared(string id = null)
        {
            var loggedexercise = db.SharedExercises.SingleOrDefault(x => x.ID == id);
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
        public ActionResult PreviewLog(DateTime date, string expression)
        {
            return Json(ParserHelper.ParseLog(db, date, expression), JsonRequestBehavior.AllowGet);
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
    }

    public static class GenStringExt
    {
        private static readonly Random _rng = new Random();
        private const string _chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_0123456789";

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