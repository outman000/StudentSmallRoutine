﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public class EmployeeReportMiddleModel
    {

        public string SchoolName { get; set; }
        /// <summary>
        /// 应到校人数
        /// </summary>
        public int? ShouldComeSchoolCount { get; set; }
        /// <summary>
        /// 实际到校人数
        /// </summary>
        public int? ActualComeSchoolCount { get; set; }
        /// <summary>
        /// 到校后发热学生
        /// </summary>
        public int? ComeSchoolHotCount { get; set; }
        /// <summary>
        /// 未到校人数
        /// </summary>
        public int? NotComeSchoolCount { get; set; }
        /// <summary>
        /// 因为在外地所以未到校的人数
        /// </summary>
        public int? NotComeSchoolByOutCount { get; set; }
        /// <summary>
        /// 因为发热未到校
        /// </summary>
        public int? NotComeSchoolByHotCount { get; set; }
        /// <summary>
        /// 因为其他原因未到校
        /// </summary>
        public int? NotComeSchoolByOtherCount { get; set; }
    }
}
