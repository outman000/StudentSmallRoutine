using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel.HealthViewModel
{
    public  class StudentSearchHealthInfo
    {
        /// <summary>
        /// 学校编号
        /// </summary>
        public string SchoolCode { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        public string GradeCode { get; set; }
        /// <summary>
        /// 班级
        /// </summary>
        public string ClassCode { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string Idnumber { get; set; }


    }
}
