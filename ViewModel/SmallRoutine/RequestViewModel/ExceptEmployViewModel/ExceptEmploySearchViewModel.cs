using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SmallRoutine.RequestViewModel.ExceptEmployViewModel
{
    public class ExceptEmploySearchViewModel
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
        /// 身份证号
        /// </summary>
        public string Idnumber { get; set; }
         /// <summary>
         /// 部门编号
         /// </summary>
        public string DepartCode { get; set; }
        /// <summary>
        /// 岗位编号
        /// </summary>
        public string StaffCode{ get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 填报时间
        /// </summary>
        public string CreateDate { get; set; }
        /// <summary>
        /// 体温
        /// </summary>
        public string Temperature { get; set; }//体温
        /// <summary>
        /// 学校编号
        /// </summary>
        public string SchoolCode { get; set; }
        /// <summary>
        /// 分页
        /// </summary>
        public PageViewModel pageViewModel { get; set; }
        /// <summary>
        /// 构造方法
        /// </summary>
        ExceptEmploySearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
