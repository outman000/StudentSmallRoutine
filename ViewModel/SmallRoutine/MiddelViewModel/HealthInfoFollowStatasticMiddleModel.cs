using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public class HealthInfoFollowStatasticMiddleModel
    {
        /// <summary>
        /// 重点关注人数
        /// </summary>
        public int FollowPerson { get; set; }
        /// <summary>
        /// 到校发热人数
        /// </summary>
        public int IsComSchoolPerson { get; set; }
        /// <summary>
        /// 未到校人数
        /// </summary>
        public int NoCoSchoolPerson { get; set; }
    }
}
