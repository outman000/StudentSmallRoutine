﻿using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel.SecondMiddleViewModel;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    /// <summary>
    /// 用户基础信息
    /// </summary>
    public class ValideMiddleViewModel
    {
        /// <summary>
        /// id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// 学校编号
        /// </summary>
        public string SchoolCode { get; set; }
        /// <summary>
        /// 学校名称
        /// </summary>
        public string SchoolName { get; set; }
        /// <summary>
        /// 年级编号
        /// </summary>
        public string GradeCode { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        public string GradeName { get; set; }
        /// <summary>
        /// 班级编号
        /// </summary>
        public string ClassCode { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 国际
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 户籍地址
        /// </summary>
        public string PermanentAddress { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 健康上报信息
        /// </summary>
        public StudentRegisterHeathInfoViewModel StudentRegisterHeathInfoViewModel { get; set; }




    }
}
