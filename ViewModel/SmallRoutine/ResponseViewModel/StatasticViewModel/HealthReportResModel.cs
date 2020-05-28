using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel
{
    public class HealthReportResModel
    {
        public bool IsSuccess { get; set; }

        public HealthStatisticsMiddleModel healthStatisticsMiddleModel { get; set; }

        public BaseViewModel baseViewModel;
        public HealthReportResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
