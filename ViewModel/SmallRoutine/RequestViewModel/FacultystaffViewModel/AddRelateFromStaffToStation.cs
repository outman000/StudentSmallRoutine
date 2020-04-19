using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel.FacultystaffViewModel
{
    public class AddRelateFromStaffToStation
    {
        /// <summary>
        /// 岗位编号
        /// </summary>
        public string StaffCode { get; set; }
        /// <summary>
        /// 班级Id
        /// </summary>
        public int? Station_InfoId { get; set; }
        /// <summary>
        /// 岗位身份证号
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 职工Id
        /// </summary>
        public int? facultystaff_InfoId { get; set; }
    }
}
