using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
   public   class PeopleSearchByTelephoneResModel
    {
        public bool IsSuccess;
        public List<PeopleSearchMiddle> peopleSearchMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public PeopleSearchByTelephoneResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
