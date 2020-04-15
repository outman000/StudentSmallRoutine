using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.HealthEveryViewModel
{
    public  class HealthInfoEverySearchResModel
    {
        public bool IsSuccess;
        public List<HealthEverySearchMiddleModel>  healthEverySearchMiddleModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public HealthInfoEverySearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
