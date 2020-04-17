using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel.FacultystaffViewModel
{
    public  class AddRelateFromStaffToClassViewModel
    {
        /// <summary>
        /// 班级Id
        /// </summary>
        public int? Class_InfoId { get; set; }
        /// <summary>
        /// 职工Id
        /// </summary>
        public int? facultystaff_InfoId { get; set; }
    }
}
