using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel
{
    public  class WeChatEnployLoginViewModel
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string Idnumber { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string telephone { get; set; }
        /// <summary>
        /// code
        /// </summary>
        public string code { get; set; }
        /// <summary>
        /// opeid
        /// </summary>
        public string openid { get; set; }
        /// <summary>
        /// 对应白名单的id
        /// </summary>
        public string whiteListId { get; set; }
        
    }
}
