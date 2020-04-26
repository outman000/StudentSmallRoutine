using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.ExceptStudentViewModel
{
    public class ExceptStudentSearchResModel
    {
        public List<ExceptStudentSearchMiddle>  exceptStudentSearchMiddles;
        public ExceptStudentSearchResModel()
        {
            baseViewModel = new BaseViewModel();

        }
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
    }
}
