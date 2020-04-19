using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;


namespace ViewModel.SmallRoutine.ResponseViewModel.StaffStationRelateViewModel
{
    public class StaffStationRelateResModel
    {
        public bool IsSuccess;
        public List<StaffStationMiddleModel>  staffStationRelateResModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StaffStationRelateResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
