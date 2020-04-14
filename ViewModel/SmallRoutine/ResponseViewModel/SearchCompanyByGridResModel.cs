using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public class SearchCompanyByGridResModel
    {
        public bool IsSuccess;
        public List<SearchCompanyMiddle> peopleSearchMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public SearchCompanyByGridResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
