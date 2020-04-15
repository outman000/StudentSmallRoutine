using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel
{
    public class StudentSearchModel
    {
        //姓名
        public string Name { get; set; }

        //学校标识
        public string SchoolCode { get; set; }

        //年级标识
        public string GradeCode { get; set; }

        //班级标识
        public string ClassCode { get; set; }

        //身份证号/护照号
        public string IdNumber { get; set; }

        //户籍地址
        public string PermanentAddress { get; set; }

    }
}
