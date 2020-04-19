using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StaffViewModel
{
    public  class StaffSearchResModel
    {
        public bool IsSuccess;
        public List<StationInfoSearchMiddleModel>  stationInfoSearchMiddleModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StaffSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }

    }
}
