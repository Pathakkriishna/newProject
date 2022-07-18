using newProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace newProject.Controllers
{
    public class SignInController : Controller
    {
        newsDatabaseEntities db = new newsDatabaseEntities();
        // GET: SignUp
        public ActionResult register()
        {
            List<admin> all_data = db.admins.ToList();
            return View(all_data);
        }

        public ActionResult addAdmin(string firstName, string lastName, int adminId, string password, string address,  string number, string email, string country )
        {
          


            admin value = new admin();
            value.firstName = firstName;
            value.lastName = lastName;
            value.adminId = adminId;
            value.password = password;
            value.email = email;
            value.number = number;
            value.address = address;
            value.country = country;
            db.admins.Add(value);
            //db.Users.Add(userImg);
            db.SaveChanges();
            return RedirectToAction("loginPage", "adminLogin");

        }
    }
}