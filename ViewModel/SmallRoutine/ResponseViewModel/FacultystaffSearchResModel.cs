using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public class FacultystaffSearchResModel
    {
        public bool IsSuccess;
        public List<FacultystaffMiddle> viewModels;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public FacultystaffSearchResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
