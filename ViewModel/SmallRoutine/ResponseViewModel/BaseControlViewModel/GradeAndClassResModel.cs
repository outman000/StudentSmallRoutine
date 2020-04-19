using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;


namespace ViewModel.SmallRoutine.ResponseViewModel.BaseControlViewModel
{
    public  class GradeAndClassResModel
    {
        public bool IsSuccess;
        public List<ClassInfoSearchMiddleModel>  classInfoSearchMiddleModels;
        public List<GradeInfoSearchMiddleModel>  gradeInfoSearchMiddleModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public GradeAndClassResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
