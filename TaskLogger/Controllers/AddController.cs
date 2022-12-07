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
            return View();
        }

        [HttpPost]
        public ActionResult Index(Task instance)
        {
            Task taskobj = new Task();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-28UGTAO;Initial Catalog=TaskLogger;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("addtask", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@name", instance.Name);
                    //cmd.Parameters.AddWithValue("@email", instance.Email);
                    //cmd.Parameters.AddWithValue("@password", instance.EncryptPass);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }

            }
            return RedirectToAction("Index", "Login", new { area = "" });
        }
    }
}