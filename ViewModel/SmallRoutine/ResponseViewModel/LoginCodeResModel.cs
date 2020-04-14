using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public  class LoginCodeResModel
    {
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
        public LoginCodeResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
