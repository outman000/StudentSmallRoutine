using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel
{
    public class StudentBaseResModel
    {
        public bool IsSuccess;
        public List<StudentComtemlateMiddle>  studentComtemlateMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public StudentBaseResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
