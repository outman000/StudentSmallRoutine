using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StaffStationRelateViewModel
{
    public   class EmploySearchStationAllResModel
    {

        public bool IsSuccess;
        public List<EmploySearchStationAllMiddle> employSearchStationResModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public EmploySearchStationAllResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
