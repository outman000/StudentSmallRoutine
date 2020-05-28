using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public class SchoolAndStudentTopReportMiddleModel
    {
        /// <summary>
        /// 复课学校数
        /// </summary>
        public int SchoolCount { get; set; }
        /// <summary>
        /// 复课学生应到人数
        /// </summary>
        public int StudentCount { get; set; }
        /// <summary>
        /// 复课学生实到人数
        /// </summary>
        public int StudentActualCount { get; set; }
        /// <summary>
        /// 复课职工应到人数
        /// </summary>
        public int FacultystaffCount { get; set; }
        /// <summary>
        /// 复课职工实到人数
        /// </summary>
        public int FacultystaffActualCount { get; set; }
    }
}
