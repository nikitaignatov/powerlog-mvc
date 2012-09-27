using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PowerLog.Models;
using Sprache;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PowerLog.Controllers
{
    public class ExerciseLogController : Controller
    {
        private DB db = new DB();

        //
        // GET: /ExerciseLog/

        public ActionResult Index()
        {
            var logs = db.Logs.Include(e => e.Exercise);
            return View(logs.ToList());
        }

        //
        // GET: /ExerciseLog/Details/5

        public ActionResult Details(int id = 0)
        {
            ExerciseLog exerciselog = db.Logs.Find(id);
            if (exerciselog == null)
            {
                return HttpNotFound();
            }
            return View(exerciselog);
        }

        //
        // GET: /ExerciseLog/Create

        public ActionResult Create()
        {
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name");
            return View();
        }

        //
        // POST: /ExerciseLog/Create


        

        [HttpPost]
        public ActionResult Create(ExerciseLog exerciselog, string expression)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Logs.Add(exerciselog);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", exerciselog.ExerciseID);
                    return View(exerciselog);
                }
            }

            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", exerciselog.ExerciseID);
            return View(exerciselog);
        }

        //
        // GET: /ExerciseLog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ExerciseLog exerciselog = db.Logs.Find(id);
            if (exerciselog == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", exerciselog.ExerciseID);
            return View(exerciselog);
        }

        //
        // POST: /ExerciseLog/Edit/5

        [HttpPost]
        public ActionResult Edit(ExerciseLog exerciselog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciselog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseID = new SelectList(db.Exercises, "ID", "Name", exerciselog.ExerciseID);
            return View(exerciselog);
        }

        //
        // GET: /ExerciseLog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ExerciseLog exerciselog = db.Logs.Find(id);
            if (exerciselog == null)
            {
                return HttpNotFound();
            }
            return View(exerciselog);
        }

        //
        // POST: /ExerciseLog/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ExerciseLog exerciselog = db.Logs.Find(id);
            db.Logs.Remove(exerciselog);
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