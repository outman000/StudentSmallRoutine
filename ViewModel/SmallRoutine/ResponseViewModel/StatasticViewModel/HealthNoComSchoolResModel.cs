using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel
{
    public class HealthNoComSchoolResModel
    {
        public bool IsSuccess { get; set; }

        public List<HealthEverySearchMiddleModel> healthEverySearchMiddleModels { get; set; }
        public int TotalNum { get; set; }

        public BaseViewModel baseViewModel;
        public HealthNoComSchoolResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
