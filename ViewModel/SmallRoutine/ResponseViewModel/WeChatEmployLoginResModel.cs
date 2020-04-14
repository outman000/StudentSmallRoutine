using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public  class WeChatEmployLoginResModel
    {
        public bool IsSuccess;
      
        public BaseViewModel baseViewModel;
        public WeChatEmployLoginResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
