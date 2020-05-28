using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SmallRoutine.RequestViewModel.StatasticViewModel
{
    public class HealthEverySearchStatasticViewModel
    {
        /// <summary>
        /// 日期 开始时间 
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 日期 结束时间 
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 学校编号  查询全部教职工和学生数据时该字段为空
        /// </summary>
        public string SchoolCode { get; set; }
        /// <summary>
        /// 到校前、天、早、午、晚类型   
        /// </summary>
        public string CheckType { get; set; }
        /// <summary>
        /// 年级（延展字段） 默认传递空值  --空值、高中、初中、小学 --
        /// </summary>
        public string GradeName { get; set; }
        /// <summary>
        /// 分页  CurrentPageNum当前页  计数从0开始
        /// </summary>
        public PageViewModel page { get; set; }
        HealthEverySearchStatasticViewModel()
        {
            page = new PageViewModel();
        }

    }
}
