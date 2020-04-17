using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.ClassViewModel
{
    public  class ClassKeyResViewModel
    {
        public List<ClassInfoSearchMiddleModel> classInfoSearchMiddleModels;

        public ClassKeyResViewModel()
        {
            baseViewModel = new BaseViewModel();

        }
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
    }
}
