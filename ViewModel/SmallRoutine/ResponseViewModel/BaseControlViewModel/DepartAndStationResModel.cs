using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;


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
