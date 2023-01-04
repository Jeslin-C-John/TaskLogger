﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TaskLogger.Models;
using System.Web.Security;

namespace TaskLogger.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Request.Cookies["AutoLogin"] != null || Request.QueryString["autologin"] != null)
            {
                FormsAuthentication.SetAuthCookie("AutoLoginUser", true);
                return RedirectToAction("ResView", "View");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(UserLogin instance)
        {
            
            
            
            if (ModelState.IsValid)
            {
                UserSignup DataModelobj = new UserSignup();
            using (SqlConnection con = new SqlConnection("Data Source=HP_5300U;Initial Catalog=TaskLogger;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("login", con))
                {


                    using (SHA256 sha256Hash = SHA256.Create())
                    {
                        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(instance.Password));
                        StringBuilder builder = new StringBuilder();
                        for (int i = 0; i < bytes.Length; i++)
                        {
                            builder.Append(bytes[i].ToString("x2"));
                        }
                        instance.EncryptPass = builder.ToString();
                    }

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@email", instance.Email);
                    cmd.Parameters.AddWithValue("@password", instance.EncryptPass);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    if (sdr.Read())
                    {
                        instance.id = sdr.GetInt32(0);
                        Session["id"] = instance.id;

                        instance.Name = sdr.GetString(1);
                        Session["Name"] = instance.Name.ToString();

                            FormsAuthentication.SetAuthCookie(instance.Email, instance.RememberMe);
                            
                        return RedirectToAction("Index", "View", new { area = "" });
                    }
                    con.Close();

                        ViewBag.Message = "Invalid Credentials!";
                    }

            }


        }
            
            return View();
        }
    }
}