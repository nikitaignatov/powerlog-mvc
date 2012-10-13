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

namespace PowerLog.Web.Controllers
{
    public class ExerciseController : Controller
    {
        private DB db = new DB();

        //
        // GET: /Exercise/

        public ActionResult Get(string q)
        {
            q = q.Trim().ToLower();
            var names = FindNames(q).Distinct().ToList();
            // throw  new Exception("Names:"+ string.Join("\n",names));
            return Json(names, JsonRequestBehavior.AllowGet);
        }

        class FuncComparer<T> : IComparer<T>
        {
            private readonly Comparison<T> comparison;
            public FuncComparer(Comparison<T> comparison)
            {
                this.comparison = comparison;
            }
            public int Compare(T x, T y)
            {
                return comparison(x, y);
            }
        }

        private IEnumerable<string> FindNames(string query)
        {
            var keywords = query.ToLower().Split(' ');
            var letters = query.ToArray();
            var list = new SortedList<int, SortedSet<string>>();
            foreach (var name in db.Exercises.Select(x => x.Name).ToList())
            {
                int matches = 0;
                foreach (var keyword in keywords)
                    if (name.ToLower().Contains(keyword))
                        matches++;
                if (matches == keywords.Count())
                {
                    if (list.ContainsKey(matches))
                        list[matches].Add(name);
                    else
                        list.Add(matches, new SortedSet<string>(new FuncComparer<string>((a, b) => a.Length.CompareTo(b.Length))) { name });
                }
            }
            return list.SelectMany(x => x.Value);
        }


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