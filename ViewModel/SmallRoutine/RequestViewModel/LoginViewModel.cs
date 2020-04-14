using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.SmallRoutine.RequestViewModel
{
     public  class LoginViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public   string username { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public string userid { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }
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
    }
}
