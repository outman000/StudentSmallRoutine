using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public  class DefaultDayAndNightMiddle
    {
      
        public int id { get; set; }
        public string SchoolName { get; set; }

      
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string GradeName { get; set; }
        public string ClassName { get; set; }
        public string Temperature { get; set; }
        public string IsComeSchool { get; set; }
        public string IsTianJin { get; set; }
        public string NotComeJinReason { get; set; }
        /// <summary>
        /// 是否上传
        /// </summary>
        public string isup { get; set; }
        public DateTime? addCreatedate { get; set; }
        public string AddTimeInterval { get; set; }
        public string ClassCode { get; set; }
        public string GradeCode { get; set; }
        public string SchoolCode { get; set; }
    }
}
