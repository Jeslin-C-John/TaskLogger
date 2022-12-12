using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using TaskLogger.Models;
using System.Security.Cryptography;
using System.Text;

namespace TaskLogger.Controllers
{
    public class SignupController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserSignup instance)
        {
            if (ModelState.IsValid)
            {
                UserSignup DataModelobj = new UserSignup();
                using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-28UGTAO;Initial Catalog=TaskLogger;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand("signup", con))
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
                        cmd.Parameters.AddWithValue("@name", instance.Name);
                        cmd.Parameters.AddWithValue("@email", instance.Email);
                        cmd.Parameters.AddWithValue("@password", instance.EncryptPass);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                    }

                }
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            return View();
        }
    }
}