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
using System.Reflection;

namespace TaskLogger.Controllers
{
    public class ViewController : Controller
    {
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Index()
        {
            
            var DataList = new List<Task>();
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-28UGTAO;Initial Catalog=TaskLogger;Integrated Security=True"))
            {
                
                using (SqlCommand cmd = new SqlCommand("viewtask", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@empid", Session["id"]);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {

                        var instance = new Task();
                        instance.Taskid = rdr.GetInt32(0);
                        instance.Date = rdr.GetString(1);
                        instance.Hours = rdr.GetInt32(2);
                        instance.IntStatus = rdr.GetInt32(3);
                        if (instance.IntStatus==0)
                        { instance.StringStatus = "Incomplete"; }
                        else
                        { instance.StringStatus = "Completed"; }

                        DataList.Add(instance);
                    }
                    con.Close();

                }

            }
            return View(DataList);
        }
         
    }
}