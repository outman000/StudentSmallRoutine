using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel
{
    public class EmployBaseResModel
    {
        public bool IsSuccess;
        public List<EmployComtemlateMiddle>  employComtemlateMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public EmployBaseResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
