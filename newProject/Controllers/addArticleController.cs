using newProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;


namespace newProject.Controllers
{
    public class addArticleController : Controller
    {
        newsDatabaseEntities db = new newsDatabaseEntities();
        // GET: addArticle
        public ActionResult addArticles()
        {
           
            return View();
        }
        public ActionResult saveData(article new2, HttpPostedFileBase SelectedImg, HttpPostedFileBase SelectedImg1)
        {
            string path = Server.MapPath("~/uploads");
            string file_name = SelectedImg.FileName;
            string new_path = path + "/" + file_name;
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SelectedImg.SaveAs(new_path);
            new2.articleImage = "~/uploads/" + file_name;

            string path1 = Server.MapPath("~/uploads");
            string file_name1 = SelectedImg1.FileName;
            string new_path1 = path1 + "/" + file_name1;
            if (Directory.Exists(path1))
            {
                Directory.CreateDirectory(path1);
            }
            SelectedImg1.SaveAs(new_path1);
            new2.authorimg = "~/uploads/" + file_name1;
            db.articles.Add(new2);
            db.SaveChanges();
            return RedirectToAction("recentArticles", "try");

        }
    }
}


        