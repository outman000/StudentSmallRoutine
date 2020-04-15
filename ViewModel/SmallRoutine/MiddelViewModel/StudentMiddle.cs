using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public class StudentMiddle
    {
        public int id { get; set; }
        //姓名
        public string Name { get; set; }
        //性别
        public string Sex { get; set; }
        //出生年月
        public DateTime? Birthday { get; set; }
        //学校标识
        public string SchoolCode { get; set; }
        //学校名称
        public string SchoolName { get; set; }
        //年级标识
        public string GradeCode { get; set; }
        //年级
        public string GradeName { get; set; }
        //班级标识
        public string ClassCode { get; set; }
        //班级
        public string ClassName { get; set; }
        //国籍
        public string Country { get; set; }
        //身份证号/护照号
        public string IdNumber { get; set; }
        //户籍地址
        public string PermanentAddress { get; set; }
        //创建时间
        public DateTime? CreateDate { get; set; }
    }
}
