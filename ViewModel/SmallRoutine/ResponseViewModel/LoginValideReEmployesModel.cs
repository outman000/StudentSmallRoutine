using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public class LoginValideReEmployesModel
    {

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsSuccess;
        /// <summary>
        /// 用户相关信息
        /// </summary>
        public ValideMiddleEmployMiddleModel Data;
        /// <summary>
        /// 基础信息
        /// </summary>
        public BaseViewModel baseViewModel;
        public LoginValideReEmployesModel()
        {
            Data = new ValideMiddleEmployMiddleModel();
            baseViewModel = new BaseViewModel();
        }
    }
}
