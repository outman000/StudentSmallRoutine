using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public class EmploySearchStationAllMiddle
    {

        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 管理人姓名
        /// </summary>
        public string emplyname { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DepartCode { get; set; }
        /// <summary>
        ///  岗位名称
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// 岗位编号
        /// </summary>
        public string StaffCode { get; set; }
    }
}
