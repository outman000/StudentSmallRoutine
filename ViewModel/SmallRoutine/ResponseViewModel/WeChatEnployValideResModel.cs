using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    /// <summary>
    /// 企业员工登录验证code返回接口
    /// </summary>
    public class WeChatEnployValideResModel
    {
        public bool IsSuccess;
        public string openid;
        public string userid;
    }
}
