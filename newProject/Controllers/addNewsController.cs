using newProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newProject.Controllers
{
    public class addNewsController : Controller
    {
        newsDatabaseEntities db = new newsDatabaseEntities();
        // GET: addNews
        public ActionResult addRecord()
        {
            return View();
        }
        
  

    public ActionResult saveData(recentNew new1, HttpPostedFileBase SelectedImg)
        {
            string path = Server.MapPath("~/uploads");
            string file_name = SelectedImg.FileName;
            string new_path = path + "/" + file_name;
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SelectedImg.SaveAs(new_path);
            new1.newsImage = "~/uploads/" + file_name;
            db.recentNews.Add(new1);
            db.SaveChanges();
            return RedirectToAction("recentNews" ,"try");
        }


    }
}