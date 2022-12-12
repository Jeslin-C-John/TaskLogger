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
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(Task e)
        {
            //if (ModelState.IsValid)
            //{

                var DataList = new List<Task>();
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-28UGTAO;Initial Catalog=TaskLogger;Integrated Security=True"))
                {

                    using (SqlCommand cmd = new SqlCommand("viewtask", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@empid", Session["id"]);
                        cmd.Parameters.AddWithValue("@startdate", e.StartDate);
                        cmd.Parameters.AddWithValue("@enddate", e.EndDate);


                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {

                            var instance = new Task();
                            instance.Taskid = rdr.GetInt32(0);
                            instance.StringDate = rdr.GetString(1);
                            instance.Hours = rdr.GetInt32(2);
                            instance.BoolStatus = rdr.GetBoolean(3);
                            if (instance.BoolStatus == true)
                            { instance.StringStatus = "Incomplete"; }
                            else
                            { instance.StringStatus = "Completed"; }

                            DataList.Add(instance);
                            return View("ResView", DataList);
                        }
                        con.Close();

                    }
                    
                }
                
            //}
            return View();
        }
         
    }
}   