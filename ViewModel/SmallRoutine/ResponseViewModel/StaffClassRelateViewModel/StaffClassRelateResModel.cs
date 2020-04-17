using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StaffClassRelateViewModel
{
    public class StaffClassRelateResModel
    {

        public bool IsSuccess;
        public List<StaffClassMiddleModel>    staffClassMiddleModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StaffClassRelateResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
