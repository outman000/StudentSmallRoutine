using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.GradeViewModel
{
    public class GradeKeyResViewModel
    {
        public List<GradeInfoSearchMiddleModel> gradeInfoSearchMiddleModels;

        public GradeKeyResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
    }
}
