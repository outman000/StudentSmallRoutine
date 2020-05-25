using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.DayAndNightViewModel
{
    public class DefaultDayAndNightSearchResViewModel
    {
        public bool IsSuccess;
        public List<DefaultDayAndNightMiddle>  defaultDayAndNightMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public DefaultDayAndNightSearchResViewModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
