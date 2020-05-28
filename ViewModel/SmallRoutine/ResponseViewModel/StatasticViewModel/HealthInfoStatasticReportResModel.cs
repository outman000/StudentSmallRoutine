using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel
{
    public class HealthInfoStatasticReportResModel
    {
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 数据列表
        /// </summary>
        public List<HealthInfoStatasticMiddleModel>  healthInfoStatasticMiddles { get; set; }

        public BaseViewModel baseViewModel;
        public HealthInfoStatasticReportResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
