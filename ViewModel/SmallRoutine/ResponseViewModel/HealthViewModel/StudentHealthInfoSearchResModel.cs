using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.HealthViewModel
{
    public class StudentHealthInfoSearchResModel
    {
        public bool IsSuccess;
        public List<StudentHealthInfoSearchMiddle> healthInfoSearchMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StudentHealthInfoSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
