using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PowerLog.Models;

namespace PowerLog.Controllers
{
    public class ExerciseController : Controller
    {
        private DB db = new DB();

        //
        // GET: /Exercise/

        public ActionResult Index()
        {
            return View(db.Exercises.ToList());
        }

        //
        // GET: /Exercise/Details/5

        public ActionResult Details(int id = 0)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        //
        // GET: /Exercise/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Exercise/Create

        [HttpPost]
        public ActionResult Create(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Exercises.Add(exercise);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(exercise);
        }

        //
        // GET: /Exercise/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        //
        // POST: /Exercise/Edit/5

        [HttpPost]
        public ActionResult Edit(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exercise).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(exercise);
        }

        //
        // GET: /Exercise/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Exercise exercise = db.Exercises.Find(id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        //
        // POST: /Exercise/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Exercise exercise = db.Exercises.Find(id);
            db.Exercises.Remove(exercise);
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