using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskLogger.Controllers
{
    public class FilterController : Controller
    {
        // GET: Filter
        public ActionResult Index()
        {
            ViewBag.Name = Session["Name"];
            return RedirectToAction("Index", "DupView", new { area = "" });
        }
    }
}