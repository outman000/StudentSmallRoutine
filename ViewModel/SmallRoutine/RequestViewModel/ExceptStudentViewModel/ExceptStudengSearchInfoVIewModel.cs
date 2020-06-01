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
        /// 姓名
        /// </summary>
        public string Name { get; set; }
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
        /// 体温
        /// </summary>

        public string Temperature { get; set; }//体温
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 学校编号
        /// </summary>
        public string SchoolCode { get; set; }
        /// <summary>
        /// 权限ID  登录时获取的RoleID
        /// </summary>
        public string RoleID { get; set; }

        /// <summary>
        /// 构造方法
        /// </summary>
        ExceptStudengSearchInfoVIewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
