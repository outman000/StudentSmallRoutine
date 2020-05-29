using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel.SecondMiddleViewModel;

namespace ViewModel.SmallRoutine.MiddelViewModel
{
    public class ValideMiddleEmployMiddleModel
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
        /// 国际
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNumber { get; set; }
        /// <summary>
        /// 部门编号
        /// </summary>
        public string DepartCode { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        public string DepartName { get; set; }
        /// <summary>
        /// 岗位编号
        /// </summary>
        public string StaffCode { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// 户籍地址
        /// </summary>
        public string PermanentAddress { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 权限标识 sys、admin、con、per
        /// </summary>
        public string RoleID { get; set; }

        /// <summary>
        /// 健康上报信息
        /// </summary>
        public StudentRegisterHeathInfoViewModel  studentRegisterHeathInfoViewModel { get; set; }
    }
}
