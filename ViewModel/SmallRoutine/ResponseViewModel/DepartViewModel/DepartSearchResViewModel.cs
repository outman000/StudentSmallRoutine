using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;


namespace ViewModel.SmallRoutine.ResponseViewModel.DepartViewModel
{
    public class DepartSearchResViewModel
    {
        public bool IsSuccess;
        public List<DepartInfoSearchMiddleModel>  departSearchResViewModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public DepartSearchResViewModel()
        {
            baseViewModel = new BaseViewModel();
        }

    }
}
