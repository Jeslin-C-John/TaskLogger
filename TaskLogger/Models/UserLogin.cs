using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskLogger.Models
{
    public class UserLogin
    {
        //[Required(ErrorMessage = "Name is required!")]
        //[StringLength(25)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Incorrect Password!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Invalid Email ID!")]
        [EmailAddress]
        public string Email { get; set; }

        public int id { get; set; }
        public string EncryptPass { get; set; }

        public bool RememberMe { get; set; }
    }
}