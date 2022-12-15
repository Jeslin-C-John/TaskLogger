using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TaskLogger.Models;

namespace TaskLogger.Controllers
{
    public class AddController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Name = Session["Name"];
            return View();
        }

        [HttpPost]
        public ActionResult Index(Task instance)
        {
            ViewBag.Name = Session["Name"];
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-28UGTAO;Initial Catalog=TaskLogger;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("addtask", con))
                    {
                        //if (instance.StringStatus == 'y' || instance.StringStatus == 'Y')
                        //{
                        //    instance.BoolStatus = true;
                        //}
                        //else
                        //{
                        //    instance.BoolStatus = false;
                        //}
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@empid", Session["id"]);
                        cmd.Parameters.AddWithValue("@date", instance.Date);
                        cmd.Parameters.AddWithValue("@hours", instance.Hours);
                        cmd.Parameters.AddWithValue("@status", instance.BoolStatus);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }

                }
                return RedirectToAction("Index", "View", new { area = "" });
        }
            return View();
    }
    }
}