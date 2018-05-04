using salahuddinahmed.HelperClasses;
using salahuddinahmed.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace salahuddinahmed.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ShowDetails(string id)
        {
            string decryptedID = ParameterEncryption.Decrypt(HttpUtility.UrlDecode(id));
            int decryptedIDInt = 0;
            if (int.TryParse(decryptedID, out decryptedIDInt) ==false)
            {
                return Content("<h2 style='text-align:center;color:red; margin-top:20%'>An Error Occoured While Log In</h2>");
            }
            DBContext DB = new DBContext();
            Information info = DB.Information.Where(x => x.Id == decryptedIDInt).FirstOrDefault();

            
            return View(info);
        }
    }
}