using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public class StaffStationMiddleModel
    {
        /// <summary>
        /// 部门
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public string DepartName { get; set; }
    
        /// <summary>
        /// 岗位
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// /是否发热
        /// </summary>
        public string IsHot { get; set; }
        /// <summary>
        /// 是否咳嗽
        /// </summary>
        public string IsThroat { get; set; }
        /// <summary>
        /// 是否乏力
        /// </summary>
        public string IsWeak { get; set; }
        /// <summary>
        /// 家庭成员发热
        /// </summary>
        public string IsFamilyHot { get; set; }
        /// <summary>
        /// 家庭人员咳嗽
        /// </summary>
        public string IsFamilyThroat { get; set; }
        /// <summary>
        /// 家庭人员乏力
        /// </summary>
        public string IsFamilyWeakt { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? Createdate { get; set; }

        /// <summary>
        /// 是否到校
        /// </summary>
        public string IsComeSchool { get; set; }
        /// <summary>
        /// 未到校原因
        /// </summary>
        public string NotComeSchoolReason { get; set; }
        /// <summary>
        /// 是否接触
        /// </summary>
        public string IsTouch { get; set; }

        /// <summary>
        /// 早午晚
        /// </summary>
        public string CheckType { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        public string Temperature { get; set; }
        /// <summary>
        /// 是否参加聚合
        /// </summary>
        public string IsAggregate { get; set; }
        /// <summary>
        /// 是否参加聚合具体情况
        /// </summary>
        public string IsAggregateContain { get; set; }
        /// <summary>
        /// 是否在天津
        /// </summary>

        public string IsTianJin { get; set; }


        /// <summary>
        /// 补录
        /// </summary>
        public string IsBulu { get; set; }
    }
}
