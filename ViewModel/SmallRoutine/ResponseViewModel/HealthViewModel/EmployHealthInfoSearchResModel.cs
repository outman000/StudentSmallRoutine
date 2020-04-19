using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.HealthViewModel
{
    public  class EmployHealthInfoSearchResModel
    {
        public bool IsSuccess;
        public List<EmployHealthInfoSearchMiddle>   employHealthInfoSearchMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public EmployHealthInfoSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
