using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel
{
    public class HealthInfoFollowStatasticResModel
    {
        public bool IsSuccess { get; set; }
        public HealthInfoFollowStatasticMiddleModel Data { get; set; }

        public BaseViewModel baseViewModel;
        public HealthInfoFollowStatasticResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
