using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public class SchoolSituationStatisticsMiddle
    {
        public string SchoolName { get; set; }

        public string SchoolCode { get; set; }
        /// <summary>
        /// 流感
        /// </summary>
        public int HealthType1 { get; set; }
        /// <summary>
        /// 麻疹 
        /// </summary>
        public int HealthType2 { get; set; }
        /// <summary>
        /// 水痘
        /// </summary>
        public int HealthType3 { get; set; }
        /// <summary>
        /// 猩红热
        /// </summary>
        public int HealthType4 { get; set; }
        /// <summary>
        /// 诺如
        /// </summary>
        public int HealthType5 { get; set; }
        /// <summary>
        /// 其它
        /// </summary>
        public int HealthType6 { get; set; }
    }
}
