using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

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
