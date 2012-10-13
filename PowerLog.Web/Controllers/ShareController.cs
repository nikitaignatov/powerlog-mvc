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

namespace PowerLog.Web.Controllers
{
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

    public class ShareController : Controller
    {
        private DB db = new DB();

        //
        // GET: /LoggedExercise/

        public ActionResult Index()
        {
            db.Configuration.ProxyCreationEnabled = false;
            var list = new List<LoggedExercise>();
            //   list = db.LoggedExercises.Include(x => x.Exercise).ToList();
            var e = @"
barbell bench press 3x20 3x40 3x60 3x80 3x90 3x95 3x100-max;
barbell incline bench press 12x40 10x50 10x60 8x70 6x70 6x60;
dumbbell fly 12x14 10x18 5x24 5x22 5x6x18";
            ViewBag.Hash = string.Empty.RandomString(6);
            list.AddRange(ParserHelper.ParseLog(db, DateTime.Now, e
                  ));

            SetJson(list);

            SetXml(list);
            SetCsv(list);


            return View(list);
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

        private void SetXml<T>(List<T> list)
        {
            var x = new XmlSerializer(list.GetType());
            var sb = new StringWriter();
            x.Serialize(sb, list);
            ViewBag.xml = sb.ToString();
        }

        //
        // GET: /LoggedExercise/Details/5

        public ActionResult Shared(string id = null)
        {
            var loggedexercise = db.SharedExercises.SingleOrDefault(x => x.ID == id);
            if (loggedexercise == null)
            {
                return HttpNotFound();
            }
            SetJson(loggedexercise.LoggedExercises.ToList());
            SetCsv(loggedexercise.LoggedExercises.ToList());
            return View(loggedexercise);
        } 

        //
        // POST: /LoggedExercise/Create

        [HttpPost]
        public ActionResult Share(LoggedExercise loggedexercise, string expression, string title)
        {
            if (!string.IsNullOrWhiteSpace(expression))
            {
                var shared = new SharedExercise
                                 {
                                     ID = string.Empty.RandomString(10),
                                     Title = title,
                                     LoggedExercises = new List<LoggedExercise>()
                                 };
                foreach (var log in ParserHelper.ParseLog(db, loggedexercise.Date, expression))
                {
                    db.LoggedExercises.Add(log);
                    shared.LoggedExercises.Add(log);
                }
                db.SaveChanges();
                db.SharedExercises.Add(shared);
                db.SaveChanges();
                return RedirectToAction("Shared", new { id = shared.ID });
            }
            else if (ModelState.IsValid)
            {
                db.LoggedExercises.Add(loggedexercise);
                db.SaveChanges();
                return RedirectToAction("Shared");
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