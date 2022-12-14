using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskLogger.Models;

namespace TaskLogger.Controllers
{
    public class DeleteController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Task instance,int Taskid)

        {
            if (ModelState.IsValid)
            {

                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-28UGTAO;Initial Catalog=TaskLogger;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("deletetask", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@taskid", Taskid);

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