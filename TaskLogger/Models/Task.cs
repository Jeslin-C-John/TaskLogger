using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskLogger.Models
{
    public class Task
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public int Hours { get; set; }

        public bool Status { get; set; }
    }
}