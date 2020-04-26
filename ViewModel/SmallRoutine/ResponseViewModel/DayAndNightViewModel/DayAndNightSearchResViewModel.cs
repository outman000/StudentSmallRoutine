using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.DayAndNightViewModel
{
    public  class DayAndNightSearchResViewModel
    {
        public bool IsSuccess;
        public List<DayandNightInfoMiddle>  dayandNightInfoMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public DayAndNightSearchResViewModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
