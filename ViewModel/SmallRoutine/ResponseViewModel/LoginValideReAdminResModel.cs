using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public class LoginValideReAdminResModel
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess;
        /// <summary>
        /// 用户相关信息
        /// </summary>
        public ValideMiddleAdminMiddleModel Data;
        /// <summary>
        /// 基础信息
        /// </summary>
        public BaseViewModel baseViewModel;
        public LoginValideReAdminResModel()
        {
            Data = new ValideMiddleAdminMiddleModel();
            baseViewModel = new BaseViewModel();
        }
    }
}
