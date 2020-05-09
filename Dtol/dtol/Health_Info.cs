using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Health_Info
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string IdNumber { get; set; }
        public string IsHot { get; set; }
        public string IsThroat { get; set; }
        public string IsWeak { get; set; }
        public string IsFamilyHot { get; set; }
        public string IsFamilyThroat { get; set; }
        public string IsFamilyWeakt { get; set; }
        public string IsComeSchool { get; set; }
        public string IsTouch { get; set; }
        public string Temperature { get; set; }//体温
        public string CheckType { get; set; }//晨午晚
        public string IsAggregate { get; set; }//是否参加聚合
        public string IsAggregateContain { get; set; }//是否参加聚合具体情况
        public DateTime? Createdate { get; set; } = DateTime.Now;

   


        public int? facultystaff_InfoId { get; set; }
        public facultystaff_Info facultystaff_Info { get; set; }
        public int? Student_InfoId { get; set; }
        public Student_Info Student_Info { get; set; }

        /// <summary>
        /// 户籍地址
        /// </summary>
        public string PermanentAddress { get; set; }
    }
}
