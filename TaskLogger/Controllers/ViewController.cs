using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskLogger.Models;
using System.Reflection;
using System.Globalization;

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
        public ActionResult Index(ViewTask e)
        {
            ViewBag.Name = Session["Name"];

            if (e.StartDate == null)
            {
                var StringStartDate = "1753-01-01";
                DateTime.TryParse(StringStartDate, out var StartDateConv);
                e.StartDate = StartDateConv;
            }
            if (e.EndDate == null)
            {
                DateTime NowDate= DateTime.Now;
                e.EndDate = NowDate;
            }

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
                        instance.Date = rdr.GetDateTime(1);
                        instance.ShortDate = instance.Date.ToString("yyyy-MM-dd");
                        instance.Hours = rdr.GetInt32(2);
                        instance.BoolStatus = rdr.GetBoolean(3);
                        if (instance.BoolStatus == false)
                        { instance.StringStatus = 'N'; }
                        else
                        { instance.StringStatus = 'Y'; }

                        DataList.Add(instance);

                    }
                    con.Close();
                    return View("ResView",DataList);
                }

            }

        }

    }
}
