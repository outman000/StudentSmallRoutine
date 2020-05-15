using Dtol.Attribute;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dtol.dtol
{
    public class facultystaff_Info
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
        [ExcelAttribute("部门编号")]
        public string DepartCode { get; set; }
        [ExcelAttribute("部门")]
        public string DepartName { get; set; }
        [ExcelAttribute("岗位编号")]
        public string StaffCode { get; set; }
        [ExcelAttribute("岗位")]
        public string StaffName { get; set; }

        [ExcelAttribute("户籍地址")]
        public string PermanentAddress { get; set; }

        [ExcelAttribute("国籍")]
        public string Country { get; set; }
        [ExcelAttribute("身份证号/护照号")]
        public string IdNumber { get; set; }
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        public int? station_InfoId { get; set; }
        public Station_Info station_Info { get; set; }



        //健康信息外键
        public int? StudentRegisterHeath_InfoId { get; set; }
        public StudentRegisterHeath_Info StudentRegisterHeath_Info { get; set; }
        //每日信息集合
        public List<Health_Info> Health_Info { get; set; }

        [ExcelAttribute("附件id")]
        public string tag { get; set; }

        //  public List<ClassManager_Relate>  classManager_Relates { get; set; }


    }
}
