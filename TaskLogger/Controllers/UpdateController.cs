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
    public class UpdateController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Task instance)
        {

            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-28UGTAO;Initial Catalog=TaskLogger;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("updatetask", con))
                {
                    if (instance.StringStatus == "y" || instance.StringStatus == "Y")
                    {
                        instance.IntStatus = 1;
                    }
                    else
                    {
                        instance.IntStatus = 0;
                    }
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@taskid", instance.Taskid);
                    cmd.Parameters.AddWithValue("@date", instance.Date);
                    cmd.Parameters.AddWithValue("@hours", instance.Hours);
                    cmd.Parameters.AddWithValue("@status", instance.IntStatus);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
            return RedirectToAction("Index", "Dashboard", new { area = "" });
        }
    }
}