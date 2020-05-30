using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel
{
    public class SchoolSituationStatisticsResModel
    {
        public bool IsSuccess { get; set; }
        public List<SchoolSituationStatisticsMiddle> Data { get; set; }

        public BaseViewModel baseViewModel;
        public SchoolSituationStatisticsResModel()
        {
            baseViewModel = new BaseViewModel();
        }

    }
}
