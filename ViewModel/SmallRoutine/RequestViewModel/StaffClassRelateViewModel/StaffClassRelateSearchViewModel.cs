﻿using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.RequestViewModel.StaffClassRelateViewModel
{
    public class StaffClassRelateSearchViewModel
    {
        /// <summary>
        /// 查询人id
        /// </summary>
        public int UserKeyId { get; set; }
        /// <summary>
        /// 年级编号
        /// </summary>
        public String GradeCode{get;set;}
        /// <summary>
        /// 班级编号
        /// </summary>
        public String ClassCode { get; set; }
        /// <summary>
        /// 是否异常
        /// </summary>
        //public String IsEexception { get; set; }
        /// <summary>
        /// 是否到校
        /// </summary>
        public String isSchool { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        StaffClassRelateSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
