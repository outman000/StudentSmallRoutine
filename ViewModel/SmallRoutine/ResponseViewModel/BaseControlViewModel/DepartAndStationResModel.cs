using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.BaseControlViewModel
{
    public class DepartAndStationResModel
    {
        public bool IsSuccess;
        public List<DepartInfoSearchMiddleModel> departInfoSearchMiddleModels;
        public List<StationInfoSearchMiddleModel> stationInfoSearchMiddleModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public DepartAndStationResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
