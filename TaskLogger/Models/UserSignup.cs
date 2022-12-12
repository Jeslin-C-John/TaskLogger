using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskLogger.Models
{
    public class UserSignup
    {
        [Required(ErrorMessage = "Name is required!")]
        [StringLength(25)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password is required!")]
        [StringLength(50, MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; }

        public int id { get; set; }
        public string EncryptPass { get; set; }
    }
}