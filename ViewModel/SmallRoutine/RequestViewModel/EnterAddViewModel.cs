using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel
{
    public class EnterAddViewModel
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDnumber { get; set; }
        /// <summary>
        /// 网格名称
        /// </summary>
        public string GridName { get; set; }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 企业地址
        /// </summary>
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactMethod { get; set; }
        /// <summary>
        /// 来津类型
        /// </summary>
        public string residenttype { get; set; }
        /// <summary>
        /// 是否去过保底
        /// </summary>
        public string goBaoDI { get; set; }
        /// <summary>
        /// 目的企业
        /// </summary>
        public string AimCompanyName { get; set; }


    }
}
