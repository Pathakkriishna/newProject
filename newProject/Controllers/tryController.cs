using newProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace newProject.Controllers
{
    public class tryController : Controller
    {
        newsDatabaseEntities db = new newsDatabaseEntities();
        // GET: try
        public ActionResult tryPage()
        {
            List<recentNew> all_data = db.recentNews.ToList();
            return View(all_data);
        }


        public ActionResult Delete(int newsId)
        {
            recentNew data = db.recentNews.Find(newsId);
            db.recentNews.Remove(data);
            db.SaveChanges();
            return RedirectToAction("tryPage");
        }

        public ActionResult edit101(int newsID)
        {
            recentNew old_data = db.recentNews.Find(newsID);
            return View(old_data);
        }
        public ActionResult updateData(recentNew series, HttpPostedFileBase SelectedImg)
        {
            recentNew value = db.recentNews.Find(series.newsId);
            value.newsId = series.newsId;
            value.newsDescription = series.newsDescription;
            value.imageCaption = series.imageCaption;
            value.author = series.author;
            value.newsDate = series.newsDate;
            value.newsDetail = series.newsDetail;
            string path = Server.MapPath("~/uploads");
            string file_name = SelectedImg.FileName;
            string new_path = path + "/" + file_name;
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SelectedImg.SaveAs(new_path);
            value.newsImage = "~/uploads/" + file_name;

            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("tryPage", "try");

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
            return RedirectToAction("tryPage", "try");
        }

    }
}