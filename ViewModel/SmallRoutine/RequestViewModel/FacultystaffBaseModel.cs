using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel
{
    public  class FacultystaffBaseModel
    { 
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
        //部门标识
        public string DepartCode { get; set; }
        //部门
        public string DepartName { get; set; }
        //岗位标识
        public string StaffCode { get; set; }
        //岗位
        public string StaffName { get; set; }
        //国籍
        public string Country { get; set; }
        //身份证号/护照号
        public string IdNumber { get; set; }
        //户籍地址
        public string PermanentAddress { get; set; }
        public int? station_InfoId { get; set; }
    }
}
