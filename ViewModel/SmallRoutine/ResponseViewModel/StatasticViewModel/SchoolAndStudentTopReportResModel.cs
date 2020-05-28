using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.StatasticViewModel
{
    public class SchoolAndStudentTopReportResModel
    {
        public bool IsSuccess { get; set; }

        public SchoolAndStudentTopReportMiddleModel schoolAndStudentTopReportMiddleModel { get; set; }

        public BaseViewModel baseViewModel;
        public SchoolAndStudentTopReportResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
