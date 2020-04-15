﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Health_Info
    {
        public int id { get; set; }
        public string IdNumber { get; set; }
        public string IsHot { get; set; }
        public string IsThroat { get; set; }
        public string IsWeak { get; set; }
        public string IsFamilyHot { get; set; }
        public string IsFamilyThroat { get; set; }
        public string IsFamilyWeakt { get; set; }
        public DateTime? Createdate { get; set; } = DateTime.Now;

        public int Student_InfoId { get; set; }
        public Student_Info Student_Info { get; set; } 
    }
}
