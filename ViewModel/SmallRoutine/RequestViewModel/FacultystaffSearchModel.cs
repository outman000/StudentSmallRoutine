using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel
{
    public class FacultystaffSearchModel
    {
        //姓名
        public string Name { get; set; }

        //学校标识
        public string SchoolCode { get; set; }

        //部门标识
        public string DepartCode { get; set; }

        //岗位标识
        public string StaffCode { get; set; }

        //身份证号/护照号
        public string IdNumber { get; set; }

        //户籍地址
        public string PermanentAddress { get; set; }
    }
}
