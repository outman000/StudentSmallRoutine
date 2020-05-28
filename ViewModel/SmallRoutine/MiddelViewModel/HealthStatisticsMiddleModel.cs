using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public class HealthStatisticsMiddleModel
    {
        /// <summary>
        /// 学生健康上报数
        /// </summary>
        public int StudentHealthCount { get; set; }
        /// <summary>
        /// 学生健康填报率  未乘100
        /// </summary>
        public string StudentHealthRate { get; set; }
        /// <summary>
        /// 教职工健康上报数
        /// </summary>
        public int FacultystaffHealthCount { get; set; }
        /// <summary>
        /// 教职工健康填报率  未乘100
        /// </summary>
        public string FacultystaffHealthRate { get; set; }
        /// <summary>
        /// 1-6年级学生上报
        /// </summary>
        public int PrimaryCount { get; set; }
        /// <summary>
        /// 7-9年级学生上报
        /// </summary>
        public int JuniorCount { get; set; }
        /// <summary>
        /// 10-12年级学生上报
        /// </summary>
        public int HighCount { get; set; }
    }
}
