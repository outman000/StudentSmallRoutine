using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;

namespace ViewModel.SmallRoutine.RequestViewModel
{
    public  class ValidePeopleViewModel
    {
        /// <summary>
        /// 身份证
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
        /// 开始进入时间
        /// </summary>
        public DateTime? StartCreateDate { get; set; }
        /// <summary>
        /// 结束进入时间
        /// </summary>
        public DateTime? EndCreateDate { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string ContactMethod { get; set; }
        /// <summary>
        /// 居民类型
        /// </summary>
        public string residenttype { get; set; }
        /// <summary>
        /// 是否去过保底
        /// </summary>
        public string goBaoDI { get; set; }

        /// <summary>
        /// 页码
        /// </summary>
        public PageViewModel pageViewModel { get; set; }

        ValidePeopleViewModel()
        {
            pageViewModel = new PageViewModel();
        }
    }
}
