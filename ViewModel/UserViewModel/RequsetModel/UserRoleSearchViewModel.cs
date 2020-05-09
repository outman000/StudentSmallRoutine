using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.UserViewModel.RequsetModel
{
    /// <summary>
    /// 角色查询视图
    /// </summary>
    public class UserRoleSearchViewModel
    {
        /// <summary>
        /// 岗位名称
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// 岗位编号
        /// </summary>
        public string StaffCode { get; set; }
        /// <summary>
        /// 页码
        /// </summary>
        public PageViewModel pageViewModel { get; set; }

        UserRoleSearchViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
