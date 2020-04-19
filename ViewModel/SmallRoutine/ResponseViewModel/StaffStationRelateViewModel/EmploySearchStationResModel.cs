using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;


namespace ViewModel.SmallRoutine.ResponseViewModel.StaffStationRelateViewModel
{
    public class EmploySearchStationResModel
    {
        public bool IsSuccess;
        public List<EmploySearchStationMiddle>  employSearchStationResModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public EmploySearchStationResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
