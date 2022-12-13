using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace TaskLogger.Models
{
    public class Task
    {



        //[Required(ErrorMessage = "Date is required!")]
        public DateTime Date { get; set; }
        //public String StringDate { get; set; }




        public int Empid { get; set; }

        //[Required(ErrorMessage = "Hours are required!")]
        public int Hours { get; set; }


        //[Required(ErrorMessage = "Task ID is required!")]
        public int Taskid { get; set; }

        
        public bool BoolStatus { get; set; }

        //[Required(ErrorMessage = "Status is required!")]
        public char StringStatus { get; set; }

        public string ShortDate { get; set; }

        

    }
}