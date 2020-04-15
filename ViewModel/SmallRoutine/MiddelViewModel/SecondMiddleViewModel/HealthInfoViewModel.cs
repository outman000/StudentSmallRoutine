using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel.SecondMiddleViewModel
{
     public  class HealthInfoViewModel
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

    }
}
