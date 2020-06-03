using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SmallRoutine.RequestViewModel.DayAndNightViewModel
{
    public class DayAndNightDefaultViewModel
    {
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNumber { get; set; }
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
        /// 是否来过学校
        /// </summary>
        public string IsComeSchool { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 填报时间
        /// </summary>
        public string AddTimeInterval { get; set; }
        /// <summary>
        /// 是否在津
        /// </summary>
        public string IsTianJin { get; set; }
        /// <summary>
        /// 未到校原因
        /// </summary>
        public string NotComeJinReason { get; set; }
    }
}
