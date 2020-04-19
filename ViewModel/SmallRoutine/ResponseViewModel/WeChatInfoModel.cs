using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public class WeChatInfoModel
    {
        /// <summary>
        /// openid
        /// </summary>
        public string openid { get; set; }
        public string session_key { get; set; }

        public string unionid { get; set; }
        /// <summary>
        /// 错误码
        /// </summary>
        public string errcode { get; set; }
        /// <summary>
        /// 错误详细信息
        /// </summary>
        public string errmsg { get; set; }
    }
}
