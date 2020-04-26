using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel
{
    public  class DayAndNightUpdateViewModel
    {
        /// <summary>
        /// 教师唯一主键
        /// </summary>
        public int userKey { get; set; }
        /// <summary>
        /// 早午晚检主键
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 年纪名称
        /// </summary>
        public string GradeName { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 是否来过学校
        /// </summary>
        public string IsComeSchool { get; set; }
        /// <summary>
        /// 填报时间
        /// </summary>
        public string AddTimeInterval { get; set; }

        public DateTime? AddCreateDate { get; set; }

    }
}
