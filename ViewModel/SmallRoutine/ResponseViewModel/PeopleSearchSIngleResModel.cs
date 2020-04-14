using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.SmallRoutine.MiddelViewModel;
using ViewModel.SmallRoutine.PublicViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel
{
    public  class PeopleSearchSIngleResModel
    {
        public List<PeopleSingeMiddle> peopleSearchMiddles;
        public BaseViewModel baseViewModel;
        public int TotalNum;
        public PeopleSearchSIngleResModel()
        {
            baseViewModel = new BaseViewModel();
        }
    }
}
