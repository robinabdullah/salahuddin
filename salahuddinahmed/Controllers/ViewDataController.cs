using salahuddinahmed.HelperClasses;
using salahuddinahmed.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace salahuddinahmed.Controllers
{
    public class ViewDataController : Controller
    {
        // GET: ViewData
        public ActionResult Show(string id)
        {
            string decryptedID = ParameterEncryption.Decrypt(HttpUtility.UrlDecode(id));
            int decryptedIDInt = 0;
            //return Content("<h2 style='text-align:center;color:red; margin-top:20%'>An Error Occoured While Processing</h2>" + decryptedID);
            if (int.TryParse(decryptedID, out decryptedIDInt) == false)
            {
                return Content("<h2 style='text-align:center;color:red; margin-top:20%'>An Error Occoured While Processing</h2>");
            }

            DBContext DB = new DBContext();
            Information info = null;

            info = DB.Information.Where(x => x.Id == decryptedIDInt).FirstOrDefault();
            ViewBag.imageSource = "http://salahuddinahmedhighschool.com/student_images/" + decryptedIDInt + ".jpg"; 
            return View("Show", info);
        }
        [HttpGet]
        public ActionResult uploadImage()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult uploadImage(int id)
        {
            var file = Request.Files[0];
            if (file.ContentLength > 0)
            {
                ///string filename = Path.GetFileName(file.FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();
                if (extension == ".jpg")
                {
                    string filename = string.Format("{0}{1}",id, extension);
                    string path = Path.Combine(Server.MapPath("/student_images"), filename);
                    file.SaveAs(path);
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json("ফাইল ফরম্যাট সঠিক নয়", JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json("ফাইল সঠিক নয়", JsonRequestBehavior.AllowGet);

            }
        }
        [HttpGet]
        public ActionResult IsImageExists(int id)
        {
            string filename = id + ".jpg";
            if(System.IO.File.Exists(Path.Combine(Server.MapPath("/student_images"), filename)))
                return Json(true, JsonRequestBehavior.AllowGet);
            else
                return Json(false, JsonRequestBehavior.AllowGet);

        }
    }
}