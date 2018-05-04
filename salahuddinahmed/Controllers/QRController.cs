using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace salahuddinahmed.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        public ActionResult CNG(string id)
        {
            var month = DateTime.Now.ToString("MMMM", new CultureInfo("en-GB"));
            var year = DateTime.Now.Year;
            var regNo = "4586/09";

            var concat = string.Format("{0}, {1}<br> {2} Approved", month, year, regNo);

            if (id == "321987456214")
                return Content("<h2 style='text-align:center;color:green; margin-top:20%'>" + concat +" </h2>");
            else
                return Content("<h2 style='text-align:center;color:red; margin-top:20%'>Not Approved</h2>");
        }
    }
}