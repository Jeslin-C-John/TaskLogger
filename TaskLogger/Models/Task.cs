﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskLogger.Models
{
    public class Task
    {
        public string Date { get; set; }
        public int Empid { get; set; }
        public int Hours { get; set; }

        public int Status { get; set; }
    }
}