
using newProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newProject.Controllers
{
    public class adminLoginController : Controller
    {
        newsDatabaseEntities db = new newsDatabaseEntities();
        // GET: adminLoginPage
        public ActionResult loginPage()
        {
            return View();
        }
        public ActionResult checkID(int adminId, string password)
        {
            var countId = db.admins.Where(x => x.adminId == adminId);
            var countPassword = db.admins.Where(x => x.password == password);
            if (countId.Count() == 0 || countPassword.Count() == 0)
            {
                Session["error1"] = "false";
                return RedirectToAction("loginPage");
            }
            

            return RedirectToAction("tryPage","try");
        }
    }
}