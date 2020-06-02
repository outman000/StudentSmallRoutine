using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StaffClassRelateViewModel
{
    public class StaffSchoolClassRelateResModel
    {

        public bool IsSuccess;
        public List<StaffSchoolClassMiddleModel>    staffClassMiddleModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StaffSchoolClassRelateResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
