using newProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newProject.Controllers
{
   
    public class HomeController : Controller
    {
        newsDatabaseEntities db = new newsDatabaseEntities();
        public ActionResult Index()
        {
            List<recentNew> all_data = db.recentNews.ToList();
                return View(all_data);
        }
        public ActionResult read(int id)
        {
            var data = db.recentNews.Where(x => x.newsId == id).ToList();
            return View("newsDetails1",data);
        }
        public ActionResult newsDetails1()
        {
            List<recentNew> all_data = db.recentNews.ToList();
            return View(all_data);
        }

        public ActionResult About()
        {
           

            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }
        public ActionResult Lifestyle()
        {
            

            return View();
        }
    }
}