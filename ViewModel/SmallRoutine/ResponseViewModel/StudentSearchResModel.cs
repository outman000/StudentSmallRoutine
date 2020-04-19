using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

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
