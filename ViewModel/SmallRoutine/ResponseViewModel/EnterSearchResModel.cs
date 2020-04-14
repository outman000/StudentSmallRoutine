using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public class EnterSearchResModel
    {
        public bool IsSuccess;
        public List<EnterMiddelViewModel>  enterMiddelViewModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public EnterSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
