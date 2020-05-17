using System;
using System.Collections.Generic;
using System.Text;
using ViewModel.PublicViewModel;
using ViewModel.SmallRoutine.MiddelViewModel;

namespace ViewModel.SmallRoutine.ResponseViewModel.SchoolViewModel
{
    public class SchoolSearchResModel
    {
        public List<SchoolSearchMiddle>  schoolSearchMiddles;

        public SchoolSearchResModel()
        {
            baseViewModel = new BaseViewModel();

        }
        public bool IsSuccess;
        public BaseViewModel baseViewModel;
    }
}
