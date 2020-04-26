using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SmallRoutine.RequestViewModel.ExceptStudentViewModel
{
    public class ExceptStudengSearchInfoVIewModel
    {
        /// <summary>
        /// 教师唯一主键
        /// </summary>
        public int userKey { get; set; }
        /// <summary>
        /// 年级code
        /// </summary>
        public string GradeCode { get; set; }
        /// <summary>
        /// 班级名称
        /// </summary>
        public string ClassCode { get; set; }
        /// <summary>
        /// 填报时间
        /// </summary>
        public string CreateDate { get; set; }


        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        ExceptStudengSearchInfoVIewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
