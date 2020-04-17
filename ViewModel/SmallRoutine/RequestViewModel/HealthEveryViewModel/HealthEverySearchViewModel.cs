using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.RequestViewModel.HealthEveryViewModel
{
    public  class HealthEverySearchViewModel
    {
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
        /// 是否接触
        /// </summary>
        public string IsTouch { get; set; }

        /// <summary>
        /// 体温
        /// </summary>
        public string Temperature { get; set; }//体温

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        HealthEverySearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
