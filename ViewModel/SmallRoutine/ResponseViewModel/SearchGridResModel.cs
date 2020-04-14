using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public   class SearchGridResModel
    {
        public bool IsSuccess;
        public List<GridViewMiddle> peopleSearchMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public SearchGridResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
