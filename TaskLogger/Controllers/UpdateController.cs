using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskLogger.Models;
using System.Threading.Tasks;

namespace TaskLogger.Controllers
{
    public class UpdateController : Controller
    {
        [HttpGet]
        public ActionResult Index(int Taskid)
        {
            ViewBag.Name = Session["Name"];
            using (SqlConnection con = new SqlConnection("Data Source=HP_5300U;Initial Catalog=TaskLogger;Integrated Security=True"))
            {

                using (SqlCommand cmd = new SqlCommand("viewupdate", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@taskid", Taskid);


                    con.Open();
              
                    SqlDataReader rdr = cmd.ExecuteReader();
                    var instance = new TaskLogger.Models.Task();

                    rdr.Read();
                        
                    instance.Date = rdr.GetDateTime(0);
                    instance.Hours = rdr.GetInt32(1);
                    instance.BoolStatus = rdr.GetBoolean(2);


                    con.Close();

                    return View(instance);
                }

            }

        }

        [HttpPost]
        public ActionResult Index(TaskLogger.Models.Task instance,int Taskid)
        {
            ViewBag.Name = Session["Name"];
            if (ModelState.IsValid)
            {

                using (SqlConnection con = new SqlConnection("Data Source=HP_5300U;Initial Catalog=TaskLogger;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("updatetask", con))
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
                        cmd.Parameters.AddWithValue("@taskid", Taskid);
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