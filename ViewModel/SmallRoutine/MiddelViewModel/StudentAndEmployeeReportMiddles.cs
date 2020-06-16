using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public class StudentAndEmployeeReportMiddles
    {
        /// <summary>
        /// 学校Code
        /// </summary>
        public string SchoolCode { get; set; }
        /// <summary>
        /// 学校
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 学生or教职工
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 应到校人数
        /// </summary>
        public double ShouldComeSchoolCount { get; set; }
        /// <summary>
        /// 实际到校人数
        /// </summary>
        public double ActualComeSchoolCount { get; set; }
        /// <summary>
        /// 到校后发热学生
        /// </summary>
        public double ComeSchoolHotCount { get; set; }
        /// <summary>
        /// 未到校人数
        /// </summary>
        public double NotComeSchoolCount { get; set; }
        /// <summary>
        /// 因为在外地所以未到校的人数
        /// </summary>
        public double NotComeSchoolByOutCount { get; set; }
        /// <summary>
        /// 因为发热未到校
        /// </summary>
        public double NotComeSchoolByHotCount { get; set; }
        /// <summary>
        /// 因为其他原因未到校
        /// </summary>
        public double NotComeSchoolByOtherCount { get; set; }

        /// <summary>
        /// 健康填报率
        /// </summary>
        public string HealthRate { get; set; }
    }
}
