using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StaffStationRelateViewModel
{
    public class StaffStationRelateResModel
    {
        public bool IsSuccess;
        public List<StaffStationRelateResModel>  staffStationRelateResModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StaffStationRelateResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
