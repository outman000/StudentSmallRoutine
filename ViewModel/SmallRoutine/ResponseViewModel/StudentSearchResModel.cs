using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public class StudentSearchResModel
    {
        public bool IsSuccess;
        public List<StudentMiddle> viewModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StudentSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
