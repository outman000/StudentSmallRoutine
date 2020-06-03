using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public  class DayAndNightAddMiddle
    {
        public int id { get; set; }


    
        public string SchoolName { get; set; }
      
        public string IdNumber { get; set; }

        public string Name { get; set; }
        public string GradeName { get; set; }

        public string ClassName { get; set; }

        public string Temperature { get; set; }
   
        public string IsComeSchool { get; set; }

       
        public string AddTimeInterval { get; set; }



        public string IsTianJin { get; set; }
 
        public string NotComeJinReason { get; set; }


        public DateTime? AddCreateDate { get; set; } = DateTime.Now;


        public string tag { get; set; }
    }
}
