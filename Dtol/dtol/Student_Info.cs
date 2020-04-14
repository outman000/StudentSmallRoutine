using Dtol.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class Student_Info
    {
       
        public int id { get; set; }
        [ExcelAttribute("姓名")]
        public string Name { get; set; }
        [ExcelAttribute("性别")]
        public string Sex { get; set; }
        [ExcelAttribute("出生年月")]
        public DateTime? Birthday { get; set; }
        [ExcelAttribute("学校标识")]
        public string SchoolCode { get; set; }
        [ExcelAttribute("学校名称")]
        public string SchoolName { get; set; }
        [ExcelAttribute("年级标识")]
        public string GradeCode { get; set; }
        [ExcelAttribute("年级")]
        public string GradeName { get; set; }
        [ExcelAttribute("班级标识")]
        public string ClassCode { get; set; }
        [ExcelAttribute("班级")]
        public string ClassName { get; set; }
        [ExcelAttribute("国籍")]
        public string Country { get; set; }
        [ExcelAttribute("身份证号/护照号")]
        public string IdNumber { get; set; }
        [ExcelAttribute("户籍地址")]
        public string PermanentAddress  { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        public Class_Info class_InfoId { get; set; }
        public Class_Info class_Info { get; set; }

        public int? Health_InfoId { get; set; }
        public Health_Info Health_Info { get; set; }
        [ExcelAttribute("附件id")]
        public string tag { get; set; }
    }
}
