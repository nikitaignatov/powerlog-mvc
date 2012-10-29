using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PowerLog.Model;
using PowerLog.Data;

namespace PowerLog.Web.Controllers
{
    public class ProfileController : Controller
    {
        private UsersContext db = new UsersContext();

        public ActionResult WeightSettings()
        {
            var id = this.GetUserId();
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        [HttpPost]
        public ActionResult WeightSettings(WeightUnit weightUnitsValue)
        {
            var id = this.GetUserId();
            UserProfile userprofile = db.UserProfiles.Find(id);

            if (new[] { 0, 1 }.Contains((int)weightUnitsValue))
            {
                userprofile.WeightUnits = weightUnitsValue;
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Dashboard");
            }

            return View(userprofile);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}