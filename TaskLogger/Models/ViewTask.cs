using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace TaskLogger.Models
{
    public class ViewTask
    {
        //[Required(ErrorMessage = "Start Date is required!")]
        public DateTime? StartDate { get; set; }

        //[Required(ErrorMessage = "End Date is required!")]
        public DateTime? EndDate { get; set; }
    }
}