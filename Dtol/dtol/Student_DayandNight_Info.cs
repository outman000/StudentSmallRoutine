using Dtol.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Student_DayandNight_Info
    {
        public int id {get;set;}
        [ExcelAttribute("学校名称（需与提供的学校全称完全一致）")]
        public string SchoolName { get; set; }
        [ExcelAttribute("姓名")]
        public string Name { get; set; }
        [ExcelAttribute("年级（需与提供的年级完全一致）")]
        public string GradeName { get; set; }
        [ExcelAttribute("班级（需与提供的班级完全一致）")]
        public string ClassName { get; set; }
        [ExcelAttribute("体温")]
        public string Temperature { get; set; }
        [ExcelAttribute("学生是否到校（默认是）")] 
        public string IsComeSchool { get; set; }
     
        [ExcelAttribute("填报时段（晨/午/晚）")]
        public string AddTimeInterval { get; set; }
        public DateTime? AddCreateDate { get; set; } = DateTime.Now;
    }
}
