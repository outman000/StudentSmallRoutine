using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public class LoginViewResModel
    {
        public bool IsSuccess;
        public string openid;
        public string userid;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public LoginViewResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
